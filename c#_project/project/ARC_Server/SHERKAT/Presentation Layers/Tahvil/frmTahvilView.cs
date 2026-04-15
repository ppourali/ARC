using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmTahvilView : Form
    {
        public FrmTahvilView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmTahvilView_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            Anbar an = new Anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from anbar");

            txtdaru_name.Items.Add("همه"); 
            foreach (DataRow dr in combosource.Rows)
                txtdaru_name.Items.Add(dr[0].ToString());
            
            txtdaru_name.SelectedIndex = 0;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //tahvil_koli tk=new tahvil_koli();
            //DataTable dt = new DataTable();
            //dt = tk.Select();

            checkBox1.Checked = true;
            btnfilter.PerformClick();

            //grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"مشخصه تحویل", "شماره پرونده","نام و نام خانوادگی","نوع درمان","روز تحویل","تاریخ تحویل","دارو از تاریخ","دارو تا تاریخ","نام دارو","دوز مصرف دوره"};
            int[] col_width = { 75, 100, 130, 120, 80, 85, 85, 85, 100, 80 };

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

                string SQL = "select * from tahvil_koli where ";
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

                if (txtdate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "tahvil_date>=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "tahvil_date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtdaru_name.SelectedIndex > 0)
                {
                    SQL = SQL + "daru_name = N'" + txtdaru_name.Text.Trim() + "'AND ";
                    check = true;
                }

                if (checkBox1.Checked)
                {
                    SQL = SQL + "tahvil_date=N'" + cur_date.Trim() + "'AND ";
                    check = true;
                }
                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4) + " ORDER BY code desc, daru_name ASC";
                }

                tahvil_koli tk=new tahvil_koli();
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


        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult diagr;
            diagr = MessageBox.Show("حدف تحویل دارو به منزله حدف تمامی داروهای این مشخصه می باشد. لطفا در تایید آن دقت فرمایید. آیا از حذف این مشخصه اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (diagr == DialogResult.Yes)
            {
                int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[icol, irow].Value.ToString();

                tahvil_koli tahk = new tahvil_koli();
                DataTable dttedad = new DataTable(); 
                tahk.code = long.Parse(val);
                dttedad = tahk.SelectforDelete();

                Anbar an = new Anbar();
                foreach (DataRow dr in dttedad.Rows)
                {
                    an.daru_name = dr["daru_name"].ToString().Trim();
                    an.mandeh = float.Parse(dr["tedad"].ToString().Trim());
                    an.UpdateAfterFactor();
                }
                
                tahk.Delete();

                new ActionLogs().Add("حذف تحویل داروی دفتری  به مشخصه ی " + val + " - شماره پرونده ی بیمار " + grdDataViewer["id", irow].Value.ToString());

                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    tahvil_koli tk = new tahvil_koli();
                    DataTable dt = new DataTable();
                    dt = tk.Select();
                    grdDataViewer.DataSource = dt;
                }
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && txtdaru_name.SelectedIndex == 0 && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                tahvil_koli tk=new tahvil_koli();
                DataTable dt = new DataTable();
                dt = tk.Select();
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


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmTahvilInput fti = new frmTahvilInput();
            fti.cur_date = cur_date;
            fti.ShowDialog();


            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                tahvil_koli tk = new tahvil_koli();
                DataTable dt = new DataTable();
                dt = tk.Select();
                grdDataViewer.DataSource = dt;
            }
        }       

        private void btnprint_Click(object sender, EventArgs e)
        {
                if (comboBox1.SelectedIndex == 0)
                {
                    FrmTahvilKoliPrintViewer ftkpv = new FrmTahvilKoliPrintViewer();
                    ftkpv.filler = (DataTable)(grdDataViewer.DataSource);
                    ftkpv.Show();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    DataTable ids = new DataTable();
                    ids.Columns.Add("id");
                    ids.Columns.Add("name");

                    DataTable idsandcodes = new DataTable();
                    idsandcodes.Columns.Add("id");
                    idsandcodes.Columns.Add("code");
                    idsandcodes.Columns.Add("date");

                    foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                    {
                        if (ids.Select("id='" + dgvr.Cells["id"].Value.ToString() + "'").Length == 0)
                        {
                            ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString() });
                        }

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["code"].Value.ToString() });
                    }


                    FrmTanzimPrintViewerOnline fgkpv = new FrmTanzimPrintViewerOnline();
                    //fgkpv.cur_code = grdDataViewer.CurrentRow.Cells["code"].Value.ToString();
                    fgkpv.idandcodestable = idsandcodes;
                    fgkpv.cur_date = grdDataViewer.CurrentRow.Cells["from_date"].Value.ToString();
                    //fgkpv.txtid.Text = grdDataViewer.CurrentRow.Cells["id"].Value.ToString();
                    ids.DefaultView.Sort = "id";
                    fgkpv.idtable = ids.DefaultView.ToTable();
                    //fgkpv.txtname.Text = grdDataViewer.CurrentRow.Cells["name"].Value.ToString();
                    fgkpv.ShowDialog();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    
                    if (!txtdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
                    {
                        MessageBox.Show("برای چاپ رسید باید یک بازه زمانی تعیین شود");
                    }
                    else if (!txtdate.MaskCompleted && !txttodate.MaskCompleted && checkBox1.Checked)
                    {
                        FrmTahvilResidPrintViewer ftkpv = new FrmTahvilResidPrintViewer();
                        ftkpv.filler = new tahvil_koli().TahvilResidByDate(cur_date, cur_date);
                        ftkpv.Show();
                    }
                    else
                    {
                        FrmTahvilResidPrintViewer ftkpv = new FrmTahvilResidPrintViewer();
                        ftkpv.ResidById = false;
                        ftkpv.txtdate.Text = txtdate.Text;
                        ftkpv.txttodate.Text = txttodate.Text;
                        ftkpv.Show();
                    }
                    
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                FrmRizTahvilView frtv = new FrmRizTahvilView();
                frtv.code = long.Parse(grdDataViewer["code", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                frtv.MdiParent = this.MdiParent; 
                frtv.Show();
            }
        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && txtdaru_name.SelectedIndex == 0 && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                tahvil_koli tk = new tahvil_koli();
                DataTable dt = new DataTable();
                dt = tk.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", row].Value.ToString();

                tahvil_koli tk = new  tahvil_koli();
                DataTable datat = new DataTable();
                tk.code = long.Parse(val);
                datat = tk.SelectforEdit();

                FrmTahvilEdit te = new FrmTahvilEdit();
                te.t_code = datat.Rows[0]["code"].ToString();
                te.sickname = datat.Rows[0]["name"].ToString();
                te.id = datat.Rows[0]["id"].ToString();
                te.txttahvil_date.Text = datat.Rows[0]["tahvil_date"].ToString();
                te.txtfrom_date.Text = datat.Rows[0]["from_date"].ToString();
                te.txtto_date.Text = datat.Rows[0]["to_date"].ToString();
                te.txttahvil_day.Text = datat.Rows[0]["tahvil_day"].ToString();
                te.toolStripStatusLabel1.Text = "مشخصه ی تحویل : " + datat.Rows[0]["code"].ToString();
                try
                {
                    te.d1 = datat.Rows[0]["daru_name"].ToString();
                    te.txttedad1.Text = (double.Parse(datat.Rows[0]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }
                
                try
                {
                    te.d2 = datat.Rows[1]["daru_name"].ToString();
                    te.txttedad2.Text = (double.Parse(datat.Rows[1]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                } 
                
                try
                {
                    te.d3 = datat.Rows[2]["daru_name"].ToString();
                    te.txttedad3.Text = (double.Parse(datat.Rows[2]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                } 
                
                try
                {
                    te.d4 = datat.Rows[3]["daru_name"].ToString();
                    te.txttedad4.Text = (double.Parse(datat.Rows[3]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }
                
                te.ShowDialog();

                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    tahvil_koli ta = new tahvil_koli();
                    DataTable dt = new DataTable();
                    dt = ta.Select();
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
            else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void frmTahvilView_Shown(object sender, EventArgs e)
        {
            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            Sicks ac = new Sicks();
            DataTable sickdt = new DataTable();
            sickdt = ac.Search("SELECT name FROM sicks WHERE (len(payan_date)!=10)");
            foreach (DataRow dtrow in sickdt.Rows)
                source.Add(dtrow["name"].ToString().Trim());

            // Create and initialize the text box.
            txtname.AutoCompleteCustomSource = source;
            txtname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (grdDataViewer["id", e.RowIndex].Value != null)
                {
                    txtid.Text = grdDataViewer["id", e.RowIndex].Value.ToString();
                    checkBox1.Checked = false; 
                    btnfilter.PerformClick();
                }
            }
        }
       
    }
}