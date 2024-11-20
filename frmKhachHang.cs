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
using static System.Windows.Forms.LinkLabel;

namespace PRJ_QuanLyBanLaptop
{
    public partial class frmKhachHang : Form
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
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        void hienthi()
        {
            ketnoi();
            string sql = "select makh as N'Mã khách hàng',tenkh as N'Tên khách hàng',gioitinh as N'Giới tính',sdt_kh as N'Số điện thoại',diachi as N'Địa chỉ' from khach_hang";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvKhachHang.DataSource = dt;
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
            if (check_input_chuoi(txtMaKH) == false)
            {
                MessageBox.Show("mã khách hàng là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtHoTen) == false)
            {
                MessageBox.Show("họ tên khách hàng là chuỗi k rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("chưa chọn giới tính ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtSdt) == false)
            {
                MessageBox.Show("Số điện thoại là chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtDiaChi) == false)
            {
                MessageBox.Show("Địa chỉ là chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into khach_hang values(@makh,@tenkh,@gioitinh,@sdt_kh,@diachi)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@tenkh", txtHoTen.Text);
                cmd.Parameters.AddWithValue("gioitinh", rbNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("sdt_kh", txtSdt.Text);
                cmd.Parameters.AddWithValue("diachi", txtDiaChi.Text);
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
            string sql = "update khach_hang set tenkh = @tenkh,gioitinh = @gioitinh,sdt_kh = @sdt_kh,diachi = @diachi where makh = @makh ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tenkh", txtHoTen.Text);
            cmd.Parameters.AddWithValue("gioitinh", rbNam.Checked ? "Nam" : "Nữ");
            cmd.Parameters.AddWithValue("sdt_kh", txtSdt.Text);
            cmd.Parameters.AddWithValue("diachi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
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
                string sql = "delete from khach_hang where makh = @ma";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma", txtMaKH.Text);
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
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
            txtMaKH.Enabled = true;
            rbNam.Checked = false;
            rbNu.Checked = false;
        }
        void timkiem()
        {
            ketnoi();
            string sql = "select makh as N'Mã khách hàng',tenkh as N'Tên khách hàng',gioitinh as N'Giới tính',sdt_kh as N'Số điện thoại',diachi as N'Địa chỉ' from khach_hang ";
            
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvKhachHang.DataSource = dt;
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

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = selectedRow.Cells[0].Value.ToString();   
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                if (selectedRow.Cells[2].Value.ToString().Equals("Nam"))
                {
                    rbNam.Checked = true;
                }else
                {
                    rbNu.Checked = true;
                }
                txtSdt.Text = selectedRow.Cells[3].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
        void timkiem(string tk)
        {
            ketnoi();
            
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sql = "select makh as N'Mã khách hàng',tenkh as N'Tên khách hàng',gioitinh as N'Giới tính',sdt_kh as N'Số điện thoại',diachi as N'Địa chỉ' from khach_hang ";
            if (!(txtTimKiem.Text == ""))
            {
                if (rbTheoMa.Checked == false && rbTheoTenKH.Checked == false)
                {
                    MessageBox.Show("Chưa chọn loại tìm kiếm", "thông báo");
                } else
                {
                    if (rbTheoMa.Checked)
                    {
                        sql += " where makh like '%" + txtTimKiem.Text + "%'";
                    }
                    if (rbTheoTenKH.Checked)
                    {
                        sql += " where tenkh like '%" + txtTimKiem.Text + "%'";
                    }
                }
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhachHang.DataSource = dt;
                con.Close();
            }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
