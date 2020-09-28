using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class action_logs
    {
       // public string user_code,pass,fname,lname,tel,address, semat;

        mydataaccess da = new mydataaccess();

        public void Add(string sharh)
        {
            string d, m, y;
            d = DateTime.Today.Date.Day.ToString();
            m = DateTime.Today.Date.Month.ToString();
            y = DateTime.Today.Date.Year.ToString();
            string current_time = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo).Trim();
            string current_date = Shamsi(y + '/' + m + '/' + d).Trim();

            string s = "insert into action_logs (sharh, user_code, user_name, date, time) Values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')";
            s = string.Format(s, sharh, Program.user_code, Program.user_name, current_date, current_time);
            da.Connect();
            da.docommand(s);
            da.disconnect();
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

        public DataTable SelectMaxDate()
        {
            string s = "select max(date) as Max_Date from action_logs";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        //public void Delete()
        //{
        //    string s = "Delete from action_logs where ( user_code=N'{0}' )";
        //    s = string.Format(s, this.user_code);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}

        //public void Updateaction_logsess()
        //{
        //    string s = "Update action_logs set fname=N'{0}', lname=N'{1}', tel=N'{2}', address=N'{3}', semat=N'{4}' where user_code=N'{5}'";
        //    s = string.Format(s, this.fname,this.lname,this.tel, this.address, this.semat, this.user_code);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}

        //public void UpdatePassword()
        //{
        //    string s = "Update action_logs set pass=N'{0}' where user_code=N'{1}'";
        //    s = string.Format(s, this.pass,this.user_code);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}

        public DataTable Select()
        {
            string s = "select * from action_logs order by date desc, time desc";
            //s = string.Format(s,this.user_code, this.pass);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Search(string sql)
        {
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(sql);
            da.disconnect();
            return dt;
        }


        public void DeleteAll()
        {
            string s = "Delete from action_logs";
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

    }

}
