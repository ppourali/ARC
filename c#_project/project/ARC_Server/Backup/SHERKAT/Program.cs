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

            string key = Properties.Settings.Default.SerialNo.ToString().Trim();
            string Auth_code = kg.MakeGUID();

            if (key != Auth_code)
            {
                Application.Run(new frmAuthurize(Auth_code));
            }

            else
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
                        catch
                        {
                            MessageBox.Show("لطفا با پشتیبان تماس بگیرید");
                            Application.Exit();
                        }
                    }

                }
                finally
                {
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