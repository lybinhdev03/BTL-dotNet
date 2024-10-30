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
    public partial class FHDXuatHang : Form
    {
        public FHDXuatHang()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FHDChiTietXuatHang fctxh = new FHDChiTietXuatHang();
            fctxh.Show();
        }
    }
}
