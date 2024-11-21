using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJ_QuanLyBanLaptop
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        public void OpenForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btSanPham_Click(object sender, EventArgs e)
        {
            OpenForm(new frmSanPham());
        }

        private void btTrangChu_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            OpenForm(new frmNhanVien());
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            OpenForm(new frmKhachHang());
        }

        private void btDonHang_Click(object sender, EventArgs e)
        {
            OpenForm(new frmHoaDon());
        }

        private void btChiTietDH_Click(object sender, EventArgs e)
        {
            OpenForm(new frmChiTietDonHang());
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            OpenForm(new frmThongKe());
        }
    }
}
