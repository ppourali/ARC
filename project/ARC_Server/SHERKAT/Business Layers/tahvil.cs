using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class tahvil
    {
        public String id, name, ravesh_tark, tahvil_day, date, daru_name, tahvil_date;
        public float tedad;
        public long code;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO tahvil (code, id, name, ravesh_tark, tahvil_day, tahvil_date, date, daru_name, tedad)"+
                                    "VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', {8})";
            s = string.Format(s,this.code, this.id, this.name, this.ravesh_tark, this.tahvil_day, this.tahvil_date, this.date, this.daru_name, this.tedad);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        //public void Delete()
        //{
        //    string s = "DELETE FROM tahvil WHERE (tahvil_no=N'{0}' id=N'{1}')";
        //    s = string.Format(s, this.tahvil_no, this.id);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}


        //public void Update()
        //{
        //    string s = "DELETE FROM tahvil WHERE (id=N'{0}')";
        //    s = string.Format(s, this.id);
        //    da.Connect();
        //    da.docommand(s);

        //    s = "INSERT INTO tahvil (id, masrafi_type, rooz, mizan, tarigheh) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}') ";
        //    s = string.Format(s, this.id, this.name, this.date, this.to_date, this.to_from);
        //    da.docommand(s);

        //    da.disconnect();
        //}


        public DataTable Select()
        {
            string s = "SELECT * FROM tahvil where (code={0}) ORDER BY tahvil_date ASC";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectSabegheh()
        {
            string s = "SELECT * FROM tahvil where (id=N'{0}') ORDER BY tahvil_date Desc, date desc";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }
        
        //public DataTable Selectforedit()
        //{
        //    string s = "SELECT * FROM tahvil (tahvil_no=N'{0}' id=N'{1}')";
        //    s = string.Format(s, this.tahvil_no, this.id);
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