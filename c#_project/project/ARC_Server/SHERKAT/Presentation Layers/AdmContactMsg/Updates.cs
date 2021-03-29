using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers.AdmContactMsg
{
    static class Updates
    {
        public static void ChangeAgeToB_date()
        {
            Sicks si = new Sicks();

            string sql = "BEGIN TRANSACTION " +
"SET QUOTED_IDENTIFIER ON " +
"SET ARITHABORT ON " +
"SET NUMERIC_ROUNDABORT OFF " +
"SET CONCAT_NULL_YIELDS_NULL ON " +
"SET ANSI_NULLS ON " +
"SET ANSI_PADDING ON " +
"SET ANSI_WARNINGS ON " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Customers_bedehkar " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_sex " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_home " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_roozaneh " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_monthFee " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_hesab " +
"   " +
"ALTER TABLE dbo.Sicks " +
"	DROP CONSTRAINT DF_Sicks_status " +
"   " +
"CREATE TABLE dbo.Tmp_Sicks " +
"	( " +
"	id nvarchar(15) NOT NULL, " +
"	darman_date nchar(10) NULL, " +
"	payan_date nchar(10) NULL, " +
"	name nvarchar(50) NOT NULL, " +
"	father_name nvarchar(30) NULL, " +
"	b_date nchar(10) NOT NULL, " +
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
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Customers_bedehkar DEFAULT ((0)) FOR b_date " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_sex DEFAULT (N'مذکر') FOR sex " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_home DEFAULT (N'مذکر') FOR home " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_roozaneh DEFAULT ((0)) FOR roozaneh " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_monthFee DEFAULT ((0)) FOR monthFee " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_hesab DEFAULT ((0)) FOR hesab " +
"   " +
"ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT " +
"	DF_Sicks_status DEFAULT (N'بدهکار') FOR status " +
"   " +
"IF EXISTS(SELECT * FROM dbo.Sicks) " +
"	 EXEC('INSERT INTO dbo.Tmp_Sicks (id, darman_date, payan_date, name, father_name, b_date, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status) " +
"		SELECT id, darman_date, payan_date, name, father_name, CONVERT(nchar(10), age), city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, monthFee, hesab, status FROM dbo.Sicks WITH (HOLDLOCK TABLOCKX)') " +
"   " +
"ALTER TABLE dbo.ghabz_daftari " +
"	DROP CONSTRAINT FK_ghabz_daftari_Sicks " +
"   " +
"ALTER TABLE dbo.sick_history_daftari " +
"	DROP CONSTRAINT FK_sick_history_daftari_Sicks " +
"   " +
"ALTER TABLE dbo.mos_list " +
"	DROP CONSTRAINT FK_mos_list_Sicks " +
"   " +
"ALTER TABLE dbo.dastoor_pezeshk " +
"	DROP CONSTRAINT FK_dastoor_pezeshk_Sicks " +
"   " +
"ALTER TABLE dbo.dastoor_pezeshk_real " +
"	DROP CONSTRAINT FK_dastoor_pezeshk_real_Sicks " +
"   " +
"ALTER TABLE dbo.peygiri " +
"	DROP CONSTRAINT FK_peygiri_Sicks " +
"   " +
"ALTER TABLE dbo.peygiri_real " +
"	DROP CONSTRAINT FK_peygiri_real_Sicks " +
"   " +
"ALTER TABLE dbo.ravanshenas " +
"	DROP CONSTRAINT FK_ravanshenas_Sicks " +
"   " +
"ALTER TABLE dbo.ravanshenas_real " +
"	DROP CONSTRAINT FK_ravanshenas_real_Sicks " +
"   " +
"ALTER TABLE dbo.ghabz " +
"	DROP CONSTRAINT FK_ghabz_Sicks " +
"   " +
"ALTER TABLE dbo.tahvil " +
"	DROP CONSTRAINT FK_tahvil_Sicks " +
"   " +
"ALTER TABLE dbo.tahvil_koli " +
"	DROP CONSTRAINT FK_tahvil_koli_Sicks " +
"   " +
"ALTER TABLE dbo.tajviz " +
"	DROP CONSTRAINT FK_tajviz_Sicks " +
"   " +
"ALTER TABLE dbo.tajviz_koli " +
"	DROP CONSTRAINT FK_tajviz_koli_Sicks " +
"   " +
"ALTER TABLE dbo.sick_history " +
"	DROP CONSTRAINT FK_sick_history_Sicks " +
"   " +
"ALTER TABLE dbo.assessment " +
"	DROP CONSTRAINT FK_assessment_Sicks " +
"   " +
"ALTER TABLE dbo.azmayesh " +
"	DROP CONSTRAINT FK_azmayesh_Sicks " +
"   " +
"ALTER TABLE dbo.azmayesh_real " +
"	DROP CONSTRAINT FK_azmayesh_real_Sicks " +
"   " +
"ALTER TABLE dbo.black_list " +
"	DROP CONSTRAINT FK_black_list_Sicks " +
"   " +
"DROP TABLE dbo.Sicks " +
"   " +
"EXECUTE sp_rename N'dbo.Tmp_Sicks', N'Sicks', 'OBJECT'  " +
"   " +
"ALTER TABLE dbo.Sicks ADD CONSTRAINT " +
"	PK_Customers PRIMARY KEY CLUSTERED  " +
"	( " +
"	id " +
"	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " +
" " +
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT " +
"BEGIN TRANSACTION " +
"   " +
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
"   " +
"COMMIT ";
            si.Search(sql);
            MessageBox.Show("عملیات با موفقیت انجام شد");
        }

        public static void normalizePayanDates()
        {
            new Sicks().Search("UPDATE [ARC].[dbo].[Sicks] SET payan_date='' WHERE (payan_date='13  /  /')");
            MessageBox.Show("عملیات با موفقیت انجام شد");

        }
    }
    
}
