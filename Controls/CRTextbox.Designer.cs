namespace CodeRedLauncher.Controls
{
    partial class CRTextbox
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
            InputBx = new System.Windows.Forms.TextBox();
            BackgroundPnl = new System.Windows.Forms.Panel();
            BackgroundPnl.SuspendLayout();
            SuspendLayout();
            // 
            // InputBx
            // 
            InputBx.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InputBx.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            InputBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            InputBx.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InputBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InputBx.Location = new System.Drawing.Point(4, 8);
            InputBx.Name = "InputBx";
            InputBx.Size = new System.Drawing.Size(190, 18);
            InputBx.TabIndex = 0;
            InputBx.Text = "textbox";
            InputBx.WordWrap = false;
            InputBx.TextChanged += InputBx_TextChanged;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            BackgroundPnl.Controls.Add(InputBx);
            BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(198, 33);
            BackgroundPnl.TabIndex = 0;
            // 
            // CRTextbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(128, 132, 142);
            Controls.Add(BackgroundPnl);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            Name = "CRTextbox";
            Size = new System.Drawing.Size(200, 35);
            SizeChanged += CRTextbox_SizeChanged;
            BackgroundPnl.ResumeLayout(false);
            BackgroundPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox InputBx;
        private System.Windows.Forms.Panel BackgroundPnl;
    }
}
