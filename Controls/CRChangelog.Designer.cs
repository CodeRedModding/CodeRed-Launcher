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
            this.TitlePnl = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.TitleImg = new System.Windows.Forms.PictureBox();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.ChangelogLbl = new System.Windows.Forms.Label();
            this.TitlePnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleImg)).BeginInit();
            this.BackgroundPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePnl
            // 
            this.TitlePnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.TitlePnl.Controls.Add(this.TitleLbl);
            this.TitlePnl.Controls.Add(this.TitleImg);
            this.TitlePnl.Location = new System.Drawing.Point(0, 0);
            this.TitlePnl.Name = "TitlePnl";
            this.TitlePnl.Size = new System.Drawing.Size(858, 40);
            this.TitlePnl.TabIndex = 0;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TitleLbl.Location = new System.Drawing.Point(40, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(818, 40);
            this.TitleLbl.TabIndex = 46;
            this.TitleLbl.Text = "Changelog";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLbl.Click += new System.EventHandler(this.TitleLbl_Click);
            // 
            // TitleImg
            // 
            this.TitleImg.BackColor = System.Drawing.Color.Transparent;
            this.TitleImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TitleImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TitleImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleImg.Location = new System.Drawing.Point(0, 0);
            this.TitleImg.Name = "TitleImg";
            this.TitleImg.Size = new System.Drawing.Size(40, 40);
            this.TitleImg.TabIndex = 45;
            this.TitleImg.TabStop = false;
            this.TitleImg.Click += new System.EventHandler(this.TitleImg_Click);
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundPnl.Controls.Add(this.ChangelogLbl);
            this.BackgroundPnl.Controls.Add(this.TitlePnl);
            this.BackgroundPnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(858, 313);
            this.BackgroundPnl.TabIndex = 48;
            // 
            // ChangelogLbl
            // 
            this.ChangelogLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogLbl.BackColor = System.Drawing.Color.Transparent;
            this.ChangelogLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ChangelogLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ChangelogLbl.Location = new System.Drawing.Point(10, 45);
            this.ChangelogLbl.Name = "ChangelogLbl";
            this.ChangelogLbl.Size = new System.Drawing.Size(838, 263);
            this.ChangelogLbl.TabIndex = 47;
            this.ChangelogLbl.Text = "Loading...";
            this.ChangelogLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CRChangelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.Name = "CRChangelog";
            this.Size = new System.Drawing.Size(860, 315);
            this.TitlePnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitleImg)).EndInit();
            this.BackgroundPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePnl;
        private System.Windows.Forms.PictureBox TitleImg;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label ChangelogLbl;
    }
}
