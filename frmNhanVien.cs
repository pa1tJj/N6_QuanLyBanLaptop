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
    public partial class frmNhanVien : Form
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
        public frmNhanVien()
        {
            InitializeComponent();
            hienthi();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
        }
        void hienthi()
        {
            ketnoi();
            string sql = "select manv as N'Mã nhân viên',tennv as N'Tên nhân viên',gioitinh as N'Giới tính',sdt_nv as N'Số điện thoại',diachi_nv as N'Địa chỉ',ngaysinh_nv as 'Ngày sinh',chucvu as N'Chức vụ' from nhan_vien";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvNhanVien.DataSource = dt;
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
            if (check_input_chuoi(txtMaNV) == false)
            {
                MessageBox.Show("mã nhân viên là chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtHoTen) == false)
            {
                MessageBox.Show("họ tên nhân viên là chuỗi k rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (check_input_chuoi(txtChucVu) == false)
            {
                MessageBox.Show("chức vụ là chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into nhan_vien values(@manv,@tennv,@gioitinh,@sdt_nv,@diachi_nv,@ngaysinh_nv,@chucvu)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@tennv", txtHoTen.Text);
                cmd.Parameters.AddWithValue("gioitinh", rbNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("sdt_nv", txtSdt.Text);
                cmd.Parameters.AddWithValue("diachi_nv", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("ngaysinh_nv", dtpNgaySinh.Text);
                cmd.Parameters.AddWithValue("chucvu", txtChucVu.Text);
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
            string sql = "update nhan_vien set tennv = @tennv,gioitinh = @gioitinh,sdt_nv = @sdt_nv,diachi_nv = @diachi_nv,ngaysinh_nv = @ngaysinh_nv,chucvu = @chucvu where manv = @manv ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tennv", txtHoTen.Text);
            cmd.Parameters.AddWithValue("gioitinh", rbNam.Checked ? "Nam" : "Nữ");
            cmd.Parameters.AddWithValue("sdt_nv", txtSdt.Text);
            cmd.Parameters.AddWithValue("diachi_nv", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("ngaysinh_nv", dtpNgaySinh.Text);
            cmd.Parameters.AddWithValue("chucvu", txtChucVu.Text);
            cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
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
                string sql = "delete from nhan_vien where manv = @ma";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma", txtMaNV.Text);
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
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtChucVu.Clear();
            txtSdt.Clear();
            txtMaNV.Enabled = true;
            rbNam.Checked = false;
            rbNu.Checked = false;
        }
        void timkiem()
        {
            ketnoi();
            string sql = "select manv as N'Mã nhân viên',tennv as N'Tên nhân viên',gioitinh as N'Giới tính',sdt_nv as N'Số điện thoại',diachi_nv as N'Địa chỉ',ngaysinh_nv as 'Ngày sinh',chucvu as N'Chức vụ' from nhan_vien where tennv like '%"+txtTimKiem.Text+"%'";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvNhanVien.DataSource = dt;
            con.Close();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            them();
            hienthi();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = selectedRow.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                if (selectedRow.Cells[2].Value.ToString().Equals("Nam")){
                    rbNam.Checked = true;
                } else
                {
                    rbNu.Checked = true;
                }
                txtSdt.Text = selectedRow.Cells[3].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[4].Value.ToString();
                dtpNgaySinh.Text = selectedRow.Cells[5].Value.ToString();
                txtChucVu.Text = selectedRow.Cells[6].Value.ToString();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            sua();
            hienthi();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            xoa_sp();
            hienthi() ;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(!(txtTimKiem.Text == ""))
            {
                timkiem();
            }
        }
    }
}
