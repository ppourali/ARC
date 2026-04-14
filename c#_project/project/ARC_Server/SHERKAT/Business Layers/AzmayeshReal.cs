using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class AzmayeshReal
    {
        public String sick_id, name, darman_date, type, date, result, comments;
        public long code;
        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO azmayesh_real (code, sick_id, name, darman_date, type, date, result, comments) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}') ";
            s = string.Format(s,this.code, this.sick_id, this.name, this.darman_date, this.type, this.date, this.result, this.comments);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ثبت  آزمایش (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه آزمایش " + this.code);
        }

        public void Delete()
        {
            string s = "DELETE FROM azmayesh_real WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("حذف  آزمایش (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه آزمایش " + this.code);
        }


        public void Update()
        {
            string s = "UPDATE azmayesh_real SET  type=N'{0}', date = N'{1}', result = N'{2}', comments = N'{3}' WHERE (code={4} )";
            s = string.Format(s, this.type, this.date, this.result, this.comments, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ویرایش  آزمایش (واقعی) برای بیمار با شماره پرونده ی " + this.sick_id + " - مشخصه آزمایش " + this.code);
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM azmayesh_real";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM azmayesh_real WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectSabegheh()
        {
            string s = "SELECT * FROM azmayesh_real WHERE (sick_id=N'{0}')";
            s = string.Format(s, this.sick_id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public long Selectmaxid()
        {
            string s = "select max(code) from azmayesh_real";
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