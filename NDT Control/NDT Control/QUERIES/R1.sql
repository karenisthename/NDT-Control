update joints 
set ReparationDate = Case when Isnull(reparationdate,'') <> '' 
						  then reparationdate else '@RepDate' end
,ivisual2 = case when isnull(ivisual2,'') <> ''  
				 then ivisual2 else '@Report' end 
,welderrt2 = case when isnull(welderrt2,'') <> ''  
			     then welderrt2 else '@welder' end
from joints with (NOLOCK)

where 
joints.unit  = '@Unit'
and joints.service = '@Service'
and joints.line = '@Line' 
and joints.train = '@Train'
and joints.JointNumber = '@Joint'
