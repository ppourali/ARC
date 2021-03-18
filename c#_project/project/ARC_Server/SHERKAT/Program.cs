using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mehr.Presentation_Layers;
using System.Data;
using Mehr.Business_Layers;

namespace Mehr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string user_semat = "", user_code = "", user_name = "";
        public static bool isServerMachine = false;

        [STAThread]

        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            KeyGen kg = new KeyGen();

            string key = Properties.Settings.Default.SerialNo.ToString().Trim();
            string Auth_code = kg.MakeGUID();

            if (key != Auth_code)
            {
                Application.Run(new frmAuthurize(Auth_code));
            }

            else
            {
                Properties.Settings.Default.Location = "CLIENT";
                Properties.Settings.Default.Save();

                if (Properties.Settings.Default.Location == null || (!Properties.Settings.Default.Location.Equals("CLIENT") &&
                    !Properties.Settings.Default.Location.Equals("SERVER")))
                {
                    isServerMachine = true;
                    if (!runOnServer())
                    {
                        isServerMachine = false;
                        if (!runOnClient())
                            Application.Exit();
                    }
                }
                else if(isServer())
                {
                    isServerMachine = true;
                    if (!runOnServer())
                    {
                        isServerMachine = false;
                        if (!runOnClient())
                            Application.Exit();
                    }
                }
                else
                {
                    isServerMachine = false;
                    runOnClient();
                }         

            }
        }

        private static bool isServer()
        {
           return Properties.Settings.Default.Location != null && 
                Properties.Settings.Default.Location.Equals("SERVER");
        }

        private static bool runOnClient()
        {
            if (Properties.Settings.Default.ServerName.ToString().Trim() == "")
            {
                frmSelectServers fss = new frmSelectServers();
                fss.ShowDialog();
            }

            if (Properties.Settings.Default.ServerName.ToString().Trim() != "")
            {

                DataTable dt = new DataTable();

                try
                {
                    mydataaccess da = new mydataaccess();
                    da.Connect();
                    da.disconnect();
                }
                catch (System.Data.SqlClient.SqlException se)
                {
                    if (se.Message.ToLower().Contains("login failed for user".ToLower()))
                    {
                        MessageBox.Show("عملیات ثبت کاربر پایگاه داده با مشکل مواجه شد، لطفا عملیات 'بررسی تنظیمات مرتبط با شبکه' را از سیستم سرور پیگیری نمایید و مجددا سعی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        frmSelectServers fss = new frmSelectServers();
                        fss.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show(" نمی باشد" + Properties.Settings.Default.ServerName.ToString() + "سیستم قادر به شناسایی سیستم سرور ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        frmSelectServers fss = new frmSelectServers();
                        fss.ShowDialog();
                    }
                }
                finally
                {
                    darmangah darm = new darmangah();

                    dt = darm.Select();
                }

                Properties.Settings.Default.Location = "CLIENT";
                Properties.Settings.Default.Save();

                isServerMachine = false;
                if (dt.Rows.Count == 0)
                {
                    frmadddarmangah fad = new frmadddarmangah();

                    if (fad.ShowDialog() != DialogResult.Abort)
                        startApp();
                }
                else
                    startApp();

            }
            return true;


        }

        private static bool runOnServer()
        {
            darmangah darm = new darmangah();
            DataTable dt = new DataTable();

            try
            {
                mydataaccess da = new mydataaccess();
                da.Connect();
                da.disconnect();
            }
            catch
            {
                mydataaccess da = new mydataaccess();

                byte ChDbExist = da.CheckDatabseExists();

                if (ChDbExist == 1)
                    da.Attach();
                else if (ChDbExist == 2)
                {
                    try
                    {
                        da.detach_action();
                        da.Attach();
                    }
                    catch (Exception ex)
                    {
                        mydataaccess.Log(ex);
                        MessageBox.Show("لطفا با پشتیبان تماس بگیرید");
                        return false;
                    }
                }

            }
            finally
            {
                dt = darm.Select();
            }

            Properties.Settings.Default.Location = "SERVER";
            Properties.Settings.Default.Save();

            isServerMachine = true;

            if (dt.Rows.Count == 0)
            {
                frmadddarmangah fad = new frmadddarmangah();

                if (fad.ShowDialog() != DialogResult.Abort)
                    startApp();
            }
            else
                startApp();

            return true;
        }

        private static void startApp()
        {
            Sicks sicks = new Sicks();
            DataTable allSicks = sicks.Select();
            Cache.putRecords(allSicks);

            Gen_settings genSettings = new Gen_settings();
            DataTable settings = genSettings.Select();

            Application.Run(new frmMain());
        }
    }
}