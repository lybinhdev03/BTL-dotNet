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
    public partial class FBaoCaoKho : Form
    {
        public FBaoCaoKho()
        {
            InitializeComponent();
        }

        private void FBaoCaoKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vlxdDataSet.KhoHang' table. You can move, or remove it, as needed.
            this.khoHangTableAdapter.Fill(this.vlxdDataSet.KhoHang);
            // TODO: This line of code loads data into the 'vlxdDataSet.BaoHanh' table. You can move, or remove it, as needed.
            this.baoHanhTableAdapter.Fill(this.vlxdDataSet.BaoHanh);
            // TODO: This line of code loads data into the 'vlxdDataSet.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.vlxdDataSet.KhachHang);

            this.reportViewer1.RefreshReport();
        }
    }
}
