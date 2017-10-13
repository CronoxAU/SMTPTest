using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace SMTPTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void runTestBTN_Click(object sender, EventArgs e)
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
                    serverResponseTB.Text = "Recipent mailbox is busy. This may be a trainsent error, re-try sending.";
                }
                if (statusCode == SmtpStatusCode.MailboxUnavailable)
                {
                    serverResponseTB.Text = "Recpient mailbox is unavalaible. This may be a trainsent error, re-try sending.";
                }
                if (statusCode == SmtpStatusCode.TransactionFailed)
                {
                    serverResponseTB.Text = "Transaction with recpient mailbox is failed. This may be a trainsent error, re-try sending.";
                }
                serverResponseTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
            }
            catch (SmtpException ex)
            {
                //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpexception(v=vs.110).aspx
                sucess = false;
                SmtpStatusCode statusCode = ex.StatusCode;
                serverResponseTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
            }
            catch (Exception ex)
            {
                sucess = false;
                    serverResponseTB.Text += Environment.NewLine + Environment.NewLine + "Full Error" + ex;
            }
            if(sucess)
            {
                serverResponseTB.Text = "Mail sent sucessfully";
            }
        }
    }
}
