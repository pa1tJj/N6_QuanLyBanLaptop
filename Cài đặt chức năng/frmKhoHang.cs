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
    public partial class frmKhoHang : Form
    {
        public frmKhoHang()
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
        void layMaNCCVaoCombobox()
        {
            ketnoi();
            string sql = "select ncc.ma_ncc from nha_cc ncc ";
            cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            cbNCC.DataSource = dt;
            cbNCC.ValueMember = "ma_ncc";
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            layMaNCCVaoCombobox();
            hienthi();
        }

        void hienthi()
        {
            ketnoi();
            string sql = "select ma_nhap_hang as N'Mã nhập hàng',ma_ncc as N'Mã NCC',hangsanxuat as N'Hãng SX',loailaptop as 'Loại laptop', giamuavao as N'Gía mua vào',ngaynhaphang as N'ngaynhaphang',soluongnhap as N'Số lượng' from nhap_hang";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dtKhohang = new DataTable();
            adapter.Fill(dtKhohang);
            dgvKhoHang.DataSource = dtKhohang;
            con.Close();
        }
        bool check_input_chuoi(TextBox t)
        {
            if (string.IsNullOrEmpty(t.Text)) return false;
            if (int.TryParse(t.Text, out int value)) return false;
            return true;
        }
        bool check_input_so(TextBox t)
        {
            if (string.IsNullOrWhiteSpace(t.Text)) return false;
            if (!int.TryParse(t.Text, out int value)) return false;
            return true;
        }
        void them()
        {
            ketnoi();
            if (check_input_chuoi(txtMaNhapHang) == false)
            {
                MessageBox.Show("mã là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtHangSanXuat) == false)
            {
                MessageBox.Show("Hãng sx là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtLoaiLaptop) == false)
            {
                MessageBox.Show("Loại laptop là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtGiaMuaVao) == false)
            {
                MessageBox.Show("giá mua vào phải là một số ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtSoLuong) == false)
            {
                MessageBox.Show("Số lượng phải là một số ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into nhap_hang values(@ma_nhap_hang,@ma_ncc,@hangsanxuat,@loailaptop,@giamuavao,@ngaynhaphang,@soluongnhap)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma_nhap_hang", txtMaNhapHang.Text);
                cmd.Parameters.AddWithValue("ma_ncc", cbNCC.Text);
                cmd.Parameters.AddWithValue("hangsanxuat", txtHangSanXuat.Text);
                cmd.Parameters.AddWithValue("loailaptop", txtLoaiLaptop.Text);
                cmd.Parameters.AddWithValue("giamuavao", int.Parse(txtGiaMuaVao.Text));
                cmd.Parameters.AddWithValue("ngaynhaphang", dtpNgayNhap.Text);
                cmd.Parameters.AddWithValue("soluongnhap", int.Parse(txtSoLuong.Text));
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công");
                }
            }
        }
        void sua()
        {
            ketnoi();
            string sql = "update nhap_hang set ma_ncc = @ma_ncc, hangsanxuat = @hangsanxuat, loailaptop = @loailaptop, hinhanh = @hinhanh, loailaptop = @loailaptop where masp = @masp ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tensp", txtTenSP.Text.Trim());
            cmd.Parameters.AddWithValue("giasp", txtGiaSP.Text.Trim());
            cmd.Parameters.AddWithValue("chitiet", txtChiTiet.Text);
            cmd.Parameters.AddWithValue("hinhanh", tenanh);
            cmd.Parameters.AddWithValue("loailaptop", cbLoaiLaptop.Text);
            cmd.Parameters.AddWithValue("masp", txtMaSP.Text);
            int kq = cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("sửa thành công");
            }

        }
        void xoa_sp()
        {
            ketnoi();
            if (MessageBox.Show("bạn có chắc chắn muốn xóa không?", "cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from sanpham where masp = @masp";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("masp", txtMaSP.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("xóa thành công");
                }
            }
        }
        void timkiem_sp()
        {
            ketnoi();
            string sql = "select masp as N'Mã SP',tensp as N'Tên SP',giasp as N'Giá SP',chitiet as N'Chi tiết',hinhanh as N'Đường dẫn ảnh',loailaptop as N'Loại laptop' from sanpham";
            switch (cbLoaiTimKiem.SelectedIndex)
            {
                case 0: sql += " where masp like '" + txtTimkiem.Text + "' "; break;
                case 1: sql += " where tensp like '" + txtTimkiem.Text + "' "; break;
                case 2: sql += " where giasp between '" + int.Parse(txtGia1.Text) + "' and '" + int.Parse(txtGia2.Text) + "' "; break;
                case 3: sql += " where loailaptop like '" + cbLoaiLaptop.Text + "' "; break;
                default: MessageBox.Show("chưa chọn loại tìm kiếm"); break;
            }
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dtSanPham = new DataTable();
            adapter.Fill(dtSanPham);
            dgvSanPham.DataSource = dtSanPham;
            con.Close();
        }
    }

}
