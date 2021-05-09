
---------------------RT

select DISTINCT htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	    j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,NDT.RT AS [NDT %]
	   ,RT_DATE.[RT RECENT] as [Report], RT_DATE.[RT RECENT DATE] as [Report Date]
	   ,CASE WHEN RTAccepted = 1 THEN 'ACC' ELSE 'REJ' END as [NDT Result], 'RT' as [NDT Type]
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool


LEFT JOIN
(
select UNIT, [SERVICE], LINE, TRAIN, SPOOL, JointNumber,
		  (select MAX(CASE 
					  WHEN (	reshootdate <> '' 
							 AND reshootdate > reshootdate2
							 AND reshootdate > RTDate1 
							 AND reshootdate > RTDate2 
							 AND reshootdate > RTDate3
						  )
					 THEN reshoot
					WHEN(
							reshootdate2 <> '' 
							 AND (reshootdate2 > reshootdate OR reshootdate2 = reshootdate)
							 AND reshootdate2 > RTDate1 
							 AND reshootdate2 > RTDate2
							 AND reshootdate2 > RTDate3 
					)
					THEN reshoot2
					WHEN (rtdate3 <> '' 
							AND RTDATE3 > RTDate2 
							AND RTDate3 > RTDate1
							AND RTDate3 > reshootdate
							AND RTDate3 > reshootdate2)
					THEN RTnumber3
				   WHEN (RTDATE2 <> '' 
							AND RTDate3 = '' 
							AND RTDATE2 > RTDATE1
							AND RTDATE2 > reshootdate
							AND RTDATE2 > reshootdate2 )
				    THEN RTnumber2
				   WHEN (RTDate1 <> '' 
							AND RTDate2 ='' 
							AND RTDate3 = '' 
							AND (reshootdate = '' OR RTDate1 > reshootdate)
							AND reshootdate2 = '' OR RTDate1 > reshootdate2)
					THEN RTnumber1
					END		
			  )) AS [RT RECENT]	,	 
		 (select MAX(CASE 
					  WHEN (	reshootdate <> '' 
							 AND reshootdate > reshootdate2
							 AND reshootdate > RTDate1 
							 AND reshootdate > RTDate2 
							 AND reshootdate > RTDate3
						  )
					 THEN reshootdate
					WHEN(
							reshootdate2 <> '' 
							 AND (reshootdate2 > reshootdate OR reshootdate2 = reshootdate)
							 AND reshootdate2 > RTDate1 
							 AND reshootdate2 > RTDate2
							 AND reshootdate2 > RTDate3 
					)
					THEN reshootdate2
					WHEN (rtdate3 <> '' 
							AND RTDATE3 > RTDate2 
							AND RTDate3 > RTDate1
							AND RTDate3 > reshootdate
							AND RTDate3 > reshootdate2)
					THEN RTDate3
				   WHEN (RTDATE2 <> '' 
							AND RTDate3 = '' 
							AND RTDATE2 > RTDATE1
							AND RTDATE2 > reshootdate
							AND RTDATE2 > reshootdate2 )
				    THEN RTDate2
				   WHEN (RTDate1 <> '' 
							AND RTDate2 ='' 
							AND RTDate3 = '' 
							AND (reshootdate = '' OR RTDate1 > reshootdate)
							AND reshootdate2 = '' OR RTDate1 > reshootdate2)
					THEN RTDate1				 
					END		
			  )) AS [RT RECENT DATE]
		from joints WITH(NOLOCK)
	where 
	unit = Joints.Unit
	and line = Joints.LINE
	and train = Joints.TRAIN
	and [service] = Joints.[SERVICE]
	and spool = JOINTS.SPOOL
	and JointNumber = Joints.JOINTNUMBER
	GROUP BY UNIT,[SERVICE], LINE, TRAIN, Spool , JointNumber
) AS RT_DATE
ON 
J.UNIT = RT_DATE.UNIT
AND J.[SERVICE] = RT_DATE.[SERVICE]
AND J.LINE = RT_DATE.LINE
AND J.TRAIN = RT_DATE.TRAIN
AND J.SPOOL = RT_DATE.SPOOL
AND J.JOINTNUMBER = RT_DATE.JointNumber

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory

LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where

RT_DATE.[RT RECENT DATE] > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1


-------------------------------pwht
union

select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,CASE WHEN J.MarkPWHT > 0 THEN J.MarkPWHT ELSE NDT.PWHT END
	   ,j.PWHT1, j.PWHTDate1,CASE WHEN j.PWHTAccepted = 1 THEN 'ACC' ELSE 'REJ' END, 'PWHT' as [NDT Type]
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory


LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where

PWHTDate1 > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)


union
------------------------------------hta

select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,NDT.HTa
	   ,j.HT1, j.HTDate1, CASE WHEN j.HTAAccepted = 1 THEN 'ACC' ELSE 'REJ' END, 'HTA' as [NDT Type]
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory


LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where
HTDate1 > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)

union
--------------------------HTB


select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,NDT.HTb
	   ,j.HTB, j.HTBDate, CASE WHEN j.HTBAccepted = 1 THEN 'ACC' ELSE 'REJ' END, 'HTB' as [NDT Type]
	 
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory

LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where
HTBDate > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)
union
------------------pmi

select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,NDT.PMI
	   ,j.pminumber, j.pmidate, CASE WHEN j.pmi = 1 THEN 'ACC' ELSE 'REJ' END, 'PMI' as [NDT Type]
	  
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory

LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where
PMIDate > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)

---------------------pt
union

select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	  ,J.NDTCategory
	  ,NDT.PT
	   ,j.PTnumber, j.PTDate, CASE WHEN j.PT = 1 THEN 'ACC' ELSE 'REJ' END,'PT' as [NDT Type]
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory

LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where
PTDate > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)

union
---------------ft

select htp.HTP, htp.Type as [Type], htp.targettest as [QC Tested Date], htp.pt as [Construction Tested Date]
	   
	   ,j.unit, j.[service], j.Line, j.Train, j.Spool, j.JointNumber, 
	   j.JointType,
	   case when j.Active = 1 then 'Active' else 'Canceled' end as [Active]
	   ,I.InspN AS [CC]
	   ,J.NDTCategory
	   ,NDT.Ferr
	   ,j.ferrit, j.ferritdate, CASE WHEN j.FerritAccepted = 1 THEN 'ACC' ELSE 'REJ' END, 'FT' as [NDT Type]
 from 
HTP

left join
Spool s

on
htp.HTP = s.HTP

left join
Joints j WITH(NOLOCK)
on 
j.unit = s.Unit
and
j.[Service]= s.[Service]
and
j.Line = s.Line
and 
j.Train = s.Train
and
j.Spool = s.Spool

LEFT JOIN
NDT 
ON 
NDT.NDTCategory = j.NDTCategory

LEFT JOIN
(
	SELECT UNIT,SERVICE, LINE,TRAIN, InspN FROM Isometric WITH(NOLOCK)
	WHERE
	LatestRevision LIKE '%latest%'
	AND 
	Active = 1
) I 
ON 
I.UNIT = J.UNIT
AND 
I.SERVICE = J.Service
AND 
I.LINE = J.LINE
AND 
I.Train = J.Train

where
ferritdate > case when htp.targettest = '' then htp.PT else htp.targettest end
and
(htp.PT <> '' or htp.targettest <> '')
--and
--j.Active = 1
and j.Unit in (01,11)
