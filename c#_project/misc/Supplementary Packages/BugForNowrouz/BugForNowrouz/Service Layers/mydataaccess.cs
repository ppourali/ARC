using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BugForNowrouz
{

    class mydataaccess
    {

        public string ServerName = @".\SQLEXPRESS";
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


        public void Attach()
        {
            string cs = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=master";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_attach_db";
            cmd.Parameters.Add("@dbname", SqlDbType.NVarChar, 128).Value = "ARC";
            cmd.Parameters.Add("@filename1", SqlDbType.NVarChar, 260).Value =Application.StartupPath+ @"\Data\ARC.mdf";
            cmd.Parameters.Add("@filename2", SqlDbType.NVarChar, 260).Value = Application.StartupPath + @"\Data\ARC_log.ldf";
            con.ConnectionString = cs;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                MessageBox.Show("در ضمیمه کردن بانک اطلاعاتی مشکلی رخ داده است");
            }
            finally
            {
                con.Close();
                System.Data.SqlClient.SqlConnection.ClearAllPools();
            }
        }

        public void ConnectforRestore()
        {
            string cs = "Server={0};database=master;Integrated Security = true";
            cs = string.Format(cs, this.ServerName);
            con.ConnectionString = cs;
            con.Open();
        }


        public void Connect()
        
        {
            string cs = "Server={0};database={1};Integrated Security = true";
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
