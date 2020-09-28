/*
   Thursday, December 27, 201212:04:29 PM
   User: 
   Server: PARSA-PC\SQLEXPRESS
   Database: ARC
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.anbar ADD
	fee bigint NOT NULL CONSTRAINT DF_anbar_fee DEFAULT 0
GO
COMMIT

USE [ARC]
GO
/****** Object:  Table [dbo].[ghabz_daftari]    Script Date: 12/25/2012 08:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ghabz_daftari](
	[ghabz_id] [nchar](6) NOT NULL,
	[id] [nchar](4) NULL,
	[name] [nvarchar](50) NULL,
	[mablagh] [bigint] NOT NULL CONSTRAINT [DF_ghabz_daftari_mablagh]  DEFAULT ((0)),
	[paid] [bigint] NOT NULL CONSTRAINT [DF_ghabz_daftari_paid]  DEFAULT ((0)),
	[sharh] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
 CONSTRAINT [PK_ghabz_daftari] PRIMARY KEY CLUSTERED 
(
	[ghabz_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ghabz_daftari]  WITH CHECK ADD  CONSTRAINT [FK_ghabz_daftari_Sicks] FOREIGN KEY([id])
REFERENCES [dbo].[Sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ghabz_daftari]



USE [ARC]
GO
/****** Object:  Table [dbo].[sick_history_daftari]    Script Date: 12/25/2012 09:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sick_history_daftari](
	[radif] [bigint] NOT NULL CONSTRAINT [DF_sick_history_daftari_radif]  DEFAULT ((0)),
	[ghabz_id] [nchar](6) NULL,
	[sick_id] [nchar](4) NOT NULL,
	[sharh] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
	[bedehkari] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_bedehkari]  DEFAULT ((0)),
	[bestankari] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_bestankari]  DEFAULT ((0)),
	[tashkhis] [nvarchar](8) NULL,
	[mandeh] [bigint] NULL CONSTRAINT [DF_sick_history_daftari_mandeh]  DEFAULT ((0)),
 CONSTRAINT [PK_sick_history_daftari] PRIMARY KEY CLUSTERED 
(
	[radif] ASC,
	[sick_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[sick_history_daftari]  WITH CHECK ADD  CONSTRAINT [FK_sick_history_daftari_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[Sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sick_history_daftari] CHECK CONSTRAINT [FK_sick_history_daftari_Sicks]



/*
   Monday, December 24, 20129:00:48 AM
   User: 
   Server: PARSA-PC\SQLEXPRESS
   Database: ARC
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Darmangah ADD
	Gen_Pass nvarchar(8) NOT NULL CONSTRAINT DF_Darmangah_Gen_Pass DEFAULT 12345678
GO
COMMIT


/*
   Monday, December 24, 201210:10:22 AM
   User: 
   Server: PARSA-PC\SQLEXPRESS
   Database: ARC
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Gen_Settings ADD
	DaftariPayType nvarchar(6) NOT NULL CONSTRAINT DF_Gen_Settings_DaftariPayType DEFAULT N'„«Â«‰Â',
	BazrasKey nvarchar(50) NOT NULL CONSTRAINT DF_Gen_Settings_BazrasKey DEFAULT N'F12'
GO
COMMIT



/*
   Monday, December 24, 20128:34:15 PM
   User: 
   Server: PARSA-PC\SQLEXPRESS
   Database: ARC
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Sicks
	DROP CONSTRAINT DF_Customers_bedehkar
GO
ALTER TABLE dbo.Sicks
	DROP CONSTRAINT DF_Sicks_sex
GO
ALTER TABLE dbo.Sicks
	DROP CONSTRAINT DF_Sicks_home
GO
ALTER TABLE dbo.Sicks
	DROP CONSTRAINT DF_Sicks_hesab
GO
ALTER TABLE dbo.Sicks
	DROP CONSTRAINT DF_Sicks_status
GO
CREATE TABLE dbo.Tmp_Sicks
	(
	id nchar(4) NOT NULL,
	darman_date nchar(10) NULL,
	payan_date nchar(10) NULL,
	name nvarchar(50) NOT NULL,
	father_name nvarchar(30) NULL,
	age nvarchar(2) NOT NULL,
	city nvarchar(20) NOT NULL,
	id_no nvarchar(10) NULL,
	sex nchar(4) NULL,
	home nvarchar(11) NULL,
	mobile nvarchar(11) NULL,
	masrafi_type nvarchar(150) NOT NULL,
	ravesh_tark nvarchar(50) NOT NULL,
	address nvarchar(100) NULL,
	roozaneh bigint NULL,
	monthFee bigint NULL,
	hesab bigint NOT NULL,
	status nvarchar(8) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Customers_bedehkar DEFAULT ((0)) FOR age
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_sex DEFAULT (N'„–ò—') FOR sex
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_home DEFAULT (N'„–ò—') FOR home
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_roozaneh DEFAULT 0 FOR roozaneh
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_monthFee DEFAULT 0 FOR monthFee
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_hesab DEFAULT ((0)) FOR hesab
GO
ALTER TABLE dbo.Tmp_Sicks ADD CONSTRAINT
	DF_Sicks_status DEFAULT (N'»œÂò«—') FOR status
GO
IF EXISTS(SELECT * FROM dbo.Sicks)
	 EXEC('INSERT INTO dbo.Tmp_Sicks (id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, hesab, status)
		SELECT id, darman_date, payan_date, name, father_name, age, city, id_no, sex, home, mobile, masrafi_type, ravesh_tark, address, roozaneh, hesab, status FROM dbo.Sicks WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.dastoor_pezeshk_real
	DROP CONSTRAINT FK_dastoor_pezeshk_real_Sicks
GO
ALTER TABLE dbo.dastoor_pezeshk
	DROP CONSTRAINT FK_dastoor_pezeshk_Sicks
GO
ALTER TABLE dbo.azmayesh_real
	DROP CONSTRAINT FK_azmayesh_real_Sicks
GO
ALTER TABLE dbo.azmayesh
	DROP CONSTRAINT FK_azmayesh_Sicks
GO
ALTER TABLE dbo.mos_list
	DROP CONSTRAINT FK_mos_list_Sicks
GO
ALTER TABLE dbo.black_list
	DROP CONSTRAINT FK_black_list_Sicks
GO
ALTER TABLE dbo.assessment
	DROP CONSTRAINT FK_assessment_Sicks
GO
ALTER TABLE dbo.ghabz
	DROP CONSTRAINT FK_ghabz_Sicks
GO
ALTER TABLE dbo.tajviz_koli
	DROP CONSTRAINT FK_tajviz_koli_Sicks
GO
ALTER TABLE dbo.tajviz
	DROP CONSTRAINT FK_tajviz_Sicks
GO
ALTER TABLE dbo.tahvil_koli
	DROP CONSTRAINT FK_tahvil_koli_Sicks
GO
ALTER TABLE dbo.tahvil
	DROP CONSTRAINT FK_tahvil_Sicks
GO
ALTER TABLE dbo.sick_history
	DROP CONSTRAINT FK_sick_history_Sicks
GO
ALTER TABLE dbo.ravanshenas_real
	DROP CONSTRAINT FK_ravanshenas_real_Sicks
GO
ALTER TABLE dbo.ravanshenas
	DROP CONSTRAINT FK_ravanshenas_Sicks
GO
ALTER TABLE dbo.peygiri_real
	DROP CONSTRAINT FK_peygiri_real_Sicks
GO
ALTER TABLE dbo.peygiri
	DROP CONSTRAINT FK_peygiri_Sicks
GO
DROP TABLE dbo.Sicks
GO
EXECUTE sp_rename N'dbo.Tmp_Sicks', N'Sicks', 'OBJECT' 
GO
ALTER TABLE dbo.Sicks ADD CONSTRAINT
	PK_Customers PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.peygiri ADD CONSTRAINT
	FK_peygiri_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.peygiri_real ADD CONSTRAINT
	FK_peygiri_real_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ravanshenas ADD CONSTRAINT
	FK_ravanshenas_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ravanshenas_real ADD CONSTRAINT
	FK_ravanshenas_real_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.sick_history ADD CONSTRAINT
	FK_sick_history_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tahvil ADD CONSTRAINT
	FK_tahvil_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tahvil_koli ADD CONSTRAINT
	FK_tahvil_koli_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tajviz ADD CONSTRAINT
	FK_tajviz_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tajviz_koli ADD CONSTRAINT
	FK_tajviz_koli_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ghabz ADD CONSTRAINT
	FK_ghabz_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.assessment ADD CONSTRAINT
	FK_assessment_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.black_list ADD CONSTRAINT
	FK_black_list_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.mos_list ADD CONSTRAINT
	FK_mos_list_Sicks FOREIGN KEY
	(
	id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.azmayesh ADD CONSTRAINT
	FK_azmayesh_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.azmayesh_real ADD CONSTRAINT
	FK_azmayesh_real_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.dastoor_pezeshk ADD CONSTRAINT
	FK_dastoor_pezeshk_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.dastoor_pezeshk_real ADD CONSTRAINT
	FK_dastoor_pezeshk_real_Sicks FOREIGN KEY
	(
	sick_id
	) REFERENCES dbo.Sicks
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
