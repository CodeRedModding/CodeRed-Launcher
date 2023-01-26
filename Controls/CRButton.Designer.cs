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
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.ButtonImg = new System.Windows.Forms.PictureBox();
            this.TextLbl = new System.Windows.Forms.Label();
            this.BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonImg)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.Red;
            this.BackgroundPnl.Controls.Add(this.ButtonImg);
            this.BackgroundPnl.Controls.Add(this.TextLbl);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(173, 33);
            this.BackgroundPnl.TabIndex = 0;
            this.BackgroundPnl.SizeChanged += new System.EventHandler(this.BackgroundPnl_SizeChanged);
            // 
            // ButtonImg
            // 
            this.ButtonImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonImg.BackColor = System.Drawing.Color.Transparent;
            this.ButtonImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonImg.Location = new System.Drawing.Point(4, 5);
            this.ButtonImg.Name = "ButtonImg";
            this.ButtonImg.Size = new System.Drawing.Size(24, 24);
            this.ButtonImg.TabIndex = 1;
            this.ButtonImg.TabStop = false;
            this.ButtonImg.Click += new System.EventHandler(this.ButtonImg_Click);
            this.ButtonImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonImg_MouseDown);
            this.ButtonImg.MouseEnter += new System.EventHandler(this.ButtonImg_MouseEnter);
            this.ButtonImg.MouseLeave += new System.EventHandler(this.ButtonImg_MouseLeave);
            this.ButtonImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonImg_MouseUp);
            // 
            // TextLbl
            // 
            this.TextLbl.BackColor = System.Drawing.Color.Transparent;
            this.TextLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextLbl.Location = new System.Drawing.Point(0, 0);
            this.TextLbl.Name = "TextLbl";
            this.TextLbl.Size = new System.Drawing.Size(173, 33);
            this.TextLbl.TabIndex = 0;
            this.TextLbl.Text = "Button";
            this.TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextLbl.Click += new System.EventHandler(this.TextLbl_Click);
            this.TextLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextLbl_MouseDown);
            this.TextLbl.MouseEnter += new System.EventHandler(this.TextLbl_MouseEnter);
            this.TextLbl.MouseLeave += new System.EventHandler(this.TextLbl_MouseLeave);
            this.TextLbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextLbl_MouseUp);
            // 
            // CRButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRButton";
            this.Size = new System.Drawing.Size(175, 35);
            this.BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label TextLbl;
        private System.Windows.Forms.PictureBox ButtonImg;
    }
}
