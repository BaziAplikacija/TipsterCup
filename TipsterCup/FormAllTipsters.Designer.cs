namespace TipsterCup
{
    partial class FormAllTipsters
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
            this.gridTipsters = new System.Windows.Forms.DataGridView();
            this.colidTipster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTipsters)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTipsters
            // 
            this.gridTipsters.AllowUserToAddRows = false;
            this.gridTipsters.AllowUserToDeleteRows = false;
            this.gridTipsters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridTipsters.BackgroundColor = System.Drawing.Color.White;
            this.gridTipsters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridTipsters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTipsters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidTipster,
            this.colRank,
            this.colTipster,
            this.colMoney});
            this.gridTipsters.Location = new System.Drawing.Point(47, 85);
            this.gridTipsters.Name = "gridTipsters";
            this.gridTipsters.ReadOnly = true;
            this.gridTipsters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTipsters.Size = new System.Drawing.Size(581, 370);
            this.gridTipsters.TabIndex = 0;
            this.gridTipsters.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTipsters_CellDoubleClick);
            // 
            // colidTipster
            // 
            this.colidTipster.HeaderText = "Id";
            this.colidTipster.Name = "colidTipster";
            this.colidTipster.ReadOnly = true;
            this.colidTipster.Visible = false;
            // 
            // colRank
            // 
            this.colRank.HeaderText = "Rank";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            this.colRank.Width = 50;
            // 
            // colTipster
            // 
            this.colTipster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTipster.HeaderText = "Tipster";
            this.colTipster.Name = "colTipster";
            this.colTipster.ReadOnly = true;
            // 
            // colMoney
            // 
            this.colMoney.HeaderText = "Money/Rating";
            this.colMoney.Name = "colMoney";
            this.colMoney.ReadOnly = true;
            // 
            // FormAllTipsters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 437);
            this.Controls.Add(this.gridTipsters);
            this.Name = "FormAllTipsters";
            this.Text = "FormAllTipsters";
            this.Load += new System.EventHandler(this.FormAllTipsters_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormAllTipsters_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gridTipsters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTipsters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidTipster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoney;

    }
}