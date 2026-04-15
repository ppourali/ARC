using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmAmarKoliView : Form
    {
        public FrmAmarKoliView()
        {
            InitializeComponent();
        }

        string[] row_headers = { "شربت متادون", "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "با احتساب ضرایب", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "با احتساب ضرایب", "قرص سوباکسون 2", "قرص سوباکسون 8", "با احتساب ضرایب" };
        public string cur_date;

        private void frmAmarKoliView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txttodate.Text = txtdate.Text;

            btnfilter.PerformClick();
        }


        public void btnfilter_Click(object sender, EventArgs e)
        {
            grdAllDataView.DataSource = null;
            grdAllDataView.Rows.Clear();
            grdAllDataView.Columns.Clear();
            //Add Column
            string[] col_headers = { "نام دارو", "تعداد کل مصرفی دفتر", "تعداد پوکه", "آخرین تعداد موجود در دفتر در تاریخ " + txttodate.Text, "تعداد موجودی فعلی دفتر", "تعداد کل مصرفی بیماران", "آخرین تعداد موجود مرکز در تاریخ " + txttodate.Text, "تعداد کل موجودی مرکز","تعداد موجودی فعلی گاوصندوق", "تعداد موجودی فعلی پرستار" };
            //int[] col_width = { 100, 90, 130, 80, 80, 80, 120 };


            for (int i = 0; i < col_headers.Length; i++)
            {
                grdAllDataView.Columns.Add("col" + i, col_headers[i].ToString());
                grdAllDataView.Columns[i].Width = 80;
            }

            grdAllDataView.Columns[0].Width = 140;

            grdAllDataView.Columns[1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[2].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[3].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[4].DefaultCellStyle.BackColor = Color.LightSkyBlue;

            grdAllDataView.Columns[5].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[6].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[7].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[8].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[9].DefaultCellStyle.BackColor = Color.MistyRose;




            //Add Row
            grdAllDataView.Rows.Add(12);


            for (int i = 0; i < row_headers.Length; i++)
            {
                grdAllDataView[0, i].Value = row_headers[i];
            }

            grdAllDataView.Columns.Add("Result", "تفاوت موجودی دفتر و مرکز");
            grdAllDataView.Columns[10].Width = 90;

            grdAllDataView.Columns.Add("Result", "تفاوت موجودی دفتر و مرکز در تاریخ"+txttodate.Text);
            grdAllDataView.Columns[11].Width = 90;

            grdAllDataView.Columns.Add("ParastariDaftari","تعداد موجودی پرستاری دفتری");
            grdAllDataView.Columns[12].Width = 90;

            grdAllDataView.CurrentCell = null;

            ////////////////////////////////////////////////////////////////////////
            tajviz_anbar atn = new tajviz_anbar();
            DataTable dtt = new DataTable();
            dtt = atn.Search("SELECT daru_name, mandeh from tajviz_anbar");

     
            foreach (DataRow dtrow in dtt.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[8, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////

            parastar_anbar pa = new parastar_anbar();
            DataTable dtpan = new DataTable();
            dtpan = pa.Search("SELECT daru_name, mandeh from parastar_anbar");

            foreach (DataRow dtrow in dtpan.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[9, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////
            Anbar an = new Anbar();
            DataTable dt = new DataTable();
            dt = an.Search("SELECT daru_name, mandeh from anbar");

            foreach (DataRow dtrow in dt.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[4, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////
            tahvil_koli tk = new tahvil_koli();
            DataTable dttah = new DataTable();
            dttah = tk.Search("select daru_name,sum(tedad) as mandeh from tahvil_koli where (tahvil_date>=N'" + txtdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name");


            foreach (DataRow dtrow in dttah.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[1, i].Value = dtrow["mandeh"].ToString().Trim();
                        grdAllDataView[2, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////


            tajviz_koli tj = new tajviz_koli();
            DataTable dttaj = new DataTable();
            dttaj = tj.Search("select daru_name,sum(tedad) as mandeh from tajviz_koli where (tajviz_date>=N'" + txtdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name");
            //grdTajviz.DataSource = dttaj;
            //grdTajviz.AutoGenerateColumns = false;

            foreach (DataRow dtrow in dttaj.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[5, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////
            DataTable daftar_feli = auto_calc();

            foreach (DataRow dtrow in daftar_feli.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[3, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////
            DataTable bimaran_feli = auto_calc_bimaran();

            foreach (DataRow dtrow in bimaran_feli.Rows)
            {
                for (int i = 0; i < row_headers.Length; i++)
                {
                    if (dtrow["daru_name"].ToString().Trim() == row_headers[i].ToString().Trim())
                    {
                        grdAllDataView[6, i].Value = dtrow["mandeh"].ToString().Trim();
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////


            for (int j = 0; j < grdAllDataView.Rows.Count; j++)
            {
                for (int k = 1; k < grdAllDataView.Columns.Count; k++)
                {
                    if (grdAllDataView[k, j].Value == null || grdAllDataView[k, j].Value.ToString().Trim() == "")
                        grdAllDataView[k, j].Value = "0";
                }
            }

            ehtesabe_zarayeb();

            for (int r = 0; r < grdAllDataView.Rows.Count; r++)
            {
                grdAllDataView[7, r].Value = (float.Parse(grdAllDataView[8, r].Value.ToString()) + float.Parse(grdAllDataView[9, r].Value.ToString())).ToString();
                grdAllDataView[10, r].Value = (float.Parse(grdAllDataView[7, r].Value.ToString()) - float.Parse(grdAllDataView[4, r].Value.ToString())).ToString();
            }


            for (int r = 0; r < grdAllDataView.Rows.Count; r++)
            {
                grdAllDataView[11, r].Value = (float.Parse(grdAllDataView[6, r].Value.ToString()) - float.Parse(grdAllDataView[3, r].Value.ToString())).ToString();
            }


            for (int r = 0; r < grdAllDataView.Rows.Count; r++)
            {
                grdAllDataView[12, r].Value = (float.Parse(grdAllDataView[9, r].Value.ToString()) - float.Parse(grdAllDataView[11, r].Value.ToString())).ToString();
            }

            if (txtdate.Text.Equals(txttodate.Text))
                btnRecord.Enabled = true;
            else
                btnRecord.Enabled = false;
        }


        private void ehtesabe_zarayeb()
        {

            Font f = new Font("Tahoma", 9, FontStyle.Bold);
            grdAllDataView.Rows[0].DefaultCellStyle.BackColor = Color.Khaki;
            grdAllDataView.Rows[0].DefaultCellStyle.Font = f;

            for (int i = 1; i < grdAllDataView.Columns.Count; i++)
            {
                grdAllDataView[i, 4].Value = ((float.Parse(grdAllDataView[i, 1].Value.ToString())) + (float.Parse(grdAllDataView[i, 2].Value.ToString()) * 4) + (float.Parse(grdAllDataView[i, 3].Value.ToString()) * 8)).ToString();
                grdAllDataView.Rows[4].DefaultCellStyle.BackColor = Color.Khaki;
                grdAllDataView.Rows[4].DefaultCellStyle.Font = f;

                grdAllDataView[i, 8].Value = ((float.Parse(grdAllDataView[i, 5].Value.ToString())) + (float.Parse(grdAllDataView[i, 6].Value.ToString()) * 5) + (float.Parse(grdAllDataView[i, 7].Value.ToString()) * 20)).ToString();
                grdAllDataView.Rows[8].DefaultCellStyle.BackColor = Color.Khaki;
                grdAllDataView.Rows[8].DefaultCellStyle.Font = f;

                grdAllDataView[i, 11].Value = ((float.Parse(grdAllDataView[i, 9].Value.ToString())) + (float.Parse(grdAllDataView[i, 10].Value.ToString()) * 4)).ToString();
                grdAllDataView.Rows[11].DefaultCellStyle.BackColor = Color.Khaki;
                grdAllDataView.Rows[11].DefaultCellStyle.Font = f;
            }
        }

        private DataTable auto_calc()
        {
            string[] names = { "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "شربت متادون", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "قرص سوباکسون 2", "قرص سوباکسون 8" };

            Anbar an = new Anbar();
            DataTable temp_db = new DataTable();
            DataTable lastf_dt = new DataTable();

            factors fa = new factors();

            tahvil_koli tk = new tahvil_koli();
            DataTable dttah = new DataTable();

            DataTable feli = new DataTable();
            feli.Columns.Add("daru_name");
            feli.Columns.Add("mandeh");

            for (int i = 0; i < names.Length; i++)
            {
                string lastfactor = "0";
                string mandeh = "0"; ;
                string masrafi = "0";
                temp_db.Clear();
                lastf_dt.Clear();
                dttah.Clear();
                an.daru_name = names[i];

                temp_db = an.Selectforedit();
                if (temp_db.Rows.Count > 0)
                    mandeh = temp_db.Rows[0]["mandeh"].ToString();


                fa.todate = txttodate.Text;
                fa.daru_name = names[i];
                lastf_dt = fa.gettedadAfterforAmar();
                if (lastf_dt.Rows.Count > 0)
                    lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

                if (lastfactor.Trim() == "")
                    lastfactor = "0";

                dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>N'" + txttodate.Text.Trim() + "' and daru_name=N'" + names[i] + "')");
                if (dttah.Rows.Count > 0)
                    masrafi = dttah.Rows[0]["masrafi"].ToString();

                if (masrafi == null || masrafi == "")
                    masrafi = "0";
                //DataRow dr=new DataRow();
                //dr[0] = names[i];
                //dr[1] = long.Parse(mandeh) + long.Parse(masrafi) - long.Parse(lastfactor);

                feli.Rows.Add(new object[] { names[i], (double.Parse(mandeh) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString() });
            }

            return feli;
        }

        private DataTable auto_calc_bimaran()
        {
            string[] names = { "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "شربت متادون", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "قرص سوباکسون 2", "قرص سوباکسون 8" };

            tajviz_anbar an = new tajviz_anbar();
            DataTable temp_db = new DataTable();
            DataTable lastf_dt = new DataTable();
            DataTable lastcontact_dt = new DataTable();

            parastar_anbar pan = new parastar_anbar();
            DataTable dtpan = new DataTable();

            tajviz_factors fa = new tajviz_factors();

            tajviz_anbar_history tanh = new tajviz_anbar_history();
            
            tajviz_koli tj = new tajviz_koli();
            DataTable dttaj = new DataTable();

            DataTable feli = new DataTable();
            feli.Columns.Add("daru_name");
            feli.Columns.Add("mandeh");

            for (int i = 0; i < names.Length; i++)
            {
                string lastfactor = "0";
                string lastcon = "0";
                string mandeh = "0"; ;
                string masrafi = "0";
                string parastar_mandeh = "0";

                temp_db.Clear();
                lastf_dt.Clear();
                dttaj.Clear();
                an.daru_name = names[i];

                temp_db = an.Selectforedit();
                if (temp_db.Rows.Count > 0)
                    mandeh = temp_db.Rows[0]["mandeh"].ToString();

                pan.daru_name = names[i];
                dtpan = pan.Selectforedit();
                if (dtpan.Rows.Count > 0)
                    parastar_mandeh = dtpan.Rows[0]["mandeh"].ToString();


                // chon az historye gav sandogh kollan sum gerefteh shod niaazi be mohasebeye factor jodaagaaneh nist
                //fa.todate = txttodate.Text;
                //fa.daru_name = names[i];
                //lastf_dt = fa.gettedadAfterforAmar();
                //if (lastf_dt.Rows.Count > 0)
                //    lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

                //if (lastfactor.Trim() == "")
                //    lastfactor = "0";


                tanh.todate = txttodate.Text;
                tanh.daru_name = names[i];
                lastcontact_dt = tanh.gettedadAfterforAmar();
                if (lastcontact_dt.Rows.Count > 0)
                    lastcon = lastcontact_dt.Rows[0]["tedad"].ToString();

                if (lastcon.Trim() == "")
                    lastcon = "0";

                dttaj = tj.Search("select sum(tedad) as masrafi from tajviz_koli where (tajviz_date>N'" + txttodate.Text.Trim() + "' and daru_name=N'" + names[i] + "')");
                if (dttaj.Rows.Count > 0)
                    masrafi = dttaj.Rows[0]["masrafi"].ToString();

                if (masrafi == null || masrafi == "")
                    masrafi = "0";

                feli.Rows.Add(new object[] { names[i], (double.Parse(mandeh) + double.Parse(parastar_mandeh) + double.Parse(masrafi) + double.Parse(lastcon)).ToString() });
            }

            return feli;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void TextChanged_Action(object sender, EventArgs e)
        {


            if (!txtdate.MaskCompleted || !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;
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
                e.SuppressKeyPress = true;
                this.ProcessTabKey(true);
                //e.Handled = true; 
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            DataTable qdt = new MehrDataSet.amarkoliroozanehDataTable();

            for (int i = 0; i < grdAllDataView.Rows.Count; i++)
            {
                qdt.Rows.Add(new object[] {grdAllDataView.Rows[i].Cells[0].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[1].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[2].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[3].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[4].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[5].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[6].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[7].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[8].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[9].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[10].Value.ToString()});
            }


            FrmAmar_koliPrintViewer fsipv = new FrmAmar_koliPrintViewer();
            fsipv.filler = (DataTable)(qdt);
            fsipv.fd = txtdate.Text;
            fsipv.td = txttodate.Text;
            fsipv.Show();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                AmarRecords ar = new AmarRecords();
                ar.date = txttodate.Text;
                ar.reg_date = cur_date;
                ar.Delete();
                for (int i = 0; i < grdAllDataView.Rows.Count; i++)
                {
                    ar.daru_name = grdAllDataView[0, i].Value.ToString();
                    ar.kol_masrafi_daftar = grdAllDataView[1, i].Value.ToString();
                    ar.pookeh = grdAllDataView[2, i].Value.ToString();
                    ar.last_tedad_on_date_daftar = grdAllDataView[3, i].Value.ToString();
                    ar.nowtedad_daftar = grdAllDataView[4, i].Value.ToString();
                    ar.kol_masrafi_sandogh = grdAllDataView[5, i].Value.ToString();
                    ar.last_tedad_on_date_sandogh = grdAllDataView[6, i].Value.ToString();
                    ar.nowtedad_kol = grdAllDataView[7, i].Value.ToString();
                    ar.nowtedad_sandogh = grdAllDataView[8, i].Value.ToString();
                    ar.nowtedad_parastar = grdAllDataView[9, i].Value.ToString();
                    ar.differences = grdAllDataView[10, i].Value.ToString();

                    ar.Add();
                }

                new ActionLogs().Add("ثبت رکورد روزانه مرکز به تاریخ : " + txttodate.Text);
                
                MessageBox.Show("عملیات ثبت رکورد با موفقیت انجام شد");
            }
            catch
            {
                MessageBox.Show("عملیات ثبت رکورد با مشکل مواجه شد");
            }


        }
    }
}