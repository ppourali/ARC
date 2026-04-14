using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class dastoor_pezeshk_real
    {
        public String sick_id, name, doctor_name, darman_date, date, pre_text, azmayesh;
        public long code;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "INSERT INTO dastoor_pezeshk_real (code, sick_id, name, doctor_name, darman_date, date, pre_text, azmayesh) VALUES ( {0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}') ";
            s = string.Format(s, this.code, this.sick_id, this.name, this.doctor_name, this.darman_date, this.date, this.pre_text, this.azmayesh);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ثبت  دستور پزشک (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه دستور " + this.code);
        }

        public void Delete()
        {
            string s = "DELETE FROM dastoor_pezeshk_real WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ثبت  دستور پزشک (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه دستور " + this.code);
        }


        public void Update()
        {
            string s = "UPDATE dastoor_pezeshk_real SET  doctor_name = N'{0}', date=N'{1}', pre_text = N'{2}', azmayesh = N'{3}' WHERE (code={4} )";
            s = string.Format(s, this.doctor_name, this.date, this.pre_text, this.azmayesh, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ویرایش  دستور پزشک (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه دستور " + this.code);
        }

        public long Selectmaxid()
        {
            string s = "select max(code) from dastoor_pezeshk_real";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();

            string count;
            try
            {
                count = dt.Rows[0][0].ToString();
                return long.Parse(count) + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public DataTable Select()
        {
            string s = "SELECT * FROM dastoor_pezeshk_real";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM dastoor_pezeshk_real WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectSabegheh()
        {
            string s = "SELECT * FROM dastoor_pezeshk_real WHERE (sick_id=N'{0}')";
            s = string.Format(s, this.sick_id);
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

    }
}