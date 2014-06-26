namespace TipsterCup
{
    partial class FormTeam
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pbTeam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStadium = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.gridPlayers = new System.Windows.Forms.DataGridView();
            this.IdPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartTeamRating = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTeamHistory = new System.Windows.Forms.Button();
            this.tableResults = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTeamRating)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTeam
            // 
            this.pbTeam.Location = new System.Drawing.Point(27, 12);
            this.pbTeam.Name = "pbTeam";
            this.pbTeam.Size = new System.Drawing.Size(145, 157);
            this.pbTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTeam.TabIndex = 0;
            this.pbTeam.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // lblStadium
            // 
            this.lblStadium.AutoSize = true;
            this.lblStadium.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStadium.Location = new System.Drawing.Point(104, 269);
            this.lblStadium.Name = "lblStadium";
            this.lblStadium.Size = new System.Drawing.Size(0, 19);
            this.lblStadium.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(24, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stadium";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(104, 233);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 19);
            this.lblName.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCity.Location = new System.Drawing.Point(104, 308);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(0, 19);
            this.lblCity.TabIndex = 6;
            // 
            // gridPlayers
            // 
            this.gridPlayers.AllowUserToAddRows = false;
            this.gridPlayers.AllowUserToDeleteRows = false;
            this.gridPlayers.BackgroundColor = System.Drawing.Color.White;
            this.gridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPlayer,
            this.FirstName,
            this.LastName,
            this.Position});
            this.gridPlayers.GridColor = System.Drawing.Color.White;
            this.gridPlayers.Location = new System.Drawing.Point(255, 247);
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.ReadOnly = true;
            this.gridPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPlayers.Size = new System.Drawing.Size(408, 196);
            this.gridPlayers.TabIndex = 7;
            this.gridPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlayers_CellDoubleClick);
            // 
            // IdPlayer
            // 
            this.IdPlayer.HeaderText = "IdPlayer";
            this.IdPlayer.Name = "IdPlayer";
            this.IdPlayer.ReadOnly = true;
            this.IdPlayer.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 120;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastName.FillWeight = 150F;
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 80;
            // 
            // chartTeamRating
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTeamRating.ChartAreas.Add(chartArea1);
            this.chartTeamRating.Location = new System.Drawing.Point(255, 12);
            this.chartTeamRating.Name = "chartTeamRating";
            this.chartTeamRating.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartTeamRating.Series.Add(series1);
            this.chartTeamRating.Size = new System.Drawing.Size(408, 204);
            this.chartTeamRating.TabIndex = 8;
            this.chartTeamRating.Text = "chart1";
            // 
            // btnTeamHistory
            // 
            this.btnTeamHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTeamHistory.Location = new System.Drawing.Point(27, 408);
            this.btnTeamHistory.Name = "btnTeamHistory";
            this.btnTeamHistory.Size = new System.Drawing.Size(192, 35);
            this.btnTeamHistory.TabIndex = 9;
            this.btnTeamHistory.Text = "Team history";
            this.btnTeamHistory.UseVisualStyleBackColor = true;
            this.btnTeamHistory.Click += new System.EventHandler(this.btnTeamHistory_Click);
            // 
            // tableResults
            // 
            this.tableResults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableResults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableResults.ColumnCount = 3;
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableResults.Location = new System.Drawing.Point(726, 28);
            this.tableResults.Name = "tableResults";
            this.tableResults.RowCount = 1;
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableResults.Size = new System.Drawing.Size(334, 415);
            this.tableResults.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Manager:";
            this.label2.Click += new System.EventHandler(this.lblManager_Click);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblManager_MouseMove);
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManager.Location = new System.Drawing.Point(104, 341);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(0, 19);
            this.lblManager.TabIndex = 12;
            this.lblManager.Click += new System.EventHandler(this.lblManager_Click);
            this.lblManager.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblManager_MouseMove);
            // 
            // FormTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1099, 468);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableResults);
            this.Controls.Add(this.btnTeamHistory);
            this.Controls.Add(this.chartTeamRating);
            this.Controls.Add(this.gridPlayers);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStadium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTeam);
            this.Name = "FormTeam";
            this.Text = "FormTeam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTeam_FormClosed);
            this.Load += new System.EventHandler(this.FormTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTeamRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStadium;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTeamRating;
        private System.Windows.Forms.Button btnTeamHistory;
        private System.Windows.Forms.TableLayoutPanel tableResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblManager;
    }
}