using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemGIay
{
    public partial class frmLogin : Form
    {
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();

        public frmLogin()
        {
            InitializeComponent();
        }
        private void btDangNhap_Click_1(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtMatKhau.Text != "")
            {
                if (bllNhanVien.DangNhap(txtEmail.Text, txtMatKhau.Text))
                {
                    Properties.Settings.Default.isSave = gtNhoMatKhau.Checked;
                    if (gtNhoMatKhau.Checked)
                    {
                        Properties.Settings.Default.Email = txtEmail.Text;
                        Properties.Settings.Default.MK = txtMatKhau.Text;
                    }
                    Properties.Settings.Default.Save();
                    frmMenu fMain = new frmMenu(txtEmail.Text);
                    this.Hide();
                    fMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtMatKhau.Text = "";
                    txtEmail.Focus();
                }
            }
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isSave)
            {
                txtEmail.Text = Properties.Settings.Default.Email;
                txtMatKhau.Text = Properties.Settings.Default.MK;
                gtNhoMatKhau.Checked = true;
            }
        }

        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                bllNhanVien = new BLL_NhanVien();
                if (bllNhanVien.KiemTraEmail(txtEmail.Text))
                {
                    string password = bllNhanVien.GetRandomPassword();
                    if (bllNhanVien.UpdateMatKhau(txtEmail.Text, password))
                    {
                        SendMail loader = new SendMail(txtEmail.Text, password, true);
                        loader.ShowDialog();
                        MessageBox.Show(loader.Result, "Thông báo");
                    }
                    else
                        MessageBox.Show("Không thực hiện được", "Thông báo");
                }
            }
        }



        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
