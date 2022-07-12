using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace QuanLiShopQuanAo.DB_Layer
{
    class DBMain
    {
        string connStr = @"Data Source=PHIBUI\SQLEXPRESS;Initial Catalog=QuanLiShopQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter ada = null;

        public DBMain()
        {
            conn = new SqlConnection(connStr);
            comm = conn.CreateCommand();
        }
        //Truy Van Du Lieu
        public SqlDataReader MyExcuteReader(string strSQl, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQl;
            comm.CommandType = ct;
            return comm.ExecuteReader();
        }
        public void myDispose()
        {
            comm.Dispose();
        }
        //Load DataSet
        public DataSet ExcuteQueryDataSet(string strSQl, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQl;
            comm.CommandType = ct;
            ada = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            return ds;
        }
        //Lay Gia Tri Du Lieu
        public bool MyExcuteNonQuery(string strSQl, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQl;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        //Lay Gia Tri De Tinh
        public string GetValue(string strSQL)
        {
            string temp = null;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand(strSQL, conn);
            SqlDataReader sqldr = sqlcmd.ExecuteReader();
            while (sqldr.Read())
                temp = sqldr[0].ToString();
            conn.Close();
            return temp;
        }
    }
}
