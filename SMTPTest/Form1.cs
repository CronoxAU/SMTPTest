using System;
using System.Windows.Forms;
using System.Net.Mail;
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
            int n;
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
            int n;
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
            if (validateAllFields())
            {
                Boolean sucess = true;
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = Int32.Parse(serverPortTB.Text);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = serverAddressTB.Text;
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
                    client.Send(mail);
                }

                //Full documentation of mail errors can at https://msdn.microsoft.com/en-us/library/swas0fwc(v=vs.110).aspx

                catch (SmtpFailedRecipientException ex)
                {
                    //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpfailedrecipientsexception(v=vs.110).aspx
                    //https://blogs.msdn.microsoft.com/jrspinella/2011/05/31/handling-exceptions-when-sending-mail-via-system-net-mail/

                    sucess = false;
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy)
                    {
                        resultsTB.Text = "Recipent mailbox is busy. This may be a trainsent error, re-try sending.";
                    }
                    if (statusCode == SmtpStatusCode.MailboxUnavailable)
                    {
                        resultsTB.Text = "Recpient mailbox is unavalaible. This may be a trainsent error, re-try sending.";
                    }
                    if (statusCode == SmtpStatusCode.TransactionFailed)
                    {
                        resultsTB.Text = "Transaction with recpient mailbox is failed. This may be a trainsent error, re-try sending.";
                    }
                    resultsTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
                }
                catch (SmtpException ex)
                {
                    //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpexception(v=vs.110).aspx
                    sucess = false;
                    SmtpStatusCode statusCode = ex.StatusCode;
                    resultsTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
                }
                catch (Exception ex)
                {
                    sucess = false;
                    resultsTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
                }
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
    }
}
