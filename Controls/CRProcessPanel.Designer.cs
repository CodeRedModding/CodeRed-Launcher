namespace CodeRedLauncher.Controls
{
    partial class CRProcessPanel
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
            this.DescriptionImg = new System.Windows.Forms.PictureBox();
            this.TitleImg = new System.Windows.Forms.PictureBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleImg)).BeginInit();
            this.BackgroundPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // DescriptionImg
            // 
            this.DescriptionImg.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DescriptionImg.Location = new System.Drawing.Point(14, 64);
            this.DescriptionImg.Name = "DescriptionImg";
            this.DescriptionImg.Size = new System.Drawing.Size(35, 50);
            this.DescriptionImg.TabIndex = 47;
            this.DescriptionImg.TabStop = false;
            // 
            // TitleImg
            // 
            this.TitleImg.BackColor = System.Drawing.Color.Transparent;
            this.TitleImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TitleImg.Location = new System.Drawing.Point(14, 14);
            this.TitleImg.Name = "TitleImg";
            this.TitleImg.Size = new System.Drawing.Size(35, 50);
            this.TitleImg.TabIndex = 46;
            this.TitleImg.TabStop = false;
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DescriptionLbl.Location = new System.Drawing.Point(49, 64);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(420, 50);
            this.DescriptionLbl.TabIndex = 45;
            this.DescriptionLbl.Text = "Loading...";
            this.DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleLbl
            // 
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.Location = new System.Drawing.Point(49, 14);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(420, 50);
            this.TitleLbl.TabIndex = 44;
            this.TitleLbl.Text = "Loading...";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundPnl.Controls.Add(this.DescriptionImg);
            this.BackgroundPnl.Controls.Add(this.TitleImg);
            this.BackgroundPnl.Controls.Add(this.TitleLbl);
            this.BackgroundPnl.Controls.Add(this.DescriptionLbl);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(483, 128);
            this.BackgroundPnl.TabIndex = 48;
            // 
            // CRProcessPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRProcessPanel";
            this.Size = new System.Drawing.Size(485, 130);
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleImg)).EndInit();
            this.BackgroundPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DescriptionImg;
        private System.Windows.Forms.PictureBox TitleImg;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel BackgroundPnl;
    }
}
