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
            ThumbnailImg = new System.Windows.Forms.PictureBox();
            NextImg = new System.Windows.Forms.PictureBox();
            PreviousImg = new System.Windows.Forms.PictureBox();
            TitleLbl = new System.Windows.Forms.Label();
            DateIconLbl = new CRIconLabel();
            CategoryIconLbl = new CRIconLabel();
            AuthorIconLbl = new CRIconLabel();
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousImg).BeginInit();
            SuspendLayout();
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
            // NextImg
            // 
            NextImg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NextImg.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            NextImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            NextImg.Location = new System.Drawing.Point(830, 0);
            NextImg.Name = "NextImg";
            NextImg.Size = new System.Drawing.Size(35, 550);
            NextImg.TabIndex = 2;
            NextImg.TabStop = false;
            NextImg.Click += NextImg_Click;
            NextImg.DoubleClick += NexImg_DoubleClick;
            // 
            // PreviousImg
            // 
            PreviousImg.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            PreviousImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            PreviousImg.Dock = System.Windows.Forms.DockStyle.Left;
            PreviousImg.Location = new System.Drawing.Point(0, 0);
            PreviousImg.Name = "PreviousImg";
            PreviousImg.Size = new System.Drawing.Size(35, 550);
            PreviousImg.TabIndex = 0;
            PreviousImg.TabStop = false;
            PreviousImg.Click += PreviousBtn_Click;
            PreviousImg.DoubleClick += PreviousBtn_DoubleClick;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TitleLbl.Location = new System.Drawing.Point(35, 490);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(795, 60);
            TitleLbl.TabIndex = 14;
            TitleLbl.Text = "Loading...";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateIconLbl
            // 
            DateIconLbl.BackColor = System.Drawing.Color.Transparent;
            DateIconLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DateIconLbl.DisplayText = "Loading...";
            DateIconLbl.IconDark = Properties.Resources.Calendar_Red;
            DateIconLbl.IconLight = Properties.Resources.Calendar_Purple;
            DateIconLbl.IconSize = IconSizes.Small;
            DateIconLbl.Location = new System.Drawing.Point(35, 0);
            DateIconLbl.Name = "DateIconLbl";
            DateIconLbl.Size = new System.Drawing.Size(265, 35);
            DateIconLbl.TabIndex = 19;
            DateIconLbl.Theme = ControlTheme.Dark;
            // 
            // CategoryIconLbl
            // 
            CategoryIconLbl.BackColor = System.Drawing.Color.Transparent;
            CategoryIconLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            CategoryIconLbl.DisplayText = "Loading...";
            CategoryIconLbl.IconDark = Properties.Resources.Tag_Red;
            CategoryIconLbl.IconLight = Properties.Resources.Tag_Purple;
            CategoryIconLbl.IconSize = IconSizes.Small;
            CategoryIconLbl.Location = new System.Drawing.Point(300, 0);
            CategoryIconLbl.Name = "CategoryIconLbl";
            CategoryIconLbl.Size = new System.Drawing.Size(265, 35);
            CategoryIconLbl.TabIndex = 20;
            CategoryIconLbl.Theme = ControlTheme.Dark;
            // 
            // AuthorIconLbl
            // 
            AuthorIconLbl.BackColor = System.Drawing.Color.Transparent;
            AuthorIconLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AuthorIconLbl.DisplayText = "Loading...";
            AuthorIconLbl.IconDark = Properties.Resources.Account_Red;
            AuthorIconLbl.IconLight = Properties.Resources.Account_Purple;
            AuthorIconLbl.IconSize = IconSizes.Small;
            AuthorIconLbl.Location = new System.Drawing.Point(565, 0);
            AuthorIconLbl.Name = "AuthorIconLbl";
            AuthorIconLbl.Size = new System.Drawing.Size(265, 35);
            AuthorIconLbl.TabIndex = 21;
            AuthorIconLbl.Theme = ControlTheme.Dark;
            // 
            // CRNews
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            Controls.Add(AuthorIconLbl);
            Controls.Add(CategoryIconLbl);
            Controls.Add(DateIconLbl);
            Controls.Add(TitleLbl);
            Controls.Add(ThumbnailImg);
            Controls.Add(PreviousImg);
            Controls.Add(NextImg);
            DoubleBuffered = true;
            Name = "CRNews";
            Size = new System.Drawing.Size(865, 550);
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousImg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox ThumbnailImg;
        private System.Windows.Forms.PictureBox NextImg;
        private System.Windows.Forms.PictureBox PreviousImg;
        private System.Windows.Forms.Label TitleLbl;
        private CRIconLabel DateIconLbl;
        private CRIconLabel CategoryIconLbl;
        private CRIconLabel AuthorIconLbl;
    }
}
