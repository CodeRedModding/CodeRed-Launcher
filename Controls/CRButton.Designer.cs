namespace CodeRedLauncher.Controls
{
    partial class CRButton
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
            TextLbl = new System.Windows.Forms.Label();
            ButtonImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)ButtonImg).BeginInit();
            SuspendLayout();
            // 
            // TextLbl
            // 
            TextLbl.BackColor = System.Drawing.Color.Transparent;
            TextLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            TextLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TextLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TextLbl.Location = new System.Drawing.Point(0, 0);
            TextLbl.Name = "TextLbl";
            TextLbl.Size = new System.Drawing.Size(229, 40);
            TextLbl.TabIndex = 0;
            TextLbl.Text = "button";
            TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            TextLbl.Click += TextLbl_Click;
            TextLbl.DoubleClick += TextLbl_DoubleClick;
            TextLbl.MouseEnter += TextLbl_MouseEnter;
            TextLbl.MouseLeave += TextLbl_MouseLeave;
            // 
            // ButtonImg
            // 
            ButtonImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ButtonImg.BackColor = System.Drawing.Color.Transparent;
            ButtonImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ButtonImg.Location = new System.Drawing.Point(16, 7);
            ButtonImg.Name = "ButtonImg";
            ButtonImg.Size = new System.Drawing.Size(27, 27);
            ButtonImg.TabIndex = 2;
            ButtonImg.TabStop = false;
            ButtonImg.Visible = false;
            ButtonImg.Click += ButtonImg_Click;
            ButtonImg.DoubleClick += ButtonImg_DoubleClick;
            ButtonImg.MouseEnter += ButtonImg_MouseEnter;
            // 
            // CRButton
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(239, 48, 36);
            Controls.Add(ButtonImg);
            Controls.Add(TextLbl);
            Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRButton";
            Size = new System.Drawing.Size(229, 40);
            ((System.ComponentModel.ISupportInitialize)ButtonImg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label TextLbl;
        private System.Windows.Forms.PictureBox ButtonImg;
    }
}
