using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DnsClient;

namespace SMTPTest
{
    public partial class Form1 : Form
    {
        public Color invalidFieldColor = Color.Red;
        public Color validFieldColor = Color.White;
        private Dictionary<Control, Timer> fadingControls = new Dictionary<Control, Timer>();
        private Dictionary<Control, int> fadeSteps = new Dictionary<Control, int>();
        private const int FADE_DURATION_MS = 5000;
        private const int FADE_INTERVAL_MS = 50;
        private const int FADE_STEPS = FADE_DURATION_MS / FADE_INTERVAL_MS;

        public Form1()
        {
            InitializeComponent();
        }


        //validate all required fields on the form. Return true if all required fields have valid data.
        //highlight any fields which fail validation, and unhighlight any fields which pass validation.
        private Boolean validateEmailTestFields()
        {
            Boolean result = true;

            // Validate server address
            if (string.IsNullOrWhiteSpace(serverAddressTB.Text))
            {
                result = false;
                SetFieldInvalid(serverAddressTB);
            }
            else
            {
                SetFieldValid(serverAddressTB);
            }

            // Validate server port
            int port;
            if (string.IsNullOrWhiteSpace(serverPortTB.Text) || 
                !int.TryParse(serverPortTB.Text, out port) || 
                port <= 0 || 
                port > 65535)
            {
                result = false;
                SetFieldInvalid(serverPortTB);
            }
            else
            {
                SetFieldValid(serverPortTB);
            }

            // Validate mail from address
            if (string.IsNullOrWhiteSpace(mailFromTB.Text) || !isValidEmail(mailFromTB.Text))
            {
                result = false;
                SetFieldInvalid(mailFromTB);
            }
            else
            {
                SetFieldValid(mailFromTB);
            }

            // Validate mail to addresses
            if (string.IsNullOrWhiteSpace(mailToTB.Text))
            {
                result = false;
                SetFieldInvalid(mailToTB);
            }
            else
            {
                Boolean allToAddressesValid = true;
                foreach (var address in mailToTB.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!isValidEmail(address.Trim()))
                    {
                        allToAddressesValid = false;
                        break;
                    }
                }

                if (allToAddressesValid)
                {
                    SetFieldValid(mailToTB);
                }
                else
                {
                    result = false;
                    SetFieldInvalid(mailToTB);
                }
            }

            // Validate username and password if authentication is enabled
            if (useAuthCB.Checked)
            {
                if (string.IsNullOrWhiteSpace(usernameTB.Text))
                {
                    result = false;
                    SetFieldInvalid(usernameTB);
                }
                else
                {
                    SetFieldValid(usernameTB);
                }

                if (string.IsNullOrWhiteSpace(passwordTB.Text))
                {
                    result = false;
                    SetFieldInvalid(passwordTB);
                }
                else
                {
                    SetFieldValid(passwordTB);
                }
            }
            else
            {
                // Reset colors when authentication is not required
                SetFieldValid(usernameTB);
                SetFieldValid(passwordTB);
            }

            return result;
        }

