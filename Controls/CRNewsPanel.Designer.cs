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
            this.PreviousBtn = new System.Windows.Forms.PictureBox();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.DetailsPnl = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.CategoryLbl = new System.Windows.Forms.Label();
            this.CategoryImg = new System.Windows.Forms.PictureBox();
            this.UserLbl = new System.Windows.Forms.Label();
            this.UserImg = new System.Windows.Forms.PictureBox();
            this.CalendarLbl = new System.Windows.Forms.Label();
            this.CalendarImg = new System.Windows.Forms.PictureBox();
            this.ThumbnailImg = new System.Windows.Forms.PictureBox();
            this.NextBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousBtn)).BeginInit();
            this.BackgroundPnl.SuspendLayout();
            this.DetailsPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.PreviousBtn.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Back_White;
            this.PreviousBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PreviousBtn.Location = new System.Drawing.Point(0, 0);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(30, 550);
            this.PreviousBtn.TabIndex = 0;
            this.PreviousBtn.TabStop = false;
            this.PreviousBtn.Visible = false;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            this.PreviousBtn.DoubleClick += new System.EventHandler(this.PreviousBtn_DoubleClick);
            this.PreviousBtn.MouseEnter += new System.EventHandler(this.PreviousBtn_MouseEnter);
            this.PreviousBtn.MouseLeave += new System.EventHandler(this.PreviousBtn_MouseLeave);
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundPnl.Controls.Add(this.DetailsPnl);
            this.BackgroundPnl.Location = new System.Drawing.Point(30, 0);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(800, 550);
            this.BackgroundPnl.TabIndex = 1;
            // 
            // DetailsPnl
            // 
            this.DetailsPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.DetailsPnl.Controls.Add(this.TitleLbl);
            this.DetailsPnl.Controls.Add(this.CategoryLbl);
            this.DetailsPnl.Controls.Add(this.CategoryImg);
            this.DetailsPnl.Controls.Add(this.UserLbl);
            this.DetailsPnl.Controls.Add(this.UserImg);
            this.DetailsPnl.Controls.Add(this.CalendarLbl);
            this.DetailsPnl.Controls.Add(this.CalendarImg);
            this.DetailsPnl.Controls.Add(this.ThumbnailImg);
            this.DetailsPnl.Location = new System.Drawing.Point(1, 1);
            this.DetailsPnl.Name = "DetailsPnl";
            this.DetailsPnl.Size = new System.Drawing.Size(798, 548);
            this.DetailsPnl.TabIndex = 2;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TitleLbl.Location = new System.Drawing.Point(0, 497);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(798, 50);
            this.TitleLbl.TabIndex = 8;
            this.TitleLbl.Text = "Loading...";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoryLbl
            // 
            this.CategoryLbl.BackColor = System.Drawing.Color.Transparent;
            this.CategoryLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CategoryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.CategoryLbl.Location = new System.Drawing.Point(572, 0);
            this.CategoryLbl.Name = "CategoryLbl";
            this.CategoryLbl.Size = new System.Drawing.Size(226, 40);
            this.CategoryLbl.TabIndex = 9;
            this.CategoryLbl.Text = "Loading...";
            this.CategoryLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CategoryImg
            // 
            this.CategoryImg.BackColor = System.Drawing.Color.Transparent;
            this.CategoryImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Clipboard_White;
            this.CategoryImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CategoryImg.Location = new System.Drawing.Point(532, 0);
            this.CategoryImg.Name = "CategoryImg";
            this.CategoryImg.Size = new System.Drawing.Size(40, 40);
            this.CategoryImg.TabIndex = 8;
            this.CategoryImg.TabStop = false;
            // 
            // UserLbl
            // 
            this.UserLbl.BackColor = System.Drawing.Color.Transparent;
            this.UserLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.UserLbl.Location = new System.Drawing.Point(306, 0);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(226, 40);
            this.UserLbl.TabIndex = 7;
            this.UserLbl.Text = "Loading...";
            this.UserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserImg
            // 
            this.UserImg.BackColor = System.Drawing.Color.Transparent;
            this.UserImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Author_White;
            this.UserImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UserImg.Location = new System.Drawing.Point(266, 0);
            this.UserImg.Name = "UserImg";
            this.UserImg.Size = new System.Drawing.Size(40, 40);
            this.UserImg.TabIndex = 6;
            this.UserImg.TabStop = false;
            // 
            // CalendarLbl
            // 
            this.CalendarLbl.BackColor = System.Drawing.Color.Transparent;
            this.CalendarLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CalendarLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.CalendarLbl.Location = new System.Drawing.Point(40, 0);
            this.CalendarLbl.Name = "CalendarLbl";
            this.CalendarLbl.Size = new System.Drawing.Size(226, 40);
            this.CalendarLbl.TabIndex = 5;
            this.CalendarLbl.Text = "Loading...";
            this.CalendarLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CalendarImg
            // 
            this.CalendarImg.BackColor = System.Drawing.Color.Transparent;
            this.CalendarImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Calendar_White;
            this.CalendarImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CalendarImg.Location = new System.Drawing.Point(0, 0);
            this.CalendarImg.Name = "CalendarImg";
            this.CalendarImg.Size = new System.Drawing.Size(40, 40);
            this.CalendarImg.TabIndex = 2;
            this.CalendarImg.TabStop = false;
            // 
            // ThumbnailImg
            // 
            this.ThumbnailImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ThumbnailImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ThumbnailImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThumbnailImg.Location = new System.Drawing.Point(0, 40);
            this.ThumbnailImg.Name = "ThumbnailImg";
            this.ThumbnailImg.Size = new System.Drawing.Size(798, 457);
            this.ThumbnailImg.TabIndex = 3;
            this.ThumbnailImg.TabStop = false;
            this.ThumbnailImg.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.ThumbnailImg_LoadCompleted);
            this.ThumbnailImg.Click += new System.EventHandler(this.ThumbnailImg_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.NextBtn.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Forward_White;
            this.NextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextBtn.Location = new System.Drawing.Point(830, 0);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(30, 550);
            this.NextBtn.TabIndex = 2;
            this.NextBtn.TabStop = false;
            this.NextBtn.Visible = false;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            this.NextBtn.DoubleClick += new System.EventHandler(this.NextBtn_DoubleClick);
            this.NextBtn.MouseEnter += new System.EventHandler(this.NextBtn_MouseEnter);
            this.NextBtn.MouseLeave += new System.EventHandler(this.NextBtn_MouseLeave);
            // 
            // CRNewsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.BackgroundPnl);
            this.Controls.Add(this.PreviousBtn);
            this.Name = "CRNewsPanel";
            this.Size = new System.Drawing.Size(860, 550);
            ((System.ComponentModel.ISupportInitialize)(this.PreviousBtn)).EndInit();
            this.BackgroundPnl.ResumeLayout(false);
            this.DetailsPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CategoryImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PreviousBtn;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Panel DetailsPnl;
        private System.Windows.Forms.PictureBox CalendarImg;
        private System.Windows.Forms.PictureBox UserImg;
        private System.Windows.Forms.Label CalendarLbl;
        private System.Windows.Forms.Label CategoryLbl;
        private System.Windows.Forms.PictureBox CategoryImg;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.PictureBox ThumbnailImg;
        private System.Windows.Forms.PictureBox NextBtn;
        private System.Windows.Forms.Label TitleLbl;
    }
}
