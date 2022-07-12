using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLiShopQuanAo.DB_Layer;
using System.Data;

namespace QuanLiShopQuanAo.BS_Layer
{
    class BLQLKH
    {
        DBMain db = null;
        public BLQLKH()
        {
            db = new DBMain();
        }
        public DataSet LayKhachHang()
        {
            return db.ExcuteQueryDataSet("Select * from KhachHang", CommandType.Text);
        }
        public bool ThemKhachHang(string MaKH, string TenKH, string DiaChi, string SoDienThoai, ref string err)
        {
            string sqlString = "Insert Into KhachHang Values('"+ MaKH + "',N'" +
            TenKH + "',N'" + DiaChi + "',N'" + SoDienThoai + "' )";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaKhachHang(ref string err, string MaKH)
        {
            string sqlString = "Delete From KhachHang Where MaKH ='" + MaKH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatKhachHang(string MaKH, string TenKH, string DiaChi, string SoDienThoai, ref string err)
        {
            string sqlString = "Update KhachHang Set TenKH=N'" + TenKH + "',DiaChi=N'"+ DiaChi + "',SoDienThoai=N'" + SoDienThoai + "'Where MAKH ='" + MaKH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet TimMaKH(string MaKH)
        {
            string sqlString = "Select * from KhachHang Where MAKH like '%" + MaKH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimTenKH(string TenKH)
        {
            string sqlString = "Select * from KhachHang Where TenKH like '%" + TenKH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimDiaChi(string DiaChi)
        {
            string sqlString = "Select * from KhachHang Where DiaChi like '%" + DiaChi + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public bool KiemTraKHTonTai_indiffTable(string MaKH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaKH From DonHang where MaKH='" + MaKH + "'";
            reader = db.MyExcuteReader(selectcommand, CommandType.Text);
            if (reader.Read())
            {
                reader.Dispose();
                return true;
            }
            reader.Dispose();
            return false;
        }

        public bool KiemTraKHTonTai_inTable(string MaKH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaKH From KhachHang where MaKH='" + MaKH + "'";
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
