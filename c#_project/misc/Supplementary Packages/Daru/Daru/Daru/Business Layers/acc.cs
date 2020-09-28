using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Daru
{
    class acc
    {
        public string user_code,pass,fname,lname,tel,address;
        
        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "insert into acc (user_code,pass,fname,lname,tel,address) Values ('{0}','{1}','{2}','{3}','{4}','{5}')";
            s = string.Format(s, this.user_code, this.pass, this.fname, this.lname, this.tel, this.address);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "Delete from acc where ( user_code='{0}' )";
            s = string.Format(s, this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void UpdateAccess()
        {
            string s = "Update acc set fname='{0}', lname='{1}', tel='{2}', address='{3}' where user_code='{4}'";
            s = string.Format(s, this.fname,this.lname,this.tel, this.address, this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void UpdatePassword()
        {
            string s = "Update acc set pass='{0}' where user_code='{1}'";
            s = string.Format(s, this.pass,this.user_code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "select * from acc where (user_code='{0}' and pass='{1}')";
            s = string.Format(s,this.user_code, this.pass);
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


    }

}
