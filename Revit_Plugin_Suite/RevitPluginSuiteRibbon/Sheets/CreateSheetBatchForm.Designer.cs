namespace RevitPluginSuiteRibbon
{
    partial class CreateSheetBatchForm
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
            this.btnGenerateSheet = new System.Windows.Forms.Button();
            this.lstbxTitleblock = new System.Windows.Forms.ListBox();
            this.txtbSheetQty = new System.Windows.Forms.TextBox();
            this.lblSheetQuantity = new System.Windows.Forms.Label();
            this.txtbSheetName = new System.Windows.Forms.TextBox();
            this.lblSheetName = new System.Windows.Forms.Label();
            this.txtbSheetNumPrefix = new System.Windows.Forms.TextBox();
            this.lblSheetNumber = new System.Windows.Forms.Label();
            this.grpbxSheetInfo = new System.Windows.Forms.GroupBox();
            this.txtbSheetNumber = new System.Windows.Forms.TextBox();
            this.lblTitleblock = new System.Windows.Forms.Label();
            this.btnLoadTitleblock = new System.Windows.Forms.Button();
            this.grpbxSheetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateSheet
            // 
            this.btnGenerateSheet.Location = new System.Drawing.Point(297, 158);
            this.btnGenerateSheet.Name = "btnGenerateSheet";
            this.btnGenerateSheet.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateSheet.TabIndex = 7;
            this.btnGenerateSheet.Text = "Generate";
            this.btnGenerateSheet.UseVisualStyleBackColor = true;
            this.btnGenerateSheet.Click += new System.EventHandler(this.btnGenerateSheet_Click);
            // 
            // lstbxTitleblock
            // 
            this.lstbxTitleblock.FormattingEnabled = true;
            this.lstbxTitleblock.Location = new System.Drawing.Point(212, 44);
            this.lstbxTitleblock.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.lstbxTitleblock.Name = "lstbxTitleblock";
            this.lstbxTitleblock.Size = new System.Drawing.Size(160, 108);
            this.lstbxTitleblock.Sorted = true;
            this.lstbxTitleblock.TabIndex = 6;
            // 
            // txtbSheetQty
            // 
            this.txtbSheetQty.Location = new System.Drawing.Point(9, 34);
            this.txtbSheetQty.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtbSheetQty.MaxLength = 3;
            this.txtbSheetQty.Name = "txtbSheetQty";
            this.txtbSheetQty.Size = new System.Drawing.Size(160, 20);
            this.txtbSheetQty.TabIndex = 1;
            this.txtbSheetQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbSheetQty_KeyPress);
            // 
            // lblSheetQuantity
            // 
            this.lblSheetQuantity.AutoSize = true;
            this.lblSheetQuantity.Location = new System.Drawing.Point(6, 16);
            this.lblSheetQuantity.Name = "lblSheetQuantity";
            this.lblSheetQuantity.Size = new System.Drawing.Size(54, 13);
            this.lblSheetQuantity.TabIndex = 6;
            this.lblSheetQuantity.Text = "Sheet Qty";
            // 
            // txtbSheetName
            // 
            this.txtbSheetName.Location = new System.Drawing.Point(9, 134);
            this.txtbSheetName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtbSheetName.Name = "txtbSheetName";
            this.txtbSheetName.Size = new System.Drawing.Size(160, 20);
            this.txtbSheetName.TabIndex = 4;
            // 
            // lblSheetName
            // 
            this.lblSheetName.AutoSize = true;
            this.lblSheetName.Location = new System.Drawing.Point(6, 116);
            this.lblSheetName.Name = "lblSheetName";
            this.lblSheetName.Size = new System.Drawing.Size(101, 13);
            this.lblSheetName.TabIndex = 6;
            this.lblSheetName.Text = "Sheet Name (Prefix)";
            // 
            // txtbSheetNumPrefix
            // 
            this.txtbSheetNumPrefix.Location = new System.Drawing.Point(9, 84);
            this.txtbSheetNumPrefix.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtbSheetNumPrefix.Name = "txtbSheetNumPrefix";
            this.txtbSheetNumPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtbSheetNumPrefix.TabIndex = 2;
            // 
            // lblSheetNumber
            // 
            this.lblSheetNumber.AutoSize = true;
            this.lblSheetNumber.Location = new System.Drawing.Point(6, 66);
            this.lblSheetNumber.Name = "lblSheetNumber";
            this.lblSheetNumber.Size = new System.Drawing.Size(97, 13);
            this.lblSheetNumber.TabIndex = 6;
            this.lblSheetNumber.Text = "First Sheet Number";
            // 
            // grpbxSheetInfo
            // 
            this.grpbxSheetInfo.Controls.Add(this.lblSheetQuantity);
            this.grpbxSheetInfo.Controls.Add(this.lblSheetNumber);
            this.grpbxSheetInfo.Controls.Add(this.txtbSheetQty);
            this.grpbxSheetInfo.Controls.Add(this.lblSheetName);
            this.grpbxSheetInfo.Controls.Add(this.txtbSheetNumber);
            this.grpbxSheetInfo.Controls.Add(this.txtbSheetNumPrefix);
            this.grpbxSheetInfo.Controls.Add(this.txtbSheetName);
            this.grpbxSheetInfo.Location = new System.Drawing.Point(12, 12);
            this.grpbxSheetInfo.Name = "grpbxSheetInfo";
            this.grpbxSheetInfo.Size = new System.Drawing.Size(183, 169);
            this.grpbxSheetInfo.TabIndex = 7;
            this.grpbxSheetInfo.TabStop = false;
            this.grpbxSheetInfo.Text = "Sheet Info";
            // 
            // txtbSheetNumber
            // 
            this.txtbSheetNumber.Location = new System.Drawing.Point(119, 84);
            this.txtbSheetNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtbSheetNumber.Name = "txtbSheetNumber";
            this.txtbSheetNumber.Size = new System.Drawing.Size(50, 20);
            this.txtbSheetNumber.TabIndex = 3;
            // 
            // lblTitleblock
            // 
            this.lblTitleblock.AutoSize = true;
            this.lblTitleblock.Location = new System.Drawing.Point(219, 22);
            this.lblTitleblock.Name = "lblTitleblock";
            this.lblTitleblock.Size = new System.Drawing.Size(53, 13);
            this.lblTitleblock.TabIndex = 6;
            this.lblTitleblock.Text = "Titleblock";
            // 
            // btnLoadTitleblock
            // 
            this.btnLoadTitleblock.Location = new System.Drawing.Point(297, 12);
            this.btnLoadTitleblock.Name = "btnLoadTitleblock";
            this.btnLoadTitleblock.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTitleblock.TabIndex = 5;
            this.btnLoadTitleblock.Text = "Load...";
            this.btnLoadTitleblock.UseVisualStyleBackColor = true;
            this.btnLoadTitleblock.Click += new System.EventHandler(this.btnLoadTitleblock_Click);
            // 
            // CreateSheetBatchForm
            // 
            this.AcceptButton = this.btnGenerateSheet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 192);
            this.Controls.Add(this.lblTitleblock);
            this.Controls.Add(this.grpbxSheetInfo);
            this.Controls.Add(this.lstbxTitleblock);
            this.Controls.Add(this.btnLoadTitleblock);
            this.Controls.Add(this.btnGenerateSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSheetBatchForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Sheet Batch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateSheetBatchForm_Load);
            this.grpbxSheetInfo.ResumeLayout(false);
            this.grpbxSheetInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerateSheet;
        public System.Windows.Forms.ListBox lstbxTitleblock;
        private System.Windows.Forms.TextBox txtbSheetQty;
        private System.Windows.Forms.Label lblSheetQuantity;
        private System.Windows.Forms.TextBox txtbSheetName;
        private System.Windows.Forms.Label lblSheetName;
        private System.Windows.Forms.TextBox txtbSheetNumPrefix;
        private System.Windows.Forms.Label lblSheetNumber;
        private System.Windows.Forms.GroupBox grpbxSheetInfo;
        private System.Windows.Forms.Label lblTitleblock;
        private System.Windows.Forms.Button btnLoadTitleblock;
        private System.Windows.Forms.TextBox txtbSheetNumber;
    }
}