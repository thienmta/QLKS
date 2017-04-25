using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLKS.Object;
using QLKS.Model;

namespace QLKS.Model
{
    class AccountModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        int a = 0;
        public int KiemTraTK(AccountObject tk)
        {
            cmd = new SqlCommand();
            cmd.Connection = con.Connection;
            try
            {
                cmd.CommandText = "sp_KiemTraTK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", tk.Username);
                cmd.Parameters.AddWithValue("@pass", tk.Password);
                con.OpenConn();
                a = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                a = -1;
            }
            finally
            {
                con.CloseConn();
            }
            return a;
        }

        public int AddData(AccountObject tk)
        {
            cmd = new SqlCommand();
            cmd.Connection = con.Connection;
            try
            {
                cmd.CommandText = "spTaoTK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", tk.Username);
                cmd.Parameters.AddWithValue("@pass", tk.Password);
                con.OpenConn();
                a = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                a = -1;
            }
            finally
            {
                con.CloseConn();
            }
            return a;
        }
    }
}
