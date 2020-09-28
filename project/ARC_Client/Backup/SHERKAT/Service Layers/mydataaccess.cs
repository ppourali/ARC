using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Mehr
{

    class mydataaccess
    {

        public string ServerName = Properties.Settings.Default.ServerName.ToString() + @"\sqlexpress";
        public string DBName = "ARC";

        private SqlConnection con;
        public SqlCommand cmd;
        private SqlDataAdapter da;

        public mydataaccess()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            cmd.Connection = con;
            da.SelectCommand = cmd;
        }

        public void ConnectforRestore()
        {
            string cs = "Server={0};database=master;Integrated Security = false; User Id=sa; Password=sa;";
            cs = string.Format(cs, this.ServerName);
            con.ConnectionString = cs;
            con.Open();
        }


        public void Connect()
        {
            string cs = "Server={0};database={1};Integrated Security=false; User Id=sa; Password=sa;";
            cs = string.Format(cs, this.ServerName, this.DBName);
            con.ConnectionString = cs;
            con.Open();

        }
        public void disconnect()
        {
            con.Close();

        }


        public SqlDataReader selectimage(string selectsql)
        {
            SqlDataReader dr = null;
            cmd.CommandText = selectsql;
            dr = cmd.ExecuteReader();

            return dr;
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
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString() + " در ورود اطلاعات مشکلی رخ داده است، لطفا مجددا اطلاعات را بررسی کنید ", "توجه");
                UpdateLogFile(sql, e);
            }

        }

        private void UpdateLogFile(string sqlCmd, Exception e)
        {
            using (StreamWriter w = File.AppendText(Application.StartupPath + "\\err.log"))
            {
                Log(sqlCmd, e.Message, w);
            }
        }

        public static void Log(string sqlCommand, string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString() + " :");
            w.WriteLine("SQL Command ::  {0}", sqlCommand);
            w.WriteLine();
            w.WriteLine("Error Msg   ::  {0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
