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
            ControlPnl = new System.Windows.Forms.Panel();
            DecrementBtn = new System.Windows.Forms.Label();
            IncrementBtn = new System.Windows.Forms.Label();
            BackgroundPnl = new System.Windows.Forms.Panel();
            InputBx = new System.Windows.Forms.NumericUpDown();
            ControlPnl.SuspendLayout();
            BackgroundPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InputBx).BeginInit();
            SuspendLayout();
            // 
            // ControlPnl
            // 
            ControlPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ControlPnl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            ControlPnl.Controls.Add(DecrementBtn);
            ControlPnl.Controls.Add(IncrementBtn);
            ControlPnl.Location = new System.Drawing.Point(171, 1);
            ControlPnl.Name = "ControlPnl";
            ControlPnl.Size = new System.Drawing.Size(28, 33);
            ControlPnl.TabIndex = 2;
            // 
            // DecrementBtn
            // 
            DecrementBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DecrementBtn.BackColor = System.Drawing.Color.Transparent;
            DecrementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            DecrementBtn.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DecrementBtn.Location = new System.Drawing.Point(0, 16);
            DecrementBtn.Name = "DecrementBtn";
            DecrementBtn.Size = new System.Drawing.Size(29, 16);
            DecrementBtn.TabIndex = 1;
            DecrementBtn.Text = "-";
            DecrementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DecrementBtn.Click += DecrementBtn_Click;
            DecrementBtn.DoubleClick += DecrementBtn_DoubleClick;
            // 
            // IncrementBtn
            // 
            IncrementBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            IncrementBtn.BackColor = System.Drawing.Color.Transparent;
            IncrementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            IncrementBtn.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IncrementBtn.Location = new System.Drawing.Point(0, 0);
            IncrementBtn.Name = "IncrementBtn";
            IncrementBtn.Size = new System.Drawing.Size(29, 16);
            IncrementBtn.TabIndex = 0;
            IncrementBtn.Text = "+";
            IncrementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            IncrementBtn.Click += IncrementBtn_Click;
            IncrementBtn.DoubleClick += IncrementBtn_DoubleClick;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            BackgroundPnl.Controls.Add(InputBx);
            BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(169, 33);
            BackgroundPnl.TabIndex = 1;
            // 
            // InputBx
            // 
            InputBx.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InputBx.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            InputBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            InputBx.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InputBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InputBx.Location = new System.Drawing.Point(3, 8);
            InputBx.Name = "InputBx";
            InputBx.Size = new System.Drawing.Size(192, 21);
            InputBx.TabIndex = 2;
            InputBx.ValueChanged += InputBx_ValueChanged;
            // 
            // CRNumberbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(128, 132, 142);
            Controls.Add(ControlPnl);
            Controls.Add(BackgroundPnl);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRNumberbox";
            Size = new System.Drawing.Size(200, 35);
            SizeChanged += CRNumberbox_SizeChanged;
            ControlPnl.ResumeLayout(false);
            BackgroundPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)InputBx).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel ControlPnl;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label IncrementBtn;
        private System.Windows.Forms.Label DecrementBtn;
        private System.Windows.Forms.NumericUpDown InputBx;
    }
}
