namespace TipsterCup
{
    partial class FormAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTipsters = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBan = new System.Windows.Forms.Button();
            this.lblRatingData = new System.Windows.Forms.Label();
            this.lblEmailData = new System.Windows.Forms.Label();
            this.lblSurnameData = new System.Windows.Forms.Label();
            this.lblNameData = new System.Windows.Forms.Label();
            this.lblPasswordData = new System.Windows.Forms.Label();
            this.lblUsernameData = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.listTipsters = new System.Windows.Forms.ListBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.gbNewSeason = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbTimeInterval = new System.Windows.Forms.GroupBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTipsters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.gbNewSeason.SuspendLayout();
            this.gbTimeInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTipsters);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 269);
            this.tabControl1.TabIndex = 2;
            // 
            // tabTipsters
            // 
            this.tabTipsters.Controls.Add(this.panel1);
            this.tabTipsters.Controls.Add(this.listTipsters);
            this.tabTipsters.Location = new System.Drawing.Point(4, 22);
            this.tabTipsters.Name = "tabTipsters";
            this.tabTipsters.Padding = new System.Windows.Forms.Padding(3);
            this.tabTipsters.Size = new System.Drawing.Size(492, 243);
            this.tabTipsters.TabIndex = 0;
            this.tabTipsters.Text = "Tipsters";
            this.tabTipsters.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBan);
            this.panel1.Controls.Add(this.lblRatingData);
            this.panel1.Controls.Add(this.lblEmailData);
            this.panel1.Controls.Add(this.lblSurnameData);
            this.panel1.Controls.Add(this.lblNameData);
            this.panel1.Controls.Add(this.lblPasswordData);
            this.panel1.Controls.Add(this.lblUsernameData);
            this.panel1.Controls.Add(this.lblRating);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblSurname);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Location = new System.Drawing.Point(232, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 267);
            this.panel1.TabIndex = 1;
            // 
            // btnBan
            // 
            this.btnBan.BackColor = System.Drawing.Color.Red;
            this.btnBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBan.Location = new System.Drawing.Point(131, 199);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(123, 38);
            this.btnBan.TabIndex = 12;
            this.btnBan.Text = "BAN";
            this.btnBan.UseVisualStyleBackColor = false;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // lblRatingData
            // 
            this.lblRatingData.AutoSize = true;
            this.lblRatingData.Location = new System.Drawing.Point(85, 170);
            this.lblRatingData.Name = "lblRatingData";
            this.lblRatingData.Size = new System.Drawing.Size(35, 13);
            this.lblRatingData.TabIndex = 11;
            this.lblRatingData.Text = "label6";
            // 
            // lblEmailData
            // 
            this.lblEmailData.AutoSize = true;
            this.lblEmailData.Location = new System.Drawing.Point(85, 139);
            this.lblEmailData.Name = "lblEmailData";
            this.lblEmailData.Size = new System.Drawing.Size(35, 13);
            this.lblEmailData.TabIndex = 10;
            this.lblEmailData.Text = "label5";
            // 
            // lblSurnameData
            // 
            this.lblSurnameData.AutoSize = true;
            this.lblSurnameData.Location = new System.Drawing.Point(85, 109);
            this.lblSurnameData.Name = "lblSurnameData";
            this.lblSurnameData.Size = new System.Drawing.Size(35, 13);
            this.lblSurnameData.TabIndex = 9;
            this.lblSurnameData.Text = "label4";
            // 
            // lblNameData
            // 
            this.lblNameData.AutoSize = true;
            this.lblNameData.Location = new System.Drawing.Point(85, 79);
            this.lblNameData.Name = "lblNameData";
            this.lblNameData.Size = new System.Drawing.Size(35, 13);
            this.lblNameData.TabIndex = 8;
            this.lblNameData.Text = "label3";
            // 
            // lblPasswordData
            // 
            this.lblPasswordData.AutoSize = true;
            this.lblPasswordData.Location = new System.Drawing.Point(85, 51);
            this.lblPasswordData.Name = "lblPasswordData";
            this.lblPasswordData.Size = new System.Drawing.Size(35, 13);
            this.lblPasswordData.TabIndex = 7;
            this.lblPasswordData.Text = "label2";
            // 
            // lblUsernameData
            // 
            this.lblUsernameData.AutoSize = true;
            this.lblUsernameData.Location = new System.Drawing.Point(85, 21);
            this.lblUsernameData.Name = "lblUsernameData";
            this.lblUsernameData.Size = new System.Drawing.Size(35, 13);
            this.lblUsernameData.TabIndex = 6;
            this.lblUsernameData.Text = "label1";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(17, 170);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(41, 13);
            this.lblRating.TabIndex = 5;
            this.lblRating.Text = "Rating:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(17, 109);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(52, 13);
            this.lblSurname.TabIndex = 3;
            this.lblSurname.Text = "Surname:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(17, 51);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(17, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // listTipsters
            // 
            this.listTipsters.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listTipsters.FormattingEnabled = true;
            this.listTipsters.Location = new System.Drawing.Point(6, 6);
            this.listTipsters.Name = "listTipsters";
            this.listTipsters.Size = new System.Drawing.Size(220, 264);
            this.listTipsters.TabIndex = 0;
            this.listTipsters.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listTipsters_DrawItem);
            this.listTipsters.SelectedIndexChanged += new System.EventHandler(this.listTipsters_SelectedIndexChanged);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.gbNewSeason);
            this.tabOptions.Controls.Add(this.gbTimeInterval);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(492, 243);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // gbNewSeason
            // 
            this.gbNewSeason.Controls.Add(this.label1);
            this.gbNewSeason.Controls.Add(this.btnStart);
            this.gbNewSeason.Location = new System.Drawing.Point(21, 125);
            this.gbNewSeason.Name = "gbNewSeason";
            this.gbNewSeason.Size = new System.Drawing.Size(448, 84);
            this.gbNewSeason.TabIndex = 3;
            this.gbNewSeason.TabStop = false;
            this.gbNewSeason.Text = "New Season";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(304, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start new season";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbTimeInterval
            // 
            this.gbTimeInterval.Controls.Add(this.btnChange);
            this.gbTimeInterval.Controls.Add(this.cbTime);
            this.gbTimeInterval.Controls.Add(this.lblDay);
            this.gbTimeInterval.Location = new System.Drawing.Point(21, 16);
            this.gbTimeInterval.Name = "gbTimeInterval";
            this.gbTimeInterval.Size = new System.Drawing.Size(448, 84);
            this.gbTimeInterval.TabIndex = 0;
            this.gbTimeInterval.TabStop = false;
            this.gbTimeInterval.Text = "Time Interval";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(337, 34);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            "24h",
            "12h",
            "8h",
            "2h",
            "1h",
            "30m",
            "20m",
            "10m",
            "5m",
            "2m",
            "1m"});
            this.cbTime.Location = new System.Drawing.Point(65, 36);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(121, 21);
            this.cbTime.TabIndex = 1;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(17, 39);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(42, 13);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "1 day =";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(6, 268);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(496, 26);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 305);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTipsters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.gbNewSeason.ResumeLayout(false);
            this.gbNewSeason.PerformLayout();
            this.gbTimeInterval.ResumeLayout(false);
            this.gbTimeInterval.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTipsters;
        private System.Windows.Forms.ListBox listTipsters;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblRatingData;
        private System.Windows.Forms.Label lblEmailData;
        private System.Windows.Forms.Label lblSurnameData;
        private System.Windows.Forms.Label lblNameData;
        private System.Windows.Forms.Label lblPasswordData;
        private System.Windows.Forms.Label lblUsernameData;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.GroupBox gbTimeInterval;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox cbTime;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbNewSeason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
    }
}