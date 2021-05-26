namespace RevitPluginSuiteRibbon.Manage
{
    partial class ManageRevisionsForm
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
            this.chklstbxSheets = new System.Windows.Forms.CheckedListBox();
            this.chklstbxRevisions = new System.Windows.Forms.CheckedListBox();
            this.lblRevisions = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnManageRevisions = new System.Windows.Forms.Button();
            this.txtbSheetFilter = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.gbSheets = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // chklstbxSheets
            // 
            this.chklstbxSheets.CheckOnClick = true;
            this.chklstbxSheets.FormattingEnabled = true;
            this.chklstbxSheets.Location = new System.Drawing.Point(12, 71);
            this.chklstbxSheets.Name = "chklstbxSheets";
            this.chklstbxSheets.Size = new System.Drawing.Size(300, 319);
            this.chklstbxSheets.Sorted = true;
            this.chklstbxSheets.TabIndex = 2;
            this.chklstbxSheets.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.chklstbxSheets_Format);
            // 
            // chklstbxRevisions
            // 
            this.chklstbxRevisions.CheckOnClick = true;
            this.chklstbxRevisions.FormattingEnabled = true;
            this.chklstbxRevisions.Location = new System.Drawing.Point(332, 41);
            this.chklstbxRevisions.Name = "chklstbxRevisions";
            this.chklstbxRevisions.Size = new System.Drawing.Size(300, 349);
            this.chklstbxRevisions.Sorted = true;
            this.chklstbxRevisions.TabIndex = 4;
            this.chklstbxRevisions.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.chklstbxRevisions_Format);
            // 
            // lblRevisions
            // 
            this.lblRevisions.AutoSize = true;
            this.lblRevisions.Location = new System.Drawing.Point(329, 17);
            this.lblRevisions.Name = "lblRevisions";
            this.lblRevisions.Size = new System.Drawing.Size(53, 13);
            this.lblRevisions.TabIndex = 2;
            this.lblRevisions.Text = "Revisions";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(557, 402);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnManageRevisions
            // 
            this.btnManageRevisions.Location = new System.Drawing.Point(507, 12);
            this.btnManageRevisions.Name = "btnManageRevisions";
            this.btnManageRevisions.Size = new System.Drawing.Size(125, 23);
            this.btnManageRevisions.TabIndex = 3;
            this.btnManageRevisions.Text = "Manage Revisions...";
            this.btnManageRevisions.UseVisualStyleBackColor = true;
            this.btnManageRevisions.Click += new System.EventHandler(this.btnManageRevisions_Click);
            // 
            // txtbSheetFilter
            // 
            this.txtbSheetFilter.Location = new System.Drawing.Point(55, 41);
            this.txtbSheetFilter.Name = "txtbSheetFilter";
            this.txtbSheetFilter.Size = new System.Drawing.Size(257, 20);
            this.txtbSheetFilter.TabIndex = 1;
            this.txtbSheetFilter.TextChanged += new System.EventHandler(this.txtbFilterSheets_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            // 
            // gbSheets
            // 
            this.gbSheets.Location = new System.Drawing.Point(4, 17);
            this.gbSheets.Name = "gbSheets";
            this.gbSheets.Size = new System.Drawing.Size(319, 384);
            this.gbSheets.TabIndex = 6;
            this.gbSheets.TabStop = false;
            this.gbSheets.Text = "Sheets";
            // 
            // ManageRevisionsForm
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 437);
            this.Controls.Add(this.txtbSheetFilter);
            this.Controls.Add(this.btnManageRevisions);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblRevisions);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.chklstbxRevisions);
            this.Controls.Add(this.chklstbxSheets);
            this.Controls.Add(this.gbSheets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageRevisionsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Revisions";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ManageRevisionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstbxSheets;
        private System.Windows.Forms.CheckedListBox chklstbxRevisions;
        private System.Windows.Forms.Label lblRevisions;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnManageRevisions;
        private System.Windows.Forms.TextBox txtbSheetFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox gbSheets;
    }
}