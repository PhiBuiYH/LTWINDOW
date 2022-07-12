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
    class BLQLNV
    {
        DBMain db = null;
        public BLQLNV()
        {
            db = new DBMain();
        }
        public DataSet LayNhanVien()
        {
            return db.ExcuteQueryDataSet("Select * from NhanVien", CommandType.Text);
        }
        public bool ThemNhanVien(string MaNV, string TenNV, string DiaChi, string SoDienThoai, string NgaySinh, ref string err)
        {
            string sqlString = "Insert Into NhanVien Values('" + MaNV + "',N'" +
            TenNV + "',N'" + DiaChi +"',N'" + SoDienThoai + "',N'" + NgaySinh + "' )";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            string sqlString = "Delete From NhanVien Where MaNV ='" + MaNV + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatNhanVien(string MaNV, string TenNV, string DiaChi, string SoDienThoai, string NgaySinh, ref string err)
        {
            string sqlString = "Update NhanVien Set HovaTen=N'" + TenNV + "',DiaChi=N'" + DiaChi + "',SoDienThoai=N'" + SoDienThoai + "',NgaySinh=N'"+NgaySinh+ "'Where MANV ='" + MaNV + "'";
            return db.MyExcuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet TimMaNV(string MaNV)
        {
            string sqlString = "Select * from NhanVien Where MaNV like '%" + MaNV + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimTenNV(string TenNV)
        {
            string sqlString = "Select * from NhanVien Where HovaTen like '%" + TenNV + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimDiaChi(string DiaChi)
        {
            string sqlString = "Select * from NhanVien Where DiaChi like '%" + DiaChi + "%'";
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool KiemTraNVTonTai_indiffTable(string MaNV)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select * From DonHang where MaNV ='" + MaNV + "'";
            reader = db.MyExcuteReader(selectcommand, CommandType.Text);
            if (reader.Read())
            {
                reader.Dispose();
                return true;
            }
            reader.Dispose();
            return false;
        }

        public bool KiemTraNVTonTai_inTable(string MaNV)
        {
            string selectcommand;
            SqlDataReader reader;
            selectcommand = "Select MaNV From NhanVien where MaNV ='" + MaNV + "'";
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
