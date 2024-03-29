﻿using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace SMTPTest
{
    public partial class Form1 : Form
    {
        public Color invalidFieldColor = Color.Red;
        public Color validFieldColor = Color.White;

        public Form1()
        {
            InitializeComponent();
        }

        //verify that the server address field contains a value
        private Boolean validateServerAddressTB()
        {
            Boolean result = true;
            if (serverAddressTB.Text == "")
            {
                result = false;
                serverAddressTB.BackColor = invalidFieldColor;
            }
            else
            {
                serverAddressTB.BackColor = validFieldColor;
            }
            return result;
        }

        //verify that the server port field contains a int value, which is not greater than 0
        private Boolean validateServerPortTB()
        {
            Boolean result = true;
            int n;
            if (serverPortTB.Text == "" || !int.TryParse(serverPortTB.Text, out n) || int.Parse(serverPortTB.Text) <= 0)
            {
                result = false;
                serverPortTB.BackColor = invalidFieldColor;
            }
            else
            {
                serverPortTB.BackColor = validFieldColor;
            }
            return result;
        }

        //verify that the mail to field is not blank and contains only valid e-mail addresses
        private Boolean validateMailToTB()
        {
            Boolean result = true;
            if (mailToTB.Text != "")
            {
                foreach (var address in mailToTB.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if(!isValidEmail(address))
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            if(result)
            {
                mailToTB.BackColor = validFieldColor;
            }
            else
            {
                mailToTB.BackColor = invalidFieldColor;
            }
            return result;
            
        }

        //verify that the mail from field contains a single, valid e-mail address.
        private Boolean validateMailFromTB()
        {
            Boolean result = true;
            if (!isValidEmail(mailFromTB.Text))
            {
                result = false;
                mailFromTB.BackColor = invalidFieldColor;
            }
            else
            {
                mailFromTB.BackColor = validFieldColor;
            }
            return result;
        }

        //validate all required fields on the form. Return true if all required fields have valid data.
        //highlight any fields which fail validation, and unhighlight any fields which pass validation.
        private Boolean validateAllFields()
        {
            Boolean result = true;
            if(!validateServerAddressTB())
            {
                result = false;
            }
            if(!validateServerPortTB())
            {
                result = false;
            }
            if (!validateMailToTB())
            {
                result = false;
            }
            if (!validateMailFromTB())
            {
                result = false;
            }
            return result;
        }

        private void runTestBTN_Click(object sender, EventArgs e)
        {
            Boolean sucess = false;
            //only atempt the send if valid details have been entered.
            if (validateAllFields())
            {
                sucess = sendMail();
                if (sucess)
                {
                    resultsTB.Text = "Mail sent sucessfully";
                }
            } 
            else
            {
                resultsTB.Text = "Invalid data. Please adjust and run the test again.";
            }
        }

        private Boolean sendMail()
        {
            Boolean sucess = true;
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            String exec = "";
            String simpleErr = "";

            client.Port = Int32.Parse(serverPortTB.Text);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = serverAddressTB.Text;
            if(useAuthCB.Checked)
            {
                NetworkCredential basicCredential = new NetworkCredential(usernameTB.Text, passwordTB.Text);
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
            }
            if(useTLSCB.Checked)
            {
                client.EnableSsl = true;
            }
            mail.Subject = subjectTB.Text;
            mail.Body = bodyTB.Text;
            //mail.Attachments.Add(new Attachment(debugFileLocation));
            mail.From = new MailAddress(mailFromTB.Text);
            foreach (var address in mailToTB.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mail.To.Add(address);
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                client.Send(mail);
            }

            //Full documentation of mail errors can at https://msdn.microsoft.com/en-us/library/swas0fwc(v=vs.110).aspx

            catch (SmtpFailedRecipientException ex)
            {
                //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpfailedrecipientsexception(v=vs.110).aspx
                //https://blogs.msdn.microsoft.com/jrspinella/2011/05/31/handling-exceptions-when-sending-mail-via-system-net-mail/

                sucess = false;
                SmtpStatusCode statusCode = ex.StatusCode;
                simpleErr = getSimpleErrMsgFromSMTPCode(statusCode);
                exec = ex.ToString();
            }
            catch (SmtpException ex)
            {
                //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpexception(v=vs.110).aspx
                sucess = false;
                SmtpStatusCode statusCode = ex.StatusCode;
                simpleErr = getSimpleErrMsgFromSMTPCode(statusCode);
                exec = ex.ToString();
            }
            catch (Exception ex)
            {
                sucess = false;
                exec = ex.ToString();
            }
            if(!sucess)
            {
                resultsTB.Text = simpleErr + Environment.NewLine + Environment.NewLine + "Full Error:" + Environment.NewLine + exec;
            }
            Cursor.Current = Cursors.Default;
            return sucess;
        }

        public String getSimpleErrMsgFromSMTPCode(SmtpStatusCode statusCode)
        {
            String simpleErr = "";
            switch(statusCode)
            {
                case SmtpStatusCode.ClientNotPermitted:
                    simpleErr = "Client is not authenticated or not allowed to send through this host.";
                    break;
                case SmtpStatusCode.ExceededStorageAllocation:
                    simpleErr = "The message is too large for the destination mailbox.";
                    break;
                case SmtpStatusCode.GeneralFailure:
                    simpleErr = "General failure, this typically indicates the host could not be found. Verify the server address and port number.";
                    break;
                case SmtpStatusCode.InsufficientStorage:
                    simpleErr = "SMTP server has insifficent storage.";
                    break;
                case SmtpStatusCode.LocalErrorInProcessing:
                    simpleErr = "Mail request denied. This can occur with the client's IP accress cannot be resolved (ie reserve lookup failed), or the client domain has been identified as an open relay or spam source.";
                    break;
                case SmtpStatusCode.MailboxBusy:
                    simpleErr = "Recipent mailbox is busy. This may be a trainsent error, re-try sending.";
                    break;
                case SmtpStatusCode.MailboxUnavailable:
                    simpleErr = "Recpient mailbox is unavalaible. This may be a trainsent error, re-try sending.";
                    break;
                case SmtpStatusCode.TransactionFailed:
                    simpleErr = "Transaction with recpient mailbox is failed. This may be a trainsent error, re-try sending.";
                    break;
                case SmtpStatusCode.MustIssueStartTlsFirst:
                    simpleErr = "The SMTP server only appects TLS connections. Please confgiure the test to use TLS";
                    break;
                case SmtpStatusCode.ServiceNotAvailable:
                    simpleErr = "SMTP is not avalaible on this server";
                    break;
            }
            return simpleErr;
        }

        private void serverAddressTB_Leave(object sender, EventArgs e)
        {
            validateServerAddressTB();
        }

        private Boolean isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void serverPortTB_Leave(object sender, EventArgs e)
        {
            validateServerPortTB();
        }

        private void mailToTB_Leave(object sender, EventArgs e)
        {
            validateMailToTB();
        }

        private void mailFromTB_Leave(object sender, EventArgs e)
        {
            validateMailFromTB();
        }

        private void useAuthCB_CheckedChanged(object sender, EventArgs e)
        {
            checkAuth();
        }

        private void checkAuth()
        {
            if (useAuthCB.Checked)
            {
                usernameTB.Enabled = true;
                passwordTB.Enabled = true;
            }
            else
            {
                usernameTB.Enabled = false;
                passwordTB.Enabled = false;
            }
        }

        private void checkTLS()
        {
            if (useTLSCB.Checked)
            {
                serverPortTB.Text = "587";
            }
            else
            {
                serverPortTB.Text = "25";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkAuth();
            checkTLS();
        }
    }
}
