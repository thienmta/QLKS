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
    class PhongModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        int a = 0;

        public DataTable Phong(string kieuphong)
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select IDPhong,TenPhong from tbl_phong a inner join tbl_kieuphong b on a.IDKieuPhong = b.IDKieuPhong where TenKieuPhong = N'" + kieuphong + "' and TrangThai=1", con.StrCon1);
                ds = new DataTable();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
            }
            return ds;
        }

        public DataTable Phong()
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select IDPhong,TenPhong,kieuphong from tbl_phong a inner join tbl_kieuphong b on a.IDKieuPhong = b.IDKieuPhong where TenKieuPhong = N' and TrangThai=1", con.StrCon1);
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
