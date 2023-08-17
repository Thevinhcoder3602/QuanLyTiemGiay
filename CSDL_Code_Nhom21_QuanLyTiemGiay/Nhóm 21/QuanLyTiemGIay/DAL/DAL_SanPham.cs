using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SanPham : DAL_Connect
    {
        public DataTable getSanPham()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getSanPham";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;

            }
            finally
            {
                conn.Close();
            }

        }
        public bool InsertSanPham(DTO_SanPham dto_sanPham)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertSanPham";
                cmd.Parameters.AddWithValue("TenSP", dto_sanPham.TenSP);
                cmd.Parameters.AddWithValue("SoLuong", dto_sanPham.SoLuong);
                cmd.Parameters.AddWithValue("GiaBanSP", dto_sanPham.GiaBanSP);
                cmd.Parameters.AddWithValue("GiaNhapSP", dto_sanPham.GiaNhapSP);
                cmd.Parameters.AddWithValue("AnhSP", dto_sanPham.AnhSP);
                cmd.Parameters.AddWithValue("GhiChu", dto_sanPham.GhiChu);
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
        public bool UpDateSanPham(DTO_SanPham dto_sanPham)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpDateSanPham";
                cmd.Parameters.AddWithValue("MaSP", dto_sanPham.MaSP);
                cmd.Parameters.AddWithValue("TenSP", dto_sanPham.TenSP);
                cmd.Parameters.AddWithValue("SoLuong", dto_sanPham.SoLuong);
                cmd.Parameters.AddWithValue("GiaNhapSP", dto_sanPham.GiaBanSP);
                cmd.Parameters.AddWithValue("GiaBanSP", dto_sanPham.GiaNhapSP);
                cmd.Parameters.AddWithValue("AnhSP", dto_sanPham.AnhSP);
                cmd.Parameters.AddWithValue("GhiChu", dto_sanPham.GhiChu);
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
        public bool DeleteSanPham(int maSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSanPham";
                cmd.Parameters.AddWithValue("MaSP", maSP);
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
        public DataTable SearchSanPham(string tenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchSanPham";
                cmd.Parameters.AddWithValue("TenSP", tenSP);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public string[] DanhSachTen_SL()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachTen_SL";
                List<string> list = new List<string>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
                return list.ToArray();
            }
            finally
            {
                conn.Close();
            }
        }
        public double GetGiaBanSP(string tenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getGiaBanSP";
                cmd.Parameters.AddWithValue("TenSP", tenSP);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }
        public double GetGiaNhapSP(string tenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getGiaNhapSP";
                cmd.Parameters.AddWithValue("TenSP", tenSP);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }
        public int GetMaSP(string tenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getMaSP";
                cmd.Parameters.AddWithValue("TenSP", tenSP);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
