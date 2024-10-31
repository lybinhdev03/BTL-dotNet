using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyVatLieuXayDung
{
    public partial class FNhaCungCap : Form
    {
        // Chuỗi kết nối tới SQL Server
        private readonly string connectionString = "Data Source=LYBINHDEV;Initial Catalog=db_vlxd; Integrated Security=true;";

        public FNhaCungCap()
        {
            InitializeComponent();
            LoadDataNhaCungCap();
            dgv_Nhacungcap.ReadOnly = true;
            dgv_Nhacungcap.CellClick += dgv_Nhacungcap_CellClick; // Kết nối sự kiện CellClick
        }

        private void LoadDataNhaCungCap()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhaCungCap";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv_Nhacungcap.DataSource = dataTable;

                // Thiết lập tiêu đề cột cho DataGridView
                dgv_Nhacungcap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Nhacungcap.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                dgv_Nhacungcap.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                dgv_Nhacungcap.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgv_Nhacungcap.Columns["SDT"].HeaderText = "Số Điện Thoại";
                dgv_Nhacungcap.Columns["Email"].HeaderText = "Email";
            }
        }

        private void dgv_Nhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Nhacungcap.Rows[e.RowIndex];
                txt_Mancc.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                txt_Tenncc.Text = row.Cells["TenNhaCungCap"].Value?.ToString();
                txt_Diachi.Text = row.Cells["DiaChi"].Value?.ToString();
                txt_sdt.Text = row.Cells["SDT"].Value?.ToString();
                txt_Email.Text = row.Cells["Email"].Value?.ToString();
            }
        }

        private void btn_Taoncc_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT, Email) VALUES (@TenNhaCungCap, @DiaChi, @SDT, @Email)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenNhaCungCap", txt_Tenncc.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txt_Diachi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("New supplier has been added successfully!");
                            LoadDataNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add new supplier.");
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

                    string query = "UPDATE NhaCungCap SET TenNhaCungCap = @TenNhaCungCap, DiaChi = @DiaChi, SDT = @SDT, Email = @Email WHERE MaNhaCungCap = @MaNhaCungCap";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaNhaCungCap", txt_Mancc.Text);
                        cmd.Parameters.AddWithValue("@TenNhaCungCap", txt_Tenncc.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txt_Diachi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier updated successfully!");
                            LoadDataNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the supplier details.");
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

                    string query = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaNhaCungCap", txt_Mancc.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier deleted successfully!");
                            LoadDataNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Please check the supplier details.");
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
            txt_Mancc.Text = "";
            txt_Tenncc.Text = "";
            txt_Diachi.Text = "";
            txt_sdt.Text = "";
            txt_Email.Text = "";
            LoadDataNhaCungCap();
            MessageBox.Show("Data has been refreshed.");
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM NhaCungCap WHERE 1=1";

                    if (!string.IsNullOrEmpty(txtMancc.Text))
                    {
                        query += " AND MaNhaCungCap = @MaNhaCungCap";
                    }
                    if (!string.IsNullOrEmpty(txtTenncc.Text))
                    {
                        query += " AND TenNhaCungCap LIKE '%' + @TenNhaCungCap + '%'";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(txtMancc.Text))
                        {
                            cmd.Parameters.AddWithValue("@MaNhaCungCap", txtMancc.Text);
                        }
                        if (!string.IsNullOrEmpty(txtTenncc.Text))
                        {
                            cmd.Parameters.AddWithValue("@TenNhaCungCap", txtTenncc.Text);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgv_Nhacungcap.DataSource = dataTable;

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
    }
}
