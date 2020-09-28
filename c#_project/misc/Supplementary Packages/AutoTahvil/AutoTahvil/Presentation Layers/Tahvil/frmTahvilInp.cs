using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace AutoTahvil.Presentation_Layers
{
    public partial class frmTahvilInput : Form
    {
        DataTable datat = new DataTable();
        DataTable combosource1, combosource2, combosource3, combosource4;

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

        private void fillDataSet()
        {
            //anbar an = new anbar();
            //combosource1 = an.Search("select distinct * from anbar");
            //combosource2 = an.Search("select distinct * from anbar");
            //combosource3 = an.Search("select distinct * from anbar");
            //combosource4 = an.Search("select distinct * from anbar");


            //txtdaru_name1.DataSource = combosource1;
            //txtdaru_name2.DataSource = combosource2;
            //txtdaru_name3.DataSource = combosource3;
            //txtdaru_name4.DataSource = combosource4;

            //txtdaru_name1.DisplayMember = "daru_name";
            //txtdaru_name2.DisplayMember = "daru_name";
            //txtdaru_name3.DisplayMember = "daru_name";
            //txtdaru_name4.DisplayMember = "daru_name";

            //txtdaru_name1.ValueMember = "daru_name";
            //txtdaru_name2.ValueMember = "daru_name";
            //txtdaru_name3.ValueMember = "daru_name";
            //txtdaru_name4.ValueMember = "daru_name";

            //lblvahed1.DataBindings.Clear();
            //lblvahed2.DataBindings.Clear();
            //lblvahed3.DataBindings.Clear();
            //lblvahed4.DataBindings.Clear();

            //lblvahed1.DataBindings.Add("Text", combosource1, "vahed");
            //lblvahed2.DataBindings.Add("Text", combosource2, "vahed");
            //lblvahed3.DataBindings.Add("Text", combosource3, "vahed");
            //lblvahed4.DataBindings.Add("Text", combosource4, "vahed");

            //txtmandeh1.DataBindings.Clear();
            //txtmandeh2.DataBindings.Clear();
            //txtmandeh3.DataBindings.Clear();
            //txtmandeh4.DataBindings.Clear();

            //txtmandeh1.DataBindings.Add("Text", combosource1, "mandeh");
            //txtmandeh2.DataBindings.Add("Text", combosource2, "mandeh");
            //txtmandeh3.DataBindings.Add("Text", combosource3, "mandeh");
            //txtmandeh4.DataBindings.Add("Text", combosource4, "mandeh");

        }

        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public frmTahvilInput()
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

        private void frmTahvilInput_Load(object sender, EventArgs e)
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

            txttedad1.Text = "0";
            txttedad2.Text = "0";
            txttedad3.Text = "0";
            txttedad4.Text = "0";

            chktahvil1.Checked = false;
            chktahvil2.Checked = false;
            chktahvil3.Checked = false;
            chktahvil4.Checked = false;

            groupBox1.Enabled = true;
            grpinfo_box.Enabled = false;
            grptahvil.Enabled = false; ;

            fillDataSet();
            
            if (txtdaru_name1.Items.Count > 0)
            {
                txtdaru_name1.SelectedIndex = 0;
                txtdaru_name2.SelectedIndex = 0;
                txtdaru_name3.SelectedIndex = 0;
                txtdaru_name4.SelectedIndex = 0;
            }

            txttahvil_date.Text = cur_date;
            txtto_date.Text = cur_date; 
            txtfrom_date.Text = cur_date;
            

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
            
            if (float.Parse(txttedadkol1.Text) > float.Parse(txtmandeh1.Text) || float.Parse(txttedadkol2.Text) > float.Parse(txtmandeh2.Text) || float.Parse(txttedadkol3.Text) > float.Parse(txtmandeh3.Text) || float.Parse(txttedadkol4.Text) > float.Parse(txtmandeh4.Text))
            {
                DialogResult diagr;
                diagr = MessageBox.Show("میزان داروهای تحویلی بیشتر از میزان موجود در بانک دارو می باشد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (diagr == DialogResult.No)
                {
                    return;
                }
            }

            string payan_darman_check = new Sicks().Search("SELECT payan_date FROM sicks WHERE (id=N'" + txtid.Text + "')").Rows[0][0].ToString();

            tahvil_koli check_exist = new tahvil_koli();
            DataTable chkdt1 = new DataTable();
            chkdt1 = check_exist.Search("SELECT code FROM tahvil where (date>=N'" + txtfrom_date.Text + "' and date<N'" + txtto_date.Text + "' and id=N'" + txtid.Text + "')");

            if (chkdt1.Rows.Count > 0)
            {
                MessageBox.Show("بیمار مورد نظر قبلا در این روزها دارو تحویل گرفته است، با ثبت این دارو پایگاه داده ها دچار مشکل خواهد شد. لطفا مجددا بررسی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpinfo_box.Focus();
                txtfrom_date.Focus();
            }
            else if (payan_darman_check.Trim() != "13  /  /" && (string.CompareOrdinal(payan_darman_check.Trim(), txtto_date.Text.Trim()) < 0))
            {
                MessageBox.Show(" پرونده ی این بیمار در تاریخ " + payan_darman_check + " بسته شده است ");
            }

            else
            {
                if ((txtdaru_name1.Text == txtdaru_name2.Text && chktahvil1.Checked == true && chktahvil2.Checked == true) || (txtdaru_name1.Text == txtdaru_name3.Text && chktahvil1.Checked == true && chktahvil3.Checked == true) || (txtdaru_name1.Text == txtdaru_name4.Text && chktahvil1.Checked == true && chktahvil4.Checked == true) ||
                  (txtdaru_name2.Text == txtdaru_name3.Text && chktahvil2.Checked == true && chktahvil3.Checked == true) || (txtdaru_name4.Text == txtdaru_name2.Text && chktahvil2.Checked == true && chktahvil4.Checked == true) ||
                  (txtdaru_name3.Text == txtdaru_name4.Text && chktahvil3.Checked == true && chktahvil4.Checked == true))
                {
                    MessageBox.Show("در ورود اطلاعات نام داروها دقت فرمایید");
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
                    if (chktahvil1.Checked) //if (txtdaru_name1.Text != "" && txttedad1.Text != "0" && txttedadkol1.Text != "0")
                    {
                        tk.daru_name = txtdaru_name1.Text;
                        tk.tedad = float.Parse(txttedadkol1.Text);
                        tk.Add();
                    }
                    if (chktahvil2.Checked) //if (txtdaru_name2.Text != "" && txttedad2.Text != "0" && txttedadkol2.Text != "0")
                    {
                        tk.daru_name = txtdaru_name2.Text;
                        tk.tedad = float.Parse(txttedadkol2.Text);
                        tk.Add();
                    }
                    if (chktahvil3.Checked) //if (txtdaru_name3.Text != "" && txttedad3.Text != "0" && txttedadkol3.Text != "0")
                    {
                        tk.daru_name = txtdaru_name3.Text;
                        tk.tedad = float.Parse(txttedadkol3.Text);
                        tk.Add();
                    }
                    if (chktahvil4.Checked) //if (txtdaru_name3.Text != "" && txttedad3.Text != "0" && txttedadkol3.Text != "0")
                    {
                        tk.daru_name = txtdaru_name4.Text;
                        tk.tedad = float.Parse(txttedadkol4.Text);
                        tk.Add();
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
                        ta.tahvil_date = txtfrom_date.Text;

                        System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                        DateTime temp_date = td.ToDateTime(int.Parse(txtfrom_date.Text.Substring(0, 4)),
                                                                int.Parse(txtfrom_date.Text.Substring(5, 2)),
                                                                int.Parse(txtfrom_date.Text.Substring(8, 2)),
                                                                0, 0, 0, 0, 0);

                        ta.date = (Shamsi((temp_date.AddDays(i)).Year.ToString("0000") + "/" +
                                                (temp_date.AddDays(i)).Month.ToString("00") + "/" +
                                                (temp_date.AddDays(i)).Day.ToString("00")));

                        if (chktahvil1.Checked) //if (txtdaru_name1.Text != "" && txttedad1.Text != "0" && txttedadkol1.Text != "0")
                        {
                            ta.daru_name = txtdaru_name1.Text;
                            ta.tedad = float.Parse(txttedad1.Text);
                            ta.Add();
                        }
                        if (chktahvil2.Checked) //if (txtdaru_name2.Text != "" && txttedad2.Text != "0" && txttedadkol2.Text != "0")
                        {
                            ta.daru_name = txtdaru_name2.Text;
                            ta.tedad = float.Parse(txttedad2.Text);
                            ta.Add();
                        }
                        if (chktahvil3.Checked) //if (txtdaru_name3.Text != "" && txttedad3.Text != "0" && txttedadkol3.Text != "0")
                        {
                            ta.daru_name = txtdaru_name3.Text;
                            ta.tedad = float.Parse(txttedad3.Text);
                            ta.Add();
                        }
                        if (chktahvil4.Checked) //if (txtdaru_name3.Text != "" && txttedad3.Text != "0" && txttedadkol3.Text != "0")
                        {
                            ta.daru_name = txtdaru_name4.Text;
                            ta.tedad = float.Parse(txttedad4.Text);
                            ta.Add();
                        }
                    }

                    // Updating the Data to the DataBase Anbar
                    
                    ShowPosition();

                    // Display a message that the record was added...
                    MessageBox.Show("عملیات ثبت دارو با موفقیت انجام شد");

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
                    if (txttahvil_date.Text != txtfrom_date.Text && txttahvil_date.Enabled==true)
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
                        ((System.Windows.Forms.MaskedTextBox)sender).Focus();
                        ((System.Windows.Forms.MaskedTextBox)sender).SelectAll();
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
            else if (sender == txttedad1)
            {
                if (txttedad1.Text == "")
                {
                    txttedad1.Text = "0";
                    txttedad1.Focus();
                    txttedad1.SelectAll();
                    chktahvil1.Checked = false;
                }
                else
                {
                    txttedadkol1.Text = (float.Parse(txttedad1.Text) * int.Parse(txtdate_dif.Text)).ToString();
                    chktahvil1.Checked = true;
                }

            }
            else if (sender == txttedad2)
            {
                if (txttedad2.Text == "")
                {
                    txttedad2.Text = "0";
                    txttedad2.Focus();
                    txttedad2.SelectAll();
                    chktahvil2.Checked = false;
                }
                else
                {
                    txttedadkol2.Text = (float.Parse(txttedad2.Text) * int.Parse(txtdate_dif.Text)).ToString();
                    chktahvil2.Checked = true;
                }
            }
            else if (sender == txttedad3)
            {
                if (txttedad3.Text == "")
                {
                    txttedad3.Text = "0";
                    txttedad3.Focus();
                    txttedad3.SelectAll();
                    chktahvil3.Checked = false;
                }
                else
                {
                    txttedadkol3.Text = (float.Parse(txttedad3.Text) * int.Parse(txtdate_dif.Text)).ToString();
                    chktahvil3.Checked = true;
                }
            }
            else if (sender == txttedad4)
            {
                if (txttedad4.Text == "")
                {
                    txttedad4.Text = "0";
                    txttedad4.Focus();
                    txttedad4.SelectAll();
                    chktahvil4.Checked = false;
                }
                else
                {
                    txttedadkol4.Text = (float.Parse(txttedad4.Text) * int.Parse(txtdate_dif.Text)).ToString();
                    chktahvil4.Checked = true;
                }
            }

            else if (sender == txtfrom_date || sender == txtto_date)
            {
                try
                {
                    txttahvil_date.Text = txtfrom_date.Text;
                    if (txtfrom_date.MaskCompleted && txtto_date.MaskCompleted)
                    {
                        if (decimal.Parse(txtto_date.Text.Replace("/","")) < decimal.Parse(txtfrom_date.Text.Replace("/","")))
                        {
                            MessageBox.Show("تاریخ روز تحویل نمی تواند پیش از تاریخ مراجعه بعدی باشد", "خطا");
                            ((System.Windows.Forms.MaskedTextBox)sender).Focus();
                            ((System.Windows.Forms.MaskedTextBox)sender).SelectAll();
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

                            txttedadkol1.Text = (float.Parse(txttedad1.Text) * int.Parse(txtdate_dif.Text)).ToString();
                            txttedadkol2.Text = (float.Parse(txttedad2.Text) * int.Parse(txtdate_dif.Text)).ToString();
                            txttedadkol3.Text = (float.Parse(txttedad3.Text) * int.Parse(txtdate_dif.Text)).ToString();
                            txttedadkol4.Text = (float.Parse(txttedad4.Text) * int.Parse(txtdate_dif.Text)).ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("لطفا تاریخ را به صورت صحیح وارد نمایید");
                    ((System.Windows.Forms.MaskedTextBox)sender).Focus();
                    ((System.Windows.Forms.MaskedTextBox)sender).SelectAll();
                }
            }

            if (txtid.Text == "")
            {
                txtid.Text = "0000";
                txtid.SelectAll();
                txtid.Focus();
            }

            if (txtid.Text == "" || txttahvil_day.Text.Trim() == "" || !txtfrom_date.MaskCompleted || !txtto_date.MaskCompleted || !txttahvil_date.MaskCompleted || txtdate_dif.Text=="0" )
                btnAdd.Enabled = false;
            else
            {
                btnAdd.Enabled = true;
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

            else if (sender.GetType() == typeof(System.Windows.Forms.MaskedTextBox))
            {
                ((System.Windows.Forms.MaskedTextBox)sender).BackColor = Color.Yellow;
                ((System.Windows.Forms.MaskedTextBox)sender).Focus();
                ((System.Windows.Forms.MaskedTextBox)sender).SelectAll();

                if (sender == txtto_date || sender == txtfrom_date || sender == txttahvil_date)
                    ((System.Windows.Forms.MaskedTextBox)sender).Select(8, 2);
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
                if (sender == txtname || sender == txttahvil_day)
                    ((ComboBox)sender).BackColor = Color.White;
                else
                {
                    if (chktahvil1.Checked == true)
                    {
                        txtdaru_name1.BackColor = Color.LightGreen;
                    }
                    else if (chktahvil1.Checked == false)
                    {
                        txtdaru_name1.BackColor = Color.White;
                    }

                    if (chktahvil2.Checked == true)
                    {
                        txtdaru_name2.BackColor = Color.LightGreen;
                    }
                    else if (chktahvil2.Checked == false)
                    {
                        txtdaru_name2.BackColor = Color.White;
                    }

                    if (chktahvil3.Checked == true)
                    {
                        txtdaru_name3.BackColor = Color.LightGreen;
                    }
                    else if (chktahvil3.Checked == false)
                    {
                        txtdaru_name3.BackColor = Color.White;
                    }

                    if (chktahvil4.Checked == true)
                    {
                        txtdaru_name4.BackColor = Color.LightGreen;
                    }
                    else if (chktahvil4.Checked == false)
                    {
                        txtdaru_name4.BackColor = Color.White;
                    }
                }
            }

            else if (sender.GetType() == typeof(System.Windows.Forms.MaskedTextBox))
            {
                ((System.Windows.Forms.MaskedTextBox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
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
                txtto_date.Text = cur_date;
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
                txtid.Text = txtid.Text = string.Format("{0:0000}", Convert.ToDecimal(txtid.Text));
                idsearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void chktahvil4_CheckedChanged(object sender, EventArgs e)
        {
            if (chktahvil1.Checked == true)
            {
                txtdaru_name1.BackColor = Color.LightGreen;
            }
            else if (chktahvil1.Checked == false)
            {
                txtdaru_name1.BackColor = Color.White;
            }

            if (chktahvil2.Checked == true)
            {
                txtdaru_name2.BackColor = Color.LightGreen;
            }
            else if (chktahvil2.Checked == false)
            {
                txtdaru_name2.BackColor = Color.White;
            }

            if (chktahvil3.Checked == true)
            {
                txtdaru_name3.BackColor = Color.LightGreen;
            }
            else if (chktahvil3.Checked == false)
            {
                txtdaru_name3.BackColor = Color.White;
            }

            if (chktahvil4.Checked == true)
            {
                txtdaru_name4.BackColor = Color.LightGreen;
            }
            else if (chktahvil4.Checked == false)
            {
                txtdaru_name4.BackColor = Color.White;
            }
        }

        private void txttedad1_Validated(object sender, EventArgs e)
        {
            if (txttedad1.Text == "0")
            {
                chktahvil1.Checked = false;
            }
            if (txttedad2.Text == "0")
            {
                chktahvil2.Checked = false;
            }
            if (txttedad3.Text == "0")
            {
                chktahvil3.Checked = false;
            }
            if (txttedad4.Text == "0")
            {
                chktahvil4.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            tahvil_koli tk = new tahvil_koli();
            dataGridView1.DataSource = tk.Search("SELECT distinct tahvil_koli.code, tahvil_koli.id,tahvil_koli.name,tahvil_koli.tahvil_date, tahvil_koli.from_date,tahvil_koli.to_date,tahvil_koli.daru_name,tahvil_koli.tedad, tahvil.tedad as roozaneh FROM tahvil_koli, tahvil WHERE (tahvil_koli.id=N'" + txtid.Text + "' and tahvil_koli.tahvil_date = (select max (tahvil_date) from tahvil_koli where (tahvil_koli.id=N'" + txtid.Text + "') ) and tahvil.code=tahvil_koli.code and tahvil.daru_name=tahvil_koli.daru_name )");

            dataGridView2.DataSource = tk.Search("SELECT distinct tajviz_koli.code, tajviz_koli.id,tajviz_koli.name,tajviz_koli.tajviz_date, tajviz_koli.from_date,tajviz_koli.to_date,tajviz_koli.daru_name,tajviz_koli.tedad, tajviz.tedad as roozaneh FROM tajviz_koli, tajviz WHERE (tajviz_koli.id=N'" + txtid.Text + "' and tajviz_koli.tajviz_date = (select max (tajviz_date) from tajviz_koli where (tajviz_koli.id=N'" + txtid.Text + "') ) and tajviz.code=tajviz_koli.code and tajviz.daru_name=tajviz_koli.daru_name )");
        }

    }
}