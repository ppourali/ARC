using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BugForNowrouz
{
    class anbar
    {
        public String daru_name, vahed, old_daruname;
        public float mandeh;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO anbar (daru_name, mandeh, vahed) VALUES ( N'{0}', {1}, N'{2}') ";
            s = string.Format(s, this.daru_name, this.mandeh, this.vahed);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM anbar WHERE (daru_name=N'{0}')";
            s = string.Format(s, this.daru_name);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public void Update()
        {
            string s = "Update anbar set daru_name= N'{0}', mandeh= {1}, vahed=N'{2}' where daru_name=N'{3}'";
            s = string.Format(s, this.daru_name, this.mandeh, this.vahed, this.old_daruname);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public void UpdateAfterFactor()
        {
            string s = "Update anbar set mandeh = mandeh + {0} where daru_name=N'{1}'";
            s = string.Format(s, this.mandeh, this.daru_name);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM anbar";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM anbar WHERE (daru_name=N'{0}')";
            s = string.Format(s, this.daru_name);
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