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
    public partial class FDatHang : Form
    {
        // Dùng cái này khi làm với sql server (đổi user, pass)
        //private readonly string connectionString = "Data Source=your_server_name;Initial Catalog=vlxd;User ID=;Password=;";
        private readonly string connectionString = "Server=localhost,1433; Database=db_vlxd; User Id=sa; Password=@Khongbiet123;";
        public FDatHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadDataHH();
            txt_idhh.ReadOnly = true;
            txt_namehh.ReadOnly = true;
            txt_dvhh.ReadOnly = true;
            txt_giatien.ReadOnly = true;
            dataGridViewHangHoa.ReadOnly = true;
        }

        private int currentMaHoaDonXuat = 0;
        private int currentMaKhachHang = 0;

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void DatHang_Resize(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNameKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtThongtin_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // Chức năng: Clear hết textbox
        private void ClearTextBoxes()
        {
            txt_idhh.Text = string.Empty;
            txt_namehh.Text = string.Empty;
            txt_dvhh.Text = string.Empty;
            txt_giatien.Text = string.Empty;
        }
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
        private void dataGridViewHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.Rows[e.RowIndex];
                txt_idhh.Text = row.Cells["MaHangHoa"].Value.ToString();
                txt_namehh.Text = row.Cells["TenSanPham"].Value.ToString();
                txt_dvhh.Text = row.Cells["DonVi"].Value.ToString();
                txt_giatien.Text = row.Cells["Gia"].Value.ToString();
            }
        }

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

        private void btn_resetSearch_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            LoadDataHH();
        }
        private void TaoHoaDonXuat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Bước 1: Thêm khách hàng mới
                if (string.IsNullOrEmpty(txt_namekh.Text) || string.IsNullOrEmpty(txt_sdt.Text) || string.IsNullOrEmpty(txt_dc.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string tenKhachHang = txt_namekh.Text;
                    string sdt = txt_sdt.Text;
                    string diaChi = txt_dc.Text;

                    // Thêm khách hàng và lấy mã khách hàng vừa tạo
                    string insertCustomerQuery = "INSERT INTO KhachHang (TenKhachHang, SDT, DiaChi) OUTPUT INSERTED.MaKhachHang VALUES (@TenKhachHang, @SDT, @DiaChi)";
                    using (SqlCommand cmd = new SqlCommand(insertCustomerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                        // Lấy mã khách hàng vừa tạo
                        currentMaKhachHang = (int)cmd.ExecuteScalar();
                        //MessageBox.Show("Thêm khách hàng thành công! Mã khách hàng: " + currentMaKhachHang);
                    }

                    // Bước 2: Tạo hóa đơn xuất
                    DateTime ngayLap = DateTime.Now;
                    float tongTien = 0; // Khởi tạo tổng tiền ban đầu là 0, sẽ cập nhật sau khi thêm chi tiết

                    string insertInvoiceQuery = "INSERT INTO HoaDonXuat (MaKhachHang, NgayLap, TongTien) OUTPUT INSERTED.MaHoaDonXuat VALUES (@MaKhachHang, @NgayLap, @TongTien)";
                    using (SqlCommand cmd = new SqlCommand(insertInvoiceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", currentMaKhachHang);
                        cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmd.Parameters.AddWithValue("@TongTien", tongTien);

                        // Lấy mã hóa đơn xuất vừa tạo
                        currentMaHoaDonXuat = (int)cmd.ExecuteScalar();
                        MessageBox.Show("Tạo hóa đơn xuất thành công! Mã hóa đơn xuất: " + currentMaHoaDonXuat);
                    }

                    // Hiển thị mã hóa đơn vào TextBox hoặc Label cho người dùng biết
                    txt_information.Text = $"Mã hóa đơn xuất: {currentMaHoaDonXuat}" + Environment.NewLine;
                    txt_information.Text += $"Tên khách hàng: {txt_namekh.Text}" + Environment.NewLine;
                    txt_information.Text += "Ngày đặt: " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine;
                    dataGridViewCthdx.Rows.Clear(); // Xóa dữ liệu cũ nếu có
                }
            }
        }

        private void ThemChiTietHoaDonXuat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (string.IsNullOrEmpty(txt_idhh.Text) || string.IsNullOrEmpty(txt_sl.Text) || string.IsNullOrEmpty(txt_giatien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maHangHoa = int.Parse(txt_idhh.Text);
                string tenHangHoa = txt_namehh.Text;
                int soLuong = int.Parse(txt_sl.Text);
                float donGia = float.Parse(txt_giatien.Text);

                // Thêm chi tiết hóa đơn xuất vào CSDL
                string insertDetailQuery = "INSERT INTO ChiTietHoaDonXuat (MaHoaDonXuat, MaHangHoa, SoLuong, DonGia) VALUES (@MaHoaDonXuat, @MaHangHoa, @SoLuong, @DonGia)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDonXuat", currentMaHoaDonXuat);
                        cmd.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.Parameters.AddWithValue("@DonGia", donGia);

                        cmd.ExecuteNonQuery();
                        // Thêm dữ liệu vào DataGridView
                        float thanhTienhdx = int.Parse(txt_sl.Text) * float.Parse(txt_giatien.Text);
                        dataGridViewCthdx.Rows.Add(txt_idhh.Text, txt_namehh.Text, txt_sl.Text, txt_giatien.Text, thanhTienhdx);
                        CapNhatTongTienHoaDonXuat(conn);  // Cập nhật tổng tiền cho hóa đơn xuất
                    }
                } catch(Exception ex) {
                    MessageBox.Show("Vui lòng xem lại dữ liệu nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CapNhatTongTienHoaDonXuat(SqlConnection conn)
        {
            string totalQuery = "SELECT SUM(SoLuong * DonGia) FROM ChiTietHoaDonXuat WHERE MaHoaDonXuat = @MaHoaDonXuat";
            using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaHoaDonXuat", currentMaHoaDonXuat);

                // Kiểm tra và xử lý giá trị null từ SUM
                object result = cmd.ExecuteScalar();
                decimal tongTien = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0m;

                // Cập nhật tổng tiền vào HoaDonNhap
                string updateTotalQuery = "UPDATE HoaDonXuat SET TongTien = @TongTien WHERE MaHoaDonXuat = @MaHoaDonXuat";
                using (SqlCommand updateCmd = new SqlCommand(updateTotalQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@TongTien", tongTien);
                    updateCmd.Parameters.AddWithValue("@MaHoaDonXuat", currentMaHoaDonXuat);
                    updateCmd.ExecuteNonQuery();
                }
                // Cập nhật TextBox hiển thị tổng tiền
                txt_information.Text = $"Mã hóa đơn: {currentMaHoaDonXuat}" + Environment.NewLine;
                txt_information.Text += $"Tên khách hàng: {txt_namekh.Text}" + Environment.NewLine;
                txt_information.Text += "Ngày đặt: " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine;
                txt_information.Text += $"Tổng tiền: {tongTien}" + Environment.NewLine;
            }
        }


        private void btn_addhdx_Click(object sender, EventArgs e)
        {
            TaoHoaDonXuat();
            //MessageBox.Show("Hóa đơn xuất được tạo thành công với mã: " + currentMaHoaDonXuat);
        }

        private void btn_addcthdx_Click(object sender, EventArgs e)
        {
            if (currentMaHoaDonXuat == 0)
            {
                MessageBox.Show("Vui lòng tạo hóa đơn xuất trước khi thêm chi tiết !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ThemChiTietHoaDonXuat();
                //MessageBox.Show("Chi tiết hóa đơn xuất đã được thêm.");
            }
        }

        private void FDatHang_Load(object sender, EventArgs e)
        {
            // Đảm bảo DataGridView có các cột
            dataGridViewCthdx.Columns.Clear();
            dataGridViewCthdx.Columns.Add("MaHangHoa", "Mã Hàng Hóa");
            dataGridViewCthdx.Columns.Add("TenHangHoa", "Tên Hàng Hóa");
            dataGridViewCthdx.Columns.Add("SoLuong", "Số Lượng");
            dataGridViewCthdx.Columns.Add("DonGia", "Giá tiền");
            dataGridViewCthdx.Columns.Add("ThanhTien", "Thành Tiền");
            // Cài đặt các thuộc tính cho DataGridView
            dataGridViewCthdx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cài đặt màu sắc và kiểu chữ
            dataGridViewCthdx.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCthdx.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewCthdx.DefaultCellStyle.Font = new Font("Arial", 10);

            // Cài đặt chế độ chọn
            dataGridViewCthdx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ngăn chỉnh sửa tất cả các cột
            foreach (DataGridViewColumn column in dataGridViewCthdx.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Reset thông tin hóa đơn
            currentMaHoaDonXuat = 0;
            txt_information.Text = "";
            dataGridViewCthdx.Rows.Clear();
            txt_namekh.Clear();
            txt_sdt.Clear();
            txt_namehh.Clear();
            txt_dvhh.Clear();
            txt_idhh.Clear();
            txt_sl.Clear();
            txt_giatien.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
