using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Daru
{

    class mydataaccess
    {

        private OleDbConnection con;
        public OleDbCommand cmd;
        private OleDbDataAdapter da;

        public mydataaccess()
        {
            con = new OleDbConnection();
            cmd = new OleDbCommand();
            da = new OleDbDataAdapter();
            cmd.Connection = con;
            da.SelectCommand = cmd;
        }


        public void Connect()
        {
            string cs = "Provider=Microsoft.Jet.OLEDB.4.0 ; Data Source=daru.mdb; Jet OLEDB:Database Password=12345;";
            con.ConnectionString = cs;
            con.Open();

        }
        public void disconnect()
        {
            con.Close();
        }

        public DataTable select(string selectsql)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = selectsql;
            da.Fill(dt);
            return dt;
        }

        public void docommand(string sql)
        {
            cmd.CommandText = sql;
           // try
           // {
                cmd.ExecuteNonQuery();
           // }
           // catch
           // {
           //     MessageBox.Show("در ورود اطلاعات مشکلی رخ داده است، لطفا مجددا اطلاعات را بررسی کنید","توجه");
           // }

        }
    }
}
