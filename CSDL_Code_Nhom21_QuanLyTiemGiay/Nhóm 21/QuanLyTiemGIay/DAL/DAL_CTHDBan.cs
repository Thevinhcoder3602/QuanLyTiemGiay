using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CTHDBan : DAL_Connect
    {
        public DataTable List_CTHDBan()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_CTHDBan";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Insert_CTHDBan(DTO_CTHDBan dtoCTHDBan, int soLuong)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_CTHDBan";
                cmd.Parameters.AddWithValue("maSP", dtoCTHDBan.MaSP);
                cmd.Parameters.AddWithValue("soLuong", soLuong);
                cmd.Parameters.AddWithValue("giaBanSP", dtoCTHDBan.GiaBan);
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

        public double TongGiaBan()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongGiaBan";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Delete_SP_CTHDBan(int maSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Delete_SP_CTHDBan";
                cmd.Parameters.AddWithValue("maSP", maSP);
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

        public bool Update_SP_CTHDBan(int maSP, int soLuong)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update_SP_CTHDBan";
                cmd.Parameters.AddWithValue("maSP", maSP);
                cmd.Parameters.AddWithValue("soLuong", soLuong);
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
    }
}
