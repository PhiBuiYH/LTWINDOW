using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLiShopQuanAo.DB_Layer;

namespace QuanLiShopQuanAo.BS_Layer
{
    class BLQLMH
    {
        DBMain db = null;
        public BLQLMH()
        {
            db = new DBMain();
        }
        public DataSet LayMatHang()
        {
            return db.ExcuteQueryDataSet("Select * from MatHang", CommandType.Text);
        }
        public bool ThemMatHang(string MaMH, string TenMH, string GiaTien, ref string err)
        {
            string sqlString = "Insert Into MatHang Values('" + MaMH + "',N'" +
            TenMH + "',N'" + GiaTien + "' )";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaMatHang(ref string err, string MaMH)
        {
            string sqlString = "Delete From MatHang Where MaMH ='" + MaMH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatMatHang(string MaMH, string TenMH, string GiaTien, ref string err)
        {
            string sqlString = "Update MatHang Set TenMH=N'" + TenMH + "',GiaTien=N'" + GiaTien + "'Where MaMH ='" + MaMH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet TimMaMH(string MaMH)
        {
            string sqlString = "Select * from MatHang Where MaMH like '%" + MaMH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet TimMH(string TenMH)
        {
            string sqlString = "Select * from MatHang Where TenMH like '%" + TenMH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public bool KiemTraMHTonTai_indiffTable(string MaMH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaMH From ChiTietDonHang where MaMH='" + MaMH + "'";
            reader = db.MyExcuteReader(selectcommand, CommandType.Text);
            if (reader.Read())
            {
                reader.Dispose();
                return true;
            }
            reader.Dispose();
            return false;
        }

        public bool KiemTraMHTonTai_inTable(string MaMH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaMH From MatHang where MaMH='" + MaMH + "'";
            reader = db.MyExcuteReader(selectcommand, CommandType.Text);
            if (reader.Read())
            {
                reader.Dispose();
                return true;
            }
            reader.Dispose();
            return false;
        }
    }
}
