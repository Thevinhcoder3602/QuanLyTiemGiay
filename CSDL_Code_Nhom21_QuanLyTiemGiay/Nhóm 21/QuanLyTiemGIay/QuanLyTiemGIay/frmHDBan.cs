using BLL;
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
    public partial class frmHDBan : Form
    {
        frmCTHDBan fCTHDBan;
        BLL_HDBan bllHDBan = new BLL_HDBan();
        public frmHDBan(string email)
        {
            InitializeComponent();
            fCTHDBan = new frmCTHDBan(email);
        }
        private void LoadGridView()
        {
            dgvHDBan.Columns[0].HeaderText = "Mã HD";
            dgvHDBan.Columns[1].HeaderText = "Tên KH";
            dgvHDBan.Columns[2].HeaderText = "Thời gian";
            dgvHDBan.Columns[3].HeaderText = "Tổng tiền";
            foreach (DataGridViewColumn item in dgvHDBan.Columns)
            {
                item.DividerWidth = 1;
            }
            dgvHDBan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHDBan.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHDBan.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtTimKiemHDN_TextChanged(object sender, EventArgs e)
        {
            string HD = txtTimKiemHDBan.Text.Trim();
            if (HD == "")
            {
                frmHDBan_Load(sender, e);
                txtTimKiemHDBan.Focus();
            }
            else
            {
                DataTable data = bllHDBan.Search_TenKH_HDBan(txtTimKiemHDBan.Text);
                dgvHDBan.DataSource = data;
            }
        }
        private void frmHDBan_Load(object sender, EventArgs e)
        {
            dgvHDBan.DataSource = bllHDBan.List_HDBan();
            LoadGridView();
        }

        private void btTaoHD_Click(object sender, EventArgs e)
        {
            this.Hide();
            fCTHDBan.ShowDialog();
            this.Show();
            dgvHDBan.DataSource = bllHDBan.List_HDBan();
            LoadGridView();
        }
    }
}
