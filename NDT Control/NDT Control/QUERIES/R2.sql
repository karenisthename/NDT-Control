
update joints 
set ReparationDate2 = Case when Isnull(reparationdate2,'') <> '' 
	then reparationdate2 else '@RepDate' end
,ivisual3 = case when isnull(ivisual3,'') <> ''  
	then ivisual3 else '@Report' end 
,welderrt3 = case when isnull(welderrt3,'') <> ''  
	then welderrt3 else '@welder' end
from joints with (NOLOCK),pcatemp with (NOLOCK)
where 
joints.unit  = '@Unit'
and joints.service = '@Service'
and joints.line = '@Line' 
and joints.train = '@Train'
and joints.JointNumber = '@Joint'
