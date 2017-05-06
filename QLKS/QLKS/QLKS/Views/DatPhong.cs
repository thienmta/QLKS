using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.Model;
using QLKS.Object;

namespace QLKS.Views
{
    public partial class DatPhong : Form
    {
        NhanVienModel nv_model = new NhanVienModel();
        KieuPhongModel kp_model = new KieuPhongModel();
        HoaDonModel hd_model = new HoaDonModel();
        PhongModel p_model = new PhongModel();
        


        public DatPhong()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DatPhong_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh:mm dd/MM/yyyy";
            dtp_thoigiandat2.Format = DateTimePickerFormat.Custom;
            dtp_thoigiandat2.CustomFormat = "hh:mm dd/MM/yyyy";
            dtp_thoigiantra2.Format = DateTimePickerFormat.Custom;
            dtp_thoigiantra2.CustomFormat = "hh:mm dd/MM/yyyy";
            cbb_nhanvien.DisplayMember = "tennhanvien";
            cbb_nhanvien.ValueMember = "idnhanvien";
            cbb_nhanvien.DataSource = nv_model.getNhanVien();


            cbb_loaiphong1.DisplayMember = "tenkieuphong";
            cbb_loaiphong1.ValueMember = "idkieuphong";
            cbb_loaiphong1.DataSource = kp_model.getKieuPhong();

            cbb_phong2.DisplayMember = "tenphong";
            cbb_phong2.ValueMember = "idhoadon";
            cbb_phong2.DataSource = hd_model.getTraPhong();
        }

        private void cbb_loaiphong1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cbb_phong1.DisplayMember = "tenphong";
            cbb_phong1.ValueMember = "IDPhong";
            cbb_phong1.DataSource = p_model.Phong(cbb_loaiphong1.Text);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonObject hd = new HoaDonObject();
                hd = get_data_hoadon1();
                int a = hd_model.DatPhong(hd);
                if (a > 0)
                    MessageBox.Show("Đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatPhong_Load(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        HoaDonObject get_data_hoadon1()
        {
            HoaDonObject hd = new HoaDonObject();
            hd.CMT = txt_socmt1.Text;
            hd.DienThoai = txt_dienthoai1.Text;
            hd.GhiChu = txt_ghichu1.Text;
            hd.IDNhanVien =int.Parse(cbb_nhanvien.SelectedValue.ToString());
            hd.IDPhong = int.Parse(cbb_phong1.SelectedValue.ToString());
            hd.TenKhachHang = txt_tenkhachhang1.Text;
            return hd;
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonObject hd = new HoaDonObject();
                hd.IDHoaDon = int.Parse(cbb_phong2.SelectedValue.ToString());
                //lbl_dongia.Text = cbb_phong2.Text;

                //tinh thoi gian giữa 2 dtp
                TimeSpan time = dtp_thoigiantra2.Value - dtp_thoigiandat2.Value;
                hd.ThanhTien = time.Hours * int.Parse(lbl_dongia.Text);
                hd.GhiChu = txt_ghichu2.Text;
                int a = hd_model.TraPhong(hd, cbb_phong2.Text);
                if (a > 0)
                {
                    MessageBox.Show("Trả phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_thanhtien.Text = hd.ThanhTien.ToString() + " vnd";
                    lbl_thoigian.Text = time.Hours.ToString() + " giờ";
                }
                else
                    MessageBox.Show("Trả phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                MessageBox.Show("Trả phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cbb_phong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = hd_model.getThongTinTraPhong(cbb_phong2.SelectedValue.ToString());
            txt_loaiphong.Text = dt.Rows[0][0].ToString();
            txt_tenkhachhang2.Text = dt.Rows[0][1].ToString();
            txt_socmt2.Text = dt.Rows[0][2].ToString();
            txt_dienthoai2.Text = dt.Rows[0][3].ToString();
            txt_ghichu2.Text = dt.Rows[0][4].ToString();
            dtp_thoigiandat2.Text = dt.Rows[0][5].ToString();
            dtp_thoigiantra2.Text = dt.Rows[0][6].ToString();
            lbl_dongia.Text = dt.Rows[0][7].ToString();
            
        }
    }
}
