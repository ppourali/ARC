using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class Gen_settings
    {

        public string PayType, DaftariPayType, BazrasKey;
        public string Takhfif_Inc;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into Gen_settings (PayType, Takhfif_Inc, DaftariPayType, BazrasKey) Values (N'{0}', N'{1}', N'{2}', N'{3}')";
            s = string.Format(s, this.PayType, this.Takhfif_Inc, this.DaftariPayType, this.BazrasKey);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from Gen_settings";
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

     

        public void Update()
        {
            string s = "Update Gen_settings set Takhfif_Inc=N'{0}', PayType=N'{1}', DaftariPayType=N'{2}', BazrasKey=N'{3}'";
            s = string.Format(s, this.Takhfif_Inc, this.PayType, this.DaftariPayType, this.BazrasKey);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "SELECT * from Gen_settings";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        //public DataTable Selectforedit()
        //{
        //    string s = "SELECT * from Gen_settings where (PayType={0}) ORDER BY PayType";
        //    s = string.Format(s, this.PayType);
        //    da.Connect();
        //    DataTable dt = new DataTable();
        //    dt = da.select(s);
        //    da.disconnect();
        //    return dt;
        //}
 
        //public DataTable SelectforComboBox()
        //{
        //    string s = "select Takhfif_Inc from Gen_settings order by Takhfif_Inc asc";
        //    //s = string.Format(s, this.PayType);
        //    da.Connect();
        //    DataTable dt = new DataTable();
        //    dt = da.select(s);
        //    da.disconnect();
        //    return dt;
        //}

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
