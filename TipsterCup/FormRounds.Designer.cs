namespace TipsterCup
{
    partial class FormRounds
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
            this.cbRounds = new System.Windows.Forms.ComboBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.tableResults = new TipsterCup.DoubleBufferedTableLayoutPanel();
            this.SuspendLayout();
            // 
            // cbRounds
            // 
            this.cbRounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRounds.FormattingEnabled = true;
            this.cbRounds.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbRounds.Location = new System.Drawing.Point(339, 44);
            this.cbRounds.Name = "cbRounds";
            this.cbRounds.Size = new System.Drawing.Size(121, 21);
            this.cbRounds.TabIndex = 1;
            this.cbRounds.SelectedIndexChanged += new System.EventHandler(this.cbRounds_SelectedIndexChanged);
            // 
            // lblRound
            // 
            this.lblRound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(277, 47);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(42, 13);
            this.lblRound.TabIndex = 2;
            this.lblRound.Text = "Round:";
            // 
            // tableResults
            // 
            this.tableResults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableResults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableResults.ColumnCount = 5;
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableResults.Location = new System.Drawing.Point(143, 162);
            this.tableResults.Name = "tableResults";
            this.tableResults.RowCount = 10;
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableResults.Size = new System.Drawing.Size(539, 293);
            this.tableResults.TabIndex = 0;
            // 
            // FormRounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 467);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.cbRounds);
            this.Controls.Add(this.tableResults);
            this.Name = "FormRounds";
            this.Text = "FormRound";
            this.Load += new System.EventHandler(this.FormRounds_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferedTableLayoutPanel tableResults;
        private System.Windows.Forms.ComboBox cbRounds;
        private System.Windows.Forms.Label lblRound;
    }
}