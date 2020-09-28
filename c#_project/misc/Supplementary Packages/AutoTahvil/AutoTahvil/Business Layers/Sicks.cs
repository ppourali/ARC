using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AutoTahvil
{
    class Sicks
    {
        public String id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, status;
        public long hesab, roozaneh;

        mydataaccess da = new mydataaccess();

        public void Add()
        {
            string s = "INSERT INTO Sicks (id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, hesab, status) VALUES ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}', {14},{15}, N'{16}') ";
            s = string.Format(s, this.id, this.darman_date, this.payan_date, this.name, this.father_name, this.age, this.city, this.id_no, this.sex, this.home, this.mobile, this.masrafi_type, this.ravesh_tark, this.address, this.roozaneh, this.hesab, this.status);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public void Delete()
        {
            string s = "update Sicks SET payan_date=N'{0}' WHERE (id=N'{1}')";
            s = string.Format(s, this.payan_date, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }


        public void Update()
        {
            string s = "UPDATE Sicks SET  darman_date = N'{0}', payan_date=N'{1}', name = N'{2}', father_name = N'{3}', age = N'{4}', city = N'{5}', id_no = N'{6}', sex=N'{7}', home = N'{8}', mobile = N'{9}', masrafi_type = N'{10}', ravesh_tark = N'{11}', address = N'{12}', roozaneh={13}  WHERE (id = N'{14}' )";
            s = string.Format(s, this.darman_date, this.payan_date, this.name, this.father_name, this.age, this.city, this.id_no, this.sex, this.home, this.mobile, this.masrafi_type, this.ravesh_tark, this.address, this.roozaneh, this.id);
            da.Connect();
            da.docommand(s);

            s = "UPDATE Ghabz SET  name = N'{0}' WHERE (id = N'{1}' )";
            s = string.Format(s, this.name, this.id);
            da.docommand(s);

            s = "UPDATE mos_list SET  name = N'{0}', home=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.name, this.home, this.id);
            da.docommand(s);

            s = "UPDATE dastoor_pezeshk SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE ravanshenas SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE azmayesh SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE peygiri SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
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

            s = "UPDATE dastoor_pezeshk_real SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE ravanshenas_real SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE azmayesh_real SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);

            s = "UPDATE peygiri_real SET  name = N'{0}', darman_date=N'{1}' WHERE (sick_id = N'{2}' )";
            s = string.Format(s, this.name, this.darman_date, this.id);
            da.docommand(s);


            da.disconnect();
        }


        public DataTable Select()
        {
            string s = "SELECT * FROM Sicks ORDER BY PAYAN_DATE, ID ASC, RAVESH_TARK ASC";
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


        public string SelectfornameCheck()
        {
            string s = "SELECT name FROM Sicks WHERE (id=N'{0}')";
            s = string.Format(s, this.id);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return "";
        }


        public void UpdateAfterGhabz()
        {
            string s = "UPDATE Sicks SET  hesab = {0}, status=N'{1}' WHERE (id = N'{2}' )";
            s = string.Format(s, this.hesab, this.status, this.id);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable SelSicksFor()
        {
            string s = "SELECT t1.id , t1.name, t1.darman_date, t2.last_tah, t3.last_das, t4.last_rav, t5.last_azm " +
                        "FROM sicks t1 " +
                        "left JOIN ( SELECT id, MAX(tahvil_date) AS last_tah FROM tahvil_koli where (tedad>0) GROUP BY id) t2 ON t1.id = t2.id " +
                        "left JOIN ( SELECT sick_id, MAX(date) AS last_das FROM dastoor_pezeshk GROUP BY sick_id) t3 ON t1.id = t3.sick_id " +
                        "left JOIN ( SELECT sick_id, MAX(date) AS last_rav FROM ravanshenas GROUP BY sick_id) t4 ON t1.id = t4.sick_id " +
                        "left JOIN ( SELECT sick_id, MAX(date) AS last_azm FROM azmayesh GROUP BY sick_id) t5 ON t1.id = t5.sick_id " +
                        "Where (t1.payan_date = N'13  /  /  ')";

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