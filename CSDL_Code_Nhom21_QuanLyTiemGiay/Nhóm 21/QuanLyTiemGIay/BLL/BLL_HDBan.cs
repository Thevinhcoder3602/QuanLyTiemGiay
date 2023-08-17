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
    public class BLL_HDBan
    {
        DAL_HDBan dalHDBan = new DAL_HDBan();

        public DataTable List_HDBan()
        {
            return dalHDBan.List_HDBan();
        }

        public bool Insert_HDBan(DTO_HDBan dtoHDBan)
        {
            return dalHDBan.Insert_HDBan(dtoHDBan);
        }

        public DataTable Search_TenKH_HDBan(string tenKH)
        {
            return dalHDBan.Search_TenKH_HDBan(tenKH);
        }

        public double Thang4()
        {
            return dalHDBan.Thang4();
        }

        public double Thang5()
        {
            return dalHDBan.Thang5();
        }

        public double Thang6()
        {
            return dalHDBan.Thang6();
        }
        public double Thang7()
        {
            return dalHDBan.Thang7();
        }
    }
}