        private void runTestBTN_Click(object sender, EventArgs e)
        {
            // clear the results box before running the test
            resultsTB.Clear();
            Boolean sucess = false;
            //only atempt the send if valid details have been entered.
            if (validateEmailTestFields())
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
                    simpleErr = "General failure. This typically indicates the host could not be found. Verify the server address and port number.";
                    break;
                case SmtpStatusCode.InsufficientStorage:
                    simpleErr = "SMTP server has insufficient storage.";
                    break;
                case SmtpStatusCode.LocalErrorInProcessing:
                    simpleErr = "Mail request denied. This can occur when the client's IP address cannot be resolved (i.e., reverse lookup failed), or the client domain has been identified as an open relay or spam source.";
                    break;
                case SmtpStatusCode.MailboxBusy:
                    simpleErr = "Recipient mailbox is busy. This may be a transient error, retry sending.";
                    break;
                case SmtpStatusCode.MailboxUnavailable:
                    simpleErr = "Recipient mailbox is unavailable. This may be a transient error, retry sending.";
                    break;
                case SmtpStatusCode.MailboxNameNotAllowed:
                    simpleErr = "Mailbox name is not allowed. The email address may contain invalid characters or format.";
                    break;
                case SmtpStatusCode.TransactionFailed:
                    simpleErr = "Transaction with recipient mailbox failed. This may be a transient error, retry sending.";
                    break;
                case SmtpStatusCode.UserNotLocalTryAlternatePath:
                    simpleErr = "User is not local to this server. The server may require using an alternate path or relay.";
                    break;
                case SmtpStatusCode.UserNotLocalWillForward:
                    simpleErr = "User is not local to this server, but the server will forward the message.";
                    break;
                case SmtpStatusCode.MustIssueStartTlsFirst:
                    simpleErr = "The SMTP server only accepts TLS connections. Please configure the test to use TLS.";
                    break;
                case SmtpStatusCode.ServiceNotAvailable:
                    simpleErr = "SMTP service is not available on this server.";
                    break;
                case SmtpStatusCode.CommandNotImplemented:
                    simpleErr = "Command not implemented by the SMTP server.";
                    break;
                case SmtpStatusCode.CommandParameterNotImplemented:
                    simpleErr = "Command parameter not implemented by the SMTP server.";
                    break;
                case SmtpStatusCode.SyntaxError:
                    simpleErr = "Syntax error in command or arguments. Check your SMTP configuration.";
                    break;
                case SmtpStatusCode.CommandUnrecognized:
                    simpleErr = "Command not recognized by the SMTP server.";
                    break;
                case SmtpStatusCode.BadCommandSequence:
                    simpleErr = "Commands sent in incorrect sequence. This may indicate an authentication or configuration issue.";
                    break;
                case SmtpStatusCode.Ok:
                    simpleErr = "Mail sent successfully.";
                    break;
                default:
                    simpleErr = $"SMTP error occurred (Code: {statusCode}). Check server logs for more details.";
                    break;
            }
            return simpleErr;
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

        private void SetFieldInvalid(Control control)
        {
            // Stop any existing fade for this control
            if (fadingControls.ContainsKey(control))
            {
                fadingControls[control].Stop();
                fadingControls[control].Dispose();
                fadingControls.Remove(control);
            }

            if (fadeSteps.ContainsKey(control))
            {
                fadeSteps.Remove(control);
            }

            // Set initial invalid color (stronger red/pink)
            control.BackColor = Color.FromArgb(255, 180, 180);

            // Initialize fade counter
            fadeSteps[control] = 0;

            // Create and start fade timer
            Timer fadeTimer = new Timer();
            fadeTimer.Interval = FADE_INTERVAL_MS;
            fadeTimer.Tick += (sender, e) => FadeFieldToValid(control, fadeTimer);
            fadingControls[control] = fadeTimer;
            fadeTimer.Start();
        }

        private void FadeFieldToValid(Control control, Timer timer)
        {
            if (!fadeSteps.ContainsKey(control))
            {
                timer.Stop();
                timer.Dispose();
                if (fadingControls.ContainsKey(control))
                    fadingControls.Remove(control);
                return;
            }

            fadeSteps[control]++;
            int currentStep = fadeSteps[control];

            if (currentStep >= FADE_STEPS)
            {
                // Fade complete - set to valid color
                control.BackColor = validFieldColor;
                timer.Stop();
                timer.Dispose();
                fadingControls.Remove(control);
                fadeSteps.Remove(control);
            }
            else
            {
                // Calculate interpolated color (from red/pink to white)
                // Fade from RGB(255, 180, 180) to RGB(255, 255, 255)
                float progress = (float)currentStep / FADE_STEPS;
                int red = 255; // Keep red at maximum
                int green = (int)(180 + (255 - 180) * progress);
                int blue = (int)(180 + (255 - 180) * progress);
                control.BackColor = Color.FromArgb(red, green, blue);
            }
        }

