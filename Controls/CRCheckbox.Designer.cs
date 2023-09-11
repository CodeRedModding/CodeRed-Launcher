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
            IconImg = new System.Windows.Forms.PictureBox();
            TextLbl = new System.Windows.Forms.Label();
            CheckImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)IconImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckImg).BeginInit();
            SuspendLayout();
            // 
            // IconImg
            // 
            IconImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            IconImg.BackColor = System.Drawing.Color.Transparent;
            IconImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            IconImg.Location = new System.Drawing.Point(3, 5);
            IconImg.Name = "IconImg";
            IconImg.Size = new System.Drawing.Size(28, 28);
            IconImg.TabIndex = 5;
            IconImg.TabStop = false;
            // 
            // TextLbl
            // 
            TextLbl.BackColor = System.Drawing.Color.Transparent;
            TextLbl.Dock = System.Windows.Forms.DockStyle.Right;
            TextLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TextLbl.Location = new System.Drawing.Point(68, 0);
            TextLbl.Name = "TextLbl";
            TextLbl.Size = new System.Drawing.Size(250, 37);
            TextLbl.TabIndex = 7;
            TextLbl.Text = "Checkbox";
            TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TextLbl.Click += TextLbl_Click;
            TextLbl.DoubleClick += TextLbl_DoubleClick;
            // 
            // CheckImg
            // 
            CheckImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            CheckImg.BackColor = System.Drawing.Color.Transparent;
            CheckImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CheckImg.Location = new System.Drawing.Point(36, 7);
            CheckImg.Name = "CheckImg";
            CheckImg.Size = new System.Drawing.Size(24, 24);
            CheckImg.TabIndex = 8;
            CheckImg.TabStop = false;
            CheckImg.Click += CheckImg_Click;
            CheckImg.DoubleClick += CheckImg_DoubleClick;
            // 
            // CRCheckbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(CheckImg);
            Controls.Add(TextLbl);
            Controls.Add(IconImg);
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRCheckbox";
            Size = new System.Drawing.Size(318, 37);
            SizeChanged += CRCheckbox_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)IconImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox IconImg;
        private System.Windows.Forms.Label TextLbl;
        private System.Windows.Forms.PictureBox CheckImg;
    }
}
