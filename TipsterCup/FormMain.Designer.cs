namespace TipsterCup
{
    partial class FormMain
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
            this.gridStandings = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRounds = new System.Windows.Forms.Button();
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnTipsters = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridStandings)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStandings
            // 
            this.gridStandings.AllowUserToAddRows = false;
            this.gridStandings.AllowUserToDeleteRows = false;
            this.gridStandings.BackgroundColor = System.Drawing.Color.White;
            this.gridStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStandings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.W,
            this.D,
            this.L,
            this.Points});
            this.gridStandings.GridColor = System.Drawing.Color.White;
            this.gridStandings.Location = new System.Drawing.Point(63, 133);
            this.gridStandings.Name = "gridStandings";
            this.gridStandings.ReadOnly = true;
            this.gridStandings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridStandings.Size = new System.Drawing.Size(676, 245);
            this.gridStandings.TabIndex = 0;
            this.gridStandings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStandings_CellDoubleClick);
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.HeaderText = "Name";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // W
            // 
            this.W.HeaderText = "W";
            this.W.Name = "W";
            this.W.ReadOnly = true;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.ReadOnly = true;
            // 
            // L
            // 
            this.L.HeaderText = "L";
            this.L.Name = "L";
            this.L.ReadOnly = true;
            // 
            // Points
            // 
            this.Points.HeaderText = "Points";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            // 
            // btnRounds
            // 
            this.btnRounds.Location = new System.Drawing.Point(80, 30);
            this.btnRounds.Name = "btnRounds";
            this.btnRounds.Size = new System.Drawing.Size(75, 23);
            this.btnRounds.TabIndex = 1;
            this.btnRounds.Text = "Rounds";
            this.btnRounds.UseVisualStyleBackColor = true;
            this.btnRounds.Click += new System.EventHandler(this.btnRounds_Click);
            // 
            // btnTeams
            // 
            this.btnTeams.Location = new System.Drawing.Point(153, 30);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(83, 23);
            this.btnTeams.TabIndex = 2;
            this.btnTeams.Text = "Teams";
            this.btnTeams.UseVisualStyleBackColor = true;
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(232, 30);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(83, 23);
            this.btnPlayers.TabIndex = 3;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            // 
            // btnTipsters
            // 
            this.btnTipsters.Location = new System.Drawing.Point(312, 30);
            this.btnTipsters.Name = "btnTipsters";
            this.btnTipsters.Size = new System.Drawing.Size(75, 23);
            this.btnTipsters.TabIndex = 4;
            this.btnTipsters.Text = "Tipsters";
            this.btnTipsters.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(384, 30);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(101, 23);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 422);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnTipsters);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnRounds);
            this.Controls.Add(this.gridStandings);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridStandings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridStandings;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.Button btnRounds;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnTipsters;
        private System.Windows.Forms.Button btnStatistics;
    }
}