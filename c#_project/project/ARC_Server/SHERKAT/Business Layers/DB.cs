using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mehr.Presentation_Layers;

namespace Mehr
{
    class DB
    {
        
        public int fn;
        public string path, Backup_name;
        string pass; // as a reminder : previous pass was mehrandarya / gholami
        mydataaccess da = new mydataaccess();

        public DB()
        {
            Darmangah da = new Darmangah();
            DataTable dt = da.Select();

            string gen_pass = dt.Rows[0]["Gen_Pass"].ToString();

            this.pass = gen_pass;
        }

        public void CreateBackup()
        {
            string s = "BACKUP DATABASE [ARC] TO  DISK = N'{0}' WITH RETAINDAYS = 60, NOFORMAT, NOINIT,  NAME = N'{1}', SKIP, NOREWIND, NOUNLOAD,  STATS = 10, MEDIAPASSWORD='{2}'";
            s = string.Format(s, this.path, this.Backup_name, this.pass);
            da.Connect();
            da.docommand(s);
            da.disconnect();
        }

        public DataTable restoreheader(string mediaPass)
        {
            string s = "RESTORE HEADERONLY FROM DISK =N'{0}' WITH MEDIAPASSWORD='{1}'";
            s = string.Format(s, this.Backup_name, mediaPass);
            da.Connect();
            DataTable dt = new DataTable();
            dt = da.select(s);
            da.disconnect();
            return dt;
        }

        public void Restore(string mediaPass)
        {
            string s = "ALTER DATABASE ARC SET OFFLINE WITH ROLLBACK IMMEDIATE";
            da.ConnectforRestore();
            da.docommand(s);
            da.disconnect();

            s = "RESTORE DATABASE [ARC] FROM  DISK = N'{0}' WITH  FILE = {1},  NOUNLOAD,  REPLACE,  STATS = 10, MEDIAPASSWORD='{2}'";
            s = string.Format(s, this.Backup_name, this.fn, mediaPass);
            da.ConnectforRestore();
            da.docommand(s);
            da.disconnect();
 
            s = "ALTER DATABASE ARC SET ONLINE WITH ROLLBACK IMMEDIATE";
            da.ConnectforRestore();
            da.docommand(s);
            da.disconnect();
            System.Data.SqlClient.SqlConnection.ClearAllPools();
        }
    }
}
