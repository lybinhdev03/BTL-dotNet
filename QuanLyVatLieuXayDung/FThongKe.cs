using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace QuanLyVatLieuXayDung
{

    public partial class FThongKe : Form
    {
        double total;
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";
        public FThongKe()
        {
            InitializeComponent();
        }

        private void FThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            string query = "SELECT * FROM HoaDonXuat WHERE NgayLap BETWEEN @from AND @to";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
                    command.Parameters.Add("@to", SqlDbType.DateTime).Value = to;

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        table.DataSource = dataTable;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
            tinhDoanhThu();

        }
        public void tinhDoanhThu()
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            string query = "SELECT Sum(TongTien) FROM HoaDonXuat WHERE NgayLap BETWEEN @from AND @to";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
                    command.Parameters.Add("@to", SqlDbType.DateTime).Value = to;

                    try
                    {
                        connection.Open();
                        Object rs = command.ExecuteScalar();
                        total = (double)rs;
                        txt_TongDoanhThu.Text = total.ToString();
                        txt_tienLai.Text = (total*0.1).ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
        }
        

private void ExportToExcel(DataGridView dataGridView, string filePath,double a)
    {
        // Tạo một package Excel
        using (ExcelPackage excelPackage = new ExcelPackage())
        {
            // Tạo một worksheet
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            // Thêm tiêu đề cột
            for (int i = 1; i <= dataGridView.Columns.Count; i++)
            {
                worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
            }

            // Thêm dữ liệu vào các ô
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                }
            }
                int dataRowCount = dataGridView.Rows.Count + 2; // Dòng tiếp theo sau DataGridView data

                worksheet.Cells[dataRowCount, 1].Value = "Tổng doanh thu:";
                worksheet.Cells[dataRowCount, 2].Value = a;

                worksheet.Cells[dataRowCount + 1, 1].Value = "Lãi:";
                worksheet.Cells[dataRowCount + 1, 2].Value = a*0.1;

                

                // Lưu file Excel ra đường dẫn chỉ định
                FileInfo fi = new FileInfo(filePath);
            excelPackage.SaveAs(fi);
        }
    }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\bt.net\btl\data.xlsx";

            // Gọi hàm export
            ExportToExcel(table, filePath,total);

            MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
        }
    }
}
  
