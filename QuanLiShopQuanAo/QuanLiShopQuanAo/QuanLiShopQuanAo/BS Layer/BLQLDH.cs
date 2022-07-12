using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiShopQuanAo.DB_Layer;
using System.Data.SqlClient;

namespace QuanLiShopQuanAo.BS_Layer
{
    class BLQLDH
    {

        DBMain db = null;
        public BLQLDH()
        {
            db = new DBMain();
        }
        public DataSet LayDonHang()
        {
            return db.ExcuteQueryDataSet("Select * from DonHang", CommandType.Text);
        }
        public bool ThemDonHang(string MaDH, string MaKH, string MaNV, string NgayMua, ref string err)
        {
            string sqlString = "Insert Into DonHang Values('" + MaDH + "',N'" +
            MaKH + "',N'" + MaNV + "',N'" + NgayMua + "' )";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaDonHang(ref string err, string MaDH)
        {
            string sqlString = "Delete From DonHang Where MaDH ='" + MaDH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatDonHang(string MaDH, string MaKH, string MaNV, string NgayMua, ref string err)
        {
            string sqlString = "Update DonHang Set MaKH=N'" + MaKH + "',MaNV=N'" + MaNV + "',NgayMua=N'" + NgayMua + "'Where MADH ='" + MaDH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet TimMaDH(string MaDH)
        {
            string sqlString = "Select * from DonHang Where MaDH like '%" + MaDH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet TimMaKH(string MaKH)
        {
            string sqlString = "Select * from DonHang Where MaKH like '%" + MaKH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet TimMaNV(string MaNV)
        {
            string sqlString = "Select * from DonHang Where MaNV like '%" + MaNV + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet TimNgayMua(string NgayMua)
        {
            string sqlString = "Select * from DonHang Where NgayMua like '%" + NgayMua + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public List<string> LayMaKH()
        {
            List<string> dsMaKH = new List<string>();
            dsMaKH.Clear();
            string selectcomm = "select MaKH from KhachHang";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
            while (reader.Read())
            {
                dsMaKH.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsMaKH;
        }

        public List<string> LayMaNV()
        {
            List<string> dsMaNV = new List<string>();
            dsMaNV.Clear();
            string selectcomm = "select MaNV from NhanVien";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
            while (reader.Read())
            {
                dsMaNV.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsMaNV;
        }

        public bool KiemTraDHTonTai_inTable(string MaDH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaDH From DonHang where MaDH='" + MaDH + "'";
            reader = db.MyExcuteReader(selectcommand, CommandType.Text);
            if (reader.Read())
            {
                reader.Dispose();
                return true;
            }
            reader.Dispose();
            return false;
        }

        public bool KiemTraDHTonTai_indiffTable(string MaDH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaDH From ChiTietDonHang where MaDH='" + MaDH + "'";
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
