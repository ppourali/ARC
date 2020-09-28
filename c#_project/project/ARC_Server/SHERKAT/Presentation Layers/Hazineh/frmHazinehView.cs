using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmHazinehView : Form
    {
        public frmHazinehView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmHazinehView_Load(object sender, EventArgs e)
        {
            
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            hazineh fa = new hazineh();
            DataTable dt = new DataTable();
            dt = fa.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه","نوع هزینه", "تاریخ", "مبلغ", "شرح هزینه" };
            int[] col_width = { 60,100, 80, 80, 270 };

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
            grdDataViewer.Columns["mablagh"].DefaultCellStyle = dataGridViewCellStyle1;
        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from hazineh where ";
                check = false;


                if (txtdate.MaskCompleted)
                {
                    SQL = SQL + "date>=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

              
                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                hazineh rm = new hazineh();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtdate.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmHazinehView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                hazineh pm = new hazineh();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف هزینه اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["radif", irow].Value.ToString();

                hazineh fac = new hazineh();
                fac.radif = long.Parse(val);
                fac.Delete();

              if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    hazineh pm = new hazineh();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted && !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;

                hazineh pm = new hazineh();
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmHazinehInp ffi = new frmHazinehInp();
            ffi.MdiParent = this.MdiParent;
            ffi.Show();

            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                hazineh pm = new hazineh();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
            
        }

        //private void btnedit_Click(object sender, EventArgs e)
        //{
        //    if (grdDataViewer.CurrentRow != null)
        //    {
        //        int col = 0;
        //        int row = grdDataViewer.CurrentRow.Index;
        //        string val = grdDataViewer[col, row].Value.ToString();

        //        factors fa = new factors();
        //        DataTable datat = new DataTable();
        //        fa.factor_no = val;

        //        datat = fa.Selectforedit();

        //        frmSicksEdit fse = new frmSicksEdit();

        //        fse.txtid.Text = val;
        //        fse.idsearch_Click(null,null);
        //        fse.ShowDialog();

        //        Sicks pm = new Sicks();
        //        DataTable dt = new DataTable();
        //        dt = pm.Select();
        //        grdDataViewer.DataSource = dt;
                
        //    }
        //}

  
        private void btnprint_Click_1(object sender, EventArgs e)
        {
            frmHazinehPrintViewer fgkpv = new frmHazinehPrintViewer();
            fgkpv.P = (DataTable)(grdDataViewer.DataSource);
            fgkpv.Show();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["radif", row].Value.ToString();

                frmHazinehEdit fse = new frmHazinehEdit();

                fse.txtradif.Text = val;
                fse.idsearch_Click();
                fse.ShowDialog();
               
                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    hazineh pm = new hazineh();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }

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