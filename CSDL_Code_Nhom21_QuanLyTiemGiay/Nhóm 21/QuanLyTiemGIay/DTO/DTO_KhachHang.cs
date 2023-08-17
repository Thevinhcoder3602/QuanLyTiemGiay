using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private int maKH;
        private string tenKH;
        private string diaChi;
        private string sDT;

        public DTO_KhachHang()
        {
        }

        public DTO_KhachHang(int maKH, string tenKH, string diaChi, string sDT)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }

        public DTO_KhachHang(string tenKH, string diaChi, string sDT)
        {
            this.tenKH = tenKH;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }

        public int MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
