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
    public partial class QLDonHang : Form
    {
        DataTable dtDH = null;
        bool Them;
        string err;
        int i = 0;
        BLQLDH dpDH = new BLQLDH();
        public QLDonHang()
        {
            InitializeComponent();
        }

        private void dgvQLDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvQLDH.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaDH.Text =
            dgvQLDH.Rows[r].Cells[0].Value.ToString();
            this.cbbMaKH.Text =
            dgvQLDH.Rows[r].Cells[1].Value.ToString();
            this.cbbMaNV.Text =
            dgvQLDH.Rows[r].Cells[2].Value.ToString();
            this.mskNgayMua.Text =
            dgvQLDH.Rows[r].Cells[3].Value.ToString();

        }
        void Load_Data()
        {
            try  
            {
                dtDH = new DataTable();
                dtDH.Clear();
                DataSet ds = dpDH.LayDonHang();
                dtDH = ds.Tables[0];

                dgvQLDH.DataSource = dtDH;
                dgvQLDH.AutoResizeColumns();
                //TimKiem
                this.txtTimKiem.ResetText();
                this.btnTimKiem.Enabled = true;
                this.grbTimKiem.Enabled = false;
                //Xóa các đối tượng trong Panel
                this.txtMaDH.ResetText();
                this.cbbMaKH.ResetText();
                this.cbbMaNV.ResetText();
                this.mskNgayMua.ResetText();
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
                dgvQLDH_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DonHang !");
            }
        }
        private void loadMaKH()
        {
            List<string> dsMaKH = new List<string>();
            dsMaKH.Clear();
            dsMaKH = dpDH.LayMaKH();
            foreach (string maKH in dsMaKH)
            {
                cbbMaKH.Items.Add(maKH);
            }
        }
        private void loadMaNV()
        {
            List<string> dsMaNV = new List<string>();
            dsMaNV.Clear();
            dsMaNV = dpDH.LayMaNV();
            foreach (string maNV in dsMaNV)
            {
                cbbMaNV.Items.Add(maNV);
            }
        }

        private void QLDonHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet.MatHang' table. You can move, or remove it, as needed.
            //this.matHangTableAdapter.Fill(this.quanLiShopQuanAoDataSet.MatHang);
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet.DonHang' table. You can move, or remove it, as needed.
            //this.donHangTableAdapter.Fill(this.quanLiShopQuanAoDataSet.DonHang);
            Load_Data();
            loadMaKH();
            loadMaNV();
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
            this.mskNgayMua.ResetText();
            this.cbbMaKH.ResetText();
            this.cbbMaNV.ResetText();
            this.txtMaDH.ResetText();
            this.txtMaDH.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm/ Xóa /Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMADH
            this.txtMaDH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            //TimKiem
            this.btnTimKiem.Enabled = false;
            this.grbTimKiem.Enabled = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            this.txtMaDH.Enabled = false;
            dgvQLDH_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.cbbMaKH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (this.cbbMaKH.Text == "" || this.txtMaDH.Text == "" || this.cbbMaNV.Text == "" || this.mskNgayMua.Text == "")
                    MessageBox.Show("Chưa nhập đủ!");
                else if (this.dpDH.KiemTraDHTonTai_inTable(this.txtMaDH.Text))
                {
                    MessageBox.Show("Đã tồn tại mã Đơn Hàng này! Hãy nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaDH.ResetText();
                    this.txtMaDH.Focus();
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLDH blDH = new BLQLDH();
                        blDH.ThemDonHang(txtMaDH.Text, cbbMaKH.Text, cbbMaNV.Text, mskNgayMua.Text, ref err);
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

                if (this.cbbMaKH.Text == "" || this.txtMaDH.Text == "" || this.cbbMaNV.Text == "" || this.mskNgayMua.Text == "")
                    MessageBox.Show("Chỗ sửa còn trống!");
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQLDH blDH = new BLQLDH();
                        blDH.CapNhatDonHang(txtMaDH.Text, cbbMaKH.Text, cbbMaNV.Text, mskNgayMua.Text, ref err);

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
            this.cbbMaKH.ResetText();
            this.txtMaDH.ResetText();
            this.cbbMaNV.ResetText();
            this.mskNgayMua.ResetText();
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
            dgvQLDH_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvQLDH.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaDH =
                dgvQLDH.Rows[r].Cells[0].Value.ToString();
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
                    if (dpDH.KiemTraDHTonTai_indiffTable(strMaDH))
                        MessageBox.Show("Bạn phải xóa " + strMaDH + " từ bảng Chi Tiết Đơn Hàng.", "Thông báo!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        try
                        {
                            dpDH.XoaDonHang(ref err, strMaDH);
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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            i = 3;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            i = 4;
            this.txtTimKiem.Focus();
            this.txtTimKiem.ResetText();
            this.txtTimKiem.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtDH = new DataTable();
            dtDH.Clear();
            if (i == 1)
            {
                DataSet ds = dpDH.TimMaDH(this.txtTimKiem.Text);
                dtDH = ds.Tables[0];
                dgvQLDH.DataSource = dtDH;
                dgvQLDH.AutoResizeColumns();
            }
            if (i == 2)
            {
                DataSet ds = dpDH.TimMaKH(this.txtTimKiem.Text);
                dtDH = ds.Tables[0];
                dgvQLDH.DataSource = dtDH;
                dgvQLDH.AutoResizeColumns();
            }
            if (i == 3)
            {
                DataSet ds = dpDH.TimMaNV(this.txtTimKiem.Text);
                dtDH = ds.Tables[0];
                dgvQLDH.DataSource = dtDH;
                dgvQLDH.AutoResizeColumns();
            }
            if (i == 4)
            {
                DataSet ds = dpDH.TimNgayMua(this.txtTimKiem.Text);
                dtDH = ds.Tables[0];
                dgvQLDH.DataSource = dtDH;
                dgvQLDH.AutoResizeColumns();
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
            this.btnThem.Enabled = false;
            this.btnReload.Enabled = false;
            grbTimKiem.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.txtTimKiem.Enabled = false;
        }

    }
}
