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
    public partial class FBaoCaoNV : Form
    {
        public FBaoCaoNV()
        {
            InitializeComponent();
        }

        private void FBaoCaoNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vlxdDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.vlxdDataSet.NhanVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
