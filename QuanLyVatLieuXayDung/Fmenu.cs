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
            FXuatHang qlhdx = new FXuatHang();
            qlhdx.Show();
        }

        private void traCứuThôngItToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đặtHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void traCứuThôngItnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
