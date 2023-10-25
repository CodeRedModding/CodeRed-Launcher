namespace CodeRedLauncher.Controls
{
    partial class CRLabel
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
            ((System.ComponentModel.ISupportInitialize)IconImg).BeginInit();
            SuspendLayout();
            // 
            // IconImg
            // 
            IconImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            IconImg.BackColor = System.Drawing.Color.Transparent;
            IconImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            IconImg.Location = new System.Drawing.Point(3, 4);
            IconImg.Name = "IconImg";
            IconImg.Size = new System.Drawing.Size(28, 28);
            IconImg.TabIndex = 6;
            IconImg.TabStop = false;
            // 
            // TextLbl
            // 
            TextLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextLbl.BackColor = System.Drawing.Color.Transparent;
            TextLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TextLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TextLbl.Location = new System.Drawing.Point(37, 0);
            TextLbl.Name = "TextLbl";
            TextLbl.Size = new System.Drawing.Size(188, 35);
            TextLbl.TabIndex = 8;
            TextLbl.Text = "Label";
            TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CRLabel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(TextLbl);
            Controls.Add(IconImg);
            DoubleBuffered = true;
            Name = "CRLabel";
            Size = new System.Drawing.Size(225, 35);
            ((System.ComponentModel.ISupportInitialize)IconImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox IconImg;
        private System.Windows.Forms.Label TextLbl;
    }
}
