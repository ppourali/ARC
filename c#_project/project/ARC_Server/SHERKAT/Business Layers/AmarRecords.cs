using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class AmarRecords
    {
        public string date, reg_date, daru_name;
        public string kol_masrafi_daftar, pookeh, last_tedad_on_date_daftar, nowtedad_daftar, kol_masrafi_sandogh, last_tedad_on_date_sandogh, nowtedad_kol, nowtedad_sandogh, nowtedad_parastar, differences;
        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into amar_records (date,reg_date, daru_name, kol_masrafi_daftar, pookeh, last_tedad_on_date_daftar, nowtedad_daftar, kol_masrafi_sandogh, last_tedad_on_date_sandogh,nowtedad_kol, nowtedad_sandogh,nowtedad_parastar, differences) Values (N'{0}', N'{1}', N'{2}', N'{3}' ,N'{4}', N'{5}', N'{6}', N'{7}',N'{8}', N'{9}', N'{10}', N'{11}', N'{12}')";
            s = string.Format(s, this.date, this.reg_date, this.daru_name, this.kol_masrafi_daftar, this.pookeh, this.last_tedad_on_date_daftar, this.nowtedad_daftar, this.kol_masrafi_sandogh, this.last_tedad_on_date_sandogh, this.nowtedad_kol, this.nowtedad_sandogh, this.nowtedad_parastar, this.differences);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from amar_records where (date=N'{0}')";
            s = string.Format(s, this.date);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "SELECT  reg_date, daru_name, kol_masrafi_daftar, pookeh, last_tedad_on_date_daftar, nowtedad_daftar, kol_masrafi_sandogh, last_tedad_on_date_sandogh, nowtedad_kol,  nowtedad_sandogh, nowtedad_parastar, differences FROM amar_records WHERE (date=N'{0}')";
            s = string.Format(s, this.date);
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
