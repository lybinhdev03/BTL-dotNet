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
    public partial class FHDChiTietXuatHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";
        private int maHoaDonXuat;
        public FHDChiTietXuatHang(int maHoaDonXuat)
        {
            InitializeComponent();
            
            this.maHoaDonXuat = maHoaDonXuat;
            LoadChiTiet();
            txt_idhd.ReadOnly = true;
            txt_giaTien.ReadOnly = true;
            lb_idhd1.Text = "Chi tiết hóa đơn xuất hàng " + maHoaDonXuat;
        }

        private void FHDChiTietXuatHang_Load(object sender, EventArgs e)
        {
        }

        private void LoadChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                                SELECT 
                                    c.MaHoaDonXuat,
                                    h.MaHangHoa,
                                    h.TenSanPham,
                                    c.SoLuong,
                                    c.DonGia,
                                    (c.SoLuong * c.DonGia) AS ThanhTien
                                FROM 
                                    ChiTietHoaDonXuat c
                                JOIN 
                                    HangHoa h ON c.MaHangHoa = h.MaHangHoa
                                WHERE 
                                    c.MaHoaDonXuat = @MaHoaDonXuat";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewcthdxh.DataSource = dt; // Hiển thị lên DataGridView

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewcthdxh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewcthdxh.Columns["MaHoaDonXuat"].HeaderText = "Mã Hóa Đơn";
                dataGridViewcthdxh.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dataGridViewcthdxh.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                dataGridViewcthdxh.Columns["Soluong"].HeaderText = "Số Lượng";
                dataGridViewcthdxh.Columns["DonGia"].HeaderText = "Đơn giá";
                dataGridViewcthdxh.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                // Cài đặt màu sắc và kiểu chữ
                dataGridViewcthdxh.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewcthdxh.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewcthdxh.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewcthdxh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewcthdxh.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }
        
        private void ClearFields()
        {
            txt_idhd.Clear();
            txt_idhh.Clear();
            txt_sl.Clear();
            txt_giaTien.Clear();
            // Clear các ô khác nếu cần
        }

        private float GetDonGia(int maHangHoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Gia FROM HangHoa WHERE MaHangHoa = @MaHangHoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToSingle(result);
                }
                return -1; // Mã hàng không tồn tại
            }
        }

        private void UpdateTongTien(SqlConnection connection)
        {
            string updateTotalQuery = "UPDATE HoaDonXuat SET TongTien = (SELECT SUM(SoLuong * DonGia) FROM ChiTietHoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat) WHERE MaHoaDonXuat = @MaHoaDonXuat";
            using (SqlCommand updateTotalCommand = new SqlCommand(updateTotalQuery, connection))
            {
                updateTotalCommand.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                updateTotalCommand.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maHangHoa;
            int soLuong;

            // Kiểm tra dữ liệu đầu vào
            if (!int.TryParse(txt_idhh.Text, out maHangHoa))
            {
                MessageBox.Show("Mã hàng hóa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_sl.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float donGia = GetDonGia(maHangHoa); // Lấy giá từ bảng hàng hóa
            if (donGia == -1)
            {
                MessageBox.Show("Mã hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float thanhTien = donGia * soLuong;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT SoLuong FROM ChiTietHoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat AND MaHangHoa = @MaHangHoa";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                    checkCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);

                    object existingQty = checkCommand.ExecuteScalar();

                    if (existingQty != null) // Nếu mã hàng đã tồn tại
                    {
                        int existingSoLuong = Convert.ToInt32(existingQty);
                        // Cập nhật số lượng và thành tiền
                        int newSoLuong = existingSoLuong + soLuong;
                        thanhTien = donGia * newSoLuong; // Cập nhật lại thành tiền

                        string updateQuery = "UPDATE ChiTietHoaDonXuat SET SoLuong = @SoLuong, DonGia = @DonGia WHERE MaHoaDonXuat = @MaHoaDonXuat AND MaHangHoa = @MaHangHoa";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@SoLuong", newSoLuong);
                            updateCommand.Parameters.AddWithValue("@DonGia", donGia);
                            updateCommand.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                            updateCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else // Nếu mã hàng chưa tồn tại, thêm mới
                    {
                        string insertQuery = "INSERT INTO ChiTietHoaDonXuat (MaHoaDonXuat, MaHangHoa, SoLuong, DonGia) VALUES (@MaHoaDonXuat, @MaHangHoa, @SoLuong, @DonGia)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                            insertCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                            insertCommand.Parameters.AddWithValue("@SoLuong", soLuong);
                            insertCommand.Parameters.AddWithValue("@DonGia", donGia);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
                UpdateTongTien(connection);
            }
            LoadChiTiet();
            ClearFields();
        }

        private void dataGridViewcthdxh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewcthdxh.Rows[e.RowIndex];
                txt_idhd.Text = row.Cells["MaHoaDonXuat"].Value.ToString();
                txt_idhh.Text = row.Cells["MaHangHoa"].Value.ToString();
                txt_sl.Text = row.Cells["Soluong"].Value.ToString();
                txt_giaTien.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int maHangHoa;
            int soLuong;

            // Kiểm tra dữ liệu đầu vào
            if (!int.TryParse(txt_idhh.Text, out maHangHoa))
            {
                MessageBox.Show("Mã hàng hóa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_sl.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float donGia = GetDonGia(maHangHoa); // Lấy giá từ bảng hàng hóa
            if (donGia == -1)
            {
                MessageBox.Show("Mã hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Cập nhật số lượng và thành tiền cho hàng hóa
                string updateQuery = "UPDATE ChiTietHoaDonXuat SET SoLuong = @SoLuong, DonGia = @DonGia WHERE MaHoaDonXuat = @MaHoaDonXuat AND MaHangHoa = @MaHangHoa";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                    updateCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    updateCommand.Parameters.AddWithValue("@SoLuong", soLuong);
                    updateCommand.Parameters.AddWithValue("@DonGia", donGia);
                    updateCommand.ExecuteNonQuery();
                }

                // Cập nhật tổng tiền cho hóa đơn
                UpdateTongTien(connection);
            }

            LoadChiTiet();
            ClearFields();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewcthdxh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHangHoa = (int)dataGridViewcthdxh.CurrentRow.Cells["MaHangHoa"].Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ChiTietHoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat AND MaHangHoa = @MaHangHoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDonXuat", maHoaDonXuat);
                command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                command.ExecuteNonQuery();
                UpdateTongTien(connection);
            }

            LoadChiTiet();
            ClearFields();
        }
    }
}
