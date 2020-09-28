using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Daru
{
    class anbar
    {
        public String daru_name, vahed, old_daruname;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO anbar (daru_name, vahed) VALUES ( '{0}','{1}') ";
            s = string.Format(s, this.daru_name, this.vahed);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM anbar WHERE (daru_name='{0}')";
            s = string.Format(s, this.daru_name);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public void Update()
        {
            string s = "Update anbar set daru_name= '{0}', vahed='{1}' where daru_name='{2}'";
            s = string.Format(s, this.daru_name, this.vahed, this.old_daruname);
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
            string s = "SELECT * FROM anbar WHERE (daru_name='{0}')";
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