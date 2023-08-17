using BLL;
using DTO;
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
    public partial class frmCTHDBan : Form
    {
        BLL_KhachHang bllKhachHang = new BLL_KhachHang();
        BLL_SanPham bllSanPham = new BLL_SanPham();
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();
        BLL_CTHDBan bllCTHDBan = new BLL_CTHDBan();
        BLL_HDBan bllHDBan = new BLL_HDBan();
        DTO_CTHDBan dtoCTHDBan;
        DTO_HDBan dtoHDBan;
        private string[] listMa_KH, list_Ten_SL_SP;
        private DateTime dateTime = new DateTime();
        private string tenSP, email, str;
        private char separator = '|';
        private string[] strlist;
        public frmCTHDBan(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void LoadData()
        {
            listMa_KH = bllKhachHang.List_MaKH();
            cbKH.Items.Clear();
            foreach (string item in listMa_KH)
            {
                cbKH.Items.Add(item);
            }

            dateTime = DateTime.Now;
            txtThoiGian.Text = dateTime.ToString("dd/MM/yyyy") + " " + dateTime.ToString("HH:mm");

            list_Ten_SL_SP = bllSanPham.DanhSachTen_SL();
            cbSP.Items.Clear();
            foreach (string item in list_Ten_SL_SP)
            {
                cbSP.Items.Add(item);
            }

            txtNV.Text = bllNhanVien.getMaNV(email);
        }

        

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadGridView()
        {
            dgvCTHDBan.Columns[0].HeaderText = "Mã SP";
            dgvCTHDBan.Columns[1].HeaderText = "Tên SP";
            dgvCTHDBan.Columns[2].HeaderText = "Số lượng";
            dgvCTHDBan.Columns[3].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn item in dgvCTHDBan.Columns)
            {
                item.DividerWidth = 1;
            }
            dgvCTHDBan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTHDBan.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTHDBan.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
       
        private void btThem_Click_1(object sender, EventArgs e)
        {
            str = cbSP.SelectedItem.ToString();
            strlist = str.Split(separator);
            tenSP = strlist[0].Trim();

            if (txtSoLuong.Text != "" && cbKH.SelectedIndex != -1 &&
                cbSP.SelectedIndex != -1)
            {
                dtoCTHDBan = new DTO_CTHDBan
                (
                    bllSanPham.getMaSP(tenSP),
                    int.Parse(txtSoLuong.Text),
                    double.Parse(txtGia.Text)
                );
                if (bllCTHDBan.Insert_CTHDBan(dtoCTHDBan, int.Parse(txtSoLuong.Text)))
                {
                    dgvCTHDBan.DataSource = bllCTHDBan.List_CTHDBan();
                    LoadGridView();
                    txtThanhTien.Text = bllCTHDBan.TongGiaBan().ToString();
                }
                else
                    MsgBox("Thêm không thành công", true);
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            int maSP = bllSanPham.getMaSP(tenSP);
            str = cbSP.SelectedItem.ToString();
            strlist = str.Split(separator);
            if (bllCTHDBan.Update_SP_CTHDBan(maSP, int.Parse(txtSoLuong.Text)))
            {
                dgvCTHDBan.DataSource = bllCTHDBan.List_CTHDBan();
                LoadGridView();
                txtThanhTien.Text = bllCTHDBan.TongGiaBan().ToString();
                MsgBox("Sửa sản phẩm thành công!");
            }
            else
            {
                MsgBox("Sửa sản phẩm không được", true);
            }
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            int maSP = bllSanPham.getMaSP(tenSP);
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bllCTHDBan.Delete_SP_CTHDBan(maSP))
                {
                    MsgBox("Xóa thành công");
                    LoadData();
                    dgvCTHDBan.DataSource = bllCTHDBan.List_CTHDBan();
                    LoadGridView();
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void btThanhToan_Click_1(object sender, EventArgs e)
        {

            str = txtNV.Text;
            strlist = str.Split(separator);
            string maNV = strlist[0].Trim();

            str = cbKH.SelectedItem.ToString();
            strlist = str.Split(separator);
            string maKH = strlist[0].Trim();

            dtoHDBan = new DTO_HDBan
            (
                int.Parse(maNV),
                int.Parse(maKH),
                double.Parse(txtThanhTien.Text)
            );
            if (bllHDBan.Insert_HDBan(dtoHDBan))
            {
                this.Close();
            }
            else
                MsgBox("Thanh toán không thành công", true);
        }

        private void btLamMoi_Click_1(object sender, EventArgs e)
        {
            txtSoLuong.Text = null;
            txtGia.Text = null;
            txtThanhTien.Text = null;

            LoadData();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cbSP.SelectedItem.ToString();
            char separator = '|';
            String[] strlist = str.Split(separator);
            tenSP = strlist[0].Trim();
            txtGia.Text = bllSanPham.GetGiaBanSP(tenSP).ToString();

        }
        
        private void frmCTHDBan_Load(object sender, EventArgs e)
        {
            txtSoLuong.Text = null;
            txtGia.Text = null;
            txtThanhTien.Text = null;
            LoadData();
            dgvCTHDBan.DataSource = bllCTHDBan.List_CTHDBan();
            LoadGridView();
        }
    }
}
