--select sick_id, count(ghabz_id) as cid from sick_history where (radif>1) group by sick_id having (count(ghabz_id)% 2=1)
--select sick_id, count(radif) as cid from sick_history group by sick_id
--select * from ghabz where mablagh=0
--select * from ghabz where ghabz_id not in (select ghabz_id from sick_history where (ghabz_id!=N'-'))
--select distinct ghabz_id from sick_history where (ghabz_id!=N'-')

delete from sick_history where radif>1