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
    public partial class FBaoCaoHH : Form
    {
        public FBaoCaoHH()
        {
            InitializeComponent();
        }

        private void FBaoCaoHH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vlxdDataSet.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter.Fill(this.vlxdDataSet.HangHoa);
            // TODO: This line of code loads data into the 'vlxdDataSet.KhoHang' table. You can move, or remove it, as needed.
            this.khoHangTableAdapter.Fill(this.vlxdDataSet.KhoHang);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
