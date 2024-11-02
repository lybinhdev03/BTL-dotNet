namespace QuanLyVatLieuXayDung
{
    partial class Fmenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThongTinHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHDX = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtThôngTinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuThôngItnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đặtHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.khoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtThôngTinToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTìnhTrạngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảoHànhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBanHang,
            this.menuKhachHang,
            this.nhàCungCấpToolStripMenuItem,
            this.khoHàngToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem,
            this.bảoHànhToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1172, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBanHang
            // 
            this.menuBanHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnThongTinHangHoa,
            this.mnDatHang,
            this.mnHDX});
            this.menuBanHang.Image = global::QuanLyVatLieuXayDung.Properties.Resources._1__bán_hàng;
            this.menuBanHang.Name = "menuBanHang";
            this.menuBanHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.menuBanHang.Size = new System.Drawing.Size(119, 27);
            this.menuBanHang.Text = "Bán hàng";
            this.menuBanHang.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // mnThongTinHangHoa
            // 
            this.mnThongTinHangHoa.Name = "mnThongTinHangHoa";
            this.mnThongTinHangHoa.Size = new System.Drawing.Size(251, 28);
            this.mnThongTinHangHoa.Text = "Thông tin hàng hóa";
            this.mnThongTinHangHoa.Click += new System.EventHandler(this.traCứuSảnPhẩmToolStripMenuItem_Click);
            // 
            // mnDatHang
            // 
            this.mnDatHang.Name = "mnDatHang";
            this.mnDatHang.Size = new System.Drawing.Size(251, 28);
            this.mnDatHang.Text = "Đặt hàng";
            this.mnDatHang.Click += new System.EventHandler(this.đặtHàngToolStripMenuItem_Click);
            // 
            // mnHDX
            // 
            this.mnHDX.Name = "mnHDX";
            this.mnHDX.Size = new System.Drawing.Size(251, 28);
            this.mnHDX.Text = "Hóa đơn xuất";
            this.mnHDX.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtThôngTinToolStripMenuItem});
            this.menuKhachHang.Image = global::QuanLyVatLieuXayDung.Properties.Resources._2__khách_hàng;
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.menuKhachHang.Size = new System.Drawing.Size(137, 27);
            this.menuKhachHang.Text = "Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // cậpNhậtThôngTinToolStripMenuItem
            // 
            this.cậpNhậtThôngTinToolStripMenuItem.Name = "cậpNhậtThôngTinToolStripMenuItem";
            this.cậpNhậtThôngTinToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.cậpNhậtThôngTinToolStripMenuItem.Text = "Cập nhật thông tin";
            this.cậpNhậtThôngTinToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtThôngTinToolStripMenuItem_Click);
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtThôngTinToolStripMenuItem1,
            this.traCứuThôngItnToolStripMenuItem,
            this.đặtHàngToolStripMenuItem1});
            this.nhàCungCấpToolStripMenuItem.Image = global::QuanLyVatLieuXayDung.Properties.Resources._3__nhà_cc;
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(153, 27);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            // 
            // cậpNhậtThôngTinToolStripMenuItem1
            // 
            this.cậpNhậtThôngTinToolStripMenuItem1.Name = "cậpNhậtThôngTinToolStripMenuItem1";
            this.cậpNhậtThôngTinToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.cậpNhậtThôngTinToolStripMenuItem1.Text = "Cập nhật thông tin";
            this.cậpNhậtThôngTinToolStripMenuItem1.Click += new System.EventHandler(this.cậpNhậtThôngTinToolStripMenuItem1_Click);
            // 
            // traCứuThôngItnToolStripMenuItem
            // 
            this.traCứuThôngItnToolStripMenuItem.Name = "traCứuThôngItnToolStripMenuItem";
            this.traCứuThôngItnToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.traCứuThôngItnToolStripMenuItem.Text = "Nhập hàng";
            this.traCứuThôngItnToolStripMenuItem.Click += new System.EventHandler(this.traCứuThôngItnToolStripMenuItem_Click);
            // 
            // đặtHàngToolStripMenuItem1
            // 
            this.đặtHàngToolStripMenuItem1.Name = "đặtHàngToolStripMenuItem1";
            this.đặtHàngToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.đặtHàngToolStripMenuItem1.Text = "Hóa đơn nhập";
            this.đặtHàngToolStripMenuItem1.Click += new System.EventHandler(this.đặtHàngToolStripMenuItem1_Click);
            // 
            // khoHàngToolStripMenuItem
            // 
            this.khoHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtThôngTinToolStripMenuItem2});
            this.khoHàngToolStripMenuItem.Image = global::QuanLyVatLieuXayDung.Properties.Resources._4__kho;
            this.khoHàngToolStripMenuItem.Name = "khoHàngToolStripMenuItem";
            this.khoHàngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.khoHàngToolStripMenuItem.Size = new System.Drawing.Size(120, 27);
            this.khoHàngToolStripMenuItem.Text = "Kho hàng";
            // 
            // cậpNhậtThôngTinToolStripMenuItem2
            // 
            this.cậpNhậtThôngTinToolStripMenuItem2.Name = "cậpNhậtThôngTinToolStripMenuItem2";
            this.cậpNhậtThôngTinToolStripMenuItem2.Size = new System.Drawing.Size(333, 28);
            this.cậpNhậtThôngTinToolStripMenuItem2.Text = "Tra cứu và Cập nhật thông tin";
            this.cậpNhậtThôngTinToolStripMenuItem2.Click += new System.EventHandler(this.cậpNhậtThôngTinToolStripMenuItem2_Click);
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoTìnhTrạngToolStripMenuItem,
            this.thốngKêDoanhThuToolStripMenuItem});
            this.báoCáoThốngKêToolStripMenuItem.Image = global::QuanLyVatLieuXayDung.Properties.Resources._5__báo_cáo;
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(209, 27);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo và Thống kê";
            // 
            // báoCáoTìnhTrạngToolStripMenuItem
            // 
            this.báoCáoTìnhTrạngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem,
            this.khoHàngToolStripMenuItem1,
            this.nhàCungCấpToolStripMenuItem1});
            this.báoCáoTìnhTrạngToolStripMenuItem.Name = "báoCáoTìnhTrạngToolStripMenuItem";
            this.báoCáoTìnhTrạngToolStripMenuItem.Size = new System.Drawing.Size(256, 28);
            this.báoCáoTìnhTrạngToolStripMenuItem.Text = "Báo cáo ";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(203, 28);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // khoHàngToolStripMenuItem1
            // 
            this.khoHàngToolStripMenuItem1.Name = "khoHàngToolStripMenuItem1";
            this.khoHàngToolStripMenuItem1.Size = new System.Drawing.Size(203, 28);
            this.khoHàngToolStripMenuItem1.Text = "Kho hàng";
            this.khoHàngToolStripMenuItem1.Click += new System.EventHandler(this.khoHàngToolStripMenuItem1_Click);
            // 
            // nhàCungCấpToolStripMenuItem1
            // 
            this.nhàCungCấpToolStripMenuItem1.Name = "nhàCungCấpToolStripMenuItem1";
            this.nhàCungCấpToolStripMenuItem1.Size = new System.Drawing.Size(203, 28);
            this.nhàCungCấpToolStripMenuItem1.Text = "Nhà cung cấp";
            this.nhàCungCấpToolStripMenuItem1.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem1_Click);
            // 
            // thốngKêDoanhThuToolStripMenuItem
            // 
            this.thốngKêDoanhThuToolStripMenuItem.Name = "thốngKêDoanhThuToolStripMenuItem";
            this.thốngKêDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(256, 28);
            this.thốngKêDoanhThuToolStripMenuItem.Text = "Thống kê doanh thu";
            this.thốngKêDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDoanhThuToolStripMenuItem_Click);
            // 
            // bảoHànhToolStripMenuItem
            // 
            this.bảoHànhToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bảoHànhToolStripMenuItem.Image = global::QuanLyVatLieuXayDung.Properties.Resources._6__bảo_hành;
            this.bảoHànhToolStripMenuItem.Name = "bảoHànhToolStripMenuItem";
            this.bảoHànhToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.bảoHànhToolStripMenuItem.Size = new System.Drawing.Size(118, 27);
            this.bảoHànhToolStripMenuItem.Text = "Bảo hành";
            this.bảoHànhToolStripMenuItem.Click += new System.EventHandler(this.bảoHànhToolStripMenuItem_Click);
            // 
            // Fmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyVatLieuXayDung.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1172, 654);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Fmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fmenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBanHang;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảoHànhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnThongTinHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnDatHang;
        private System.Windows.Forms.ToolStripMenuItem mnHDX;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCứuThôngItnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtThôngTinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đặtHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtThôngTinToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTìnhTrạngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem1;
    }
}