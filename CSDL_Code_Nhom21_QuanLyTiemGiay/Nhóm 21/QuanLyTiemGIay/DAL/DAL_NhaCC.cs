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
    public class DAL_NhaCC : DAL_Connect
    {
        public DataTable getNhaCC()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getNhaCC";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertNhaCC(DTO_NhaCC nhaCC)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertNhaCC";
                cmd.Parameters.AddWithValue("tenNCC", nhaCC.TenNCC);
                cmd.Parameters.AddWithValue("diaChi", nhaCC.DiaChi);
                cmd.Parameters.AddWithValue("sDT", nhaCC.SDT);
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

        public bool UpdateNhaCC(DTO_NhaCC nhaCC)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateNhaCC";
                cmd.Parameters.AddWithValue("maNCC", nhaCC.MaNCC);
                cmd.Parameters.AddWithValue("tenNCC", nhaCC.TenNCC);
                cmd.Parameters.AddWithValue("diaChi", nhaCC.DiaChi);
                cmd.Parameters.AddWithValue("sDT", nhaCC.SDT);
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

        public bool DeleteNhaCC(int maNCC)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteNhaCC";
                cmd.Parameters.AddWithValue("maNCC", maNCC);
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

        public DataTable SearchNhaCC(string tenNCC)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchNhaCC";
                cmd.Parameters.AddWithValue("tenNCC", tenNCC);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public string[] List_MaNCC()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_MaNCC";
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
