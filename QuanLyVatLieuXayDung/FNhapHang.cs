using System;
using System.Collections;
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
    public partial class FNhapHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";

        public FNhapHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadDataNCC();
            LoadDataHH();
            txt_idncc.ReadOnly = true;
            txt_namencc.ReadOnly = true;
            txt_sdtncc.ReadOnly = true;
            txt_idhh.ReadOnly = true;
            txt_namehh.ReadOnly = true;
            txt_dvhh.ReadOnly = true;
            dataGridViewHangHoa.ReadOnly = true;
            dataGridViewNCC.ReadOnly = true;
        }

        private int currentMaHoaDonNhap = 0;

        private void LoadDataHH()
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

        private void LoadDataNCC()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhaCungCap";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewNCC.DataSource = dataTable;

                // Cài đặt các thuộc tính cho DataGridView
                dataGridViewNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewNCC.Columns["MaNhaCungCap"].HeaderText = "Mã";
                dataGridViewNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                dataGridViewNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dataGridViewNCC.Columns["SDT"].HeaderText = "SDT";
                dataGridViewNCC.Columns["Email"].HeaderText = "Email";

                // Cài đặt màu sắc và kiểu chữ
                dataGridViewNCC.BackgroundColor = System.Drawing.Color.LightGray;
                dataGridViewNCC.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridViewNCC.DefaultCellStyle.Font = new Font("Arial", 10);

                // Cài đặt chế độ chọn
                dataGridViewNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ngăn chỉnh sửa tất cả các cột
                foreach (DataGridViewColumn column in dataGridViewNCC.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }
        private void FNhapHang_Load(object sender, EventArgs e)
        {
            // Đảm bảo DataGridView có các cột
            dataGridViewCthdn.Columns.Clear();
            dataGridViewCthdn.Columns.Add("MaHangHoa", "Mã Hàng Hóa");
            dataGridViewCthdn.Columns.Add("SoLuong", "Số Lượng");
            dataGridViewCthdn.Columns.Add("DonGiaNhap", "Đơn Giá Nhập");
            dataGridViewCthdn.Columns.Add("ThanhTien", "Thành Tiền");
            // Cài đặt các thuộc tính cho DataGridView
            dataGridViewCthdn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cài đặt màu sắc và kiểu chữ
            dataGridViewCthdn.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCthdn.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewCthdn.DefaultCellStyle.Font = new Font("Arial", 10);

            // Cài đặt chế độ chọn
            dataGridViewCthdn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ngăn chỉnh sửa tất cả các cột
            foreach (DataGridViewColumn column in dataGridViewCthdn.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewNCC.Rows[e.RowIndex];
                txt_idncc.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                txt_namencc.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txt_sdtncc.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        private void dataGridViewHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.Rows[e.RowIndex];
                txt_idhh.Text = row.Cells["MaHangHoa"].Value.ToString();
                txt_namehh.Text = row.Cells["TenSanPham"].Value.ToString();
                txt_dvhh.Text = row.Cells["DonVi"].Value.ToString();
                txt_gianhap.Text = row.Cells["Gia"].Value.ToString();
            }
        }


        private void TaoHoaDonNhap()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (string.IsNullOrEmpty(txt_idncc.Text) || string.IsNullOrEmpty(txt_namencc.Text) || string.IsNullOrEmpty(txt_sdtncc.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = "INSERT INTO HoaDonNhap (MaNhaCungCap, NgayNhap, TongTien) OUTPUT INSERTED.MaHoaDonNhap VALUES (@MaNhaCungCap, @NgayNhap, 0)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhaCungCap", int.Parse(txt_idncc.Text));
                        cmd.Parameters.AddWithValue("@NgayNhap", DateTime.Now);

                        currentMaHoaDonNhap = (int)cmd.ExecuteScalar(); // Lưu mã hóa đơn mới tạo

                        txt_information.Text = $"Mã hóa đơn: {currentMaHoaDonNhap}" + Environment.NewLine;
                        txt_information.Text += $"Nhà cung cấp: {txt_namencc.Text}" + Environment.NewLine;
                        txt_information.Text += "Ngày nhập: " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine;
                        dataGridViewCthdn.Rows.Clear(); // Xóa dữ liệu cũ nếu có
                    }               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ThemChiTietHoaDonNhap()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Thêm chi tiết hóa đơn nhập
                string insertDetailQuery = "INSERT INTO ChiTietHoaDonNhap (MaHoaDonNhap, MaHangHoa, SoLuong, DonGiaNhap) VALUES (@MaHoaDonNhap, @MaHangHoa, @SoLuong, @DonGiaNhap)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDonNhap", currentMaHoaDonNhap);
                        cmd.Parameters.AddWithValue("@MaHangHoa", int.Parse(txt_idhh.Text));
                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txt_sl.Text));
                        cmd.Parameters.AddWithValue("@DonGiaNhap", float.Parse(txt_gianhap.Text));

                        cmd.ExecuteNonQuery();
                    }
                    // Thêm dữ liệu vào DataGridView
                    float thanhTien = int.Parse(txt_sl.Text) * float.Parse(txt_gianhap.Text);
                    dataGridViewCthdn.Rows.Add(txt_idhh.Text, txt_sl.Text, txt_gianhap.Text, thanhTien);


                    // Cập nhật tổng tiền cho HoaDonNhap
                    CapNhatTongTienHoaDon(conn);
                    UpdateKhoHang(int.Parse(txt_idhh.Text), int.Parse(txt_sl.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng xem lại dữ liệu nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
        private void UpdateKhoHang(int maHangHoa, int soLuong)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // Cập nhật số lượng trong KhoHang
                    command.CommandText = "UPDATE KhoHang SET SoLuong = SoLuong + @SoLuong WHERE MaHangHoa = @MaHangHoa";
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có bản ghi nào được cập nhật không
                    if (rowsAffected > 0)
                    {
                        // Nếu có, xác nhận giao dịch
                        transaction.Commit();
                        MessageBox.Show("Cập nhật thành công.");
                    }
                    else
                    {
                        // Nếu không có bản ghi nào được cập nhật, hủy giao dịch
                        transaction.Rollback();
                        MessageBox.Show("Không tìm thấy mặt hàng với mã: " + maHangHoa);
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi xảy ra, hủy giao dịch
                    transaction.Rollback();
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
        private void CapNhatTongTienHoaDon(SqlConnection conn)
        {
            // Tính tổng tiền mới
            string totalQuery = "SELECT SUM(SoLuong * DonGiaNhap) FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap = @MaHoaDonNhap";
            using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaHoaDonNhap", currentMaHoaDonNhap);

                // Kiểm tra và xử lý giá trị null từ SUM
                object result = cmd.ExecuteScalar();
                decimal tongTien = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0m;

                // Cập nhật tổng tiền vào HoaDonNhap
                string updateTotalQuery = "UPDATE HoaDonNhap SET TongTien = @TongTien WHERE MaHoaDonNhap = @MaHoaDonNhap";
                using (SqlCommand updateCmd = new SqlCommand(updateTotalQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@TongTien", tongTien);
                    updateCmd.Parameters.AddWithValue("@MaHoaDonNhap", currentMaHoaDonNhap);
                    updateCmd.ExecuteNonQuery();
                }
                // Cập nhật thông tin hóa đơn lên TextBox              
                txt_information.Text = $"Mã hóa đơn: {currentMaHoaDonNhap}" + Environment.NewLine;
                txt_information.Text += $"Nhà cung cấp: {txt_namencc.Text}" + Environment.NewLine;
                txt_information.Text += "Ngày nhập: " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine;
                txt_information.Text += $"Tổng tiền: {tongTien}" + Environment.NewLine;
            }
        }


        private void btn_addhdn_Click(object sender, EventArgs e)
        {
            TaoHoaDonNhap();
            if (currentMaHoaDonNhap != 0)
            {
                MessageBox.Show("Hóa đơn nhập được tạo thành công với mã: " + currentMaHoaDonNhap);
            }
            
        }

        private void btn_addcthdn_Click(object sender, EventArgs e)
        {
            if (currentMaHoaDonNhap == 0)
            {
                MessageBox.Show("Vui lòng tạo hóa đơn trước khi thêm chi tiết !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ThemChiTietHoaDonNhap();
                //MessageBox.Show("Chi tiết hóa đơn nhập đã được thêm.");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Reset thông tin hóa đơn
            currentMaHoaDonNhap = 0;
            txt_information.Text = "";
            dataGridViewCthdn.Rows.Clear();
            txt_idncc.Clear();
            txt_namencc.Clear();
            txt_sdtncc.Clear();
            txt_namehh.Clear();
            txt_dvhh.Clear();
            txt_idhh.Clear();
            txt_sl.Clear();
            txt_gianhap.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
