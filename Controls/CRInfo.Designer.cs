namespace CodeRedLauncher.Controls
{
    partial class CRInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InfoDescriptionLbl = new System.Windows.Forms.Label();
            InfoImg = new System.Windows.Forms.PictureBox();
            InfoTitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)InfoImg).BeginInit();
            SuspendLayout();
            // 
            // InfoDescriptionLbl
            // 
            InfoDescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            InfoDescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            InfoDescriptionLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            InfoDescriptionLbl.ForeColor = System.Drawing.Color.FromArgb(181, 186, 192);
            InfoDescriptionLbl.Location = new System.Drawing.Point(166, 1);
            InfoDescriptionLbl.Name = "InfoDescriptionLbl";
            InfoDescriptionLbl.Size = new System.Drawing.Size(269, 32);
            InfoDescriptionLbl.TabIndex = 25;
            InfoDescriptionLbl.Text = "description";
            InfoDescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            InfoDescriptionLbl.Click += InfoDescriptionLbl_Click;
            InfoDescriptionLbl.DoubleClick += InfoDescriptionLbl_DoubleClick;
            // 
            // InfoImg
            // 
            InfoImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            InfoImg.BackColor = System.Drawing.Color.Transparent;
            InfoImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            InfoImg.Location = new System.Drawing.Point(2, 4);
            InfoImg.Name = "InfoImg";
            InfoImg.Size = new System.Drawing.Size(28, 28);
            InfoImg.TabIndex = 24;
            InfoImg.TabStop = false;
            // 
            // InfoTitleLbl
            // 
            InfoTitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            InfoTitleLbl.BackColor = System.Drawing.Color.Transparent;
            InfoTitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InfoTitleLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InfoTitleLbl.Location = new System.Drawing.Point(40, 0);
            InfoTitleLbl.Name = "InfoTitleLbl";
            InfoTitleLbl.Size = new System.Drawing.Size(120, 35);
            InfoTitleLbl.TabIndex = 23;
            InfoTitleLbl.Text = "title";
            InfoTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CRInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(InfoTitleLbl);
            Controls.Add(InfoDescriptionLbl);
            Controls.Add(InfoImg);
            DoubleBuffered = true;
            Name = "CRInfo";
            Size = new System.Drawing.Size(435, 35);
            ((System.ComponentModel.ISupportInitialize)InfoImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label InfoDescriptionLbl;
        private System.Windows.Forms.PictureBox InfoImg;
        private System.Windows.Forms.Label InfoTitleLbl;
    }
}
