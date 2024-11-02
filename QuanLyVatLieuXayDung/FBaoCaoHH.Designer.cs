namespace QuanLyVatLieuXayDung
{
    partial class FBaoCaoHH
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.khoHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vlxdDataSet = new QuanLyVatLieuXayDung.vlxdDataSet();
            this.dHangHoaxsdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoHangTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.KhoHangTableAdapter();
            this.hangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.HangHoaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vlxdDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dHangHoaxsdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // khoHangBindingSource
            // 
            this.khoHangBindingSource.DataMember = "KhoHang";
            this.khoHangBindingSource.DataSource = this.vlxdDataSet;
            // 
            // vlxdDataSet
            // 
            this.vlxdDataSet.DataSetName = "vlxdDataSet";
            this.vlxdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khoHangTableAdapter
            // 
            this.khoHangTableAdapter.ClearBeforeFill = true;
            // 
            // hangHoaBindingSource
            // 
            this.hangHoaBindingSource.DataMember = "HangHoa";
            this.hangHoaBindingSource.DataSource = this.vlxdDataSet;
            // 
            // hangHoaTableAdapter
            // 
            this.hangHoaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.hangHoaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyVatLieuXayDung.ReportHangHoa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1182, 553);
            this.reportViewer1.TabIndex = 0;
            // 
            // vlxdDataSetBindingSource
            // 
            this.vlxdDataSetBindingSource.DataSource = this.vlxdDataSet;
            this.vlxdDataSetBindingSource.Position = 0;
            // 
            // hangHoaBindingSource1
            // 
            this.hangHoaBindingSource1.DataMember = "HangHoa";
            this.hangHoaBindingSource1.DataSource = this.vlxdDataSetBindingSource;
            // 
            // FBaoCaoHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FBaoCaoHH";
            this.Text = "FBaoCaoHH";
            this.Load += new System.EventHandler(this.FBaoCaoHH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dHangHoaxsdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dHangHoaxsdBindingSource;
        
        private vlxdDataSet vlxdDataSet;
        private System.Windows.Forms.BindingSource khoHangBindingSource;
        private vlxdDataSetTableAdapters.KhoHangTableAdapter khoHangTableAdapter;
        private System.Windows.Forms.BindingSource hangHoaBindingSource;
        private vlxdDataSetTableAdapters.HangHoaTableAdapter hangHoaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vlxdDataSetBindingSource;
        private System.Windows.Forms.BindingSource hangHoaBindingSource1;
    }
}