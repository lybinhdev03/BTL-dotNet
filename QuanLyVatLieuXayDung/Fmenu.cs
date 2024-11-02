using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatLieuXayDung
{
    public partial class Fmenu : Form
    {
        public Fmenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDatHang datHang = new FDatHang();
            datHang.MdiParent = this;
            datHang.Show();
        }

        private void traCứuSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHangHoa qlHangHoa = new FHangHoa();
            qlHangHoa.MdiParent = this;
            qlHangHoa.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHDXuatHang qlhdx = new FHDXuatHang();
            qlhdx.MdiParent = this;
            qlhdx.Show();
        }

        private void traCứuThôngItToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đặtHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FHDNhapHang fnh = new FHDNhapHang();
            fnh.MdiParent = this;
            fnh.Show();
        }

        private void traCứuThôngItnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhapHang fNhap = new FNhapHang();
            fNhap.MdiParent = this;
            fNhap.Show();
        }

        private void Fmenu_Load(object sender, EventArgs e)
        {

        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKhachHang fkh = new FKhachHang();
            fkh.MdiParent = this;
            fkh.Show();
        }

        private void cậpNhậtThôngTinToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FKhoHang fkh = new FKhoHang();
            fkh.MdiParent = this;
            fkh.Show();
        }

        private void cậpNhậtThôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FNhaCungCap fncc = new FNhaCungCap();
            fncc.MdiParent = this;
            fncc.Show();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FThongKe fThongKe = new FThongKe();
            fThongKe.MdiParent = this;
            fThongKe.Show();
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBaoHanh fBaoHanh = new FBaoHanh(); 
            fBaoHanh.MdiParent = this;
            fBaoHanh.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBaoCaoNV fNhanvien = new FBaoCaoNV();
            fNhanvien.MdiParent = this;
            fNhanvien.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBaoCaoKH fKhachHang = new FBaoCaoKH();
            fKhachHang.MdiParent = this;
            fKhachHang.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBaoCaoHH f = new FBaoCaoHH();
            f.MdiParent = this;
            f.Show();
        }

        private void khoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FBaoCaoKho fBaoCaoKho = new FBaoCaoKho();   
            fBaoCaoKho.MdiParent = this;    
            fBaoCaoKho.Show();
        }

        private void nhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FBaoCaoNCC f = new FBaoCaoNCC();
            f.MdiParent = this;
            f.Show();
        }
    }
}
