using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyVatLieuXayDung
{
    public partial class FKhoHang : Form
    {
        public readonly string connectionString = "Server=DESKTOP-Q53GGI4\\SQLEXPRESS;Database=vlxd;Integrated Security=True;";

        private string originalMaKho = "";  // Lưu mã kho ban đầu
        private string originalMaHangHoa = "";  // Lưu mã hàng hóa ban đầu

        public FKhoHang()
        {
            InitializeComponent();
            LoadDataKhoHang();
            dgv_Khohang.ReadOnly = true;
            dgv_Khohang.CellClick += dgv_Khohang_CellClick;
        }

        private void LoadDataKhoHang()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhoHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv_Khohang.DataSource = dataTable;

                dgv_Khohang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Khohang.Columns["MaKho"].HeaderText = "Mã Kho";
                dgv_Khohang.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hoá";
                dgv_Khohang.Columns["SoLuong"].HeaderText = "Số Lượng";

                dgv_Khohang.BackgroundColor = Color.LightGray;
                dgv_Khohang.DefaultCellStyle.ForeColor = Color.Black;
                dgv_Khohang.DefaultCellStyle.Font = new Font("Arial", 10);
                dgv_Khohang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewColumn column in dgv_Khohang.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void dgv_Khohang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_Khohang.Rows[e.RowIndex];
                txt_Makho.Text = row.Cells["MaKho"].Value?.ToString();
                txt_Mahh.Text = row.Cells["MaHangHoa"].Value?.ToString();
                txt_Soluong.Text = row.Cells["SoLuong"].Value?.ToString();

                // Lưu lại mã kho và mã hàng hóa ban đầu
                originalMaKho = txt_Makho.Text;
                originalMaHangHoa = txt_Mahh.Text;
            }
        }

        private void btn_Taohh_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO KhoHang (MaKho, MaHangHoa, SoLuong) VALUES (@MaKho, @MaHangHoa, @SoLuong)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKho", txt_Makho.Text);
                        cmd.Parameters.AddWithValue("@MaHangHoa", txt_Mahh.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txt_Soluong.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("New item has been added successfully!");
                            LoadDataKhoHang();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add new item.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE KhoHang SET MaKho = @MaKho, MaHangHoa = @MaHangHoa, SoLuong = @SoLuong " +
                                   "WHERE MaKho = @OriginalMaKho AND MaHangHoa = @OriginalMaHangHoa";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKho", txt_Makho.Text);
                        cmd.Parameters.AddWithValue("@MaHangHoa", txt_Mahh.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txt_Soluong.Text));
                        cmd.Parameters.AddWithValue("@OriginalMaKho", originalMaKho);
                        cmd.Parameters.AddWithValue("@OriginalMaHangHoa", originalMaHangHoa);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item updated successfully!");
                            LoadDataKhoHang();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the item details.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM KhoHang WHERE MaKho = @MaKho AND MaHangHoa = @MaHangHoa";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKho", txt_Makho.Text);
                        cmd.Parameters.AddWithValue("@MaHangHoa", txt_Mahh.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully!");
                            LoadDataKhoHang();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Please check the item details.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txt_Makho.Text = "";
            txt_Mahh.Text = "";
            txt_Soluong.Text = "";
            LoadDataKhoHang();
            MessageBox.Show("Data has been refreshed.");
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM KhoHang WHERE 1=1";

                    if (!string.IsNullOrEmpty(txtMakho.Text))
                    {
                        query += " AND MaKho = @MaKho";
                    }

                    if (!string.IsNullOrEmpty(txtMahh.Text))
                    {
                        query += " AND MaHangHoa = @MaHangHoa";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(txtMakho.Text))
                        {
                            cmd.Parameters.AddWithValue("@MaKho", txtMakho.Text);
                        }

                        if (!string.IsNullOrEmpty(txtMahh.Text))
                        {
                            cmd.Parameters.AddWithValue("@MaHangHoa", txtMahh.Text);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgv_Khohang.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No matching records found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FKhoHang_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
