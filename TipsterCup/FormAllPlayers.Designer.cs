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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.timerName = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFirstname,
            this.colLastName,
            this.colDate,
            this.colRating,
            this.colTeam,
            this.colPosition});
            this.dataGridView1.Location = new System.Drawing.Point(12, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(714, 266);
            this.dataGridView1.TabIndex = 0;
            // 
            // colFirstname
            // 
            this.colFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFirstname.HeaderText = "First name";
            this.colFirstname.Name = "colFirstname";
            // 
            // colLastName
            // 
            this.colLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastName.HeaderText = "Last name";
            this.colLastName.Name = "colLastName";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date of birth";
            this.colDate.Name = "colDate";
            this.colDate.Width = 80;
            // 
            // colRating
            // 
            this.colRating.HeaderText = "Rating";
            this.colRating.Name = "colRating";
            this.colRating.Width = 50;
            // 
            // colTeam
            // 
            this.colTeam.HeaderText = "Team";
            this.colTeam.Name = "colTeam";
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by ";
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Checked = true;
            this.cbName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbName.Location = new System.Drawing.Point(17, 86);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(60, 22);
            this.cbName.TabIndex = 2;
            this.cbName.Text = "Name";
            this.cbName.UseVisualStyleBackColor = true;
            this.cbName.CheckedChanged += new System.EventHandler(this.cbName_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(644, 201);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 60);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(83, 86);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(220, 20);
            this.tbName.TabIndex = 11;
            // 
            // timerName
            // 
            this.timerName.Tick += new System.EventHandler(this.timerName_Tick);
            // 
            // FormAllPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 543);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAllPlayers";
            this.Text = "FormAllPlayers";
            this.Load += new System.EventHandler(this.FormAllPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Timer timerName;
    }
}