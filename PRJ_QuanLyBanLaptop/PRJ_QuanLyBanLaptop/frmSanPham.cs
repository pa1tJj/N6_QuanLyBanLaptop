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
        string tenanh;
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
        void hienthi()
        {
            ketnoi();
            string sql = "select masp as N'Mã sản phẩm',tensp as N'Tên sản phẩm',giabanra as N'Gía bán ra',chitiet as N'Chi tiết',hinhanh as N'Hình ảnh',loailaptop as 'Loại laptop',hangsanxuat as N'Hãng sản xuất', giamuavao as N'Giá mua vào',soluong as N'Số lượng' from sanpham";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvSanPham.DataSource = dt;
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
            string sql = "select masp from sanpham where masp = @masp";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", txtMaSP.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            bool ma_trung = false;
            if (rdr.Read() == true)
            {
                ma_trung = true;
                con.Close();
            }
            return ma_trung;
        }
        void them()
        {
            if (check_input_chuoi(txtMaSP) == false)
            {
                MessageBox.Show("mã sản phẩm là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (kiem_tra_trung_ma_sp(txtMaSP) == true)
            {
                MessageBox.Show("mã sản phẩm đã tồn tại", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenSP) == false)
            {
                MessageBox.Show("tên sản phẩm là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtGiaMuaVao) == false)
            {
                MessageBox.Show("giá mua vào là một số thực không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtGiaBanRa) == false)
            {
                MessageBox.Show("giá bán là một số thực không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtChiTiet) == false)
            {
                MessageBox.Show("nội dung nhập vào là chuỗi k để trống ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.Parse(txtGiaBanRa.Text) < int.Parse(txtGiaMuaVao.Text))
            {
                MessageBox.Show("giá bán ra đang nhỏ hơn giá mua vào", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbLoaiLaptop.Text.Equals(""))
            {
                MessageBox.Show("chưa chọn loại laptop", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbHangSX.Text.Equals(""))
            {
                MessageBox.Show("chưa chọn hãng sản xuất", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (check_input_so(txtSoLuong) == false)
            {
                MessageBox.Show("số lượng là số nguyên k rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pictureBoxSanPham.Image == null)
            {
                MessageBox.Show("chưa chọn ảnh sản phẩm", "thông báo");
            }

            else
            {
                ketnoi();
                string sql = "insert into sanpham values(@masp,@tensp,@giabanra,@chitiet,@hinhanh,@loailaptop,@hangsanxuat,@giamuavao,@soluong)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("masp", txtMaSP.Text);
                cmd.Parameters.AddWithValue("tensp", txtTenSP.Text);
                cmd.Parameters.AddWithValue("giabanra", txtGiaBanRa.Text);
                cmd.Parameters.AddWithValue("chitiet", txtChiTiet.Text);
                cmd.Parameters.AddWithValue("hinhanh", tenanh);
                cmd.Parameters.AddWithValue("loailaptop", cbLoaiLaptop.Text);
                cmd.Parameters.AddWithValue("hangsanxuat", cbHangSX.Text);
                cmd.Parameters.AddWithValue("giamuavao", txtGiaMuaVao.Text);
                cmd.Parameters.AddWithValue("soluong", txtSoLuong.Text);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công");
                }
            }
        }
        string ten_anh_hien_thi;
        void sua()
        {
            ketnoi();
            string sql = "update sanpham set tensp = @tensp,giabanra = @giabanra,chitiet = @chitiet,hinhanh = @hinhanh, loailaptop = @loailaptop,hangsanxuat = @hangsanxuat, giamuavao = @giamuavao, soluong = @soluong where masp = @ma ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tensp", txtTenSP.Text);
            cmd.Parameters.AddWithValue("giabanra", txtGiaBanRa.Text);
            cmd.Parameters.AddWithValue("chitiet", txtChiTiet.Text);
            cmd.Parameters.AddWithValue("hinhanh", tenanh);
            cmd.Parameters.AddWithValue("loailaptop", cbLoaiLaptop.Text);
            cmd.Parameters.AddWithValue("hangsanxuat", cbHangSX.Text);
            cmd.Parameters.AddWithValue("giamuavao", txtGiaMuaVao.Text);
            cmd.Parameters.AddWithValue("soluong", txtSoLuong.Text);
            cmd.Parameters.AddWithValue("ma", txtMaSP.Text);
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
                try
                {
                    string sql = "delete from sanpham where masp = @ma";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("ma", txtMaSP.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("xóa thành công");
                    }
                    reset();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sản phẩm đang có đơn hàng hàng không thể xóa được");
                }
                
            }
        }
        void reset()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBanRa.Clear();
            txtChiTiet.Clear();
            txtGiaMuaVao.Clear();
            txtSoLuong.Clear();
            pictureBoxSanPham.Image = null;
            txtMaSP.Enabled = true;

        }
        private void btReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void pictureBoxSanPham_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "open file|*.png;*.jpg;*.jfif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSanPham.Image = Image.FromFile(openFileDialog1.FileName);
            }
            pictureBoxSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            tenanh = Path.GetFileName(openFileDialog1.FileName);
        }
        void DSLoaiLaptop()
        {
            cbLoaiLaptop.Items.Add("Văn phòng");
            cbLoaiLaptop.Items.Add("Gaming");
            cbLoaiLaptop.Items.Add("Loại mỏng nhẹ");
            cbLoaiLaptop.Items.Add("Đồ họa-kỹ thuật");
            cbLoaiLaptop.Items.Add("Sinh viên");
            cbLoaiLaptop.Items.Add("Cảm ứng");
            cbLoaiLaptop.Items.Add("Laptop AI");
        }
        void DSHangSX()
        {
            cbHangSX.Items.Add("Lenovo");
            cbHangSX.Items.Add("Dell");
            cbHangSX.Items.Add("Macbook");
            cbHangSX.Items.Add("Asus");
            cbHangSX.Items.Add("HP");
            cbHangSX.Items.Add("MSI");
            cbHangSX.Items.Add("Acer");
            cbHangSX.Items.Add("LG");
            cbHangSX.Items.Add("Huawei");
            cbHangSX.Items.Add("Gigabyte");
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            DSLoaiLaptop();
            DSHangSX();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (kiem_tra_trung_ma_sp(txtMaSP) == true)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                them();
                hienthi();
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
            hienthi();
        }

        private void btReset_Click_1(object sender, EventArgs e)
        {
            reset();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {

        }
        string link = "C:/Users/PHAN ANH TUAN/OneDrive/Documents/project C#/PRJ_QuanLyBanLaptop/anh_sp/";
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSP.Enabled = false;
                DataGridViewRow selectedRow = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = selectedRow.Cells[0].Value.ToString();
                txtTenSP.Text = selectedRow.Cells[1].Value.ToString();
                txtGiaBanRa.Text = selectedRow.Cells[2].Value.ToString();
                txtChiTiet.Text = selectedRow.Cells[3].Value.ToString();

                ten_anh_hien_thi = selectedRow.Cells[4].Value.ToString();

                pictureBoxSanPham.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxSanPham.Image = Image.FromFile(link + selectedRow.Cells[4].Value.ToString());
                cbLoaiLaptop.Text = selectedRow.Cells[5].Value.ToString();
                cbHangSX.Text = selectedRow.Cells[6].Value.ToString();
                txtGiaMuaVao.Text = selectedRow.Cells[7].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells[8].Value.ToString();
            }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtGiaBanRa_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "select masp as N'Mã sản phẩm',tensp as N'Tên sản phẩm',giabanra as N'Gía bán ra',chitiet as N'Chi tiết',hinhanh as N'Hình ảnh',loailaptop as 'Loại laptop',hangsanxuat as N'Hãng sản xuất', giamuavao as N'Giá mua vào',soluong as N'Số lượng' from sanpham where masp like '%" + txtTimKiem.Text + "%' ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", txtTimKiem.Text);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvSanPham.DataSource = dt;
            con.Close();
        }


    }
}
