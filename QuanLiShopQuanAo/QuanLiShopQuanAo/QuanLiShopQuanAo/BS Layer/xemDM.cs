using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiShopQuanAo.DB_Layer;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLiShopQuanAo.BS_Layer;


namespace QuanLiShopQuanAo.BS_Layer
{
    public class xemDM
    {
        DBMain db = null;
        public xemDM()
        {
            db = new DBMain();
        }
        public DataSet LayKhachHang()
        {
            return db.ExcuteQueryDataSet("Select * From KhachHang ", CommandType.Text);
        }
        public DataSet LayNhanVien()
        {
            return db.ExcuteQueryDataSet("Select * From NhanVien ", CommandType.Text);
        }
        public DataSet LayMatHang()
        {
            return db.ExcuteQueryDataSet("Select * From MatHang ", CommandType.Text);
        }
        public DataSet LayDonHang()
        {
            return db.ExcuteQueryDataSet("Select * From DonHang ", CommandType.Text);
        }
        public DataSet LayChiTietDonHang()
        {
            return db.ExcuteQueryDataSet("Select * From ChiTietDonHang ", CommandType.Text);
        }

    }
}
