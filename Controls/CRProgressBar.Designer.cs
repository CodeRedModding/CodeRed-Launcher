namespace CodeRedLauncher.Controls
{
    partial class CRProgressBar
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
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.ProgressImg = new System.Windows.Forms.PictureBox();
            this.BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressImg)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.BackgroundPnl.Controls.Add(this.ProgressImg);
            this.BackgroundPnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(348, 28);
            this.BackgroundPnl.TabIndex = 0;
            // 
            // ProgressImg
            // 
            this.ProgressImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgressImg.BackColor = System.Drawing.Color.Red;
            this.ProgressImg.Location = new System.Drawing.Point(0, 0);
            this.ProgressImg.Name = "ProgressImg";
            this.ProgressImg.Size = new System.Drawing.Size(0, 28);
            this.ProgressImg.TabIndex = 0;
            this.ProgressImg.TabStop = false;
            // 
            // CRProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.Name = "CRProgressBar";
            this.Size = new System.Drawing.Size(350, 30);
            this.BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProgressImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.PictureBox ProgressImg;
    }
}
