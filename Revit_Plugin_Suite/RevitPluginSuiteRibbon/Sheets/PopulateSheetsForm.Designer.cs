namespace RevitPluginSuiteRibbon.Sheets
{
    partial class PopulateSheetsForm
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
            this.btnDone = new System.Windows.Forms.Button();
            this.chklstbxViews = new System.Windows.Forms.CheckedListBox();
            this.lstbxSheets = new System.Windows.Forms.ListBox();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblSheet = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.txtbxViewFilter = new System.Windows.Forms.TextBox();
            this.txtbxSheetFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(557, 403);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // chklstbxViews
            // 
            this.chklstbxViews.FormattingEnabled = true;
            this.chklstbxViews.Location = new System.Drawing.Point(12, 52);
            this.chklstbxViews.Name = "chklstbxViews";
            this.chklstbxViews.Size = new System.Drawing.Size(300, 319);
            this.chklstbxViews.TabIndex = 1;
            // 
            // lstbxSheets
            // 
            this.lstbxSheets.FormattingEnabled = true;
            this.lstbxSheets.Location = new System.Drawing.Point(332, 52);
            this.lstbxSheets.Name = "lstbxSheets";
            this.lstbxSheets.Size = new System.Drawing.Size(300, 316);
            this.lstbxSheets.TabIndex = 2;
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(12, 9);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(35, 13);
            this.lblViews.TabIndex = 3;
            this.lblViews.Text = "Views";
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Location = new System.Drawing.Point(329, 9);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(35, 13);
            this.lblSheet.TabIndex = 4;
            this.lblSheet.Text = "Sheet";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(451, 374);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Sheet";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(557, 374);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(75, 23);
            this.btnPopulate.TabIndex = 6;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            // 
            // txtbxViewFilter
            // 
            this.txtbxViewFilter.Location = new System.Drawing.Point(13, 26);
            this.txtbxViewFilter.Name = "txtbxViewFilter";
            this.txtbxViewFilter.Size = new System.Drawing.Size(299, 20);
            this.txtbxViewFilter.TabIndex = 7;
            // 
            // txtbxSheetFilter
            // 
            this.txtbxSheetFilter.Location = new System.Drawing.Point(332, 26);
            this.txtbxSheetFilter.Name = "txtbxSheetFilter";
            this.txtbxSheetFilter.Size = new System.Drawing.Size(299, 20);
            this.txtbxSheetFilter.TabIndex = 7;
            // 
            // PopulateSheetsForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 436);
            this.Controls.Add(this.txtbxSheetFilter);
            this.Controls.Add(this.txtbxViewFilter);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSheet);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.lstbxSheets);
            this.Controls.Add(this.chklstbxViews);
            this.Controls.Add(this.btnDone);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopulateSheetsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Populate Sheets";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckedListBox chklstbxViews;
        private System.Windows.Forms.ListBox lstbxSheets;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.TextBox txtbxViewFilter;
        private System.Windows.Forms.TextBox txtbxSheetFilter;
    }
}