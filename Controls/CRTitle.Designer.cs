namespace CodeRedLauncher.Controls
{
    partial class CRTitle
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
            TitleLbl = new System.Windows.Forms.Label();
            ExitBtn = new System.Windows.Forms.Label();
            MinimizeBtn = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // TitleLbl
            // 
            TitleLbl.BackColor = System.Drawing.Color.Transparent;
            TitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            TitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLbl.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TitleLbl.Location = new System.Drawing.Point(0, 0);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new System.Drawing.Size(970, 30);
            TitleLbl.TabIndex = 0;
            TitleLbl.Text = "CODERED LAUNCHER";
            TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            TitleLbl.MouseMove += TitleLbl_MouseMove;
            // 
            // ExitBtn
            // 
            ExitBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ExitBtn.BackColor = System.Drawing.Color.Transparent;
            ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            ExitBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ExitBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            ExitBtn.Location = new System.Drawing.Point(935, 0);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new System.Drawing.Size(35, 30);
            ExitBtn.TabIndex = 1;
            ExitBtn.Text = "x";
            ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ExitBtn.Click += ExitBtn_Click;
            ExitBtn.DoubleClick += ExitBtn_DoubleClick;
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            MinimizeBtn.BackColor = System.Drawing.Color.Transparent;
            MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            MinimizeBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            MinimizeBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            MinimizeBtn.Location = new System.Drawing.Point(900, 0);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.Size = new System.Drawing.Size(35, 30);
            MinimizeBtn.TabIndex = 2;
            MinimizeBtn.Text = "_";
            MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MinimizeBtn.Click += MinimizeBtn_Click;
            MinimizeBtn.DoubleClick += MinimizeBtn_DoubleClick;
            // 
            // CRTitleBar
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            Controls.Add(MinimizeBtn);
            Controls.Add(ExitBtn);
            Controls.Add(TitleLbl);
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRTitleBar";
            Size = new System.Drawing.Size(970, 30);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label ExitBtn;
        private System.Windows.Forms.Label MinimizeBtn;
    }
}
