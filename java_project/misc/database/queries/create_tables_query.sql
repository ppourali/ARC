USE [master]
GO
/****** Object:  Database [ARC_DB]    Script Date: 2020-10-21 9:23:43 AM ******/
CREATE DATABASE [ARC_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARC_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ARC_DB.mdf' , SIZE = 176128KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ARC_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ARC_DB_log.ldf' , SIZE = 568896KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ARC_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARC_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARC_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARC_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARC_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARC_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARC_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARC_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ARC_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARC_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARC_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARC_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARC_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARC_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARC_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARC_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARC_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ARC_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARC_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARC_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARC_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARC_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARC_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARC_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARC_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ARC_DB] SET  MULTI_USER 
GO
ALTER DATABASE [ARC_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARC_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARC_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARC_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ARC_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ARC_DB] SET QUERY_STORE = OFF
GO
USE [ARC_DB]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[username] [nvarchar](10) NOT NULL,
	[pass] [nvarchar](8) NULL,
	[fname] [nvarchar](20) NULL,
	[lname] [nvarchar](30) NULL,
	[tel] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
 CONSTRAINT [PK_acc] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[action_logs]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[action_logs](
	[id] [bigint] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[username] [nvarchar](10) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[time] [timestamp] NOT NULL,
 CONSTRAINT [PK_action_logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[assessment]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[assessment](
	[code] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[assessment_date] [nchar](10) NOT NULL,
	[q1a] [tinyint] NOT NULL,
	[q1b] [tinyint] NOT NULL,
	[q2a] [tinyint] NOT NULL,
	[q2b] [tinyint] NOT NULL,
	[q2c] [tinyint] NOT NULL,
	[q2d] [tinyint] NOT NULL,
	[q3a] [tinyint] NOT NULL,
	[q3b] [tinyint] NOT NULL,
	[q3c] [tinyint] NOT NULL,
	[q3d] [tinyint] NOT NULL,
	[q4a] [tinyint] NOT NULL,
	[q4b] [tinyint] NOT NULL,
	[q4c] [tinyint] NOT NULL,
	[q4d] [tinyint] NOT NULL,
	[q4e] [tinyint] NOT NULL,
	[sum_all] [tinyint] NOT NULL,
 CONSTRAINT [PK_assessment] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[black_list]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[black_list](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NULL,
	[description] [nvarchar](100) NULL,
 CONSTRAINT [PK_black_list] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clinic_info]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clinic_info](
	[name] [nvarchar](30) NOT NULL,
	[tel] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[photo] [image] NULL,
	[gen_pass] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Sherkat2] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact](
	[id] [nchar](4) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
 CONSTRAINT [PK_contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact_depot]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact_depot](
	[contact_id] [nchar](4) NOT NULL,
	[contact_name] [nvarchar](100) NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[remained] [float] NOT NULL,
	[unit] [nvarchar](15) NULL,
 CONSTRAINT [PK_contact_anbar] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC,
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[depot]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depot](
	[drug_name] [nvarchar](50) NOT NULL,
	[remained] [float] NOT NULL,
	[unit] [nvarchar](15) NULL,
	[cost] [bigint] NOT NULL,
 CONSTRAINT [PK_anbar] PRIMARY KEY CLUSTERED 
(
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[depot_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depot_real](
	[drug_name] [nvarchar](50) NOT NULL,
	[remained] [float] NOT NULL,
	[unit] [nvarchar](15) NULL,
	[fee] [bigint] NOT NULL,
 CONSTRAINT [PK_tajviz_anbar] PRIMARY KEY CLUSTERED 
(
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[depot_real_history]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depot_real_history](
	[id] [bigint] NOT NULL,
	[contact_id] [nchar](4) NOT NULL,
	[contact_name] [nvarchar](100) NULL,
	[date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
	[comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_tajviz_anbar_history] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dispensed_items]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispensed_items](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_method] [nvarchar](50) NULL,
	[dispense_day] [nvarchar](50) NULL,
	[dispense_date] [nchar](10) NULL,
	[from_date] [nchar](10) NOT NULL,
	[to_date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
 CONSTRAINT [PK_tahvil_koli] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dispensed_items_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispensed_items_real](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_method] [nvarchar](50) NULL,
	[dispense_day] [nvarchar](50) NULL,
	[dispense_date] [nchar](10) NULL,
	[from_date] [nchar](10) NOT NULL,
	[to_date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
 CONSTRAINT [PK_tajviz_koli] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dispenses_daily]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispenses_daily](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_method] [nvarchar](50) NULL,
	[dispense_day] [nvarchar](50) NULL,
	[dispense_date] [nchar](10) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
 CONSTRAINT [PK_tahvil_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sick_id] ASC,
	[date] ASC,
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dispenses_daily_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispenses_daily_real](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_method] [nvarchar](50) NULL,
	[dispense_day] [nvarchar](50) NULL,
	[dispense_date] [nchar](10) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
 CONSTRAINT [PK_tajviz] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sick_id] ASC,
	[date] ASC,
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expense_types]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expense_types](
	[id] [bigint] NOT NULL,
	[cost_type] [nvarchar](250) NULL,
 CONSTRAINT [PK_hazineh_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expenses]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expenses](
	[id] [bigint] NOT NULL,
	[type] [nvarchar](250) NULL,
	[date] [nchar](10) NULL,
	[cost] [bigint] NULL,
	[comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_hazineh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_settings]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_settings](
	[pay_type] [nvarchar](6) NOT NULL,
	[promotion] [nvarchar](3) NOT NULL,
	[pay_type_real] [nvarchar](6) NOT NULL,
	[investigator_key] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[interviews]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[interviews](
	[code] [bigint] NOT NULL,
	[id] [nvarchar](15) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[home] [nvarchar](11) NULL,
	[mos_date] [nchar](10) NULL,
	[mos_name] [nvarchar](50) NULL,
	[mos_semat] [nvarchar](30) NULL,
 CONSTRAINT [PK_mos_list] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAP_A]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAP_A](
	[code] [bigint] NOT NULL,
	[id] [nvarchar](15) NOT NULL,
	[masrafi_type] [nvarchar](50) NULL,
	[rooz] [nvarchar](3) NULL,
	[mizan] [nvarchar](5) NULL,
	[tarigheh] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Map_BtoG]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Map_BtoG](
	[code] [bigint] NOT NULL,
	[id] [nvarchar](15) NOT NULL,
	[qoverdose] [nvarchar](3) NULL,
	[qb1] [nvarchar](3) NULL,
	[qb2_1] [nvarchar](3) NULL,
	[qb2_2] [nvarchar](3) NULL,
	[qb2_3] [nvarchar](3) NULL,
	[qb2_4] [nvarchar](3) NULL,
	[qb3] [nvarchar](20) NULL,
	[qb4] [nvarchar](100) NULL,
	[qb5] [nvarchar](100) NULL,
	[qb6] [nvarchar](50) NULL,
	[qb7] [nvarchar](50) NULL,
	[qb8] [nvarchar](50) NULL,
	[qb9_1] [nvarchar](3) NULL,
	[qb9_2] [nvarchar](10) NULL,
	[qb9_3] [nvarchar](100) NULL,
	[qc1] [nvarchar](3) NULL,
	[qc2] [nvarchar](3) NULL,
	[qc3] [nvarchar](3) NULL,
	[qc4] [nvarchar](3) NULL,
	[qc5] [nvarchar](3) NULL,
	[qd1] [nvarchar](15) NULL,
	[qd2] [nvarchar](15) NULL,
	[qd3] [nvarchar](15) NULL,
	[qd4] [nvarchar](15) NULL,
	[qd5] [nvarchar](15) NULL,
	[qd6] [nvarchar](15) NULL,
	[qd7] [nvarchar](15) NULL,
	[qd8] [nvarchar](15) NULL,
	[qd9] [nvarchar](15) NULL,
	[qd10] [nvarchar](15) NULL,
	[qd11] [nvarchar](15) NULL,
	[qd12] [nvarchar](15) NULL,
	[qd13] [nvarchar](15) NULL,
	[qd14] [nvarchar](15) NULL,
	[qd15] [nvarchar](15) NULL,
	[qd16] [nvarchar](15) NULL,
	[qd17] [nvarchar](15) NULL,
	[qd18] [nvarchar](15) NULL,
	[qd19] [nvarchar](15) NULL,
	[qd20] [nvarchar](15) NULL,
	[qe1] [nvarchar](3) NULL,
	[qe2] [nvarchar](3) NULL,
	[qe3] [nvarchar](3) NULL,
	[qe4] [nvarchar](3) NULL,
	[qe5] [nvarchar](3) NULL,
	[qe6] [nvarchar](3) NULL,
	[qe7] [nvarchar](3) NULL,
	[qf1] [nchar](4) NULL,
	[qf2] [nvarchar](3) NULL,
	[qf3] [nvarchar](60) NULL,
	[qf4] [nvarchar](60) NULL,
	[qf5] [nvarchar](50) NULL,
	[qf6] [nvarchar](15) NULL,
	[qg1] [nvarchar](3) NULL,
	[qg2] [nvarchar](3) NULL,
	[qg3] [nvarchar](3) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAP_History]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAP_History](
	[code] [bigint] NOT NULL,
	[id] [nvarchar](15) NOT NULL,
	[masrafi_type] [nvarchar](50) NULL,
	[start_age] [nvarchar](3) NULL,
	[rooz] [nvarchar](3) NULL,
	[masraf_life] [nvarchar](6) NULL,
	[tarigheh] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nurse_depot]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nurse_depot](
	[drug_name] [nvarchar](50) NOT NULL,
	[remained] [float] NOT NULL,
	[unit] [nvarchar](15) NULL,
 CONSTRAINT [PK_parastar_anbar] PRIMARY KEY CLUSTERED 
(
	[drug_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [nchar](6) NOT NULL,
	[sick_id] [nvarchar](15) NULL,
	[sick_name] [nvarchar](50) NULL,
	[fee] [bigint] NOT NULL,
	[paid] [bigint] NOT NULL,
	[description] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
 CONSTRAINT [PK_ghabz] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments_real](
	[id] [nchar](6) NOT NULL,
	[sick_id] [nvarchar](15) NULL,
	[sick_name] [nvarchar](50) NULL,
	[fee] [bigint] NOT NULL,
	[paid] [bigint] NOT NULL,
	[description] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
 CONSTRAINT [PK_ghabz_daftari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prescriptions]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prescriptions](
	[code] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[doctor_name] [nvarchar](50) NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NOT NULL,
	[prescription_text] [nvarchar](max) NULL,
	[test] [nvarchar](60) NULL,
 CONSTRAINT [PK_dastoor_pezeshk] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prescriptions_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prescriptions_real](
	[code] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[doctor_name] [nvarchar](50) NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NOT NULL,
	[prescription_text] [nvarchar](max) NULL,
	[test] [nvarchar](60) NULL,
 CONSTRAINT [PK_dastoor_pezeshk_real] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotions]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotions](
	[id] [bigint] NOT NULL,
	[start_range] [smallint] NOT NULL,
	[end_range] [smallint] NOT NULL,
	[promotion_percent] [smallint] NOT NULL,
 CONSTRAINT [PK_takhfif] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[psychologist]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[psychologist](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[doctor_name] [nvarchar](50) NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NOT NULL,
	[next_date] [nchar](10) NULL,
	[comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_ravanshenas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[psychologist_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[psychologist_real](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[doctor_name] [nvarchar](50) NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NOT NULL,
	[next_date] [nchar](10) NULL,
	[comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_ravanshenas_real] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[receipts]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receipts](
	[id] [bigint] NOT NULL,
	[receipt_id] [nvarchar](15) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
	[fee] [bigint] NULL,
	[total_fee] [bigint] NULL,
	[sell_price] [bigint] NULL,
	[comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_factors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[receipts_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receipts_real](
	[id] [bigint] NOT NULL,
	[receipt_id] [nvarchar](15) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[count] [float] NOT NULL,
	[fee] [bigint] NULL,
	[total_fee] [bigint] NULL,
	[sell_price] [bigint] NULL,
	[comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_tajviz_factors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[records_snapshots]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[records_snapshots](
	[id] [int] NOT NULL,
	[date] [nchar](10) NOT NULL,
	[reg_date] [nchar](10) NOT NULL,
	[drug_name] [nvarchar](50) NOT NULL,
	[total_used_real] [nvarchar](15) NOT NULL,
	[empty_case] [nvarchar](15) NOT NULL,
	[last_total_on_date] [nvarchar](15) NOT NULL,
	[current_total] [nvarchar](15) NOT NULL,
	[total_used] [nvarchar](15) NOT NULL,
	[last_total_on_date_real] [nvarchar](15) NOT NULL,
	[current_total_all] [nvarchar](15) NOT NULL,
	[current_total_real] [nvarchar](15) NOT NULL,
	[current_total_nurse] [nvarchar](15) NOT NULL,
	[differences] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_records_snapshots] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sample]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sample](
	[context] [nvarchar](max) NOT NULL,
	[type] [nvarchar](20) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sick_history]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sick_history](
	[id] [bigint] NOT NULL,
	[receipt_id] [nchar](6) NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[description] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
	[debit] [bigint] NULL,
	[credit] [bigint] NULL,
	[account_state] [nvarchar](8) NULL,
	[amount] [bigint] NULL,
 CONSTRAINT [PK_sick_history] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sick_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sick_history_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sick_history_real](
	[id] [bigint] NOT NULL,
	[receipt_id] [nchar](6) NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[description] [nvarchar](100) NULL,
	[date] [nchar](10) NULL,
	[debit] [bigint] NULL,
	[credit] [bigint] NULL,
	[account_state] [nvarchar](8) NULL,
	[amount] [bigint] NULL,
 CONSTRAINT [PK_sick_history_daftari] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sick_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sicks]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sicks](
	[id] [nvarchar](15) NOT NULL,
	[treatment_date] [nchar](10) NULL,
	[end_date] [nchar](10) NULL,
	[name] [nvarchar](50) NOT NULL,
	[father_name] [nvarchar](30) NULL,
	[birth_date] [nchar](10) NOT NULL,
	[city] [nvarchar](20) NOT NULL,
	[id_no] [nvarchar](10) NULL,
	[sex] [nchar](4) NULL,
	[home] [nvarchar](11) NULL,
	[mobile] [nvarchar](11) NULL,
	[usage_type] [nvarchar](150) NOT NULL,
	[treatment_method] [nvarchar](50) NOT NULL,
	[address] [nvarchar](100) NULL,
	[daily] [bigint] NULL,
	[monthly_fee] [bigint] NOT NULL,
	[amount] [bigint] NOT NULL,
	[acount_state] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[code] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_date] [nchar](10) NULL,
	[type] [nvarchar](50) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[result] [nchar](4) NOT NULL,
	[comments] [varchar](max) NULL,
 CONSTRAINT [PK_azmayesh] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_real](
	[code] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NOT NULL,
	[treatment_date] [nchar](10) NULL,
	[type] [nvarchar](50) NOT NULL,
	[date] [nchar](10) NOT NULL,
	[result] [nchar](4) NOT NULL,
	[comments] [varchar](max) NULL,
 CONSTRAINT [PK_azmayesh_real] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trackings]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trackings](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NULL,
	[tracking_no] [bigint] NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NULL,
	[comments] [nvarchar](max) NULL,
	[result] [nvarchar](max) NULL,
 CONSTRAINT [PK_peygiri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trackings_real]    Script Date: 2020-10-21 9:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trackings_real](
	[id] [bigint] NOT NULL,
	[sick_id] [nvarchar](15) NOT NULL,
	[sick_name] [nvarchar](50) NULL,
	[tracking_no] [bigint] NULL,
	[treatment_date] [nchar](10) NULL,
	[date] [nchar](10) NULL,
	[comments] [nvarchar](max) NULL,
	[result] [nvarchar](max) NULL,
 CONSTRAINT [PK_peygiri_real] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q1a]  DEFAULT ((0)) FOR [q1a]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q1b]  DEFAULT ((0)) FOR [q1b]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q2a]  DEFAULT ((0)) FOR [q2a]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q2b]  DEFAULT ((0)) FOR [q2b]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q2c]  DEFAULT ((0)) FOR [q2c]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q2d]  DEFAULT ((0)) FOR [q2d]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q3a]  DEFAULT ((0)) FOR [q3a]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q3b]  DEFAULT ((0)) FOR [q3b]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q3c]  DEFAULT ((0)) FOR [q3c]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q3d]  DEFAULT ((0)) FOR [q3d]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q4a]  DEFAULT ((0)) FOR [q4a]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q4b]  DEFAULT ((0)) FOR [q4b]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q4c]  DEFAULT ((0)) FOR [q4c]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q4d]  DEFAULT ((0)) FOR [q4d]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_q4e]  DEFAULT ((0)) FOR [q4e]
