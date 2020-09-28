using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class takhfif
    {

        public long radif;
        public short start_range, end_range, takhfif_percent;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            radif = Selectmaxradif();
            string s = "insert into takhfif (radif, start_range, end_range, takhfif_percent) Values ({0}, {1}, {2}, {3})";
            s = string.Format(s, this.radif, this.start_range, this.end_range, this.takhfif_percent);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from takhfif";
            s = string.Format(s, this.radif);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public long Selectmaxradif()
        {
            string s = "select max(radif) from takhfif";
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

        public DataTable Select()
        {
            string s = "SELECT start_range, end_range, takhfif_percent from takhfif ORDER BY radif";
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
