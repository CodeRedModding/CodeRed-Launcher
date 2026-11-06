namespace CodeRedLauncher.Controls
{
    partial class CRAboutInfo
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
            DescriptionLbl = new System.Windows.Forms.Label();
            IconImg = new System.Windows.Forms.PictureBox();
            TitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)IconImg).BeginInit();
            SuspendLayout();
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            DescriptionLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            DescriptionLbl.ForeColor = System.Drawing.Color.FromArgb(194, 194, 198);
            DescriptionLbl.Location = new System.Drawing.Point(166, 1);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new System.Drawing.Size(269, 32);
            DescriptionLbl.TabIndex = 25;
            DescriptionLbl.Text = "Description";
            DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DescriptionLbl.Click += DescriptionLbl_Click;
            DescriptionLbl.DoubleClick += DescriptionLbl_DoubleClick;
            // 
            // IconImg
            // 
            IconImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            IconImg.BackColor = System.Drawing.Color.Transparent;
            IconImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            IconImg.Location = new System.Drawing.Point(2, 4);
            IconImg.Name = "IconImg";
            IconImg.Size = new System.Drawing.Size(28, 28);
            IconImg.TabIndex = 24;
            IconImg.TabStop = false;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(242, 242, 242);
            TitleLbl.Location = new System.Drawing.Point(40, 0);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(120, 35);
            TitleLbl.TabIndex = 23;
            TitleLbl.Text = "Title";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CRAboutInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(TitleLbl);
            Controls.Add(DescriptionLbl);
            Controls.Add(IconImg);
            DoubleBuffered = true;
            Name = "CRAboutInfo";
            Size = new System.Drawing.Size(435, 35);
            ((System.ComponentModel.ISupportInitialize)IconImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox IconImg;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
    }
}
