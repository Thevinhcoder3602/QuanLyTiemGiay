namespace QuanLyTiemGIay
{
    partial class SendMail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMail));
            this.ptbAnhLoad = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnhLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbAnhLoad
            // 
            this.ptbAnhLoad.Image = ((System.Drawing.Image)(resources.GetObject("ptbAnhLoad.Image")));
            this.ptbAnhLoad.ImageRotate = 0F;
            this.ptbAnhLoad.Location = new System.Drawing.Point(-27, 1);
            this.ptbAnhLoad.Name = "ptbAnhLoad";
            this.ptbAnhLoad.Size = new System.Drawing.Size(340, 200);
            this.ptbAnhLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbAnhLoad.TabIndex = 0;
            this.ptbAnhLoad.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chờ xíu nha!!!";
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptbAnhLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMail";
            this.Load += new System.EventHandler(this.SendMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnhLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptbAnhLoad;
        private System.Windows.Forms.Label label1;
    }
}