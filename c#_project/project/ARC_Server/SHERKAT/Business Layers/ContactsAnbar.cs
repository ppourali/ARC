using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class ContactsAnbar
    {
        public String contactid, contactname, daru_name, vahed, old_daruname;
        public float mandeh, old_mandeh;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            DataTable dtifexists = Selectforedit();
            if (dtifexists.Rows.Count > 0)
            {
                MojoodiInc();
            }
            else if (dtifexists.Rows.Count == 0)
            {
                string s = "INSERT INTO contact_anbar (contactid, contactname, daru_name, mandeh, vahed) VALUES ( N'{0}', N'{1}', N'{2}', {3}, N'{4}') ";
                s = string.Format(s, this.contactid, this.contactname, this.daru_name, this.mandeh, this.vahed);
                da.Connect();
                da.docommand(s);
                da.disconnect();
            }

            new ActionLogs().Add("ثبت داروی " + this.daru_name + " به مقدار " + this.mandeh.ToString() + " به انبار دارویی مخاطب");
        }
        
        public void MojoodiInc()
        {
            string s = "update contact_anbar set mandeh=mandeh+{0} where (daru_name=N'{1}' and contactid=N'{2}')";
            s = string.Format(s, this.mandeh, this.daru_name, this.contactid);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM contact_anbar WHERE (daru_name=N'{0}' and contactid=N'{1}')";
            s = string.Format(s, this.daru_name, this.contactid);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("حدف  داروی " + this.daru_name + " از انبار دارویی مخاطب به مقدار" + this.mandeh.ToString());
        }


        public void Update()
        {
            string s = "Update contact_anbar set daru_name= N'{0}', mandeh= {1}, vahed=N'{2}' where daru_name=N'{3}' and contactid=N'{4}'";
            s = string.Format(s, this.daru_name, this.mandeh, this.vahed, this.old_daruname, this.contactid);
            da.Connect();
            da.docommand(s);
            da.disconnect();

            new ActionLogs().Add("ویرایش  داروی " + this.daru_name + " از انبار دارویی مخاطب از مقدار " + this.old_mandeh.ToString() + " به مقدار " + this.mandeh.ToString());
        }


        public void UpdateAfterFactor()
        {
            string s = "Update contact_anbar set mandeh = mandeh + {0} where daru_name=N'{1}' and contactid=N'{2}'";
            s = string.Format(s, this.mandeh, this.daru_name, this.contactid);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM contact_anbar where (contactid=N'{0}')";
            s = string.Format(s, this.contactid);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM contact_anbar WHERE (daru_name=N'{0}' and contactid=N'{1}')";
            s = string.Format(s, this.daru_name, this.contactid);
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