using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HDBan
    {
        private int maNV;
        private int maKH;
        private double tongTien;

        public DTO_HDBan()
        {
        }

        public DTO_HDBan(int maNV, int maKH, double tongTien)
        {
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.TongTienBan = tongTien;
        }

        public int MaNV { get => maNV; set => maNV = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public double TongTienBan { get => tongTien; set => tongTien = value; }
    }
}
