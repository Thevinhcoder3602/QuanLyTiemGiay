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
    public class BLL_NhaCC
    {
        DAL_NhaCC dalNhaCC = new DAL_NhaCC();

        public DataTable getNhaCC()
        {
            return dalNhaCC.getNhaCC();
        }

        public bool InsertNhaCC(DTO_NhaCC dtoNhaCC)
        {
            return dalNhaCC.InsertNhaCC(dtoNhaCC);
        }

        public bool DeleteNhaCC(int maNCC)
        {
            return dalNhaCC.DeleteNhaCC(maNCC);
        }

        public bool UpdateNhaCC(DTO_NhaCC dtoNhaCC)
        {
            return dalNhaCC.UpdateNhaCC(dtoNhaCC);
        }

        public DataTable SearchNhaCC(string tenNCC)
        {
            return dalNhaCC.SearchNhaCC(tenNCC);
        }

        public string[] List_MaNCC()
        {
            return dalNhaCC.List_MaNCC();
        }
    }
}

