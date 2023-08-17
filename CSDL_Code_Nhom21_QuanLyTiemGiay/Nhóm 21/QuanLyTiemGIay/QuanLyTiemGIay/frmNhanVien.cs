using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QuanLyTiemGIay
{
    public partial class frmNhanVien : Form
    {
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();
        private int maNV;
        private string tenNV;
        private bool vaiTro;
        private bool trangThai;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = bllNhanVien.getNhanVien();
            LoadGridView();
            SetValue(true, false);
            txtTenNV.Focus();
        }
        private void LoadGridView()
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ tên";
            dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[4].HeaderText = "Email";
            dgvNhanVien.Columns[5].HeaderText = "Vai trò";
            dgvNhanVien.Columns[6].HeaderText = "Tình trạng";
            foreach (DataGridViewColumn item in dgvNhanVien.Columns)
            {
                item.DividerWidth = 1;
            }
            dgvNhanVien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvNhanVien.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void SetValue(bool param, bool isLoad)
        {
            txtEmail.ReadOnly = false;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtSDT.Text = null;
            btThem.Enabled = param;
            txtTenNV.Text = null;
            rbHoatDong.Enabled = param;
            rbNgungHoatDong.Enabled = param;
            rbNhanVien.Enabled = param;
            rbQuanLy.Enabled = param;
            txtTenNV.Focus();
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
            rbNhanVien.Checked = true;
            rbHoatDong.Checked = true;
        }
        private bool EmailHopLe(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            tenNV = txtTimKiem.Text.Trim();
            if (tenNV =="")
            {
                frmNhanVien_Load(sender, e);
                txtTimKiem.Focus();
            }    
            else
            {
                DataTable data = bllNhanVien.SearchNhanVien(tenNV); 
                dgvNhanVien.DataSource = data;
            }
        }

        private void frmNhanVien_Shown(object sender, EventArgs e)
        {
            txtTenNV.Focus();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btSua.Enabled = true;
            btXoa.Enabled = true;
            rbNgungHoatDong.Enabled = true;
            rbHoatDong.Enabled = true;
            rbNhanVien.Enabled = true;
            rbQuanLy.Enabled = true;
            txtEmail.ReadOnly = true;
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            vaiTro = bool.Parse(dgvNhanVien.CurrentRow.Cells[5].Value.ToString());
            trangThai = bool.Parse(dgvNhanVien.CurrentRow.Cells[6].Value.ToString());
            if (vaiTro)
                rbQuanLy.Checked = true;
            else
                rbNhanVien.Checked = true;
            if (trangThai)
                rbHoatDong.Checked = true;
            else
                rbNgungHoatDong.Checked = true;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text != "" && txtEmail.Text != "" && txtTenNV.Text != ""
                && txtSDT.Text != "")
            {
                if (EmailHopLe(txtEmail.Text))
                {
                    vaiTro = rbQuanLy.Checked;
                    trangThai = rbHoatDong.Checked;
                    string mK = bllNhanVien.GetRandomPassword();
                    DTO_NhanVien dtoNhanVien = new DTO_NhanVien(txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, vaiTro, trangThai, mK);
                    if (bllNhanVien.InsertNhanVien(dtoNhanVien))
                    {
                        SetValue(false, true);
                        dgvNhanVien.DataSource = bllNhanVien.getNhanVien();
                        LoadGridView();

                        SendMail sendMail = new SendMail(dtoNhanVien.Email, mK);
                        sendMail.ShowDialog();
                        MsgBox(sendMail.Result);
                    }
                    else
                        MsgBox("Không thêm nhân viên được!", true);
                }
                else
                    MsgBox("Email không đúng định dạng!", true);
            }
            else
                MsgBox("Thiếu trường thông tin!", true);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text != "" && txtEmail.Text != "" && txtTenNV.Text != ""
                && txtSDT.Text != "")
            {
                vaiTro = rbQuanLy.Checked;
                trangThai = rbHoatDong.Checked;
                DTO_NhanVien dtoNhanVien = new DTO_NhanVien(txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, vaiTro, trangThai);
                if (bllNhanVien.UpdateNhanVien(dtoNhanVien))
                {
                    SetValue(true, false);
                    dgvNhanVien.DataSource = bllNhanVien.getNhanVien();
                    LoadGridView();
                    MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Sửa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                  
            else
                MessageBox.Show("Thiếu trường thông tin!");
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            maNV = int.Parse((dgvNhanVien).CurrentRow.Cells[0].Value.ToString());
            if (bllNhanVien.DeleteNhanVien(maNV))
            {
                SetValue(true, false);
                dgvNhanVien.DataSource = bllNhanVien.getNhanVien();
                LoadGridView();
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Xóa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }
    }
}
