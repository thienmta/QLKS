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
    class KieuPhongModel
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        

        public DataTable getKieuPhong()
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select idkieuphong,tenkieuphong from tbl_kieuphong ", con.StrCon1);
                ds = new DataTable();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
            }
            return ds;
        }

        
    }
}
