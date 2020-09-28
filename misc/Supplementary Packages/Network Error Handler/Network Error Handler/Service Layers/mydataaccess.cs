using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ServiceProcess;


namespace Network_Error_Handler
{

    class mydataaccess
    {

        public string ServerName = @".\sqlexpress";
        public string DBName = "mehr";

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


        public void ChangeMixedMode()
        {
            string cs = @"Integrated Security=SSPI;Data Source=" + ServerName + ";Initial Catalog=master;";
            cmd.CommandText = @"USE [master];EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2;" +
                "ALTER LOGIN [sa] WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;" +
                "ALTER LOGIN [sa] WITH PASSWORD=N'sa';" +
                "ALTER LOGIN [sa] ENABLE";

            con.ConnectionString = cs;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            System.Data.SqlClient.SqlConnection.ClearAllPools();


            //Restart Service
            RestartService("MSSQL$SQLEXPRESS");

        }

        public void RestartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped);

            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);

            //                MessageBox.Show("عملیات تغییر نوع کاربری بانک اطلاعاتی با موفقیت به اتمام رسید");
        }

    

        public void Connect()
        {
            string cs = "Server={0};database={1};Integrated Security=true;";
            cs = string.Format(cs, this.ServerName, this.DBName);
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
            //try
            //{
                cmd.ExecuteNonQuery();
            //}
            //catch
            //{
            //    MessageBox.Show("در ورود اطلاعات مشکلی رخ داده است، لطفا مجددا اطلاعات را بررسی کنید", "توجه");
            //}

        }
    }
}
