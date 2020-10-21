using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class frmDaftariPeygiriPrintViewerEntekhaabi : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();


        CurrencyManager objCurrencyManager;

        public string id = "";
        public string darman_date = "";
        public string sick_name = "";
        public DataTable idtable = new DataTable();

        

        public frmDaftariPeygiriPrintViewerEntekhaabi()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            FillDataSetAndView();

            objCurrencyManager.PositionChanged += new EventHandler(objCurrencyManager_PositionChanged);

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptPeygiri.rdlc";

            objCurrencyManager.Position = 0;
            //foreach (DataRow dtr in idtable.Rows)
            //{
            //    id = dtr["id"].ToString();
            //    LoadData();
            //}

            id = idtable.Rows[0]["id"].ToString();
            sick_name = idtable.Rows[0]["name"].ToString();
            darman_date = idtable.Rows[0]["darman_date"].ToString();
            LoadData();
            ShowPosition();
        }



        private void LoadData()
        {
            filler.Clear();

            reportDataSource1.Value = null;

            getData();

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            // Move to the previous record...
            objCurrencyManager.Position -= 1;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            // Set the record position to the first record...
            objCurrencyManager.Position = 0;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            objCurrencyManager.Position += 1;
            //Show the current record position...
            ShowPosition();
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            // Set the record position to the last record...
            objCurrencyManager.Position = objCurrencyManager.Count - 1;
            // Show the current record position...
            ShowPosition();
        }

        private void ShowPosition()
        {
            // Display the current position and the number of records
            txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
        }

        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[idtable]);


        }

        void objCurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            id = idtable.Rows[objCurrencyManager.Position]["id"].ToString();
            sick_name = idtable.Rows[objCurrencyManager.Position]["name"].ToString();
            darman_date = idtable.Rows[objCurrencyManager.Position]["darman_date"].ToString();
            LoadData();
        }

        private void getData()
        {
            Cursor.Current = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("WeekNo");
            dt.Columns.Add("tedad");

            Sicks si = new Sicks();

            string tod = cur_date;
            string next_week = "", pre_next_week = "", fd = darman_date;

            int i = 0;

            while (string.CompareOrdinal(next_week, tod) <= 0)
            {

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                                        int.Parse(fd.Substring(5, 2)),
                                                        int.Parse(fd.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                if (i <= 12)
                {
                    pre_next_week = (Shamsi((temp_date.AddDays(6)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(6)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(6)).Day.ToString("00")));

                    next_week = (Shamsi((temp_date.AddDays(7)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(7)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(7)).Day.ToString("00")));
                    i++;

                }
                else if (i > 12 && i <= 24)
                {
                    pre_next_week = (Shamsi((temp_date.AddDays(13)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(13)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(13)).Day.ToString("00")));

                    next_week = (Shamsi((temp_date.AddDays(14)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(14)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(14)).Day.ToString("00")));
                    i += 2;

                }
                else if (i > 24)
                {
                    pre_next_week = (Shamsi((temp_date.AddDays(27)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(27)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(27)).Day.ToString("00")));

                    next_week = (Shamsi((temp_date.AddDays(28)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(28)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(28)).Day.ToString("00")));
                    i += 4;
                }

                //Select FROM fd AND next_week WEEK////////////////////HERE
                DataTable vis_dt = si.Search("select count (distinct code) as tedad, min(date) as mindate from dastoor_pezeshk where (date>=N'" + fd + "' and date<'" + next_week + "' and sick_id=N'" + id + "')");
                string visit = vis_dt.Rows[0]["tedad"].ToString();
                string vis_date = "";



                if ((int.Parse(visit) > 0))
                    vis_date = vis_dt.Rows[0]["mindate"].ToString();

                dt.Rows.Add(new object[] { "تاریخ", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), vis_date });

                if (!(int.Parse(visit) > 0))
                {
                    if ((i - 1) <= 36)
                        visit = "O";
                    else if ((i - 1) > 36 && (i - 1) % 8 != 0)
                        visit = "O";
                    else
                        visit = "";
                }
                else
                    visit = "دارد";
                dt.Rows.Add(new object[] { "ویزیت بیمار", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), visit });
                /* END OF VISIT */

                /* START OF GHEYBAT */
                string gheybat = si.Search("select code from tahvil_koli where (tahvil_date>=N'" + fd + "' and tahvil_date<'" + next_week + "' and id=N'" + id + "') group by code having (sum(tedad)=0)").Rows.Count.ToString();
                if (!(int.Parse(gheybat) > 0))
                    gheybat = "";
                dt.Rows.Add(new object[] { "دفعات  غیبت در هفته", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), gheybat });
                /* END OF GHEYBAT */

                /* START OF AAZMAYESH EDRAR*/
                DataTable azmayeshdata = si.Search("select result from azmayesh where (date>=N'" + fd + "' and date<'" + next_week + "' and sick_id=N'" + id + "' and type=N'U/A')");

                string azmayeshedrar = "";
                if (azmayeshdata.Rows.Count == 0)
                {
                    if ((i - 1) > 0 && (i - 1) <= 10 && (i - 1) % 2 == 0)
                        azmayeshedrar = "O";
                    else if ((i - 1) > 10 && (i - 1) <= 36 && (i - 1) % 4 == 0)
                        azmayeshedrar = "O";
                    else if ((i - 1) > 36 && (i - 1) % 8 != 0)
                        azmayeshedrar = "O";
                    else
                        azmayeshedrar = "";
                }
                else
                    azmayeshedrar = azmayeshdata.Rows[azmayeshdata.Rows.Count - 1]["result"].ToString();
                dt.Rows.Add(new object[] { "آزمایش ادرار", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), azmayeshedrar });
                /* END OF AAZMAYESH EDRAR*/

                /* START OF MAP*/
                string map = si.Search("select count (distinct code) as tedad from mos_list where (mos_date>=N'" + fd + "' and mos_date<'" + next_week + "' and id=N'" + id + "')").Rows[0][0].ToString();
                if (!(int.Parse(map) > 0))
                {
                    if ((i - 1) >= 0 && (i - 1) <= 12 && (i - 1) % 4 == 0)
                        map = "O";
                    else if ((i - 1) > 12 && (i - 1) % 12 == 0)
                        map = "O";
                    else
                        map = "";
                }
                else
                    map = "دارد";
                dt.Rows.Add(new object[] { "M.A.P", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), map });
                /* END OF MAP*/

                /* START OF RAVANSHENAS*/
                string ravanshenas = si.Search("select count (distinct code) as tedad from ravanshenas where (date>=N'" + fd + "' and date<'" + next_week + "' and sick_id=N'" + id + "')").Rows[0][0].ToString();
                if (!(int.Parse(ravanshenas) > 0))
                {
                    if ((i - 1) <= 10)
                        ravanshenas = "O";
                    else
                        ravanshenas = "";
                }
                else
                    ravanshenas = "دارد";
                dt.Rows.Add(new object[] { "جلسات مشاوره و آموزش", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), ravanshenas });
                /* END OF RAVANSHENAS*/

                /* START OF CBC */
                string azmayeshCBC = si.Search("select count (distinct code) as tedad from azmayesh where (date>=N'" + fd + "' and date<'" + next_week + "' and sick_id=N'" + id + "' and type=N'LFT/CBC')").Rows[0][0].ToString();
                if (!(int.Parse(azmayeshCBC) > 0))
                {
                    if ((i - 1) == 12 || (i - 1) % 24 == 0)
                        azmayeshCBC = "O";
                    else
                        azmayeshCBC = "";
                }
                else
                    azmayeshCBC = "دارد";
                dt.Rows.Add(new object[] { "LFT/CBC", "از " + fd + " تا " + pre_next_week + " - " + "هفته " + (i - 1).ToString(), azmayeshCBC });
                /* END OF CBC */

                fd = next_week;

            }

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("id", id), 
                                                                                 new ReportParameter("name", sick_name), 
                                                                                 new ReportParameter("darman_date", darman_date)});

            filler = dt;
            reportDataSource1.Name = "MehrDataSet_Peygiri";
            reportDataSource1.Value = filler;
        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {

                ((DateMaskedTextbox)sender).BackColor = Color.Yellow;
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
            }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Yellow;
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }


        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.White;
            }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

        }
        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

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
    }
}