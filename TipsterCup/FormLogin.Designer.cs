namespace TipsterCup
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLoginAs = new System.Windows.Forms.Label();
            this.cbLoginAs = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerOneTickOneDay = new System.Windows.Forms.Timer(this.components);
            this.timerCheckIntervalChanged = new System.Windows.Forms.Timer(this.components);
            this.llblRegister = new System.Windows.Forms.LinkLabel();
            this.timerThisDay = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(54, 56);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(54, 101);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(144, 98);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(132, 20);
            this.tbPassword.TabIndex = 2;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(144, 49);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(132, 20);
            this.tbUsername.TabIndex = 1;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(54, 189);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "Language:";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "ENG",
            "МКД"});
            this.cbLanguage.Location = new System.Drawing.Point(57, 226);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbLanguage.TabIndex = 3;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // lblLoginAs
            // 
            this.lblLoginAs.AutoSize = true;
            this.lblLoginAs.Location = new System.Drawing.Point(253, 189);
            this.lblLoginAs.Name = "lblLoginAs";
            this.lblLoginAs.Size = new System.Drawing.Size(50, 13);
            this.lblLoginAs.TabIndex = 6;
            this.lblLoginAs.Text = "Login as:";
            // 
            // cbLoginAs
            // 
            this.cbLoginAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoginAs.FormattingEnabled = true;
            this.cbLoginAs.Items.AddRange(new object[] {
            "Tipster",
            "Administrator"});
            this.cbLoginAs.Location = new System.Drawing.Point(256, 226);
            this.cbLoginAs.Name = "cbLoginAs";
            this.cbLoginAs.Size = new System.Drawing.Size(121, 21);
            this.cbLoginAs.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(57, 301);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 68);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGo
            // 
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(306, 301);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(71, 68);
            this.btnGo.TabIndex = 5;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerOneTickOneDay
            // 
            this.timerOneTickOneDay.Interval = 1000;
            this.timerOneTickOneDay.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerCheckIntervalChanged
            // 
            this.timerCheckIntervalChanged.Interval = 1000;
            this.timerCheckIntervalChanged.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // llblRegister
            // 
            this.llblRegister.AutoSize = true;
            this.llblRegister.Location = new System.Drawing.Point(322, 145);
            this.llblRegister.Name = "llblRegister";
            this.llblRegister.Size = new System.Drawing.Size(52, 13);
            this.llblRegister.TabIndex = 7;
            this.llblRegister.TabStop = true;
            this.llblRegister.Text = "Register?";
            this.llblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRegister_LinkClicked);
            // 
            // timerThisDay
            // 
            this.timerThisDay.Tick += new System.EventHandler(this.timerThisDay_Tick);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 381);
            this.Controls.Add(this.llblRegister);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbLoginAs);
            this.Controls.Add(this.lblLoginAs);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label lblLoginAs;
        private System.Windows.Forms.ComboBox cbLoginAs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerOneTickOneDay;
        private System.Windows.Forms.Timer timerCheckIntervalChanged;
        private System.Windows.Forms.LinkLabel llblRegister;
        private System.Windows.Forms.Timer timerThisDay;
    }
}