﻿namespace QuanLyVatLieuXayDung
{
    partial class FBaoCaoKho
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vlxdDataSet = new QuanLyVatLieuXayDung.vlxdDataSet();
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.KhachHangTableAdapter();
            this.fKBaoHanhMaKhach52593CB8BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baoHanhTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.BaoHanhTableAdapter();
            this.khoHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoHangTableAdapter = new QuanLyVatLieuXayDung.vlxdDataSetTableAdapters.KhoHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKBaoHanhMaKhach52593CB8BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.khoHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyVatLieuXayDung.ReportKhoHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1572, 652);
            this.reportViewer1.TabIndex = 0;
            // 
            // vlxdDataSet
            // 
            this.vlxdDataSet.DataSetName = "vlxdDataSet";
            this.vlxdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khachHangBindingSource
            // 
            this.khachHangBindingSource.DataMember = "KhachHang";
            this.khachHangBindingSource.DataSource = this.vlxdDataSet;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // fKBaoHanhMaKhach52593CB8BindingSource
            // 
            this.fKBaoHanhMaKhach52593CB8BindingSource.DataMember = "FK__BaoHanh__MaKhach__52593CB8";
            this.fKBaoHanhMaKhach52593CB8BindingSource.DataSource = this.khachHangBindingSource;
            // 
            // baoHanhTableAdapter
            // 
            this.baoHanhTableAdapter.ClearBeforeFill = true;
            // 
            // khoHangBindingSource
            // 
            this.khoHangBindingSource.DataMember = "KhoHang";
            this.khoHangBindingSource.DataSource = this.vlxdDataSet;
            // 
            // khoHangTableAdapter
            // 
            this.khoHangTableAdapter.ClearBeforeFill = true;
            // 
            // FBaoCaoKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1572, 652);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FBaoCaoKho";
            this.Text = "FBaoCaoKho";
            this.Load += new System.EventHandler(this.FBaoCaoKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vlxdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKBaoHanhMaKhach52593CB8BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private vlxdDataSet vlxdDataSet;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        private vlxdDataSetTableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private System.Windows.Forms.BindingSource fKBaoHanhMaKhach52593CB8BindingSource;
        private vlxdDataSetTableAdapters.BaoHanhTableAdapter baoHanhTableAdapter;
        private System.Windows.Forms.BindingSource khoHangBindingSource;
        private vlxdDataSetTableAdapters.KhoHangTableAdapter khoHangTableAdapter;
    }
}