using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_SanPham
    {
        DAL_SanPham dal_sanPham = new DAL_SanPham();
        public DataTable getSanPham()
        {
            return dal_sanPham.getSanPham();

        }
        public bool InsertSanPham(DTO_SanPham dto_sanPham)
        {
            return dal_sanPham.InsertSanPham(dto_sanPham);
        }
        public bool UpDateSanPham(DTO_SanPham dto_sanPham)
        {
            return dal_sanPham.UpDateSanPham(dto_sanPham);
        }
        public bool DeleteSanPham(int maSP)
        {
            return dal_sanPham.DeleteSanPham(maSP);
        }
        public DataTable SearchSanPham(string tenSP)
        {
            return dal_sanPham.SearchSanPham(tenSP);
        }
        public string[] DanhSachTen_SL()
        {
            return dal_sanPham.DanhSachTen_SL();
        }
        public double GetGiaBanSP(string tenSP)
        {
            return dal_sanPham.GetGiaBanSP(tenSP);
        }
        public double GetGiaNhapSP(string tenSP)
        {
            return dal_sanPham.GetGiaNhapSP(tenSP);
        }
        public int getMaSP(string tenSP)
        {
            return dal_sanPham.GetMaSP(tenSP);
        }
    }
}
