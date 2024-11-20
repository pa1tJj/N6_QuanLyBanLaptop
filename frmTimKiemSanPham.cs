using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJ_QuanLyBanLaptop
{
    public partial class frmTimKiemSanPham : Form
    {
        public frmTimKiemSanPham()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        void ketnoi()
        {
            string str_con = @"Data Source=DESKTOP-E4JEDDI;Initial Catalog=db_laptop;Integrated Security=True";
            con = new SqlConnection(str_con);
            con.Open();
        }
        void hienthi(string s)
        {
            ketnoi();
            string sql = "select masp as N'Mã sản phẩm',tensp as N'Tên sản phẩm',giabanra as N'Gía bán ra',chitiet as N'Chi tiết',hinhanh as N'Hình ảnh',loailaptop as 'Loại laptop',hangsanxuat as N'Hãng sản xuất', giamuavao as N'Giá mua vào',soluong as N'Số lượng' from sanpham where ";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvThongTinSP.DataSource = dt;
            con.Close();
        }
        private void frmTimKiemSanPham_Load(object sender, EventArgs e)
        {
            cbLoaiTimKiem.Text = "Loại tìm kiếm";
            cbLoaiTimKiem.Items.Add("theo mã");
            cbLoaiTimKiem.Items.Add("theo tên");
        }

        private void cbLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi();
            if (string.IsNullOrEmpty(cbLoaiTimKiem.Text))
            {
                MessageBox.Show("chưa nhập tìm kiếm", "thông báo");
            }
            else
            {
                string sql = "select masp as N'Mã sản phẩm',tensp as N'Tên sản phẩm',giabanra as N'Gía bán ra',chitiet as N'Chi tiết',hinhanh as N'Hình ảnh',loailaptop as 'Loại laptop',hangsanxuat as N'Hãng sản xuất', giamuavao as N'Giá mua vào',soluong as N'Số lượng' from sanpham";

                //SqlParameter ma = new SqlParameter("@masp", int.Parse(txtTimKiem.Text));
                //SqlParameter ten = new SqlParameter("ten", txtTimKiem.Text);
                switch (cbLoaiTimKiem.SelectedIndex)
                {
                    case 0:
                        sql += " where masp = '" + int.Parse(txtTimKiem.Text) + "'";
                        break;
                    case 1:
                        sql += " where tensp like '%" + txtTimKiem.Text + "%' ";
                        break;

                }
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvThongTinSP.DataSource = dt;
                con.Close();
            }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void tim_kiem_theo_gia()
        {
            ketnoi();
            string sql = "select masp as N'Mã sản phẩm',tensp as N'Tên sản phẩm',giabanra as N'Gía bán ra',chitiet as N'Chi tiết',hinhanh as N'Hình ảnh',loailaptop as 'Loại laptop',hangsanxuat as N'Hãng sản xuất', giamuavao as N'Giá mua vào',soluong as N'Số lượng' from sanpham where giabanra between '" + float.Parse(txtGiaDau.Text) + "' and '" + float.Parse(txtGiaCuoi.Text) + "'";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvThongTinSP.DataSource = dt;
            con.Close();
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            tim_kiem_theo_gia();
        }
    }
}
