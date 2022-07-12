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
    public partial class XemDanhMuc : Form
    {
        DataTable dtDM = null;
        xemDM DM = new xemDM();
        public XemDanhMuc()
        {
            InitializeComponent();
        }
        public int index=0; 

        private void XemDanhMuc_Load(object sender, EventArgs e)
        {
            try
            {
                string intDM = this.Text;
                switch (intDM)
                {
                    case "1":
                        lblDM.Text = "Danh mục Khách Hàng";
                        dtDM = new DataTable();
                        dtDM.Clear();
                        DataSet ds1 = DM.LayKhachHang();
                        dtDM = ds1.Tables[0];
                        dgvDanhMuc.DataSource = dtDM;
                        dgvDanhMuc.AutoResizeColumns();
                       
                        break;
                    case "2":
                        lblDM.Text = "Danh mục Nhân Viên";
                        dtDM = new DataTable();
                        dtDM.Clear();
                        DataSet ds2 = DM.LayNhanVien();
                        dtDM = ds2.Tables[0];
                        dgvDanhMuc.DataSource = dtDM;
                        dgvDanhMuc.AutoResizeColumns();
                        break;
                    case "3":
                        lblDM.Text = "Danh mục Mặt Hàng";
                        dtDM = new DataTable();
                        dtDM.Clear();
                        DataSet ds3 = DM.LayMatHang();
                        dtDM = ds3.Tables[0];
                        dgvDanhMuc.DataSource = dtDM;
                        dgvDanhMuc.AutoResizeColumns();
                        break;
                    case "4":
                        lblDM.Text = "Danh mục Đơn Hàng";
                        dtDM = new DataTable();
                        dtDM.Clear();
                        DataSet ds4 = DM.LayDonHang();
                        dtDM = ds4.Tables[0];
                        dgvDanhMuc.DataSource = dtDM;
                        dgvDanhMuc.AutoResizeColumns();
                        break;
                    case "5":
                        lblDM.Text = "Chi Tiết Đơn Hàng";
                        dtDM = new DataTable();
                        dtDM.Clear();
                        DataSet ds5 = DM.LayChiTietDonHang();
                        dtDM = ds5.Tables[0];
                        dgvDanhMuc.DataSource = dtDM;
                        dgvDanhMuc.AutoResizeColumns();
                        break;
                    default:
                        break;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
