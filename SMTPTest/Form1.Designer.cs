namespace SMTPTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendEmailTestBTN = new System.Windows.Forms.Button();
            this.resultsTB = new System.Windows.Forms.RichTextBox();
            this.resultsLBL = new System.Windows.Forms.Label();
            this.serverAddressTB = new System.Windows.Forms.TextBox();
            this.serverAddressLBL = new System.Windows.Forms.Label();
            this.mailToLBL = new System.Windows.Forms.Label();
            this.mailToTB = new System.Windows.Forms.TextBox();
            this.mailFromLBL = new System.Windows.Forms.Label();
            this.mailFromTB = new System.Windows.Forms.TextBox();
            this.usernameLBL = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordLBL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.subjectLBL = new System.Windows.Forms.Label();
            this.subjectTB = new System.Windows.Forms.TextBox();
            this.bodyLBL = new System.Windows.Forms.Label();
            this.bodyTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverPortTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.useTLSCB = new System.Windows.Forms.CheckBox();
            this.useAuthCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.domainHasValidDmarcCB = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dkimRecordTB = new System.Windows.Forms.TextBox();
            this.domainHasValidDkimCB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dmarcRecordTB = new System.Windows.Forms.TextBox();
            this.domainHasValidSpfCB = new System.Windows.Forms.CheckBox();
            this.domainLookupBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.spfRecordTB = new System.Windows.Forms.TextBox();
            this.domainAddressTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mxRecordTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendEmailTestBTN
            // 
            this.sendEmailTestBTN.Location = new System.Drawing.Point(116, 236);
            this.sendEmailTestBTN.Name = "sendEmailTestBTN";
            this.sendEmailTestBTN.Size = new System.Drawing.Size(124, 23);
            this.sendEmailTestBTN.TabIndex = 3;
            this.sendEmailTestBTN.Text = "Send Test Mail";
            this.sendEmailTestBTN.UseVisualStyleBackColor = true;
            this.sendEmailTestBTN.Click += new System.EventHandler(this.runTestBTN_Click);
            // 
            // resultsTB
            // 
            this.resultsTB.Location = new System.Drawing.Point(12, 299);
            this.resultsTB.Name = "resultsTB";
            this.resultsTB.ReadOnly = true;
            this.resultsTB.Size = new System.Drawing.Size(808, 338);
            this.resultsTB.TabIndex = 9;
            this.resultsTB.Text = "";
            // 
            // resultsLBL
            // 
            this.resultsLBL.AutoSize = true;
            this.resultsLBL.Location = new System.Drawing.Point(24, 283);
            this.resultsLBL.Name = "resultsLBL";
            this.resultsLBL.Size = new System.Drawing.Size(66, 13);
            this.resultsLBL.TabIndex = 2;
            this.resultsLBL.Text = "Test Results";
            // 
            // serverAddressTB
            // 
            this.serverAddressTB.BackColor = System.Drawing.SystemColors.Window;
            this.serverAddressTB.Location = new System.Drawing.Point(92, 15);
            this.serverAddressTB.Name = "serverAddressTB";
            this.serverAddressTB.Size = new System.Drawing.Size(345, 20);
            this.serverAddressTB.TabIndex = 1;
            // 
            // serverAddressLBL
            // 
            this.serverAddressLBL.AutoSize = true;
            this.serverAddressLBL.Location = new System.Drawing.Point(12, 18);
            this.serverAddressLBL.Name = "serverAddressLBL";
            this.serverAddressLBL.Size = new System.Drawing.Size(45, 13);
            this.serverAddressLBL.TabIndex = 4;
            this.serverAddressLBL.Text = "Address";
            // 
            // mailToLBL
            // 
            this.mailToLBL.AutoSize = true;
            this.mailToLBL.Location = new System.Drawing.Point(14, 43);
            this.mailToLBL.Name = "mailToLBL";
            this.mailToLBL.Size = new System.Drawing.Size(20, 13);
            this.mailToLBL.TabIndex = 6;
            this.mailToLBL.Text = "To";
            // 
            // mailToTB
            // 
            this.mailToTB.Location = new System.Drawing.Point(70, 40);
            this.mailToTB.Name = "mailToTB";
            this.mailToTB.Size = new System.Drawing.Size(273, 20);
            this.mailToTB.TabIndex = 1;
            // 
            // mailFromLBL
            // 
            this.mailFromLBL.AutoSize = true;
            this.mailFromLBL.Location = new System.Drawing.Point(14, 18);
            this.mailFromLBL.Name = "mailFromLBL";
            this.mailFromLBL.Size = new System.Drawing.Size(30, 13);
            this.mailFromLBL.TabIndex = 8;
            this.mailFromLBL.Text = "From";
            // 
            // mailFromTB
            // 
            this.mailFromTB.Location = new System.Drawing.Point(70, 15);
            this.mailFromTB.Name = "mailFromTB";
            this.mailFromTB.Size = new System.Drawing.Size(273, 20);
            this.mailFromTB.TabIndex = 2;
            // 
            // usernameLBL
            // 
            this.usernameLBL.AutoSize = true;
            this.usernameLBL.Location = new System.Drawing.Point(11, 66);
            this.usernameLBL.Name = "usernameLBL";
            this.usernameLBL.Size = new System.Drawing.Size(55, 13);
            this.usernameLBL.TabIndex = 10;
            this.usernameLBL.Text = "Username";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(92, 66);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(345, 20);
            this.usernameTB.TabIndex = 4;
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(11, 93);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(53, 13);
            this.passwordLBL.TabIndex = 12;
            this.passwordLBL.Text = "Password";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(91, 90);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(345, 20);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.UseSystemPasswordChar = true;
            // 
            // subjectLBL
            // 
            this.subjectLBL.AutoSize = true;
            this.subjectLBL.Location = new System.Drawing.Point(14, 67);
            this.subjectLBL.Name = "subjectLBL";
            this.subjectLBL.Size = new System.Drawing.Size(43, 13);
            this.subjectLBL.TabIndex = 14;
            this.subjectLBL.Text = "Subject";
            // 
            // subjectTB
            // 
            this.subjectTB.Location = new System.Drawing.Point(70, 64);
            this.subjectTB.Name = "subjectTB";
            this.subjectTB.Size = new System.Drawing.Size(273, 20);
            this.subjectTB.TabIndex = 3;
            this.subjectTB.Text = "Test";
            // 
            // bodyLBL
            // 
            this.bodyLBL.AutoSize = true;
            this.bodyLBL.Location = new System.Drawing.Point(14, 92);
            this.bodyLBL.Name = "bodyLBL";
            this.bodyLBL.Size = new System.Drawing.Size(31, 13);
            this.bodyLBL.TabIndex = 16;
            this.bodyLBL.Text = "Body";
            // 
            // bodyTB
            // 
            this.bodyTB.Location = new System.Drawing.Point(70, 89);
            this.bodyTB.Multiline = true;
            this.bodyTB.Name = "bodyTB";
            this.bodyTB.Size = new System.Drawing.Size(273, 145);
            this.bodyTB.TabIndex = 4;
            this.bodyTB.Text = "Test e-mail sent from SMTPTest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Port";
            // 
            // serverPortTB
            // 
            this.serverPortTB.Location = new System.Drawing.Point(92, 40);
            this.serverPortTB.Name = "serverPortTB";
            this.serverPortTB.Size = new System.Drawing.Size(71, 20);
            this.serverPortTB.TabIndex = 2;
            this.serverPortTB.Text = "25";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useTLSCB);
            this.groupBox1.Controls.Add(this.useAuthCB);
            this.groupBox1.Controls.Add(this.serverAddressTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverAddressLBL);
            this.groupBox1.Controls.Add(this.serverPortTB);
            this.groupBox1.Controls.Add(this.usernameTB);
            this.groupBox1.Controls.Add(this.usernameLBL);
            this.groupBox1.Controls.Add(this.passwordTB);
            this.groupBox1.Controls.Add(this.passwordLBL);
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMTP Server";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // useTLSCB
            // 
            this.useTLSCB.AutoSize = true;
            this.useTLSCB.Location = new System.Drawing.Point(169, 42);
            this.useTLSCB.Name = "useTLSCB";
            this.useTLSCB.Size = new System.Drawing.Size(68, 17);
            this.useTLSCB.TabIndex = 6;
            this.useTLSCB.Text = "Use TLS";
            this.useTLSCB.UseVisualStyleBackColor = true;
            // 
            // useAuthCB
            // 
            this.useAuthCB.AutoSize = true;
            this.useAuthCB.Location = new System.Drawing.Point(286, 43);
            this.useAuthCB.Name = "useAuthCB";
            this.useAuthCB.Size = new System.Drawing.Size(116, 17);
            this.useAuthCB.TabIndex = 3;
            this.useAuthCB.Text = "Use Authentication";
            this.useAuthCB.UseVisualStyleBackColor = true;
            this.useAuthCB.CheckedChanged += new System.EventHandler(this.useAuthCB_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.subjectTB);
            this.groupBox2.Controls.Add(this.mailToTB);
            this.groupBox2.Controls.Add(this.bodyLBL);
            this.groupBox2.Controls.Add(this.mailToLBL);
            this.groupBox2.Controls.Add(this.bodyTB);
            this.groupBox2.Controls.Add(this.sendEmailTestBTN);
            this.groupBox2.Controls.Add(this.mailFromTB);
            this.groupBox2.Controls.Add(this.mailFromLBL);
            this.groupBox2.Controls.Add(this.subjectLBL);
            this.groupBox2.Location = new System.Drawing.Point(462, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 268);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test E-mail";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.domainHasValidDmarcCB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dkimRecordTB);
            this.groupBox3.Controls.Add(this.domainHasValidDkimCB);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dmarcRecordTB);
            this.groupBox3.Controls.Add(this.domainHasValidSpfCB);
            this.groupBox3.Controls.Add(this.domainLookupBTN);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.spfRecordTB);
            this.groupBox3.Controls.Add(this.domainAddressTB);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.mxRecordTB);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 142);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Domain Lookup";
            // 
            // domainHasValidDmarcCB
            // 
            this.domainHasValidDmarcCB.AutoSize = true;
            this.domainHasValidDmarcCB.Location = new System.Drawing.Point(359, 119);
            this.domainHasValidDmarcCB.Name = "domainHasValidDmarcCB";
            this.domainHasValidDmarcCB.Size = new System.Drawing.Size(55, 17);
            this.domainHasValidDmarcCB.TabIndex = 24;
            this.domainHasValidDmarcCB.Text = "Valid?";
            this.domainHasValidDmarcCB.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "DMARC";
            // 
            // dkimRecordTB
            // 
            this.dkimRecordTB.Location = new System.Drawing.Point(92, 116);
            this.dkimRecordTB.Name = "dkimRecordTB";
            this.dkimRecordTB.Size = new System.Drawing.Size(261, 20);
            this.dkimRecordTB.TabIndex = 25;
            // 
            // domainHasValidDkimCB
            // 
            this.domainHasValidDkimCB.AutoSize = true;
            this.domainHasValidDkimCB.Location = new System.Drawing.Point(359, 95);
            this.domainHasValidDkimCB.Name = "domainHasValidDkimCB";
            this.domainHasValidDkimCB.Size = new System.Drawing.Size(55, 17);
            this.domainHasValidDkimCB.TabIndex = 21;
            this.domainHasValidDkimCB.Text = "Valid?";
            this.domainHasValidDkimCB.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "DKIM";
            // 
            // dmarcRecordTB
            // 
            this.dmarcRecordTB.Location = new System.Drawing.Point(91, 92);
            this.dmarcRecordTB.Name = "dmarcRecordTB";
            this.dmarcRecordTB.Size = new System.Drawing.Size(261, 20);
            this.dmarcRecordTB.TabIndex = 22;
            // 
            // domainHasValidSpfCB
            // 
            this.domainHasValidSpfCB.AutoSize = true;
            this.domainHasValidSpfCB.Location = new System.Drawing.Point(359, 69);
            this.domainHasValidSpfCB.Name = "domainHasValidSpfCB";
            this.domainHasValidSpfCB.Size = new System.Drawing.Size(55, 17);
            this.domainHasValidSpfCB.TabIndex = 19;
            this.domainHasValidSpfCB.Text = "Valid?";
            this.domainHasValidSpfCB.UseVisualStyleBackColor = true;
            // 
            // domainLookupBTN
            // 
            this.domainLookupBTN.Location = new System.Drawing.Point(332, 13);
            this.domainLookupBTN.Name = "domainLookupBTN";
            this.domainLookupBTN.Size = new System.Drawing.Size(106, 23);
            this.domainLookupBTN.TabIndex = 17;
            this.domainLookupBTN.Text = "Lookup Domain";
            this.domainLookupBTN.UseVisualStyleBackColor = true;
            this.domainLookupBTN.Click += new System.EventHandler(this.domainLookupBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "SPF";
            // 
            // spfRecordTB
            // 
            this.spfRecordTB.Location = new System.Drawing.Point(92, 66);
            this.spfRecordTB.Name = "spfRecordTB";
            this.spfRecordTB.Size = new System.Drawing.Size(261, 20);
            this.spfRecordTB.TabIndex = 19;
            // 
            // domainAddressTB
            // 
            this.domainAddressTB.BackColor = System.Drawing.SystemColors.Window;
            this.domainAddressTB.Location = new System.Drawing.Point(92, 15);
            this.domainAddressTB.Name = "domainAddressTB";
            this.domainAddressTB.Size = new System.Drawing.Size(234, 20);
            this.domainAddressTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "MX Record";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Domain";
            // 
            // mxRecordTB
            // 
            this.mxRecordTB.Location = new System.Drawing.Point(92, 40);
            this.mxRecordTB.Name = "mxRecordTB";
            this.mxRecordTB.Size = new System.Drawing.Size(346, 20);
            this.mxRecordTB.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 651);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultsLBL);
            this.Controls.Add(this.resultsTB);
            this.Name = "Form1";
            this.Text = "Simple SMTP Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendEmailTestBTN;
        private System.Windows.Forms.RichTextBox resultsTB;
        private System.Windows.Forms.Label resultsLBL;
        private System.Windows.Forms.TextBox serverAddressTB;
        private System.Windows.Forms.Label serverAddressLBL;
        private System.Windows.Forms.Label mailToLBL;
        private System.Windows.Forms.TextBox mailToTB;
        private System.Windows.Forms.Label mailFromLBL;
        private System.Windows.Forms.TextBox mailFromTB;
        private System.Windows.Forms.Label usernameLBL;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label passwordLBL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label subjectLBL;
        private System.Windows.Forms.TextBox subjectTB;
        private System.Windows.Forms.Label bodyLBL;
        private System.Windows.Forms.TextBox bodyTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverPortTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox useAuthCB;
        private System.Windows.Forms.CheckBox useTLSCB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox domainAddressTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mxRecordTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox spfRecordTB;
        private System.Windows.Forms.Button domainLookupBTN;
        private System.Windows.Forms.CheckBox domainHasValidSpfCB;
        private System.Windows.Forms.CheckBox domainHasValidDmarcCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dkimRecordTB;
        private System.Windows.Forms.CheckBox domainHasValidDkimCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dmarcRecordTB;
    }
}

