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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // runTestBTN
            // 
            this.runTestBTN.Location = new System.Drawing.Point(214, 329);
            this.runTestBTN.Name = "runTestBTN";
            this.runTestBTN.Size = new System.Drawing.Size(124, 23);
            this.runTestBTN.TabIndex = 8;
            this.runTestBTN.Text = "Send Mail";
            this.runTestBTN.UseVisualStyleBackColor = true;
            this.runTestBTN.Click += new System.EventHandler(this.runTestBTN_Click);
            // 
            // resultsTB
            // 
            this.resultsTB.AcceptsReturn = true;
            this.resultsTB.Location = new System.Drawing.Point(35, 358);
            this.resultsTB.Multiline = true;
            this.resultsTB.Name = "resultsTB";
            this.resultsTB.Size = new System.Drawing.Size(457, 207);
            this.resultsTB.TabIndex = 9;
            // 
            // resultsLBL
            // 
            this.resultsLBL.AutoSize = true;
            this.resultsLBL.Location = new System.Drawing.Point(43, 342);
            this.resultsLBL.Name = "resultsLBL";
            this.resultsLBL.Size = new System.Drawing.Size(42, 13);
            this.resultsLBL.TabIndex = 2;
            this.resultsLBL.Text = "Results";
            // 
            // serverAddressTB
            // 
            this.serverAddressTB.BackColor = System.Drawing.SystemColors.Window;
            this.serverAddressTB.Location = new System.Drawing.Point(92, 15);
            this.serverAddressTB.Name = "serverAddressTB";
            this.serverAddressTB.Size = new System.Drawing.Size(358, 20);
            this.serverAddressTB.TabIndex = 1;
            this.serverAddressTB.Leave += new System.EventHandler(this.serverAddressTB_Leave);
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
            this.mailToLBL.Location = new System.Drawing.Point(14, 16);
            this.mailToLBL.Name = "mailToLBL";
            this.mailToLBL.Size = new System.Drawing.Size(48, 13);
            this.mailToLBL.TabIndex = 6;
            this.mailToLBL.Text = "Send To";
            // 
            // mailToTB
            // 
            this.mailToTB.Location = new System.Drawing.Point(94, 13);
            this.mailToTB.Name = "mailToTB";
            this.mailToTB.Size = new System.Drawing.Size(358, 20);
            this.mailToTB.TabIndex = 2;
            this.mailToTB.Leave += new System.EventHandler(this.mailToTB_Leave);
            // 
            // mailFromLBL
            // 
            this.mailFromLBL.AutoSize = true;
            this.mailFromLBL.Location = new System.Drawing.Point(14, 39);
            this.mailFromLBL.Name = "mailFromLBL";
            this.mailFromLBL.Size = new System.Drawing.Size(58, 13);
            this.mailFromLBL.TabIndex = 8;
            this.mailFromLBL.Text = "Send From";
            // 
            // mailFromTB
            // 
            this.mailFromTB.Location = new System.Drawing.Point(94, 36);
            this.mailFromTB.Name = "mailFromTB";
            this.mailFromTB.Size = new System.Drawing.Size(358, 20);
            this.mailFromTB.TabIndex = 3;
            this.mailFromTB.Leave += new System.EventHandler(this.mailFromTB_Leave);
            // 
            // usernameLBL
            // 
            this.usernameLBL.AutoSize = true;
            this.usernameLBL.Location = new System.Drawing.Point(12, 68);
            this.usernameLBL.Name = "usernameLBL";
            this.usernameLBL.Size = new System.Drawing.Size(55, 13);
            this.usernameLBL.TabIndex = 10;
            this.usernameLBL.Text = "Username";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(92, 66);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(358, 20);
            this.usernameTB.TabIndex = 4;
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(12, 95);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(53, 13);
            this.passwordLBL.TabIndex = 12;
            this.passwordLBL.Text = "Password";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(92, 92);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(358, 20);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.UseSystemPasswordChar = true;
            // 
            // subjectLBL
            // 
            this.subjectLBL.AutoSize = true;
            this.subjectLBL.Location = new System.Drawing.Point(14, 63);
            this.subjectLBL.Name = "subjectLBL";
            this.subjectLBL.Size = new System.Drawing.Size(43, 13);
            this.subjectLBL.TabIndex = 14;
            this.subjectLBL.Text = "Subject";
            // 
            // subjectTB
            // 
            this.subjectTB.Location = new System.Drawing.Point(94, 60);
            this.subjectTB.Name = "subjectTB";
            this.subjectTB.Size = new System.Drawing.Size(358, 20);
            this.subjectTB.TabIndex = 6;
            // 
            // bodyLBL
            // 
            this.bodyLBL.AutoSize = true;
            this.bodyLBL.Location = new System.Drawing.Point(14, 89);
            this.bodyLBL.Name = "bodyLBL";
            this.bodyLBL.Size = new System.Drawing.Size(31, 13);
            this.bodyLBL.TabIndex = 16;
            this.bodyLBL.Text = "Body";
            // 
            // bodyTB
            // 
            this.bodyTB.Location = new System.Drawing.Point(94, 86);
            this.bodyTB.Multiline = true;
            this.bodyTB.Name = "bodyTB";
            this.bodyTB.Size = new System.Drawing.Size(358, 88);
            this.bodyTB.TabIndex = 7;
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
            this.serverPortTB.Size = new System.Drawing.Size(358, 20);
            this.serverPortTB.TabIndex = 17;
            this.serverPortTB.Text = "25";
            this.serverPortTB.Leave += new System.EventHandler(this.serverPortTB_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverAddressTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverAddressLBL);
            this.groupBox1.Controls.Add(this.serverPortTB);
            this.groupBox1.Controls.Add(this.usernameTB);
            this.groupBox1.Controls.Add(this.usernameLBL);
            this.groupBox1.Controls.Add(this.passwordTB);
            this.groupBox1.Controls.Add(this.passwordLBL);
            this.groupBox1.Location = new System.Drawing.Point(35, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 118);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.subjectTB);
            this.groupBox2.Controls.Add(this.mailToTB);
            this.groupBox2.Controls.Add(this.bodyLBL);
            this.groupBox2.Controls.Add(this.mailToLBL);
            this.groupBox2.Controls.Add(this.bodyTB);
            this.groupBox2.Controls.Add(this.mailFromTB);
            this.groupBox2.Controls.Add(this.subjectLBL);
            this.groupBox2.Controls.Add(this.mailFromLBL);
            this.groupBox2.Location = new System.Drawing.Point(33, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 186);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test E-mail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 581);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultsLBL);
            this.Controls.Add(this.resultsTB);
            this.Controls.Add(this.runTestBTN);
            this.Name = "Form1";
            this.Text = "Simple SMTP Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

