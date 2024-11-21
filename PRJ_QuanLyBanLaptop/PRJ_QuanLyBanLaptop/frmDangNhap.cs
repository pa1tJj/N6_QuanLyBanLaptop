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
    public partial class frmDangNhap : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        void ketnoi()
        {
            string str_con = @"Data Source=DESKTOP-E4JEDDI;Initial Catalog=db_laptop;Integrated Security=True";
            con = new SqlConnection(str_con);
            con.Open();
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }
        //hàm kiểm tra chuỗi nhập vào
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
            if (check_input_chuoi(txtTenDangNhap) == false)
            {
                MessageBox.Show("vui lòng nhập tên đăng nhập", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (check_input_so(txtMatKhau) == false && check_input_chuoi(txtMatKhau) == false)
            {
                MessageBox.Show("vui lòng nhập mật khẩu", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ketnoi();
                string tendn = txtTenDangNhap.Text.Trim();
                string mk = txtMatKhau.Text.Trim();
                string sql = "select *from dangnhap where tendangnhap = @ten and matkhau = @pass";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ten", tendn);
                cmd.Parameters.AddWithValue("pass", mk);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    frmTrangChu f = new frmTrangChu();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("tên đăng nhập hoặc mật khẩu không đúng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }


        private void btDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.ShowDialog();
            this.Close();
        }

        private void cbHienAn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienAn.Checked == true)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }
    }
}
