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
    public class DAL_KhachHang : DAL_Connect
    {
        public DataTable getKhachHang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getKhachHang";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertKhachHang(DTO_KhachHang khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertKhachHang";
                cmd.Parameters.AddWithValue("tenKH", khachHang.TenKH);
                cmd.Parameters.AddWithValue("diaChi", khachHang.DiaChi);
                cmd.Parameters.AddWithValue("sDT", khachHang.SDT);
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

        public bool UpdateKhachHang(DTO_KhachHang khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateKhachHang";
                cmd.Parameters.AddWithValue("maKH", khachHang.MaKH);
                cmd.Parameters.AddWithValue("tenKH", khachHang.TenKH);
                cmd.Parameters.AddWithValue("diaChi", khachHang.DiaChi);
                cmd.Parameters.AddWithValue("sDT", khachHang.SDT);
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

        public bool DeleteKhachHang(int maKH)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteKhachHang";
                cmd.Parameters.AddWithValue("maKH", maKH);
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

        public DataTable SearchKhachHang(string tenKH)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchKhachHang";
                cmd.Parameters.AddWithValue("tenKH", tenKH);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public string[] List_MaKH()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_MaKH";
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
    }
}
