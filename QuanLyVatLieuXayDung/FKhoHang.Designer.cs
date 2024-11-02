namespace QuanLyVatLieuXayDung
{
    partial class FKhoHang
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
            this.btn_Lammoi = new System.Windows.Forms.Button();
            this.btn_Taohh = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Soluong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Mahh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Makho = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.txtMahh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            this.txtMakho = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgv_Khohang = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Khohang)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Lammoi
            // 
            this.btn_Lammoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btn_Lammoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Lammoi.ForeColor = System.Drawing.Color.White;
            this.btn_Lammoi.Location = new System.Drawing.Point(541, 169);
            this.btn_Lammoi.Name = "btn_Lammoi";
            this.btn_Lammoi.Size = new System.Drawing.Size(120, 40);
            this.btn_Lammoi.TabIndex = 16;
            this.btn_Lammoi.Text = "Làm mới";
            this.btn_Lammoi.UseVisualStyleBackColor = false;
            // 
            // btn_Taohh
            // 
            this.btn_Taohh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btn_Taohh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Taohh.ForeColor = System.Drawing.Color.White;
            this.btn_Taohh.Location = new System.Drawing.Point(477, 9);
            this.btn_Taohh.Name = "btn_Taohh";
            this.btn_Taohh.Size = new System.Drawing.Size(184, 40);
            this.btn_Taohh.TabIndex = 15;
            this.btn_Taohh.Text = "Tạo hàng hoá";
            this.btn_Taohh.UseVisualStyleBackColor = false;
            this.btn_Taohh.Click += new System.EventHandler(this.btn_Taohh_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Số lượng";
            // 
            // txt_Soluong
            // 
            this.txt_Soluong.Location = new System.Drawing.Point(136, 130);
            this.txt_Soluong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Soluong.Name = "txt_Soluong";
            this.txt_Soluong.Size = new System.Drawing.Size(209, 22);
            this.txt_Soluong.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mã hàng hoá";
            // 
            // txt_Mahh
            // 
            this.txt_Mahh.Location = new System.Drawing.Point(136, 82);
            this.txt_Mahh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Mahh.Name = "txt_Mahh";
            this.txt_Mahh.Size = new System.Drawing.Size(209, 22);
            this.txt_Mahh.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mã kho";
            // 
            // txt_Makho
            // 
            this.txt_Makho.Location = new System.Drawing.Point(136, 36);
            this.txt_Makho.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Makho.Name = "txt_Makho";
            this.txt_Makho.Size = new System.Drawing.Size(209, 22);
            this.txt_Makho.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 32);
            this.label1.TabIndex = 38;
            this.label1.Text = "THÊM HÀNG HOÁ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mã kho";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.btn_sua);
            this.panel1.Controls.Add(this.btn_Lammoi);
            this.panel1.Controls.Add(this.btn_Taohh);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_Soluong);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_Mahh);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_Makho);
            this.panel1.Location = new System.Drawing.Point(45, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 225);
            this.panel1.TabIndex = 37;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(477, 100);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(184, 40);
            this.btn_xoa.TabIndex = 39;
            this.btn_xoa.Text = "Xoá hàng hoá";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Location = new System.Drawing.Point(477, 54);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(184, 40);
            this.btn_sua.TabIndex = 17;
            this.btn_sua.Text = "Sửa hàng hoá";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // txtMahh
            // 
            this.txtMahh.Location = new System.Drawing.Point(6, 150);
            this.txtMahh.Multiline = true;
            this.txtMahh.Name = "txtMahh";
            this.txtMahh.Size = new System.Drawing.Size(242, 47);
            this.txtMahh.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mã hàng hoá";
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btn_Timkiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timkiem.ForeColor = System.Drawing.Color.White;
            this.btn_Timkiem.Location = new System.Drawing.Point(324, 105);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(120, 40);
            this.btn_Timkiem.TabIndex = 6;
            this.btn_Timkiem.Text = "Tìm kiếm";
            this.btn_Timkiem.UseVisualStyleBackColor = false;
            this.btn_Timkiem.Click += new System.EventHandler(this.btn_Timkiem_Click);
            // 
            // txtMakho
            // 
            this.txtMakho.Location = new System.Drawing.Point(6, 54);
            this.txtMakho.Multiline = true;
            this.txtMakho.Name = "txtMakho";
            this.txtMakho.Size = new System.Drawing.Size(242, 47);
            this.txtMakho.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(45, 335);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(407, 32);
            this.label11.TabIndex = 34;
            this.label11.Text = "Thông tin nhà hàng hoá trong kho";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // dgv_Khohang
            // 
            this.dgv_Khohang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Khohang.Location = new System.Drawing.Point(22, 16);
            this.dgv_Khohang.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Khohang.Name = "dgv_Khohang";
            this.dgv_Khohang.RowHeadersWidth = 51;
            this.dgv_Khohang.Size = new System.Drawing.Size(1137, 230);
            this.dgv_Khohang.TabIndex = 4;
            this.dgv_Khohang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Khohang_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.dgv_Khohang);
            this.panel4.Location = new System.Drawing.Point(45, 393);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1181, 265);
            this.panel4.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.txtMahh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Timkiem);
            this.groupBox1.Controls.Add(this.txtMakho);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(737, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 225);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // FKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 723);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FKhoHang";
            this.Text = "FKhoHang";
            this.Load += new System.EventHandler(this.FKhoHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Khohang)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Lammoi;
        private System.Windows.Forms.Button btn_Taohh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Soluong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Mahh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Makho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMahh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Timkiem;
        private System.Windows.Forms.TextBox txtMakho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgv_Khohang;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
    }
}