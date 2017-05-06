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
    class HoaDonModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        int a = 0;

        public int DatPhong(HoaDonObject hd)
        {
            cmd = new SqlCommand();
            cmd.Connection = con.Connection;
            try
            {
                cmd.CommandText = "sp_DatPhong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idphong", hd.IDPhong);
                cmd.Parameters.AddWithValue("@idnhanvien", hd.IDNhanVien);
                cmd.Parameters.AddWithValue("@tenkhachhang", hd.TenKhachHang);
                cmd.Parameters.AddWithValue("@cmt", hd.CMT);
                cmd.Parameters.AddWithValue("@dienthoai", hd.DienThoai);
                cmd.Parameters.AddWithValue("@ghichu", hd.GhiChu);
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

        public int TraPhong(HoaDonObject hd,string tenphong)
        {
            cmd = new SqlCommand();
            cmd.Connection = con.Connection;
            try
            {
                cmd.CommandText = "sp_TraPhong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idhoadon", hd.IDHoaDon);
                cmd.Parameters.AddWithValue("@tenphong", tenphong);
                cmd.Parameters.AddWithValue("@thanhtien", hd.ThanhTien);
                cmd.Parameters.AddWithValue("@ghichu", hd.GhiChu);
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
        public DataTable getTraPhong()
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select idhoadon,b.tenphong from tbl_hoadon a inner join tbl_phong b on a.IDPhong = b.IDPhong where GioTra is null", con.StrCon1);
                ds = new DataTable();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
            }
            return ds;
        }
        public DataTable getThongTinTraPhong(string idhoadon)
        {
            DataTable ds = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select TenKieuPhong,TenKhachHang,CMT,DienThoai,GhiChu,GioDat,GioTra,dongia from tbl_hoadon a inner join tbl_phong b on a.IDPhong = b.IDPhong inner join tbl_kieuphong c on b.IDKieuPhong = c.IDKieuPhong where IDHoaDon =" + idhoadon, con.StrCon1);
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
