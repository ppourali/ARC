using Mehr.Business_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmTahvilAdam : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";
        public bool sentbyadamview = false;

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


        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public frmTahvilAdam()
        {
            InitializeComponent();
        }

        private int DayReader(string EngDay)
        {
            int rtn = 0;
            switch (EngDay)
            {
                case "Saturday":
                    {
                        rtn = 0;
                        break;
                    }
                case "Sunday":
                    {
                        rtn = 1;
                        break;
                    }
                case "Monday":
                    {
                        rtn = 2;
                        break;
                    }
                case "Tuesday":
                    {
                        rtn = 3;
                        break;
                    }
                case "Wednesday":
                    {
                        rtn = 4;
                        break;
                    }
                case "Thursday":
                    {
                        rtn = 5;
                        break;
                    }
                case "Friday":
                    {
                        rtn = 6;
                        break;
                    }

            }
            return rtn;
        }

        private void frmTahvilAdam_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,ravesh_tark FROM sicks where (len(payan_date)!=10) order by name");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";
            txtid.DataBindings.Clear();
            txtid.DataBindings.Add("Text", dtname, "id");
            txtravesh_tark.DataBindings.Clear();
            txtravesh_tark.DataBindings.Add("Text", dtname, "ravesh_tark");
            

            txttahvil_day.SelectedIndex = DayReader(DateTime.Now.DayOfWeek.ToString());

            newform();
        }

        private void newform()
        {
            grpinfo_box.Enabled = false;

            toolStripStatusLabel1.Text = "آماده ایجاد رکورد جدید";
            ShowPosition();
            btnAdd.Enabled = false;

            groupBox1.Enabled = true;
            grpinfo_box.Enabled = false;
            grptahvil.Enabled = false; ;

            txttahvil_date.Text = cur_date;
            txtfrom_date.Text = cur_date;

            System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
            DateTime temp_date = td.ToDateTime(int.Parse(txtfrom_date.Text.Substring(0, 4)),
                                                    int.Parse(txtfrom_date.Text.Substring(5, 2)),
                                                    int.Parse(txtfrom_date.Text.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

            txtto_date.Text = (Shamsi((temp_date.AddDays(1)).Year.ToString("0000") + "/" +
                                    (temp_date.AddDays(1)).Month.ToString("00") + "/" +
                                    (temp_date.AddDays(1)).Day.ToString("00")));

//            txtto_date.Text = cur_date;

            foreach (Control dnctrl in tableLayoutPanel1.Controls)
            {
                if (dnctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)dnctrl).Checked = false;
                }
            }

            groupBox1.Focus();            
            txtname.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sicks sicksname = new Sicks();
            sicksname.id = txtid.Text;
            if (!sicksname.SelectfornameCheck().Equals(txtname.Text))
            {
                MessageBox.Show("نام بیمار با شماره پرونده مطابقت ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
                return;
            }
            
            DataTable AzmCanTake = new DataTable();
            DataTable RavCanTake = new DataTable();
            DataTable DasCanTake = new DataTable();
            AzmCanTake = new tahvil_koli().Search("select sick_id from azmayesh where (sick_id=N'" + txtid.Text + "' and date=N'" + txttahvil_date.Text + "')");
            RavCanTake = new tahvil_koli().Search("select sick_id from ravanshenas where (sick_id=N'" + txtid.Text + "' and date=N'" + txttahvil_date.Text + "')");
            DasCanTake = new tahvil_koli().Search("select sick_id from dastoor_pezeshk where (sick_id=N'" + txtid.Text + "' and date=N'" + txttahvil_date.Text + "')");

            bool CanTakeCheck = true;

            if (AzmCanTake.Rows.Count > 0 || RavCanTake.Rows.Count > 0 || DasCanTake.Rows.Count > 0)
            {
                DialogResult dr;
                dr = MessageBox.Show("بیمار در این تاریخ یکی از موارد آزمایش، مشاوره روانشناسی و دستورپزشک دارد، آیا از ثبت عدم مراجعه اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                if (dr == DialogResult.No)
                {
                    CanTakeCheck = false;
                }
            }


            if (CanTakeCheck == true)
            {
                string payan_darman_check = Cache.closedDate(txtid.Text);
                //string payan_darman_check = new Sicks().Search("SELECT payan_date FROM sicks WHERE (id=N'" + txtid.Text + "')").Rows[0][0].ToString();

                tahvil_koli check_exist = new tahvil_koli();
                DataTable chkdt1 = new DataTable();
                chkdt1 = check_exist.Search("SELECT code FROM tahvil where (date>=N'" + txtfrom_date.Text + "' and date<N'" + txtto_date.Text + "' and id=N'" + txtid.Text + "')");

                if (chkdt1.Rows.Count > 0)
                {
                    MessageBox.Show("بیمار مورد نظر قبلا در این روزها دارو تحویل گرفته است، با ثبت این دارو پایگاه داده ها دچار مشکل خواهد شد. لطفا مجددا بررسی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grpinfo_box.Focus();
                    txtfrom_date.Focus();
                }
                else if (txtto_date.isAfter(payan_darman_check.Trim()))
                {
                    MessageBox.Show(" پرونده ی این بیمار در تاریخ " + payan_darman_check + " بسته شده است ");
                }

                else
                {

                    // Inserting the Data to the DataBase
                    string count;
                    long counter_code = 0;
                    DataTable dt = new DataTable();

                    tahvil_koli taj = new tahvil_koli();
                    try
                    {
                        dt = taj.Selectmaxid();
                        count = dt.Rows[0][0].ToString();
                        counter_code = long.Parse(count) + 1;
                    }
                    catch (Exception)
                    {
                        counter_code = 1;
                    }

                    tahvil_koli tk = new tahvil_koli();
                    tk.code = counter_code;
                    tk.id = txtid.Text;
                    tk.name = txtname.Text;
                    tk.ravesh_tark = txtravesh_tark.Text;
                    tk.tahvil_day = txttahvil_day.Text;
                    tk.tahvil_date = txttahvil_date.Text;
                    tk.from_date = txtfrom_date.Text;
                    tk.to_date = txtto_date.Text;

                    foreach (Control dnctrl in tableLayoutPanel1.Controls)
                    {
                        if (dnctrl.GetType() == typeof(CheckBox))
                        {
                            if (((CheckBox)dnctrl).Checked)
                            {
                                tk.daru_name = dnctrl.Text;
                                tk.tedad = 0;
                                tk.Add();
                            }
                        }
                    }


                    //////////////////////////////////////////////////////////////////////////////////////////////////
                    tahvil ta = new tahvil();
                    for (int i = 0; i < int.Parse(txtdate_dif.Text); i++)
                    {
                        ta.code = counter_code;
                        ta.id = txtid.Text;
                        ta.name = txtname.Text;
                        ta.ravesh_tark = txtravesh_tark.Text;
                        ta.tahvil_day = txttahvil_day.Text;
                        ta.tahvil_date = txttahvil_date.Text;

                        System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                        DateTime temp_date = td.ToDateTime(int.Parse(txtfrom_date.Text.Substring(0, 4)),
                                                                int.Parse(txtfrom_date.Text.Substring(5, 2)),
                                                                int.Parse(txtfrom_date.Text.Substring(8, 2)),
                                                                0, 0, 0, 0, 0);

                        ta.date = (Shamsi((temp_date.AddDays(i)).Year.ToString("0000") + "/" +
                                                (temp_date.AddDays(i)).Month.ToString("00") + "/" +
                                                (temp_date.AddDays(i)).Day.ToString("00")));

                        foreach (Control dnctrl2 in tableLayoutPanel1.Controls)
                        {
                            if (dnctrl2.GetType() == typeof(CheckBox))
                            {
                                if (((CheckBox)dnctrl2).Checked)
                                {
                                    ta.daru_name = dnctrl2.Text;
                                    ta.tedad = 0;
                                    ta.Add();
                                }
                            }
                        }
                    }


                    new ActionLogs().Add("تحویل داروی دفتری (عدم مراجعه) به مشخصه ی " + counter_code);

                    // Show the current record position...
                    ShowPosition();

                    // Display a message that the record was added...
                    MessageBox.Show("عملیات ثبت عدم مراجعه با موفقیت انجام شد");

                    if (checkBox10.Checked)
                    {
                        DataTable ids = new DataTable();
                        ids.Columns.Add("id");
                        ids.Columns.Add("name");

                        DataTable idsandcodes = new DataTable();
                        idsandcodes.Columns.Add("id");
                        idsandcodes.Columns.Add("code");

                        ids.Rows.Add(new object[] { txtid.Text, txtname.Text });

                        idsandcodes.Rows.Add(new object[] { txtid.Text, counter_code.ToString() });

                        frmTanzimPrintViewerOnline fgkpv = new frmTanzimPrintViewerOnline();
                        fgkpv.idandcodestable = idsandcodes;
                        fgkpv.cur_date = txtfrom_date.Text;
                        fgkpv.idtable = ids;
                        fgkpv.ShowDialog();
                    }

                    if (sentbyadamview == true)
                    {
                        try
                        {
                            newform();
                            Application.OpenForms["frmAbsentSicksView"].Activate();
                        }
                        catch
                        {
                        }
                    }
                    else
                        newform();

                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (sender == txttahvil_date)
            {
                if (txttahvil_date.MaskCompleted)
                {
                    if (txttahvil_date.Text != txtfrom_date.Text && txttahvil_date.Enabled == true)
                    {
                        MessageBox.Show(" تاریخ تحویل باید با تاریخ شروع دوره برابر باشد؛ در غیر اینصورت ممکن است پایگاه داده با مشکل مواجه شود");
                    }

                    try
                    {
                        //Convert.ToDateTime(txttahvil_date.Text);

                        System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                        DateTime pdt = x.ToDateTime(int.Parse(txttahvil_date.Text.Substring(0, 4)),
                                                    int.Parse(txttahvil_date.Text.Substring(5, 2)),
                                                    int.Parse(txttahvil_date.Text.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

                        txttahvil_day.SelectedIndex = DayReader(pdt.DayOfWeek.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("لطفا تاریخ را به صورت صحیح وارد نمایید");
                        ((DateMaskedTextbox)sender).Focus();
                        ((DateMaskedTextbox)sender).SelectAll();
                    }

                    Sicks si = new Sicks();
                    if (si.Search("select id from tahvil_koli where (tahvil_date='" + txttahvil_date.Text + "' and id=N'" + txtid.Text + "')").Rows.Count > 0)
                    {
                        toolStripStatusLabel1.Text = "این بیمار در این روز دارو گرفته است";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "آماده عملیات";
                        toolStripStatusLabel1.ForeColor = Color.Black;
                    }
                }
            }
            //Tahvil////////////////////////////////////////////////////////////////////
            else if (sender == txtfrom_date || sender == txtto_date)
            {
                try
                {
                    txttahvil_date.Text = txtfrom_date.Text;
                    if (txtfrom_date.MaskCompleted && txtto_date.MaskCompleted)
                    {
                        if (decimal.Parse(txtto_date.Text.Replace("/", "")) < decimal.Parse(txtfrom_date.Text.Replace("/", "")))
                        {
                            MessageBox.Show("تاریخ روز تحویل نمی تواند پیش از تاریخ مراجعه بعدی باشد", "خطا");
                            ((DateMaskedTextbox)sender).Focus();
                            ((DateMaskedTextbox)sender).SelectAll();
                        }
                        else
                        {

                            System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                            TimeSpan ts = xd.ToDateTime(int.Parse(txtto_date.Text.Substring(0, 4)),
                                                        int.Parse(txtto_date.Text.Substring(5, 2)),
                                                        int.Parse(txtto_date.Text.Substring(8, 2)),
                                                        0, 0, 0, 0, 0)
                                          - xd.ToDateTime(int.Parse(txtfrom_date.Text.Substring(0, 4)),
                                                        int.Parse(txtfrom_date.Text.Substring(5, 2)),
                                                        int.Parse(txtfrom_date.Text.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                            txtdate_dif.Text = (ts.TotalDays).ToString();

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("لطفا تاریخ را به صورت صحیح وارد نمایید");
                    ((DateMaskedTextbox)sender).Focus();
                    ((DateMaskedTextbox)sender).SelectAll();
                }
            }

            if (txtid.Text == "")
            {
                txtid.Text = "000000000000000";
                txtid.SelectAll();
                txtid.Focus();
            }

            if (txtid.Text == "" || txttahvil_day.Text.Trim() == "" || !txtfrom_date.MaskCompleted || !txtto_date.MaskCompleted || !txttahvil_date.MaskCompleted || txtdate_dif.Text == "0" || 
                (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false))
                btnAdd.Enabled = false;
            else
            {
                btnAdd.Enabled = true;
            }
        }


        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (sender == txtto_date)
            {
                if (e.KeyCode == Keys.Up)
                {
                    System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                    DateTime temp_date = td.ToDateTime(int.Parse(txtto_date.Text.Substring(0, 4)),
                                                            int.Parse(txtto_date.Text.Substring(5, 2)),
                                                            int.Parse(txtto_date.Text.Substring(8, 2)),
                                                            0, 0, 0, 0, 0);

                    txtto_date.Text = (Shamsi((temp_date.AddDays(1)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(1)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(1)).Day.ToString("00")));

                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                    DateTime temp_date = td.ToDateTime(int.Parse(txtto_date.Text.Substring(0, 4)),
                                                            int.Parse(txtto_date.Text.Substring(5, 2)),
                                                            int.Parse(txtto_date.Text.Substring(8, 2)),
                                                            0, 0, 0, 0, 0);

                    txtto_date.Text = (Shamsi((temp_date.AddDays(-1)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(-1)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(-1)).Day.ToString("00")));

                    e.SuppressKeyPress = true;
                }
            } 
            
            if (e.KeyCode == Keys.Enter && e.Modifiers != Keys.Control)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 13 && e.Modifiers == Keys.Control)
            {
                btnAdd.PerformClick();
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

                if (sender == txtto_date || sender == txtfrom_date || sender == txttahvil_date)
                    ((DateMaskedTextbox)sender).Select(8, 2);
            }

            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Yellow;
                ((CheckBox)sender).Focus();
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
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Transparent;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {

        }

        public void idsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Sicks si = new Sicks();
            si.id = txtid.Text;
            dt = si.Selectforedit();
            if (dt.Rows.Count > 0)
            {

                // Clear any previous bindings & Add new bindings to the DataView object...
                //txtname.Text = dt.Rows[0]["name"].ToString();
                //txtravesh_tark.Text = dt.Rows[0]["ravesh_tark"].ToString();
                // End of Clearing & Adding of Controls Binding

                //groupBox1.Enabled = false;
                //groupBox1.TabStop = false;
                grpinfo_box.Enabled = true;
                grptahvil.Enabled = true;

                txtfrom_date.Text = cur_date;

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(txtfrom_date.Text.Substring(0, 4)),
                                                        int.Parse(txtfrom_date.Text.Substring(5, 2)),
                                                        int.Parse(txtfrom_date.Text.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                txtto_date.Text = (Shamsi((temp_date.AddDays(1)).Year.ToString("0000") + "/" +
                                        (temp_date.AddDays(1)).Month.ToString("00") + "/" +
                                        (temp_date.AddDays(1)).Day.ToString("00")));


                txtfrom_date.Focus();

                if (si.Search("select id from tahvil_koli where (tahvil_date='" + txttahvil_date.Text + "' and id=N'"+txtid.Text+"')").Rows.Count > 0)
                {
                    toolStripStatusLabel1.Text = "این بیمار در این روز دارو گرفته است";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
                else
                {
                    toolStripStatusLabel1.Text = "آماده عملیات";
                    toolStripStatusLabel1.ForeColor = Color.Black;
                }


            }
            else
            {
                MessageBox.Show("مشخصات  در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtid.Text = string.Format("{0:000000000000000}", Convert.ToDecimal(txtid.Text));
                idsearch.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void chktahvil4_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                ((CheckBox)sender).BackColor = Color.LightGreen;
            }
            else if (((CheckBox)sender).Checked == false)
            {
                ((CheckBox)sender).BackColor = Color.Transparent;
            }

           if (txtid.Text == "" || txttahvil_day.Text.Trim() == "" || !txtfrom_date.MaskCompleted || !txtto_date.MaskCompleted || !txttahvil_date.MaskCompleted || txtdate_dif.Text == "0" || 
                (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false))
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmSabeghehView frtv = new frmSabeghehView();
            frtv.id = txtid.Text;
            frtv.tahORtaj = false;
            frtv.ShowDialog();
            txtname.Focus();
            txtname.SelectAll();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            tahvil_koli tk = new tahvil_koli();
            dataGridView1.DataSource = tk.Search("SELECT distinct tahvil_koli.code, tahvil_koli.id,tahvil_koli.name,tahvil_koli.tahvil_date, tahvil_koli.from_date,tahvil_koli.to_date,tahvil_koli.daru_name,tahvil_koli.tedad, tahvil.tedad as roozaneh FROM tahvil_koli, tahvil WHERE (tahvil_koli.id=N'" + txtid.Text + "' and tahvil_koli.tahvil_date = (select max (tahvil_date) from tahvil_koli where (tahvil_koli.id=N'" + txtid.Text + "') ) and tahvil.code=tahvil_koli.code and tahvil.daru_name=tahvil_koli.daru_name )");
        }

    }
}