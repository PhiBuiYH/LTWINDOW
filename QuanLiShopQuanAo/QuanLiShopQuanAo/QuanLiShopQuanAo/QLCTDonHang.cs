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
    public partial class QLCTDonHang : Form
    {
        DataTable dt_CTDH = null;
        bool Them;
        string err;
        BLQL_CTDH dp_CTDH = new BLQL_CTDH();
        public QLCTDonHang()
        {
            InitializeComponent();
        }
        private void dgvQLKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvQLCTDH.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.cbbMaDH.Text =
            dgvQLCTDH.Rows[r].Cells[0].Value.ToString();
            this.cbbMaMH.Text =
            dgvQLCTDH.Rows[r].Cells[1].Value.ToString();
            this.txtSoluong.Text =
            dgvQLCTDH.Rows[r].Cells[2].Value.ToString();
            this.txtThanhTien.Text =
            dgvQLCTDH.Rows[r].Cells[3].Value.ToString();
        }
        void Load_Data()
        {
            try
            {
                dt_CTDH = new DataTable();
                dt_CTDH.Clear();
                DataSet ds = dp_CTDH.Lay_ChiTietDonHang();
                dt_CTDH = ds.Tables[0];
                //TimKiem
                this.txtTimKiem.ResetText();
                this.btnTimKiem.Enabled = true;
                this.txtTimKiem.Enabled = false;

                dgvQLCTDH.DataSource = dt_CTDH;
                dgvQLCTDH.AutoResizeColumns();
                //Xóa các đối tượng trong Panel
                this.cbbMaDH.ResetText();
                this.cbbMaMH.ResetText();
                this.txtSoluong.ResetText();
                this.txtThanhTien.ResetText();
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
                dgvQLKH_CellClick(null, null);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChiTietDonHang!");
            }
        }
        private void loadMaDH()
        {
            List<string> dsMaDH = new List<string>();
            dsMaDH.Clear();
            dsMaDH = dp_CTDH.LayMaDH();
            foreach (string maDH in dsMaDH)
            {
                cbbMaDH.Items.Add(maDH);
            }
        }
        private void loadMaMH()
        {
            List<string> dsMaMH = new List<string>();
            dsMaMH.Clear();
            dsMaMH = dp_CTDH.LayMaMH();
            foreach (string maMH in dsMaMH)
            {
                cbbMaMH.Items.Add(maMH);
            }
        }
        private void QLCTDonHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiShopQuanAoDataSet1.ChiTietDonHang' table. You can move, or remove it, as needed.
            // this.chiTietDonHangTableAdapter.Fill(this.quanLiShopQuanAoDataSet1.ChiTietDonHang);
            Load_Data();
            loadMaMH();
            loadMaDH();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            //TimKiem
            this.txtTimKiem.ResetText();
            this.btnTimKiem.Enabled = false;
            this.txtTimKiem.Enabled = false;
            //Xóa các đối tượng trong Panel
            this.cbbMaDH.ResetText();
            this.cbbMaMH.ResetText();
            this.txtSoluong.ResetText();
            this.txtThanhTien.ResetText();
            this.cbbMaDH.Enabled = true;
            this.cbbMaMH.Enabled = true;
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
            this.cbbMaDH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            //TimKiem
            this.btnTimKiem.Enabled = false;
            this.txtTimKiem.Enabled = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            this.cbbMaDH.Enabled = false;
            this.cbbMaMH.Enabled = false;
            dgvQLKH_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtSoluong
            this.txtSoluong.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (this.txtSoluong.Text == "" || this.txtThanhTien.Text == "")
                    MessageBox.Show("Chưa nhập đủ!");
                else if (this.dp_CTDH.KiemTraMHTonTai_inDH(this.cbbMaMH.Text, this.cbbMaDH.Text))
                {
                    MessageBox.Show("Đã tồn tại mã Mặt Hàng trong Đơn Hàng này! Hãy nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cbbMaMH.ResetText();
                    this.cbbMaMH.Focus();
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQL_CTDH ctDH = new BLQL_CTDH();
                        ctDH.Them_ChiTietDH(cbbMaDH.Text, cbbMaMH.Text, txtSoluong.Text, txtThanhTien.Text, ref err);
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
                if (this.txtSoluong.Text == "" || this.txtThanhTien.Text == "")
                    MessageBox.Show("Chỗ sửa còn trống!");
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        BLQL_CTDH ctDH = new BLQL_CTDH();
                        ctDH.CapNhat_ChiTietDH(cbbMaDH.Text, cbbMaMH.Text, txtSoluong.Text, txtThanhTien.Text, ref err);

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
            this.txtTimKiem.Enabled = false;
            //Xóa các đối tượng trong Panel
            this.cbbMaDH.ResetText();
            this.cbbMaMH.ResetText();
            this.txtSoluong.ResetText();
            this.txtThanhTien.ResetText();
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
            dgvQLKH_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvQLCTDH.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaMH =
                dgvQLCTDH.Rows[r].Cells[1].Value.ToString();
                string strMaDH =
                dgvQLCTDH.Rows[r].Cells[0].Value.ToString();
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
                    dp_CTDH.Xoa_ChiTietDH(ref err, strMaMH, strMaDH);
                    // Cập nhật lại DataGridView
                    Load_Data();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
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
            this.btnThem.Enabled = false;
            this.btnReload.Enabled = false;
            this.btnHuybo.Enabled = true;
            this.txtTimKiem.Enabled = true;
            this.txtTimKiem.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dt_CTDH = new DataTable();
            dt_CTDH.Clear();
            DataSet ds = dp_CTDH.TimMaDH(this.txtTimKiem.Text);
            dt_CTDH = ds.Tables[0];
            dgvQLCTDH.DataSource = dt_CTDH;
            dgvQLCTDH.AutoResizeColumns();
        }

        private void cbbMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtSoluong.ResetText();
            this.txtThanhTien.ResetText();
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            double sl, dg, tt;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            dg = Convert.ToDouble(dp_CTDH.TimGiaTien(cbbMaMH.Text));

            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

    }
}
