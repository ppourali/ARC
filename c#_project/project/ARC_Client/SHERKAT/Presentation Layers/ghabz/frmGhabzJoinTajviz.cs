using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmGhabzJoinTajviz : Form
    {
        public frmGhabzJoinTajviz()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmGhabzJoinTajviz_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //tajviz_koli tajk = new tajviz_koli();
            //DataTable dt = new DataTable();
            //dt = tajk.Search("SELECT tajviz_koli.* , ghabz_id,mablagh,paid from tajviz_koli,ghabz");

            //grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            //string[] col_headers = { "مشخصه تحویل", "شماره پرونده", "نام", "نوع درمان", "روز تحویل", "تاریخ تحویل", "دارو از تاریخ", "دارو تا تاریخ", "نام دارو", "دوز مصرف دوره" };
            //int[] col_width = { 75, 90, 100, 120, 80, 80, 90, 110, 110, 90 };

            //for (int i = 0; i < col_headers.Length; i++)
            //{
            //    grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
            //    grdDataViewer.Columns[i].Width = col_width[i];
            //}

            grdDataViewer.DefaultCellStyle.BackColor = Color.SeaShell;
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            //objAlternatingCellStyle.BackColor = Color.Khaki;
            //grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.ShowAlways = true; 
            ToolTip1.SetToolTip(this.pnlnotpaid, "معرف لیست بیمارانی که دارو دریافت کرده اند، اما قبضی پرداخت نکرده اند");
            

            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.ShowAlways = true; 
            ToolTip2.SetToolTip(this.pnlpaid, "معرف لیست بیمارانی که دارو دریافت کرده اند و قبض مربوطه را پرداخت کرده اند");
            

            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.ShowAlways = true; 
            ToolTip3.SetToolTip(this.pnlpaidnodrugs, "معرف لیست بیمارانی که دارو دریافت نکرده اند، اما قبض پرداخت کرده اند");
            

            txtfromdate.Text = cur_date;
            txttodate.Text = cur_date;
            //btnfilter.PerformClick();


            
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                Sicks rm = new Sicks();
                DataTable dtnotpaid = new DataTable();
                DataTable dtpaid = new DataTable();
                DataTable dtpaidnodrug = new DataTable();  

                DataTable dtall = new DataTable();
                dtall.Clear();
                dtpaid.Clear();
                dtnotpaid.Clear();
                dtpaidnodrug.Clear();

                dtall.Columns.Add("code");
                dtall.Columns.Add("id");
                dtall.Columns.Add("name");
                dtall.Columns.Add("tajviz_day");
                dtall.Columns.Add("tajviz_date");
                dtall.Columns.Add("ghabz_id");
                dtall.Columns.Add("mablagh");
                dtall.Columns.Add("paid");

                dtall.Columns["mablagh"].DataType = typeof(long);
                dtall.Columns["paid"].DataType = typeof(long);

                dtpaid = dtall.Clone();
                dtpaidnodrug = dtall.Clone();
                dtnotpaid = dtall.Clone();



                DataTable dtdaru = rm.Search("SELECT distinct code,id,name,tajviz_day,tajviz_date FROM tajviz_koli WHERE (tajviz_date>=N'" + txtfromdate.Text + "' and tajviz_date<=N'" + txttodate.Text + "' and tedad>0)");
                DataTable dtghabz = rm.Search("SELECT id,ghabz_id,mablagh,paid,name,date FROM ghabz WHERE (date>=N'" + txtfromdate.Text + "'  and date<=N'" + txttodate.Text + "')");

                DataTable dtdarucopy = dtdaru.Copy();

                string day = "----";

                for (int i = 0; i < dtdaru.Rows.Count; i++)
                {
                    DataRow dr = dtdaru.Rows[i];

                    string darucode = dr["code"].ToString();
                    string daruid = dr["id"].ToString();
                    string daruname = dr["name"].ToString();
                    string darutajviz_day = dr["tajviz_day"].ToString();
                    string darutajviz_date = dr["tajviz_date"].ToString();


                    DataRow[] dtghabzrow = dtghabz.Select("id='" + daruid + "' and date='" + darutajviz_date + "'");

                    if (dtghabzrow.Length > 0)
                    {
                        string ghabzid = dtghabzrow[0]["ghabz_id"].ToString();
                        string ghabzmablagh = dtghabzrow[0]["mablagh"].ToString();
                        string ghabzpaid = dtghabzrow[0]["paid"].ToString();

                        dtpaid.Rows.Add(new object[] { darucode, daruid, daruname, darutajviz_day, darutajviz_date, ghabzid, ghabzmablagh, ghabzpaid });

                        dtghabz.Rows.Remove(dtghabzrow[0]);
                    }
                    else
                    {
                        dtnotpaid.Rows.Add(new object[] { darucode, daruid, daruname, darutajviz_day, darutajviz_date, "----", 0, 0 });
                    }

                    day = darutajviz_day;
                }

                for (int i = 0; i < dtghabz.Rows.Count; i++)
                {
                    DataRow dr = dtghabz.Rows[i];

                    string darucode = "----";
                    string daruid = dr["id"].ToString();
                    string daruname = dr["name"].ToString();
                    string darutajviz_day = day;
                    string darutajviz_date = dr["date"].ToString();

                    string ghabzid = dr["ghabz_id"].ToString();
                    string ghabzmablagh = dr["mablagh"].ToString();
                    string ghabzpaid = dr["paid"].ToString();

                    dtpaidnodrug.Rows.Add(new object[] { darucode, daruid, daruname, darutajviz_day, darutajviz_date, ghabzid, ghabzmablagh, ghabzpaid });

                }

                dtall.Merge(dtnotpaid, true, MissingSchemaAction.Add);
                dtall.Merge(dtpaidnodrug, true, MissingSchemaAction.Add);
                dtall.Merge(dtpaid, true, MissingSchemaAction.Add);


                //dtall.DefaultView.Sort = "code";
                grdDataViewer.DataSource = dtall;


                foreach (DataGridViewRow dgvr in grdDataViewer.Rows)
                {
                    if (dgvr.Cells["ghabz_id"].Value == null || dgvr.Cells["ghabz_id"].Value.ToString().Trim() == "" || dgvr.Cells["ghabz_id"].Value.ToString().Trim() == "----")
                        dgvr.DefaultCellStyle.BackColor = Color.Pink;

                    else if (dgvr.Cells["code"].Value == null || dgvr.Cells["code"].Value.ToString().Trim() == "" || dgvr.Cells["code"].Value.ToString().Trim() == "----")
                        dgvr.DefaultCellStyle.BackColor = Color.PowderBlue;


                }

                grdDataViewer.CurrentCell = null;

                DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                dataGridViewCellStyle1.Format = "N0";
                grdDataViewer.Columns["mablagh"].DefaultCellStyle = dataGridViewCellStyle1;
                grdDataViewer.Columns["paid"].DefaultCellStyle = dataGridViewCellStyle1;

            }
            catch (Exception)
            {
                MessageBox.Show("انجام عملیات با مشکل مواجه شد!!!");
                txtfromdate.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtfromdate.MaskCompleted || !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;
                btnfilter.PerformClick();
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
            if (grdDataViewer.CurrentRow!=null)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                
                if (Program.user_semat.Trim() == "بازرس")
                    frtv.tahORtaj = false;
                else
                    frtv.tahORtaj = true;

                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                frmSickHisView fsh = new frmSickHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }

        private void pnlnotpaid_Click(object sender, EventArgs e)
        {
            MessageBox.Show("معرف لیست بیمارانی که دارو دریافت کرده اند، اما قبضی پرداخت نکرده اند");
        }

        private void pnlpaidnodrugs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("معرف لیست بیمارانی که دارو دریافت نکرده اند، اما قبض پرداخت کرده اند");
        }

        private void pnlpaid_Click(object sender, EventArgs e)
        {
            MessageBox.Show("معرف لیست بیمارانی که دارو دریافت کرده اند و قبض مربوطه را پرداخت کرده اند");
        }
    }
}