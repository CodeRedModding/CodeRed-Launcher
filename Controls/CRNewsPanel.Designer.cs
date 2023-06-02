namespace CodeRedLauncher.Controls
{
    partial class CRNewsPanel
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
            BackgroundPnl = new System.Windows.Forms.Panel();
            DetailsPnl = new System.Windows.Forms.Panel();
            IndexLbl = new System.Windows.Forms.Label();
            TitleLbl = new System.Windows.Forms.Label();
            CategoryLbl = new System.Windows.Forms.Label();
            CategoryImg = new System.Windows.Forms.PictureBox();
            UserLbl = new System.Windows.Forms.Label();
            UserImg = new System.Windows.Forms.PictureBox();
            CalendarLbl = new System.Windows.Forms.Label();
            CalendarImg = new System.Windows.Forms.PictureBox();
            ThumbnailImg = new System.Windows.Forms.PictureBox();
            NextBtn = new System.Windows.Forms.PictureBox();
            PreviousBtn = new System.Windows.Forms.PictureBox();
            BackgroundPnl.SuspendLayout();
            DetailsPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CategoryImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CalendarImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousBtn).BeginInit();
            SuspendLayout();
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            BackgroundPnl.Controls.Add(DetailsPnl);
            BackgroundPnl.Location = new System.Drawing.Point(30, 0);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(815, 550);
            BackgroundPnl.TabIndex = 1;
            // 
            // DetailsPnl
            // 
            DetailsPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DetailsPnl.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            DetailsPnl.Controls.Add(IndexLbl);
            DetailsPnl.Controls.Add(TitleLbl);
            DetailsPnl.Controls.Add(CategoryLbl);
            DetailsPnl.Controls.Add(CategoryImg);
            DetailsPnl.Controls.Add(UserLbl);
            DetailsPnl.Controls.Add(UserImg);
            DetailsPnl.Controls.Add(CalendarLbl);
            DetailsPnl.Controls.Add(CalendarImg);
            DetailsPnl.Controls.Add(ThumbnailImg);
            DetailsPnl.Location = new System.Drawing.Point(5, 1);
            DetailsPnl.Name = "DetailsPnl";
            DetailsPnl.Size = new System.Drawing.Size(808, 548);
            DetailsPnl.TabIndex = 2;
            // 
            // IndexLbl
            // 
            IndexLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            IndexLbl.BackColor = System.Drawing.Color.Transparent;
            IndexLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IndexLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            IndexLbl.Location = new System.Drawing.Point(755, 0);
            IndexLbl.Name = "IndexLbl";
            IndexLbl.Size = new System.Drawing.Size(50, 40);
            IndexLbl.TabIndex = 10;
            IndexLbl.Text = "0/0";
            IndexLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            TitleLbl.Location = new System.Drawing.Point(0, 497);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(805, 50);
            TitleLbl.TabIndex = 8;
            TitleLbl.Text = "Loading...";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            TitleLbl.Click += TitleLbl_Click;
            TitleLbl.DoubleClick += TitleLbl_DoubleClick;
            // 
            // CategoryLbl
            // 
            CategoryLbl.BackColor = System.Drawing.Color.Transparent;
            CategoryLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CategoryLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            CategoryLbl.Location = new System.Drawing.Point(572, 0);
            CategoryLbl.Name = "CategoryLbl";
            CategoryLbl.Size = new System.Drawing.Size(233, 40);
            CategoryLbl.TabIndex = 9;
            CategoryLbl.Text = "Loading...";
            CategoryLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CategoryImg
            // 
            CategoryImg.BackColor = System.Drawing.Color.Transparent;
            CategoryImg.BackgroundImage = Properties.Resources.Clipboard_White;
            CategoryImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            CategoryImg.Location = new System.Drawing.Point(532, 0);
            CategoryImg.Name = "CategoryImg";
            CategoryImg.Size = new System.Drawing.Size(40, 40);
            CategoryImg.TabIndex = 8;
            CategoryImg.TabStop = false;
            // 
            // UserLbl
            // 
            UserLbl.BackColor = System.Drawing.Color.Transparent;
            UserLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            UserLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            UserLbl.Location = new System.Drawing.Point(306, 0);
            UserLbl.Name = "UserLbl";
            UserLbl.Size = new System.Drawing.Size(226, 40);
            UserLbl.TabIndex = 7;
            UserLbl.Text = "Loading...";
            UserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserImg
            // 
            UserImg.BackColor = System.Drawing.Color.Transparent;
            UserImg.BackgroundImage = Properties.Resources.Author_White;
            UserImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            UserImg.Location = new System.Drawing.Point(266, 0);
            UserImg.Name = "UserImg";
            UserImg.Size = new System.Drawing.Size(40, 40);
            UserImg.TabIndex = 6;
            UserImg.TabStop = false;
            // 
            // CalendarLbl
            // 
            CalendarLbl.BackColor = System.Drawing.Color.Transparent;
            CalendarLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CalendarLbl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            CalendarLbl.Location = new System.Drawing.Point(40, 0);
            CalendarLbl.Name = "CalendarLbl";
            CalendarLbl.Size = new System.Drawing.Size(226, 40);
            CalendarLbl.TabIndex = 5;
            CalendarLbl.Text = "Loading...";
            CalendarLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CalendarImg
            // 
            CalendarImg.BackColor = System.Drawing.Color.Transparent;
            CalendarImg.BackgroundImage = Properties.Resources.Calendar_White;
            CalendarImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            CalendarImg.Location = new System.Drawing.Point(0, 0);
            CalendarImg.Name = "CalendarImg";
            CalendarImg.Size = new System.Drawing.Size(40, 40);
            CalendarImg.TabIndex = 2;
            CalendarImg.TabStop = false;
            // 
            // ThumbnailImg
            // 
            ThumbnailImg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ThumbnailImg.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ThumbnailImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ThumbnailImg.Cursor = System.Windows.Forms.Cursors.Hand;
            ThumbnailImg.Location = new System.Drawing.Point(0, 40);
            ThumbnailImg.Name = "ThumbnailImg";
            ThumbnailImg.Size = new System.Drawing.Size(805, 457);
            ThumbnailImg.TabIndex = 3;
            ThumbnailImg.TabStop = false;
            ThumbnailImg.Click += ThumbnailImg_Click;
            ThumbnailImg.DoubleClick += ThumbnailImg_DoubleClick;
            // 
            // NextBtn
            // 
            NextBtn.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            NextBtn.BackgroundImage = Properties.Resources.Forward_White;
            NextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            NextBtn.Dock = System.Windows.Forms.DockStyle.Right;
            NextBtn.Location = new System.Drawing.Point(840, 0);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new System.Drawing.Size(35, 550);
            NextBtn.TabIndex = 2;
            NextBtn.TabStop = false;
            NextBtn.Click += NextBtn_Click;
            NextBtn.DoubleClick += NextBtn_DoubleClick;
            NextBtn.MouseEnter += NextBtn_MouseEnter;
            NextBtn.MouseLeave += NextBtn_MouseLeave;
            // 
            // PreviousBtn
            // 
            PreviousBtn.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            PreviousBtn.BackgroundImage = Properties.Resources.Back_White;
            PreviousBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            PreviousBtn.Dock = System.Windows.Forms.DockStyle.Left;
            PreviousBtn.Location = new System.Drawing.Point(0, 0);
            PreviousBtn.Name = "PreviousBtn";
            PreviousBtn.Size = new System.Drawing.Size(35, 550);
            PreviousBtn.TabIndex = 0;
            PreviousBtn.TabStop = false;
            PreviousBtn.Click += PreviousBtn_Click;
            PreviousBtn.DoubleClick += PreviousBtn_DoubleClick;
            PreviousBtn.MouseEnter += PreviousBtn_MouseEnter;
            PreviousBtn.MouseLeave += PreviousBtn_MouseLeave;
            // 
            // CRNewsPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(PreviousBtn);
            Controls.Add(NextBtn);
            Controls.Add(BackgroundPnl);
            Name = "CRNewsPanel";
            Size = new System.Drawing.Size(875, 550);
            BackgroundPnl.ResumeLayout(false);
            DetailsPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CategoryImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)CalendarImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThumbnailImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Panel DetailsPnl;
        private System.Windows.Forms.PictureBox CalendarImg;
        private System.Windows.Forms.PictureBox UserImg;
        private System.Windows.Forms.Label CalendarLbl;
        private System.Windows.Forms.Label CategoryLbl;
        private System.Windows.Forms.PictureBox CategoryImg;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.PictureBox ThumbnailImg;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label IndexLbl;
        private System.Windows.Forms.PictureBox NextBtn;
        private System.Windows.Forms.PictureBox PreviousBtn;
    }
}
