using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJ_QuanLyBanLaptop
{
    public partial class frmSanPham : Form
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
        public frmSanPham()
        {
            InitializeComponent();
            hienthi();
        }
        void layLoaiLapTopVaoCombobox()
        {
            ketnoi();
            string sql = "select n.loailaptop from nhap_hang n inner join kho_hang k on n.ma_nhap_hang = k.ma_nhap_hang inner join sanpham s on s.masp = k.masp";
            cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            cbLoaiLaptop.DataSource = dt;
            cbLoaiLaptop.ValueMember = "loailaptop";
        }
        void ComboboxLoaiTimKiem()
        {
            cbLoaiTimKiem.Items.Add("Theo mã");
            cbLoaiTimKiem.Items.Add("Theo tên");
            cbLoaiTimKiem.Items.Add("Theo giá");
            cbLoaiTimKiem.Items.Add("Theo loại laptop");
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            layLoaiLapTopVaoCombobox();
            ComboboxLoaiTimKiem();
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
        
        void hienthi()
        {
            ketnoi();
            string sql = "select masp as N'Mã SP',tensp as N'Tên SP',giasp as N'Giá SP',chitiet as N'Chi tiết',hinhanh as N'Đường dẫn ảnh',loailaptop as N'Loại laptop' from sanpham";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dtSanPham = new DataTable();
            adapter.Fill(dtSanPham);
            dgvSanPham.DataSource = dtSanPham;
            con.Close();
        }
        string tenanh;
        void them_sp()
        {
            ketnoi();
            if (check_input_chuoi(txtMaSP) == false)
            {
                MessageBox.Show("mã là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenSP) == false)
            {
                MessageBox.Show("tên là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenSP) == false)
            {
                MessageBox.Show("tên là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtGiaSP) == false)
            {
                MessageBox.Show("giá sp phải là một số ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pictureBoxSanPham.Image == null)
            {
                MessageBox.Show("chưa chọn ảnh sản phẩm", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into sanpham values(@masp,@tensp,@giasp,@chitiet,@hinhanh,@loailaptop)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("masp", txtMaSP.Text);
                cmd.Parameters.AddWithValue("tensp", txtTenSP.Text);
                cmd.Parameters.AddWithValue("giasp", int.Parse(txtGiaSP.Text));
                cmd.Parameters.AddWithValue("chitiet", txtChiTiet.Text);
                cmd.Parameters.AddWithValue("hinhanh", tenanh);
                cmd.Parameters.AddWithValue("loailaptop", cbLoaiLaptop.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công");
                }
            }

        }
        void sua_sp()
        {
            ketnoi();
            if (txtMaSP.Enabled == false)
            {
                string sql = "update sanpham set tensp = @tensp, giasp = @giasp, chitiet = @chitiet, hinhanh = @hinhanh, loailaptop = @loailaptop where masp = @masp ";
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
                case 0: sql += " where masp like '" + txtTimkiem.Text + "' ";break;
                case 1: sql += " where tensp like '" + txtTimkiem.Text + "' "; break;
                case 2: sql += " where giasp between '"+int.Parse(txtGia1.Text)+ "' and '"+int.Parse(txtGia2.Text)+"' "; break;
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
        private void btThem_Click(object sender, EventArgs e)
        {
            them_sp();
            hienthi();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            sua_sp();
            hienthi();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            xoa_sp();
            hienthi();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            txtMaSP.Clear();
            txtGiaSP.Clear();
            txtChiTiet.Clear();
            txtTenSP.Clear();
            pictureBoxSanPham.Image = null;
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            timkiem_sp();
        }

        private void pictureBoxSanPham_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "open file|*.png;*.jpg;*.jfif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSanPham.Image = Image.FromFile(openFileDialog1.FileName);
            }
            pictureBoxSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            tenanh = Path.GetFileName(openFileDialog1.FileName);
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Enabled = false;
            int i = dgvSanPham.CurrentRow.Index;
            txtMaSP.Text = dgvSanPham.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dgvSanPham.Rows[i].Cells[1].Value.ToString();
            txtGiaSP.Text = dgvSanPham.Rows[i].Cells[2].Value.ToString();
            txtChiTiet.Text = dgvSanPham.Rows[i].Cells[3].Value.ToString();
            cbLoaiLaptop.Text = dgvSanPham.Rows[i].Cells[5].Value.ToString();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
