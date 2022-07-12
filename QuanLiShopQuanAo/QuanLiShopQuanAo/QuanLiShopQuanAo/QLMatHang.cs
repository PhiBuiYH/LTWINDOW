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
    public partial class QLMatHang : Form
    {
        int i = 0;
        DataTable dtMH = null;
        bool Them;
        string err;
        BLQLMH dpMH = new BLQLMH();
        private void dgvQLMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvQLMH.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaMH.Text =
            dgvQLMH.Rows[r].Cells[0].Value.ToString();
            this.txtTenMH.Text =
            dgvQLMH.Rows[r].Cells[1].Value.ToString();
            this.txtGiaTien.Text =
            dgvQLMH.Rows[r].Cells[2].Value.ToString();
         
        }
        void Load_Data()
        {
            try
            {
                dtMH = new DataTable();
                dtMH.Clear();
                DataSet ds = dpMH.LayMatHang();
                dtMH = ds.Tables[0];

                dgvQLMH.DataSource = dtMH;
                dgvQLMH.AutoResizeColumns();
                //Xóa các đối tượng trong Panel
                this.txtMaMH.ResetText();
                this.txtTenMH.ResetText();
                this.txtGiaTien.ResetText();
                //Xoa cac doi tuong trong Grb
                this.txtTimKiem.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.grbTimKiem.Enabled = false;
                this.btnLuu.Enabled = false;
                this.btnHuybo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnTimKiem.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                // Chuyển thông tin lên Panel
                dgvQLMH_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table MatHang!");
            }
        }
        public QLMatHang()
        {
            InitializeComponent();
        }

   

        private void QLMatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet1.MatHang' table. You can move, or remove it, as needed.
            //this.matHangTableAdapter1.Fill(this.quanLiShopQuanAoDataSet1.MatHang);
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet2.MatHang' table. You can move, or remove it, as needed.
            //this.matHangTableAdapter.Fill(this.quanLiShopQuanAoDataSet2.MatHang);
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
            this.txtMaMH.ResetText();
            this.txtTenMH.ResetText();
            this.txtGiaTien.ResetText();
            this.txtTimKiem.ResetText();
            this.grbTimKiem.Enabled = false;
            this.txtMaMH.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm/ Xóa /Thoát
            this.btnTimKiem.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMAMH
            this.txtMaMH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            this.grbTimKiem.Enabled = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            this.txtMaMH.Enabled = false;
            dgvQLMH_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnTimKiem.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtTenMH
            this.txtTenMH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (this.txtMaMH.Text == "" || this.txtTenMH.Text == "" || this.txtGiaTien.Text == "")
                    MessageBox.Show("Chưa nhập đủ!");
                else if (dpMH.KiemTraMHTonTai_inTable(this.txtMaMH.Text))
                {
                    MessageBox.Show("Đã tồn tại mã Mặt Hàng này! Hãy nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaMH.ResetText();
                    this.txtMaMH.Focus();
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLMH blMH = new BLQLMH();
                        blMH.ThemMatHang(txtMaMH.Text, txtTenMH.Text, txtGiaTien.Text, ref err);
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
                if (this.txtMaMH.Text == "" || this.txtTenMH.Text == "" || this.txtGiaTien.Text == "")
                    MessageBox.Show("Chỗ sửa còn trống!");
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLMH blMH = new BLQLMH();
                        blMH.CapNhatMatHang(txtMaMH.Text, txtTenMH.Text, txtGiaTien.Text, ref err);

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
            this.txtMaMH.ResetText();
            this.txtTenMH.ResetText();
            this.txtGiaTien.ResetText();
            this.txtTimKiem.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.grbTimKiem.Enabled = false;
            this.btnLuu.Enabled = false;
            this.btnHuybo.Enabled = false;
            this.panel.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
            this.btnReload.Enabled = true;
            this.btnTimKiem.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            dgvQLMH_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvQLMH.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaMH =
                dgvQLMH.Rows[r].Cells[0].Value.ToString();
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
                    if (dpMH.KiemTraMHTonTai_indiffTable(strMaMH))
                        MessageBox.Show("Bạn phải xóa " + strMaMH +" của Đơn hàng đã lên từ bảng Chi Tiết Đơn Hàng.", "Thông báo!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        try
                        {
                            dpMH.XoaMatHang(ref err, strMaMH);
                            // Cập nhật lại DataGridView
                            Load_Data();
                            // Thông báo
                            MessageBox.Show("Đã xóa xong!");
                        }
                        catch
                        {
                            MessageBox.Show("Không xóa được. Lỗi rồi!!!"); 
                        }
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
            dtMH = new DataTable();
            dtMH.Clear();
            if (i == 1)
            {
                DataSet ds = dpMH.TimMaMH(this.txtTimKiem.Text);
                dtMH = ds.Tables[0];
                dgvQLMH.DataSource = dtMH;
                dgvQLMH.AutoResizeColumns();
            }
            if (i == 2)
            {
                DataSet ds = dpMH.TimMH(this.txtTimKiem.Text);
                dtMH = ds.Tables[0];
                dgvQLMH.DataSource = dtMH;
                dgvQLMH.AutoResizeColumns();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            this.btnThem.Enabled = false;
            this.btnReload.Enabled = false;
            grbTimKiem.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.txtTimKiem.Enabled = false;
        }
    }
}
