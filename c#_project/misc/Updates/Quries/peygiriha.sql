-- tedade visit dar har bazeye tarikhi masalan hafteh-- tedade satrha melak ast!!!
select code, min(tajviz_date) from tajviz_koli where (tajviz_date>=N'1390/02/01' and tajviz_date<='1390/02/15' and id=N'0015') group by code having (sum(tedad)>0)
----------------------------------------------------------------------------------
-- tedade gheybat dar har bazeye tarikhi masalan hafteh-- tedade satrha melak ast!!!
select code from tajviz_koli where (tajviz_date>=N'1390/02/01' and tajviz_date<='1390/03/10' and id=N'0006') group by code having (sum(tedad)=0)
----------------------------------------------------------------------------------
-- tedade azmayesh dar har bazeye tarikhi masalan hafteh--
select count (distinct code) as tedad from azmayesh where (date>=N'1390/02/01' and date<='1390/03/10' and sick_id=N'0006')
----------------------------------------------------------------------------------
-- tedade moshavereh dar har bazeye tarikhi masalan hafteh--
select count (distinct code) as tedad from ravanshenas where (date>=N'1390/02/01' and date<='1390/03/10' and sick_id=N'0006')
----------------------------------------------------------------------------------
-- tedade dastoore pezeshk dar har bazeye tarikhi masalan hafteh--
select count (distinct code) as tedad from dastoor_pezeshk where (date>=N'1390/02/01' and date<='1390/03/10' and sick_id=N'0006')
----------------------------------------------------------------------------------
-- tedade MAP dar har bazeye tarikhi masalan hafteh--
select count (distinct code) as tedad from mos_list where (mos_date>=N'1390/02/01' and mos_date<='1390/03/15' and id=N'0015')







