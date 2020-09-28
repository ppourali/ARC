using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mehr
{
    public partial class frmCalender : Form
    {
        public frmCalender()
        {
            InitializeComponent();
        }
        public string cur_date = "";
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }
        private void DeskTopCalender()
        {
            string[] monthnames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تـیـر", "مـرداد", "شهریور", "مـهـر", "آبــان", "آذر", "دی", "بهمن", "اسفند" };
            string[] daynames = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه" };

            
            string month = cur_date.Substring(5, 2);

            lblmonth_year.Text = monthnames[int.Parse(month) - 1].Trim() + " " + cur_date.Substring(0, 4).Trim();

            lblDay.Text = cur_date.Substring(8, 2).Trim();

            System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
            DateTime pdt = x.ToDateTime(int.Parse(cur_date.Substring(0, 4)),
                                        int.Parse(cur_date.Substring(5, 2)),
                                        int.Parse(cur_date.Substring(8, 2)),
                                        0, 0, 0, 0, 0);

            lblDayofWeek.Text = daynames[DayReader(pdt.DayOfWeek.ToString())];
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

        private void frmCalender_Load(object sender, EventArgs e)
        {
            DeskTopCalender();
        }

    }
}
