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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
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
        void ComboboxLoaiTimKiem()
        {
            cbLoaiTimKiem.Text = "Loại tìm kiếm";
            cbLoaiTimKiem.Items.Add("Theo mã");
            cbLoaiTimKiem.Items.Add("Theo tên");
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            ComboboxLoaiTimKiem();
            hienthi();

        }
        void hienthi()
        {
            ketnoi();
            string sql = "select ma_ncc as N'Mã NCC',ten_ncc as N'Tên NCC',sdt_ncc as N'Số điện thoại',email as 'Email' from nha_cc";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dtNCC = new DataTable();
            adapter.Fill(dtNCC);
            dgvNCC.DataSource = dtNCC;
            con.Close();
        }

        bool check_input_chuoi(TextBox t)
        {
            if (string.IsNullOrEmpty(t.Text)) return false;
            if (int.TryParse(t.Text, out int value)) return false;
            return true;
        }
        void them()
        {
            ketnoi();
            if (check_input_chuoi(txtMaNCC) == false)
            {
                MessageBox.Show("mã là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenNCC) == false)
            {
                MessageBox.Show("tên là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtSDT))
            {
                MessageBox.Show("số điện thoại là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtEmail) == false)
            {
                MessageBox.Show("email là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into nha_cc values(@ma_ncc,@ten_ncc,@sdt_ncc,@email)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma_ncc", txtMaNCC.Text.Trim());
                cmd.Parameters.AddWithValue("ten_ncc", txtTenNCC.Text.Trim());
                cmd.Parameters.AddWithValue("sdt_ncc", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("email", txtEmail.Text.Trim());
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
            string sql = "update nha_cc set ten_ncc = @ten_ncc, sdt_ncc = @sdt_ncc, email = @email where ma_ncc = @ma_ncc ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("ten_ncc", txtTenNCC.Text.Trim());
            cmd.Parameters.AddWithValue("sdt_ncc", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("ma_ncc", txtMaNCC.Text.Trim());
            int kq = cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("sửa thành công");
            }

        }
        void xoa()
        {
            ketnoi();
            if (MessageBox.Show("bạn có chắc chắn muốn xóa không?", "cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from nha_cc where ma_ncc = @ma_ncc";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma_ncc", txtMaNCC.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("xóa thành công");
                }
            }
        }
        void timkiem()
        {
            ketnoi();
            string sql = "select ma_ncc as N'Mã NCC',ten_ncc as N'Tên NCC',sdt_ncc as N'Nhà cung cấp',email as 'Email' from nha_cc";
            switch (cbLoaiTimKiem.SelectedIndex)
            {
                case 0: sql += " where ma_ncc like '" + (txtTimkiem.Text).Trim() + "' "; break;
                case 1: sql += " where ten_ncc like '" + (txtTimkiem.Text).Trim() + "' "; break;
                default: MessageBox.Show("chưa chọn loại tìm kiếm");break;
            }
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dtNCC = new DataTable();
            adapter.Fill(dtNCC);
            dgvNCC.DataSource = dtNCC;
            con.Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            them();
            hienthi();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            sua();
            hienthi() ;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            xoa();
            hienthi();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Clear();
            txtMaNCC.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Enabled = false;
            int i = dgvNCC.CurrentRow.Index;
            txtMaNCC.Text = dgvNCC.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[i].Cells[1].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[i].Cells[3].Value.ToString();
        }

       
    }
}
