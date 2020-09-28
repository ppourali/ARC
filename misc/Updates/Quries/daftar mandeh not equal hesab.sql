use arc
select sicks.id,hesab, si2.mandeh from sicks
left join (select sick_id,max(radif) as ra from sick_history group by sick_id) si on si.sick_id=sicks.id
left join (select radif,sick_id,mandeh from sick_history) si2 on si2.sick_id=si.sick_id and si2.radif=si.ra
where (hesab!=mandeh) order by id