namespace CodeRedLauncher.Controls
{
    partial class CRTab
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
            this.TintPnl = new System.Windows.Forms.PictureBox();
            this.TabImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TintPnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabImg)).BeginInit();
            this.SuspendLayout();
            // 
            // TintPnl
            // 
            this.TintPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TintPnl.BackColor = System.Drawing.Color.Red;
            this.TintPnl.Location = new System.Drawing.Point(0, 0);
            this.TintPnl.Name = "TintPnl";
            this.TintPnl.Size = new System.Drawing.Size(2, 50);
            this.TintPnl.TabIndex = 0;
            this.TintPnl.TabStop = false;
            this.TintPnl.Visible = false;
            // 
            // TabImg
            // 
            this.TabImg.BackColor = System.Drawing.Color.Transparent;
            this.TabImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TabImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabImg.Location = new System.Drawing.Point(0, 0);
            this.TabImg.Name = "TabImg";
            this.TabImg.Size = new System.Drawing.Size(60, 50);
            this.TabImg.TabIndex = 1;
            this.TabImg.TabStop = false;
            this.TabImg.Click += new System.EventHandler(this.TabImg_Click);
            this.TabImg.DoubleClick += new System.EventHandler(this.TabImg_DoubleClick);
            this.TabImg.MouseEnter += new System.EventHandler(this.TabImg_MouseEnter);
            this.TabImg.MouseLeave += new System.EventHandler(this.TabImg_MouseLeave);
            // 
            // CRTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.TintPnl);
            this.Controls.Add(this.TabImg);
            this.Name = "CRTab";
            this.Size = new System.Drawing.Size(60, 50);
            ((System.ComponentModel.ISupportInitialize)(this.TintPnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TintPnl;
        private System.Windows.Forms.PictureBox TabImg;
    }
}
