using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rpt
{
    class Sicks
    {
        public String id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, status;
        public long hesab;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO Sicks (id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, hesab, status) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}', {14}, N'{15}') ";
            s = string.Format(s, this.id, this.darman_date,this.payan_date, this.name, this.father_name, this.age, this.city, this.id_no,this.sex, this.home, this.mobile, this.masrafi_type, this.ravesh_tark, this.address, this.hesab, this.status);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "DELETE FROM Sicks WHERE (id=N'{0}')";
            s = string.Format(s, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public void Update()
        {
            string s = "UPDATE Sicks SET  darman_date = N'{0}', payan_date=N'{1}', name = N'{2}', father_name = N'{3}', age = N'{4}', city = N'{5}', id_no = N'{6}', sex=N'{7}', home = N'{8}', mobile = N'{9}', masrafi_type = N'{10}', ravesh_tark = N'{11}', address = N'{12}', hesab={13}, status=N'{14}'   WHERE (id = N'{15}' )";
            s = string.Format(s, this.darman_date,this.payan_date, this.name, this.father_name, this.age, this.city, this.id_no, this.sex, this.home, this.mobile, this.masrafi_type, this.ravesh_tark, this.address,this.hesab, this.status, this.id);
            da.Connect();
            da.docommand(s);

            s = "UPDATE Ghabz SET  name = N'{0}' WHERE (id = N'{1}' )";
            s = string.Format(s, this.name, this.id);
            da.docommand(s);

            s = "UPDATE mos_list SET  name = N'{0}', home=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.home, this.id);
            da.docommand(s);

            s = "UPDATE tahvil SET  name = N'{0}', ravesh_tark=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.ravesh_tark, this.id);
            da.docommand(s);

            s = "UPDATE tahvil_koli SET  name = N'{0}', ravesh_tark=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.ravesh_tark, this.id);
            da.docommand(s);

            s = "UPDATE tajviz SET  name = N'{0}', ravesh_tark=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.ravesh_tark, this.id);
            da.docommand(s);

            s = "UPDATE tajviz_koli SET  name = N'{0}', ravesh_tark=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.ravesh_tark, this.id);
            da.docommand(s);

            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM Sicks";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM Sicks WHERE (id=N'{0}')";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public void UpdateAfterGhabz()
        {
            string s = "UPDATE Sicks SET  hesab = {0}, status=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.hesab, this.status, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
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