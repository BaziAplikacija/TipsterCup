namespace TipsterCup
{
    partial class FormAllPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAllPlayers));
            this.gridPlayers = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.cbFirstName = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.timerName = new System.Windows.Forms.Timer(this.components);
            this.cbGoals = new System.Windows.Forms.CheckBox();
            this.tbAgeFrom = new System.Windows.Forms.TextBox();
            this.cbAge = new System.Windows.Forms.CheckBox();
            this.cbTeam = new System.Windows.Forms.CheckBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.cbLastName = new System.Windows.Forms.CheckBox();
            this.cbPosition = new System.Windows.Forms.CheckBox();
            this.tbAgeTo = new System.Windows.Forms.TextBox();
            this.lblFromAge = new System.Windows.Forms.Label();
            this.lblToAge = new System.Windows.Forms.Label();
            this.lblToGoals = new System.Windows.Forms.Label();
            this.lblFromGoals = new System.Windows.Forms.Label();
            this.tbGoalsTo = new System.Windows.Forms.TextBox();
            this.tbGoalsFrom = new System.Windows.Forms.TextBox();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            this.cbxPosition = new System.Windows.Forms.ComboBox();
            this.lblToRating = new System.Windows.Forms.Label();
            this.lblFromRating = new System.Windows.Forms.Label();
            this.tbRatingTo = new System.Windows.Forms.TextBox();
            this.tbRatingFrom = new System.Windows.Forms.TextBox();
            this.cbRating = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPlayers
            // 
            this.gridPlayers.AllowUserToAddRows = false;
            this.gridPlayers.AllowUserToDeleteRows = false;
            this.gridPlayers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFirstname,
            this.colLastName,
            this.colRating,
            this.colTeam,
            this.colPosition,
            this.colGoals,
            this.colDate});
            this.gridPlayers.Location = new System.Drawing.Point(12, 289);
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.ReadOnly = true;
            this.gridPlayers.RowHeadersVisible = false;
            this.gridPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPlayers.Size = new System.Drawing.Size(1231, 266);
            this.gridPlayers.TabIndex = 0;
            this.gridPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlayers_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "IdPlayer";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFirstname
            // 
            this.colFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFirstname.HeaderText = "First name";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastName.HeaderText = "Last name";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colRating
            // 
            this.colRating.HeaderText = "Rating";
            this.colRating.Name = "colRating";
            this.colRating.ReadOnly = true;
            this.colRating.Width = 120;
            // 
            // colTeam
            // 
            this.colTeam.HeaderText = "Team";
            this.colTeam.Name = "colTeam";
            this.colTeam.ReadOnly = true;
            this.colTeam.Width = 150;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 150;
            // 
            // colGoals
            // 
            this.colGoals.HeaderText = "Goals";
            this.colGoals.Name = "colGoals";
            this.colGoals.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Years";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBy.Location = new System.Drawing.Point(12, 28);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(115, 27);
            this.lblSearchBy.TabIndex = 1;
            this.lblSearchBy.Text = "Search by ";
            // 
            // cbFirstName
            // 
            this.cbFirstName.AutoSize = true;
            this.cbFirstName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFirstName.Location = new System.Drawing.Point(17, 86);
            this.cbFirstName.Name = "cbFirstName";
            this.cbFirstName.Size = new System.Drawing.Size(94, 22);
            this.cbFirstName.TabIndex = 2;
            this.cbFirstName.Text = "First name:";
            this.cbFirstName.UseVisualStyleBackColor = true;
            this.cbFirstName.CheckedChanged += new System.EventHandler(this.cbFirstName_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(1183, 211);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 60);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Enabled = false;
            this.tbFirstName.Location = new System.Drawing.Point(144, 86);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(159, 20);
            this.tbFirstName.TabIndex = 11;
            // 
            // cbGoals
            // 
            this.cbGoals.AutoSize = true;
            this.cbGoals.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGoals.Location = new System.Drawing.Point(354, 122);
            this.cbGoals.Name = "cbGoals";
            this.cbGoals.Size = new System.Drawing.Size(60, 22);
            this.cbGoals.TabIndex = 12;
            this.cbGoals.Text = "Goals";
            this.cbGoals.UseVisualStyleBackColor = true;
            this.cbGoals.CheckedChanged += new System.EventHandler(this.cbGoals_CheckedChanged);
            // 
            // tbAgeFrom
            // 
            this.tbAgeFrom.Enabled = false;
            this.tbAgeFrom.Location = new System.Drawing.Point(498, 88);
            this.tbAgeFrom.Name = "tbAgeFrom";
            this.tbAgeFrom.Size = new System.Drawing.Size(54, 20);
            this.tbAgeFrom.TabIndex = 15;
            this.tbAgeFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // cbAge
            // 
            this.cbAge.AutoSize = true;
            this.cbAge.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAge.Location = new System.Drawing.Point(354, 86);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(50, 22);
            this.cbAge.TabIndex = 14;
            this.cbAge.Text = "Age";
            this.cbAge.UseVisualStyleBackColor = true;
            this.cbAge.CheckedChanged += new System.EventHandler(this.cbAge_CheckedChanged);
            // 
            // cbTeam
            // 
            this.cbTeam.AutoSize = true;
            this.cbTeam.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTeam.Location = new System.Drawing.Point(697, 85);
            this.cbTeam.Name = "cbTeam";
            this.cbTeam.Size = new System.Drawing.Size(59, 22);
            this.cbTeam.TabIndex = 16;
            this.cbTeam.Text = "Team";
            this.cbTeam.UseVisualStyleBackColor = true;
            this.cbTeam.CheckedChanged += new System.EventHandler(this.cbTeam_CheckedChanged);
            // 
            // tbLastName
            // 
            this.tbLastName.Enabled = false;
            this.tbLastName.Location = new System.Drawing.Point(144, 122);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(159, 20);
            this.tbLastName.TabIndex = 19;
            // 
            // cbLastName
            // 
            this.cbLastName.AutoSize = true;
            this.cbLastName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLastName.Location = new System.Drawing.Point(17, 122);
            this.cbLastName.Name = "cbLastName";
            this.cbLastName.Size = new System.Drawing.Size(90, 22);
            this.cbLastName.TabIndex = 18;
            this.cbLastName.Text = "Last name:";
            this.cbLastName.UseVisualStyleBackColor = true;
            this.cbLastName.CheckedChanged += new System.EventHandler(this.cbLastName_CheckedChanged);
            // 
            // cbPosition
            // 
            this.cbPosition.AutoSize = true;
            this.cbPosition.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPosition.Location = new System.Drawing.Point(976, 86);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(74, 22);
            this.cbPosition.TabIndex = 20;
            this.cbPosition.Text = "Position";
            this.cbPosition.UseVisualStyleBackColor = true;
            this.cbPosition.CheckedChanged += new System.EventHandler(this.cbPosition_CheckedChanged);
            // 
            // tbAgeTo
            // 
            this.tbAgeTo.Enabled = false;
            this.tbAgeTo.Location = new System.Drawing.Point(596, 88);
            this.tbAgeTo.Name = "tbAgeTo";
            this.tbAgeTo.Size = new System.Drawing.Size(55, 20);
            this.tbAgeTo.TabIndex = 22;
            this.tbAgeTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // lblFromAge
            // 
            this.lblFromAge.AutoSize = true;
            this.lblFromAge.Location = new System.Drawing.Point(457, 92);
            this.lblFromAge.Name = "lblFromAge";
            this.lblFromAge.Size = new System.Drawing.Size(33, 13);
            this.lblFromAge.TabIndex = 23;
            this.lblFromAge.Text = "From:";
            // 
            // lblToAge
            // 
            this.lblToAge.AutoSize = true;
            this.lblToAge.Location = new System.Drawing.Point(567, 92);
            this.lblToAge.Name = "lblToAge";
            this.lblToAge.Size = new System.Drawing.Size(23, 13);
            this.lblToAge.TabIndex = 24;
            this.lblToAge.Text = "To:";
            // 
            // lblToGoals
            // 
            this.lblToGoals.AutoSize = true;
            this.lblToGoals.Location = new System.Drawing.Point(567, 128);
            this.lblToGoals.Name = "lblToGoals";
            this.lblToGoals.Size = new System.Drawing.Size(23, 13);
            this.lblToGoals.TabIndex = 28;
            this.lblToGoals.Text = "To:";
            // 
            // lblFromGoals
            // 
            this.lblFromGoals.AutoSize = true;
            this.lblFromGoals.Location = new System.Drawing.Point(457, 128);
            this.lblFromGoals.Name = "lblFromGoals";
            this.lblFromGoals.Size = new System.Drawing.Size(33, 13);
            this.lblFromGoals.TabIndex = 27;
            this.lblFromGoals.Text = "From:";
            // 
            // tbGoalsTo
            // 
            this.tbGoalsTo.Enabled = false;
            this.tbGoalsTo.Location = new System.Drawing.Point(596, 124);
            this.tbGoalsTo.Name = "tbGoalsTo";
            this.tbGoalsTo.Size = new System.Drawing.Size(55, 20);
            this.tbGoalsTo.TabIndex = 26;
            this.tbGoalsTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // tbGoalsFrom
            // 
            this.tbGoalsFrom.Enabled = false;
            this.tbGoalsFrom.Location = new System.Drawing.Point(498, 124);
            this.tbGoalsFrom.Name = "tbGoalsFrom";
            this.tbGoalsFrom.Size = new System.Drawing.Size(54, 20);
            this.tbGoalsFrom.TabIndex = 25;
            this.tbGoalsFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // cbxTeam
            // 
            this.cbxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeam.Enabled = false;
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Items.AddRange(new object[] {
            "Arsenal",
            "Aston Villa",
            "Cardiff City",
            "Chelsea",
            "Crystal Palace",
            "Everton",
            "Fulham",
            "Hull City",
            "Liverpool",
            "Manchester City",
            "Manchester United",
            "Newcastle United",
            "Norwich City",
            "Southampton",
            "Stoke City",
            "Sunderland",
            "Swansea City",
            "Tottenham Hotspur",
            "West Bromwich",
            "West Ham United"});
            this.cbxTeam.Location = new System.Drawing.Point(785, 85);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(159, 21);
            this.cbxTeam.TabIndex = 29;
            // 
            // cbxPosition
            // 
            this.cbxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPosition.Enabled = false;
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Items.AddRange(new object[] {
            "Attack",
            "Middle",
            "Defense",
            "Goalkeeper"});
            this.cbxPosition.Location = new System.Drawing.Point(1056, 85);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(159, 21);
            this.cbxPosition.TabIndex = 30;
            // 
            // lblToRating
            // 
            this.lblToRating.AutoSize = true;
            this.lblToRating.Location = new System.Drawing.Point(567, 167);
            this.lblToRating.Name = "lblToRating";
            this.lblToRating.Size = new System.Drawing.Size(23, 13);
            this.lblToRating.TabIndex = 35;
            this.lblToRating.Text = "To:";
            // 
            // lblFromRating
            // 
            this.lblFromRating.AutoSize = true;
            this.lblFromRating.Location = new System.Drawing.Point(457, 167);
            this.lblFromRating.Name = "lblFromRating";
            this.lblFromRating.Size = new System.Drawing.Size(33, 13);
            this.lblFromRating.TabIndex = 34;
            this.lblFromRating.Text = "From:";
            // 
            // tbRatingTo
            // 
            this.tbRatingTo.Enabled = false;
            this.tbRatingTo.Location = new System.Drawing.Point(596, 163);
            this.tbRatingTo.Name = "tbRatingTo";
            this.tbRatingTo.Size = new System.Drawing.Size(55, 20);
            this.tbRatingTo.TabIndex = 33;
            this.tbRatingTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // tbRatingFrom
            // 
            this.tbRatingFrom.Enabled = false;
            this.tbRatingFrom.Location = new System.Drawing.Point(498, 163);
            this.tbRatingFrom.Name = "tbRatingFrom";
            this.tbRatingFrom.Size = new System.Drawing.Size(54, 20);
            this.tbRatingFrom.TabIndex = 32;
            this.tbRatingFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeFrom_KeyPress);
            // 
            // cbRating
            // 
            this.cbRating.AutoSize = true;
            this.cbRating.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRating.Location = new System.Drawing.Point(354, 161);
            this.cbRating.Name = "cbRating";
            this.cbRating.Size = new System.Drawing.Size(65, 22);
            this.cbRating.TabIndex = 31;
            this.cbRating.Text = "Rating";
            this.cbRating.UseVisualStyleBackColor = true;
            this.cbRating.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            // 
            // FormAllPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 543);
            this.Controls.Add(this.lblToRating);
            this.Controls.Add(this.lblFromRating);
            this.Controls.Add(this.tbRatingTo);
            this.Controls.Add(this.tbRatingFrom);
            this.Controls.Add(this.cbRating);
            this.Controls.Add(this.cbxPosition);
            this.Controls.Add(this.cbxTeam);
            this.Controls.Add(this.lblToGoals);
            this.Controls.Add(this.lblFromGoals);
            this.Controls.Add(this.tbGoalsTo);
            this.Controls.Add(this.tbGoalsFrom);
            this.Controls.Add(this.lblToAge);
            this.Controls.Add(this.lblFromAge);
            this.Controls.Add(this.tbAgeTo);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.cbLastName);
            this.Controls.Add(this.cbTeam);
            this.Controls.Add(this.tbAgeFrom);
            this.Controls.Add(this.cbAge);
            this.Controls.Add(this.cbGoals);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbFirstName);
            this.Controls.Add(this.lblSearchBy);
            this.Controls.Add(this.gridPlayers);
            this.Name = "FormAllPlayers";
            this.Text = "All players";
            this.Load += new System.EventHandler(this.FormAllPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.CheckBox cbFirstName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Timer timerName;
        private System.Windows.Forms.CheckBox cbGoals;
        private System.Windows.Forms.TextBox tbAgeFrom;
        private System.Windows.Forms.CheckBox cbAge;
        private System.Windows.Forms.CheckBox cbTeam;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.CheckBox cbLastName;
        private System.Windows.Forms.CheckBox cbPosition;
        private System.Windows.Forms.TextBox tbAgeTo;
        private System.Windows.Forms.Label lblFromAge;
        private System.Windows.Forms.Label lblToAge;
        private System.Windows.Forms.Label lblToGoals;
        private System.Windows.Forms.Label lblFromGoals;
        private System.Windows.Forms.TextBox tbGoalsTo;
        private System.Windows.Forms.TextBox tbGoalsFrom;
        private System.Windows.Forms.ComboBox cbxTeam;
        private System.Windows.Forms.ComboBox cbxPosition;
        private System.Windows.Forms.Label lblToRating;
        private System.Windows.Forms.Label lblFromRating;
        private System.Windows.Forms.TextBox tbRatingTo;
        private System.Windows.Forms.TextBox tbRatingFrom;
        private System.Windows.Forms.CheckBox cbRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}