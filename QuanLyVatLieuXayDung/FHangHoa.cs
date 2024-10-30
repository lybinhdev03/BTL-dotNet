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
    public partial class FHangHoa : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        private readonly string connectionString = "Server=localhost,1433; Database=db_vlxd; User Id=sa; Password=@Khongbiet123;";
        public FHangHoa()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadData(); 
            txt_id.ReadOnly = true;
            dataGridViewHangHoa.ReadOnly = true;
        }

        // Chức năng: Load lại dữ liệu và có chỉnh sửa giao diện bảng
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HangHoa";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewHangHoa.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewHangHoa.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dataGridViewHangHoa.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                dataGridViewHangHoa.Columns["DonVi"].HeaderText = "Đơn Vị";
                dataGridViewHangHoa.Columns["Gia"].HeaderText = "Giá (VNĐ)";

                // Cài đặt màu sắc và kiểu chữ
                dataGridViewHangHoa.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewHangHoa.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewHangHoa.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewHangHoa.Columns)
                {
                    column.ReadOnly = true; 
                }
            }
        }


        // Chức năng: Clear hết textbox
        private void ClearTextBoxes()
        {
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_dv.Text = string.Empty;
            txt_price.Text = string.Empty;
        }

        // Chức năng: Bắt lỗi đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Tên hàng hóa không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_dv.Text))
            {
                MessageBox.Show("Đơn vị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(txt_price.Text, out float gia) || gia < 0)
            {
                MessageBox.Show("Giá phải là một số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Chức năng: Hiển thị dữ liệu lên textbox khi bấm vào bảng
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.Rows[e.RowIndex];
                txt_id.Text = row.Cells["MaHangHoa"].Value.ToString();
                txt_name.Text = row.Cells["TenSanPham"].Value.ToString();
                txt_dv.Text = row.Cells["DonVi"].Value.ToString();
                txt_price.Text = row.Cells["Gia"].Value.ToString();
            }
        }

        // Chức năng: Thêm hàng hóa
        private void btn_add_Click(object sender, EventArgs e)
        {           
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO HangHoa (TenSanPham, DonVi, Gia) VALUES (@tenSanPham, @donVi, @gia)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@tenSanPham", txt_name.Text);
                    command.Parameters.AddWithValue("@donVi", txt_dv.Text);
                    command.Parameters.AddWithValue("@gia", float.Parse(txt_price.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        // Chức năng: Cập nhật hàng hóa theo mã
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE HangHoa SET TenSanPham = @tenSanPham, DonVi = @donVi, Gia = @gia WHERE MaHangHoa = @maHangHoa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maHangHoa", int.Parse(txt_id.Text));
                    command.Parameters.AddWithValue("@tenSanPham", txt_name.Text);
                    command.Parameters.AddWithValue("@donVi", txt_dv.Text);
                    command.Parameters.AddWithValue("@gia", float.Parse(txt_price.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        // Chức năng: Xóa hàng hóa theo mã
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM HangHoa WHERE MaHangHoa = @maHangHoa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maHangHoa", int.Parse(txt_id.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                LoadData();
                ClearTextBoxes();
            }
        }

        // Chức năng: làm mới dữ liệu
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            LoadData();
        }

        private void FHangHoa_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // Chức năng: Tìm kiếm theo mã | tên
        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchQuery;
            if (rd_id.Checked)
            {
                searchQuery = "SELECT * FROM HangHoa WHERE MaHangHoa = @MaHangHoa";
            }
            else if (rd_name.Checked)
            {
                searchQuery = "SELECT * FROM HangHoa WHERE TenSanPham LIKE @TenSanPham";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cách tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(searchQuery, connection);
                if (rd_id.Checked)
                {
                    command.Parameters.AddWithValue("@MaHangHoa", int.Parse(txt_search.Text)); 
                }
                else if (rd_name.Checked)
                {
                    command.Parameters.AddWithValue("@TenSanPham", "%" + txt_search.Text + "%");
                }

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewHangHoa.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
