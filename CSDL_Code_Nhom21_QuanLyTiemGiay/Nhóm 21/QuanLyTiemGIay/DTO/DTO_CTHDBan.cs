using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHDBan
    {
        private int maSP;
        private int soLuong;
        private double giaBan;

        public DTO_CTHDBan()
        {
        }

        public DTO_CTHDBan(int maSP, int soLuong, double giaBan)
        {
            this.MaSP = maSP;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
        }

        public int MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
    }
}
