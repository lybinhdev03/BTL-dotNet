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
    public partial class FBaoCaoNCC : Form
    {
        public FBaoCaoNCC()
        {
            InitializeComponent();
        }

        private void FBaoCaoNCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vlxdDataSet.NhaCungCap' table. You can move, or remove it, as needed.
            this.nhaCungCapTableAdapter.Fill(this.vlxdDataSet.NhaCungCap);

            this.reportViewer1.RefreshReport();
        }
    }
}
