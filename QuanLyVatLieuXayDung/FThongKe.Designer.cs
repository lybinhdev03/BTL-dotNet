namespace QuanLyVatLieuXayDung
{
    partial class FThongKe
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            
            this.vlxdDataSet = new QuanLyVatLieuXayDung.vlxdDataSet();
            this.hoaDonXuatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hoaDonXuatTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.HoaDonXuatTableAdapter();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_tienLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TongDoanhThu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonXuatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "TỪ NGÀY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "ĐẾN NGÀY";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(170, 112);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 22);
            this.dateFrom.TabIndex = 4;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(170, 163);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 22);
            this.dateTo.TabIndex = 5;
            // 
            // dataSet1
            // 
            
            // 
            // vlxdDataSet
            // 
            this.vlxdDataSet.DataSetName = "vlxdDataSet";
            this.vlxdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hoaDonXuatBindingSource
            // 
            this.hoaDonXuatBindingSource.DataMember = "HoaDonXuat";
            this.hoaDonXuatBindingSource.DataSource = this.vlxdDataSet;
            // 
            // hoaDonXuatTableAdapter
            // 
            this.hoaDonXuatTableAdapter.ClearBeforeFill = true;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.Location = new System.Drawing.Point(295, 228);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(75, 23);
            this.btn_timKiem.TabIndex = 7;
            this.btn_timKiem.Text = "TÌM";
            this.btn_timKiem.UseVisualStyleBackColor = true;
            this.btn_timKiem.Click += new System.EventHandler(this.btn_timKiem_Click);
            // 
            // table
            // 
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(476, 112);
            this.table.Name = "table";
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.Size = new System.Drawing.Size(694, 274);
            this.table.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_tienLai);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_TongDoanhThu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(28, 402);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1142, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DOANH THU";
            // 
            // txt_tienLai
            // 
            this.txt_tienLai.Location = new System.Drawing.Point(203, 119);
            this.txt_tienLai.Name = "txt_tienLai";
            this.txt_tienLai.Size = new System.Drawing.Size(313, 22);
            this.txt_tienLai.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "TỔNG SỐ TIỀN LÃI";
            // 
            // txt_TongDoanhThu
            // 
            this.txt_TongDoanhThu.Location = new System.Drawing.Point(203, 59);
            this.txt_TongDoanhThu.Name = "txt_TongDoanhThu";
            this.txt_TongDoanhThu.Size = new System.Drawing.Size(313, 22);
            this.txt_TongDoanhThu.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "TỔNG SỐ DOANH THU";
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(1095, 623);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 10;
            this.btn_Export.Text = "XUẤT";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(402, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 46);
            this.label1.TabIndex = 35;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // FThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 675);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.table);
            this.Controls.Add(this.btn_timKiem);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FThongKe";
            this.Text = "FThongKe";
            this.Load += new System.EventHandler(this.FThongKe_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonXuatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        
        private vlxdDataSet vlxdDataSet;
        private System.Windows.Forms.BindingSource hoaDonXuatBindingSource;
        private vlxdDataSetTableAdapters.HoaDonXuatTableAdapter hoaDonXuatTableAdapter;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TongDoanhThu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tienLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label1;
    }
}