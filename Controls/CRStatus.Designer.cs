namespace CodeRedLauncher.Controls
{
    partial class CRStatus
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
            DescriptionImg = new System.Windows.Forms.PictureBox();
            TitleImg = new System.Windows.Forms.PictureBox();
            DescriptionLbl = new System.Windows.Forms.Label();
            TitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)DescriptionImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TitleImg).BeginInit();
            SuspendLayout();
            // 
            // DescriptionImg
            // 
            DescriptionImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            DescriptionImg.BackColor = System.Drawing.Color.Transparent;
            DescriptionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            DescriptionImg.Location = new System.Drawing.Point(14, 80);
            DescriptionImg.Name = "DescriptionImg";
            DescriptionImg.Size = new System.Drawing.Size(24, 24);
            DescriptionImg.TabIndex = 47;
            DescriptionImg.TabStop = false;
            // 
            // TitleImg
            // 
            TitleImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            TitleImg.BackColor = System.Drawing.Color.Transparent;
            TitleImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TitleImg.Location = new System.Drawing.Point(10, 22);
            TitleImg.Name = "TitleImg";
            TitleImg.Size = new System.Drawing.Size(32, 32);
            TitleImg.TabIndex = 46;
            TitleImg.TabStop = false;
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DescriptionLbl.Location = new System.Drawing.Point(49, 64);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new System.Drawing.Size(420, 50);
            DescriptionLbl.TabIndex = 45;
            DescriptionLbl.Text = "Loading...";
            DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLbl.Location = new System.Drawing.Point(49, 14);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(420, 50);
            TitleLbl.TabIndex = 44;
            TitleLbl.Text = "Loading...";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CRStatus
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            Controls.Add(DescriptionImg);
            Controls.Add(TitleImg);
            Controls.Add(TitleLbl);
            Controls.Add(DescriptionLbl);
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRStatus";
            Size = new System.Drawing.Size(485, 130);
            ((System.ComponentModel.ISupportInitialize)DescriptionImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)TitleImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox DescriptionImg;
        private System.Windows.Forms.PictureBox TitleImg;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
    }
}
