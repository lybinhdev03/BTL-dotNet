namespace QuanLyVatLieuXayDung
{
    partial class TraCuuSanPham
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
            this.tbSanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbText = new System.Windows.Forms.Label();
            this.cbLoaiTraCuu = new System.Windows.Forms.ComboBox();
            this.txtTraCuuSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTraCuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSanPham
            // 
            this.tbSanPham.AllowUserToAddRows = false;
            this.tbSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbSanPham.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbSanPham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.tbSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.Soluong,
            this.Donvi,
            this.GiaSP});
            this.tbSanPham.Location = new System.Drawing.Point(12, 171);
            this.tbSanPham.Name = "tbSanPham";
            this.tbSanPham.RowHeadersVisible = false;
            this.tbSanPham.RowHeadersWidth = 51;
            this.tbSanPham.RowTemplate.Height = 24;
            this.tbSanPham.Size = new System.Drawing.Size(1160, 470);
            this.tbSanPham.TabIndex = 0;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "         Mã sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "                        Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // Soluong
            // 
            this.Soluong.HeaderText = "           Số lượng";
            this.Soluong.MinimumWidth = 6;
            this.Soluong.Name = "Soluong";
            // 
            // Donvi
            // 
            this.Donvi.HeaderText = "             Đơn vị";
            this.Donvi.MinimumWidth = 6;
            this.Donvi.Name = "Donvi";
            // 
            // GiaSP
            // 
            this.GiaSP.HeaderText = "                     Giá sản phẩm";
            this.GiaSP.MinimumWidth = 6;
            this.GiaSP.Name = "GiaSP";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.Location = new System.Drawing.Point(261, 53);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(119, 23);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "Tên sản phẩm";
            // 
            // cbLoaiTraCuu
            // 
            this.cbLoaiTraCuu.FormattingEnabled = true;
            this.cbLoaiTraCuu.Items.AddRange(new object[] {
            "Tên sản phẩm",
            "Mã sản phẩm"});
            this.cbLoaiTraCuu.Location = new System.Drawing.Point(396, 105);
            this.cbLoaiTraCuu.Name = "cbLoaiTraCuu";
            this.cbLoaiTraCuu.Size = new System.Drawing.Size(281, 24);
            this.cbLoaiTraCuu.TabIndex = 5;
            // 
            // txtTraCuuSP
            // 
            this.txtTraCuuSP.Location = new System.Drawing.Point(396, 55);
            this.txtTraCuuSP.Name = "txtTraCuuSP";
            this.txtTraCuuSP.Size = new System.Drawing.Size(281, 22);
            this.txtTraCuuSP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tìm theo";
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuu.Location = new System.Drawing.Point(802, 101);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(170, 36);
            this.btnTraCuu.TabIndex = 8;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            // 
            // TraCuuSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTraCuuSP);
            this.Controls.Add(this.cbLoaiTraCuu);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.tbSanPham);
            this.Name = "TraCuuSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra Cứu Sản Phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tbSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbSanPham;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.ComboBox cbLoaiTraCuu;
        private System.Windows.Forms.TextBox txtTraCuuSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaSP;
    }
}