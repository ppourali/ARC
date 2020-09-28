using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAdamTajvizView : Form
    {
        public frmAdamTajvizView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmAdamTajvizView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);


            btnfilter.PerformClick();

            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"مشخصه تحویل", "شماره پرونده","نام و نام خانوادگی","روز عدم مراجعه","تاریخ عدم مراجعه","شرح پیگیری"};
            int[] col_width = { 75, 100, 130, 80, 80, 248};

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

                string SQL = "SELECT distinct t1.code, t1.id, t1.name, t1.tajviz_day, t1.date, t2.comments from tajviz t1 " +
                                                                "left join (select distinct sick_id, date, comments from peygiri_real) t2 on (t1.id=t2.sick_id and t1.date=t2.date) " +
                                                                "where t1.tedad=0 AND ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "t1.id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname.Text != "")
                {
                    SQL = SQL + "t1.name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtdate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "t1.date>=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "t1.date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }


                if (checkBox1.Checked)
                {
                    SQL = SQL + "t1.date=N'" + cur_date.Trim() + "'AND ";
                    check = true;
                }
               
                    SQL = SQL.Remove(SQL.Length - 4)+" ORDER BY t1.date DESC";

                tajviz_koli tk=new tajviz_koli();
                DataTable dt = new DataTable();
                dt = tk.Search(SQL);
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


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.PerformClick();
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


  

        private void txtid_Validating(object sender, CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                grdDataViewer.Focus();
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmRealPeygiriInp))
                    {
                        IsOpen = true;
                        ((frmRealPeygiriInp)f).cur_date = grdDataViewer["date", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        f.Focus();
                        ((frmRealPeygiriInp)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmRealPeygiriInp)f).txtsick_id.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmRealPeygiriInp)f).idsearch_Click(null, null);   
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmRealPeygiriInp fsh = new frmRealPeygiriInp();
                    fsh.sentbyadamview = true; 
                    fsh.cur_date = grdDataViewer["date", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.txtsick_id.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);    
                }

                //grdDataViewer.Rows[cr].Selected = true;
            }
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.PerformClick();
        }

        private void grdDataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.PerformClick();
            }
            
        }

       
    }
}