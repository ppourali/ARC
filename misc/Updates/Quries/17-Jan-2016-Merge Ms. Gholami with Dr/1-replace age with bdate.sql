/*

    Open DBDiff 0.9.0.0
    http://opendbiff.codeplex.com/

    Script created by PARSA-PC\Parsa on 1/16/2016 at 10:11:47 PM.

    Created on:  PARSA-PC
    Source:      ARC on PARSA-PC\SQLEXPRESS
    Destination: ghARC on PARSA-PC\SQLEXPRESS

*/

USE [ghARC]
GO

ALTER TABLE [dbo].[Sicks] DROP COLUMN [age]
GO
ALTER TABLE [dbo].[Sicks] ADD 
[b_date] [nchar] (10) COLLATE Arabic_CI_AS NOT NULL CONSTRAINT [DF_Customers_bedehkar] DEFAULT ((0))
GO
