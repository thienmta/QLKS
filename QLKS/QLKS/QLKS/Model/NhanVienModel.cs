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
    class NhanVienModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        

        public DataTable getNhanVien()
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select IDNhanVien,TenNhanVien from tbl_nhanvien order by tennhanvien", con.StrCon1);
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
