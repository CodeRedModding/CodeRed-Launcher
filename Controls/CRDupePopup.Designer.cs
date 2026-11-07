namespace CodeRedLauncher.Controls
{
    partial class CRDupePopup
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
            ArtTLImg = new System.Windows.Forms.PictureBox();
            BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtTLImg).BeginInit();
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
            DescriptionLbl.TabIndex = 9;
            DescriptionLbl.Text = "It looks like you have another launcher open in the background, would you like to continue anyway or close this window?";
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
            TitleLbl.TabIndex = 8;
            TitleLbl.Text = "Already Running";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            BackgroundPnl.Controls.Add(DenyBtn);
            BackgroundPnl.Controls.Add(AcceptBtn);
            BackgroundPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            BackgroundPnl.Location = new System.Drawing.Point(0, 530);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(970, 100);
            BackgroundPnl.TabIndex = 10;
            // 
            // DenyBtn
            // 
            DenyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            DenyBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            DenyBtn.ButtonEnabled = true;
            DenyBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DenyBtn.DisplayText = "I forgot it was running...";
            DenyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DenyBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            DenyBtn.IconDark = Properties.Resources.No_White;
            DenyBtn.IconLight = Properties.Resources.Yes_White;
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
            AcceptBtn.DisplayText = "I know what I'm doing";
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
            // ArtTLImg
            // 
            ArtTLImg.BackColor = System.Drawing.Color.Transparent;
            ArtTLImg.BackgroundImage = Properties.Resources.TL2_Red;
            ArtTLImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ArtTLImg.Location = new System.Drawing.Point(0, 0);
            ArtTLImg.Name = "ArtTLImg";
            ArtTLImg.Size = new System.Drawing.Size(220, 182);
            ArtTLImg.TabIndex = 11;
            ArtTLImg.TabStop = false;
            // 
            // CRDupePopup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            Controls.Add(ArtTLImg);
            Controls.Add(BackgroundPnl);
            Controls.Add(DescriptionLbl);
            Controls.Add(TitleLbl);
            DoubleBuffered = true;
            Name = "CRDupePopup";
            Size = new System.Drawing.Size(970, 630);
            BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ArtTLImg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private CRButton DenyBtn;
        private CRButton AcceptBtn;
        private System.Windows.Forms.PictureBox ArtTLImg;
    }
}
