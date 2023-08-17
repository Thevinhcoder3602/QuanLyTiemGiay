using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemGIay
{
    public partial class frmSanPham : Form
    {
        private string DiaChiFileAnh;
        private byte[] img;
        BLL_SanPham bll_sanPham = new BLL_SanPham();
        DTO_SanPham dto_sanPham;
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void SetGiaTri(bool param, bool isLoad)
        {
            txtMaSP.Text = null;

            txtTenSP.Text = null;
            txtSoLuong.Text = null;
            txtGiaNhap.Text = null;
            txtGiaBan.Text = null;
            txtGhiChu.Text = null;

            btThem.Enabled = param;
            ptbAnhSP.Image = null;

            if (isLoad)
            {
                btSua.Enabled = !false;
                btXoa.Enabled = false;
            }
            else
            {
                btSua.Enabled = !param;
                btXoa.Enabled = !param;
            }
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private Image CloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };
            return result;
        }
        private byte[] ImageToByteArray(PictureBox ptb)
        {
            MemoryStream memoryStream = new MemoryStream();
            ptb.Image.Save(memoryStream, ptb.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void LoadGridView()
        {
            dgvSanPham.Columns[0].HeaderText = "Mã hàng";
            dgvSanPham.Columns[1].HeaderText = "Tên hàng";
            dgvSanPham.Columns[2].HeaderText = "Số lượng";
            dgvSanPham.Columns[3].HeaderText = "Đơn giá nhập";
            dgvSanPham.Columns[4].HeaderText = "Đơn giá bán";
            dgvSanPham.Columns[5].HeaderText = "Hình ảnh";
            dgvSanPham.Columns[6].HeaderText = "Ghi chú";
            foreach (DataGridViewColumn item in dgvSanPham.Columns)
                item.DividerWidth = 1;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dgvSanPham.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvSanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private bool CheckIsNummber(string text)
        {
            return int.TryParse(text, out int s);
        }
        private void OpenAnh()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "Chọn ảnh";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DiaChiFileAnh = open.FileName;
                ptbAnhSP.Image = CloneImage(DiaChiFileAnh);
                ptbAnhSP.ImageLocation = DiaChiFileAnh;
                img = ImageToByteArray(ptbAnhSP);
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = bll_sanPham.getSanPham();
            LoadGridView();
            SetGiaTri(true, false);
            txtTenSP.Focus();
        }




        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            string name = txtTimKiemSP.Text.Trim();
            if (name == "")
            {
                frmSanPham_Load(sender, e);
                txtTimKiemSP.Focus();
            }
            else
            {
                DataTable data = bll_sanPham.SearchSanPham(txtTimKiemSP.Text);
                dgvSanPham.DataSource = data;
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Rows.Count > 0)
            {
                btSua.Enabled = true;
                btXoa.Enabled = true;

                txtMaSP.ReadOnly = true;
                txtMaSP.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
                txtGiaNhap.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
                txtGiaBan.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();

                MemoryStream memoryStream = new MemoryStream((byte[])dgvSanPham.CurrentRow.Cells[5].Value);
                ptbAnhSP.Image = Image.FromStream(memoryStream);
                txtGhiChu.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            if (!CheckIsNummber(txtSoLuong.Text) || !CheckIsNummber(txtGiaBan.Text) || !CheckIsNummber(txtGiaNhap.Text))
                MsgBox("Vui lòng nhập chữ số!", true);
            else if (txtTenSP.Text == "")
                MsgBox("Thiếu trường thông tin!", true);
            else if (ptbAnhSP.Image == null)
                MsgBox("Vui lòng chọn hình!", true);
            else
            {
                dto_sanPham = new DTO_SanPham
                (
                    txtTenSP.Text,
                    int.Parse(txtSoLuong.Text),
                    int.Parse(txtGiaNhap.Text),
                    int.Parse(txtGiaBan.Text),
                    ImageToByteArray(ptbAnhSP),
                    txtGhiChu.Text
                );
                if (bll_sanPham.InsertSanPham(dto_sanPham))
                {
                    dgvSanPham.DataSource = bll_sanPham.getSanPham();
                    LoadGridView();
                    MsgBox("Thêm sản phẩm thành công");
                }
                else
                {
                    MsgBox("Thêm sản phẩm không được", true);
                }
            }
        }

        private void btLamMoi_Click_1(object sender, EventArgs e)
        {
            SetGiaTri(true, false);
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckIsNummber(txtSoLuong.Text) || !CheckIsNummber(txtGiaBan.Text) || !CheckIsNummber(txtGiaNhap.Text))
                    MsgBox("Vui lòng nhập chữ số!", true);
                else if (txtTenSP.Text == "")
                    MsgBox("Thiếu trường thông tin!", true);
                else if (ptbAnhSP.Image == null)
                    MsgBox("Vui lòng chọn hình!", true);
                else
                {
                    dto_sanPham = new DTO_SanPham
                    (
                        int.Parse(txtMaSP.Text),
                        txtTenSP.Text,
                        int.Parse(txtSoLuong.Text),
                        int.Parse(txtGiaNhap.Text),
                        int.Parse(txtGiaBan.Text),
                        ImageToByteArray(ptbAnhSP),
                        txtGhiChu.Text
                    );
                    if (bll_sanPham.UpDateSanPham(dto_sanPham))
                    {
                        dgvSanPham.DataSource = bll_sanPham.getSanPham();
                        LoadGridView();
                        MsgBox("Sửa sản phẩm thành công!");
                    }
                    else
                    {
                        MsgBox("Sửa sản phẩm không được", true);
                    }
                }
            }
        }

        private void btThemAnh_Click_1(object sender, EventArgs e)
        {
            OpenAnh();
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll_sanPham.DeleteSanPham(int.Parse(txtMaSP.Text)))
                {
                    dgvSanPham.DataSource = bll_sanPham.getSanPham();
                    LoadGridView();
                    MsgBox("Xóa thành công");
                }
                else
                    MsgBox("Xóa không thành công!");
            }
        }
    }
}
