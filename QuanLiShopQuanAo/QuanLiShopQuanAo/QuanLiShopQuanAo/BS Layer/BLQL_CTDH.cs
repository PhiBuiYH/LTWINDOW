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
    class BLQL_CTDH
    {
        DBMain db = null;
        public BLQL_CTDH()
        {
            db = new DBMain();
        }
        public DataSet Lay_ChiTietDonHang()
        {
            return db.ExcuteQueryDataSet("Select * from ChiTietDonHang", CommandType.Text);
        }
        public bool Them_ChiTietDH(string MaDH, string MaMH, string Soluong, string ThanhTien, ref string err)
        {
            string sqlString = "Insert Into ChiTietDonHang Values('" + MaDH + "',N'" +
            MaMH + "',N'" + Soluong + "',N'" + ThanhTien + "' )";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Xoa_ChiTietDH(ref string err, string MaMH, string MaDH)
        {
            string sqlString = "Delete From ChiTietDonHang Where MaMH ='" + MaMH + "'AND MADH ='" + MaDH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhat_ChiTietDH(string MaDH, string MaMH, string Soluong, string ThanhTien, ref string err)
        {
            string sqlString = "Update ChiTietDonHang Set Soluong=N'" + Soluong + "',ThanhTien=N'" + ThanhTien + "'Where MaMH ='" + MaMH + "'AND MaDH ='" + MaDH + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet TimMaDH(string MaDH)
        {
            string sqlString = "Select * from ChiTietDonHang Where MaDH like '%" + MaDH + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public string TimGiaTien(string MaMH)
        {
            string sqlString = "Select GiaTien from MatHang Where MaMH like '%" + MaMH + "%'";

            return db.GetValue(sqlString);
        }
        public List<string> LayMaMH()
        {
            List<string> dsMaMH = new List<string>();
            dsMaMH.Clear();
            string selectcomm = "select MaMH from MatHang";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
            while (reader.Read())
            {
                dsMaMH.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsMaMH;
        }

        public List<string> LayMaDH()
        {
            List<string> dsMaDH = new List<string>();
            dsMaDH.Clear();
            string selectcomm = "select MaDH from DonHang";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
            while (reader.Read())
            {
                dsMaDH.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsMaDH;
        }
        public List<string> LayMaKH_DaLenHoaDon()
        {
            List<string> dsMaKH = new List<string>();
            dsMaKH.Clear();
            string selectcomm = "Select a.MaKH From KhachHang as a, DonHang as b, ChiTietDonHang as c Where a.MaKH = b.MaKH and b.MaDH = c.MaDH Group By a.MaKH";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
            while (reader.Read())
            {
                dsMaKH.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsMaKH;
        }

        public bool KiemTraMHTonTai_inDH(string MaMH, string MaDH)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaMH From ChiTietDonHang where MaMH='" + MaMH + "'AND MADH ='" + MaDH + "'";
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
