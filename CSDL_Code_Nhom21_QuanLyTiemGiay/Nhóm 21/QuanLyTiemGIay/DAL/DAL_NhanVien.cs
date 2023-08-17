using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhanVien : DAL_Connect
    {
        public bool DangNhap(string email, string mK)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("mK", mK);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraEmail(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraEmail";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateMatKhau(string email, string mK)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("mK", mK);
                if (cmd.ExecuteNonQuery() != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool getVaiTroNV(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getVaiTroNV";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool ChangeMatKhau(string email, string mkCu, string mkMoi)
        { 
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ChangeMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("mkCu", mkCu);
                cmd.Parameters.AddWithValue("mkMoi", mkMoi);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public DataTable getNhanVien()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getNhanVien";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertNhanVien(DTO_NhanVien nhanVien)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertNhanVien";
                cmd.Parameters.AddWithValue("tenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("diaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("sDT", nhanVien.SDT);
                cmd.Parameters.AddWithValue("email", nhanVien.Email);
                cmd.Parameters.AddWithValue("vaiTro", nhanVien.VaiTro);
                cmd.Parameters.AddWithValue("trangThai", nhanVien.TrangThai);
                cmd.Parameters.AddWithValue("mK", nhanVien.MK);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateNhanVien(DTO_NhanVien nhanVien)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateNhanVien";
                cmd.Parameters.AddWithValue("tenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("diaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("sDT", nhanVien.SDT);
                cmd.Parameters.AddWithValue("email", nhanVien.Email);
                cmd.Parameters.AddWithValue("vaiTro", nhanVien.VaiTro);
                cmd.Parameters.AddWithValue("trangThai", nhanVien.TrangThai);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool Update_DiaChi_SDT_NhanVien(DTO_NhanVien nhanVien)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update_DiaChi_SDT_NhanVien";
                cmd.Parameters.AddWithValue("diaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("sDT", nhanVien.SDT);
                cmd.Parameters.AddWithValue("email", nhanVien.Email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool DeleteNhanVien(int maNV)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteNhanVien";
                cmd.Parameters.AddWithValue("maNV", maNV);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public DataTable SearchNhanVien(string tenNV)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchNhanVien";
                cmd.Parameters.AddWithValue("tenNV", tenNV);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public string getMaNV(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getMaNV";
                cmd.Parameters.AddWithValue("email", email);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

        public string get_DiaChi_SDT_NhanVien(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "get_DiaChi_SDT_NhanVien";
                cmd.Parameters.AddWithValue("email", email);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
