namespace CodeRedLauncher.Controls
{
    partial class CRCountdown
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
            this.TimerLbl = new System.Windows.Forms.Label();
            this.TimerImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimerImg)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerLbl
            // 
            this.TimerLbl.BackColor = System.Drawing.Color.Transparent;
            this.TimerLbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimerLbl.Location = new System.Drawing.Point(0, 0);
            this.TimerLbl.Name = "TimerLbl";
            this.TimerLbl.Size = new System.Drawing.Size(128, 93);
            this.TimerLbl.TabIndex = 45;
            this.TimerLbl.Text = "0";
            this.TimerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerImg
            // 
            this.TimerImg.BackColor = System.Drawing.Color.Transparent;
            this.TimerImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Hourglass_White;
            this.TimerImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TimerImg.Location = new System.Drawing.Point(0, 93);
            this.TimerImg.Name = "TimerImg";
            this.TimerImg.Size = new System.Drawing.Size(128, 35);
            this.TimerImg.TabIndex = 46;
            this.TimerImg.TabStop = false;
            // 
            // CRCountdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.TimerImg);
            this.Controls.Add(this.TimerLbl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Name = "CRCountdown";
            this.Size = new System.Drawing.Size(128, 128);
            ((System.ComponentModel.ISupportInitialize)(this.TimerImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TimerLbl;
        private System.Windows.Forms.PictureBox TimerImg;
    }
}
