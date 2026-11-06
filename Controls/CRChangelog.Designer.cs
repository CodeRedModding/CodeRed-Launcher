namespace CodeRedLauncher.Controls
{
    partial class CRChangelog
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
            TitleLbl = new System.Windows.Forms.Label();
            TitleImg = new System.Windows.Forms.PictureBox();
            DescriptionLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)TitleImg).BeginInit();
            SuspendLayout();
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            TitleLbl.Location = new System.Drawing.Point(0, 0);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(860, 55);
            TitleLbl.TabIndex = 46;
            TitleLbl.Text = "               Module Changelog";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TitleLbl.Click += TitleLbl_Click;
            TitleLbl.DoubleClick += TitleLbl_DoubleClick;
            TitleLbl.MouseEnter += TitleLbl_MouseEnter;
            TitleLbl.MouseLeave += TitleLbl_MouseLeave;
            // 
            // TitleImg
            // 
            TitleImg.BackColor = System.Drawing.Color.Transparent;
            TitleImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TitleImg.Cursor = System.Windows.Forms.Cursors.Hand;
            TitleImg.Location = new System.Drawing.Point(15, 15);
            TitleImg.Name = "TitleImg";
            TitleImg.Size = new System.Drawing.Size(28, 28);
            TitleImg.TabIndex = 45;
            TitleImg.TabStop = false;
            TitleImg.Click += TitleImg_Click;
            TitleImg.DoubleClick += TitleImg_DoubleClick;
            TitleImg.MouseEnter += TitleImg_MouseEnter;
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DescriptionLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            DescriptionLbl.Location = new System.Drawing.Point(19, 55);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new System.Drawing.Size(820, 240);
            DescriptionLbl.TabIndex = 47;
            DescriptionLbl.Text = "Loading...";
            DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CRChangelog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            Controls.Add(DescriptionLbl);
            Controls.Add(TitleImg);
            Controls.Add(TitleLbl);
            DoubleBuffered = true;
            Name = "CRChangelog";
            Size = new System.Drawing.Size(860, 315);
            ((System.ComponentModel.ISupportInitialize)TitleImg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox TitleImg;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label DescriptionLbl;
    }
}
