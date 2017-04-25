using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKS.Model;
using QLKS.Object;

namespace QLKS.Control
{
    class AccountControl
    {
        AccountModel tk = new AccountModel();
        public int kiemtraTK(AccountObject accObj)
        {
            return tk.KiemTraTK(accObj);
        }

        public int addTaiKhoan(AccountObject accObj)
        {
            return tk.AddData(accObj);
        }
    }
}
