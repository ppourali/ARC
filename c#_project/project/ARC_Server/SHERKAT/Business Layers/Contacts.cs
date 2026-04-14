using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class Contacts
    {
        public String fullname, phone, address;
        public string id;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "INSERT INTO contact (id, fullname, phone, address) VALUES ( N'{0}', '{1}', '{2}', '{3}') ";
            s = string.Format(s, this.id, this.fullname, this.phone, this.address);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM contact WHERE (id=N'{0}')";
            s = string.Format(s, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Update()
        {
            da.Connect();

            string s = "Update contact set fullname='{0}', phone= '{1}', address='{2}' where id=N'{3}'";
            s = string.Format(s, this.fullname, this.phone, this.address, this.id);
            da.docommand(s);

            s = "Update tajviz_anbar_history set contactname='{0}' where contactid=N'{1}'";
            s = string.Format(s, this.fullname, this.id);
            da.docommand(s);

            s = "Update contact_anbar set contactname='{0}' where contactid=N'{1}'";
            s = string.Format(s, this.fullname, this.id);
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



        public long Selectmaxid()
        {
            string s = "select max(id) from contact";
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


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM contact WHERE (id=N'{0}')";
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