namespace CodeRedLauncher.Controls
{
    partial class CRMessagebox
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
            this.ButtonPnl = new System.Windows.Forms.Panel();
            this.SecondOptionBtn = new CodeRedLauncher.Controls.CRButton();
            this.FirstOptionBtn = new CodeRedLauncher.Controls.CRButton();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.IconImg = new System.Windows.Forms.PictureBox();
            this.BackgroundPnl.SuspendLayout();
            this.ButtonPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconImg)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.BackgroundPnl.Controls.Add(this.DescriptionLbl);
            this.BackgroundPnl.Controls.Add(this.ButtonPnl);
            this.BackgroundPnl.Controls.Add(this.TitleLbl);
            this.BackgroundPnl.Controls.Add(this.IconImg);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(373, 148);
            this.BackgroundPnl.TabIndex = 0;
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DescriptionLbl.Location = new System.Drawing.Point(75, 55);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(275, 35);
            this.DescriptionLbl.TabIndex = 3;
            this.DescriptionLbl.Text = "Description";
            this.DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonPnl
            // 
            this.ButtonPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ButtonPnl.Controls.Add(this.SecondOptionBtn);
            this.ButtonPnl.Controls.Add(this.FirstOptionBtn);
            this.ButtonPnl.Location = new System.Drawing.Point(0, 103);
            this.ButtonPnl.Name = "ButtonPnl";
            this.ButtonPnl.Size = new System.Drawing.Size(373, 45);
            this.ButtonPnl.TabIndex = 2;
            // 
            // SecondOptionBtn
            // 
            this.SecondOptionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.SecondOptionBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SecondOptionBtn.DisplayImage = null;
            this.SecondOptionBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_LIGHT;
            this.SecondOptionBtn.DisplayText = "Second Option";
            this.SecondOptionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SecondOptionBtn.Location = new System.Drawing.Point(200, 9);
            this.SecondOptionBtn.Name = "SecondOptionBtn";
            this.SecondOptionBtn.Size = new System.Drawing.Size(150, 28);
            this.SecondOptionBtn.TabIndex = 1;
            this.SecondOptionBtn.OnButtonClick += new System.EventHandler(this.SecondOptionBtn_OnButtonClick);
            // 
            // FirstOptionBtn
            // 
            this.FirstOptionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.FirstOptionBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FirstOptionBtn.DisplayImage = null;
            this.FirstOptionBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_LIGHT;
            this.FirstOptionBtn.DisplayText = "First Option";
            this.FirstOptionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FirstOptionBtn.Location = new System.Drawing.Point(20, 9);
            this.FirstOptionBtn.Name = "FirstOptionBtn";
            this.FirstOptionBtn.Size = new System.Drawing.Size(150, 28);
            this.FirstOptionBtn.TabIndex = 0;
            this.FirstOptionBtn.OnButtonClick += new System.EventHandler(this.FirstOptionBtn_OnButtonClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.Location = new System.Drawing.Point(75, 20);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(275, 35);
            this.TitleLbl.TabIndex = 1;
            this.TitleLbl.Text = "Title";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconImg
            // 
            this.IconImg.BackColor = System.Drawing.Color.Transparent;
            this.IconImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.About_White;
            this.IconImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.IconImg.Location = new System.Drawing.Point(20, 30);
            this.IconImg.Name = "IconImg";
            this.IconImg.Size = new System.Drawing.Size(50, 50);
            this.IconImg.TabIndex = 0;
            this.IconImg.TabStop = false;
            // 
            // CRMessagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRMessagebox";
            this.Size = new System.Drawing.Size(375, 150);
            this.BackgroundPnl.ResumeLayout(false);
            this.ButtonPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.PictureBox IconImg;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel ButtonPnl;
        private System.Windows.Forms.Label DescriptionLbl;
        private CRButton SecondOptionBtn;
        private CRButton FirstOptionBtn;
    }
}
