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
using System.Data.Sql;
using QuanLiShopQuanAo.BS_Layer;
using System.Text.RegularExpressions;

namespace QuanLiShopQuanAo
{
    public partial class QLKhachHang : Form
    {
        DataTable dtKH = null;
        bool Them;
        string err;
        int i = 0;
        BLQLKH dpKH = new BLQLKH();
        public QLKhachHang()
        {
            InitializeComponent();
        }
        private void dgvQLKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvQLKH.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaKH.Text =
            dgvQLKH.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text =
            dgvQLKH.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text =
            dgvQLKH.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvQLKH.Rows[r].Cells[3].Value.ToString();

        }
        void Load_Data()
        {
            try
            {
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet ds = dpKH.LayKhachHang();
                dtKH = ds.Tables[0];

                dgvQLKH.DataSource = dtKH;
                dgvQLKH.AutoResizeColumns();
                //Xóa các đối tượng trong Panel
                this.txtMaKH.ResetText();
                this.txtTenKH.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.txtTimKiem.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuybo.Enabled = false;
                this.panel.Enabled = false;
                this.grbTimKiem.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.button1.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                // Chuyển thông tin lên Panel
                dgvQLKH_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KhachHang!");
            }
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet11.KhachHang' table. You can move, or remove it, as needed.
            //this.khachHangTableAdapter.Fill(this.quanLiShopQuanAoDataSet11.KhachHang);
            Load_Data();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            //Xóa các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.txtTimKiem.ResetText();
            this.txtMaKH.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm/ Xóa /Thoát
            this.button1.Enabled = false;
            this.grbTimKiem.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMAKH
            this.txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            this.txtMaKH.Enabled = false;
            dgvQLKH_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.button1.Enabled = false;
            this.grbTimKiem.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtTenKH
            this.txtTenKH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (this.txtMaKH.Text == "" || this.txtTenKH.Text == "" || this.txtDiaChi.Text == "" || this.txtSDT.Text == "")
                    MessageBox.Show("Chưa nhập đủ!");
                else if (dpKH.KiemTraKHTonTai_inTable(this.txtMaKH.Text))
                {
                    MessageBox.Show("Đã tồn tại mã Khách Hàng này! Hãy nhập lại.","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaKH.ResetText();
                    this.txtMaKH.Focus();
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLKH blKH = new BLQLKH();
                        blKH.ThemKhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);
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
                if (this.txtMaKH.Text == "" || this.txtTenKH.Text == "" || this.txtDiaChi.Text == "" || this.txtSDT.Text == "")
                    MessageBox.Show("Chỗ sửa còn trống!");
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLKH blKH = new BLQLKH();
                        blKH.CapNhatKhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);

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
            //Xóa các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.txtTimKiem.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuybo.Enabled = false;
            this.panel.Enabled = false;
            this.grbTimKiem.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
            this.btnReload.Enabled = true;
            this.button1.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            dgvQLKH_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvQLKH.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaKH =
                dgvQLKH.Rows[r].Cells[0].Value.ToString();
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
                    if (dpKH.KiemTraKHTonTai_indiffTable(strMaKH))
                        MessageBox.Show("Bạn phải xóa " + strMaKH + " của những Đơn hàng đã lên từ bảng Đơn Hàng.", "Thông báo!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        try
                        {
                            dpKH.XoaKhachHang(ref err, strMaKH);
                            // Cập nhật lại DataGridView
                            Load_Data();
                            // Thông báo
                            MessageBox.Show("Đã xóa xong!");
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi rồi!");
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
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtKH = new DataTable();
            dtKH.Clear();
            if (i == 1)
            {
                DataSet ds = dpKH.TimMaKH(this.txtTimKiem.Text);
                dtKH = ds.Tables[0];
                dgvQLKH.DataSource = dtKH;
                dgvQLKH.AutoResizeColumns();
            }
            if (i == 2)
            {
                DataSet ds = dpKH.TimTenKH(this.txtTimKiem.Text);
                dtKH = ds.Tables[0];
                dgvQLKH.DataSource = dtKH;
                dgvQLKH.AutoResizeColumns();
            }
            if (i == 3)
            {
                DataSet ds = dpKH.TimDiaChi(this.txtTimKiem.Text);
                dtKH = ds.Tables[0];
                dgvQLKH.DataSource = dtKH;
                dgvQLKH.AutoResizeColumns();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.btnThem.Enabled = false;
            this.btnReload.Enabled = false;
            grbTimKiem.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.txtTimKiem.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            i = 3;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            txtSDT.Text = Regex.Replace(txtSDT.Text, @"[^0-9]+", "");
        }

        private void dgvQLKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
