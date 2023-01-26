namespace CodeRedLauncher.Controls
{
    partial class CRCheckbox
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
            this.DisplayImg = new System.Windows.Forms.PictureBox();
            this.CheckPnl = new System.Windows.Forms.Panel();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.TextLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImg)).BeginInit();
            this.CheckPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayImg
            // 
            this.DisplayImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DisplayImg.BackColor = System.Drawing.Color.Transparent;
            this.DisplayImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DisplayImg.Location = new System.Drawing.Point(4, 3);
            this.DisplayImg.Name = "DisplayImg";
            this.DisplayImg.Size = new System.Drawing.Size(24, 24);
            this.DisplayImg.TabIndex = 5;
            this.DisplayImg.TabStop = false;
            // 
            // CheckPnl
            // 
            this.CheckPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CheckPnl.Controls.Add(this.BackgroundPnl);
            this.CheckPnl.Location = new System.Drawing.Point(35, 7);
            this.CheckPnl.Name = "CheckPnl";
            this.CheckPnl.Size = new System.Drawing.Size(18, 18);
            this.CheckPnl.TabIndex = 6;
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(16, 16);
            this.BackgroundPnl.TabIndex = 7;
            this.BackgroundPnl.Click += new System.EventHandler(this.BackgroundPnl_Click);
            // 
            // TextLbl
            // 
            this.TextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextLbl.BackColor = System.Drawing.Color.Transparent;
            this.TextLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextLbl.Location = new System.Drawing.Point(55, 0);
            this.TextLbl.Name = "TextLbl";
            this.TextLbl.Size = new System.Drawing.Size(245, 30);
            this.TextLbl.TabIndex = 7;
            this.TextLbl.Text = "Checkbox";
            this.TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextLbl.Click += new System.EventHandler(this.TextLbl_Click);
            // 
            // CRCheckbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TextLbl);
            this.Controls.Add(this.CheckPnl);
            this.Controls.Add(this.DisplayImg);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRCheckbox";
            this.Size = new System.Drawing.Size(300, 30);
            this.SizeChanged += new System.EventHandler(this.CRCheckbox_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImg)).EndInit();
            this.CheckPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayImg;
        private System.Windows.Forms.Panel CheckPnl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label TextLbl;
    }
}
