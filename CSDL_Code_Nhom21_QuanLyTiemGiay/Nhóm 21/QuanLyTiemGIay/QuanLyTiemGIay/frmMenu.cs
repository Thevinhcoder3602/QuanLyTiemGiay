using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QuanLyTiemGIay
{
    public partial class frmMenu : Form
    {
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();
        frmNhanVien fNhanVien = new frmNhanVien();
        frmSanPham fSanPham = new frmSanPham();
        frmKhachHang fKhachHang = new frmKhachHang();
        frmNCC fNCC = new frmNCC();
        frmLogin frmLogin = new frmLogin();
        
        frmThongKe fThongKe = new frmThongKe();
        frmTaiKhoan fTaiKhoan;
        frmHDBan fHDBan;
       
        public frmMenu(string email)
        {
            InitializeComponent();
            if (!bllNhanVien.getVaiTroNV(email))
            {
                btNhanVien.Visible = false;
                btThongKe.Visible = false;
                btNCC.Visible = false;
                
                btSanPham.Checked = true;
                fSanPham.TopLevel = false;
                fSanPham.Dock = DockStyle.Fill;
                gpBody.Controls.Add(fSanPham);
                fSanPham.Show();
            }
            else
            {
                btThongKe.Checked = true;
                fThongKe.TopLevel = false;
                fThongKe.Dock = DockStyle.Fill;
                gpBody.Controls.Add(fThongKe);
                fThongKe.Show();
            }
            fTaiKhoan = new frmTaiKhoan(email);
            fHDBan = new frmHDBan(email);
           
          
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btThongKe_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fThongKe.TopLevel = false;
            gpBody.Controls.Add(fThongKe);
            fThongKe.Dock = DockStyle.Fill;
            fThongKe.Show();
        }

        private void btSanPham_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fSanPham.TopLevel = false;
            gpBody.Controls.Add(fSanPham);
            fSanPham.Dock = DockStyle.Fill;
            fSanPham.Show();
        }

        private void btKhachHang_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fKhachHang.TopLevel = false;
            gpBody.Controls.Add(fKhachHang);
            fKhachHang.Dock = DockStyle.Fill;
            fKhachHang.Show();
        }

        private void btBanHang_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fHDBan.TopLevel = false;
            gpBody.Controls.Add(fHDBan);
            fHDBan.Dock = DockStyle.Fill;
            fHDBan.Show();
        }


        private void btTaiKhoan_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fTaiKhoan.TopLevel = false;
            gpBody.Controls.Add(fTaiKhoan);
            fTaiKhoan.Dock = DockStyle.Fill;
            fTaiKhoan.Show();
        }

        private void btNhanVien_Click_1(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fNhanVien.TopLevel = false;
            fNhanVien.Dock = DockStyle.Fill;
            gpBody.Controls.Add(fNhanVien);
            fNhanVien.Show();
        }
        private void btNCC_Click(object sender, EventArgs e)
        {
            gpBody.Controls.Clear();
            fNCC.TopLevel = false;
            fNCC.Dock = DockStyle.Fill;
            gpBody.Controls.Add(fNCC);
            fNCC.Show();
        }


        private void btDangXuat_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

            this.Hide();
            frmLogin.ShowDialog();
            this.Show();
        }
        

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OK);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
