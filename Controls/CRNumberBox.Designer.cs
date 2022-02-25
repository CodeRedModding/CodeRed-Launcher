namespace CodeRedLauncher.Controls
{
    partial class CRNumberbox
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
            this.ControlPnl = new System.Windows.Forms.Panel();
            this.DecrementBtn = new System.Windows.Forms.Label();
            this.IncrementBtn = new System.Windows.Forms.Label();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.InputBx = new System.Windows.Forms.NumericUpDown();
            this.ControlPnl.SuspendLayout();
            this.BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputBx)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPnl
            // 
            this.ControlPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ControlPnl.Controls.Add(this.DecrementBtn);
            this.ControlPnl.Controls.Add(this.IncrementBtn);
            this.ControlPnl.Location = new System.Drawing.Point(146, 1);
            this.ControlPnl.Name = "ControlPnl";
            this.ControlPnl.Size = new System.Drawing.Size(28, 27);
            this.ControlPnl.TabIndex = 2;
            // 
            // DecrementBtn
            // 
            this.DecrementBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.DecrementBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DecrementBtn.Location = new System.Drawing.Point(1, 14);
            this.DecrementBtn.Name = "DecrementBtn";
            this.DecrementBtn.Size = new System.Drawing.Size(26, 12);
            this.DecrementBtn.TabIndex = 1;
            this.DecrementBtn.Text = "-";
            this.DecrementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecrementBtn.Click += new System.EventHandler(this.DecrementBtn_Click);
            this.DecrementBtn.DoubleClick += new System.EventHandler(this.DecrementBtn_DoubleClick);
            this.DecrementBtn.MouseEnter += new System.EventHandler(this.DecrementBtn_MouseEnter);
            this.DecrementBtn.MouseLeave += new System.EventHandler(this.DecrementBtn_MouseLeave);
            // 
            // IncrementBtn
            // 
            this.IncrementBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.IncrementBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IncrementBtn.Location = new System.Drawing.Point(1, 1);
            this.IncrementBtn.Name = "IncrementBtn";
            this.IncrementBtn.Size = new System.Drawing.Size(26, 12);
            this.IncrementBtn.TabIndex = 0;
            this.IncrementBtn.Text = "+";
            this.IncrementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IncrementBtn.Click += new System.EventHandler(this.IncrementBtn_Click);
            this.IncrementBtn.DoubleClick += new System.EventHandler(this.IncrementBtn_DoubleClick);
            this.IncrementBtn.MouseEnter += new System.EventHandler(this.IncrementBtn_MouseEnter);
            this.IncrementBtn.MouseLeave += new System.EventHandler(this.IncrementBtn_MouseLeave);
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundPnl.Controls.Add(this.InputBx);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(144, 27);
            this.BackgroundPnl.TabIndex = 1;
            // 
            // InputBx
            // 
            this.InputBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.InputBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputBx.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InputBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InputBx.Location = new System.Drawing.Point(8, 4);
            this.InputBx.Name = "InputBx";
            this.InputBx.Size = new System.Drawing.Size(152, 21);
            this.InputBx.TabIndex = 2;
            this.InputBx.ValueChanged += new System.EventHandler(this.InputBx_ValueChanged);
            // 
            // CRNumberbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.ControlPnl);
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRNumberbox";
            this.Size = new System.Drawing.Size(175, 29);
            this.ControlPnl.ResumeLayout(false);
            this.BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ControlPnl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label IncrementBtn;
        private System.Windows.Forms.Label DecrementBtn;
        private System.Windows.Forms.NumericUpDown InputBx;
    }
}
