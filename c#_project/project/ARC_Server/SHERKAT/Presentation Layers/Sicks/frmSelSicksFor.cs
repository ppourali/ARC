using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmSelSicksFor : Form
    {
        public FrmSelSicksFor()
        {
            InitializeComponent();
        }

        public string cur_date;

        private void frmSelSicksFor_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            comboBox1.SelectedIndex = 0;

            txtdate.Text = cur_date;
            txttodate.Text = cur_date;

            panel1.Focus();
            txtdate.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSabegheh_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                FrmAzmayeshHisView fsh = new FrmAzmayeshHisView();
                int irow = dataGridView1.CurrentRow.Index;
                fsh.sid = dataGridView1["id", irow].Value.ToString();
                fsh.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                FrmDastoorHisView fsh = new FrmDastoorHisView();
                int irow = dataGridView1.CurrentRow.Index;
                fsh.sid = dataGridView1["id", irow].Value.ToString();
                fsh.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                FrmRavanshenasHisView fsh = new FrmRavanshenasHisView();
                int irow = dataGridView1.CurrentRow.Index;
                fsh.sid = dataGridView1["id", irow].Value.ToString();
                fsh.ShowDialog();
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted && !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;

                dataGridView1.DataSource = null;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            string date_dif = "";
            try
            {

                if (decimal.Parse(txttodate.Text.Replace("/", "")) < decimal.Parse(txtdate.Text.Replace("/", "")))
                {
                    MessageBox.Show("تاریخ شروع نمی تواند پیش از تاریخ پایان باشد", "خطا");
                    ((DateMaskedTextbox)sender).Focus();
                    ((DateMaskedTextbox)sender).SelectAll();
                }
                else
                {

                    System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                    TimeSpan ts = xd.ToDateTime(int.Parse(txttodate.Text.Substring(0, 4)),
                                                int.Parse(txttodate.Text.Substring(5, 2)),
                                                int.Parse(txttodate.Text.Substring(8, 2)),
                                                0, 0, 0, 0, 0)
                                  - xd.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                                int.Parse(txtdate.Text.Substring(5, 2)),
                                                int.Parse(txtdate.Text.Substring(8, 2)),
                                                0, 0, 0, 0, 0);

                    date_dif = (ts.TotalDays + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("لطفا تاریخ را به صورت صحیح وارد نمایید");
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
            }

            DataTable alldt = new DataTable();
            for (int i = 0; i < int.Parse(date_dif); i++)
            {

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                                        int.Parse(txtdate.Text.Substring(5, 2)),
                                                        int.Parse(txtdate.Text.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                string todaydate = (Shamsi((temp_date.AddDays(i)).Year.ToString("0000") + "/" +
                                        (temp_date.AddDays(i)).Month.ToString("00") + "/" +
                                        (temp_date.AddDays(i)).Day.ToString("00")));


                Sicks sicksearch = new Sicks();
                alldt.Merge(sicksearch.Search("select distinct s0.id, s0.name, s1.code as dascode, s1.date as dasdate, s2.code as ravcode, s2.date as ravdate, s3.code as azcode, s3.date as azdate, t1.code as tahvilcode,tahvil_date, from_date, to_date  from sicks s0 " +
    "left join (select distinct id, code, tahvil_date, from_date, to_date from tahvil_koli where(tahvil_date>=N'" + txtdate.Text + "' and tahvil_date<=N'" + txttodate.Text + "')) t1 ON (t1.id=s0.id  and t1.tahvil_date=N'" + todaydate + "') " +
    "left join (select sick_id, code, date from Dastoor_pezeshk where(date>=N'" + txtdate.Text + "' and date<=N'" + txttodate.Text + "')) s1 ON (s1.sick_id=s0.id and s1.date=N'" + todaydate + "') " +
    "left join (select sick_id, code, date from ravanshenas where(date>=N'" + txtdate.Text + "' and date<=N'" + txttodate.Text + "')) s2 ON (s2.sick_id=s0.id and s2.date=N'" + todaydate + "') " +
    "left join (select sick_id, code, date from azmayesh where(date>=N'" + txtdate.Text + "' and date<=N'" + txttodate.Text + "')) s3 ON (s3.sick_id=s0.id and s3.date=N'" + todaydate + "') " +
    "where (s1.code is not null or s2.code is not null or s3.code is not null or t1.code is not null)"));
            }

            dataGridView1.DataSource = alldt;

            lbldastoor.Text ="تعداد دستور پزشک : "+ alldt.Select("dascode >0").Length.ToString();
            lblravanshenas.Text = "تعداد نظر روانشناس : " + alldt.Select("ravcode >0").Length.ToString();
            lblazmayesh.Text = "تـعـداد آزمـایـشـات : " + alldt.Select("azcode >0").Length.ToString();
            lbltahvil.Text = "تعداد تحویلی دارو : " + alldt.Select("tahvilcode >0").Length.ToString();
            lblall.Text = "تعداد کل بیماران : " + alldt.Rows.Count.ToString();

            dataGridView1.Columns["dascode"].DefaultCellStyle.BackColor = Color.Pink;
            dataGridView1.Columns["dasdate"].DefaultCellStyle.BackColor = Color.Pink;

            dataGridView1.Columns["ravcode"].DefaultCellStyle.BackColor = Color.PeachPuff;
            dataGridView1.Columns["ravdate"].DefaultCellStyle.BackColor = Color.PeachPuff;

            dataGridView1.Columns["azcode"].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            dataGridView1.Columns["azdate"].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            dataGridView1.Columns["tahvilcode"].DefaultCellStyle.BackColor = Color.MistyRose;
            dataGridView1.Columns["tahvil_date"].DefaultCellStyle.BackColor = Color.MistyRose;
            dataGridView1.Columns["from_date"].DefaultCellStyle.BackColor = Color.MistyRose;
            dataGridView1.Columns["to_date"].DefaultCellStyle.BackColor = Color.MistyRose;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                FrmSabeghehView frtv = new FrmSabeghehView();
                frtv.id = (dataGridView1["id", dataGridView1.CurrentCell.RowIndex].Value.ToString());

                frtv.tahORtaj = false;

                frtv.ShowDialog();
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

        private void btnprint_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                DataTable idsandcodes = new DataTable();
                idsandcodes.Columns.Add("id");
                idsandcodes.Columns.Add("code");

                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    if (dgvr.Cells["dascode"].Value != null && dgvr.Cells["dascode"].Value.ToString() != "")
                    {
                        if (ids.Select("id='" + dgvr.Cells["id"].Value.ToString() + "'").Length == 0)
                            ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["dascode"].Value.ToString() });
                    }
                }

                if (ids.Rows.Count > 0)
                {
                    FrmDastoorOnLinePrintViewer fd = new FrmDastoorOnLinePrintViewer();
                    fd.RealOrNot = false;
                    fd.idtable = ids;
                    fd.idandcodestable = idsandcodes;
                    fd.Show();
                }
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                DataTable idsandcodes = new DataTable();
                idsandcodes.Columns.Add("id");
                idsandcodes.Columns.Add("code");

                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    if (dgvr.Cells["ravcode"].Value != null && dgvr.Cells["ravcode"].Value.ToString() != "")
                    {
                        if (ids.Select("id='" + dgvr.Cells["id"].Value.ToString() + "'").Length == 0)
                            ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["ravcode"].Value.ToString() });
                    }
                }

                if (ids.Rows.Count > 0)
                {
                    FrmRavanshenasOnLinePrintViewer fd = new FrmRavanshenasOnLinePrintViewer();
                    fd.RealOrNot = false;
                    fd.idtable = ids;
                    fd.idandcodestable = idsandcodes;
                    fd.Show();
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                DataTable idsandcodes = new DataTable();
                idsandcodes.Columns.Add("id");
                idsandcodes.Columns.Add("code");

                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    if (dgvr.Cells["azcode"].Value != null && dgvr.Cells["azcode"].Value.ToString() != "")
                    {
                        if (ids.Select("id='" + dgvr.Cells["id"].Value.ToString() + "'").Length == 0)
                            ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["azcode"].Value.ToString() });
                    }
                }

                if (ids.Rows.Count > 0)
                {
                    FrmOnLineAzmayeshPrintViewer fd = new FrmOnLineAzmayeshPrintViewer();
                    fd.RealOrNot = false;
                    fd.idtable = ids;
                    fd.idandcodestable = idsandcodes;
                    fd.Show();
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");

                DataTable idsandcodes = new DataTable();
                idsandcodes.Columns.Add("id");
                idsandcodes.Columns.Add("code");
                idsandcodes.Columns.Add("date");

                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    if (dgvr.Cells["tahvilcode"].Value != null && dgvr.Cells["tahvilcode"].Value.ToString() != "")
                    {
                        if (ids.Select("id='" + dgvr.Cells["id"].Value.ToString() + "'").Length == 0)
                        {
                            ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString() });
                        }

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["tahvilcode"].Value.ToString() });
                    }
                }
                if (ids.Rows.Count > 0)
                {
                    FrmTanzimPrintViewerOnline fgkpv = new FrmTanzimPrintViewerOnline();
                    fgkpv.idandcodestable = idsandcodes;
                    fgkpv.cur_date = dataGridView1.CurrentRow.Cells["from_date"].Value.ToString();
                    ids.DefaultView.Sort = "id";
                    fgkpv.idtable = ids.DefaultView.ToTable();
                    fgkpv.Show();
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
        }

    }
}