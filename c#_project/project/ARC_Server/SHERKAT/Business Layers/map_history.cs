using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class map_history
    {
        public String id, masrafi_type, start_age, rooz, masraf_life, tarigheh;
        public long code;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO map_history (code, id, masrafi_type, start_age, rooz, masraf_life, tarigheh) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}') ";
            s = string.Format(s, this.code, this.id, this.masrafi_type, this.start_age, this.rooz, this.masraf_life, this.tarigheh);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM map_history WHERE (code={0})";
            s = string.Format(s, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        //public void Update()
        //{
        //    string s = "UPDATE map_history SET  masrafi_type = N'{0}', start_age = N'{1}', rooz = N'{2}', masraf_life = N'{3}', tarigheh = N'{4}' WHERE (id = N'{5}' )";
        //    s = string.Format(s, this.masrafi_type, this.start_age, this.rooz, this.masraf_life, this.tarigheh, this.id);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}


        public DataTable Select()
        {
            string s = "SELECT * FROM map_history";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM map_history WHERE (code={0})";
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