        private void SetFieldValid(Control control)
        {
            // Stop any existing fade for this control
            if (fadingControls.ContainsKey(control))
            {
                fadingControls[control].Stop();
                fadingControls[control].Dispose();
                fadingControls.Remove(control);
            }

            if (fadeSteps.ContainsKey(control))
            {
                fadeSteps.Remove(control);
            }

            // Set to valid color immediately
            control.BackColor = validFieldColor;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void domainLookupBTN_Click(object sender, EventArgs e)
        {
            string domain = domainAddressTB.Text.Trim();

            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("Please enter a domain name.", "Domain Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clear all result fields before starting the lookup
            mxRecordTB.Text = "";
            spfRecordTB.Text = "";
            dmarcRecordTB.Text = "";
            dkimRecordTB.Text = "";
            resultsTB.Clear();
            domainHasValidSpfCB.Checked = false;
            domainHasValidDkimCB.Checked = false;
            domainHasValidDmarcCB.Checked = false;
            ResetCheckBoxColor(domainHasValidSpfCB);
            ResetCheckBoxColor(domainHasValidDkimCB);
            ResetCheckBoxColor(domainHasValidDmarcCB);

            // Force the UI to refresh and show the cleared fields
            this.Refresh();
            Application.DoEvents();

            try
            { 
                Cursor.Current = Cursors.WaitCursor;

                // Lookup MX record
                string mxRecord = GetHighestPriorityMX(domain);
                mxRecordTB.Text = mxRecord;

                // Lookup SPF record
                string spfRecord = GetSPFRecord(domain, out string spfDebugInfo);
                spfRecordTB.Text = spfRecord;
                AppendColoredText("=== SPF Lookup ===" + Environment.NewLine, Color.Black, true);
                AppendColoredText(spfDebugInfo + Environment.NewLine, Color.Black, false);

                // Validate SPF record
                bool hasSpfWarnings = false;
                if (!spfRecord.StartsWith("No SPF") && !spfRecord.StartsWith("Error"))
                {
                    bool isValidSpf = ValidateSPFRecord(spfRecord, out string spfValidationMsg);
                    domainHasValidSpfCB.Checked = isValidSpf;
                    SetCheckBoxColor(domainHasValidSpfCB, isValidSpf);

                    hasSpfWarnings = !string.IsNullOrEmpty(spfValidationMsg);
                    Color validationColor = isValidSpf ? (hasSpfWarnings ? Color.Orange : Color.Green) : Color.Red;
                    AppendColoredText("SPF Validation: " + (isValidSpf ? "VALID" : "INVALID") + Environment.NewLine, validationColor, true);

                    if (hasSpfWarnings)
                    {
                        AppendValidationMessages(spfValidationMsg);
                    }
                }
                AppendColoredText(Environment.NewLine, Color.Black, false);

                // Lookup DKIM record
                string dkimRecord = GetDKIMRecord(domain, out string dkimDebugInfo);
                dkimRecordTB.Text = dkimRecord;
                AppendColoredText("=== DKIM Lookup ===" + Environment.NewLine, Color.Black, true);
                AppendColoredText(dkimDebugInfo + Environment.NewLine, Color.Black, false);

                // Validate DKIM record
                bool hasDkimWarnings = false;
                if (!dkimRecord.StartsWith("No DKIM") && !dkimRecord.StartsWith("Error"))
                {
                    bool isValidDkim = ValidateDKIMRecord(dkimRecord, out string dkimValidationMsg);
                    domainHasValidDkimCB.Checked = isValidDkim;
                    SetCheckBoxColor(domainHasValidDkimCB, isValidDkim);

                    hasDkimWarnings = !string.IsNullOrEmpty(dkimValidationMsg);
                    Color validationColor = isValidDkim ? (hasDkimWarnings ? Color.Orange : Color.Green) : Color.Red;
                    AppendColoredText("DKIM Validation: " + (isValidDkim ? "VALID" : "INVALID") + Environment.NewLine, validationColor, true);

                    if (hasDkimWarnings)
                    {
                        AppendValidationMessages(dkimValidationMsg);
                    }
                }
                AppendColoredText(Environment.NewLine, Color.Black, false);

                // Lookup DMARC record
                string dmarcRecord = GetDMARCRecord(domain, out string dmarcDebugInfo);
                dmarcRecordTB.Text = dmarcRecord;
                AppendColoredText("=== DMARC Lookup ===" + Environment.NewLine, Color.Black, true);
                AppendColoredText(dmarcDebugInfo + Environment.NewLine, Color.Black, false);

                // Validate DMARC record
                bool hasDmarcWarnings = false;
                if (!dmarcRecord.StartsWith("No DMARC") && !dmarcRecord.StartsWith("Error"))
                {
                    bool isValidDmarc = ValidateDMARCRecord(dmarcRecord, out string dmarcValidationMsg);
                    domainHasValidDmarcCB.Checked = isValidDmarc;
                    SetCheckBoxColor(domainHasValidDmarcCB, isValidDmarc);

                    hasDmarcWarnings = !string.IsNullOrEmpty(dmarcValidationMsg);
                    Color validationColor = isValidDmarc ? (hasDmarcWarnings ? Color.Orange : Color.Green) : Color.Red;
                    AppendColoredText("DMARC Validation: " + (isValidDmarc ? "VALID" : "INVALID") + Environment.NewLine, validationColor, true);

                    if (hasDmarcWarnings)
                    {
                        AppendValidationMessages(dmarcValidationMsg);
                    }
                }
                

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error performing DNS lookup: " + ex.Message, "DNS Lookup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCheckBoxColor(CheckBox checkBox, bool isValid)
        {
            checkBox.ForeColor = isValid ? Color.Green : Color.Red;
        }

        private void ResetCheckBoxColor(CheckBox checkBox)
        {
            checkBox.ForeColor = SystemColors.ControlText;
        }

        private void AppendColoredText(string text, Color color, bool bold)
        {
            int start = resultsTB.TextLength;
            resultsTB.AppendText(text);
            int end = resultsTB.TextLength;

            resultsTB.Select(start, end - start);
            resultsTB.SelectionColor = color;
            if (bold)
            {
                resultsTB.SelectionFont = new Font(resultsTB.Font, FontStyle.Bold);
            }
            resultsTB.SelectionLength = 0;
            resultsTB.Select(end, 0);
        }

        private void AppendValidationMessages(string validationMsg)
        {
            string[] lines = validationMsg.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.StartsWith("ERROR:"))
                {
                    AppendColoredText(line + Environment.NewLine, Color.Red, false);
                }
                else if (line.StartsWith("WARNING:"))
                {
                    AppendColoredText(line + Environment.NewLine, Color.Orange, false);
                }
                else if (line.StartsWith("INFO:"))
                {
                    AppendColoredText(line + Environment.NewLine, Color.Blue, false);
                }
                else
                {
                    AppendColoredText(line + Environment.NewLine, Color.Black, false);
                }
            }
        }

        private string GetHighestPriorityMX(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domain, QueryType.MX);

                var mxRecords = result.Answers.MxRecords().ToList();

                if (mxRecords.Count == 0)
                {
                    return "No MX records found.";
                }

                var highestPriority = mxRecords.OrderBy(mx => mx.Preference).First();
                return highestPriority.Exchange.Value.TrimEnd('.') + " (Priority: " + highestPriority.Preference + ")";
            }
            catch (Exception ex)
            {
                return "MX lookup failed: " + ex.Message;
            }
        }

