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
    public partial class frmHoaDon : Form
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
        public frmHoaDon()
        {
            InitializeComponent();
            DanhSachMaNhanVien();
            DanhSachMaKhacHang();
            DanhSachMaSanPham();
        }
        void DanhSachMaNhanVien()
        {
            ketnoi();
            string sql = "select *from nhan_vien";
            cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            cbMaNhanVien.DataSource = dt;
            cbMaNhanVien.ValueMember = "manv";
        }
        void DanhSachMaKhacHang()
        {
            ketnoi();
            string sql = "select *from khach_hang";
            cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            cbMaKH.DataSource = dt;
            cbMaKH.ValueMember = "makh";
        }
        void DanhSachMaSanPham()
        {
            ketnoi();
            string sql = "select *from sanpham";
            cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            cbMaSP.DataSource = dt;
            cbMaSP.ValueMember = "masp";
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtSdt.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtTenLaptop.ReadOnly = true;
            txtHangSX.ReadOnly = true;
            txtLoaiLaptop.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            hienthi();
        }

        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "select tennv from nhan_vien where manv = @manv";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@manv", cbMaNhanVien.Text);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                txtTenNV.Text = read[0].ToString();
            }
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "select tenkh,sdt_kh,diachi from khach_hang where makh = @makh";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@makh", cbMaKH.Text);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                txtTenKH.Text = read[0].ToString();
                txtSdt.Text = read[1].ToString();
                txtDiaChi.Text = read[2].ToString();
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "select tensp,loailaptop,hangsanxuat,giabanra from sanpham where masp = @masp";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@masp", cbMaSP.Text);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                txtTenLaptop.Text = read[0].ToString();
                txtLoaiLaptop.Text = read[1].ToString();
                txtHangSX.Text = read[2].ToString();
                txtGia.Text = read[3].ToString();
            }
        }

        private void txtSoLuongMua_TextChanged(object sender, EventArgs e)
        {
            if (!(txtSoLuongMua.Text == ""))
            {
                float gia = float.Parse(txtGia.Text);
                int sl = int.Parse(txtSoLuongMua.Text);
                float tongtien = gia * sl;
                txtThanhTien.Text = tongtien.ToString();
            }
        }

        int TraVeSoLuongLaptopTrongKho()
        {
            ketnoi();
            string sql = "select soluong from sanpham where masp = @masp";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", cbMaSP.Text);
            SqlDataReader r = cmd.ExecuteReader();
            int sl = 0;
            while (r.Read())
            {
                sl = int.Parse(r[0].ToString());
            }
            return sl;
        }

        void CapNhatSoLuongTrongKho()
        {
            int slConLai = TraVeSoLuongLaptopTrongKho() - int.Parse(txtSoLuongMua.Text);
            ketnoi();
            string sql = "update sanpham set soluong = @soluong where masp = @masp";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", cbMaSP.Text);
            cmd.Parameters.AddWithValue("soluong", slConLai);
            cmd.ExecuteNonQuery();
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
        int them_hoa_don()
        {
            int kq = 0;
            int slMua = int.Parse(txtSoLuongMua.Text.Trim());
            if (TraVeSoLuongLaptopTrongKho() < slMua)
            {
                MessageBox.Show("Số lượng laptop trong kho không đủ", "Cảnh báo");
            }
            else
            {
                ketnoi();
                string sql = "insert into don_hang values(@madh,@manv,@makh,@ngayban)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
                cmd.Parameters.AddWithValue("manv", cbMaNhanVien.Text);
                cmd.Parameters.AddWithValue("makh", cbMaKH.Text);
                cmd.Parameters.AddWithValue("ngayban", dtpNgayBan.Text);
                kq = cmd.ExecuteNonQuery();
                con.Close();
            }
            return kq;

        }
        int them_chi_tiet_hoa_don()
        {
            ketnoi();
            string sql = "insert into chitiet_donhang values(@madh,@masp,@soluongmua,@thanhtien)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", cbMaSP.Text);
            cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
            cmd.Parameters.AddWithValue("soluongmua", txtSoLuongMua.Text);
            cmd.Parameters.AddWithValue("thanhtien", txtThanhTien.Text);
            int kq = cmd.ExecuteNonQuery();
            con.Close();
            return kq;
        }
        void hienthi()
        {
            ketnoi();
            string sql = "select dh.madh as N'Mã đơn hàng',nv.manv as N'Mã NV',kh.makh as N'Mã KH',nv.tennv as N'Tên nhân viên bán hàng',kh.tenkh as 'Tên khách hàng',kh.sdt_kh as N'Số điện thoại',kh.diachi as N'Địa chỉ',sp.masp as N'Mã SP',sp.tensp as N'Tên sản phẩm',sp.loailaptop as N'Loại laptop',sp.hangsanxuat as N'Hãng sản xuất',ct.soluongmua as N'Số lượng',sp.giabanra as N'Đơn giá',ct.thanhtien as N'Thành tiền',dh.ngayban as 'Ngày bán' from don_hang dh inner join chitiet_donhang ct on ct.madh = dh.madh inner join sanpham sp on sp.masp = ct.masp inner join khach_hang kh on dh.makh = kh.makh inner join nhan_vien nv on nv.manv = dh.manv";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvTTHD.DataSource = dt;
            con.Close();
        }
        int xoa_don_hang()
        {
            ketnoi();
            string sql = "delete from don_hang where madh = @madh";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
            int kq = cmd.ExecuteNonQuery();
            return kq;
        }
        int xoa_chi_tiet()
        {
            ketnoi();
            string sql = "delete from chitiet_donhang where madh = @madh";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
            int kq = cmd.ExecuteNonQuery();
            return kq;
        }
        int sua_don_hang()
        {
            int kq = 0;
            int slMua = int.Parse(txtSoLuongMua.Text.Trim());
            if (TraVeSoLuongLaptopTrongKho() < slMua)
            {
                MessageBox.Show("Số lượng laptop trong kho không đủ", "Cảnh báo");
            }
            else
            {
                ketnoi();
                string sql = "update don_hang set manv = @manv,makh = @makh,ngayban = @ngayban where madh = @madh";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("manv", cbMaNhanVien.Text);
                cmd.Parameters.AddWithValue("makh", cbMaKH.Text);
                cmd.Parameters.AddWithValue("ngayban", dtpNgayBan.Text);
                cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
                kq = cmd.ExecuteNonQuery();
                con.Close();
            }
            return kq;
        }
        int sua_chi_tiet()
        {
            ketnoi();
            string sql = "update chitiet_donhang set masp = @masp,soluongmua = @soluongmua, thanhtien = @thanhtien where madh = @madh";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", cbMaSP.Text);
            cmd.Parameters.AddWithValue("soluongmua", txtSoLuongMua.Text);
            cmd.Parameters.AddWithValue("thanhtien", txtThanhTien.Text);
            cmd.Parameters.AddWithValue("madh", txtMaHD.Text);
            int kq = cmd.ExecuteNonQuery();
            con.Close();
            return kq;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (check_input_chuoi(txtMaHD) == false)
            {
                MessageBox.Show("mã hóa đơn là một chuỗi không rỗng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenNV) == false)
            {
                MessageBox.Show("chưa chọn nhân viên", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenKH) == false)
            {
                MessageBox.Show("chưa chọn khách hàng", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_chuoi(txtTenLaptop) == false)
            {
                MessageBox.Show("chưa chọn sản phẩm", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_input_so(txtSoLuongMua) == false)
            {
                MessageBox.Show("số lượng mua là một số nguyên,k để trống", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (them_hoa_don() > 0)
                {
                    if (them_chi_tiet_hoa_don() > 0)
                    {
                        MessageBox.Show("thêm thành công");
                        CapNhatSoLuongTrongKho();
                        hienthi();
                    }
                }
            }

        }

        private void dgvTTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTTHD.Rows[e.RowIndex];
                txtMaHD.Text = selectedRow.Cells[0].Value.ToString();
                cbMaNhanVien.Text = selectedRow.Cells[1].Value.ToString();
                cbMaKH.Text = selectedRow.Cells[2].Value.ToString();
                txtTenNV.Text = selectedRow.Cells[3].Value.ToString();
                txtTenKH.Text = selectedRow.Cells[4].Value.ToString();
                txtSdt.Text = selectedRow.Cells[5].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[6].Value.ToString();
                cbMaSP.Text = selectedRow.Cells[7].Value.ToString();
                txtTenLaptop.Text = selectedRow.Cells[8].Value.ToString();
                txtLoaiLaptop.Text = selectedRow.Cells[9].Value.ToString();
                txtHangSX.Text = selectedRow.Cells[10].Value.ToString();
                txtSoLuongMua.Text = selectedRow.Cells[11].Value.ToString();
                txtGia.Text = selectedRow.Cells[12].Value.ToString();
                txtThanhTien.Text = selectedRow.Cells[13].Value.ToString();
                dtpNgayBan.Text = selectedRow.Cells[14].Value.ToString();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (sua_don_hang() > 0)
            {
                if (sua_chi_tiet() > 0)
                {
                    MessageBox.Show("sửa thành công");
                    CapNhatSoLuongTrongKho();
                    hienthi();
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (xoa_chi_tiet() > 0 && xoa_don_hang() > 0)
            {
                MessageBox.Show("xóa thành công");
                hienthi();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void TimKiemTheoMa()
        {
            ketnoi();
            string sql = "select dh.madh as N'Mã đơn hàng',nv.manv as N'Mã NV',kh.makh as N'Mã KH',nv.tennv as N'Tên nhân viên bán hàng',kh.tenkh as 'Tên khách hàng',kh.sdt_kh as N'Số điện thoại',kh.diachi as N'Địa chỉ',sp.masp as N'Mã SP',sp.tensp as N'Tên sản phẩm',sp.loailaptop as N'Loại laptop',sp.hangsanxuat as N'Hãng sản xuất',ct.soluongmua as N'Số lượng',sp.giabanra as N'Đơn giá',ct.thanhtien as N'Thành tiền',dh.ngayban as 'Ngày bán' from don_hang dh inner join chitiet_donhang ct on ct.madh = dh.madh inner join sanpham sp on sp.masp = ct.masp inner join khach_hang kh on dh.makh = kh.makh inner join nhan_vien nv on nv.manv = dh.manv where dh.madh like '%" + txtTimKiem.Text + "%'";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvTTHD.DataSource = dt;
            con.Close();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtTimKiem.Text)))
            {
                TimKiemTheoMa();
            }
        }
    }
}
