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
    public partial class FKhachHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        private readonly string connectionString = "Server=localhost,1433; Database=db_vlxd; User Id=sa; Password=@Khongbiet123;"; //docker
        public FKhachHang()
        {
            InitializeComponent();
            LoadData();
            txt_id.ReadOnly = true;
            dataGridViewKhachHang.ReadOnly = true;
        }

        // Chức năng: Load lại dữ liệu và có chỉnh sửa giao diện bảng
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewKhachHang.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewKhachHang.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dataGridViewKhachHang.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                dataGridViewKhachHang.Columns["SDT"].HeaderText = "SDT";
                dataGridViewKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";

                // Cài đặt màu sắc và kiểu chữ
                dataGridViewKhachHang.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewKhachHang.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewKhachHang.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewKhachHang.Columns)
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
            txt_sdt.Text = string.Empty;
            txt_dc.Text = string.Empty;
        }

        // Chức năng: Bắt lỗi đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_sdt.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_dc.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Chức năng: Hiển thị dữ liệu lên textbox khi bấm vào bảng
        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewKhachHang.Rows[e.RowIndex];
                txt_id.Text = row.Cells["MaKhachHang"].Value.ToString();
                txt_name.Text = row.Cells["TenKhachHang"].Value.ToString();
                txt_sdt.Text = row.Cells["SDT"].Value.ToString();
                txt_dc.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Chức năng: Thêm khách hàng
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO KhachHang (TenKhachHang, SDT, DiaChi) VALUES (@tenkh, @sdt, @dc)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@tenkh", txt_name.Text);
                    command.Parameters.AddWithValue("@sdt", txt_sdt.Text);
                    command.Parameters.AddWithValue("@dc", txt_dc.Text);

                    connection.Open();
                    int rs = command.ExecuteNonQuery();
                    if (rs > 0)
                    {
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadData();
            }
        }

        // Chức năng: Cập nhật khách hàng theo mã
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE KhachHang SET TenKhachHang = @tenkh, SDT = @sdt, DiaChi = @dc WHERE MaKhachHang = @makh";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@makh", int.Parse(txt_id.Text));
                    command.Parameters.AddWithValue("@tenkh", txt_name.Text);
                    command.Parameters.AddWithValue("@sdt", txt_sdt.Text);
                    command.Parameters.AddWithValue("@dc", txt_dc.Text);

                    connection.Open();
                    int rs = command.ExecuteNonQuery();
                    if (rs > 0)
                    {
                        MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadData();
            }
        }

        // Chức năng: Xóa khách hàng theo mã
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM KhachHang WHERE MaKhachHang = @makh";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@makh", int.Parse(txt_id.Text));

                    connection.Open();
                    int rs = command.ExecuteNonQuery();
                    if (rs > 0)
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchQuery;
            if (rd_id.Checked)
            {
                searchQuery = "SELECT * FROM KhachHang WHERE MaKhachHang = @makh";
            }
            else if (rd_name.Checked)
            {
                searchQuery = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE @tenkh";
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
                    command.Parameters.AddWithValue("@makh", int.Parse(txt_search.Text));
                }
                else if (rd_name.Checked)
                {
                    command.Parameters.AddWithValue("@tenkh", "%" + txt_search.Text + "%");
                }

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewKhachHang.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
