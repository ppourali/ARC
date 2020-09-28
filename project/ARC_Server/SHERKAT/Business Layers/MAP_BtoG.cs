using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mehr
{
    class MAP_BtoG
    {
        public String id, qoverdose, qb1, qb2_1, qb2_2, qb2_3, qb2_4, qb3, qb4, qb5, qb6, qb7, qb8, qb9_1, qb9_2, qb9_3, qc1, qc2, qc3, qc4, qc5, qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10, qd11, qd12, qd13, qd14, qd15, qd16, qd17, qd18, qd19, qd20, qe1, qe2, qe3, qe4, qe5, qe6, qe7, qf1, qf2, qf3, qf4, qf5, qf6, qg1, qg2, qg3;
        public long code;

        mydataaccess da = new mydataaccess();
        
        public void Add()
        {
            string s = "INSERT INTO Map_BtoG (code, id, qoverdose, qb1, qb2_1, qb2_2, qb2_3, qb2_4, qb3, qb4, qb5, qb6, qb7, qb8, qb9_1, qb9_2, qb9_3, "+
                                             "qc1, qc2, qc3, qc4, qc5, "+
                                             "qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10, qd11, qd12, qd13, qd14, qd15, qd16, qd17, qd18, qd19, qd20, "+
                                             "qe1, qe2, qe3, qe4, qe5, qe6, qe7, "+
                                             "qf1, qf2, qf3, qf4, qf5, qf6, "+
                                             "qg1, qg2, qg3) VALUES "+
                                             "({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}', N'{14}', N'{15}', "+
                                             "N'{16}', N'{17}', N'{18}', N'{19}', N'{20}', "+
                                             "N'{21}', N'{22}', N'{23}', N'{24}', N'{25}', N'{26}', N'{27}', N'{28}', N'{29}', N'{30}', N'{31}', N'{32}', N'{33}', N'{34}', N'{35}', N'{36}', N'{37}', N'{38}', N'{39}', N'{40}', "+
                                             "N'{41}', N'{42}', N'{43}', N'{44}', N'{45}', N'{46}', N'{47}', "+
                                             "N'{48}', N'{49}', N'{50}', N'{51}', N'{52}', N'{53}', "+
                                             "N'{54}', N'{55}', N'{56}',N'{57}')";
            s = string.Format(s, this.code, this.id, this.qoverdose, this.qb1, this.qb2_1, this.qb2_2, this.qb2_3, this.qb2_4, this.qb3, this.qb4, this.qb5, this.qb6, this.qb7, this.qb8, this.qb9_1, this.qb9_2, this.qb9_3, this.qc1, this.qc2, this.qc3, this.qc4, this.qc5, this.qd1, this.qd2, this.qd3, this.qd4, this.qd5, this.qd6, this.qd7, this.qd8, this.qd9, this.qd10, this.qd11, this.qd12, this.qd13, this.qd14, this.qd15, this.qd16, this.qd17, this.qd18, this.qd19, this.qd20, this.qe1, this.qe2, this.qe3, this.qe4, this.qe5, this.qe6, this.qe7, this.qf1, this.qf2, this.qf3, this.qf4, this.qf5, this.qf6, this.qg1, this.qg2, this.qg3);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        //public void Delete()
        //{
        //    string s = "DELETE FROM Map_BtoG WHERE (id=N'{0}')";
        //    s = string.Format(s, this.id);
        //    da.Connect();
        //    da.docommand(s);
        //    da.disconnect();
        //}


        public void Update()
        {
            string s = "UPDATE Map_BtoG SET qoverdose=N'{0}', qb1=N'{1}', qb2_1=N'{2}', qb2_2=N'{3}', qb2_3=N'{4}', qb2_4=N'{5}', qb3=N'{6}', qb4=N'{7}', qb5=N'{8}', qb6=N'{9}', qb7=N'{10}', qb8=N'{11}', qb9_1=N'{12}', qb9_2=N'{13}', qb9_3=N'{14}', " +
                                             "qc1=N'{15}', qc2=N'{16}', qc3=N'{17}', qc4=N'{18}', qc5=N'{19}', " +
                                             "qd1=N'{20}', qd2=N'{21}', qd3=N'{22}', qd4=N'{23}', qd5=N'{24}', qd6=N'{25}', qd7=N'{26}', qd8=N'{27}', qd9=N'{28}', qd10=N'{29}', qd11=N'{30}', qd12=N'{31}', qd13=N'{32}', qd14=N'{33}', qd15=N'{34}', qd16=N'{35}', qd17=N'{36}', qd18=N'{37}', qd19=N'{38}', qd20=N'{39}', " +
                                             "qe1=N'{40}', qe2=N'{41}', qe3=N'{42}', qe4=N'{43}', qe5=N'{44}', qe6=N'{45}', qe7=N'{46}', " +
                                             "qf1=N'{47}', qf2=N'{48}', qf3=N'{49}', qf4=N'{50}', qf5=N'{51}', qf6=N'{52}', " +
                                             "qg1=N'{53}', qg2=N'{54}', qg3=N'{55}' Where (code={56})";
            s = string.Format(s, this.qoverdose, this.qb1, this.qb2_1, this.qb2_2, this.qb2_3, this.qb2_4, this.qb3, this.qb4, this.qb5, this.qb6, this.qb7, this.qb8, this.qb9_1, this.qb9_2, this.qb9_3, this.qc1, this.qc2, this.qc3, this.qc4, this.qc5, this.qd1, this.qd2, this.qd3, this.qd4, this.qd5, this.qd6, this.qd7, this.qd8, this.qd9, this.qd10, this.qd11, this.qd12, this.qd13, this.qd14, this.qd15, this.qd16, this.qd17, this.qd18, this.qd19, this.qd20, this.qe1, this.qe2, this.qe3, this.qe4, this.qe5, this.qe6, this.qe7, this.qf1, this.qf2, this.qf3, this.qf4, this.qf5, this.qf6, this.qg1, this.qg2, this.qg3, this.code);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable Select()
        {
            string s = "SELECT * FROM Map_BtoG";
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }


        public DataTable Selectforedit()
        {
            string s = "SELECT * FROM Map_BtoG WHERE (code={0})";
            s = string.Format(s, this.code);
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