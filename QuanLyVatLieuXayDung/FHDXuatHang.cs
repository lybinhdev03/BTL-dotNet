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
    public partial class FHDXuatHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        private readonly string connectionString = "Server=localhost,1433; Database=db_vlxd; User Id=sa; Password=@Khongbiet123;";
        public FHDXuatHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txt_idhd.ReadOnly = true;
            //txt_idkh.ReadOnly = true;
            txt_tongTien.ReadOnly = true;
            LoadData();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM HoaDonXuat";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewhdxh.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewhdxh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewhdxh.Columns["MaHoaDonXuat"].HeaderText = "Mã Hóa Đơn";
                dataGridViewhdxh.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dataGridViewhdxh.Columns["NgayLap"].HeaderText = "Ngày Đặt Hàng";
                dataGridViewhdxh.Columns["TongTien"].HeaderText = "Tổng Tiền";
                // Cài đặt màu sắc và kiểu chữ
                dataGridViewhdxh.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewhdxh.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewhdxh.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewhdxh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewhdxh.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }
        // Kiểm tra đầu vào hợp lệ
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txt_idhd.Text))
            {
                //MessageBox.Show("Vui lòng chọn Mã hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ClearTextBoxes()
        {
            txt_idhd.Text = string.Empty;
            txt_idkh.Text = string.Empty;
            txt_tongTien.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                int maHoaDonXuat = int.Parse(txt_idhd.Text);
                FHDChiTietXuatHang fctxh = new FHDChiTietXuatHang(maHoaDonXuat);
                fctxh.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void FHDXuatHang_Load(object sender, EventArgs e)
        {

        }

        // Hàm kiểm tra sự tồn tại của mã khách hàng
        private bool CheckMaKhachHangExists(int maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                int maKhachHang = int.Parse(txt_idkh.Text);

                // Kiểm tra mã khách hàng có tồn tại không
                if (!CheckMaKhachHangExists(maKhachHang))
                {
                    MessageBox.Show("Mã Khách Hàng không tồn tại. Vui lòng nhập mã hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE HoaDonXuat SET MaKhachHang = @MaKhachHang, NgayLap = @NgayLap WHERE MaHoaDonXuat = @MaHoaDonXuat";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDonXuat", int.Parse(txt_idhd.Text));
                    cmd.Parameters.AddWithValue("@MaKhachHang", int.Parse(txt_idkh.Text));
                    cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật hóa đơn xuất thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteHoaDonXuat(int maHoaDonXuat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa các chi tiết hóa đơn trước
                string deleteChiTietQuery = "DELETE FROM ChiTietHoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat";
                SqlCommand deleteChiTietCmd = new SqlCommand(deleteChiTietQuery, conn);
                deleteChiTietCmd.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                deleteChiTietCmd.ExecuteNonQuery();

                // Sau đó xóa hóa đơn xuất
                string deleteHoaDonQuery = "DELETE FROM HoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat";
                SqlCommand deleteHoaDonCmd = new SqlCommand(deleteHoaDonQuery, conn);
                deleteHoaDonCmd.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                deleteHoaDonCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xóa hóa đơn và chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DeleteHoaDonXuat(int.Parse(txt_idhd.Text));
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewhdxh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewhdxh.Rows[e.RowIndex];
                txt_idhd.Text = row.Cells["MaHoaDonXuat"].Value.ToString();
                txt_idkh.Text = row.Cells["MaKhachHang"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                txt_tongTien.Text = row.Cells["TongTien"].Value.ToString();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            LoadData();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn xuất cần tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string searchQuery = "SELECT * FROM HoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(searchQuery, connection);
                    command.Parameters.AddWithValue("@MaHoaDonXuat", int.Parse(txt_search.Text));
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewhdxh.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
    }
}
