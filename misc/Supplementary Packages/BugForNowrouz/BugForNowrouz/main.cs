using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugForNowrouz
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sicks s = new Sicks();
            DataTable dt = s.Search("select id,hesab,status from sicks where (Not Exists (select distinct sick_id from sick_history where (sick_id=id)))");

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["status"].ToString() == "بدهکار")
                {
                    s.Search("INSERT INTO sick_history ([radif],[ghabz_id],[sick_id],[sharh],[date],[bedehkari],[bestankari],[tashkhis],[mandeh]) VALUES  "+
                             "(1,N'-',N' "+ dr["id"].ToString() + "' ,N'مانده اولیه' ,N'1390/03/15', "+ dr["hesab"].ToString() + ",0,N' "+ dr["status"] + "', "+ dr["hesab"].ToString() + ")");
                }
                else if (dr["status"].ToString() == "بستانکار")
                {
                    s.Search("INSERT INTO sick_history ([radif],[ghabz_id],[sick_id],[sharh],[date],[bedehkari],[bestankari],[tashkhis],[mandeh]) VALUES  "+
                             "(1,N'-',N' "+ dr["id"].ToString() + "' ,N'مانده اولیه' ,N'1390/03/15',0, "+ dr["hesab"].ToString() + ",N' "+ dr["status"] + "', "+ dr["hesab"].ToString() + ")");
                }
                i++;

            }
            MessageBox.Show(i.ToString());
            //s.Search("Update sick_history SET radif=radif+1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db d = new db();
            d.CHANGETOARC();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tajviz_koli tk = new tajviz_koli();
            DataTable dt = tk.Search("select tajviz.code tcode, tajviz_koli.code tkcode, tajviz.tajviz_date tdate, tajviz_koli.tajviz_date tkdate from tajviz, tajviz_koli where (tajviz.code=tajviz_koli.code and tajviz.tajviz_date!=tajviz_koli.tajviz_date)");

            foreach (DataRow dr in dt.Rows)
            {
                tk.Search("Update tajviz set tajviz_date=N' "+ dr["tkdate"].ToString() + "' where (code= "+ dr["tkcode"].ToString() + ")");
            }

            MessageBox.Show("done");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sicks tk = new Sicks();
            DataTable dt = tk.Search("select sick_id,tashkhis,mandeh from sick_history");

            foreach (DataRow dr in dt.Rows)
            {
                tk.Search("Update sicks set status=N' "+ dr["tashkhis"].ToString() + "', hesab=N' "+ dr["mandeh"].ToString() + "' where (id=N' "+ dr["sick_id"].ToString() + "')");
            }

            MessageBox.Show("done");
        }

        private void button6_Click(object sender, EventArgs e)
        {


            Sicks sicksname = new Sicks();

            DataTable allsicks = sicksname.Select();
            DataTable allghabz = sicksname.Search("select * from ghabz");

            foreach (DataRow dtr in allghabz.Rows)
            {

                sick_history sh = new sick_history();
                // Elame bedehkari
                sh.ghabz_id = dtr["ghabz_id"].ToString();
                sh.sick_id = dtr["id"].ToString();
                sh.sharh = dtr["sharh"].ToString();
                sh.date = dtr["date"].ToString();
                sh.bedehkari = long.Parse(dtr["mablagh"].ToString());
                sh.Add();

                sick_history shb = new sick_history();
                // Elame bedehkari
                shb.ghabz_id = dtr["ghabz_id"].ToString();
                shb.sick_id = dtr["id"].ToString();
                shb.sharh = "پرداخت وجه از بابت  "+ dtr["sharh"].ToString();
                shb.date = dtr["date"].ToString();
                shb.bestankari = long.Parse(dtr["paid"].ToString());
                shb.Add();

            }
            MessageBox.Show("قبض با موفقیت ثبت گردید");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sicks si = new Sicks();
            DataTable dt = si.Search("select id,name from sicks");

            foreach (DataRow dr in dt.Rows)
            {
                si.id = dr["id"].ToString();
                si.name = dr["name"].ToString().Trim();
                si.Updatefortrim();
            }
            MessageBox.Show("عملیات با موفقیت ثبت گردید");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Sicks si = new Sicks();

            si.Search("delete from action_logs");

            si.Search("BEGIN TRANSACTION  "+
"SET QUOTED_IDENTIFIER ON  "+
"SET ARITHABORT ON  "+
"SET NUMERIC_ROUNDABORT OFF  "+
"SET CONCAT_NULL_YIELDS_NULL ON  "+
"SET ANSI_NULLS ON  "+
"SET ANSI_PADDING ON  "+
"SET ANSI_WARNINGS ON  "+
"COMMIT  "+
"BEGIN TRANSACTION  "+
"ALTER TABLE dbo.action_logs  "+
    "DROP CONSTRAINT PK_action_logs  "+
"ALTER TABLE dbo.action_logs  "+
    "DROP COLUMN id  "+
"COMMIT");

            MessageBox.Show("عملیات با موفقیت ثبت گردید");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Sicks si = new Sicks();

            si.Search("USE [ARC]  "+
"SET ANSI_NULLS ON  "+
"SET QUOTED_IDENTIFIER ON  "+
"CREATE TABLE [dbo].[Gen_Settings](  "+
    "[PayType] [nvarchar](6) NOT NULL CONSTRAINT [DF_Gen_Settings_PayType]  DEFAULT (N'روزانه'),  "+
    "[Takhfif_Inc] [nvarchar](3) NOT NULL CONSTRAINT [DF_Gen_Settings_Takhfif_Inc]  DEFAULT (N'بلی')  "+
") ON [PRIMARY]  "+
"insert into Gen_settings (PayType, Takhfif_Inc) Values (N'روزانه', N'بلی')");

            si.Search("use [arc] "+
"BEGIN TRANSACTION  "+
"SET QUOTED_IDENTIFIER ON  "+
"SET ARITHABORT ON  "+
"SET NUMERIC_ROUNDABORT OFF  "+
"SET CONCAT_NULL_YIELDS_NULL ON  "+
"SET ANSI_NULLS ON  "+
"SET ANSI_PADDING ON  "+
"SET ANSI_WARNINGS ON  "+
"COMMIT  "+
"BEGIN TRANSACTION  "+
"ALTER TABLE dbo.tajviz_anbar ADD  "+
    "fee bigint NOT NULL CONSTRAINT DF_tajviz_anbar_fee DEFAULT 0  "+
"COMMIT");


            MessageBox.Show("عملیات با موفقیت ثبت گردید");
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Sicks si = new Sicks();

            si.Search("USE [ARC]  "+
"BEGIN TRANSACTION "+
"SET QUOTED_IDENTIFIER ON "+
"SET ARITHABORT ON "+
"SET NUMERIC_ROUNDABORT OFF "+
"SET CONCAT_NULL_YIELDS_NULL ON "+
"SET ANSI_NULLS ON "+
"SET ANSI_PADDING ON "+
"SET ANSI_WARNINGS ON "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.anbar ADD "+
"	fee bigint NOT NULL CONSTRAINT DF_anbar_fee DEFAULT 0 "+
"COMMIT");

            si.Search("USE [ARC]  "+
"SET ANSI_NULLS ON "+
"SET QUOTED_IDENTIFIER ON "+
"CREATE TABLE [dbo].[ghabz_daftari]( "+
"	[ghabz_id] [nchar](6) NOT NULL, "+
"	[id] [nchar](4) NULL, "+
"	[name] [nvarchar](50) NULL, "+
"	[mablagh] [bigint] NOT NULL CONSTRAINT [DF_ghabz_daftari_mablagh]  DEFAULT ((0)), "+
"	[paid] [bigint] NOT NULL CONSTRAINT [DF_ghabz_daftari_paid]  DEFAULT ((0)), "+
"	[sharh] [nvarchar](100) NULL, "+
"	[date] [nchar](10) NULL, "+
" CONSTRAINT [PK_ghabz_daftari] PRIMARY KEY CLUSTERED  "+
"( "+
"	[ghabz_id] ASC "+
")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "+
") ON [PRIMARY] "+
"ALTER TABLE [dbo].[ghabz_daftari]  WITH CHECK ADD  CONSTRAINT [FK_ghabz_daftari_Sicks] FOREIGN KEY([id]) "+
"REFERENCES [dbo].[Sicks] ([id]) "+
"ON UPDATE CASCADE "+
"ON DELETE CASCADE "+
"ALTER TABLE [dbo].[ghabz_daftari] CHECK CONSTRAINT [FK_ghabz_daftari_Sicks]");

            si.Search("USE [ARC]  "+
"SET ANSI_NULLS ON "+
"SET QUOTED_IDENTIFIER ON "+
"CREATE TABLE [dbo].[sick_history_daftari]( "+
"	[radif] [bigint] NOT NULL CONSTRAINT [DF_sick_history_daftari_radif]  DEFAULT ((0)), "+
"	[ghabz_id] [nchar](6) NULL, "+
"	[sick_id] [nchar](4) NOT NULL, "+
"	[sharh] [nvarchar](100) NULL, "+
"	[date] [nchar](10) NULL, "+
"	[bedehkari] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_bedehkari]  DEFAULT ((0)), "+
"	[bestankari] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_bestankari]  DEFAULT ((0)), "+
"	[tashkhis] [nvarchar](8) NULL, "+
"	[mandeh] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_mandeh]  DEFAULT ((0)), "+
" CONSTRAINT [PK_sick_history_daftari] PRIMARY KEY CLUSTERED  "+
"( "+
"	[radif] ASC, "+
"	[sick_id] ASC "+
")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "+
") ON [PRIMARY] "+
"ALTER TABLE [dbo].[sick_history_daftari]  WITH CHECK ADD  CONSTRAINT [FK_sick_history_daftari_Sicks] FOREIGN KEY([sick_id]) "+
"REFERENCES [dbo].[Sicks] ([id]) "+
"ON UPDATE CASCADE "+
"ON DELETE CASCADE "+
"ALTER TABLE [dbo].[sick_history_daftari] CHECK CONSTRAINT [FK_sick_history_daftari_Sicks]");

            si.Search("USE [ARC]  "+
"BEGIN TRANSACTION "+
"SET QUOTED_IDENTIFIER ON "+
"SET ARITHABORT ON "+
"SET NUMERIC_ROUNDABORT OFF "+
"SET CONCAT_NULL_YIELDS_NULL ON "+
"SET ANSI_NULLS ON "+
"SET ANSI_PADDING ON "+
"SET ANSI_WARNINGS ON "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.Darmangah ADD "+
"	Gen_Pass nvarchar(8) NOT NULL CONSTRAINT DF_Darmangah_Gen_Pass DEFAULT 12345678 "+
"COMMIT");
            si.Search("USE [ARC]  "+
"BEGIN TRANSACTION "+
"SET QUOTED_IDENTIFIER ON "+
"SET ARITHABORT ON "+
"SET NUMERIC_ROUNDABORT OFF "+
"SET CONCAT_NULL_YIELDS_NULL ON "+
"SET ANSI_NULLS ON "+
"SET ANSI_PADDING ON "+
"SET ANSI_WARNINGS ON "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.Gen_Settings ADD "+
"	DaftariPayType nvarchar(6) NOT NULL CONSTRAINT DF_Gen_Settings_DaftariPayType DEFAULT N'ماهانه', "+
"	BazrasKey nvarchar(50) NOT NULL CONSTRAINT DF_Gen_Settings_BazrasKey DEFAULT N'F12' "+
"COMMIT");


            si.Search("USE [ARC]  "+
"BEGIN TRANSACTION " +
"SET QUOTED_IDENTIFIER ON "+
"SET ARITHABORT ON "+
"SET NUMERIC_ROUNDABORT OFF "+
"SET CONCAT_NULL_YIELDS_NULL ON "+
"SET ANSI_NULLS ON "+
"SET ANSI_PADDING ON "+
"SET ANSI_WARNINGS ON "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Customers_bedehkar "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_sex "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_home "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_hesab "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_status "+
"CREATE TABLE dbo.Tmp_Sicks "+
"	( "+
"	id nchar(4) NOT NULL, "+
"	darman_date nchar(10) NULL, "+
"	payan_date nchar(10) NULL, "+
"	name nvarchar(50) NOT NULL, "+
"	father_name nvarchar(30) NULL, "+
"	age nvarchar(2) NOT NULL, "+
"	city nvarchar(20) NOT NULL, "+
"	id_no nvarchar(10) NULL, "+
"	sex nchar(4) NULL, "+
"	home nvarchar(11) NULL, "+
"	mobile nvarchar(11) NULL, "+
"	masrafi_type nvarchar(150) NOT NULL, "+
"	ravesh_tark nvarchar(50) NOT NULL, "+
"	address nvarchar(100) NULL, "+
"	roozaneh bigint NULL, "+
"	monthFee bigint NOT NULL, "+
"	hesab bigint NOT NULL, "+
"	status nvarchar(8) NULL "+
"	)  ON [PRIMARY] "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Customers_bedehkar DEFAULT ((0)) FOR age "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_sex DEFAULT (N'مذکر') FOR sex "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_home DEFAULT (N'مذکر') FOR home "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_monthFee DEFAULT 0 FOR monthFee "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_hesab DEFAULT ((0)) FOR hesab "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_status DEFAULT (N'بدهکار') FOR status "+
"IF EXISTS(SELECT * FROM dbo.Sicks) "+
"	 EXEC('INSERT INTO dbo.Tmp_Sicks (id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, hesab, status) "+
"		SELECT id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, hesab, status FROM dbo.Sicks WITH (HOLDLOCK TABLOCKX)') "+
"ALTER TABLE dbo.peygiri "+
"	DROP CONSTRAINT FK_peygiri_Sicks "+
"ALTER TABLE dbo.peygiri_real "+
"	DROP CONSTRAINT FK_peygiri_real_Sicks "+
"ALTER TABLE dbo.ravanshenas "+
"	DROP CONSTRAINT FK_ravanshenas_Sicks "+
"ALTER TABLE dbo.ravanshenas_real "+
"	DROP CONSTRAINT FK_ravanshenas_real_Sicks "+
"ALTER TABLE dbo.sick_history "+
"	DROP CONSTRAINT FK_sick_history_Sicks "+
"ALTER TABLE dbo.tahvil "+
"	DROP CONSTRAINT FK_tahvil_Sicks "+
"ALTER TABLE dbo.tahvil_koli "+
"	DROP CONSTRAINT FK_tahvil_koli_Sicks "+
"ALTER TABLE dbo.tajviz "+
"	DROP CONSTRAINT FK_tajviz_Sicks "+
"ALTER TABLE dbo.tajviz_koli "+
"	DROP CONSTRAINT FK_tajviz_koli_Sicks "+
"ALTER TABLE dbo.ghabz "+
"	DROP CONSTRAINT FK_ghabz_Sicks "+
"ALTER TABLE dbo.assessment "+
"	DROP CONSTRAINT FK_assessment_Sicks "+
"ALTER TABLE dbo.black_list "+
"	DROP CONSTRAINT FK_black_list_Sicks "+
"ALTER TABLE dbo.ghabz_daftari "+
"	DROP CONSTRAINT FK_ghabz_daftari_Sicks "+
"ALTER TABLE dbo.sick_history_daftari "+
"	DROP CONSTRAINT FK_sick_history_daftari_Sicks "+
"ALTER TABLE dbo.mos_list "+
"	DROP CONSTRAINT FK_mos_list_Sicks "+
"ALTER TABLE dbo.azmayesh "+
"	DROP CONSTRAINT FK_azmayesh_Sicks "+
"ALTER TABLE dbo.azmayesh_real "+
"	DROP CONSTRAINT FK_azmayesh_real_Sicks "+
"ALTER TABLE dbo.dastoor_pezeshk "+
"	DROP CONSTRAINT FK_dastoor_pezeshk_Sicks "+
"ALTER TABLE dbo.dastoor_pezeshk_real "+
"	DROP CONSTRAINT FK_dastoor_pezeshk_real_Sicks "+
"DROP TABLE dbo.Sicks "+
"EXECUTE sp_rename N'dbo.Tmp_Sicks', N'Sicks', 'OBJECT'  "+
"ALTER TABLE dbo.Sicks ADD CONSTRAINT "+
"	PK_Customers PRIMARY KEY CLUSTERED  "+
"	( "+
"	id "+
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.dastoor_pezeshk_real ADD CONSTRAINT "+
"	FK_dastoor_pezeshk_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.dastoor_pezeshk ADD CONSTRAINT "+
"	FK_dastoor_pezeshk_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.azmayesh_real ADD CONSTRAINT "+
"	FK_azmayesh_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.azmayesh ADD CONSTRAINT "+
"	FK_azmayesh_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.mos_list ADD CONSTRAINT "+
"	FK_mos_list_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.sick_history_daftari ADD CONSTRAINT "+
"	FK_sick_history_daftari_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.ghabz_daftari ADD CONSTRAINT "+
"	FK_ghabz_daftari_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.black_list ADD CONSTRAINT "+
"	FK_black_list_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.assessment ADD CONSTRAINT "+
"	FK_assessment_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.ghabz ADD CONSTRAINT "+
"	FK_ghabz_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.tajviz_koli ADD CONSTRAINT "+
"	FK_tajviz_koli_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.tajviz ADD CONSTRAINT "+
"	FK_tajviz_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.tahvil_koli ADD CONSTRAINT "+
"	FK_tahvil_koli_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.tahvil ADD CONSTRAINT "+
"	FK_tahvil_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.sick_history ADD CONSTRAINT "+
"	FK_sick_history_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.ravanshenas_real ADD CONSTRAINT "+
"	FK_ravanshenas_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.ravanshenas ADD CONSTRAINT "+
"	FK_ravanshenas_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.peygiri_real ADD CONSTRAINT "+
"	FK_peygiri_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"COMMIT "+
"BEGIN TRANSACTION "+
"ALTER TABLE dbo.peygiri ADD CONSTRAINT "+
"	FK_peygiri_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE "+
"COMMIT");


            si.Search("update sicks set monthFee=86600");

            MessageBox.Show("عملیات با موفقیت ثبت گردید");


        }

        private void button11_Click(object sender, EventArgs e)
        {

            sick_history_daftari sickhdd = new sick_history_daftari();
            sickhdd.DeleteAll();

            Sicks sicksname = new Sicks();

            DataTable allsicks = sicksname.Select();

            foreach (DataRow dtr in allsicks.Rows)
            {
                sick_history_daftari sickhd = new sick_history_daftari();
                sickhd.ghabz_id = "-";
                sickhd.sharh = "مانده اولیه";
                sickhd.date = dtr["darman_date"].ToString();
                sickhd.sick_id = dtr["id"].ToString();
                sickhd.tashkhis = "بدهکار";
                sickhd.mandeh = 0;
                sickhd.Add_firstly();
            }

            MessageBox.Show("عملیات با موفقیت ثبت گردید");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //try
            //{
              

                Sicks Scks = new Sicks();


            // For Navid, it was a mess ! I had to reset the ghabz_ids in the ghabz table with the  sick_history table
                Scks.Search("update ghabz set ghabz.id=sick_history.sick_id from sick_history where (ghabz.ghabz_id=sick_history.ghabz_id)");



                DataTable sicksNotinGhaz = Scks.Search("select * from ghabz where id not in (select id from sicks)");
                if (sicksNotinGhaz.Rows.Count > 0)
                {
                    for (int i = 0; i < sicksNotinGhaz.Rows.Count; i++)
                    {
                            DataTable sickNameToId = Scks.Search("Select * from sicks where (name=N'" + sicksNotinGhaz.Rows[i]["name"].ToString() + "')");
                            Scks.Search("update ghabz set id=N'" + sickNameToId.Rows[0]["id"].ToString().Trim() + "'");
                        

                    }
                }


                    //add foriegn key to the table Ghabz
                    Scks.Search("BEGIN TRANSACTION " +
    "SET QUOTED_IDENTIFIER ON " +
    "SET ARITHABORT ON " +
    "SET NUMERIC_ROUNDABORT OFF " +
    "SET CONCAT_NULL_YIELDS_NULL ON " +
    "SET ANSI_NULLS ON " +
    "SET ANSI_PADDING ON " +
    "SET ANSI_WARNINGS ON " +
    "COMMIT " +
    "BEGIN TRANSACTION " +
    "COMMIT " +
    "BEGIN TRANSACTION " +
    "ALTER TABLE dbo.ghabz ADD CONSTRAINT " +
    "	FK_ghabz_Sicks FOREIGN KEY " +
    "	( " +
    "	id " +
    "	) REFERENCES dbo.Sicks " +
    "	( " +
    "	id " +
    "	) ON UPDATE  CASCADE  " +
    "	 ON DELETE  CASCADE " +
    "COMMIT");

                //update kardane tedade horoofe jadvale bimaran be nvarchar(15)
                Scks.Search("BEGIN TRANSACTION " +
"SET QUOTED_IDENTIFIER ON " +
"SET ARITHABORT ON " +
"SET NUMERIC_ROUNDABORT OFF " +
"SET CONCAT_NULL_YIELDS_NULL ON " +
"SET ANSI_NULLS ON " +
"SET ANSI_PADDING ON " +
"SET ANSI_WARNINGS ON " +
"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Customers_bedehkar " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_sex " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_home " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_roozaneh " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_monthFee " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_hesab " +

"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_status " +

"CREATE TABLE dbo.Tmp_Sicks " +
"	( " +
"	id nvarchar(15) NOT NULL, " +
"	darman_date nchar(10) NULL, " +
"	payan_date nchar(10) NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	father_name nvarchar(30) NULL, " +
"	age nvarchar(2) NOT NULL, " +
"	city nvarchar(20) NOT NULL, " +
"	id_no nvarchar(10) NULL, " +
"	sex nchar(4) NULL, " +
"	home nvarchar(11) NULL, " +
"	mobile nvarchar(11) NULL, " +
"	masrafi_type nvarchar(150) NOT NULL, " +
"	ravesh_tark nvarchar(50) NOT NULL, " +
"	address nvarchar(100) NULL, " +
"	roozaneh bigint NULL, " +
"	monthFee bigint NOT NULL, " +
"	hesab bigint NOT NULL, " +
"	status nvarchar(8) NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Customers_bedehkar DEFAULT ((0)) FOR age " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_sex DEFAULT (N'مذکر') FOR sex " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_home DEFAULT (N'مذکر') FOR home " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_roozaneh DEFAULT ((0)) FOR roozaneh " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_monthFee DEFAULT ((0)) FOR monthFee " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_hesab DEFAULT ((0)) FOR hesab " +

"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_status DEFAULT (N'بدهکار') FOR status " +

"IF EXISTS(SELECT * FROM dbo.Sicks) " +
"	 EXEC('INSERT INTO dbo.Tmp_Sicks (id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status) " +
"		SELECT CONVERT(nvarchar(15), id), darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status FROM dbo.Sicks WITH (HOLDLOCK TABLOCKX)') " +

"ALTER TABLE dbo.black_list " +
"	DROP CONSTRAINT FK_black_list_Sicks " +

"ALTER TABLE dbo.azmayesh_real " +
"	DROP CONSTRAINT FK_azmayesh_real_Sicks " +

"ALTER TABLE dbo.azmayesh " +
"	DROP CONSTRAINT FK_azmayesh_Sicks " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT FK_assessment_Sicks " +

"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT FK_sick_history_Sicks " +

"ALTER TABLE dbo.tajviz_koli " +
"	DROP CONSTRAINT FK_tajviz_koli_Sicks " +

"ALTER TABLE dbo.tajviz " +
"	DROP CONSTRAINT FK_tajviz_Sicks " +

"ALTER TABLE dbo.tahvil_koli " +
"	DROP CONSTRAINT FK_tahvil_koli_Sicks " +

"ALTER TABLE dbo.tahvil " +
"	DROP CONSTRAINT FK_tahvil_Sicks " +

"ALTER TABLE dbo.ghabz " +
"	DROP CONSTRAINT FK_ghabz_Sicks " +

"ALTER TABLE dbo.ravanshenas_real " +
"	DROP CONSTRAINT FK_ravanshenas_real_Sicks " +

"ALTER TABLE dbo.ravanshenas " +
"	DROP CONSTRAINT FK_ravanshenas_Sicks " +

"ALTER TABLE dbo.peygiri_real " +
"	DROP CONSTRAINT FK_peygiri_real_Sicks " +

"ALTER TABLE dbo.peygiri " +
"	DROP CONSTRAINT FK_peygiri_Sicks " +

"ALTER TABLE dbo.dastoor_pezeshk_real " +
"	DROP CONSTRAINT FK_dastoor_pezeshk_real_Sicks " +

"ALTER TABLE dbo.dastoor_pezeshk " +
"	DROP CONSTRAINT FK_dastoor_pezeshk_Sicks " +

"ALTER TABLE dbo.mos_list " +
"	DROP CONSTRAINT FK_mos_list_Sicks " +

"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT FK_sick_history_daftari_Sicks " +

"ALTER TABLE dbo.ghabz_daftari " +
"	DROP CONSTRAINT FK_ghabz_daftari_Sicks " +

"DROP TABLE dbo.Sicks " +

"EXECUTE sp_rename N'dbo.Tmp_Sicks', N'Sicks', 'OBJECT'  " +

"ALTER TABLE dbo.Sicks ADD CONSTRAINT " +
"	PK_Customers PRIMARY KEY CLUSTERED  " +
"	( " +
"	id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.ghabz_daftari " +
"	DROP CONSTRAINT DF_ghabz_daftari_mablagh " +

"ALTER TABLE dbo.ghabz_daftari " +
"	DROP CONSTRAINT DF_ghabz_daftari_paid " +

"CREATE TABLE dbo.Tmp_ghabz_daftari " +
"	( " +
"	ghabz_id nchar(6) NOT NULL, " +
"	id nvarchar(15) NULL, " +
"	name nvarchar(50) NULL, " +
"	mablagh bigint NOT NULL, " +
"	paid bigint NOT NULL, " +
"	sharh nvarchar(100) NULL, " +
"	date nchar(10) NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_ghabz_daftari ADD CONSTRAINT " +
"	DF_ghabz_daftari_mablagh DEFAULT ((0)) FOR mablagh " +

"ALTER TABLE dbo.Tmp_ghabz_daftari ADD CONSTRAINT " +
"	DF_ghabz_daftari_paid DEFAULT ((0)) FOR paid " +

"IF EXISTS(SELECT * FROM dbo.ghabz_daftari) " +
"	 EXEC('INSERT INTO dbo.Tmp_ghabz_daftari (ghabz_id, id, name, mablagh, paid, sharh, date) " +
"		SELECT ghabz_id, CONVERT(nvarchar(15), id), name, mablagh, paid, sharh, date FROM dbo.ghabz_daftari WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.ghabz_daftari " +

"EXECUTE sp_rename N'dbo.Tmp_ghabz_daftari', N'ghabz_daftari', 'OBJECT'  " +

"ALTER TABLE dbo.ghabz_daftari ADD CONSTRAINT " +
"	PK_ghabz_daftari PRIMARY KEY CLUSTERED  " +
"	( " +
"	ghabz_id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.ghabz_daftari ADD CONSTRAINT " +
"	FK_ghabz_daftari_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT DF_sick_history_daftari_radif " +

"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT DF_sick_history_daftari_bedehkari " +

"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT DF_sick_history_daftari_bestankari " +

"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT DF_sick_history_daftari_mandeh " +

"CREATE TABLE dbo.Tmp_sick_history_daftari " +
"	( " +
"	radif bigint NOT NULL, " +
"	ghabz_id nchar(6) NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	sharh nvarchar(100) NULL, " +
"	date nchar(10) NULL, " +
"	bedehkari bigint NULL, " +
"	bestankari bigint NULL, " +
"	tashkhis nvarchar(8) NULL, " +
"	mandeh bigint NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_sick_history_daftari ADD CONSTRAINT " +
"	DF_sick_history_daftari_radif DEFAULT ((0)) FOR radif " +

"ALTER TABLE dbo.Tmp_sick_history_daftari ADD CONSTRAINT " +
"	DF_sick_history_daftari_bedehkari DEFAULT ((0)) FOR bedehkari " +

"ALTER TABLE dbo.Tmp_sick_history_daftari ADD CONSTRAINT " +
"	DF_sick_history_daftari_bestankari DEFAULT ((0)) FOR bestankari " +

"ALTER TABLE dbo.Tmp_sick_history_daftari ADD CONSTRAINT " +
"	DF_sick_history_daftari_mandeh DEFAULT ((0)) FOR mandeh " +

"IF EXISTS(SELECT * FROM dbo.sick_history_daftari) " +
"	 EXEC('INSERT INTO dbo.Tmp_sick_history_daftari (radif, ghabz_id, sick_id, sharh, date, bedehkari, bestankari, tashkhis, mandeh) " +
"		SELECT radif, ghabz_id, CONVERT(nvarchar(15), sick_id), sharh, date, bedehkari, bestankari, tashkhis, mandeh FROM dbo.sick_history_daftari WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.sick_history_daftari " +

"EXECUTE sp_rename N'dbo.Tmp_sick_history_daftari', N'sick_history_daftari', 'OBJECT'  " +

"ALTER TABLE dbo.sick_history_daftari ADD CONSTRAINT " +
"	PK_sick_history_daftari PRIMARY KEY CLUSTERED  " +
"	( " +
"	radif, " +
"	sick_id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.sick_history_daftari ADD CONSTRAINT " +
"	FK_sick_history_daftari_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_mos_list " +
"	( " +
"	code bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	home nvarchar(11) NULL, " +
"	mos_date nchar(10) NULL, " +
"	mos_name nvarchar(50) NULL, " +
"	mos_semat nvarchar(30) NULL " +
"	)  ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.mos_list) " +
"	 EXEC('INSERT INTO dbo.Tmp_mos_list (code, id, name, home, mos_date, mos_name, mos_semat) " +
"		SELECT code, CONVERT(nvarchar(15), id), name, home, mos_date, mos_name, mos_semat FROM dbo.mos_list WITH (HOLDLOCK TABLOCKX)') " +

"ALTER TABLE dbo.MAP_A " +
"	DROP CONSTRAINT FK_MAP_A_mos_list " +

"ALTER TABLE dbo.Map_BtoG " +
"	DROP CONSTRAINT FK_Map_BtoG_mos_list " +

"ALTER TABLE dbo.MAP_History " +
"	DROP CONSTRAINT FK_MAP_History_mos_list " +

"DROP TABLE dbo.mos_list " +

"EXECUTE sp_rename N'dbo.Tmp_mos_list', N'mos_list', 'OBJECT'  " +

"ALTER TABLE dbo.mos_list ADD CONSTRAINT " +
"	PK_mos_list PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.mos_list ADD CONSTRAINT " +
"	FK_mos_list_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.MAP_History ADD CONSTRAINT " +
"	FK_MAP_History_mos_list FOREIGN KEY " +
"	( " +
"	code " +
"	) REFERENCES dbo.mos_list " +
"	( " +
"	code " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.Map_BtoG ADD CONSTRAINT " +
"	FK_Map_BtoG_mos_list FOREIGN KEY " +
"	( " +
"	code " +
"	) REFERENCES dbo.mos_list " +
"	( " +
"	code " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.MAP_A ADD CONSTRAINT " +
"	FK_MAP_A_mos_list FOREIGN KEY " +
"	( " +
"	code " +
"	) REFERENCES dbo.mos_list " +
"	( " +
"	code " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_dastoor_pezeshk " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	doctor_name nvarchar(50) NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NOT NULL, " +
"	pre_text nvarchar(MAX) NULL, " +
"	azmayesh nvarchar(60) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.dastoor_pezeshk) " +
"	 EXEC('INSERT INTO dbo.Tmp_dastoor_pezeshk (code, sick_id, name, doctor_name, darman_date, date, pre_text, azmayesh) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, doctor_name, darman_date, date, pre_text, azmayesh FROM dbo.dastoor_pezeshk WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.dastoor_pezeshk " +

"EXECUTE sp_rename N'dbo.Tmp_dastoor_pezeshk', N'dastoor_pezeshk', 'OBJECT'  " +

"ALTER TABLE dbo.dastoor_pezeshk ADD CONSTRAINT " +
"	PK_dastoor_pezeshk PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.dastoor_pezeshk ADD CONSTRAINT " +
"	FK_dastoor_pezeshk_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_dastoor_pezeshk_real " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	doctor_name nvarchar(50) NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NOT NULL, " +
"	pre_text nvarchar(MAX) NULL, " +
"	azmayesh nvarchar(60) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.dastoor_pezeshk_real) " +
"	 EXEC('INSERT INTO dbo.Tmp_dastoor_pezeshk_real (code, sick_id, name, doctor_name, darman_date, date, pre_text, azmayesh) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, doctor_name, darman_date, date, pre_text, azmayesh FROM dbo.dastoor_pezeshk_real WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.dastoor_pezeshk_real " +

"EXECUTE sp_rename N'dbo.Tmp_dastoor_pezeshk_real', N'dastoor_pezeshk_real', 'OBJECT'  " +

"ALTER TABLE dbo.dastoor_pezeshk_real ADD CONSTRAINT " +
"	PK_dastoor_pezeshk_real PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.dastoor_pezeshk_real ADD CONSTRAINT " +
"	FK_dastoor_pezeshk_real_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_peygiri " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NULL, " +
"	peygiriNo bigint NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NULL, " +
"	comments nvarchar(MAX) NULL, " +
"	natijeh nvarchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.peygiri) " +
"	 EXEC('INSERT INTO dbo.Tmp_peygiri (code, sick_id, name, peygiriNo, darman_date, date, comments, natijeh) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, peygiriNo, darman_date, date, comments, natijeh FROM dbo.peygiri WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.peygiri " +

"EXECUTE sp_rename N'dbo.Tmp_peygiri', N'peygiri', 'OBJECT'  " +

"ALTER TABLE dbo.peygiri ADD CONSTRAINT " +
"	PK_peygiri PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.peygiri ADD CONSTRAINT " +
"	FK_peygiri_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_peygiri_real " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NULL, " +
"	peygiriNo bigint NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NULL, " +
"	comments nvarchar(MAX) NULL, " +
"	natijeh nvarchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.peygiri_real) " +
"	 EXEC('INSERT INTO dbo.Tmp_peygiri_real (code, sick_id, name, peygiriNo, darman_date, date, comments, natijeh) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, peygiriNo, darman_date, date, comments, natijeh FROM dbo.peygiri_real WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.peygiri_real " +

"EXECUTE sp_rename N'dbo.Tmp_peygiri_real', N'peygiri_real', 'OBJECT'  " +

"ALTER TABLE dbo.peygiri_real ADD CONSTRAINT " +
"	PK_peygiri_real PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.peygiri_real ADD CONSTRAINT " +
"	FK_peygiri_real_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_ravanshenas " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	doctor_name nvarchar(50) NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NOT NULL, " +
"	next_date nchar(10) NULL, " +
"	comments nvarchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.ravanshenas) " +
"	 EXEC('INSERT INTO dbo.Tmp_ravanshenas (code, sick_id, name, doctor_name, darman_date, date, next_date, comments) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, doctor_name, darman_date, date, next_date, comments FROM dbo.ravanshenas WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.ravanshenas " +

"EXECUTE sp_rename N'dbo.Tmp_ravanshenas', N'ravanshenas', 'OBJECT'  " +

"ALTER TABLE dbo.ravanshenas ADD CONSTRAINT " +
"	PK_ravanshenas PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.ravanshenas ADD CONSTRAINT " +
"	FK_ravanshenas_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_ravanshenas_real " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	doctor_name nvarchar(50) NULL, " +
"	darman_date nchar(10) NULL, " +
"	date nchar(10) NOT NULL, " +
"	next_date nchar(10) NULL, " +
"	comments nvarchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.ravanshenas_real) " +
"	 EXEC('INSERT INTO dbo.Tmp_ravanshenas_real (code, sick_id, name, doctor_name, darman_date, date, next_date, comments) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, doctor_name, darman_date, date, next_date, comments FROM dbo.ravanshenas_real WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.ravanshenas_real " +

"EXECUTE sp_rename N'dbo.Tmp_ravanshenas_real', N'ravanshenas_real', 'OBJECT'  " +

"ALTER TABLE dbo.ravanshenas_real ADD CONSTRAINT " +
"	PK_ravanshenas_real PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.ravanshenas_real ADD CONSTRAINT " +
"	FK_ravanshenas_real_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.ghabz " +
"	DROP CONSTRAINT DF_ghabz_mablagh " +

"ALTER TABLE dbo.ghabz " +
"	DROP CONSTRAINT DF_ghabz_paid " +

"CREATE TABLE dbo.Tmp_ghabz " +
"	( " +
"	ghabz_id nchar(6) NOT NULL, " +
"	id nvarchar(15) NULL, " +
"	name nvarchar(50) NULL, " +
"	mablagh bigint NOT NULL, " +
"	paid bigint NOT NULL, " +
"	sharh nvarchar(100) NULL, " +
"	date nchar(10) NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_ghabz ADD CONSTRAINT " +
"	DF_ghabz_mablagh DEFAULT ((0)) FOR mablagh " +

"ALTER TABLE dbo.Tmp_ghabz ADD CONSTRAINT " +
"	DF_ghabz_paid DEFAULT ((0)) FOR paid " +

"IF EXISTS(SELECT * FROM dbo.ghabz) " +
"	 EXEC('INSERT INTO dbo.Tmp_ghabz (ghabz_id, id, name, mablagh, paid, sharh, date) " +
"		SELECT ghabz_id, CONVERT(nvarchar(15), id), name, mablagh, paid, sharh, date FROM dbo.ghabz WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.ghabz " +

"EXECUTE sp_rename N'dbo.Tmp_ghabz', N'ghabz', 'OBJECT'  " +

"ALTER TABLE dbo.ghabz ADD CONSTRAINT " +
"	PK_ghabz PRIMARY KEY CLUSTERED  " +
"	( " +
"	ghabz_id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.ghabz ADD CONSTRAINT " +
"	FK_ghabz_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.tahvil " +
"	DROP CONSTRAINT DF_tahvil_m5 " +

"ALTER TABLE dbo.tahvil " +
"	DROP CONSTRAINT DF_tahvil_m20 " +

"CREATE TABLE dbo.Tmp_tahvil " +
"	( " +
"	code bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	ravesh_tark nvarchar(50) NULL, " +
"	tahvil_day nvarchar(50) NULL, " +
"	tahvil_date nchar(10) NOT NULL, " +
"	date nchar(10) NOT NULL, " +
"	daru_name nvarchar(50) NOT NULL, " +
"	tedad float(53) NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_tahvil ADD CONSTRAINT " +
"	DF_tahvil_m5 DEFAULT ((0)) FOR daru_name " +

"ALTER TABLE dbo.Tmp_tahvil ADD CONSTRAINT " +
"	DF_tahvil_m20 DEFAULT ((0)) FOR tedad " +

"IF EXISTS(SELECT * FROM dbo.tahvil) " +
"	 EXEC('INSERT INTO dbo.Tmp_tahvil (code, id, name, ravesh_tark, tahvil_day, tahvil_date, date, daru_name, tedad) " +
"		SELECT code, CONVERT(nvarchar(15), id), name, ravesh_tark, tahvil_day, tahvil_date, date, daru_name, tedad FROM dbo.tahvil WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.tahvil " +

"EXECUTE sp_rename N'dbo.Tmp_tahvil', N'tahvil', 'OBJECT'  " +

"ALTER TABLE dbo.tahvil ADD CONSTRAINT " +
"	PK_tahvil_1 PRIMARY KEY CLUSTERED  " +
"	( " +
"	code, " +
"	id, " +
"	date, " +
"	daru_name " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.tahvil ADD CONSTRAINT " +
"	FK_tahvil_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.tahvil_koli " +
"	DROP CONSTRAINT DF_tahvil_koli_code " +

"ALTER TABLE dbo.tahvil_koli " +
"	DROP CONSTRAINT DF_tahvil_koli_daru_name " +

"ALTER TABLE dbo.tahvil_koli " +
"	DROP CONSTRAINT DF_tahvil_koli_tedad " +

"CREATE TABLE dbo.Tmp_tahvil_koli " +
"	( " +
"	code bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	ravesh_tark nvarchar(50) NULL, " +
"	tahvil_day nvarchar(50) NULL, " +
"	tahvil_date nchar(10) NULL, " +
"	from_date nchar(10) NOT NULL, " +
"	to_date nchar(10) NOT NULL, " +
"	daru_name nvarchar(50) NOT NULL, " +
"	tedad float(53) NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_tahvil_koli ADD CONSTRAINT " +
"	DF_tahvil_koli_code DEFAULT ((0)) FOR code " +

"ALTER TABLE dbo.Tmp_tahvil_koli ADD CONSTRAINT " +
"	DF_tahvil_koli_daru_name DEFAULT ((0)) FOR daru_name " +

"ALTER TABLE dbo.Tmp_tahvil_koli ADD CONSTRAINT " +
"	DF_tahvil_koli_tedad DEFAULT ((0)) FOR tedad " +

"IF EXISTS(SELECT * FROM dbo.tahvil_koli) " +
"	 EXEC('INSERT INTO dbo.Tmp_tahvil_koli (code, id, name, ravesh_tark, tahvil_day, tahvil_date, from_date, to_date, daru_name, tedad) " +
"		SELECT code, CONVERT(nvarchar(15), id), name, ravesh_tark, tahvil_day, tahvil_date, from_date, to_date, daru_name, tedad FROM dbo.tahvil_koli WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.tahvil_koli " +

"EXECUTE sp_rename N'dbo.Tmp_tahvil_koli', N'tahvil_koli', 'OBJECT'  " +

"ALTER TABLE dbo.tahvil_koli ADD CONSTRAINT " +
"	PK_tahvil_koli PRIMARY KEY CLUSTERED  " +
"	( " +
"	code, " +
"	daru_name " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.tahvil_koli ADD CONSTRAINT " +
"	FK_tahvil_koli_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.tajviz " +
"	DROP CONSTRAINT DF_tajviz_daru_name " +

"ALTER TABLE dbo.tajviz " +
"	DROP CONSTRAINT DF_tajviz_tedad " +

"CREATE TABLE dbo.Tmp_tajviz " +
"	( " +
"	code bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	ravesh_tark nvarchar(50) NULL, " +
"	tajviz_day nvarchar(50) NULL, " +
"	tajviz_date nchar(10) NOT NULL, " +
"	date nchar(10) NOT NULL, " +
"	daru_name nvarchar(50) NOT NULL, " +
"	tedad float(53) NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_tajviz ADD CONSTRAINT " +
"	DF_tajviz_daru_name DEFAULT ((0)) FOR daru_name " +

"ALTER TABLE dbo.Tmp_tajviz ADD CONSTRAINT " +
"	DF_tajviz_tedad DEFAULT ((0)) FOR tedad " +

"IF EXISTS(SELECT * FROM dbo.tajviz) " +
"	 EXEC('INSERT INTO dbo.Tmp_tajviz (code, id, name, ravesh_tark, tajviz_day, tajviz_date, date, daru_name, tedad) " +
"		SELECT code, CONVERT(nvarchar(15), id), name, ravesh_tark, tajviz_day, tajviz_date, date, daru_name, tedad FROM dbo.tajviz WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.tajviz " +

"EXECUTE sp_rename N'dbo.Tmp_tajviz', N'tajviz', 'OBJECT'  " +

"ALTER TABLE dbo.tajviz ADD CONSTRAINT " +
"	PK_tajviz PRIMARY KEY CLUSTERED  " +
"	( " +
"	code, " +
"	id, " +
"	date, " +
"	daru_name " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.tajviz ADD CONSTRAINT " +
"	FK_tajviz_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.tajviz_koli " +
"	DROP CONSTRAINT DF_tajviz_koli_code " +

"ALTER TABLE dbo.tajviz_koli " +
"	DROP CONSTRAINT DF_tajviz_koli_daru_name " +

"ALTER TABLE dbo.tajviz_koli " +
"	DROP CONSTRAINT DF_tajviz_koli_tedad " +

"CREATE TABLE dbo.Tmp_tajviz_koli " +
"	( " +
"	code bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	ravesh_tark nvarchar(50) NULL, " +
"	tajviz_day nvarchar(50) NULL, " +
"	tajviz_date nchar(10) NULL, " +
"	from_date nchar(10) NOT NULL, " +
"	to_date nchar(10) NOT NULL, " +
"	daru_name nvarchar(50) NOT NULL, " +
"	tedad float(53) NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_tajviz_koli ADD CONSTRAINT " +
"	DF_tajviz_koli_code DEFAULT ((0)) FOR code " +

"ALTER TABLE dbo.Tmp_tajviz_koli ADD CONSTRAINT " +
"	DF_tajviz_koli_daru_name DEFAULT ((0)) FOR daru_name " +

"ALTER TABLE dbo.Tmp_tajviz_koli ADD CONSTRAINT " +
"	DF_tajviz_koli_tedad DEFAULT ((0)) FOR tedad " +

"IF EXISTS(SELECT * FROM dbo.tajviz_koli) " +
"	 EXEC('INSERT INTO dbo.Tmp_tajviz_koli (code, id, name, ravesh_tark, tajviz_day, tajviz_date, from_date, to_date, daru_name, tedad) " +
"		SELECT code, CONVERT(nvarchar(15), id), name, ravesh_tark, tajviz_day, tajviz_date, from_date, to_date, daru_name, tedad FROM dbo.tajviz_koli WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.tajviz_koli " +

"EXECUTE sp_rename N'dbo.Tmp_tajviz_koli', N'tajviz_koli', 'OBJECT'  " +

"ALTER TABLE dbo.tajviz_koli ADD CONSTRAINT " +
"	PK_tajviz_koli PRIMARY KEY CLUSTERED  " +
"	( " +
"	code, " +
"	daru_name " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.tajviz_koli ADD CONSTRAINT " +
"	FK_tajviz_koli_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT DF_sick_history_radif " +

"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT DF_sick_history_bedehkari " +

"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT DF_sick_history_bestankari " +

"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT DF_sick_history_mandeh " +

"CREATE TABLE dbo.Tmp_sick_history " +
"	( " +
"	radif bigint NOT NULL, " +
"	ghabz_id nchar(6) NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	sharh nvarchar(100) NULL, " +
"	date nchar(10) NULL, " +
"	bedehkari bigint NULL, " +
"	bestankari bigint NULL, " +
"	tashkhis nvarchar(8) NULL, " +
"	mandeh bigint NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_sick_history ADD CONSTRAINT " +
"	DF_sick_history_radif DEFAULT ((0)) FOR radif " +

"ALTER TABLE dbo.Tmp_sick_history ADD CONSTRAINT " +
"	DF_sick_history_bedehkari DEFAULT ((0)) FOR bedehkari " +

"ALTER TABLE dbo.Tmp_sick_history ADD CONSTRAINT " +
"	DF_sick_history_bestankari DEFAULT ((0)) FOR bestankari " +

"ALTER TABLE dbo.Tmp_sick_history ADD CONSTRAINT " +
"	DF_sick_history_mandeh DEFAULT ((0)) FOR mandeh " +

"IF EXISTS(SELECT * FROM dbo.sick_history) " +
"	 EXEC('INSERT INTO dbo.Tmp_sick_history (radif, ghabz_id, sick_id, sharh, date, bedehkari, bestankari, tashkhis, mandeh) " +
"		SELECT radif, ghabz_id, CONVERT(nvarchar(15), sick_id), sharh, date, bedehkari, bestankari, tashkhis, mandeh FROM dbo.sick_history WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.sick_history " +

"EXECUTE sp_rename N'dbo.Tmp_sick_history', N'sick_history', 'OBJECT'  " +

"ALTER TABLE dbo.sick_history ADD CONSTRAINT " +
"	PK_sick_history PRIMARY KEY CLUSTERED  " +
"	( " +
"	radif, " +
"	sick_id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.sick_history ADD CONSTRAINT " +
"	FK_sick_history_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q1a " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q1b " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q2a " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q2b " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q2c " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q2d " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q3a " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q3b " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q3c " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q3d " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q4a " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q4b " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q4c " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q4d " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_q4e " +

"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT DF_assessment_sum_all " +

"CREATE TABLE dbo.Tmp_assessment " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	ass_date nchar(10) NOT NULL, " +
"	q1a tinyint NOT NULL, " +
"	q1b tinyint NOT NULL, " +
"	q2a tinyint NOT NULL, " +
"	q2b tinyint NOT NULL, " +
"	q2c tinyint NOT NULL, " +
"	q2d tinyint NOT NULL, " +
"	q3a tinyint NOT NULL, " +
"	q3b tinyint NOT NULL, " +
"	q3c tinyint NOT NULL, " +
"	q3d tinyint NOT NULL, " +
"	q4a tinyint NOT NULL, " +
"	q4b tinyint NOT NULL, " +
"	q4c tinyint NOT NULL, " +
"	q4d tinyint NOT NULL, " +
"	q4e tinyint NOT NULL, " +
"	sum_all tinyint NOT NULL " +
"	)  ON [PRIMARY] " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q1a DEFAULT ((0)) FOR q1a " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q1b DEFAULT ((0)) FOR q1b " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q2a DEFAULT ((0)) FOR q2a " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q2b DEFAULT ((0)) FOR q2b " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q2c DEFAULT ((0)) FOR q2c " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q2d DEFAULT ((0)) FOR q2d " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q3a DEFAULT ((0)) FOR q3a " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q3b DEFAULT ((0)) FOR q3b " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q3c DEFAULT ((0)) FOR q3c " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q3d DEFAULT ((0)) FOR q3d " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q4a DEFAULT ((0)) FOR q4a " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q4b DEFAULT ((0)) FOR q4b " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q4c DEFAULT ((0)) FOR q4c " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q4d DEFAULT ((0)) FOR q4d " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_q4e DEFAULT ((0)) FOR q4e " +

"ALTER TABLE dbo.Tmp_assessment ADD CONSTRAINT " +
"	DF_assessment_sum_all DEFAULT ((0)) FOR sum_all " +

"IF EXISTS(SELECT * FROM dbo.assessment) " +
"	 EXEC('INSERT INTO dbo.Tmp_assessment (code, sick_id, name, ass_date, q1a, q1b, q2a, q2b, q2c, q2d, q3a, q3b, q3c, q3d, q4a, q4b, q4c, q4d, q4e, sum_all) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, ass_date, q1a, q1b, q2a, q2b, q2c, q2d, q3a, q3b, q3c, q3d, q4a, q4b, q4c, q4d, q4e, sum_all FROM dbo.assessment WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.assessment " +

"EXECUTE sp_rename N'dbo.Tmp_assessment', N'assessment', 'OBJECT'  " +

"ALTER TABLE dbo.assessment ADD CONSTRAINT " +
"	PK_assessment PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.assessment ADD CONSTRAINT " +
"	FK_assessment_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_azmayesh " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	darman_date nchar(10) NULL, " +
"	type nvarchar(50) NOT NULL, " +
"	date nchar(10) NOT NULL, " +
"	result nchar(4) NOT NULL, " +
"	comments varchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.azmayesh) " +
"	 EXEC('INSERT INTO dbo.Tmp_azmayesh (code, sick_id, name, darman_date, type, date, result, comments) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, darman_date, type, date, result, comments FROM dbo.azmayesh WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.azmayesh " +

"EXECUTE sp_rename N'dbo.Tmp_azmayesh', N'azmayesh', 'OBJECT'  " +

"ALTER TABLE dbo.azmayesh ADD CONSTRAINT " +
"	PK_azmayesh PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.azmayesh ADD CONSTRAINT " +
"	FK_azmayesh_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_azmayesh_real " +
"	( " +
"	code bigint NOT NULL, " +
"	sick_id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	darman_date nchar(10) NULL, " +
"	type nvarchar(50) NOT NULL, " +
"	date nchar(10) NOT NULL, " +
"	result nchar(4) NOT NULL, " +
"	comments varchar(MAX) NULL " +
"	)  ON [PRIMARY] " +
"	 TEXTIMAGE_ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.azmayesh_real) " +
"	 EXEC('INSERT INTO dbo.Tmp_azmayesh_real (code, sick_id, name, darman_date, type, date, result, comments) " +
"		SELECT code, CONVERT(nvarchar(15), sick_id), name, darman_date, type, date, result, comments FROM dbo.azmayesh_real WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.azmayesh_real " +

"EXECUTE sp_rename N'dbo.Tmp_azmayesh_real', N'azmayesh_real', 'OBJECT'  " +

"ALTER TABLE dbo.azmayesh_real ADD CONSTRAINT " +
"	PK_azmayesh_real PRIMARY KEY CLUSTERED  " +
"	( " +
"	code " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.azmayesh_real ADD CONSTRAINT " +
"	FK_azmayesh_real_Sicks FOREIGN KEY " +
"	( " +
"	sick_id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT " +
"BEGIN TRANSACTION " +

"CREATE TABLE dbo.Tmp_black_list " +
"	( " +
"	radif bigint NOT NULL, " +
"	id nvarchar(15) NOT NULL, " +
"	name nvarchar(50) NULL, " +
"	sharh nvarchar(100) NULL " +
"	)  ON [PRIMARY] " +

"IF EXISTS(SELECT * FROM dbo.black_list) " +
"	 EXEC('INSERT INTO dbo.Tmp_black_list (radif, id, name, sharh) " +
"		SELECT radif, CONVERT(nvarchar(15), id), name, sharh FROM dbo.black_list WITH (HOLDLOCK TABLOCKX)') " +

"DROP TABLE dbo.black_list " +

"EXECUTE sp_rename N'dbo.Tmp_black_list', N'black_list', 'OBJECT'  " +

"ALTER TABLE dbo.black_list ADD CONSTRAINT " +
"	PK_black_list PRIMARY KEY CLUSTERED  " +
"	( " +
"	radif " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +

"ALTER TABLE dbo.black_list ADD CONSTRAINT " +
"	FK_black_list_Sicks FOREIGN KEY " +
"	( " +
"	id " +
"	) REFERENCES dbo.Sicks " +
"	( " +
"	id " +
"	) ON UPDATE  CASCADE  " +
"	 ON DELETE  CASCADE  " +
"	 " +

"COMMIT ");


                //update kardan bimaaraane ghabli ke 4 harfi boodand be 15 harfi
                Scks.Search("update sicks set id='00000000000'+id");
                //update kardan zir jadaavele osaahebe - chon kelide khaareji nadashtan bayad dasti 15 harfi mishodan
                Scks.Search(
                    "BEGIN TRANSACTION " +
   "SET QUOTED_IDENTIFIER ON " +
   "SET ARITHABORT ON " +
   "SET NUMERIC_ROUNDABORT OFF " +
   "SET CONCAT_NULL_YIELDS_NULL ON " +
   "SET ANSI_NULLS ON " +
   "SET ANSI_PADDING ON " +
   "SET ANSI_WARNINGS ON " +
   "COMMIT " +
   "BEGIN TRANSACTION " +

   "ALTER TABLE dbo.MAP_A " +
   "	DROP CONSTRAINT FK_MAP_A_mos_list " +

   "COMMIT " +
   "BEGIN TRANSACTION " +

   "ALTER TABLE dbo.MAP_A " +
   "	DROP CONSTRAINT DF_MAP_A_rooz " +

   "ALTER TABLE dbo.MAP_A " +
   "	DROP CONSTRAINT DF_MAP_A_mizan " +

   "CREATE TABLE dbo.Tmp_MAP_A " +
   "	( " +
   "	code bigint NOT NULL, " +
   "	id nvarchar(15) NOT NULL, " +
   "	masrafi_type nvarchar(50) NULL, " +
   "	rooz nvarchar(3) NULL, " +
   "	mizan nvarchar(5) NULL, " +
   "	tarigheh nvarchar(50) NULL " +
   "	)  ON [PRIMARY] " +

   "ALTER TABLE dbo.Tmp_MAP_A ADD CONSTRAINT " +
   "	DF_MAP_A_rooz DEFAULT ((0)) FOR rooz " +

   "ALTER TABLE dbo.Tmp_MAP_A ADD CONSTRAINT " +
   "	DF_MAP_A_mizan DEFAULT ((0)) FOR mizan " +

   "IF EXISTS(SELECT * FROM dbo.MAP_A) " +
   "	 EXEC('INSERT INTO dbo.Tmp_MAP_A (code, id, masrafi_type, rooz, mizan, tarigheh) " +
   "		SELECT code, CONVERT(nvarchar(15), id), masrafi_type, rooz, mizan, tarigheh FROM dbo.MAP_A WITH (HOLDLOCK TABLOCKX)') " +

   "DROP TABLE dbo.MAP_A " +

   "EXECUTE sp_rename N'dbo.Tmp_MAP_A', N'MAP_A', 'OBJECT'  " +

   "ALTER TABLE dbo.MAP_A ADD CONSTRAINT " +
   "	FK_MAP_A_mos_list FOREIGN KEY " +
   "	( " +
   "	code " +
   "	) REFERENCES dbo.mos_list " +
   "	( " +
   "	code " +
   "	) ON UPDATE  CASCADE  " +
   "	 ON DELETE  CASCADE  " +
   "	 " +

   "COMMIT "
   );

                Scks.Search(
                    "BEGIN TRANSACTION " +
   "SET QUOTED_IDENTIFIER ON " +
   "SET ARITHABORT ON " +
   "SET NUMERIC_ROUNDABORT OFF " +
   "SET CONCAT_NULL_YIELDS_NULL ON " +
   "SET ANSI_NULLS ON " +
   "SET ANSI_PADDING ON " +
   "SET ANSI_WARNINGS ON " +
   "COMMIT " +
   "BEGIN TRANSACTION " +

   "ALTER TABLE dbo.Map_BtoG " +
   "	DROP CONSTRAINT FK_Map_BtoG_mos_list " +

   "COMMIT " +
   "BEGIN TRANSACTION " +

   "CREATE TABLE dbo.Tmp_Map_BtoG " +
   "	( " +
   "	code bigint NOT NULL, " +
   "	id nvarchar(15) NOT NULL, " +
   "	qoverdose nvarchar(3) NULL, " +
   "	qb1 nvarchar(3) NULL, " +
   "	qb2_1 nvarchar(3) NULL, " +
   "	qb2_2 nvarchar(3) NULL, " +
   "	qb2_3 nvarchar(3) NULL, " +
   "	qb2_4 nvarchar(3) NULL, " +
   "	qb3 nvarchar(20) NULL, " +
   "	qb4 nvarchar(100) NULL, " +
   "	qb5 nvarchar(100) NULL, " +
   "	qb6 nvarchar(50) NULL, " +
   "	qb7 nvarchar(50) NULL, " +
   "	qb8 nvarchar(50) NULL, " +
   "	qb9_1 nvarchar(3) NULL, " +
   "	qb9_2 nvarchar(10) NULL, " +
   "	qb9_3 nvarchar(100) NULL, " +
   "	qc1 nvarchar(3) NULL, " +
   "	qc2 nvarchar(3) NULL, " +
   "	qc3 nvarchar(3) NULL, " +
   "	qc4 nvarchar(3) NULL, " +
   "	qc5 nvarchar(3) NULL, " +
   "	qd1 nvarchar(15) NULL, " +
   "	qd2 nvarchar(15) NULL, " +
   "	qd3 nvarchar(15) NULL, " +
   "	qd4 nvarchar(15) NULL, " +
   "	qd5 nvarchar(15) NULL, " +
   "	qd6 nvarchar(15) NULL, " +
   "   qd7 nvarchar(15) NULL, " +
   "	qd8 nvarchar(15) NULL, " +
   "	qd9 nvarchar(15) NULL, " +
   "	qd10 nvarchar(15) NULL, " +
   "	qd11 nvarchar(15) NULL, " +
   "	qd12 nvarchar(15) NULL, " +
   "	qd13 nvarchar(15) NULL, " +
   "	qd14 nvarchar(15) NULL, " +
   "	qd15 nvarchar(15) NULL, " +
   "	qd16 nvarchar(15) NULL, " +
   "	qd17 nvarchar(15) NULL, " +
   "	qd18 nvarchar(15) NULL, " +
   "	qd19 nvarchar(15) NULL, " +
   "	qd20 nvarchar(15) NULL, " +
   "	qe1 nvarchar(3) NULL, " +
   "	qe2 nvarchar(3) NULL, " +
   "	qe3 nvarchar(3) NULL, " +
   "	qe4 nvarchar(3) NULL, " +
   "	qe5 nvarchar(3) NULL, " +
   "	qe6 nvarchar(3) NULL, " +
   "	qe7 nvarchar(3) NULL, " +
   "	qf1 nchar(4) NULL, " +
   "	qf2 nvarchar(3) NULL, " +
   "	qf3 nvarchar(60) NULL, " +
   "   qf4 nvarchar(60) NULL, " +
   "	qf5 nvarchar(50) NULL, " +
   "	qf6 nvarchar(15) NULL, " +
   "	qg1 nvarchar(3) NULL, " +
   "	qg2 nvarchar(3) NULL, " +
   "	qg3 nvarchar(3) NULL " +
   "	)  ON [PRIMARY] " +

   "IF EXISTS(SELECT * FROM dbo.Map_BtoG) " +
   "	 EXEC('INSERT INTO dbo.Tmp_Map_BtoG (code, id, qoverdose, qb1, qb2_1, qb2_2, qb2_3, qb2_4, qb3, qb4, qb5, qb6, qb7, qb8, qb9_1, qb9_2, qb9_3, qc1, qc2, qc3, qc4, qc5, qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10, qd11, qd12, qd13, qd14, qd15, qd16, qd17, qd18, qd19, qd20, qe1, qe2, qe3, qe4, qe5, qe6, qe7, qf1, qf2, qf3, qf4, qf5, qf6, qg1, qg2, qg3) " +
   "		SELECT code, CONVERT(nvarchar(15), id), qoverdose, qb1, qb2_1, qb2_2, qb2_3, qb2_4, qb3, qb4, qb5, qb6, qb7, qb8, qb9_1, qb9_2, qb9_3, qc1, qc2, qc3, qc4, qc5, qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10, qd11, qd12, qd13, qd14, qd15, qd16, qd17, qd18, qd19, qd20, qe1, qe2, qe3, qe4, qe5, qe6, qe7, qf1, qf2, qf3, qf4, qf5, qf6, qg1, qg2, qg3 FROM dbo.Map_BtoG WITH (HOLDLOCK TABLOCKX)') " +

   "DROP TABLE dbo.Map_BtoG " +

   "EXECUTE sp_rename N'dbo.Tmp_Map_BtoG', N'Map_BtoG', 'OBJECT'  " +
   " " +
   "ALTER TABLE dbo.Map_BtoG ADD CONSTRAINT " +
   "	FK_Map_BtoG_mos_list FOREIGN KEY " +
   "	( " +
   "	code " +
   "	) REFERENCES dbo.mos_list " +
   "	( " +
   "	code " +
   "	) ON UPDATE  CASCADE  " +
   "	 ON DELETE  CASCADE  " +
   "	 " +

   "COMMIT"
                    );

                Scks.Search("BEGIN TRANSACTION " +
   "SET QUOTED_IDENTIFIER ON " +
   "SET ARITHABORT ON " +
   "SET NUMERIC_ROUNDABORT OFF " +
   "SET CONCAT_NULL_YIELDS_NULL ON " +
   "SET ANSI_NULLS ON " +
   "SET ANSI_PADDING ON " +
   "SET ANSI_WARNINGS ON " +
   "COMMIT " +
   "BEGIN TRANSACTION " +

   "ALTER TABLE dbo.MAP_History " +
   "	DROP CONSTRAINT FK_MAP_History_mos_list " +

   "COMMIT " +
   "BEGIN TRANSACTION " +

   "CREATE TABLE dbo.Tmp_MAP_History " +
   "	( " +
   "	code bigint NOT NULL, " +
   "	id nvarchar(15) NOT NULL, " +
   "	masrafi_type nvarchar(50) NULL, " +
   "	start_age nvarchar(3) NULL, " +
   "	rooz nvarchar(3) NULL, " +
   "	masraf_life nvarchar(6) NULL, " +
   "	tarigheh nvarchar(30) NULL " +
   "	)  ON [PRIMARY] " +

   "IF EXISTS(SELECT * FROM dbo.MAP_History) " +
   "	 EXEC('INSERT INTO dbo.Tmp_MAP_History (code, id, masrafi_type, start_age, rooz, masraf_life, tarigheh) " +
   "		SELECT code, CONVERT(nvarchar(15), id), masrafi_type, start_age, rooz, masraf_life, tarigheh FROM dbo.MAP_History WITH (HOLDLOCK TABLOCKX)') " +

   "DROP TABLE dbo.MAP_History " +

   "EXECUTE sp_rename N'dbo.Tmp_MAP_History', N'MAP_History', 'OBJECT'  " +

   "ALTER TABLE dbo.MAP_History ADD CONSTRAINT " +
   "	FK_MAP_History_mos_list FOREIGN KEY " +
   "	( " +
   "	code " +
   "	) REFERENCES dbo.mos_list " +
   "	( " +
   "	code " +
   "	) ON UPDATE  CASCADE  " +
   "	 ON DELETE  CASCADE  " +
   "	 " +
   "COMMIT");

                //update kardane shomareh parvandehaaye zir jadaavele mosahebe ba jadvale mosaahebe - bug dar version haaye ghabl
                Scks.Search("update map_a  set map_a.id=mos_list.id from map_a, mos_list where (map_a.code=mos_list.code) " +
                            "update Map_BtoG  set Map_BtoG.id=mos_list.id from Map_BtoG, mos_list where (Map_BtoG.code=mos_list.code) " +
                            "update MAP_History  set MAP_History.id=mos_list.id from MAP_History, mos_list where (MAP_History.code=mos_list.code)");
                
                MessageBox.Show("عملیات با موفقیت انجام شد");
            
 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FormtoUpdateCurrenctSicksIDs f = new FormtoUpdateCurrenctSicksIDs();
            f.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Sicks si = new Sicks();

            string sql = "BEGIN TRANSACTION "+
"SET QUOTED_IDENTIFIER ON "+
"SET ARITHABORT ON "+
"SET NUMERIC_ROUNDABORT OFF "+
"SET CONCAT_NULL_YIELDS_NULL ON "+
"SET ANSI_NULLS ON "+
"SET ANSI_PADDING ON "+
"SET ANSI_WARNINGS ON "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Customers_bedehkar "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_sex "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_home "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_roozaneh "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_monthFee "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_hesab "+
"   "+
"ALTER TABLE dbo.Sicks "+
"	DROP CONSTRAINT DF_Sicks_status "+
"   "+
"CREATE TABLE dbo.Tmp_Sicks "+
"	( "+
"	id nvarchar(15) NOT NULL, "+
"	darman_date nchar(10) NULL, "+
"	payan_date nchar(10) NULL, "+
"	name nvarchar(50) NOT NULL, "+
"	father_name nvarchar(30) NULL, "+
"	b_date nchar(10) NOT NULL, "+
"	city nvarchar(20) NOT NULL, "+
"	id_no nvarchar(10) NULL, "+
"	sex nchar(4) NULL, "+
"	home nvarchar(11) NULL, "+
"	mobile nvarchar(11) NULL, "+
"	masrafi_type nvarchar(150) NOT NULL, "+
"	ravesh_tark nvarchar(50) NOT NULL, "+
"	address nvarchar(100) NULL, "+
"	roozaneh bigint NULL, "+
"	monthFee bigint NOT NULL, "+
"	hesab bigint NOT NULL, "+
"	status nvarchar(8) NOT NULL "+
"	)  ON [PRIMARY] "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Customers_bedehkar DEFAULT ((0)) FOR b_date "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_sex DEFAULT (N'مذکر') FOR sex "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_home DEFAULT (N'مذکر') FOR home "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_roozaneh DEFAULT ((0)) FOR roozaneh "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_monthFee DEFAULT ((0)) FOR monthFee "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_hesab DEFAULT ((0)) FOR hesab "+
"   "+
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT "+
"	DF_Sicks_status DEFAULT (N'بدهکار') FOR status "+
"   "+
"IF EXISTS(SELECT * FROM dbo.Sicks) "+
"	 EXEC('INSERT INTO dbo.Tmp_Sicks (id, darman_date, payan_date, name, father_name, b_date, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status) "+
"		SELECT id, darman_date, payan_date, name, father_name, CONVERT(nchar(10), age), city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status FROM dbo.Sicks WITH (HOLDLOCK TABLOCKX)') "+
"   "+
"ALTER TABLE dbo.ghabz_daftari "+
"	DROP CONSTRAINT FK_ghabz_daftari_Sicks "+
"   "+
"ALTER TABLE dbo.sick_history_daftari "+
"	DROP CONSTRAINT FK_sick_history_daftari_Sicks "+
"   "+
"ALTER TABLE dbo.mos_list "+
"	DROP CONSTRAINT FK_mos_list_Sicks "+
"   "+
"ALTER TABLE dbo.dastoor_pezeshk "+
"	DROP CONSTRAINT FK_dastoor_pezeshk_Sicks "+
"   "+
"ALTER TABLE dbo.dastoor_pezeshk_real "+
"	DROP CONSTRAINT FK_dastoor_pezeshk_real_Sicks "+
"   "+
"ALTER TABLE dbo.peygiri "+
"	DROP CONSTRAINT FK_peygiri_Sicks "+
"   "+
"ALTER TABLE dbo.peygiri_real "+
"	DROP CONSTRAINT FK_peygiri_real_Sicks "+
"   "+
"ALTER TABLE dbo.ravanshenas "+
"	DROP CONSTRAINT FK_ravanshenas_Sicks "+
"   "+
"ALTER TABLE dbo.ravanshenas_real "+
"	DROP CONSTRAINT FK_ravanshenas_real_Sicks "+
"   "+
"ALTER TABLE dbo.ghabz "+
"	DROP CONSTRAINT FK_ghabz_Sicks "+
"   "+
"ALTER TABLE dbo.tahvil "+
"	DROP CONSTRAINT FK_tahvil_Sicks "+
"   "+
"ALTER TABLE dbo.tahvil_koli "+
"	DROP CONSTRAINT FK_tahvil_koli_Sicks "+
"   "+
"ALTER TABLE dbo.tajviz "+
"	DROP CONSTRAINT FK_tajviz_Sicks "+
"   "+
"ALTER TABLE dbo.tajviz_koli "+
"	DROP CONSTRAINT FK_tajviz_koli_Sicks "+
"   "+
"ALTER TABLE dbo.sick_history "+
"	DROP CONSTRAINT FK_sick_history_Sicks "+
"   "+
"ALTER TABLE dbo.assessment "+
"	DROP CONSTRAINT FK_assessment_Sicks "+
"   "+
"ALTER TABLE dbo.azmayesh "+
"	DROP CONSTRAINT FK_azmayesh_Sicks "+
"   "+
"ALTER TABLE dbo.azmayesh_real "+
"	DROP CONSTRAINT FK_azmayesh_real_Sicks "+
"   "+
"ALTER TABLE dbo.black_list "+
"	DROP CONSTRAINT FK_black_list_Sicks "+
"   "+
"DROP TABLE dbo.Sicks "+
"   "+
"EXECUTE sp_rename N'dbo.Tmp_Sicks', N'Sicks', 'OBJECT'  "+
"   "+
"ALTER TABLE dbo.Sicks ADD CONSTRAINT "+
"	PK_Customers PRIMARY KEY CLUSTERED  "+
"	( "+
"	id "+
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "+
" "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.black_list ADD CONSTRAINT "+
"	FK_black_list_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.azmayesh_real ADD CONSTRAINT "+
"	FK_azmayesh_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.azmayesh ADD CONSTRAINT "+
"	FK_azmayesh_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.assessment ADD CONSTRAINT "+
"	FK_assessment_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.sick_history ADD CONSTRAINT "+
"	FK_sick_history_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.tajviz_koli ADD CONSTRAINT "+
"	FK_tajviz_koli_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.tajviz ADD CONSTRAINT "+
"	FK_tajviz_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.tahvil_koli ADD CONSTRAINT "+
"	FK_tahvil_koli_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.tahvil ADD CONSTRAINT "+
"	FK_tahvil_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.ghabz ADD CONSTRAINT "+
"	FK_ghabz_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.ravanshenas_real ADD CONSTRAINT "+
"	FK_ravanshenas_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.ravanshenas ADD CONSTRAINT "+
"	FK_ravanshenas_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.peygiri_real ADD CONSTRAINT "+
"	FK_peygiri_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.peygiri ADD CONSTRAINT "+
"	FK_peygiri_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.dastoor_pezeshk_real ADD CONSTRAINT "+
"	FK_dastoor_pezeshk_real_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.dastoor_pezeshk ADD CONSTRAINT "+
"	FK_dastoor_pezeshk_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.mos_list ADD CONSTRAINT "+
"	FK_mos_list_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.sick_history_daftari ADD CONSTRAINT "+
"	FK_sick_history_daftari_Sicks FOREIGN KEY "+
"	( "+
"	sick_id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT "+
"BEGIN TRANSACTION "+
"   "+
"ALTER TABLE dbo.ghabz_daftari ADD CONSTRAINT "+
"	FK_ghabz_daftari_Sicks FOREIGN KEY "+
"	( "+
"	id "+
"	) REFERENCES dbo.Sicks "+
"	( "+
"	id "+
"	) ON UPDATE  CASCADE  "+
"	 ON DELETE  CASCADE  "+
"	 "+
"   "+
"COMMIT ";
            si.Search(sql);
            MessageBox.Show("عملیات با موفقیت انجام شد");
        }
    }
}