namespace CodeRedLauncher.Controls
{
    partial class CRNews
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
            CategoryLbl = new CRLabel();
            AuthorLbl = new CRLabel();
            CalendarLbl = new CRLabel();
            ThumbnailImg = new System.Windows.Forms.PictureBox();
            NextBtn = new System.Windows.Forms.PictureBox();
            PreviousBtn = new System.Windows.Forms.PictureBox();
            TitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousBtn).BeginInit();
            SuspendLayout();
            // 
            // CategoryLbl
            // 
            CategoryLbl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            CategoryLbl.ControlType = ControlTheme.Dark;
            CategoryLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CategoryLbl.DisplayText = "Loading...";
            CategoryLbl.IconBlack = Properties.Resources.Tag_Black;
            CategoryLbl.IconBlue = Properties.Resources.Tag_Blue;
            CategoryLbl.IconPurple = Properties.Resources.Tag_Purple;
            CategoryLbl.IconRed = Properties.Resources.Tag_Red;
            CategoryLbl.IconType = IconTheme.Red;
            CategoryLbl.IconWhite = Properties.Resources.Tag_White;
            CategoryLbl.Location = new System.Drawing.Point(565, 0);
            CategoryLbl.Name = "CategoryLbl";
            CategoryLbl.Size = new System.Drawing.Size(265, 35);
            CategoryLbl.TabIndex = 13;
            // 
            // AuthorLbl
            // 
            AuthorLbl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            AuthorLbl.ControlType = ControlTheme.Dark;
            AuthorLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AuthorLbl.DisplayText = "Loading...";
            AuthorLbl.IconBlack = Properties.Resources.Account_Black;
            AuthorLbl.IconBlue = Properties.Resources.Account_Blue;
            AuthorLbl.IconPurple = Properties.Resources.Account_Purple;
            AuthorLbl.IconRed = Properties.Resources.Account_Red;
            AuthorLbl.IconType = IconTheme.Red;
            AuthorLbl.IconWhite = Properties.Resources.Account_White;
            AuthorLbl.Location = new System.Drawing.Point(300, 0);
            AuthorLbl.Name = "AuthorLbl";
            AuthorLbl.Size = new System.Drawing.Size(265, 35);
            AuthorLbl.TabIndex = 12;
            // 
            // CalendarLbl
            // 
            CalendarLbl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            CalendarLbl.ControlType = ControlTheme.Dark;
            CalendarLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CalendarLbl.DisplayText = "Loading...";
            CalendarLbl.IconBlack = Properties.Resources.Calendar_Black;
            CalendarLbl.IconBlue = Properties.Resources.Calendar_Blue;
            CalendarLbl.IconPurple = Properties.Resources.Calendar_Purple;
            CalendarLbl.IconRed = Properties.Resources.Calendar_Red;
            CalendarLbl.IconType = IconTheme.Red;
            CalendarLbl.IconWhite = Properties.Resources.Calendar_White;
            CalendarLbl.Location = new System.Drawing.Point(35, 0);
            CalendarLbl.Name = "CalendarLbl";
            CalendarLbl.Size = new System.Drawing.Size(265, 35);
            CalendarLbl.TabIndex = 11;
            // 
            // ThumbnailImg
            // 
            ThumbnailImg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ThumbnailImg.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            ThumbnailImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ThumbnailImg.Cursor = System.Windows.Forms.Cursors.Hand;
            ThumbnailImg.Location = new System.Drawing.Point(35, 35);
            ThumbnailImg.Name = "ThumbnailImg";
            ThumbnailImg.Size = new System.Drawing.Size(795, 455);
            ThumbnailImg.TabIndex = 3;
            ThumbnailImg.TabStop = false;
            ThumbnailImg.Click += ThumbnailImg_Click;
            ThumbnailImg.DoubleClick += ThumbnailImg_DoubleClick;
            // 
            // NextBtn
            // 
            NextBtn.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            NextBtn.BackgroundImage = Properties.Resources.Right_Red;
            NextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            NextBtn.Dock = System.Windows.Forms.DockStyle.Right;
            NextBtn.Location = new System.Drawing.Point(830, 0);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new System.Drawing.Size(35, 550);
            NextBtn.TabIndex = 2;
            NextBtn.TabStop = false;
            NextBtn.Click += NextBtn_Click;
            NextBtn.DoubleClick += NextBtn_DoubleClick;
            // 
            // PreviousBtn
            // 
            PreviousBtn.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            PreviousBtn.BackgroundImage = Properties.Resources.Left_Red;
            PreviousBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            PreviousBtn.Dock = System.Windows.Forms.DockStyle.Left;
            PreviousBtn.Location = new System.Drawing.Point(0, 0);
            PreviousBtn.Name = "PreviousBtn";
            PreviousBtn.Size = new System.Drawing.Size(35, 550);
            PreviousBtn.TabIndex = 0;
            PreviousBtn.TabStop = false;
            PreviousBtn.Click += PreviousBtn_Click;
            PreviousBtn.DoubleClick += PreviousBtn_DoubleClick;
            // 
            // TitleLbl
            // 
            TitleLbl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TitleLbl.Location = new System.Drawing.Point(35, 490);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(795, 60);
            TitleLbl.TabIndex = 14;
            TitleLbl.Text = "Loading...";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CRNews
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            Controls.Add(TitleLbl);
            Controls.Add(ThumbnailImg);
            Controls.Add(AuthorLbl);
            Controls.Add(CategoryLbl);
            Controls.Add(PreviousBtn);
            Controls.Add(NextBtn);
            Controls.Add(CalendarLbl);
            Name = "CRNews";
            Size = new System.Drawing.Size(865, 550);
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox ThumbnailImg;
        private System.Windows.Forms.PictureBox NextBtn;
        private System.Windows.Forms.PictureBox PreviousBtn;
        private CRLabel CalendarLbl;
        private CRLabel AuthorLbl;
        private CRLabel CategoryLbl;
        private System.Windows.Forms.Label TitleLbl;
    }
}
