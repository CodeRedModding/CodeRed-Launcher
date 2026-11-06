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
            ActiveImg = new System.Windows.Forms.PictureBox();
            TabImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)ActiveImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TabImg).BeginInit();
            SuspendLayout();
            // 
            // ActiveImg
            // 
            ActiveImg.BackColor = System.Drawing.Color.FromArgb(239, 48, 36);
            ActiveImg.Dock = System.Windows.Forms.DockStyle.Left;
            ActiveImg.Location = new System.Drawing.Point(0, 0);
            ActiveImg.Name = "ActiveImg";
            ActiveImg.Size = new System.Drawing.Size(2, 50);
            ActiveImg.TabIndex = 0;
            ActiveImg.TabStop = false;
            ActiveImg.Visible = false;
            // 
            // TabImg
            // 
            TabImg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabImg.BackColor = System.Drawing.Color.Transparent;
            TabImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TabImg.Location = new System.Drawing.Point(16, 11);
            TabImg.Name = "TabImg";
            TabImg.Size = new System.Drawing.Size(28, 28);
            TabImg.TabIndex = 1;
            TabImg.TabStop = false;
            TabImg.Click += TabImg_Click;
            TabImg.DoubleClick += TabImg_DoubleClick;
            // 
            // CRTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(ActiveImg);
            Controls.Add(TabImg);
            DoubleBuffered = true;
            Name = "CRTab";
            Size = new System.Drawing.Size(60, 50);
            Click += CRTab_Click;
            DoubleClick += CRTab_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)ActiveImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)TabImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox ActiveImg;
        private System.Windows.Forms.PictureBox TabImg;
    }
}
