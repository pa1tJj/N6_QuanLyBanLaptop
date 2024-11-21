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
    public partial class frmHangLaptop : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        void ketnoi()
        {
            string str_con = @"Data Source=DESKTOP-E4JEDDI;Initial Catalog=db_laptop;Integrated Security=True";
            con = new SqlConnection(str_con);
            con.Open();
        }
        public frmHangLaptop()
        {
            InitializeComponent();
            hienthi();
        }

        private void frmHangLaptop_Load(object sender, EventArgs e)
        {

        }
        void hienthi()
        {
            ketnoi();
            string sql = "select mahanglaptop as N'Mã hãng laptop',ten_hanglaptop as N'Tên hãng' from hanglaptop";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvHangLaptop.DataSource = dt;
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
        bool kiem_tra_trung_ma_sp(TextBox t)
        {
            ketnoi();
            string sql = "select masp from sanpham";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd1.ExecuteReader();
            bool ma_trung = false;
            while (rdr.Read())
            {
                if (t.Text == rdr[0].ToString())
                {
                    ma_trung = true;
                }
            }
            return ma_trung;
        }
        void them()
        {
            ketnoi();
            if (check_input_chuoi(txtMaHang) == false)
            {
                MessageBox.Show("mã hãng là một số nguyên,không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenHang) == false)
            {
                MessageBox.Show("tên hãng là chuỗi k rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into hanglaptop values(@mahanglaptop,@ten_hanglaptop)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mahanglaptop", txtMaHang.Text);
                cmd.Parameters.AddWithValue("@ten_hanglaptop", txtTenHang.Text);
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
            string sql = "update hanglaptop set ten_hanglaptop = @ten where mahanglaptop = @ma ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", txtTenHang.Text);
            cmd.Parameters.AddWithValue("@ma", txtMaHang.Text);
            int kq = cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("sửa thành công");
            }
            reset();
        }
        void xoa_sp()
        {
            ketnoi();
            if (MessageBox.Show("bạn có chắc chắn muốn xóa không?", "cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from hanglaptop where mahanglaptop = @ma";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma", txtMaHang.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("xóa thành công");
                }
                reset();
            }
        }
        void reset()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtMaHang.Enabled = true;
        }
        void timkiem()
        {
            ketnoi();
            string sql = "select mahanglaptop as N'Mã hãng',ten_hanglaptop as N'Tên hãng' from hanglaptop where ten_hanglaptop like '%" + txtTimKiem.Text + "%'";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvHangLaptop.DataSource = dt;
            con.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(!(txtTimKiem.Text == ""))
            {
                timkiem();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            them();
            hienthi();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            sua();
            hienthi();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            xoa_sp();
            hienthi();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvHangLaptop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvHangLaptop.Rows[e.RowIndex];
                txtMaHang.Text = selectedRow.Cells[0].Value.ToString();
                txtTenHang.Text = selectedRow.Cells[1].Value.ToString();
            }
        }
    }
}
