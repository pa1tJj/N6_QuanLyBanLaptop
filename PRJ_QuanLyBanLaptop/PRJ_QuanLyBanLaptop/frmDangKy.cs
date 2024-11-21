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
    public partial class frmDangKy : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        void ketnoi()
        {
            string str_con = @"Data Source=DESKTOP-E4JEDDI;Initial Catalog=db_laptop;Integrated Security=True";
            con = new SqlConnection(str_con);
            con.Open();
        }
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            
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
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.ShowDialog();
            this.Close();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            if(check_input_chuoi(txtTenDangKy) == false)
            {
                MessageBox.Show("vui lòng nhập tên đăng ký", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if(check_input_chuoi(txtMatKhau) == false && check_input_so(txtMatKhau) == false)
            {
                MessageBox.Show("vui lòng nhập mật khẩu", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtNhapLai) == false && check_input_so(txtMatKhau) == false)
            {
                MessageBox.Show("vui lòng xác nhận mật khẩu", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMatKhau.Text != txtNhapLai.Text)
            {
                MessageBox.Show("mật khẩu không khớp", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ketnoi();
                string sql = "insert into dangnhap values(@tendangnhap,@matkhau,@nhaplai_mk)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tendangnhap", txtTenDangKy.Text);
                cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
                cmd.Parameters.AddWithValue("@nhaplai_mk", txtNhapLai.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thành công", "Thông báo");
                }
            }
            
        }
    }
}
