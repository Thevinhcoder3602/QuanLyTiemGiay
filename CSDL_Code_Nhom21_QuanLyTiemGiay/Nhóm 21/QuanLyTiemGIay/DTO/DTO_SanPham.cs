using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        private int maSP;
        private string tenSP;
        private int soLuong;
        private double giaNhapSP;
        private double giaBanSP;
        private byte[] anhSP;
        private string ghiChu;

        public DTO_SanPham()
        {

        }

        public DTO_SanPham(string tenSP, int soLuong, double giaNhapSP, double giaBanSP, byte[] anhSP, string ghiChu)
        {
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.giaNhapSP = giaNhapSP;
            this.giaBanSP = giaBanSP;
            this.anhSP = anhSP;
            this.ghiChu = ghiChu;
        }
        public DTO_SanPham(int maSP, string tenSP, int soLuong, double giaNhapSP, double giaBanSP, byte[] anhSP, string ghiChu)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaNhapSP = giaNhapSP;
            this.giaBanSP = giaBanSP;
            this.anhSP = anhSP;
            this.ghiChu = ghiChu;
        }
        public int MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double GiaNhapSP { get => giaNhapSP; set => giaNhapSP = value; }
        public double GiaBanSP { get => giaBanSP; set => giaBanSP = value; }
        public byte[] AnhSP { get => anhSP; set => anhSP = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
