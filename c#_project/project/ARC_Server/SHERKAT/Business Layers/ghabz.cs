using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class ghabz
    {
        public string id, name, sharh, date, ghabz_id;
        public long paid, mablagh;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into ghabz (ghabz_id,id,name,mablagh, paid,sharh, date) Values (N'{0}',N'{1}',N'{2}',{3},{4},N'{5}',N'{6}')";
            s = string.Format(s, this.ghabz_id, this.id, this.name, this.mablagh, this.paid, this.sharh, this.date);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("صدور قبض برای بیمار با شماره پرونده ی " + this.id + " - مشخصه قبض " + this.ghabz_id);
        }

        public void Delete()
        {
            string s = "Delete from ghabz where (ghabz_id=N'{0}')";
            s = string.Format(s, this.ghabz_id);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("حذف قبض به مشخصه ی " + this.ghabz_id);
        }

        
        public void Update()
        {
            string s = "Update ghabz set id=N'{0}', name=N'{1}',mablagh=N'{2}', paid=N'{3}',  sharh=N'{4}', date=N'{5}' where (ghabz_id=N'{6}')";
            s = string.Format(s, this.id, this.name, this.mablagh, this.paid, this.sharh, this.date,this.ghabz_id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
            
            new ActionLogs().Add("ویرایش قبض به مشخصه ی " + this.ghabz_id);
        }

        public DataTable Select()
        {
            string s = "SELECT row_number() over (order by ghabz_id Desc) as rowid, * from ghabz order by rowid asc";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable Selectmaxid()
        {
            string s = "select max(ghabz_id) from ghabz";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable Selectforedit()
        {
            string s = "SELECT * from ghabz where (ghabz_id=N'{0}')";
            s = string.Format(s, this.ghabz_id);
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
