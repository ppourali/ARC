USE ARC
GO
UPDATE [sick_history] SET tashkhis=N'بدهکار' WHERE tashkhis=N'ÈÏå˜ÇÑ'
UPDATE [sick_history] SET tashkhis=N'بستانکار' WHERE tashkhis=N'ÈÓÊÇä˜ÇÑ'


UPDATE [sick_history_daftari] SET tashkhis=N'بدهکار' WHERE tashkhis=N'ÈÏå˜ÇÑ'
UPDATE [sick_history_daftari] SET tashkhis=N'بستانکار' WHERE tashkhis=N'ÈÓÊÇä˜ÇÑ'

GO
