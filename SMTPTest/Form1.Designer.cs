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
            this.runTestBTN = new System.Windows.Forms.Button();
            this.resultsTB = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // runTestBTN
            // 
            this.runTestBTN.Location = new System.Drawing.Point(203, 287);
            this.runTestBTN.Name = "runTestBTN";
            this.runTestBTN.Size = new System.Drawing.Size(124, 23);
            this.runTestBTN.TabIndex = 8;
            this.runTestBTN.Text = "Run Test";
            this.runTestBTN.UseVisualStyleBackColor = true;
            this.runTestBTN.Click += new System.EventHandler(this.runTestBTN_Click);
            // 
            // resultsTB
            // 
            this.resultsTB.AcceptsReturn = true;
            this.resultsTB.Location = new System.Drawing.Point(35, 324);
            this.resultsTB.Multiline = true;
            this.resultsTB.Name = "resultsTB";
            this.resultsTB.Size = new System.Drawing.Size(435, 97);
            this.resultsTB.TabIndex = 9;
            // 
            // resultsLBL
            // 
            this.resultsLBL.AutoSize = true;
            this.resultsLBL.Location = new System.Drawing.Point(32, 308);
            this.resultsLBL.Name = "resultsLBL";
            this.resultsLBL.Size = new System.Drawing.Size(42, 13);
            this.resultsLBL.TabIndex = 2;
            this.resultsLBL.Text = "Results";
            // 
            // serverAddressTB
            // 
            this.serverAddressTB.BackColor = System.Drawing.SystemColors.Window;
            this.serverAddressTB.Location = new System.Drawing.Point(112, 12);
            this.serverAddressTB.Name = "serverAddressTB";
            this.serverAddressTB.Size = new System.Drawing.Size(358, 20);
            this.serverAddressTB.TabIndex = 1;
            this.serverAddressTB.Leave += new System.EventHandler(this.serverAddressTB_Leave);
            // 
            // serverAddressLBL
            // 
            this.serverAddressLBL.AutoSize = true;
            this.serverAddressLBL.Location = new System.Drawing.Point(32, 15);
            this.serverAddressLBL.Name = "serverAddressLBL";
            this.serverAddressLBL.Size = new System.Drawing.Size(79, 13);
            this.serverAddressLBL.TabIndex = 4;
            this.serverAddressLBL.Text = "Server Address";
            // 
            // mailToLBL
            // 
            this.mailToLBL.AutoSize = true;
            this.mailToLBL.Location = new System.Drawing.Point(32, 66);
            this.mailToLBL.Name = "mailToLBL";
            this.mailToLBL.Size = new System.Drawing.Size(42, 13);
            this.mailToLBL.TabIndex = 6;
            this.mailToLBL.Text = "Mail To";
            // 
            // mailToTB
            // 
            this.mailToTB.Location = new System.Drawing.Point(112, 63);
            this.mailToTB.Name = "mailToTB";
            this.mailToTB.Size = new System.Drawing.Size(358, 20);
            this.mailToTB.TabIndex = 2;
            this.mailToTB.Leave += new System.EventHandler(this.mailToTB_Leave);
            // 
            // mailFromLBL
            // 
            this.mailFromLBL.AutoSize = true;
            this.mailFromLBL.Location = new System.Drawing.Point(32, 92);
            this.mailFromLBL.Name = "mailFromLBL";
            this.mailFromLBL.Size = new System.Drawing.Size(52, 13);
            this.mailFromLBL.TabIndex = 8;
            this.mailFromLBL.Text = "Mail From";
            // 
            // mailFromTB
            // 
            this.mailFromTB.Location = new System.Drawing.Point(112, 89);
            this.mailFromTB.Name = "mailFromTB";
            this.mailFromTB.Size = new System.Drawing.Size(358, 20);
            this.mailFromTB.TabIndex = 3;
            this.mailFromTB.Leave += new System.EventHandler(this.mailFromTB_Leave);
            // 
            // usernameLBL
            // 
            this.usernameLBL.AutoSize = true;
            this.usernameLBL.Location = new System.Drawing.Point(32, 118);
            this.usernameLBL.Name = "usernameLBL";
            this.usernameLBL.Size = new System.Drawing.Size(55, 13);
            this.usernameLBL.TabIndex = 10;
            this.usernameLBL.Text = "Username";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(112, 115);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(358, 20);
            this.usernameTB.TabIndex = 4;
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(32, 144);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(53, 13);
            this.passwordLBL.TabIndex = 12;
            this.passwordLBL.Text = "Password";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(112, 141);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(358, 20);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.UseSystemPasswordChar = true;
            // 
            // subjectLBL
            // 
            this.subjectLBL.AutoSize = true;
            this.subjectLBL.Location = new System.Drawing.Point(32, 170);
            this.subjectLBL.Name = "subjectLBL";
            this.subjectLBL.Size = new System.Drawing.Size(43, 13);
            this.subjectLBL.TabIndex = 14;
            this.subjectLBL.Text = "Subject";
            // 
            // subjectTB
            // 
            this.subjectTB.Location = new System.Drawing.Point(112, 167);
            this.subjectTB.Name = "subjectTB";
            this.subjectTB.Size = new System.Drawing.Size(358, 20);
            this.subjectTB.TabIndex = 6;
            // 
            // bodyLBL
            // 
            this.bodyLBL.AutoSize = true;
            this.bodyLBL.Location = new System.Drawing.Point(32, 196);
            this.bodyLBL.Name = "bodyLBL";
            this.bodyLBL.Size = new System.Drawing.Size(31, 13);
            this.bodyLBL.TabIndex = 16;
            this.bodyLBL.Text = "Body";
            // 
            // bodyTB
            // 
            this.bodyTB.Location = new System.Drawing.Point(112, 193);
            this.bodyTB.Multiline = true;
            this.bodyTB.Name = "bodyTB";
            this.bodyTB.Size = new System.Drawing.Size(358, 88);
            this.bodyTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Server Port";
            // 
            // serverPortTB
            // 
            this.serverPortTB.Location = new System.Drawing.Point(112, 37);
            this.serverPortTB.Name = "serverPortTB";
            this.serverPortTB.Size = new System.Drawing.Size(358, 20);
            this.serverPortTB.TabIndex = 17;
            this.serverPortTB.Text = "25";
            this.serverPortTB.Leave += new System.EventHandler(this.serverPortTB_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 434);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverPortTB);
            this.Controls.Add(this.bodyLBL);
            this.Controls.Add(this.bodyTB);
            this.Controls.Add(this.subjectLBL);
            this.Controls.Add(this.subjectTB);
            this.Controls.Add(this.passwordLBL);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameLBL);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.mailFromLBL);
            this.Controls.Add(this.mailFromTB);
            this.Controls.Add(this.mailToLBL);
            this.Controls.Add(this.mailToTB);
            this.Controls.Add(this.serverAddressLBL);
            this.Controls.Add(this.serverAddressTB);
            this.Controls.Add(this.resultsLBL);
            this.Controls.Add(this.resultsTB);
            this.Controls.Add(this.runTestBTN);
            this.Name = "Form1";
            this.Text = "Simple SMTP Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runTestBTN;
        private System.Windows.Forms.TextBox resultsTB;
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
    }
}