GO
ALTER TABLE [dbo].[assessment] ADD  CONSTRAINT [DF_assessment_sum_all]  DEFAULT ((0)) FOR [sum_all]
GO
ALTER TABLE [dbo].[clinic_info] ADD  CONSTRAINT [DF_Darmangah_Gen_Pass]  DEFAULT ((12345678)) FOR [gen_pass]
GO
ALTER TABLE [dbo].[contact_depot] ADD  CONSTRAINT [DF_contact_anbar_mandeh]  DEFAULT ((0)) FOR [remained]
GO
ALTER TABLE [dbo].[depot] ADD  CONSTRAINT [DF_anbar_mandeh]  DEFAULT ((0)) FOR [remained]
GO
ALTER TABLE [dbo].[depot] ADD  CONSTRAINT [DF_anbar_fee]  DEFAULT ((0)) FOR [cost]
GO
ALTER TABLE [dbo].[depot_real] ADD  CONSTRAINT [DF_tajviz_anbar_mandeh]  DEFAULT ((0)) FOR [remained]
GO
ALTER TABLE [dbo].[depot_real] ADD  CONSTRAINT [DF_tajviz_anbar_fee]  DEFAULT ((0)) FOR [fee]
GO
ALTER TABLE [dbo].[depot_real_history] ADD  CONSTRAINT [DF_tajviz_anbar_history_contactid]  DEFAULT ((0)) FOR [contact_id]
GO
ALTER TABLE [dbo].[depot_real_history] ADD  CONSTRAINT [DF_tajviz_anbar_history_contactname]  DEFAULT (N'پرستار') FOR [contact_name]
GO
ALTER TABLE [dbo].[dispensed_items] ADD  CONSTRAINT [DF_tahvil_koli_code]  DEFAULT ((0)) FOR [id]
GO
ALTER TABLE [dbo].[dispensed_items] ADD  CONSTRAINT [DF_tahvil_koli_daru_name]  DEFAULT ((0)) FOR [drug_name]
GO
ALTER TABLE [dbo].[dispensed_items] ADD  CONSTRAINT [DF_tahvil_koli_tedad]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[dispensed_items_real] ADD  CONSTRAINT [DF_tajviz_koli_code]  DEFAULT ((0)) FOR [id]
GO
ALTER TABLE [dbo].[dispensed_items_real] ADD  CONSTRAINT [DF_tajviz_koli_daru_name]  DEFAULT ((0)) FOR [drug_name]
GO
ALTER TABLE [dbo].[dispensed_items_real] ADD  CONSTRAINT [DF_tajviz_koli_tedad]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[dispenses_daily] ADD  CONSTRAINT [DF_tahvil_m5]  DEFAULT ((0)) FOR [drug_name]
GO
ALTER TABLE [dbo].[dispenses_daily] ADD  CONSTRAINT [DF_tahvil_m20]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[dispenses_daily_real] ADD  CONSTRAINT [DF_tajviz_daru_name]  DEFAULT ((0)) FOR [drug_name]
GO
ALTER TABLE [dbo].[dispenses_daily_real] ADD  CONSTRAINT [DF_tajviz_tedad]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[general_settings] ADD  CONSTRAINT [DF_Gen_Settings_PayType]  DEFAULT (N'روزانه') FOR [pay_type]
GO
ALTER TABLE [dbo].[general_settings] ADD  CONSTRAINT [DF_Gen_Settings_Takhfif_Inc]  DEFAULT (N'بلی') FOR [promotion]
GO
ALTER TABLE [dbo].[general_settings] ADD  CONSTRAINT [DF_Gen_Settings_DaftariPayType]  DEFAULT (N'ماهانه') FOR [pay_type_real]
GO
ALTER TABLE [dbo].[general_settings] ADD  CONSTRAINT [DF_Gen_Settings_BazrasKey]  DEFAULT (N'F12') FOR [investigator_key]
GO
ALTER TABLE [dbo].[MAP_A] ADD  CONSTRAINT [DF_MAP_A_rooz]  DEFAULT ((0)) FOR [rooz]
GO
ALTER TABLE [dbo].[MAP_A] ADD  CONSTRAINT [DF_MAP_A_mizan]  DEFAULT ((0)) FOR [mizan]
GO
ALTER TABLE [dbo].[nurse_depot] ADD  CONSTRAINT [DF_parastar_anbar_mandeh]  DEFAULT ((0)) FOR [remained]
GO
ALTER TABLE [dbo].[payments] ADD  CONSTRAINT [DF_ghabz_mablagh]  DEFAULT ((0)) FOR [fee]
GO
ALTER TABLE [dbo].[payments] ADD  CONSTRAINT [DF_ghabz_paid]  DEFAULT ((0)) FOR [paid]
GO
ALTER TABLE [dbo].[payments_real] ADD  CONSTRAINT [DF_ghabz_daftari_mablagh]  DEFAULT ((0)) FOR [fee]
GO
ALTER TABLE [dbo].[payments_real] ADD  CONSTRAINT [DF_ghabz_daftari_paid]  DEFAULT ((0)) FOR [paid]
GO
ALTER TABLE [dbo].[promotions] ADD  CONSTRAINT [DF_takhfif_start_range]  DEFAULT ((0)) FOR [start_range]
GO
ALTER TABLE [dbo].[promotions] ADD  CONSTRAINT [DF_takhfif_end_range]  DEFAULT ((0)) FOR [end_range]
GO
ALTER TABLE [dbo].[promotions] ADD  CONSTRAINT [DF_takhfif_takhfif]  DEFAULT ((0)) FOR [promotion_percent]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_kol_masrafi_daftar]  DEFAULT ((0)) FOR [total_used_real]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_pookeh]  DEFAULT ((0)) FOR [empty_case]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_last_tedad_on_date_daftar]  DEFAULT ((0)) FOR [last_total_on_date]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_nowtedad_daftar]  DEFAULT ((0)) FOR [current_total]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_kol_masrafi_sandogh]  DEFAULT ((0)) FOR [total_used]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_last_tedad_on_date_sandogh]  DEFAULT ((0)) FOR [last_total_on_date_real]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_nowtedad_kol]  DEFAULT ((0)) FOR [current_total_all]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_nowtedad_sandogh]  DEFAULT ((0)) FOR [current_total_real]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_nowtedad_parastar]  DEFAULT ((0)) FOR [current_total_nurse]
GO
ALTER TABLE [dbo].[records_snapshots] ADD  CONSTRAINT [DF_amar_records_difference]  DEFAULT ((0)) FOR [differences]
GO
ALTER TABLE [dbo].[sick_history] ADD  CONSTRAINT [DF_sick_history_radif]  DEFAULT ((0)) FOR [id]
GO
ALTER TABLE [dbo].[sick_history] ADD  CONSTRAINT [DF_sick_history_bedehkari]  DEFAULT ((0)) FOR [debit]
GO
ALTER TABLE [dbo].[sick_history] ADD  CONSTRAINT [DF_sick_history_bestankari]  DEFAULT ((0)) FOR [credit]
GO
ALTER TABLE [dbo].[sick_history] ADD  CONSTRAINT [DF_sick_history_mandeh]  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[sick_history_real] ADD  CONSTRAINT [DF_sick_history_daftari_radif]  DEFAULT ((0)) FOR [id]
GO
ALTER TABLE [dbo].[sick_history_real] ADD  CONSTRAINT [DF_sick_history_daftari_bedehkari]  DEFAULT ((0)) FOR [debit]
GO
ALTER TABLE [dbo].[sick_history_real] ADD  CONSTRAINT [DF_sick_history_daftari_bestankari]  DEFAULT ((0)) FOR [credit]
GO
ALTER TABLE [dbo].[sick_history_real] ADD  CONSTRAINT [DF_sick_history_daftari_mandeh]  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Customers_bedehkar]  DEFAULT ((0)) FOR [birth_date]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_sex]  DEFAULT (N'مذکر') FOR [sex]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_home]  DEFAULT (N'مذکر') FOR [home]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_roozaneh]  DEFAULT ((0)) FOR [daily]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_monthFee]  DEFAULT ((0)) FOR [monthly_fee]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_hesab]  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[sicks] ADD  CONSTRAINT [DF_Sicks_status]  DEFAULT (N'بدهکار') FOR [acount_state]
GO
ALTER TABLE [dbo].[assessment]  WITH CHECK ADD  CONSTRAINT [FK_assessment_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[assessment] CHECK CONSTRAINT [FK_assessment_Sicks]
GO
ALTER TABLE [dbo].[black_list]  WITH CHECK ADD  CONSTRAINT [FK_black_list_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[black_list] CHECK CONSTRAINT [FK_black_list_Sicks]
GO
ALTER TABLE [dbo].[dispensed_items]  WITH CHECK ADD  CONSTRAINT [FK_tahvil_koli_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dispensed_items] CHECK CONSTRAINT [FK_tahvil_koli_Sicks]
GO
ALTER TABLE [dbo].[dispensed_items_real]  WITH CHECK ADD  CONSTRAINT [FK_tajviz_koli_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dispensed_items_real] CHECK CONSTRAINT [FK_tajviz_koli_Sicks]
GO
ALTER TABLE [dbo].[dispenses_daily]  WITH CHECK ADD  CONSTRAINT [FK_tahvil_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dispenses_daily] CHECK CONSTRAINT [FK_tahvil_Sicks]
GO
ALTER TABLE [dbo].[dispenses_daily_real]  WITH CHECK ADD  CONSTRAINT [FK_tajviz_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dispenses_daily_real] CHECK CONSTRAINT [FK_tajviz_Sicks]
GO
ALTER TABLE [dbo].[interviews]  WITH CHECK ADD  CONSTRAINT [FK_mos_list_Sicks] FOREIGN KEY([id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[interviews] CHECK CONSTRAINT [FK_mos_list_Sicks]
GO
ALTER TABLE [dbo].[MAP_A]  WITH CHECK ADD  CONSTRAINT [FK_MAP_A_mos_list] FOREIGN KEY([code])
REFERENCES [dbo].[interviews] ([code])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MAP_A] CHECK CONSTRAINT [FK_MAP_A_mos_list]
GO
ALTER TABLE [dbo].[Map_BtoG]  WITH CHECK ADD  CONSTRAINT [FK_Map_BtoG_mos_list] FOREIGN KEY([code])
REFERENCES [dbo].[interviews] ([code])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Map_BtoG] CHECK CONSTRAINT [FK_Map_BtoG_mos_list]
GO
ALTER TABLE [dbo].[MAP_History]  WITH CHECK ADD  CONSTRAINT [FK_MAP_History_mos_list] FOREIGN KEY([code])
REFERENCES [dbo].[interviews] ([code])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MAP_History] CHECK CONSTRAINT [FK_MAP_History_mos_list]
GO
ALTER TABLE [dbo].[payments]  WITH CHECK ADD  CONSTRAINT [FK_ghabz_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[payments] CHECK CONSTRAINT [FK_ghabz_Sicks]
GO
ALTER TABLE [dbo].[payments_real]  WITH CHECK ADD  CONSTRAINT [FK_ghabz_daftari_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[payments_real] CHECK CONSTRAINT [FK_ghabz_daftari_Sicks]
GO
ALTER TABLE [dbo].[prescriptions]  WITH CHECK ADD  CONSTRAINT [FK_dastoor_pezeshk_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[prescriptions] CHECK CONSTRAINT [FK_dastoor_pezeshk_Sicks]
GO
ALTER TABLE [dbo].[psychologist]  WITH CHECK ADD  CONSTRAINT [FK_ravanshenas_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[psychologist] CHECK CONSTRAINT [FK_ravanshenas_Sicks]
GO
ALTER TABLE [dbo].[psychologist_real]  WITH CHECK ADD  CONSTRAINT [FK_ravanshenas_real_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[psychologist_real] CHECK CONSTRAINT [FK_ravanshenas_real_Sicks]
GO
ALTER TABLE [dbo].[sick_history]  WITH CHECK ADD  CONSTRAINT [FK_sick_history_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sick_history] CHECK CONSTRAINT [FK_sick_history_Sicks]
GO
ALTER TABLE [dbo].[sick_history_real]  WITH CHECK ADD  CONSTRAINT [FK_sick_history_daftari_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sick_history_real] CHECK CONSTRAINT [FK_sick_history_daftari_Sicks]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_azmayesh_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_azmayesh_Sicks]
GO
ALTER TABLE [dbo].[test_real]  WITH CHECK ADD  CONSTRAINT [FK_azmayesh_real_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[test_real] CHECK CONSTRAINT [FK_azmayesh_real_Sicks]
GO
ALTER TABLE [dbo].[trackings]  WITH CHECK ADD  CONSTRAINT [FK_peygiri_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[trackings] CHECK CONSTRAINT [FK_peygiri_Sicks]
GO
ALTER TABLE [dbo].[trackings_real]  WITH CHECK ADD  CONSTRAINT [FK_peygiri_real_Sicks] FOREIGN KEY([sick_id])
REFERENCES [dbo].[sicks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[trackings_real] CHECK CONSTRAINT [FK_peygiri_real_Sicks]
GO
USE [master]
GO
ALTER DATABASE [ARC_DB] SET  READ_WRITE 
GO
