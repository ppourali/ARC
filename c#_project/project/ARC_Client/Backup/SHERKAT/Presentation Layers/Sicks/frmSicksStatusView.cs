using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class frmSicksStatusView : Form
    {
        public frmSicksStatusView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmSicksStatusView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //Sicks si = new Sicks();
            //DataTable dt = new DataTable();
            //dt = si.Select();

            chkActive.Checked = false;
            //btnfilter.PerformClick();

            txtfrom_date.Text = txttodate.Text = cur_date;

            //grdDataViewer.DataSource = dt;
            //btnfilter.PerformClick();
            grdDataViewer.AutoGenerateColumns = true;

         
            /*
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            grdDataViewer.Columns["hesab"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["roozaneh"].DefaultCellStyle = dataGridViewCellStyle1;
            */
            Colorize();
            
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Sicks rm = new Sicks();
                DataTable dt = new DataTable();

                string SQL ;

                if (chk0.Checked || chk0.CheckState == CheckState.Indeterminate)
                {
                    SQL = "select '0' as status, * from sicks where (len (payan_date)<10 and (id in(select id from tajviz where (date>=N'" + txtfrom_date.Text.Trim() + "' and date<=N'" + txttodate.Text.Trim() + "' ))))";
                    dt = rm.Search(SQL);
                }

                if (chk1.Checked)
                {
                    SQL = "select '1' as status, * from sicks where (len (payan_date)=10 and (id in(select id from tajviz where (date>=N'" + txtfrom_date.Text.Trim() + "' and date<=N'" + txttodate.Text.Trim() + "' ))))";
                    dt.Merge(rm.Search(SQL));
                }
                if (chk2.Checked)
                {
                    SQL = "select '2' as status, * from sicks where (len (payan_date)<10 and (id not in(select id from tajviz where (date>=N'" + txtfrom_date.Text.Trim() + "' and date<=N'" + txttodate.Text.Trim() + "' ))))";
                    dt.Merge(rm.Search(SQL));
                }
                if (chk3.Checked)
                {
                    SQL = "select '3' as status, * from sicks where (len (payan_date)=10 and (id not in(select id from tajviz where (date>=N'" + txtfrom_date.Text.Trim() + "' and date<=N'" + txttodate.Text.Trim() + "' ))))";
                    dt.Merge(rm.Search(SQL));
                }
                
                grdDataViewer.DataSource = dt;

               dt.DefaultView.Sort = "status";

               string[] col_headers = { "وضعیت", "شماره پرونده", "شروع درمان", "پایان درمان", "نام و نام خانوادگی", "نام پدر", "سن", "شهر", "شماره شناسنامه", "جنسیت", "تلفن منزل", "تلفن همراه", "مخدر مصرفی", "روش  ترک", "آدرس","هزینه روزانه","هزینه ی ماهانه",  "مانده حساب", "وضعیت حساب" };
               int[] col_width = { 60, 100, 70, 70, 130, 80, 40, 50, 70, 50, 80, 80, 100, 120, 115,70, 70, 70, 70 };

               for (int i = 0; i < col_headers.Length; i++)
               {
                   grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                   grdDataViewer.Columns[i].Width = col_width[i];
               }

               DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
               dataGridViewCellStyle1.Format = "N0";
               dataGridViewCellStyle1.NullValue = null;
               grdDataViewer.Columns["hesab"].DefaultCellStyle = dataGridViewCellStyle1;
               grdDataViewer.Columns["roozaneh"].DefaultCellStyle = dataGridViewCellStyle1;
               grdDataViewer.Columns["monthFee"].DefaultCellStyle = dataGridViewCellStyle1;

               Colorize();
                   
            }
            catch (Exception)
            {
               // MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtfrom_date.Focus();
                grdDataViewer.DataSource = null;
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtfrom_date.MaskCompleted || !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;
                //grdDataViewer.DataSource = null;
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


        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());

                frtv.tahORtaj = false;

                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            frmSickHisView fsh = new frmSickHisView();
            fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
            fsh.sabegheh = true;
            fsh.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (grdDataViewer.DataSource != null)
            {
                if (chkActive.Checked && !chkDeActive.Checked)
                {
                    ((DataTable)grdDataViewer.DataSource).DefaultView.RowFilter = "len(trim(payan_date))<10";
                }
                else if (!chkActive.Checked && chkDeActive.Checked)
                {
                    ((DataTable)grdDataViewer.DataSource).DefaultView.RowFilter = "len(trim(payan_date))=10";
                }
                else if ((!chkActive.Checked && !chkDeActive.Checked) || (chkActive.Checked && chkDeActive.Checked))
                {
                    ((DataTable)grdDataViewer.DataSource).DefaultView.RowFilter = "";
                }

                Colorize();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());

                frtv.tahORtaj = true;

                frtv.ShowDialog();
            }
        }

        private void Colorize()
        {
            foreach (DataGridViewRow dgvr in grdDataViewer.Rows)
            {
                if (dgvr.Cells[0].Value.ToString().Equals("0"))
                {

                    dgvr.DefaultCellStyle.BackColor = Color.Pink;

                    if (chk0.CheckState == CheckState.Indeterminate)
                    {

                        //checks for mismatch
                        tahvil ta = new tahvil();

                        DataTable allMetTahvil = new DataTable();
                        DataTable allBoopTahvil = new DataTable();
                        DataTable allSubTahvil = new DataTable();

                        string id = dgvr.Cells["id"].Value.ToString();

                        string from_date = txtfrom_date.Text;
                        string todate = txttodate.Text;
                        double MetTahvilTedad = 0, BoopTahvilTedad = 0, SubTahvilTedad = 0, MetTajvizTedad = 0, BoopTajvizTedad = 0, SubTajvizTedad = 0;

                        allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                               "FROM tahvil t0 " +
                               "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                               "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                               "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                               "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                               "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                        foreach (DataRow DR in allMetTahvil.Rows)
                        {
                            MetTahvilTedad += (double.Parse(DR["tedad"].ToString()));
                        }



                        allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                                    "FROM tahvil t0 " +
                                    "left JOIN ( SELECT tedad * 0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                                    "left JOIN ( SELECT tedad * 2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                    "left JOIN ( SELECT tedad * 8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                                    "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


                        foreach (DataRow DR in allBoopTahvil.Rows)
                        {
                            BoopTahvilTedad += (double.Parse(DR["tedad"].ToString()));
                        }


                        allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                                    "FROM tahvil t0 " +
                                    "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                                    "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                    "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


                        foreach (DataRow DR in allSubTahvil.Rows)
                        {
                            SubTahvilTedad += (double.Parse(DR["tedad"].ToString()));
                        }


                        //DataTable alltahvil = new DataTable();
                        //alltahvil.Merge(allMetTahvil);
                        //alltahvil.Merge(allBoopTahvil);
                        //alltahvil.Merge(allSubTahvil);
                        //alltahvil.DefaultView.Sort = "type";

                        //TAJVIZ////////////////////////////////////////////////////////////////////////////////////////////////////
                        DataTable allMetTajviz = new DataTable();
                        DataTable allBoopTajviz = new DataTable();
                        DataTable allSubTajviz = new DataTable();

                        allMetTajviz = ta.Search("SELECT distinct t0.tajviz_date, 'متادون' as type, t0.id, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                                 "FROM tajviz t0 " +
                                 "left JOIN ( SELECT tedad*5 as tedad,date FROM tajviz where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                                 "left JOIN ( SELECT tedad*5 as tedad,date FROM tajviz where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                 "left JOIN ( SELECT tedad*20 as tedad,date FROM tajviz where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                                 "left JOIN ( SELECT tedad*40 as tedad,date FROM tajviz where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                                 "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                        foreach (DataRow DR in allMetTajviz.Rows)
                        {
                            MetTajvizTedad += (double.Parse(DR["tedad"].ToString()));
                        }


                        allBoopTajviz = ta.Search("SELECT distinct t0.tajviz_date, 'بوپرنورفین' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                                    "FROM tajviz t0 " +
                                    "left JOIN ( SELECT tedad*0.4 as tedad,date FROM tajviz where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                                    "left JOIN ( SELECT tedad*2 as tedad,date FROM tajviz where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                    "left JOIN ( SELECT tedad*8  as tedad,date FROM tajviz where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                                    "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                        foreach (DataRow DR in allBoopTajviz.Rows)
                        {
                            BoopTajvizTedad += (double.Parse(DR["tedad"].ToString()));
                        }


                        allSubTajviz = ta.Search("SELECT distinct t0.tajviz_date, 'سوباکسون' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                                    "FROM tajviz t0 " +
                                    "left JOIN ( SELECT tedad*2 as tedad,date FROM tajviz where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                                    "left JOIN ( SELECT tedad*8 as tedad,date FROM tajviz where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                    "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                        foreach (DataRow DR in allSubTajviz.Rows)
                        {
                            SubTajvizTedad += (double.Parse(DR["tedad"].ToString()));
                        }


                        //DataTable alltajviz = new DataTable();
                        //alltajviz.Merge(allMetTajviz);
                        //alltajviz.Merge(allBoopTajviz);
                        //alltajviz.Merge(allSubTajviz);
                        //alltajviz.DefaultView.Sort = "type";

                        if ((MetTahvilTedad != MetTajvizTedad) || (BoopTahvilTedad != BoopTajvizTedad) || (SubTahvilTedad != SubTajvizTedad))
                        {
                            dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                    
                }
                else if (dgvr.Cells[0].Value.ToString().Equals("1"))
                    dgvr.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                else if (dgvr.Cells[0].Value.ToString().Equals("2"))
                    dgvr.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                else if (dgvr.Cells[0].Value.ToString().Equals("3"))
                    dgvr.DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        private void chkS_CheckedChanged(object sender, EventArgs e)
        {
            if(grdDataViewer.DataSource!=null)
            {
                string f = "";
                if (chk0.Checked || chk0.CheckState == CheckState.Indeterminate)
                    f += "status=0 or ";

                if (chk1.Checked)
                    f += "status=1 or ";

                if (chk2.Checked)
                    f += "status=2 or ";

                if (chk3.Checked)
                    f += "status=3 or ";


                if (f != "")
                    f = f.Substring(0, f.Length - 4);

                ((DataTable)grdDataViewer.DataSource).DefaultView.RowFilter = f;

                Colorize();
            }
        }

 
    }
}