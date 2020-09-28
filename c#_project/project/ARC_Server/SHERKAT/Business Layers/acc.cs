using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class acc
    {
        public string user_code,pass,fname,lname,tel,address, semat;
        
        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into acc (user_code,pass,fname,lname,tel,address,semat) Values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')";
            s = string.Format(s, this.user_code, this.pass, this.fname, this.lname, this.tel, this.address, this.semat);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from acc where ( user_code=N'{0}' )";
            s = string.Format(s, this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void UpdateAccess()
        {
            string s = "Update acc set fname=N'{0}', lname=N'{1}', tel=N'{2}', address=N'{3}', semat=N'{4}' where user_code=N'{5}'";
            s = string.Format(s, this.fname,this.lname,this.tel, this.address, this.semat, this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void UpdatePassword()
        {
            string s = "Update acc set pass=N'{0}' where user_code=N'{1}'";
            s = string.Format(s, this.pass,this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "select * from acc where (user_code=N'{0}' and pass=N'{1}')";
            s = string.Format(s,this.user_code, this.pass);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectDoctors()
        {
            string s = "select fname+' '+lname as name from acc where (semat=N'پزشک')";
            s = string.Format(s, this.user_code, this.pass);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable SelectRavans()
        {
            string s = "select fname+' '+lname as name from acc where (semat=N'روانشناس')";
            s = string.Format(s, this.user_code, this.pass);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public DataTable checkpass()
        {
            string s = "select * from acc";
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
