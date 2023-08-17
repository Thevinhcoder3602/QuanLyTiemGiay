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
    public class DAL_HDBan: DAL_Connect
    {
        public DataTable List_HDBan()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_HDBan";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Insert_HDBan(DTO_HDBan dtoHDBan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_HDBan";
                cmd.Parameters.AddWithValue("maNV", dtoHDBan.MaNV);
                cmd.Parameters.AddWithValue("maKH", dtoHDBan.MaKH);
                cmd.Parameters.AddWithValue("tongTienBan", dtoHDBan.TongTienBan);
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

        public DataTable Search_TenKH_HDBan(string tenKH)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Search_TenKH_HDBan";
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

        public double Thang4()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Thang4";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

        public double Thang5()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Thang5";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

        public double Thang6()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Thang6";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }
        public double Thang7()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Thang7";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
