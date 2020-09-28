using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace Client_Classes
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
        }
    }
}