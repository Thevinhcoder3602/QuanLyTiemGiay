using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();

        private string MaHoa(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public bool DangNhap(string email, string mk)
        {

            mk = MaHoa(mk);
            return dalNhanVien.DangNhap(email, mk);
        }

        public bool KiemTraEmail(string email)
        {
            return dalNhanVien.KiemTraEmail(email);
        }

        public bool UpdateMatKhau(string email, string mK)
        {
            mK = MaHoa(mK);
            return dalNhanVien.UpdateMatKhau(email, mK);
        }

        public bool getVaiTroNV(string email)
        {
            return dalNhanVien.getVaiTroNV(email);
        }

        public bool ChangeMatKhau(string email, string mkCu, string mkMoi)
        {
            mkCu = MaHoa(mkCu);
            mkMoi = MaHoa(mkMoi);
            return dalNhanVien.ChangeMatKhau(email, mkCu, mkMoi);
        }

        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }

        public bool InsertNhanVien(DTO_NhanVien dtoNhanVien)
        {
            dtoNhanVien.MK  = MaHoa(dtoNhanVien.MK);
            return dalNhanVien.InsertNhanVien(dtoNhanVien);
        }

        public bool UpdateNhanVien(DTO_NhanVien dtoNhanVien)
        {
            return dalNhanVien.UpdateNhanVien(dtoNhanVien);
        }

        public bool Update_DiaChi_SDT_NhanVien(DTO_NhanVien dtoNhanVien)
        {
            return dalNhanVien.Update_DiaChi_SDT_NhanVien(dtoNhanVien);
        }

        public bool DeleteNhanVien(int maNV)
        {
            return dalNhanVien.DeleteNhanVien(maNV);
        }

        public DataTable SearchNhanVien(string tenNV)
        {
            return dalNhanVien.SearchNhanVien(tenNV);
        }

        public string getMaNV(string email)
        {
            return dalNhanVien.getMaNV(email);
        }

        public string get_DiaChi_SDT_NhanVien(string email)
        {
            return dalNhanVien.get_DiaChi_SDT_NhanVien(email);
        }

        public string GetRandomPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();
            }
            else return builder.ToString().ToLower();
        }
    }
}
