namespace PRJ_QuanLyBanLaptop
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.chartTongTien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSoLuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTenSPBanChay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTienLai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTongTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(587, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống kê doanh thu";
            // 
            // chartTongTien
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTongTien.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTongTien.Legends.Add(legend1);
            this.chartTongTien.Location = new System.Drawing.Point(722, 121);
            this.chartTongTien.Name = "chartTongTien";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "TongTien";
            this.chartTongTien.Series.Add(series1);
            this.chartTongTien.Size = new System.Drawing.Size(584, 331);
            this.chartTongTien.TabIndex = 2;
            this.chartTongTien.Text = "chart1";
            // 
            // chartSoLuong
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSoLuong.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSoLuong.Legends.Add(legend2);
            this.chartSoLuong.Location = new System.Drawing.Point(45, 121);
            this.chartSoLuong.Name = "chartSoLuong";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "SoLuongBan";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "SoLuongConLai";
            this.chartSoLuong.Series.Add(series2);
            this.chartSoLuong.Series.Add(series3);
            this.chartSoLuong.Size = new System.Drawing.Size(651, 331);
            this.chartSoLuong.TabIndex = 3;
            this.chartSoLuong.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTienLai);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbTongTien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbTenSPBanChay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(238, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 161);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng kết ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng số lượng laptop bán ra:";
            // 
            // lbTenSPBanChay
            // 
            this.lbTenSPBanChay.Location = new System.Drawing.Point(273, 27);
            this.lbTenSPBanChay.Name = "lbTenSPBanChay";
            this.lbTenSPBanChay.Size = new System.Drawing.Size(656, 28);
            this.lbTenSPBanChay.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng doanh thu:";
            // 
            // lbTongTien
            // 
            this.lbTongTien.Location = new System.Drawing.Point(173, 77);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(303, 20);
            this.lbTongTien.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lãi:";
            // 
            // lbTienLai
            // 
            this.lbTienLai.Location = new System.Drawing.Point(173, 124);
            this.lbTienLai.Name = "lbTienLai";
            this.lbTienLai.Size = new System.Drawing.Size(181, 20);
            this.lbTienLai.TabIndex = 5;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1451, 731);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartSoLuong);
            this.Controls.Add(this.chartTongTien);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongKe";
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTongTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTongTien;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSoLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTenSPBanChay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTienLai;
        private System.Windows.Forms.Label label5;
    }
}