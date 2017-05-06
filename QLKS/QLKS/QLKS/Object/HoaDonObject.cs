using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Object
{
    class HoaDonObject
    {

        private int idhoadon;
        private int idnhanvien;
        private int idphong;

        private string tenkhachhang;
        private string cmt;
        private string dienthoai;
        private DateTime giodat;
        private DateTime giotra;
        private int thanhtien;
        private string ghichu;


        public int IDHoaDon
        {
            get { return idhoadon; }
            set { idhoadon = value; }
        }
        public int IDNhanVien
        {
            get { return idnhanvien; }
            set { idnhanvien = value; }
        }
        public int IDPhong
        {
            get { return idphong; }
            set { idphong = value; }
        }
        public int ThanhTien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }

        public string TenKhachHang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }
        public string CMT
        {
            get { return cmt; }
            set { cmt = value; }
        }
        public string DienThoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public DateTime GioDat
        {
            get { return giodat; }
            set { giodat = value; }
        }

        public DateTime GioTra
        {
            get { return giotra; }
            set { giotra = value; }
        }


    }
}
