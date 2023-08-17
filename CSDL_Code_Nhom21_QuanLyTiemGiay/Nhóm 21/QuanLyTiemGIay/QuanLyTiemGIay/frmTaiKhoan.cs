using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;
using DTO;

namespace QuanLyTiemGIay
{
    public partial class frmTaiKhoan : Form
    {
        BLL_NhanVien bllNhanVien  = new BLL_NhanVien();
        DTO_NhanVien dtoNhanVien;
        private string email, str;
        private char separator = '|';
        private string[] strlist;
        public frmTaiKhoan(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void LoadData()
        {
            str =bllNhanVien.getMaNV(email);
            strlist = str.Split(separator);
            txtHoTen.Text = strlist[1].Trim();

            str = bllNhanVien.get_DiaChi_SDT_NhanVien(email);
            strlist = str.Split(separator);
            txtDiaChi.Text = strlist[0].Trim();
            txtSDT.Text = strlist[1].Trim();

            txtEmail.Text = email;
        }


        private void btSua_Click_1(object sender, EventArgs e)
        {
            dtoNhanVien = new DTO_NhanVien(txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
            if (bllNhanVien.Update_DiaChi_SDT_NhanVien(dtoNhanVien))
            {
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            if (txtmMKCu.Text != "")
            {
                if (txtMKMoi.Text == txtNhapLaiMKMoi.Text)
                {
                    bllNhanVien = new BLL_NhanVien();
                    if (bllNhanVien.ChangeMatKhau(txtEmail.Text, txtmMKCu.Text, txtMKMoi.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.MK = "";
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
