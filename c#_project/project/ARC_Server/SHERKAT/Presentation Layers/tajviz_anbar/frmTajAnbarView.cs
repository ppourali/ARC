using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmTajAnbarView : Form
    {
        public frmTajAnbarView()
        {
            InitializeComponent();
        }

        private void frmTajAnbarView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_anbar an = new tajviz_anbar();
            DataTable dt = new DataTable();
            dt = an.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"نام دارو","موجودی انبار","واحد", "قیمت"};
            int[] col_width = {150, 100, 100, 100};

            for (int i=0; i<col_headers.Length;i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            grdDataViewer.Columns["fee"].DefaultCellStyle = dataGridViewCellStyle1;
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void frmTajAnbarView_Activated(object sender, EventArgs e)
        {
            tajviz_anbar pm = new tajviz_anbar();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف دارو اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[icol, irow].Value.ToString();

                tajviz_anbar anb = new tajviz_anbar();
                anb.daru_name = val;
                anb.mandeh = float.Parse(grdDataViewer["mandeh", irow].Value.ToString()); 
                anb.Delete();

                tajviz_anbar pm = new tajviz_anbar();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmTajAnbarInp fai = new frmTajAnbarInp();
            fai.MdiParent = this.MdiParent;
            fai.Show();

            tajviz_anbar pm = new tajviz_anbar();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            frmEditPassInput fad=new frmEditPassInput();
            if (fad.ShowDialog() != DialogResult.Abort)
            {
                if (grdDataViewer.CurrentRow != null)
                {
                    int col = 0;
                    int row = grdDataViewer.CurrentRow.Index;
                    string val = grdDataViewer[col, row].Value.ToString();

                    frmTajAnbarEdit fae = new frmTajAnbarEdit();
                    fae.txtdaru_name.Text = val;
                    fae.old_daru_name = val;
                    fae.old_mandeh = grdDataViewer["mandeh", row].Value.ToString();
                    fae.txtmandeh.Text = grdDataViewer["mandeh", row].Value.ToString();
                    fae.txtvahed.Text = grdDataViewer["vahed", row].Value.ToString();
                    fae.txtfee.Text = grdDataViewer["fee", row].Value.ToString();
                    fae.txtmandeh.Focus();
                    fae.ShowDialog();

                    tajviz_anbar pm = new tajviz_anbar();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btndel.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                btnedit.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}