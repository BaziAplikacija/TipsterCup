namespace TipsterCup
{
    partial class FormStatistics
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
            this.btnDreamTeam = new System.Windows.Forms.Button();
            this.btnLastPerformance = new System.Windows.Forms.Button();
            this.btnAverageAge = new System.Windows.Forms.Button();
            this.btnTopscorer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridLastPerformance = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTopscorers = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLastPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTopscorers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDreamTeam
            // 
            this.btnDreamTeam.BackColor = System.Drawing.SystemColors.Control;
            this.btnDreamTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDreamTeam.Location = new System.Drawing.Point(0, 0);
            this.btnDreamTeam.Name = "btnDreamTeam";
            this.btnDreamTeam.Size = new System.Drawing.Size(135, 64);
            this.btnDreamTeam.TabIndex = 0;
            this.btnDreamTeam.Text = "Dream team";
            this.btnDreamTeam.UseVisualStyleBackColor = false;
            // 
            // btnLastPerformance
            // 
            this.btnLastPerformance.BackColor = System.Drawing.SystemColors.Control;
            this.btnLastPerformance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastPerformance.Location = new System.Drawing.Point(0, 60);
            this.btnLastPerformance.Name = "btnLastPerformance";
            this.btnLastPerformance.Size = new System.Drawing.Size(135, 64);
            this.btnLastPerformance.TabIndex = 1;
            this.btnLastPerformance.Text = "Last performance";
            this.btnLastPerformance.UseVisualStyleBackColor = false;
            this.btnLastPerformance.Click += new System.EventHandler(this.btnLastPerformance_Click);
            // 
            // btnAverageAge
            // 
            this.btnAverageAge.BackColor = System.Drawing.SystemColors.Control;
            this.btnAverageAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAverageAge.Location = new System.Drawing.Point(133, 0);
            this.btnAverageAge.Name = "btnAverageAge";
            this.btnAverageAge.Size = new System.Drawing.Size(135, 64);
            this.btnAverageAge.TabIndex = 2;
            this.btnAverageAge.Text = "Average age";
            this.btnAverageAge.UseVisualStyleBackColor = false;
            // 
            // btnTopscorer
            // 
            this.btnTopscorer.BackColor = System.Drawing.SystemColors.Control;
            this.btnTopscorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopscorer.Location = new System.Drawing.Point(133, 60);
            this.btnTopscorer.Name = "btnTopscorer";
            this.btnTopscorer.Size = new System.Drawing.Size(135, 64);
            this.btnTopscorer.TabIndex = 3;
            this.btnTopscorer.Text = "Top scorer(s)";
            this.btnTopscorer.UseVisualStyleBackColor = false;
            this.btnTopscorer.Click += new System.EventHandler(this.btnTopscorer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDreamTeam);
            this.panel1.Controls.Add(this.btnTopscorer);
            this.panel1.Controls.Add(this.btnAverageAge);
            this.panel1.Controls.Add(this.btnLastPerformance);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 209);
            this.panel1.TabIndex = 4;
            // 
            // gridLastPerformance
            // 
            this.gridLastPerformance.AllowUserToAddRows = false;
            this.gridLastPerformance.AllowUserToDeleteRows = false;
            this.gridLastPerformance.BackgroundColor = System.Drawing.Color.White;
            this.gridLastPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLastPerformance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colForm});
            this.gridLastPerformance.Location = new System.Drawing.Point(326, 52);
            this.gridLastPerformance.Name = "gridLastPerformance";
            this.gridLastPerformance.ReadOnly = true;
            this.gridLastPerformance.RowHeadersVisible = false;
            this.gridLastPerformance.Size = new System.Drawing.Size(244, 150);
            this.gridLastPerformance.TabIndex = 4;
            this.gridLastPerformance.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colForm
            // 
            this.colForm.HeaderText = "Form";
            this.colForm.Name = "colForm";
            this.colForm.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.Location = new System.Drawing.Point(286, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(244, 150);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Form";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // gridTopscorers
            // 
            this.gridTopscorers.AllowUserToAddRows = false;
            this.gridTopscorers.AllowUserToDeleteRows = false;
            this.gridTopscorers.BackgroundColor = System.Drawing.Color.White;
            this.gridTopscorers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTopscorers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.colTeam,
            this.dataGridViewTextBoxColumn4});
            this.gridTopscorers.Location = new System.Drawing.Point(590, 52);
            this.gridTopscorers.Name = "gridTopscorers";
            this.gridTopscorers.ReadOnly = true;
            this.gridTopscorers.RowHeadersVisible = false;
            this.gridTopscorers.Size = new System.Drawing.Size(244, 150);
            this.gridTopscorers.TabIndex = 6;
            this.gridTopscorers.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView3.Location = new System.Drawing.Point(564, 228);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(244, 150);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Form";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // colTeam
            // 
            this.colTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTeam.HeaderText = "Team";
            this.colTeam.Name = "colTeam";
            this.colTeam.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Goals";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 378);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.gridTopscorers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gridLastPerformance);
            this.Controls.Add(this.panel1);
            this.Name = "FormStatistics";
            this.Text = "FormStatistics";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLastPerformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTopscorers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDreamTeam;
        private System.Windows.Forms.Button btnLastPerformance;
        private System.Windows.Forms.Button btnAverageAge;
        private System.Windows.Forms.Button btnTopscorer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridLastPerformance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView gridTopscorers;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}