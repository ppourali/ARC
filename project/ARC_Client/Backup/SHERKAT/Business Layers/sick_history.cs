using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class sick_history
    {
        public String ghabz_id,sharh,date,tashkhis;
        public String sick_id;
        public Int64 bedehkari, bestankari, mandeh;

        private long radif;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            radif = Selectmaxid();
            string s = "INSERT INTO sick_history (radif, ghabz_id,sharh,date,sick_id,bedehkari,bestankari,tashkhis,mandeh) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', {5}, {6}, N'{7}', {8}) ";
            s = string.Format(s, this.radif, this.ghabz_id, this.sharh, this.date, this.sick_id, this.bedehkari, this.bestankari, this.tashkhis, this.mandeh);
            da.Connect();
            da.docommand(s);

            UpdateMandeh();

            da.disconnect();
        }


        public void Add_firstly()
        {
            if (this.tashkhis.Equals("认鍢茄"))
            {
                this.bedehkari = this.mandeh;
                this.bestankari = 0;
            }
            else if (this.tashkhis.Equals("扔是錁茄"))
            {
                this.bestankari = this.mandeh;
                this.bedehkari = 0;
            }


            
            radif = Selectmaxid();
            string s = "INSERT INTO sick_history (radif, ghabz_id,sharh,date,sick_id,bedehkari,bestankari,tashkhis,mandeh) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', {5}, {6}, N'{7}', {8}) ";
            s = string.Format(s, this.radif, this.ghabz_id, this.sharh, this.date, this.sick_id, this.bedehkari, this.bestankari, this.tashkhis, this.mandeh);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public long Selectmaxid()
        {
            string s = "select max(radif) from sick_history where (sick_id=N'"+this.sick_id+"')";
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

        public void Delete()
        {
            string s = "Delete from sick_history where (ghabz_id=N'{0}')";
            s = string.Format(s, this.ghabz_id);
            da.Connect();
            da.docommand(s);

            UpdateMandeh();

            da.disconnect();
        }

        public void UpdateAfterMandehChanged()
        {
            string s = "UPDATE sick_history SET  bedehkari = {0}, bestankari={1}, tashkhis=N'{2}', mandeh=N'{3}' WHERE (radif=1 and sick_id = N'{4}')";
            s = string.Format(s, this.bedehkari, this.bestankari, this.tashkhis, this.mandeh, this.sick_id);
            da.Connect();
            da.docommand(s);

            UpdateMandeh();

            da.disconnect();
        }
        
        public void UpdateAfterHamahangSazi(string tash, long man, long rad, string cusCode, int rid)
        {
            string s = "UPDATE sick_history SET radif={0}, tashkhis = N'{1}', mandeh={2} WHERE (radif={3} and sick_id=N'{4}')";
            s = string.Format(s, rid + 1, tash, man, rad, cusCode);
            //da.Connect();
            da.docommand(s);
            //            da.disconnect();
        }


        public void UpdateAfterEslahGhabz()
        {
            string s = "UPDATE sick_history SET  bedehkari = {0}, bestankari={1}, date=N'{2}' WHERE (ghabz_id=N'{3}' and sick_id = N'{4}' and sharh=N'{5}')";
            s = string.Format(s, this.bedehkari, this.bestankari, this.date, this.ghabz_id, this.sick_id, this.sharh);
            da.Connect();
            da.docommand(s);

            UpdateMandeh();

            da.disconnect();
        }

        public void UpdateMandeh()
        {
            DataTable dt = SelectForEslah();

            long sumbedehkari = 0, sumbestankari = 0, lastmandeh = 0;
            string tashkhisRow = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lastmandeh = 0;
                tashkhisRow = "";

                sumbedehkari += long.Parse(dt.Rows[i]["bedehkari"].ToString());
                sumbestankari += long.Parse(dt.Rows[i]["bestankari"].ToString());

                lastmandeh = sumbestankari - sumbedehkari;

                if (lastmandeh > 0)
                {
                    tashkhisRow = "扔是錁茄";
                }
                else if (lastmandeh <= 0)
                {
                    tashkhisRow = "认鍢茄";
                }

                UpdateAfterHamahangSazi(tashkhisRow, Math.Abs(lastmandeh), long.Parse(dt.Rows[i]["radif"].ToString()), dt.Rows[i]["sick_id"].ToString(), i);
            }
            Sicks sic = new Sicks();
            sic.id = this.sick_id; ;
            sic.hesab = Math.Abs(lastmandeh);
            sic.status = tashkhisRow;
            sic.UpdateAfterGhabz();
        }


        public DataTable SelectForEslah()
        {
            string s = "SELECT * FROM sick_history WHERE (sick_id=N'{0}') order by radif";
            s = string.Format(s, this.sick_id);
            DataTable dt = new DataTable();
            dt = da.select(s);
            return dt;
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM sick_history WHERE (sick_id=N'{0}') Order by radif ASC";
            s = string.Format(s, this.sick_id);
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