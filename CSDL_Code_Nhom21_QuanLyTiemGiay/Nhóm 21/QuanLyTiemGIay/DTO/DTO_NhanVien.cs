using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int maNV;
        private string tenNV;
        private string diaChi;
        private string sDT;
        private string email;
        private bool vaiTro;
        private bool trangThai;
        private string mK;

        public DTO_NhanVien()
        {
        }

        public DTO_NhanVien(string tenNV, string diaChi, string sDT, string email, bool vaiTro, bool trangThai, string mK)
        {
            this.tenNV = tenNV;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
            this.vaiTro = vaiTro;
            this.trangThai = trangThai;
            this.mK = mK;
        }

        public DTO_NhanVien(string tenNV, string diaChi, string sDT, string email, bool vaiTro, bool trangThai)
        {
            this.tenNV = tenNV;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
            this.vaiTro = vaiTro;
            this.trangThai = trangThai;
        }

        public DTO_NhanVien(string diaChi, string sDT, string email)
        {
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
        }

        public int MaNV { get => maNV ; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string Email { get => email; set => email = value; }
        public bool VaiTro { get => vaiTro; set => vaiTro = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public string MK { get => mK; set => mK = value; }
    }
}
