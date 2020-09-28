using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rpt
{
    class tahvil_koli
    {
        public String id, name, ravesh_tark, tahvil_day, to_date, daru_name, from_date, tahvil_date;
        public float tedad;
        public long code;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "INSERT INTO tahvil_koli (code, id, name, ravesh_tark, tahvil_day, tahvil_date, from_date, to_date, daru_name, tedad)" +
                                    "VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', {9})";
            s = string.Format(s,this.code, this.id, this.name, this.ravesh_tark, this.tahvil_day, this.tahvil_date, this.from_date, this.to_date, this.daru_name, this.tedad);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM tahvil_koli WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            da.docommand(s);

            s = "DELETE FROM tahvil WHERE (code={0})";
            s = string.Format(s, this.code);
            da.docommand(s);


            //s = "Update tahvil_koli set code=code-1 WHERE (code>{0})";
            //s = string.Format(s, this.code);
            //da.docommand(s);


            //s = "Update tahvil set code=code-1 WHERE (code>{0})";
            //s = string.Format(s, this.code);
            //da.docommand(s);

            da.disconnect();
        }



        public DataTable Select()
        {
            string s = "SELECT * FROM tahvil_koli order by code";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable SelectforDelete()
        {
            string s = "select daru_name , tedad from tahvil_koli where (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectforEdit()
        {
            string s = "select * from tahvil_koli where (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable Selectmaxid()
        {
            string s = "select max(code) from tahvil_koli";
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