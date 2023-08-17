namespace QuanLyTiemGIay
{
    partial class frmHDBan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiemHDBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvHDBan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btTaoHD = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(310, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 46);
            this.label1.TabIndex = 19;
            this.label1.Text = "DANH SÁCH HÓA ĐƠN BÁN";
            // 
            // txtTimKiemHDBan
            // 
            this.txtTimKiemHDBan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.txtTimKiemHDBan.BorderRadius = 6;
            this.txtTimKiemHDBan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemHDBan.DefaultText = "";
            this.txtTimKiemHDBan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemHDBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemHDBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemHDBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemHDBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemHDBan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiemHDBan.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiemHDBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemHDBan.Location = new System.Drawing.Point(169, 147);
            this.txtTimKiemHDBan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTimKiemHDBan.Name = "txtTimKiemHDBan";
            this.txtTimKiemHDBan.PasswordChar = '\0';
            this.txtTimKiemHDBan.PlaceholderText = "Tìm kiếm hóa đơn bán";
            this.txtTimKiemHDBan.SelectedText = "";
            this.txtTimKiemHDBan.Size = new System.Drawing.Size(539, 60);
            this.txtTimKiemHDBan.TabIndex = 1;
            this.txtTimKiemHDBan.TextChanged += new System.EventHandler(this.txtTimKiemHDN_TextChanged);
            // 
            // dgvHDBan
            // 
            this.dgvHDBan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvHDBan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDBan.ColumnHeadersHeight = 20;
            this.dgvHDBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHDBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHDBan.Location = new System.Drawing.Point(2, 314);
            this.dgvHDBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvHDBan.Name = "dgvHDBan";
            this.dgvHDBan.RowHeadersVisible = false;
            this.dgvHDBan.RowHeadersWidth = 51;
            this.dgvHDBan.RowTemplate.Height = 24;
            this.dgvHDBan.Size = new System.Drawing.Size(1003, 581);
            this.dgvHDBan.TabIndex = 16;
            this.dgvHDBan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHDBan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHDBan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHDBan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHDBan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHDBan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHDBan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHDBan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHDBan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHDBan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvHDBan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHDBan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHDBan.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvHDBan.ThemeStyle.ReadOnly = false;
            this.dgvHDBan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHDBan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHDBan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvHDBan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHDBan.ThemeStyle.RowsStyle.Height = 24;
            this.dgvHDBan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHDBan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btTaoHD
            // 
            this.btTaoHD.BorderRadius = 10;
            this.btTaoHD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btTaoHD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btTaoHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btTaoHD.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btTaoHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btTaoHD.FillColor = System.Drawing.Color.HotPink;
            this.btTaoHD.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btTaoHD.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btTaoHD.ForeColor = System.Drawing.Color.Black;
            this.btTaoHD.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btTaoHD.Location = new System.Drawing.Point(758, 131);
            this.btTaoHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btTaoHD.Name = "btTaoHD";
            this.btTaoHD.Size = new System.Drawing.Size(189, 90);
            this.btTaoHD.TabIndex = 2;
            this.btTaoHD.Text = "Tạo hóa đơn";
            this.btTaoHD.Click += new System.EventHandler(this.btTaoHD_Click);
            // 
            // frmHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1008, 892);
            this.Controls.Add(this.btTaoHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiemHDBan);
            this.Controls.Add(this.dgvHDBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHDBan";
            this.Text = "frmHDBan";
            this.Load += new System.EventHandler(this.frmHDBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemHDBan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHDBan;
        private Guna.UI2.WinForms.Guna2GradientButton btTaoHD;
    }
}