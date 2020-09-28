using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Daru
{
    class contact
    {
        public String fullname, phone, address;
        public int id;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO contact (id, fullname, phone, address) VALUES ( {0}, '{1}', '{2}', '{3}') ";
            s = string.Format(s, this.id, this.fullname, this.phone,this.address);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM contact WHERE (id={0})";
            s = string.Format(s, this.id);
            da.Connect();
            da.docommand(s);

            s = "Update contact set id=id-1 where id>{0}";
            s = string.Format(s, this.id);
            da.docommand(s);

            da.disconnect();
        }

        public void Update()
        {
            string s = "Update contact set fullname='{0}', phone= '{1}', address='{2}' where id={3}";
            s = string.Format(s, this.fullname, this.phone, this.address, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM contact";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }



        public string SelectMaxid()
        {
            string s = "SELECT count(id) FROM contact";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();

            string mi = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            return mi;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM contact WHERE (id={0})";
            s = string.Format(s, this.id);
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