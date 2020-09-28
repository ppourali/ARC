using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class hazineh_types
    {

        public long id;
        public string htype;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into hazineh_types (id, htype) Values ({0},N'{1}')";
            s = string.Format(s, this.id, this.htype);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from hazineh_types where (id={0})";
            s = string.Format(s, this.id);
            da.Connect();
            da.docommand(s);

            s = "Update hazineh_types set id=id-1 where id>{0}";
            s = string.Format(s, this.id);
            da.docommand(s);

            da.disconnect();
        }

        public long Selectmaxid()
        {
            string s = "select max(id) from hazineh_types";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();

            string count;
            try
            {
                count = dt.Rows[0][0].ToString();
                return (long.Parse(count) + 1);
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public void Update()
        {
            string oldtype = Selectforedit().Rows[0]["htype"].ToString();

            

            string s = "Update hazineh_types set htype=N'{0}' where (id={1})";
            s = string.Format(s, this.htype, this.id);
            da.Connect();
            da.docommand(s);

            s = "Update hazineh set type=N'{0}' where (type=N'{1}')";
            s = string.Format(s, this.htype, oldtype);
            da.docommand(s);

            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "SELECT * from hazineh_types ORDER BY id";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * from hazineh_types where (id={0}) ORDER BY id";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }
 
        public DataTable SelectforComboBox()
        {
            string s = "select htype from hazineh_types order by htype asc";
            //s = string.Format(s, this.id);
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
