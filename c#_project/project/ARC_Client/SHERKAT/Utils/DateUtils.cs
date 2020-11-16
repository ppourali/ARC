using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mehr.Utils
{
    static class DateUtils
    {
        public static string DateMaskFormat()
        {
            //return YearValue().ToString().Substring(0, 2) + "00/00/00";
            return "0000/00/00";

        }

        public static int MonthIndex()
        {
            return int.Parse(Shamsi().Substring(5, 2)) - 1;
        }

        public static int YearValue()
        {
            return int.Parse(Shamsi().Substring(0, 4));
        }

        public static string Georgian()
        {
            string d, m, y;
            d = DateTime.Today.Date.Day.ToString();
            m = DateTime.Today.Date.Month.ToString();
            y = DateTime.Today.Date.Year.ToString();
            return DateTime.Now.ToLongTimeString();
        }
        public static string Shamsi()
        {
            string d, m, y;
            d = DateTime.Today.Date.Day.ToString();
            m = DateTime.Today.Date.Month.ToString();
            y = DateTime.Today.Date.Year.ToString();
            String date = y + '/' + m + '/' + d;

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
            return (year + "/" + Convert.ToString(month).PadLeft(2, '0') + "/" +
            Convert.ToString(day).PadLeft(2, '0')).Trim();


        }
    }
}
