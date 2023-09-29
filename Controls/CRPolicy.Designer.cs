namespace CodeRedLauncher.Controls
{
    partial class CRPolicy
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
            BackgroundPnl = new System.Windows.Forms.Panel();
            AcceptBtn = new CRButton();
            DenyBtn = new CRButton();
            AltBtn = new CRButton();
            TitleLbl = new System.Windows.Forms.Label();
            DescriptionBx = new System.Windows.Forms.RichTextBox();
            ArtImage = new System.Windows.Forms.PictureBox();
            BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtImage).BeginInit();
            SuspendLayout();
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            BackgroundPnl.Controls.Add(AcceptBtn);
            BackgroundPnl.Controls.Add(DenyBtn);
            BackgroundPnl.Controls.Add(AltBtn);
            BackgroundPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            BackgroundPnl.Location = new System.Drawing.Point(0, 530);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(970, 100);
            BackgroundPnl.TabIndex = 9;
            // 
            // AcceptBtn
            // 
            AcceptBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            AcceptBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            AcceptBtn.ButtonEnabled = true;
            AcceptBtn.ControlType = ControlTheme.Dark;
            AcceptBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AcceptBtn.DisplayText = "I agree";
            AcceptBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AcceptBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            AcceptBtn.IconBlack = null;
            AcceptBtn.IconBlue = null;
            AcceptBtn.IconPurple = null;
            AcceptBtn.IconRed = null;
            AcceptBtn.IconSync = false;
            AcceptBtn.IconType = IconTheme.White;
            AcceptBtn.IconWhite = null;
            AcceptBtn.Location = new System.Drawing.Point(150, 35);
            AcceptBtn.Name = "AcceptBtn";
            AcceptBtn.Size = new System.Drawing.Size(300, 40);
            AcceptBtn.TabIndex = 0;
            AcceptBtn.OnButtonClick += AcceptBtn_OnButtonClick;
            // 
            // DenyBtn
            // 
            DenyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            DenyBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            DenyBtn.ButtonEnabled = true;
            DenyBtn.ControlType = ControlTheme.Dark;
            DenyBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DenyBtn.DisplayText = "I do not agree";
            DenyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DenyBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            DenyBtn.IconBlack = null;
            DenyBtn.IconBlue = null;
            DenyBtn.IconPurple = null;
            DenyBtn.IconRed = null;
            DenyBtn.IconSync = false;
            DenyBtn.IconType = IconTheme.White;
            DenyBtn.IconWhite = null;
            DenyBtn.Location = new System.Drawing.Point(520, 35);
            DenyBtn.Name = "DenyBtn";
            DenyBtn.Size = new System.Drawing.Size(300, 40);
            DenyBtn.TabIndex = 7;
            DenyBtn.OnButtonClick += DenyBtn_OnButtonClick;
            // 
            // AltBtn
            // 
            AltBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            AltBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            AltBtn.ButtonEnabled = true;
            AltBtn.ControlType = ControlTheme.Dark;
            AltBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AltBtn.DisplayText = "Yeah cool I'm done reading";
            AltBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AltBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            AltBtn.IconBlack = null;
            AltBtn.IconBlue = null;
            AltBtn.IconPurple = null;
            AltBtn.IconRed = null;
            AltBtn.IconSync = false;
            AltBtn.IconType = IconTheme.White;
            AltBtn.IconWhite = null;
            AltBtn.Location = new System.Drawing.Point(335, 35);
            AltBtn.Name = "AltBtn";
            AltBtn.Size = new System.Drawing.Size(300, 40);
            AltBtn.TabIndex = 8;
            AltBtn.OnButtonClick += AltBtn_OnButtonClick;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLbl.ForeColor = System.Drawing.Color.White;
            TitleLbl.Location = new System.Drawing.Point(210, 25);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(550, 80);
            TitleLbl.TabIndex = 10;
            TitleLbl.Text = "Privacy Policy";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionBx
            // 
            DescriptionBx.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            DescriptionBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DescriptionBx.DetectUrls = false;
            DescriptionBx.Location = new System.Drawing.Point(50, 108);
            DescriptionBx.Name = "DescriptionBx";
            DescriptionBx.ReadOnly = true;
            DescriptionBx.Size = new System.Drawing.Size(865, 385);
            DescriptionBx.TabIndex = 11;
            DescriptionBx.Text = "";
            // 
            // ArtImage
            // 
            ArtImage.BackColor = System.Drawing.Color.Transparent;
            ArtImage.BackgroundImage = Properties.Resources.TL0_Dark;
            ArtImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ArtImage.Location = new System.Drawing.Point(0, 0);
            ArtImage.Name = "ArtImage";
            ArtImage.Size = new System.Drawing.Size(219, 166);
            ArtImage.TabIndex = 12;
            ArtImage.TabStop = false;
            // 
            // CRPolicy
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            Controls.Add(DescriptionBx);
            Controls.Add(BackgroundPnl);
            Controls.Add(ArtImage);
            Controls.Add(TitleLbl);
            DoubleBuffered = true;
            Name = "CRPolicy";
            Size = new System.Drawing.Size(970, 630);
            BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ArtImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel BackgroundPnl;
        private CRButton AcceptBtn;
        private CRButton DenyBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.RichTextBox DescriptionBx;
        private CRButton AltBtn;
        private System.Windows.Forms.PictureBox ArtImage;
    }
}
