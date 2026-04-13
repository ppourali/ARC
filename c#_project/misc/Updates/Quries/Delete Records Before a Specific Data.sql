USE ARC
go

DECLARE @end_date AS VARCHAR(10)=N'1400/01/01'

DELETE FROM action_logs WHERE date<@end_date
DELETE FROM amar_records WHERE date<@end_date
DELETE FROM azmayesh WHERE date<@end_date
DELETE FROM azmayesh_real WHERE date<@end_date
DELETE FROM dastoor_pezeshk WHERE date<@end_date
DELETE FROM dastoor_pezeshk_real WHERE date<@end_date
DELETE FROM ghabz WHERE date<@end_date
DELETE FROM ghabz_daftari WHERE date<@end_date
DELETE FROM mos_list WHERE mos_date<@end_date
DELETE FROM peygiri WHERE date<@end_date
DELETE FROM peygiri_real WHERE date<@end_date
DELETE FROM ravanshenas WHERE date<@end_date
DELETE FROM ravanshenas_real WHERE date<@end_date
DELETE FROM sick_history WHERE date<@end_date
DELETE FROM sick_history_daftari WHERE date<@end_date
DELETE FROM tahvil WHERE date<@end_date
DELETE FROM tahvil_koli WHERE tahvil_date<@end_date
DELETE FROM tajviz WHERE date<@end_date
DELETE FROM tajviz_koli WHERE tajviz_date<@end_date
DELETE FROM tajviz_anbar_history WHERE date<@end_date
DELETE FROM tajviz_factors WHERE date<@end_date
DELETE FROM tajviz_koli WHERE tajviz_date<@end_date

GO