        private string GetSPFRecord(string domain, out string debugInfo)
        {
            StringBuilder debug = new StringBuilder();
            StringBuilder spfRecords = new StringBuilder();

            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domain, QueryType.TXT);

                debug.AppendLine($"DNS Query completed. Answer count: {result.Answers.Count}");

                int recordCount = 0;
                foreach (var txtRecord in result.Answers.TxtRecords())
                {
                    recordCount++;
                    // TXT records can have multiple strings that need to be concatenated
                    string txtValue = string.Join("", txtRecord.Text);
                    if (txtValue.StartsWith("v=spf1", StringComparison.OrdinalIgnoreCase))
                    {
                        debug.AppendLine($"Record #{recordCount}: {txtValue}");
                        if (spfRecords.Length > 0)
                            spfRecords.AppendLine();
                        spfRecords.Append(txtValue);
                    }
                }
                debug.AppendLine($"SPF records found: {(spfRecords.Length > 0 ? "Yes" : "No")}");

                debugInfo = debug.ToString();

                if (spfRecords.Length == 0)
                {
                    return "No SPF record found.";
                }

                return spfRecords.ToString();
            }
            catch (Exception ex)
            {
                debugInfo = "SPF lookup failed: " + ex.Message;
                return "Error querying SPF record.";
            }
        }

        private string GetDMARCRecord(string domain, out string debugInfo)
        {
            StringBuilder debug = new StringBuilder();
            StringBuilder dmarcRecords = new StringBuilder();

            try
            {
                // DMARC records are stored as TXT records at _dmarc.domain.com
                string dmarcDomain = "_dmarc." + domain;
                var lookup = new LookupClient();
                var result = lookup.Query(dmarcDomain, QueryType.TXT);

                debug.AppendLine($"Querying: {dmarcDomain}");
                debug.AppendLine($"DNS Query completed. Answer count: {result.Answers.Count}");

                int recordCount = 0;
                foreach (var txtRecord in result.Answers.TxtRecords())
                {
                    recordCount++;
                    // TXT records can have multiple strings that need to be concatenated
                    string txtValue = string.Join("", txtRecord.Text);
                    if (txtValue.StartsWith("v=DMARC1", StringComparison.OrdinalIgnoreCase))
                    {
                        debug.AppendLine($"Record #{recordCount}: {txtValue}");
                        if (dmarcRecords.Length > 0)
                            dmarcRecords.AppendLine();
                        dmarcRecords.Append(txtValue);
                    }
                }
                debug.AppendLine($"DMARC records found: {(dmarcRecords.Length > 0 ? "Yes" : "No")}");

                debugInfo = debug.ToString();

                if (dmarcRecords.Length == 0)
                {
                    return "No DMARC record found.";
                }

                return dmarcRecords.ToString();
            }
            catch (Exception ex)
            {
                debugInfo = "DMARC lookup failed: " + ex.Message;
                return "Error querying DMARC record.";
            }
        }

        private string GetDKIMRecord(string domain, out string debugInfo)
        {
            StringBuilder debug = new StringBuilder();

            try
            {
                // DKIM records require a selector. Common selectors to try:
                string[] commonSelectors = { "default", "selector1", "selector2", "google", "k1", "dkim", "mail", "s1", "s2" };

                foreach (string selector in commonSelectors)
                {
                    string dkimDomain = selector + "._domainkey." + domain;
                    debug.AppendLine($"Trying selector '{selector}' at: {dkimDomain}");

                    try
                    {
                        var lookup = new LookupClient();
                        var result = lookup.Query(dkimDomain, QueryType.TXT);

                        if (result.Answers.Count > 0)
                        {
                            foreach (var txtRecord in result.Answers.TxtRecords())
                            {
                                string txtValue = string.Join("", txtRecord.Text);

                                // DKIM records typically contain "v=DKIM1" or "k=rsa" or "p=" (public key)
                                if (txtValue.Contains("v=DKIM1") || txtValue.Contains("k=rsa") || txtValue.Contains("p="))
                                {
                                    debug.AppendLine($"  -> DKIM record found with selector '{selector}'!");
                                    debug.AppendLine($"  Record: {txtValue}");
                                    debugInfo = debug.ToString();
                                    return $"Selector: {selector}\n{txtValue}";
                                }
                            }
                        }
                    }
                    catch
                    {
                        debug.AppendLine($"  No record found for selector '{selector}'");
                    }
                }

                debug.AppendLine();
                debug.AppendLine("No DKIM records found with common selectors.");
                debug.AppendLine("DKIM requires knowing the specific selector used by the domain.");
                debugInfo = debug.ToString();

                return "No DKIM record found with common selectors. DKIM requires the specific selector name.";
            }
            catch (Exception ex)
            {
                debugInfo = "DKIM lookup failed: " + ex.Message;
                return "Error querying DKIM record.";
            }
        }

        private bool ValidateSPFRecord(string spfRecord, out string validationMessage)
        {
            StringBuilder validation = new StringBuilder();
            bool isValid = true;

            try
            {
                // SPF record must start with "v=spf1"
                if (!spfRecord.TrimStart().StartsWith("v=spf1", StringComparison.OrdinalIgnoreCase))
                {
                    validation.AppendLine("ERROR: SPF record must start with 'v=spf1'");
                    isValid = false;
                }

                // Split the record into mechanisms
                string[] parts = spfRecord.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                bool hasAll = false;
                int allPosition = -1;

                for (int i = 0; i < parts.Length; i++)
                {
                    string part = parts[i].Trim();

                    if (i == 0 && part.StartsWith("v=spf1", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Check for "all" directive
                    if (part.Equals("all", StringComparison.OrdinalIgnoreCase) ||
                        part.Equals("+all", StringComparison.OrdinalIgnoreCase) ||
                        part.Equals("-all", StringComparison.OrdinalIgnoreCase) ||
                        part.Equals("~all", StringComparison.OrdinalIgnoreCase) ||
                        part.Equals("?all", StringComparison.OrdinalIgnoreCase))
                    {
                        hasAll = true;
                        allPosition = i;

                        if (i < parts.Length - 1)
                        {
                            validation.AppendLine("WARNING: 'all' directive should be the last mechanism");
                        }
                    }

                    // Validate known mechanisms and modifiers
                    string mechanism = part.ToLower();
                    if (mechanism.StartsWith("+") || mechanism.StartsWith("-") || 
                        mechanism.StartsWith("~") || mechanism.StartsWith("?"))
                    {
                        mechanism = mechanism.Substring(1);
                    }

                    // Check if it's a valid mechanism or modifier
                    if (!IsValidSPFMechanism(mechanism))
                    {
                        validation.AppendLine($"WARNING: Unknown or invalid mechanism/modifier: '{part}'");
                    }
                }

                if (!hasAll)
                {
                    validation.AppendLine("WARNING: SPF record should end with an 'all' mechanism (e.g., -all, ~all, or ?all)");
                }

                // Check for common issues
                if (spfRecord.Length > 512)
                {
                    validation.AppendLine("WARNING: SPF record exceeds 512 characters (may cause DNS issues)");
                }

                int includeCount = 0;
                foreach (string part in parts)
                {
                    if (part.StartsWith("include:", StringComparison.OrdinalIgnoreCase))
                        includeCount++;
                }
                if (includeCount > 10)
                {
                    validation.AppendLine("WARNING: More than 10 DNS lookups detected (SPF has a 10 lookup limit)");
                }

                validationMessage = validation.ToString();
                return isValid;
            }
            catch (Exception ex)
            {
                validationMessage = "Error validating SPF record: " + ex.Message;
                return false;
            }
        }

        private bool IsValidSPFMechanism(string mechanism)
        {
            // Remove qualifier prefix if present
            if (mechanism.StartsWith("+") || mechanism.StartsWith("-") || 
                mechanism.StartsWith("~") || mechanism.StartsWith("?"))
            {
                mechanism = mechanism.Substring(1);
            }

            // Valid SPF mechanisms
            string[] validMechanisms = { "all", "include:", "a", "mx", "ip4:", "ip6:", "exists:", "ptr" };

            foreach (string valid in validMechanisms)
            {
                if (mechanism.Equals(valid, StringComparison.OrdinalIgnoreCase) || 
                    mechanism.StartsWith(valid, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            // Valid SPF modifiers
            string[] validModifiers = { "redirect=", "exp=" };
            foreach (string valid in validModifiers)
            {
                if (mechanism.StartsWith(valid, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidateDMARCRecord(string dmarcRecord, out string validationMessage)
        {
            StringBuilder validation = new StringBuilder();
            bool isValid = true;

            try
            {
                // DMARC record must start with "v=DMARC1"
                if (!dmarcRecord.TrimStart().StartsWith("v=DMARC1", StringComparison.OrdinalIgnoreCase))
                {
                    validation.AppendLine("ERROR: DMARC record must start with 'v=DMARC1'");
                    isValid = false;
                }

                // Parse tags
                string[] tags = dmarcRecord.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                bool hasPolicy = false;
                bool hasRua = false;
                bool hasRuf = false;

                foreach (string tag in tags)
                {
                    string trimmedTag = tag.Trim();

                    if (trimmedTag.StartsWith("v=", StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (trimmedTag.StartsWith("p=", StringComparison.OrdinalIgnoreCase))
                    {
                        hasPolicy = true;
                        string policy = trimmedTag.Substring(2).Trim().ToLower();
                        if (policy != "none" && policy != "quarantine" && policy != "reject")
                        {
                            validation.AppendLine($"ERROR: Invalid policy value '{policy}'. Must be 'none', 'quarantine', or 'reject'");
                            isValid = false;
                        }
                        if (policy == "none")
                        {
                            validation.AppendLine("INFO: Policy is set to 'none' (monitoring only, no action taken)");
                        }
                    }
                    else if (trimmedTag.StartsWith("sp=", StringComparison.OrdinalIgnoreCase))
                    {
                        string subdomainPolicy = trimmedTag.Substring(3).Trim().ToLower();
                        if (subdomainPolicy != "none" && subdomainPolicy != "quarantine" && subdomainPolicy != "reject")
                        {
                            validation.AppendLine($"ERROR: Invalid subdomain policy value '{subdomainPolicy}'");
                            isValid = false;
                        }
                    }
                    else if (trimmedTag.StartsWith("rua=", StringComparison.OrdinalIgnoreCase))
                    {
                        hasRua = true;
                    }
                    else if (trimmedTag.StartsWith("ruf=", StringComparison.OrdinalIgnoreCase))
                    {
                        hasRuf = true;
                    }
                    else if (trimmedTag.StartsWith("pct=", StringComparison.OrdinalIgnoreCase))
                    {
                        string pctValue = trimmedTag.Substring(4).Trim();
                        if (int.TryParse(pctValue, out int pct))
                        {
                            if (pct < 0 || pct > 100)
                            {
                                validation.AppendLine($"ERROR: pct value must be between 0 and 100, found '{pct}'");
                                isValid = false;
                            }
                        }
                        else
                        {
                            validation.AppendLine($"ERROR: Invalid pct value '{pctValue}'");
                            isValid = false;
                        }
                    }
                    else if (trimmedTag.StartsWith("adkim=", StringComparison.OrdinalIgnoreCase))
                    {
                        string adkim = trimmedTag.Substring(6).Trim().ToLower();
                        if (adkim != "r" && adkim != "s")
                        {
                            validation.AppendLine($"ERROR: adkim must be 'r' (relaxed) or 's' (strict), found '{adkim}'");
                            isValid = false;
                        }
                    }
                    else if (trimmedTag.StartsWith("aspf=", StringComparison.OrdinalIgnoreCase))
                    {
                        string aspf = trimmedTag.Substring(5).Trim().ToLower();
                        if (aspf != "r" && aspf != "s")
                        {
                            validation.AppendLine($"ERROR: aspf must be 'r' (relaxed) or 's' (strict), found '{aspf}'");
                            isValid = false;
                        }
                    }
                }

                if (!hasPolicy)
                {
                    validation.AppendLine("ERROR: DMARC record must include a 'p=' policy tag");
                    isValid = false;
                }

                if (!hasRua && !hasRuf)
                {
                    validation.AppendLine("WARNING: No reporting addresses specified (rua or ruf). You won't receive DMARC reports.");
                }

                validationMessage = validation.ToString();
                return isValid;
            }
            catch (Exception ex)
            {
                validationMessage = "Error validating DMARC record: " + ex.Message;
                return false;
            }
        }

        private bool ValidateDKIMRecord(string dkimRecord, out string validationMessage)
        {
            StringBuilder validation = new StringBuilder();
            bool isValid = true;

            try
            {
                // Extract just the record part if it includes "Selector: xxx\n"
                string recordToValidate = dkimRecord;
                if (dkimRecord.Contains("Selector:"))
                {
                    int newlineIndex = dkimRecord.IndexOf('\n');
                    if (newlineIndex > 0)
                    {
                        recordToValidate = dkimRecord.Substring(newlineIndex + 1).Trim();
                    }
                }

                // Parse tags
                string[] tags = recordToValidate.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                bool hasPublicKey = false;
                bool hasVersion = false;

                foreach (string tag in tags)
                {
                    string trimmedTag = tag.Trim();

                    if (trimmedTag.StartsWith("v=", StringComparison.OrdinalIgnoreCase))
                    {
                        hasVersion = true;
                        string version = trimmedTag.Substring(2).Trim();
                        if (!version.Equals("DKIM1", StringComparison.OrdinalIgnoreCase))
                        {
                            validation.AppendLine($"WARNING: DKIM version should be 'DKIM1', found '{version}'");
                        }
                    }
                    else if (trimmedTag.StartsWith("p=", StringComparison.OrdinalIgnoreCase))
                    {
                        hasPublicKey = true;
                        string publicKey = trimmedTag.Substring(2).Trim();
                        if (string.IsNullOrEmpty(publicKey))
                        {
                            validation.AppendLine("ERROR: Public key (p=) is empty. This revokes the DKIM key.");
                            isValid = false;
                        }
                        else if (publicKey.Length < 100)
                        {
                            validation.AppendLine("WARNING: Public key seems unusually short");
                        }
                    }
                    else if (trimmedTag.StartsWith("k=", StringComparison.OrdinalIgnoreCase))
                    {
                        string keyType = trimmedTag.Substring(2).Trim().ToLower();
                        if (keyType != "rsa" && keyType != "ed25519")
                        {
                            validation.AppendLine($"WARNING: Unknown key type '{keyType}'. Common types are 'rsa' and 'ed25519'");
                        }
                    }
                    else if (trimmedTag.StartsWith("t=", StringComparison.OrdinalIgnoreCase))
                    {
                        string flags = trimmedTag.Substring(2).Trim().ToLower();
                        if (flags.Contains("y"))
                        {
                            validation.AppendLine("INFO: DKIM key is in testing mode (t=y)");
                        }
                        if (flags.Contains("s"))
                        {
                            validation.AppendLine("INFO: DKIM key requires strict domain matching (t=s)");
                        }
                    }
                    else if (trimmedTag.StartsWith("h=", StringComparison.OrdinalIgnoreCase))
                    {
                        // Hash algorithms - informational only
                    }
                    else if (trimmedTag.StartsWith("s=", StringComparison.OrdinalIgnoreCase))
                    {
                        // Service type - informational only
                    }
                    else if (trimmedTag.StartsWith("n=", StringComparison.OrdinalIgnoreCase))
                    {
                        // Notes - informational only
                    }
                    else if (!string.IsNullOrWhiteSpace(trimmedTag))
                    {
                        validation.AppendLine($"WARNING: Unknown DKIM tag: '{trimmedTag.Split('=')[0]}'");
                    }
                }

                if (!hasPublicKey)
                {
                    validation.AppendLine("ERROR: DKIM record must include a public key (p=)");
                    isValid = false;
                }

                if (!hasVersion)
                {
                    validation.AppendLine("INFO: DKIM version (v=DKIM1) not specified. This is optional but recommended.");
                }

                validationMessage = validation.ToString();
                return isValid;
            }
            catch (Exception ex)
            {
                validationMessage = "Error validating DKIM record: " + ex.Message;
                return false;
            }
        }

        private void lookupFromDomainBTN_Click(object sender, EventArgs e)
        {
            // Extract domain from the mailFromTB email address
            string emailAddress = mailFromTB.Text.Trim();

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                MessageBox.Show("Please enter an email address in the 'From' field first.", "Email Address Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the email address format
            if (!isValidEmail(emailAddress))
            {
                MessageBox.Show("Please enter a valid email address in the 'From' field.", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract domain from email address (everything after the @ symbol)
            int atIndex = emailAddress.IndexOf('@');
            if (atIndex > 0 && atIndex < emailAddress.Length - 1)
            {
                string domain = emailAddress.Substring(atIndex + 1);

                // Set the domain in the domainAddressTB field
                domainAddressTB.Text = domain;

                // Trigger the domain lookup button click
                domainLookupBTN.PerformClick();
            }
            else
            {
                MessageBox.Show("Unable to extract domain from the email address.", "Domain Extraction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
