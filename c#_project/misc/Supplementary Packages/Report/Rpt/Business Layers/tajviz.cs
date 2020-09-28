using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rpt
{
    class tajviz
    {
        public String id, name, ravesh_tark, tajviz_day, date, daru_name, tajviz_date;
        public float tedad;
        public long code;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO tajviz (code, id, name, ravesh_tark, tajviz_day, tajviz_date, date, daru_name, tedad)"+
                                    "VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', {8})";
            s = string.Format(s,this.code, this.id, this.name, this.ravesh_tark, this.tajviz_day, this.tajviz_date, this.date, this.daru_name, this.tedad);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        //public void Delete()
        //{
        //    string s = "DELETE FROM tajviz WHERE (tajviz_no=N'{0}' id=N'{1}')";
        //    s = string.Format(s, this.tajviz_no, this.id);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}


        //public void Update()
        //{
        //    string s = "DELETE FROM tajviz WHERE (id=N'{0}')";
        //    s = string.Format(s, this.id);
        //    da.Connect();
        //    da.docommand(s);

        //    s = "INSERT INTO tajviz (id, masrafi_type, rooz, mizan, tarigheh) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}') ";
        //    s = string.Format(s, this.id, this.name, this.date, this.to_date, this.to_from);
        //    da.docommand(s);

        //    da.disconnect();
        //}


        public DataTable Select()
        {
            string s = "SELECT * FROM tajviz where (code={0}) ORDER BY tajviz_date ASC";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable SelectSabegheh()
        {
            string s = "SELECT * FROM tajviz where (id=N'{0}') ORDER BY tajviz_date DESC";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        //public DataTable Selectforedit()
        //{
        //    string s = "SELECT * FROM tajviz (tajviz_no=N'{0}' id=N'{1}')";
        //    s = string.Format(s, this.tajviz_no, this.id);
        //    da.Connect();
        //    DataTable dt = new DataTable();
        //    dt = da.select(s);
        //    da.disconnect();
        //    return dt;
        //}


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