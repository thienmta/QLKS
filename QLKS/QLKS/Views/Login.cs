using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.Object;
using QLKS.Control;

namespace QLKS.Views
{
    public partial class Login : Form
    {
        AccountControl tkctr = new AccountControl();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            AccountObject tk = new AccountObject();
            addDaTa(tk);
            int a = tkctr.kiemtraTK(tk);
            if (a == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                Menu menu = new Menu();
                menu.Show();
                this.Hide();    
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void addDaTa(AccountObject tkO)
        {
            tkO.Username = txtUser.Text;
            tkO.Password = txtPass.Text;
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
                txtPass.UseSystemPasswordChar = false;
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
