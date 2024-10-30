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
            datHang.Show();
        }

        private void traCứuSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHangHoa qlHangHoa = new FHangHoa();
            qlHangHoa.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHDXuatHang qlhdx = new FHDXuatHang();
            qlhdx.Show();
        }

        private void traCứuThôngItToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đặtHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FHDNhapHang fnh = new FHDNhapHang();
            fnh.Show();
        }

        private void traCứuThôngItnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhapHang fNhap = new FNhapHang();
            fNhap.Show();
        }

        private void Fmenu_Load(object sender, EventArgs e)
        {

        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKhachHang fkh = new FKhachHang();
            fkh.Show();
        }
    }
}
