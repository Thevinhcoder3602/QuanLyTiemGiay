using BLL;
using Guna.Charts.WinForms;
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
    public partial class frmThongKe : Form
    {
        BLL_HDBan bllHDBan = new BLL_HDBan();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            DoanhThu(gcThongKe);
        }
        public void DoanhThu(GunaChart chart)
        {
            //Chart configuration 
            chart.YAxes.GridLines.Display = false;
            chart.Title.Text = "Doanh thu theo tháng";

            //Create a new dataset 
            var dataset = new GunaBarDataset();
            dataset.DataPoints.Add("Tháng 4", bllHDBan.Thang4());
            dataset.DataPoints.Add("Tháng 5", bllHDBan.Thang5());
            dataset.DataPoints.Add("Tháng 6", bllHDBan.Thang6());
            dataset.DataPoints.Add("Tháng 7", bllHDBan.Thang6());

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }

    }
}
