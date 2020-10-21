using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmMetDaftarShow : Form
    {
        public frmMetDaftarShow()
        {
            InitializeComponent();
        }

        public string cur_date = "";

        string daybeforedate = "";
        DataTable feli = new DataTable();
        string[] mandeh = new string[4];

        private void frmMetDaftarShow_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            grdDaftar.AutoGenerateColumns = true;


            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDaftar.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;


            txtdate.Text = txttodate.Text = cur_date;
        }

        public string Shamsi(string date)
        {
            int[] arrMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] arrStart = { 21, 20, 21, 21, 22, 22, 23, 23, 23, 23, 22, 22 };
            char[] sep = { '/' };
            string[] arrDate = date.Split(sep);
            int year = Convert.ToInt32(arrDate[0]);
            int month = Convert.ToInt32(arrDate[1]);
            int day = Convert.ToInt32(arrDate[2]);
            if (year % 4 == 0)
            {
                for (int i = 2; i < 12; i++)
                    arrStart[i]--;
                arrMonths[1]++;
                if (month == 1) arrStart[11]++;
            }
            else if (year % 4 == 1)
            {
                arrStart[0]--;
                arrStart[1]--;
                if (month == 1) arrStart[11]--;
            }
            year = month <= 3 ? year - 622 : year - 621;
            if (month == 3 && day >= arrStart[2]) year++;
            if (day < arrStart[month - 1])
            {
                int i = month == 1 ? 11 : month - 2;
                day = day - arrStart[i] + arrMonths[i] + 1;
                month -= 3;
            }
            else
            {
                day = day - arrStart[month - 1] + 1;
                month -= 2;
            }
            if (month <= 0) month += 12;
            return year + "/" + Convert.ToString(month).PadLeft(2, '0') + "/" +
            Convert.ToString(day).PadLeft(2, '0');


        }

        public void btnfilter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                                        int.Parse(txtdate.Text.Substring(5, 2)),
                                                        int.Parse(txtdate.Text.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                daybeforedate = (Shamsi((temp_date.AddDays(-1)).Year.ToString("0000") + "/" +
                                        (temp_date.AddDays(-1)).Month.ToString("00") + "/" +
                                        (temp_date.AddDays(-1)).Day.ToString("00")));



                string[] names = { "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "شربت متادون" };
                DataTable metadones = new DataTable();
                metadones.Columns.Add("radif");
                metadones.Columns.Add("name");
                metadones.Columns.Add("date");
                metadones.Columns.Add("m5fd");
                metadones.Columns.Add("m20fd");
                metadones.Columns.Add("m40fd");
                metadones.Columns.Add("spfd");
                metadones.Columns.Add("m5mandeh");
                metadones.Columns.Add("m20mandeh");
                metadones.Columns.Add("m40mandeh");
                metadones.Columns.Add("spmandeh");


                for (int i = 0; i < names.Length; i++)
                {
                    mandeh[i] = auto_calc(names[i]);
                }

                DataTable dttk = new DataTable();
                tahvil_koli tk = new tahvil_koli();

                dttk = tk.Search("select distinct code, name, tahvil_date from tahvil_koli where (tahvil_date>=N'" + txtdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "' and daru_name like N'%متادون%') ORDER BY tahvil_date ASC");
                int counter = 0;

                factors fa = new factors();
                string ted = "0";

              
                foreach (DataRow codedr in dttk.Rows)
                {
                    string hghg;
                    if( codedr["name"].ToString().Contains("محرم"))
                         hghg="";

                    string[] temp_array = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

                    temp_array[0] = (++counter).ToString();
                    temp_array[1] = codedr["name"].ToString();
                    temp_array[2] = codedr["tahvil_date"].ToString();

                    for (int j = 0; j < names.Length; j++)
                    {
                        temp_array[3 + j] = GetDose(codedr["code"].ToString(), names[j], double.Parse(mandeh[j]), j);

                        fa.daru_name = names[j];
                        fa.fromdate = txtdate.Text;
                        fa.todate = codedr["tahvil_date"].ToString();
                        
                        ted = "0";
                        ted = fa.gettedad().Rows[0]["tedad"].ToString();

                        if (ted.Trim() == "" || ted.Trim() == "0")
                            temp_array[7 + j] = mandeh[j];
                        else
                            temp_array[7 + j] = ted + "ف + " + mandeh[j] + " = " + (double.Parse(ted) + double.Parse(mandeh[j])).ToString();
                    }

                    metadones.Rows.Add(temp_array);
                }

                grdDaftar.DataSource = metadones;

                string[] col_headers = { "ردیف", "نام", "تاریخ", "متادون 5", "متادون 20", "متادون 40", "شربت متادون", "مانده  5 ", "مانده  20", "مانده  40", "مانده شربت" };
                int[] col_width = { 45, 130, 70, 70, 70, 70, 70, 130, 65, 65, 130 };

                for (int i = 0; i < col_headers.Length; i++)
                {
                    grdDaftar.Columns[i].HeaderText = col_headers[i].ToString();
                    grdDaftar.Columns[i].Width = col_width[i];
                }
                grdDaftar.Columns[3].DefaultCellStyle.BackColor = Color.LightBlue;
                grdDaftar.Columns[4].DefaultCellStyle.BackColor = Color.LightBlue;
                grdDaftar.Columns[5].DefaultCellStyle.BackColor = Color.LightBlue;
                grdDaftar.Columns[6].DefaultCellStyle.BackColor = Color.LightBlue;

                grdDaftar.Columns[7].DefaultCellStyle.BackColor = Color.Pink;
                grdDaftar.Columns[8].DefaultCellStyle.BackColor = Color.Pink;
                grdDaftar.Columns[9].DefaultCellStyle.BackColor = Color.Pink;
                grdDaftar.Columns[10].DefaultCellStyle.BackColor = Color.Pink;
            }
            catch (Exception exp)
            {
                MessageBox.Show(" انجام عملیات با مشکل مواجه شد " + exp.ToString());
            }
    }

        private string auto_calc(string daru_name)
        {

            anbar an = new anbar();
            DataTable temp_db = new DataTable();
            DataTable lastf_dt = new DataTable();

            factors fa = new factors();

            tahvil_koli tk = new tahvil_koli();
            DataTable dttah = new DataTable();


            string lastfactor = "0";
            string mandeh = "0"; ;
            string masrafi = "0";
            temp_db.Clear();
            lastf_dt.Clear();
            dttah.Clear();
            an.daru_name = daru_name;

            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh = temp_db.Rows[0]["mandeh"].ToString();


            fa.todate = daybeforedate;
            fa.daru_name = daru_name;
            lastf_dt = fa.gettedadAfterforAmar();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();


            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>N'" + daybeforedate.Trim() + "' and daru_name=N'" + daru_name + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            return (double.Parse(mandeh) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

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
                this.ProcessTabKey(true);
                e.Handled = true;
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

        private string GetDose(string code, string daru_name, double temp_mandeh, int p)
        {
            DataTable dttk = new DataTable();
            tahvil_koli tk = new tahvil_koli();

            dttk = tk.Search("select name,tedad,from_date,to_date from tahvil_koli where (code=N'" + code + "' and daru_name=N'" + daru_name.Trim() + "')");

            double datedif = 0, firstday = 0, takehome = 0;

            DataTable temp = new DataTable();
            temp.Columns.Add("name");
            temp.Columns.Add("spfirstday");
            temp.Columns.Add("sptakehome");

            if (dttk.Rows.Count > 0)
            {
                datedif = 0;
                firstday = 0;
                takehome = 0;

                System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                TimeSpan ts = xd.ToDateTime(int.Parse(dttk.Rows[0]["to_date"].ToString().Substring(0, 4)),
                                            int.Parse(dttk.Rows[0]["to_date"].ToString().Substring(5, 2)),
                                            int.Parse(dttk.Rows[0]["to_date"].ToString().Substring(8, 2)),
                                            0, 0, 0, 0, 0)
                              - xd.ToDateTime(int.Parse(dttk.Rows[0]["from_date"].ToString().Substring(0, 4)),
                                            int.Parse(dttk.Rows[0]["from_date"].ToString().Substring(5, 2)),
                                            int.Parse(dttk.Rows[0]["from_date"].ToString().Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                datedif = (ts.TotalDays);

                firstday = double.Parse(dttk.Rows[0]["tedad"].ToString()) / datedif;
                takehome = double.Parse(dttk.Rows[0]["tedad"].ToString()) - firstday;

                mandeh[p] = (temp_mandeh - double.Parse(dttk.Rows[0]["tedad"].ToString())).ToString();

                return takehome.ToString() + " + " + firstday.ToString();
            }
            else
            {
                return "0";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmDaftarPrintViewer fdpv = new frmDaftarPrintViewer();
            fdpv.choose = 0;
            fdpv.fromdate = txtdate.Text;
            fdpv.todate = txttodate.Text;
            fdpv.filler = (DataTable)(grdDaftar.DataSource);
            fdpv.Show();

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}