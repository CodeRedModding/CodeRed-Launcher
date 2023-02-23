namespace CodeRedLauncher.Controls
{
    partial class CRPopup
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
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.DoublePnl = new System.Windows.Forms.Panel();
            this.DoubleSecondBtn = new CodeRedLauncher.Controls.CRButton();
            this.DoubleFirstBtn = new CodeRedLauncher.Controls.CRButton();
            this.SinglePnl = new System.Windows.Forms.Panel();
            this.SingleBtn = new CodeRedLauncher.Controls.CRButton();
            this.BackgroundPnl.SuspendLayout();
            this.DoublePnl.SuspendLayout();
            this.SinglePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BackgroundPnl.Controls.Add(this.DescriptionLbl);
            this.BackgroundPnl.Controls.Add(this.TitleLbl);
            this.BackgroundPnl.Controls.Add(this.DoublePnl);
            this.BackgroundPnl.Controls.Add(this.SinglePnl);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(968, 628);
            this.BackgroundPnl.TabIndex = 0;
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DescriptionLbl.Location = new System.Drawing.Point(186, 190);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(600, 225);
            this.DescriptionLbl.TabIndex = 2;
            this.DescriptionLbl.Text = "Description";
            this.DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.Location = new System.Drawing.Point(186, 140);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(600, 50);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoublePnl
            // 
            this.DoublePnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoublePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.DoublePnl.Controls.Add(this.DoubleSecondBtn);
            this.DoublePnl.Controls.Add(this.DoubleFirstBtn);
            this.DoublePnl.Location = new System.Drawing.Point(0, 543);
            this.DoublePnl.Name = "DoublePnl";
            this.DoublePnl.Size = new System.Drawing.Size(968, 85);
            this.DoublePnl.TabIndex = 4;
            this.DoublePnl.Visible = false;
            // 
            // DoubleSecondBtn
            // 
            this.DoubleSecondBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoubleSecondBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.DoubleSecondBtn.ButtonEnabled = true;
            this.DoubleSecondBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DoubleSecondBtn.DisplayImage = null;
            this.DoubleSecondBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_LIGHT;
            this.DoubleSecondBtn.DisplayText = "Second Option";
            this.DoubleSecondBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DoubleSecondBtn.Location = new System.Drawing.Point(506, 23);
            this.DoubleSecondBtn.Name = "DoubleSecondBtn";
            this.DoubleSecondBtn.Size = new System.Drawing.Size(285, 40);
            this.DoubleSecondBtn.TabIndex = 1;
            this.DoubleSecondBtn.OnButtonClick += new System.EventHandler(this.DoubleSecondBtn_OnButtonClick);
            // 
            // DoubleFirstBtn
            // 
            this.DoubleFirstBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DoubleFirstBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.DoubleFirstBtn.ButtonEnabled = true;
            this.DoubleFirstBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DoubleFirstBtn.DisplayImage = null;
            this.DoubleFirstBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_LIGHT;
            this.DoubleFirstBtn.DisplayText = "First Option";
            this.DoubleFirstBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DoubleFirstBtn.Location = new System.Drawing.Point(181, 23);
            this.DoubleFirstBtn.Name = "DoubleFirstBtn";
            this.DoubleFirstBtn.Size = new System.Drawing.Size(285, 40);
            this.DoubleFirstBtn.TabIndex = 0;
            this.DoubleFirstBtn.OnButtonClick += new System.EventHandler(this.DoubleFirstBtn_OnButtonClick);
            // 
            // SinglePnl
            // 
            this.SinglePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SinglePnl.Controls.Add(this.SingleBtn);
            this.SinglePnl.Location = new System.Drawing.Point(0, 543);
            this.SinglePnl.Name = "SinglePnl";
            this.SinglePnl.Size = new System.Drawing.Size(968, 85);
            this.SinglePnl.TabIndex = 3;
            // 
            // SingleBtn
            // 
            this.SingleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.SingleBtn.ButtonEnabled = true;
            this.SingleBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SingleBtn.DisplayImage = null;
            this.SingleBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_LIGHT;
            this.SingleBtn.DisplayText = "Single Option";
            this.SingleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SingleBtn.Location = new System.Drawing.Point(341, 23);
            this.SingleBtn.Name = "SingleBtn";
            this.SingleBtn.Size = new System.Drawing.Size(285, 40);
            this.SingleBtn.TabIndex = 0;
            this.SingleBtn.OnButtonClick += new System.EventHandler(this.SingleBtn_OnButtonClick);
            // 
            // CRPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRPopup";
            this.Size = new System.Drawing.Size(970, 630);
            this.BackgroundPnl.ResumeLayout(false);
            this.DoublePnl.ResumeLayout(false);
            this.SinglePnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Panel SinglePnl;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Label TitleLbl;
        private CRButton SingleBtn;
        private System.Windows.Forms.Panel DoublePnl;
        private CRButton DoubleSecondBtn;
        private CRButton DoubleFirstBtn;
    }
}
