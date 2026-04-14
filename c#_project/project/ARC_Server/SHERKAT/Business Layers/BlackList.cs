using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class BlackList
    {
        public string id, name, sharh;
        public long radif;
        mydataaccess da = new mydataaccess();

        public void Add()
        {

            if (SelectifExists().Rows.Count == 0)
            {
                radif = Selectmaxid();

                string s = "insert into black_list (radif, id,name,sharh) Values ({0},N'{1}',N'{2}',N'{3}')";
                s = string.Format(s, this.radif, this.id, this.name, this.sharh.Trim());
                da.Connect();
                da.docommand(s);
                da.disconnect();
            }
        }

        public void Delete()
        {
            string s = "Delete from black_list where (radif={0})";
            s = string.Format(s, this.radif);
            da.Connect();
            da.docommand(s);

            s = "update black_list set radif=radif-1 where (radif>{0})";
            s = string.Format(s, this.radif);
            da.docommand(s);

            da.disconnect();
        }

        
        public void Update()
        {
            string s = "Update black_list set id=N'{0}', name=N'{1}',sharh=N'{2}' where (radif={3})";
            s = string.Format(s, this.id, this.name, this.sharh, this.radif);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "SELECT  * from black_list order by radif asc";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectifExists()
        {
            string s = "SELECT  * from black_list where (id=N'{0}' and sharh=N'{1}')";
            s = string.Format(s, this.id, this.sharh.Trim());
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public long Selectmaxid()
        {
            string s = "select max(radif) from black_list";
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

        public string Selectfortajviz()
        {
            string s = "SELECT * from black_list where (id=N'{0}')";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();

            string probs = "";
            foreach (DataRow dr in dt.Rows)
            {
                probs =probs+ dr["sharh"].ToString().Trim() + " - ";
            }

            if (probs.Trim().Length > 0)
                probs = probs.Remove(probs.Length - 3);

            return probs;
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
