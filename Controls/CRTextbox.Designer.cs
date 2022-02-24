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
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.InputBx = new System.Windows.Forms.TextBox();
            this.BackgroundPnl.SuspendLayout();
            this.SuspendLayout();
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
            this.BackgroundPnl.Size = new System.Drawing.Size(173, 28);
            this.BackgroundPnl.TabIndex = 0;
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
            this.InputBx.Location = new System.Drawing.Point(2, 5);
            this.InputBx.Multiline = true;
            this.InputBx.Name = "InputBx";
            this.InputBx.Size = new System.Drawing.Size(169, 18);
            this.InputBx.TabIndex = 0;
            this.InputBx.Text = "Textbox";
            this.InputBx.TextChanged += new System.EventHandler(this.InputBx_TextChanged);
            // 
            // CRTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BackgroundPnl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRTextbox";
            this.Size = new System.Drawing.Size(175, 30);
            this.BackgroundPnl.ResumeLayout(false);
            this.BackgroundPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.TextBox InputBx;
    }
}
