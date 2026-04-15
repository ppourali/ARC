using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmMosahebehView : Form
    {
        public FrmMosahebehView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmMosView_Load(object sender, EventArgs e)
        {
           

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            mos_list ml = new mos_list();
            DataTable dt = new DataTable();
            dt = ml.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"مشخصه","شماره پرونده","نام و نام خانوادگی","تلفن منزل","تاریخ مصاحبه","مصاحبه کننده","سمت"};
            int[] col_width = {70, 100, 130, 100, 100, 110, 90};
            //grdDataViewer.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            for (int i=0; i<col_headers.Length;i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from mos_list where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }
                
                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtmos_date.MaskCompleted)
                {
                    SQL = SQL + "mos_date>=N'" + txtmos_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "mos_date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                mos_list rm = new mos_list();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtid.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void frmMosView_Activated(object sender, EventArgs e)
        {
            mos_list pm = new mos_list();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text=="" && !txtmos_date.MaskCompleted && !txttodate.MaskCompleted )
            {
                btnfilter.Enabled = false;

                mos_list pm = new mos_list();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }                    



        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }

        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Yellow;
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.Yellow;
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
            }

        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {

        }


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmMosahebehInp fmi = new FrmMosahebehInp();
            fmi.cur_date = this.cur_date;
            fmi.MdiParent = this.MdiParent;
            fmi.Show();

            mos_list pm = new mos_list();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                //int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", row].Value.ToString();

                FrmMosahebehEdit fme = new FrmMosahebehEdit();

                fme.txtCode.Text = val;
                fme.idsearch_Click(null,null);
                fme.ShowDialog();

                mos_list pm = new mos_list();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
                
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                FrmMosahebehPrintViewer fmpv = new FrmMosahebehPrintViewer();

                long val = long.Parse(grdDataViewer["code", grdDataViewer.CurrentRow.Index].Value.ToString());
                mos_list ml = new mos_list();
                ml.code = val;
                fmpv.filler_mos_list = ml.Selectforedit();

                map_a ma = new map_a();
                ma.code = val;
                fmpv.filler_MAP_A = ma.Selectforedit();

                MAP_BtoG mb = new MAP_BtoG();
                mb.code = val;
                fmpv.filler_MAP_BtoG = mb.Selectforedit();

                map_history mh = new map_history();
                mh.code = val;
                fmpv.filler_MAP_History = mh.Selectforedit();

                fmpv.Show();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف مصاحبه بیمار اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", irow].Value.ToString();

                mos_list mo = new mos_list();
                mo.code = long.Parse(val);
                mo.id = grdDataViewer["id", irow].Value.ToString();
                mo.Delete();

                mos_list pm = new mos_list();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
                
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
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