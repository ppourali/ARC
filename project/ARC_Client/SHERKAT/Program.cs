using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mehr.Presentation_Layers;
using System.Data;

namespace Mehr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string user_semat = "", user_code = "", user_name = "";

        [STAThread]

        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            KeyGen kg = new KeyGen();

            bool keyCheck = true;

            string key = Properties.Settings.Default.SerialNo.ToString().Trim();
            string Auth_code = kg.MakeGUID();

            if (key != Auth_code)
            {
                keyCheck = false;

                //frmAuthurize f1 = new frmAuthurize();
                //f1.txtAuth.Text = Auth_code;

                Application.Run(new frmAuthurize(Auth_code));

                //if (dr == DialogResult.OK)
                //    keyCheck = true;
            }

            else
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

                    if (dt.Rows.Count == 0)
                    {
                        frmadddarmangah fad = new frmadddarmangah();

                        if (fad.ShowDialog() != DialogResult.Abort)
                            Application.Run(new frmMain());
                    }
                    else
                        Application.Run(new frmMain());

                }
            }
        }
    }
}