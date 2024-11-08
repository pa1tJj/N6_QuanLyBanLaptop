namespace PRJ_QuanLyBanLaptop
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btTrangChu = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btThongKe = new System.Windows.Forms.Button();
            this.btNhanVien = new System.Windows.Forms.Button();
            this.btKhoHang = new System.Windows.Forms.Button();
            this.btSanPham = new System.Windows.Forms.Button();
            this.btNCC = new System.Windows.Forms.Button();
            this.btDonHang = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "LAPTOP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btTrangChu
            // 
            this.btTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btTrangChu.Location = new System.Drawing.Point(3, 0);
            this.btTrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.btTrangChu.Name = "btTrangChu";
            this.btTrangChu.Size = new System.Drawing.Size(139, 74);
            this.btTrangChu.TabIndex = 1;
            this.btTrangChu.Text = "Trang chủ";
            this.btTrangChu.UseVisualStyleBackColor = false;
            this.btTrangChu.Click += new System.EventHandler(this.btTrangChu_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(156, 44);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1048, 630);
            this.panelMain.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelLeft.Controls.Add(this.btThongKe);
            this.panelLeft.Controls.Add(this.btNhanVien);
            this.panelLeft.Controls.Add(this.btKhoHang);
            this.panelLeft.Controls.Add(this.btSanPham);
            this.panelLeft.Controls.Add(this.btNCC);
            this.panelLeft.Controls.Add(this.btDonHang);
            this.panelLeft.Controls.Add(this.btTrangChu);
            this.panelLeft.Location = new System.Drawing.Point(7, 44);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(143, 630);
            this.panelLeft.TabIndex = 3;
            // 
            // btThongKe
            // 
            this.btThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btThongKe.Location = new System.Drawing.Point(3, 428);
            this.btThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(139, 74);
            this.btThongKe.TabIndex = 7;
            this.btThongKe.Text = "Thống kê";
            this.btThongKe.UseVisualStyleBackColor = false;
            // 
            // btNhanVien
            // 
            this.btNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btNhanVien.Location = new System.Drawing.Point(4, 357);
            this.btNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btNhanVien.Name = "btNhanVien";
            this.btNhanVien.Size = new System.Drawing.Size(139, 74);
            this.btNhanVien.TabIndex = 6;
            this.btNhanVien.Text = "Nhân viên";
            this.btNhanVien.UseVisualStyleBackColor = false;
            // 
            // btKhoHang
            // 
            this.btKhoHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btKhoHang.Location = new System.Drawing.Point(4, 287);
            this.btKhoHang.Margin = new System.Windows.Forms.Padding(4);
            this.btKhoHang.Name = "btKhoHang";
            this.btKhoHang.Size = new System.Drawing.Size(139, 74);
            this.btKhoHang.TabIndex = 5;
            this.btKhoHang.Text = "Kho hàng";
            this.btKhoHang.UseVisualStyleBackColor = false;
            this.btKhoHang.Click += new System.EventHandler(this.btKhoHang_Click);
            // 
            // btSanPham
            // 
            this.btSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btSanPham.Location = new System.Drawing.Point(4, 71);
            this.btSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.btSanPham.Name = "btSanPham";
            this.btSanPham.Size = new System.Drawing.Size(139, 74);
            this.btSanPham.TabIndex = 4;
            this.btSanPham.Text = "Sản phẩm";
            this.btSanPham.UseVisualStyleBackColor = false;
            this.btSanPham.Click += new System.EventHandler(this.btSanPham_Click);
            // 
            // btNCC
            // 
            this.btNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btNCC.Location = new System.Drawing.Point(4, 142);
            this.btNCC.Margin = new System.Windows.Forms.Padding(4);
            this.btNCC.Name = "btNCC";
            this.btNCC.Size = new System.Drawing.Size(139, 74);
            this.btNCC.TabIndex = 3;
            this.btNCC.Text = "Nhà cung cấp";
            this.btNCC.UseVisualStyleBackColor = false;
            this.btNCC.Click += new System.EventHandler(this.btNCC_Click);
            // 
            // btDonHang
            // 
            this.btDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btDonHang.Location = new System.Drawing.Point(4, 214);
            this.btDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.btDonHang.Name = "btDonHang";
            this.btDonHang.Size = new System.Drawing.Size(139, 74);
            this.btDonHang.TabIndex = 2;
            this.btDonHang.Text = "Đơn hàng";
            this.btDonHang.UseVisualStyleBackColor = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Location = new System.Drawing.Point(7, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1197, 45);
            this.panelTop.TabIndex = 4;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 677);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrangChu";
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTrangChu;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btSanPham;
        private System.Windows.Forms.Button btNCC;
        private System.Windows.Forms.Button btDonHang;
        private System.Windows.Forms.Button btThongKe;
        private System.Windows.Forms.Button btNhanVien;
        private System.Windows.Forms.Button btKhoHang;
        private System.Windows.Forms.Panel panelTop;
    }
}