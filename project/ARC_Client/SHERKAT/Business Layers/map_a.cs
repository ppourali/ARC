using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class map_a
    {
        public String id, masrafi_type, rooz, mizan, tarigheh;
        public long code;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO map_a (code, id, masrafi_type, rooz, mizan, tarigheh) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}') ";
            s = string.Format(s,this.code, this.id, this.masrafi_type, this.rooz, this.mizan, this.tarigheh);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM map_a WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        //public void Update()
        //{
        //    string s = "DELETE FROM map_a WHERE (id=N'{0}')";
        //    s = string.Format(s, this.id);
        //    da.Connect();
        //    da.docommand(s);

        //    s = "INSERT INTO map_a (id, masrafi_type, rooz, mizan, tarigheh) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}') ";
        //    s = string.Format(s, this.id, this.masrafi_type, this.rooz, this.mizan, this.tarigheh);
        //    da.docommand(s);

        //    da.disconnect();
        //}


        public DataTable Select()
        {
            string s = "SELECT * FROM map_a";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM map_a WHERE (code={0})";
            s = string.Format(s, this.code);
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