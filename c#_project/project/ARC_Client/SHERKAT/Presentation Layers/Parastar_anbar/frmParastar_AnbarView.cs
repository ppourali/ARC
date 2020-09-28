using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmParastar_AnbarView : Form
    {
        public frmParastar_AnbarView()
        {
            InitializeComponent();
        }

        public string cur_date = "";

        private void frmParastar_AnbarView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            parastar_anbar an = new parastar_anbar();
            DataTable dt = new DataTable();
            dt = an.Select();

            grdDataViewer.DataSource = dt;
            //grdDataViewer.AutoGenerateColumns = true;

            //string[] col_headers = { "نام دارو", "موجودی انبار", "واحد" };
            //int[] col_width = { 150, 150, 125 };

            //for (int i = 0; i < col_headers.Length; i++)
            //{
            //    grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
            //    grdDataViewer.Columns[i].Width = col_width[i];
            //}

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.MistyRose;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Boolean alldone = false;

            foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
            {
                try
                {
                    string mandeh = dgvr.Cells["mandeh"].Value.ToString();

                    if (float.Parse(mandeh) > 0)
                    {
                        tajviz_anbar_history dar = new tajviz_anbar_history();
                        dar.id = long.Parse(new tajviz_anbar_history().Selectmaxid().ToString());
                        dar.date = cur_date;
                        dar.contactname = "پرستار";
                        dar.contactid = "0000";
                        dar.daru_name = dgvr.Cells["daru_name"].Value.ToString();
                        dar.tedad = float.Parse(mandeh);
                        dar.comments = "برگشت دارو از بانک دارویی پرستار";
                        dar.Add();

                        // Updating the Data to the DataBase Anbar
                        tajviz_anbar an = new tajviz_anbar();
                        an.mandeh = float.Parse(mandeh);
                        an.daru_name = dgvr.Cells["daru_name"].Value.ToString();
                        an.UpdateAfterFactor();
                        // End of Updating Data to the DataBase
                        
                        parastar_anbar pa = new parastar_anbar();
                        pa.daru_name = dgvr.Cells["daru_name"].Value.ToString();
                        pa.mandeh = -float.Parse(mandeh);
                        pa.MojoodiInc();

                        alldone = true;
                       
                    }
                }
                catch
                {
                    MessageBox.Show("انجام عملیات با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (alldone)
                MessageBox.Show("انجام عملیات با موفقیت به پایان رسید", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


            parastar_anbar pm = new parastar_anbar();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                btnedit.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void grdDataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string mandeh = grdDataViewer["mandeh", e.RowIndex].Value.ToString();
                if (float.Parse(mandeh) > 0)
                {
                    frmDaruReturnTedad fdrt = new frmDaruReturnTedad();
                    fdrt.maxcanreturn = mandeh;
                    fdrt.daru_name = grdDataViewer["daru_name", e.RowIndex].Value.ToString();
                    fdrt.cur_date = this.cur_date;
                    fdrt.type = "پرستار";
                    fdrt.cname = "پرستار";
                    fdrt.cid = "0000";
                    fdrt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("مقدار مانده ی داروی انتخاب شده صفر می باشد");
                }


                parastar_anbar pm = new parastar_anbar();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                grdDataViewer.CurrentCell = grdDataViewer[0, e.RowIndex];
            }
        }
    }
}