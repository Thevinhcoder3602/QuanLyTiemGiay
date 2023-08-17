using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();

        public DataTable getKhachHang()
        {
            return dalKhachHang.getKhachHang();
        }

        public bool InsertKhachHang(DTO_KhachHang dtoKhachHang)
        {
            return dalKhachHang.InsertKhachHang(dtoKhachHang);
        }

        public bool DeleteKhachHang(int maKH)
        {
            return dalKhachHang.DeleteKhachHang(maKH);
        }

        public bool UpdateKhachHang(DTO_KhachHang dtoKhachHang)
        {
            return dalKhachHang.UpdateKhachHang(dtoKhachHang);
        }

        public DataTable SearchKhachHang(string tenKH)
        {
            return dalKhachHang.SearchKhachHang(tenKH);
        }

        public string[] List_MaKH()
        {
            return dalKhachHang.List_MaKH();
        }
    }
}
