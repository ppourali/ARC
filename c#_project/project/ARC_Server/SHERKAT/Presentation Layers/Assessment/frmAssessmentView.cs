using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmAssessmentView : Form
    {
        public FrmAssessmentView()
        {
            InitializeComponent();
        }

        DataTable dtforprint = new DataTable();
        public string cur_date;

        private void frmAssessmentView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Assessment ml = new Assessment();
            DataTable dt = new DataTable();
            dt = ml.Select();
            dtforprint = ml.Selectforprint();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"مشخصه","شماره پرونده","نام و نام خانوادگی","تاریخ ارزیابی","نمره ارزیابی"};
            int[] col_width = { 70, 100, 150, 100, 100 };

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

                string SQL = "select code, sick_id, name, ass_date, sum_all from assessment where ";

                string SQLforPrint = "select * from assessment where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "sick_id=N'" + txtid.Text.Trim() + "'AND ";
                    SQLforPrint = SQLforPrint + "sick_id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }
                
                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    SQLforPrint = SQLforPrint + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtmos_date.MaskCompleted)
                {
                    SQL = SQL + "ass_date>=N'" + txtmos_date.Text.Trim() + "'AND ";
                    SQLforPrint = SQLforPrint + "ass_date>=N'" + txtmos_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "ass_date<=N'" + txttodate.Text.Trim() + "'AND ";
                    SQLforPrint = SQLforPrint + "ass_date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                    SQLforPrint = SQLforPrint.Remove(SQLforPrint.Length - 4);
                }

                Assessment rm = new Assessment();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

                dtforprint = rm.Search(SQLforPrint);

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

      
        
        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text=="" && !txtmos_date.MaskCompleted && !txttodate.MaskCompleted )
            {
                btnfilter.Enabled = false;

                Assessment pm = new Assessment();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                dtforprint = pm.Selectforprint();
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


        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                //int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", row].Value.ToString();

                FrmAssessmentEdit fme = new FrmAssessmentEdit();

                fme.ass_code = val;
                fme.ShowDialog();

                Assessment pm = new Assessment();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                dtforprint = pm.Selectforprint();
                
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                FrmAssessmentprintviewer fmpv = new FrmAssessmentprintviewer();
                fmpv.P = dtforprint;
                
                fmpv.Show();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف ارزیابی بیمار اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (grdDataViewer.CurrentRow != null)
                {
                    //int icol = 0;
                    int irow = grdDataViewer.CurrentRow.Index;
                    string val = grdDataViewer["code", irow].Value.ToString();

                    Assessment mo = new Assessment();
                    mo.code = long.Parse(val);
                    mo.sick_id = grdDataViewer["sick_id", irow].Value.ToString();
                    mo.Delete();

                    Assessment pm = new Assessment();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;

                    dtforprint = pm.Selectforprint();
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