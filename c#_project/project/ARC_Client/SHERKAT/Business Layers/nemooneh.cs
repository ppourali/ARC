using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class nemooneh
    {
        public String context, type;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO nemooneh (context, type) VALUES ( N'{0}', N'{1}') ";
            s = string.Format(s, this.context, this.type);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM nemooneh WHERE (context=N'{0}' and type=N'{1}')";
            s = string.Format(s, this.context, this.type);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        //public void Update()
        //{
        //    string s = "UPDATE nemooneh SET  doctor_type = N'{0}', date=N'{1}', pre_text = N'{2}', azmayesh = N'{3}' WHERE (code={4} )";
        //    s = string.Format(s, this.doctor_type, this.date, this.pre_text, this.azmayesh, this.code);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}

        
        public DataTable Select()
        {
            string s = "SELECT * FROM nemooneh where (type=N'{0}')";
            s = string.Format(s, this.type);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        //public DataTable Search(string sql)
        //{
        //    da.Connect();
        //    DataTable dt = new DataTable();
        //    dt = da.select(sql);
        //    da.disconnect();
        //    return dt;
        //}

    }
}