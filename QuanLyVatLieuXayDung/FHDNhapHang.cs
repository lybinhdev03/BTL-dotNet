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
    public partial class FHDNhapHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        private readonly string connectionString = "Server=localhost,1433; Database=db_vlxd; User Id=sa; Password=@Khongbiet123;";
        public FHDNhapHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txt_idhd.ReadOnly = true;
            txt_tongTien.ReadOnly = true;
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM HoaDonNhap";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewhdnh.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewhdnh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewhdnh.Columns["MaHoaDonNhap"].HeaderText = "Mã Hóa Đơn";
                dataGridViewhdnh.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                dataGridViewhdnh.Columns["NgayNhap"].HeaderText = "Ngày Nhập Hàng";
                dataGridViewhdnh.Columns["TongTien"].HeaderText = "Tổng Tiền";
                // Cài đặt màu sắc và kiểu chữ
                dataGridViewhdnh.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewhdnh.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewhdnh.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewhdnh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewhdnh.Columns)
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


        // Hàm kiểm tra sự tồn tại của mã ncc
        private bool CheckMaNCCExists(int maNcc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNhaCungCap = @maNcc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maNcc", maNcc);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        //Clear text
        private void ClearTextBoxes()
        {
            txt_idhd.Text = string.Empty;
            txt_idncc.Text = string.Empty;
            txt_tongTien.Text = string.Empty;
        }

        private void btn_chiTiet_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                int maHoaDonNhap = int.Parse(txt_idhd.Text);
                FHDChiTietNhapHang fctnh = new FHDChiTietNhapHang(maHoaDonNhap);
                fctnh.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewhdnh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewhdnh.Rows[e.RowIndex];
                txt_idhd.Text = row.Cells["MaHoaDonNhap"].Value.ToString();
                txt_idncc.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
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
                MessageBox.Show("Vui lòng nhập mã hóa đơn nhập cần tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string searchQuery = "SELECT * FROM HoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(searchQuery, connection);
                    command.Parameters.AddWithValue("@MaHoaDonNhap", int.Parse(txt_search.Text));
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewhdnh.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Chức năng: cập nhật đơn hàng
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                int maNCC = int.Parse(txt_idncc.Text);

                // Kiểm tra mã khách hàng có tồn tại không
                if (!CheckMaNCCExists(maNCC))
                {
                    MessageBox.Show("Mã Nhà Cung Cấp không tồn tại. Vui lòng nhập mã hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE HoaDonNhap SET MaNhaCungCap = @MaNhaCungCap, NgayNhap = @NgayNhap WHERE MaHoaDonNhap = @MaHoaDonNhap";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDonNhap", int.Parse(txt_idhd.Text));
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", int.Parse(txt_idncc.Text));
                    cmd.Parameters.AddWithValue("@NgayNhap", dateTimePicker1.Value);

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

        private void DeleteHoaDonNhap(int maHoaDonNhap)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa các chi tiết hóa đơn trước
                string deleteChiTietQuery = "DELETE FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap";
                SqlCommand deleteChiTietCmd = new SqlCommand(deleteChiTietQuery, conn);
                deleteChiTietCmd.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                deleteChiTietCmd.ExecuteNonQuery();

                // Sau đó xóa hóa đơn xuất
                string deleteHoaDonQuery = "DELETE FROM HoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap";
                SqlCommand deleteHoaDonCmd = new SqlCommand(deleteHoaDonQuery, conn);
                deleteHoaDonCmd.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                deleteHoaDonCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xóa hóa đơn và chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DeleteHoaDonNhap(int.Parse(txt_idhd.Text));
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
