using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Daru
{
    class daru
    {
        public String daru_date, daru_name, tahvil_be, daryaft_az, tedad;
        public long fee, fee_kol;
        public int id;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO daru (id, daru_date, daru_name, tedad, daryaft_az, tahvil_be, fee, fee_kol) VALUES ( {0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6},{7}) ";
            s = string.Format(s, this.id, this.daru_date, this.daru_name,this.tedad, this.daryaft_az,this.tahvil_be, this.fee, this.fee_kol);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM daru WHERE (id={0})";
            s = string.Format(s, this.id);
            da.Connect();
            da.docommand(s);

            s = "Update daru set id=id-1 where id>{0}";
            s = string.Format(s, this.id);
            da.docommand(s);

            da.disconnect();
        }

        public void Update()
        {
            string s = "Update daru set daru_date='{0}', daru_name= '{1}', tedad='{2}', daryaft_az='{3}', tahvil_be='{4}', fee={5}, fee_kol={6} where id={7}";
            s = string.Format(s, this.daru_date, this.daru_name, this.tedad, this.daryaft_az, this.tahvil_be, this.fee, this.fee_kol, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM daru";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }



        public string SelectMaxid()
        {
            string s = "SELECT count(id) FROM daru";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();

            string mi = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            return mi;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM daru WHERE (id={0})";
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