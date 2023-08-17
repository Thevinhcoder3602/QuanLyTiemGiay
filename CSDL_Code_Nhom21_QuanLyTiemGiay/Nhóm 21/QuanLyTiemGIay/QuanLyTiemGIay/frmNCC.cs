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
    public partial class frmNCC : Form
    {
        BLL_NhaCC bllNhaCC = new BLL_NhaCC();
        DTO_NhaCC dtoNhaCC;

        public frmNCC()
        {
            InitializeComponent();
        }
        private void LamMoiGiaTri(bool param, bool isLoad)
        {
            txtMaNCC.Text = null;
            txtMaNCC.Enabled = !param;

            txtSDT.Text = null;
            txtDiaChi.Text = null;
            btThem.Enabled = param;
            txtTenNCC.Text = null;
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
            dgvNCC.Columns[0].HeaderText = "Mã NCC";
            dgvNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNCC.Columns[3].HeaderText = "Số điện thoại";
            foreach (DataGridViewColumn item in dgvNCC.Columns)
            {
                item.DividerWidth = 1;
            }
            dgvNCC.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvNCC.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

            }
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNCC.Rows.Count > 0)
            {
                btSua.Enabled = true;
                btXoa.Enabled = true;

                txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
            }

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tenNCC = txtTimKiem.Text.Trim();
            if (tenNCC == "")
            {
                frmNCC_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
            {
                DataTable data = bllNhaCC.SearchNhaCC(txtTimKiem.Text);
                dgvNCC.DataSource = data;
            }

        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = bllNhaCC.getNhaCC();
            LoadGridView();
            LamMoiGiaTri(true, false);
            txtTenNCC.Focus();

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bool DungSDT = int.TryParse(txtSDT.Text, out int sdt);

            if (DungSDT && txtSDT.Text != "" && txtTenNCC.Text != "")
            {
                dtoNhaCC = new DTO_NhaCC(txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                if (bllNhaCC.InsertNhaCC(dtoNhaCC))
                {
                    MsgBox("Thêm nhà cung cấp thành công!");
                    dgvNCC.DataSource = bllNhaCC.getNhaCC();
                    LoadGridView();
                    LamMoiGiaTri(true, false);
                }
                else
                    MsgBox("Thêm nhà cung cấp không thành công", true);
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);

        }

        

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bllNhaCC.DeleteNhaCC(int.Parse(txtMaNCC.Text)))
                {
                    MsgBox("Xóa thành công");
                    dgvNCC.DataSource = bllNhaCC.getNhaCC();
                    LoadGridView();
                    LamMoiGiaTri(true, false);
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiGiaTri(true, false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            bool DUNGSDT = int.TryParse(txtSDT.Text, out int num);

            if (DUNGSDT && txtSDT.Text != "" && txtTenNCC.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtoNhaCC = new DTO_NhaCC(int.Parse(txtMaNCC.Text), txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                    if (bllNhaCC.UpdateNhaCC(dtoNhaCC))
                    {
                        MsgBox("Sửa nhà cung cấp thành công!");
                        dgvNCC.DataSource = bllNhaCC.getNhaCC();
                        LoadGridView();
                        LamMoiGiaTri(true, false);
                    }
                    else
                        MsgBox("Sửa nhà cung cấp không thành công", true);
                }
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
        }
    }
}
