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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PRJ_QuanLyBanLaptop
{
    public partial class frmThongTinChiTietMotHoaDon : Form
    {
        public string ma;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        void ketnoi()
        {
            string str_con = @"Data Source=DESKTOP-E4JEDDI;Initial Catalog=db_laptop;Integrated Security=True";
            con = new SqlConnection(str_con);
            con.Open();
        }
        public frmThongTinChiTietMotHoaDon()
        {
            InitializeComponent();
            lbChiTiet.Text = "HÓA ĐƠN";
        }
        public void layDuLieu(string data)
        {
            ma = data;
        }
        
        List<string> list = new List<string>();
        void layDuLieuTraVe()
        {
            ketnoi();
            string sql = "select dh.madh as N'Mã đơn hàng',nv.tennv as N'Tên nhân viên bán hàng',kh.tenkh as 'Tên khách hàng',kh.sdt_kh as N'Số điện thoại',kh.diachi as N'Địa chỉ',sp.tensp as N'Tên sản phẩm',sp.loailaptop as N'Loại laptop',sp.hangsanxuat as N'Hãng sản xuất',sp.chitiet as N'Chi tiết',ct.soluongmua as N'Số lượng',sp.giabanra as N'Đơn giá',ct.thanhtien as N'Thành tiền',dh.ngayban as N'Ngày bán' from don_hang dh inner join chitiet_donhang ct on ct.madh = dh.madh inner join sanpham sp on sp.masp = ct.masp inner join khach_hang kh on dh.makh = kh.makh inner join nhan_vien nv on nv.manv = dh.manv where dh.madh = @ma";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("ma", ma);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //đẩy dữ liệu lên listbox
                lbChiTiet.Items.Add("Mã hóa đơn:" +rdr[0].ToString());
                lbChiTiet.Items.Add("Tên nhân viên bán hàng:" + rdr[1].ToString());
                lbChiTiet.Items.Add("Tên khách hàng:" + rdr[2].ToString());
                lbChiTiet.Items.Add("Số điện thoại:" + rdr[3].ToString());
                lbChiTiet.Items.Add("Địa chỉ:" + rdr[4].ToString());
                lbChiTiet.Items.Add("Tên laptop:" + rdr[5].ToString());
                lbChiTiet.Items.Add("Loại laptop:" + rdr[6].ToString());
                lbChiTiet.Items.Add("Hãng sản xuất:" + rdr[7].ToString());
                lbChiTiet.Items.Add("Thông tin chi tiết về laptop:" + rdr[8].ToString());
                lbChiTiet.Items.Add("Số lượng:" + rdr[9].ToString());
                lbChiTiet.Items.Add("Giá bán:" + rdr[10].ToString());
                lbChiTiet.Items.Add("Tổng tiền:" + rdr[11].ToString());
                lbChiTiet.Items.Add("Ngày bán:" + rdr[12].ToString());
                //thêm dữ liệu vào list
                list.Add(rdr[0].ToString());
                list.Add(rdr[1].ToString());
                list.Add(rdr[2].ToString());
                list.Add(rdr[3].ToString());
                list.Add(rdr[4].ToString());
                list.Add(rdr[5].ToString());
                list.Add(rdr[6].ToString());
                list.Add(rdr[7].ToString());
                list.Add(rdr[8].ToString());
                list.Add(rdr[9].ToString());
                list.Add(rdr[10].ToString());
                list.Add(rdr[11].ToString());
                list.Add(rdr[12].ToString());
            }
            
        }
        private void frmThongTinChiTietMotHoaDon_Load(object sender, EventArgs e)
        {
            layDuLieuTraVe();
        }

        private void btInHoaDon_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        //lấy dữ liệu vào file PDF
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("HOÁ ĐƠN MUA HÀNG", new System.Drawing.Font("Courier New", 25, FontStyle.Bold), Brushes.Black, new Point(230, 20));
            e.Graphics.DrawString("Mã hóa đơn: " + list[0], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 130));
            e.Graphics.DrawString("Tên nhân viên bán hàng: " + list[1], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 160));
            e.Graphics.DrawString("Tên khách hàng: " + list[2], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 190));
            e.Graphics.DrawString("Liên hệ: " + list[3], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 220));
            e.Graphics.DrawString("Địa chỉ: " + list[4], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 250));
            e.Graphics.DrawString("Tên laptop: " + list[5], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 280));
            e.Graphics.DrawString("Loại laptop: " + list[6], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 310));
            e.Graphics.DrawString("Hãng sản xuất: " + list[7], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 340));
            e.Graphics.DrawString("Thông tin chi tiết: " + list[8], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 370));
            e.Graphics.DrawString("Số lượng: " + list[9], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 400));
            e.Graphics.DrawString("Giá bán: " + list[10], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(100, 430));
            e.Graphics.DrawString("Tổng tiền: " + list[11], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Red, new Point(550, 470));
            e.Graphics.DrawString("Ngày bán: " + list[12], new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(400, 100));
            //định dạng bút vẽ
            Pen blackPen =  new Pen(Color.Black);
            var y = 70;//tạo độ theo chiều dọc
            var width = printDocument1.DefaultPageSettings.PaperSize.Width;//trả về chiều rộng giấy in
            Point p1 = new Point(10, y);
            Point p2 = new Point(width - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            //đường kẻ ngang thứ 2
            y += 450;
            p1 = new Point(10, y);
            p2 = new Point(width - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            e.Graphics.DrawString("Chữ ký khách hàng", new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(80, 550));
            e.Graphics.DrawString("Chữ ký nhân viên bán bàng", new System.Drawing.Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new Point(490, 550));
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
