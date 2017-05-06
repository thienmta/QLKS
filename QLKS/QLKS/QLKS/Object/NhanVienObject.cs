using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Object
{
    class NhanVienObject
    {
        int idnhanvien;
        string tennhanvien;
        string cmt;

        public int IDNhanVien
        {
            get { return idnhanvien; }
            set { idnhanvien = value; }
        }
        public string TenNhanVien
        {
            get { return tennhanvien; }
            set { tennhanvien = value; }
        }
        public string CMT
        {
            get { return cmt; }
            set { cmt = value; }
        }

    }
}
