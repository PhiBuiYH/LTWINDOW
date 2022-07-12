using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiShopQuanAo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new QLDonHang();
            f.Text = "Quản Lý Đơn Hàng";
            f.ShowDialog();
        }

        void xem(int intDanhMuc)
        {
            Form f = new XemDanhMuc();
            f.Text = intDanhMuc.ToString();
            f.ShowDialog();
        }
        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xem(1);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xem(2);
        }

        private void danhMụcMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xem(3);
        }

        private void danhMụcĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xem(4);
        }

        private void danhMụcChiTiếtĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xem(5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void danhMụcKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new QLKhachHang();
            f.Text = "Quản Lý Khách Hàng";
            f.ShowDialog();
        }

        private void danhMụcNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new QLNhanVien();
            f.Text = "Quản Lý Nhân Viên";
            f.ShowDialog();
        }

        private void danhMụcĐơnHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new QLMatHang();
            f.Text = "Quản Lý Mặt Hàng";
            f.ShowDialog();
        }

        private void danhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new QLCTDonHang();
            f.Text = "Quản Lý Chi Tiết Đơn Hàng";
            f.ShowDialog();
        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  Form f = new Report_XuatHoaDon();
            f.Text = "Hóa Đơn Đã Lên";
            f.ShowDialog();*/
        }

        private void xemDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            if ((this.txtUser.Text == "admin") && (this.txtPass.Text == "123"))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                xemDanhMụcToolStripMenuItem.Enabled = true;
                quảnLýDanhMụcĐơnHàngToolStripMenuItem.Enabled = true;
               
                panelDN.Visible = false;
                lbTittle.Text = "Chào mừng bạn đến với \n" +
                    "HOPE to PASS SHOP!";
                đăngNhậpToolStripMenuItem.Enabled = false;
            }
            else if ((this.txtUser.Text == "") || (this.txtPass.Text == ""))
                MessageBox.Show("Còn thiếu", "Lỗi");


            else
            {
                MessageBox.Show("Không đúng tên đăng nhập hoặc mật khẩu!", "Thông báo");
                this.txtUser.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.panelDN.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ngườiThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new NguoiTH();
            f.Text = "Người thực hiện";
            f.ShowDialog();
        }

        int x = 35 , y = 62 , a = 1;

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelDN_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quảnLýDanhMụcĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.panelDN.Enabled = true;
            this.panelDN.Visible = true;
            this.txtUser.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                lbTittle.Location = new Point(x, y);

                if (x >= 300)
                {
                    a = -2;
                }
                if (x <= 35)
                {
                    a = 2;
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
