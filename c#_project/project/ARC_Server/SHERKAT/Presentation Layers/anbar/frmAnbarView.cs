using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmAnbarView : Form
    {
        public FrmAnbarView()
        {
            InitializeComponent();
        }

        private void frmAnbarView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Anbar an = new Anbar();
            DataTable dt = new DataTable();
            dt = an.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "نام دارو", "موجودی انبار", "واحد", "قیمت" };
            int[] col_width = { 150, 100, 100, 100 };

            for (int i = 0; i < col_headers.Length; i++)
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


        private void frmAnbarView_Activated(object sender, EventArgs e)
        {
            Anbar pm = new Anbar();
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

                Anbar anb = new Anbar();
                anb.daru_name = val;
                anb.mandeh = float.Parse(grdDataViewer["mandeh", irow].Value.ToString());
                anb.Delete();

                Anbar pm = new Anbar();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmAnbarInp fai = new FrmAnbarInp();
            fai.MdiParent = this.MdiParent;
            fai.Show();

            Anbar pm = new Anbar();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[col, row].Value.ToString();

                FrmAnbarEdit fae = new FrmAnbarEdit();

                fae.txtdaru_name.Text = val;
                fae.old_daru_name = val;
                fae.old_mandeh = grdDataViewer["mandeh", row].Value.ToString();
                fae.txtmandeh.Text = grdDataViewer["mandeh", row].Value.ToString();
                fae.txtvahed.Text = grdDataViewer["vahed", row].Value.ToString();
                fae.txtfee.Text = grdDataViewer["fee", row].Value.ToString();
                fae.txtmandeh.Focus();
                fae.ShowDialog();

                Anbar pm = new Anbar();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

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