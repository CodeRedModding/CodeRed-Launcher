namespace CodeRedLauncher.Controls
{
    partial class CRTitleBar
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Label();
            this.MinimizeBtn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLbl.Location = new System.Drawing.Point(0, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(970, 30);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "CODERED LAUNCHER";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLbl_MouseMove);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.BackColor = System.Drawing.Color.Transparent;
            this.ExitBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitBtn.Location = new System.Drawing.Point(935, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(35, 30);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "x";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.ExitBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitBtn_MouseDown);
            this.ExitBtn.MouseEnter += new System.EventHandler(this.ExitBtn_MouseEnter);
            this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtn_MouseLeave);
            this.ExitBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExitBtn_MouseUp);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MinimizeBtn.Location = new System.Drawing.Point(900, 0);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(35, 30);
            this.MinimizeBtn.TabIndex = 2;
            this.MinimizeBtn.Text = "_";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseDown);
            this.MinimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtn_MouseEnter);
            this.MinimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtn_MouseLeave);
            this.MinimizeBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseUp);
            // 
            // CRTitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.TitleLbl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRTitleBar";
            this.Size = new System.Drawing.Size(970, 30);
            this.Load += new System.EventHandler(this.CRTitleBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label ExitBtn;
        private System.Windows.Forms.Label MinimizeBtn;
    }
}
