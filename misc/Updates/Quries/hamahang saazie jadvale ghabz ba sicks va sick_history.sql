update ghabz set ghabz.id=sick_history.sick_id from ghabz,sick_history where (ghabz.ghabz_id=sick_history.ghabz_id)
update ghabz set ghabz.name=sicks.name from ghabz,sicks where (ghabz.id=sicks.id)
