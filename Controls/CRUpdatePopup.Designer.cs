namespace CodeRedLauncher.Controls
{
    partial class CRUpdatePopup
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
            DescriptionLbl = new System.Windows.Forms.Label();
            TitleLbl = new System.Windows.Forms.Label();
            BackgroundPnl = new System.Windows.Forms.Panel();
            DenyBtn = new CRButton();
            AcceptBtn = new CRButton();
            AltBtn = new CRButton();
            ArtImage = new System.Windows.Forms.PictureBox();
            BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtImage).BeginInit();
            SuspendLayout();
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            DescriptionLbl.ForeColor = System.Drawing.Color.White;
            DescriptionLbl.Location = new System.Drawing.Point(55, 230);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new System.Drawing.Size(850, 250);
            DescriptionLbl.TabIndex = 4;
            DescriptionLbl.Text = "A new version of the module was found, would you like to automatically install it now?";
            DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            TitleLbl.ForeColor = System.Drawing.Color.White;
            TitleLbl.Location = new System.Drawing.Point(210, 150);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(550, 80);
            TitleLbl.TabIndex = 3;
            TitleLbl.Text = "Update Available";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            BackgroundPnl.Controls.Add(DenyBtn);
            BackgroundPnl.Controls.Add(AcceptBtn);
            BackgroundPnl.Controls.Add(AltBtn);
            BackgroundPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            BackgroundPnl.Location = new System.Drawing.Point(0, 530);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(970, 100);
            BackgroundPnl.TabIndex = 5;
            // 
            // DenyBtn
            // 
            DenyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            DenyBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            DenyBtn.ButtonEnabled = true;
            DenyBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DenyBtn.DisplayText = "Nah, I'm not really feeling it";
            DenyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DenyBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            DenyBtn.IconDark = Properties.Resources.No_White;
            DenyBtn.IconLight = Properties.Resources.No_White;
            DenyBtn.Location = new System.Drawing.Point(520, 35);
            DenyBtn.Name = "DenyBtn";
            DenyBtn.Size = new System.Drawing.Size(300, 40);
            DenyBtn.TabIndex = 1;
            DenyBtn.Theme = ControlTheme.Dark;
            DenyBtn.OnButtonClick += DenyBtn_OnButtonClick;
            // 
            // AcceptBtn
            // 
            AcceptBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            AcceptBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            AcceptBtn.ButtonEnabled = true;
            AcceptBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AcceptBtn.DisplayText = "Yeah sure, sounds good";
            AcceptBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AcceptBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            AcceptBtn.IconDark = Properties.Resources.Yes_White;
            AcceptBtn.IconLight = Properties.Resources.Yes_White;
            AcceptBtn.Location = new System.Drawing.Point(150, 35);
            AcceptBtn.Name = "AcceptBtn";
            AcceptBtn.Size = new System.Drawing.Size(300, 40);
            AcceptBtn.TabIndex = 0;
            AcceptBtn.Theme = ControlTheme.Dark;
            AcceptBtn.OnButtonClick += AcceptBtn_OnButtonClick;
            // 
            // AltBtn
            // 
            AltBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            AltBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            AltBtn.ButtonEnabled = true;
            AltBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AltBtn.DisplayText = "Okay fine, I'll close the game";
            AltBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AltBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            AltBtn.IconDark = Properties.Resources.Yes_White;
            AltBtn.IconLight = Properties.Resources.Yes_White;
            AltBtn.Location = new System.Drawing.Point(335, 35);
            AltBtn.Name = "AltBtn";
            AltBtn.Size = new System.Drawing.Size(300, 40);
            AltBtn.TabIndex = 7;
            AltBtn.Theme = ControlTheme.Dark;
            AltBtn.Visible = false;
            AltBtn.OnButtonClick += AltBtn_OnButtonClick;
            // 
            // ArtImage
            // 
            ArtImage.BackColor = System.Drawing.Color.Transparent;
            ArtImage.BackgroundImage = Properties.Resources.TL0_Dark;
            ArtImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ArtImage.Location = new System.Drawing.Point(0, 0);
            ArtImage.Name = "ArtImage";
            ArtImage.Size = new System.Drawing.Size(219, 166);
            ArtImage.TabIndex = 13;
            ArtImage.TabStop = false;
            // 
            // CRUpdatePopup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            Controls.Add(ArtImage);
            Controls.Add(BackgroundPnl);
            Controls.Add(DescriptionLbl);
            Controls.Add(TitleLbl);
            DoubleBuffered = true;
            Name = "CRUpdatePopup";
            Size = new System.Drawing.Size(970, 630);
            BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ArtImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private CRButton AcceptBtn;
        private CRButton DenyBtn;
        private CRButton AltBtn;
        private System.Windows.Forms.PictureBox ArtImage;
    }
}
