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
    public partial class frmChiTietDonHang : Form
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
        public frmChiTietDonHang()
        {
            InitializeComponent();
            hienthi();
        }
        void hienthi()
        {
            ketnoi();
            string sql = "select dh.madh as N'Mã đơn hàng',nv.tennv as N'Tên nhân viên bán hàng',kh.tenkh as 'Tên khách hàng',kh.sdt_kh as N'Số điện thoại',kh.diachi as N'Địa chỉ',sp.tensp as N'Tên sản phẩm',sp.loailaptop as N'Loại laptop',sp.hangsanxuat as N'Hãng sản xuất',sp.chitiet as N'Chi tiết',ct.soluongmua as N'Số lượng',sp.giabanra as N'Đơn giá',ct.thanhtien as N'Thành tiền',dh.ngayban as N'Ngày bán' from don_hang dh inner join chitiet_donhang ct on ct.madh = dh.madh inner join sanpham sp on sp.masp = ct.masp inner join khach_hang kh on dh.makh = kh.makh inner join nhan_vien nv on nv.manv = dh.manv";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvChiTiet.DataSource = dt;
            con.Close();
        }
        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {

        }
        List<string> list;
        string ma;
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvChiTiet.Rows[e.RowIndex];
                ma = selectedRow.Cells[0].Value.ToString();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btHienChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmThongTinChiTietMotHoaDon f = new frmThongTinChiTietMotHoaDon();
                f.layDuLieu(ma);
                f.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("vui lòng chọn hóa đơn cần in");
            }
            finally { Close(); }

        }

        private void dgvChiTiet_Click(object sender, EventArgs e)
        {

        }
        void tim_kiem_theo_madh()
        {

            ketnoi();
            string sql = "select dh.madh as N'Mã đơn hàng',nv.tennv as N'Tên nhân viên bán hàng',kh.tenkh as 'Tên khách hàng',kh.sdt_kh as N'Số điện thoại',kh.diachi as N'Địa chỉ',sp.tensp as N'Tên sản phẩm',sp.loailaptop as N'Loại laptop',sp.hangsanxuat as N'Hãng sản xuất',sp.chitiet as N'Chi tiết',ct.soluongmua as N'Số lượng',sp.giabanra as N'Đơn giá',ct.thanhtien as N'Thành tiền',dh.ngayban as N'Ngày bán' from don_hang dh inner join chitiet_donhang ct on ct.madh = dh.madh inner join sanpham sp on sp.masp = ct.masp inner join khach_hang kh on dh.makh = kh.makh inner join nhan_vien nv on nv.manv = dh.manv where dh.madh like '%" + txtTimKiem.Text + "%'";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvChiTiet.DataSource = dt;
            con.Close();

        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtTimKiem.Text))){
                tim_kiem_theo_madh();
            }
        }
    }
}
