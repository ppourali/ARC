using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmTajvizAnbarHistoryView : Form
    {
        public FrmTajvizAnbarHistoryView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmtaj_anbar_historyView_Load(object sender, EventArgs e)
        {

            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from tajviz_anbar");

            txtdaru_name.Items.Add("همه");
            foreach (DataRow dr in combosource.Rows)
                txtdaru_name.Items.Add(dr[0].ToString());

            txtdaru_name.SelectedIndex = 0;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_anbar_history fa = new tajviz_anbar_history();
            DataTable dt = new DataTable();
            dt = fa.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه", "کد مخاطب", "نام مخاطب", "تاریخ", "نام دارو", "تعداد", "توضیحات" };
            int[] col_width = { 60, 80, 130, 80, 150, 80, 237 };

            for (int i = 0; i < col_headers.Length; i++)
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

                string SQL = "select * from tajviz_anbar_history where ";
                check = false;


                if (txtcontactid.Text != "")
                {
                    SQL = SQL + "contactid=N'" + txtcontactid.Text.Trim() + "'AND ";
                    check = true;
                }


                if (txtcontactname.Text.Trim() != "")
                {
                    SQL = SQL + "contactname like N'%" + txtcontactname.Text.Trim() + "%'AND ";
                    check = true;
                }


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

                if (txtcomments.Text != "")
                {
                    SQL = SQL + "comments like N'%" + txtcomments.Text.Trim() + "%'AND ";
                    check = true;
                } 
                
                if (txtdaru_name.SelectedIndex > 0)
                {
                    SQL = SQL + "daru_name = N'" + txtdaru_name.Text.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4)+" order by id desc";
                }

                tajviz_anbar_history rm = new tajviz_anbar_history();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtcontactid.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtcontactid.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && txtdaru_name.SelectedIndex == 0 && txtcomments.Text.Trim()=="" && txtcontactname.Text.Trim()=="")
            {
                btnfilter.Enabled = false;

                tajviz_anbar_history pm = new tajviz_anbar_history();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
        }

        private void btnprint_Click_1(object sender, EventArgs e)
        {
            FrmTajvizAnbarHistoryPrintViewer fgkpv = new FrmTajvizAnbarHistoryPrintViewer();
            fgkpv.filler = (DataTable)(grdDataViewer.DataSource);
            fgkpv.Show();
        }

     
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
           
        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {
            if (txtcontactid.Text != "")
                txtcontactid.Text = string.Format("{0:0000}", Convert.ToDecimal(txtcontactid.Text));
        }
    }
}