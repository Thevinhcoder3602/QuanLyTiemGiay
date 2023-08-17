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
    public class BLL_CTHDBan
    {
        DAL_CTHDBan dalCTHDBan = new DAL_CTHDBan();

        public DataTable List_CTHDBan()
        {
            return dalCTHDBan.List_CTHDBan();
        }

        public bool Insert_CTHDBan(DTO_CTHDBan dtoCTHDBan, int soLuong)
        {
            return dalCTHDBan.Insert_CTHDBan(dtoCTHDBan, soLuong);
        }

        public double TongGiaBan()
        {
            return dalCTHDBan.TongGiaBan();
        }

        public bool Delete_SP_CTHDBan(int maSP)
        {
            return dalCTHDBan.Delete_SP_CTHDBan(maSP);
        }

        public bool Update_SP_CTHDBan(int maSP, int soLuong)
        {
            return dalCTHDBan.Update_SP_CTHDBan(maSP, soLuong);
        }
    }
}
