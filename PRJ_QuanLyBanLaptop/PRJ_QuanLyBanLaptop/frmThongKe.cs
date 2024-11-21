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
    public partial class frmThongKe : Form
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
        public frmThongKe()
        {
            InitializeComponent();
        }
        void thongke_tongtien()
        {
            ketnoi();
            DataTable dt = new DataTable();
            string sql = "select masp,sum(thanhtien) as tongthanhtien from chitiet_donhang group by masp";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            chartTongTien.DataSource = dt;
            chartTongTien.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";
            chartTongTien.ChartAreas["ChartArea1"].AxisX.Title = "Mã sản phẩm";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartTongTien.Series["TongTien"].Points.AddXY(dt.Rows[i]["masp"], dt.Rows[i]["tongthanhtien"]);
            }
        }
        void thongke_soluong()
        {
            ketnoi() ;
            DataTable dt = new DataTable();
            string sql = "select sp.masp,sum(ct.soluongmua) as tongmua,sp.soluong from chitiet_donhang ct inner join sanpham sp on ct.masp = sp.masp  group by (sp.masp),(ct.soluongmua),(sp.soluong)";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            chartSoLuong.DataSource = dt;
            chartSoLuong.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
            chartSoLuong.ChartAreas["ChartArea1"].AxisX.Title = "Mã sản phẩm";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartSoLuong.Series["SoLuongBan"].Points.AddXY(dt.Rows[i]["masp"], dt.Rows[i]["tongmua"]);
                chartSoLuong.Series["SoLuongConLai"].Points.AddXY(dt.Rows[i]["masp"], dt.Rows[i]["soluong"]);
            }
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            thongke_tongtien();
            thongke_soluong();
            tongtien_ban();
            tienlai();
            sl_ban_duoc();
        }
        
        float tienban;
        //tổng tiền thu về từ bán
        void tongtien_ban()
        {
            var s = new System.Globalization.NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberDecimalSeparator = "."
            };
            ketnoi();
            string sql = "select sum(thanhtien) from chitiet_donhang";
            cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var t = int.Parse(rdr[0].ToString());
                lbTongTien.Text = t.ToString("N",s) + " vnđ";
                tienban = t;
            }

        }
        //tính tiền lãi
        void tienlai()
        {
            var s = new System.Globalization.NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberDecimalSeparator = "."
            };
            ketnoi();
            string sql = "select sum(giamuavao) from sanpham";
            cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var tienmua = int.Parse(rdr[0].ToString());
                var lai = tienban - tienmua;
                lbTienLai.Text = lai.ToString("N", s) + " vnđ";
            }
        }
        //lấy ra số lượng mua lớn nhất
        void sl_ban_duoc()
        {
            ketnoi();
            string sql = "select sum(soluongmua) from chitiet_donhang ";
            cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                
                lbTenSPBanChay.Text = rdr[0].ToString();
            }
        }
        //lấy ra tên laptop bán chạy nhất theo sl_max
        
    }
}
