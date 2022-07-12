using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLiShopQuanAo.BS_Layer;

namespace QuanLiShopQuanAo
{
    public partial class QLNhanVien : Form
    {
        DataTable dtNV = null;
        bool Them;
        string err;
        int i = 0;
        BLQLNV dpNV = new BLQLNV();
        public QLNhanVien()
        {
            InitializeComponent();
        }
        private void dgvQLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvQLNV.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNV.Text =
            dgvQLNV.Rows[r].Cells[0].Value.ToString();
            this.txtTenNV.Text =
            dgvQLNV.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text =
            dgvQLNV.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvQLNV.Rows[r].Cells[3].Value.ToString();
            this.mskNgaySinh.Text =
            dgvQLNV.Rows[r].Cells[4].Value.ToString();

        }
        void Load_Data()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet ds = dpNV.LayNhanVien();
                dtNV = ds.Tables[0];

                dgvQLNV.DataSource = dtNV;
                dgvQLNV.AutoResizeColumns();
                //TimKiem
                this.txtTimKiem.ResetText();
                this.btnTimKiem.Enabled = true;
                this.grbTimKiem.Enabled = false;
                //Xóa các đối tượng trong Panel
                this.txtMaNV.ResetText();
                this.txtTenNV.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.mskNgaySinh.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuybo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                // Chuyển thông tin lên Panel
                dgvQLNV_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien!");
            }
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet.NhanVien' table. You can move, or remove it, as needed.
            //this.nhanVienTableAdapter1.Fill(this.quanLiShopQuanAoDataSet.NhanVien);
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet1.NhanVien' table. You can move, or remove it, as needed.
            //this.nhanVienTableAdapter.Fill(this.quanLiShopQuanAoDataSet1.NhanVien);
            Load_Data();

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            //TimKiem
            this.txtTimKiem.ResetText();
            this.btnTimKiem.Enabled = false;
            this.grbTimKiem.Enabled = false;
            //Xóa các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.mskNgaySinh.ResetText();
            this.txtMaNV.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm/ Xóa /Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMANV
            this.txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //TimKiem
            this.btnTimKiem.Enabled = false;
            this.grbTimKiem.Enabled = false;
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            this.txtMaNV.Enabled = false;
            dgvQLNV_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtTenNV
            this.txtTenNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (this.txtMaNV.Text == "" || this.txtTenNV.Text == "" || this.txtDiaChi.Text == "" || this.txtSDT.Text == "" || this.mskNgaySinh.Text == "")
                    MessageBox.Show("Chưa nhập đủ!");
                else if (dpNV.KiemTraNVTonTai_inTable(this.txtMaNV.Text))
                {
                    MessageBox.Show("Đã tồn tại mã Nhân Viên này! Hãy nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaNV.ResetText();
                    this.txtMaNV.Focus();
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLNV blNV = new BLQLNV();
                        blNV.ThemNhanVien(txtMaNV.Text, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, mskNgaySinh.Text, ref err);
                        // Load lại dữ liệu trên DataGridView
                        Load_Data();
                        // Thông báo
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
            }
            else
            {
                if (this.txtMaNV.Text == "" || this.txtTenNV.Text == "" || this.txtDiaChi.Text == "" || this.txtSDT.Text == "" || this.mskNgaySinh.Text == "")
                    MessageBox.Show("Chỗ sửa còn trống!");
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLNV blNV = new BLQLNV();
                        blNV.CapNhatNhanVien(txtMaNV.Text, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, mskNgaySinh.Text, ref err);

                        // Load lại dữ liệu trên DataGridView
                        Load_Data();
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!");
                    }
                }
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            //TimKiem
            this.txtTimKiem.ResetText();
            this.btnTimKiem.Enabled = true;
            this.grbTimKiem.Enabled = false;

            //Xóa các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.mskNgaySinh.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuybo.Enabled = false;
            this.panel.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
            this.btnReload.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            dgvQLNV_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvQLNV.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaNV =
                dgvQLNV.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                // Hiện thông báo xác nhận việc xóa mẫu tin
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    if (dpNV.KiemTraNVTonTai_indiffTable(strMaNV))
                        MessageBox.Show("Bạn phải xóa " + strMaNV + " của Đơn hàng đã lên từ bảng Đơn Hàng.", "Thông báo!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        try
                        {
                            dpNV.XoaNhanVien(ref err, strMaNV);
                            // Cập nhật lại DataGridView
                            Load_Data();
                            // Thông báo
                            MessageBox.Show("Đã xóa xong!");
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi rồi!.");
                        }
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            this.btnThem.Enabled = false;
            this.btnReload.Enabled = false;
            grbTimKiem.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.txtTimKiem.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            i = 1;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            i = 2;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            i = 3;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtNV = new DataTable();
            dtNV.Clear();
            if (i == 1)
            {
                DataSet ds = dpNV.TimMaNV(this.txtTimKiem.Text);
                dtNV = ds.Tables[0];
                dgvQLNV.DataSource = dtNV;
                dgvQLNV.AutoResizeColumns();
            }
            if (i == 2)
            {
                DataSet ds = dpNV.TimTenNV(this.txtTimKiem.Text);
                dtNV = ds.Tables[0];
                dgvQLNV.DataSource = dtNV;
                dgvQLNV.AutoResizeColumns();
            }
            if (i == 3)
            {
                DataSet ds = dpNV.TimDiaChi(this.txtTimKiem.Text);
                dtNV = ds.Tables[0];
                dgvQLNV.DataSource = dtNV;
                dgvQLNV.AutoResizeColumns();
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
