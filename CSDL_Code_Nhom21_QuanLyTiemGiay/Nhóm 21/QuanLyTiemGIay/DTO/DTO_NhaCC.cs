using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhaCC
    {
        private int maNCC;
        private string tenNCC;
        private string diaChi;
        private string sDT;

        public DTO_NhaCC()
        {
        }

        public DTO_NhaCC(int maNCC, string tenNCC, string diaChi, string sDT)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }

        public DTO_NhaCC(string tenNCC, string diaChi, string sDT)
        {
            this.tenNCC = tenNCC;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }

        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
