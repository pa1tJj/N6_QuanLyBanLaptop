namespace PRJ_QuanLyBanLaptop
{
    partial class frmThongTinChiTietMotHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinChiTietMotHoaDon));
            this.lbChiTiet = new System.Windows.Forms.ListBox();
            this.btInHoaDon = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // lbChiTiet
            // 
            this.lbChiTiet.FormattingEnabled = true;
            this.lbChiTiet.ItemHeight = 20;
            this.lbChiTiet.Location = new System.Drawing.Point(38, 32);
            this.lbChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.lbChiTiet.Name = "lbChiTiet";
            this.lbChiTiet.Size = new System.Drawing.Size(1110, 584);
            this.lbChiTiet.TabIndex = 0;
            // 
            // btInHoaDon
            // 
            this.btInHoaDon.BackColor = System.Drawing.Color.Cyan;
            this.btInHoaDon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btInHoaDon.Location = new System.Drawing.Point(526, 641);
            this.btInHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btInHoaDon.Name = "btInHoaDon";
            this.btInHoaDon.Size = new System.Drawing.Size(140, 38);
            this.btInHoaDon.TabIndex = 1;
            this.btInHoaDon.Text = "In hóa đơn";
            this.btInHoaDon.UseVisualStyleBackColor = false;
            this.btInHoaDon.Click += new System.EventHandler(this.btInHoaDon_Click);
            // 
            // btThoat
            // 
            this.btThoat.BackColor = System.Drawing.Color.Cyan;
            this.btThoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btThoat.Location = new System.Drawing.Point(1008, 641);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(140, 38);
            this.btThoat.TabIndex = 2;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = false;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmThongTinChiTietMotHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1184, 698);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btInHoaDon);
            this.Controls.Add(this.lbChiTiet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongTinChiTietMotHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmThongTinChiTietMotHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbChiTiet;
        private System.Windows.Forms.Button btInHoaDon;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}