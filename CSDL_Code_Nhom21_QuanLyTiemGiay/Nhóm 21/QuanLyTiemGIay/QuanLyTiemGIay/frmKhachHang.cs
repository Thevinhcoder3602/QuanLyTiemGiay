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
    public partial class frmKhachHang : Form
    {
        BLL_KhachHang bllKhachHang = new BLL_KhachHang();
        DTO_KhachHang dtoKhachHang;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void LamMoiGiaTri(bool param, bool isLoad)
        {
            txtMaKH.Text = null;
            txtMaKH.Enabled = !param;

            txtSDT.Text = null;
            txtDiaChi.Text = null;
            btThem.Enabled = param;
            txtHoTen.Text = null;
            if (isLoad)
            {
                btSua.Enabled = false;
                btXoa.Enabled = false;
            }
            else
            {
                btSua.Enabled = !param;
                btXoa.Enabled = !param;
            }
        }
        private void LoadGridView()
        {
            dgvKhachHang.Columns[0].HeaderText = "Mã KH";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Số điện thoại";
            foreach (DataGridViewColumn item in dgvKhachHang.Columns)
            {
                item.DividerWidth = 1;
            }
            dgvKhachHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvKhachHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = bllKhachHang.getKhachHang();
            LoadGridView();
            LamMoiGiaTri(true, false);
            txtHoTen.Focus();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 0)
            {
                btSua.Enabled = true;
                btXoa.Enabled = true;

                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            }
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

            string name = txtTimKiem.Text.Trim();
            if (name == "")
            {
                frmKhachHang_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
            {
                DataTable data = bllKhachHang.SearchKhachHang(txtTimKiem.Text);
                dgvKhachHang.DataSource = data;
            }
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {

            bool DungSDT = int.TryParse(txtSDT.Text, out int sdt);

            if (DungSDT && txtSDT.Text != "" && txtHoTen.Text != "")
            {
                dtoKhachHang = new DTO_KhachHang(txtHoTen.Text, txtDiaChi.Text, txtSDT.Text);
                if (bllKhachHang.InsertKhachHang(dtoKhachHang))
                {
                    MsgBox("Thêm khách hàng thành công!");
                    dgvKhachHang.DataSource = bllKhachHang.getKhachHang();
                    LoadGridView();
                    LamMoiGiaTri(true, false);
                }
                else
                    MsgBox("Thêm khách hàng không thành công", true);
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            bool DUNGSDT = int.TryParse(txtSDT.Text, out int num);

            if (DUNGSDT && txtSDT.Text != "" && txtHoTen.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtoKhachHang = new DTO_KhachHang(int.Parse(txtMaKH.Text), txtHoTen.Text, txtDiaChi.Text, txtSDT.Text);
                    if (bllKhachHang.UpdateKhachHang(dtoKhachHang))
                    {
                        MsgBox("Sửa khách hàng thành công!");
                        dgvKhachHang.DataSource = bllKhachHang.getKhachHang();
                        LoadGridView();
                        LamMoiGiaTri(true, false);
                    }
                    else
                        MsgBox("Sửa khách hàng không thành công", true);
                }
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bllKhachHang.DeleteKhachHang(int.Parse(txtMaKH.Text)))
                {
                    MsgBox("Xóa thành công");
                    dgvKhachHang.DataSource = bllKhachHang.getKhachHang();
                    LoadGridView();
                    LamMoiGiaTri(true, false);
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void btLamMoi_Click_1(object sender, EventArgs e)
        {
            LamMoiGiaTri(true, false);
        }
    }
}
