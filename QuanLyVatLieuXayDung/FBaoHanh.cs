using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatLieuXayDung
{
    public partial class FBaoHanh : Form
    {
        string maBH = "";
        string maKH = "";
        DateTime today = DateTime.Now.Date;
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";
        public FBaoHanh()
        {
            InitializeComponent();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void rd_id_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_name_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FBaoHanh_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BaoHanh";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                table.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                table.Columns["MaBaoHanh"].HeaderText = "Mã bảo hành";
                table.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
                table.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                table.Columns["NgayBaoHanh"].HeaderText = "Ngày bảo hành";
                table.Columns["ThoiGianBaoHanh"].HeaderText = "Hạn bao hành(Tháng)";

                // Cài đặt màu sắc và kiểu chữ
                table.BackgroundColor = System.Drawing.Color.LightGray;
                table.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                table.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in table.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            sqlBH("INSERT INTO BaoHanh (MaHangHoa,NgayBaoHanh,ThoiGianBaoHanh,MaKhachHang) VALUES (@1,@2,@3,@4)");
        }
        private void sqlBH(string sql)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@1", txt_mahh.Text);
                        cmd.Parameters.AddWithValue("@2", today);

                        cmd.Parameters.AddWithValue("@3", int.Parse(txt_hanBH.Text));
                        cmd.Parameters.AddWithValue("@4", int.Parse(txt_makh.Text));


                        cmd.ExecuteNonQuery();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng xem lại dữ liệu nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            sqlBH($"UPDATE BaoHanh SET MaHangHoa = @1, NgayBaoHanh = @2, ThoiGianBaoHanh= @3, MaKhachHang =@4  WHERE MaBaoHanh = {maBH}");
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy dòng được click
                DataGridViewRow row = table.Rows[e.RowIndex];

                // Lấy dữ liệu từ một ô bất kỳ, ví dụ từ cột 0
                maBH = row.Cells["MaBaoHanh"].Value.ToString();
                string maHangHoa = row.Cells["MaHangHoa"].Value.ToString(); // Lấy giá trị từ cột "MaHangHoa"
                DateTime ngayBaoHanh = Convert.ToDateTime(row.Cells["NgayBaoHanh"].Value); // Lấy giá trị từ cột "NgayBaoHanh"
                int thoiGianBaoHanh = Convert.ToInt32(row.Cells["ThoiGianBaoHanh"].Value); // Lấy giá trị từ cột "ThoiGianBaoHanh"
                maKH = row.Cells["MaKhachHang"].Value.ToString();

                MessageBox.Show($"Mã bảo hành: {maBH},Mã hàng hóa: {maHangHoa}, Ngày bảo hành: {ngayBaoHanh}, Thời gian bảo hành: {thoiGianBaoHanh} tháng");

                // Hoặc bạn có thể gán dữ liệu vào các TextBox để sửa
                txt_mahh.Text = maHangHoa;
                txt_hanBH.Text = thoiGianBaoHanh.ToString();
                txt_makh.Text = maKH.ToString();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Cần chỉ rõ tên bảng. Ví dụ: bảng là BaoHanh
            string sql = "DELETE FROM BaoHanh WHERE MaBaoHanh = @maBH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm tham số @maBH vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@maBH", maBH);

                        // Thực thi lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Kiểm tra xem có xóa dòng nào không
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã bảo hành để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_mahh.Clear();
            txt_makh.Clear();
            txt_hanBH.Clear();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (rd_id.Checked)
            {
                // Kiểm tra giá trị của maBH
                if (!string.IsNullOrEmpty(txt_search.Text))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Sử dụng tham số để tránh SQL Injection
                        string query = "SELECT * FROM BaoHanh WHERE MaBaoHanh = @maBH";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Thêm tham số vào lệnh truy vấn
                        adapter.SelectCommand.Parameters.AddWithValue("@maBH", txt_search.Text);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        table.DataSource = dataTable;

                        // Cài đặt các thuộc tính cho DataGridView
                        table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        table.Columns["MaBaoHanh"].HeaderText = "Mã bảo hành";
                        table.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
                        table.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                        table.Columns["NgayBaoHanh"].HeaderText = "Ngày bảo hành";
                        table.Columns["ThoiGianBaoHanh"].HeaderText = "Hạn bảo hành (Tháng)";

                        // Cài đặt màu sắc và kiểu chữ
                        table.BackgroundColor = System.Drawing.Color.LightGray;
                        table.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        table.DefaultCellStyle.Font = new Font("Arial", 10);

                        // Cài đặt chế độ chọn
                        table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        // Ngăn chỉnh sửa tất cả các cột
                        foreach (DataGridViewColumn column in table.Columns)
                        {
                            column.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã bảo hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (rd_idKH.Checked)
            {
                // Kiểm tra giá trị của maKH
                if (!string.IsNullOrEmpty(txt_search.Text))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Sử dụng tham số để tránh SQL Injection
                        string query = "SELECT * FROM BaoHanh WHERE MaKhachHang = @maKH";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Thêm tham số vào lệnh truy vấn
                        adapter.SelectCommand.Parameters.AddWithValue("@maKH", txt_search.Text);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        table.DataSource = dataTable;

                        // Cài đặt các thuộc tính cho DataGridView
                        table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        table.Columns["MaBaoHanh"].HeaderText = "Mã bảo hành";
                        table.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
                        table.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                        table.Columns["NgayBaoHanh"].HeaderText = "Ngày bảo hành";
                        table.Columns["ThoiGianBaoHanh"].HeaderText = "Hạn bảo hành (Tháng)";

                        // Cài đặt màu sắc và kiểu chữ
                        table.BackgroundColor = System.Drawing.Color.LightGray;
                        table.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        table.DefaultCellStyle.Font = new Font("Arial", 10);

                        // Cài đặt chế độ chọn
                        table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        // Ngăn chỉnh sửa tất cả các cột
                        foreach (DataGridViewColumn column in table.Columns)
                        {
                            column.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }
    }
            
}
