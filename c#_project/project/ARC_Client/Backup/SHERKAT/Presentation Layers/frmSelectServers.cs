using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace Mehr.Presentation_Layers
{
    public partial class frmSelectServers : Form
    {
        public frmSelectServers()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "نرم افزار در حال جستجوی سیستم سرور می باشد.";
            
            Cursor.Current = Cursors.WaitCursor;

            SqlDataSourceEnumerator sdse = SqlDataSourceEnumerator.Instance;
            DataTable table = sdse.GetDataSources();
            
            treeView1.Nodes["engine"].Nodes.Clear();

            int i = 0;

            foreach (DataRow row in table.Rows)
            {
                treeView1.Nodes["Engine"].Nodes.Add("DS"+i++,row["ServerName"].ToString(),1,1);
            }

            treeView1.Nodes[0].ExpandAll();

            Cursor.Current = Cursors.Default;

            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "جستجوی سیستم سرور به اتمام رسید...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "نرم افزار در حال برقراری ارتباط با  سرور " + treeView1.SelectedNode.Text.ToString() + " می باشد.";
            string snbefor = Properties.Settings.Default.ServerName.ToString();

            Properties.Settings.Default.ServerName = treeView1.SelectedNode.Text.ToString();
            Properties.Settings.Default.Save();

            Cursor.Current = Cursors.WaitCursor;

            mydataaccess da = new mydataaccess();
            try
            {
                da.Connect();
                da.disconnect();
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                Properties.Settings.Default.ServerName = snbefor;
                Properties.Settings.Default.Save();

                if (se.Message.ToLower().Contains("login failed for user".ToLower()))
                {
                    MessageBox.Show("عملیات ثبت کاربر پایگاه داده با مشکل مواجه شد، لطفا عملیات 'بررسی تنظیمات مرتبط با شبکه' را از سیستم سرور پیگیری نمایید و مجددا سعی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show(se.Message.ToString());
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "سیستم قادر به برقراری ارتباط با سرور نمی باشد. لطفا مجددا بررسی نمایید.";
                }
            }

            Cursor.Current = Cursors.Default; ;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode.Name=="Engine")
                button2.Enabled = false;
            else
                button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}