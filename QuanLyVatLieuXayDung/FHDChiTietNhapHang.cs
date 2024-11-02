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
    public partial class FHDChiTietNhapHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";
        private int maHoaDonNhap;
        public FHDChiTietNhapHang(int maHoaDonNhap)
        {
            InitializeComponent();
            
            this.maHoaDonNhap = maHoaDonNhap;
            LoadChiTiet();
            txt_idhd.ReadOnly = true;
            txt_giaTien.ReadOnly = true;
            lb_idhd2.Text = "Chi tiết hóa đơn nhập hàng " + maHoaDonNhap;
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
            string updateTotalQuery = "UPDATE HoaDonNhap SET TongTien = (SELECT SUM(SoLuong * DonGiaNhap) FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap) WHERE MaHoaDonNhap = @MaHoaDonNhap";
            using (SqlCommand updateTotalCommand = new SqlCommand(updateTotalQuery, connection))
            {
                updateTotalCommand.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                updateTotalCommand.ExecuteNonQuery();
            }
        }

        // Load data
        private void LoadChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                                SELECT 
                                    c.MaHoaDonNhap,
                                    h.MaHangHoa,
                                    h.TenSanPham,
                                    c.SoLuong,
                                    c.DonGiaNhap,
                                    (c.SoLuong * c.DonGiaNhap) AS ThanhTien
                                FROM 
                                    ChiTietHoaDonNhap c
                                JOIN 
                                    HangHoa h ON c.MaHangHoa = h.MaHangHoa
                                WHERE 
                                    c.MaHoaDonNhap = @MaHoaDonNhap";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewcthdnh.DataSource = dt; // Hiển thị lên DataGridView

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewcthdnh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewcthdnh.Columns["maHoaDonNhap"].HeaderText = "Mã Hóa Đơn";
                dataGridViewcthdnh.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dataGridViewcthdnh.Columns["TenSanPham"].HeaderText = "Tên Hàng Hóa";
                dataGridViewcthdnh.Columns["Soluong"].HeaderText = "Số Lượng";
                dataGridViewcthdnh.Columns["DonGiaNhap"].HeaderText = "Đơn giá";
                dataGridViewcthdnh.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                // Cài đặt màu sắc và kiểu chữ
                dataGridViewcthdnh.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewcthdnh.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewcthdnh.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewcthdnh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewcthdnh.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void FHDChiTietNhapHang_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewcthdxh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewcthdnh.Rows[e.RowIndex];
                txt_idhd.Text = row.Cells["MaHoaDonNhap"].Value.ToString();
                txt_idhh.Text = row.Cells["MaHangHoa"].Value.ToString();
                txt_sl.Text = row.Cells["Soluong"].Value.ToString();
                txt_giaTien.Text = row.Cells["DonGiaNhap"].Value.ToString();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
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
                string checkQuery = "SELECT SoLuong FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap AND MaHangHoa = @MaHangHoa";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                    checkCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);

                    object existingQty = checkCommand.ExecuteScalar();

                    if (existingQty != null) // Nếu mã hàng đã tồn tại
                    {
                        int existingSoLuong = Convert.ToInt32(existingQty);
                        // Cập nhật số lượng và thành tiền
                        int newSoLuong = existingSoLuong + soLuong;
                        thanhTien = donGia * newSoLuong; // Cập nhật lại thành tiền

                        string updateQuery = "UPDATE ChiTietHoaDonNhap SET SoLuong = @SoLuong, DonGiaNhap = @DonGiaNhap WHERE MaHoaDonNhap = @MaHoaDonNhap AND MaHangHoa = @MaHangHoa";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@SoLuong", newSoLuong);
                            updateCommand.Parameters.AddWithValue("@DonGiaNhap", donGia);
                            updateCommand.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                            updateCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else // Nếu mã hàng chưa tồn tại, thêm mới
                    {
                        string insertQuery = "INSERT INTO ChiTietHoaDonNhap (MaHoaDonNhap, MaHangHoa, SoLuong, DonGiaNhap) VALUES (@MaHoaDonNhap, @MaHangHoa, @SoLuong, @DonGiaNhap)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                            insertCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                            insertCommand.Parameters.AddWithValue("@SoLuong", soLuong);
                            insertCommand.Parameters.AddWithValue("@DonGiaNhap", donGia);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
                UpdateTongTien(connection);
            }
            LoadChiTiet();
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
                string updateQuery = "UPDATE ChiTietHoaDonNhap SET SoLuong = @SoLuong, DonGiaNhap = @DonGiaNhap WHERE MaHoaDonNhap = @MaHoaDonNhap AND MaHangHoa = @MaHangHoa";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                    updateCommand.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    updateCommand.Parameters.AddWithValue("@SoLuong", soLuong);
                    updateCommand.Parameters.AddWithValue("@DonGiaNhap", donGia);
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
            if (dataGridViewcthdnh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHangHoa = (int)dataGridViewcthdnh.CurrentRow.Cells["MaHangHoa"].Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap AND MaHangHoa = @MaHangHoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDonNhap", maHoaDonNhap);
                command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                command.ExecuteNonQuery();
                UpdateTongTien(connection);
            }

            LoadChiTiet();
            ClearFields();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
