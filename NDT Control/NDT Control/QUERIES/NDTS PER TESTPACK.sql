SELECT 
	RTRIM(iso.Unit)+'-'+RTRIM(iso.[Service])+'-'+RTRIM(iso.Line)+'-'+RTRIM(iso.Train) AS [ISO]
	,RTRIM(JTS.Spool) AS [SPOOL]
	,RTRIM(JTS.JointNumber) AS [JOINT]
	,ISO.NDTCond1
	,ISO.NDTCond2
	,JTS.JointType
	,JTS.NDTCategory
	,DWR_DATA.DWR
	,DWR_DATA.[DATE OF WELD]
	
---------------------------------------------RT-------------------------------------------------
	,CASE WHEN [RT RECENT] IS NULL THEN '' ELSE [RT RECENT] END AS [RT]
	,CASE WHEN [RT RECENT DATE] IS NULL THEN '' ELSE [RT RECENT DATE] END AS [RT DATE]
	,CASE WHEN RTAccepted=1 
			THEN 'YES' 
		  WHEN rtaccepted=0 AND rt1rej=0 AND rtnumber1<>'' 
			THEN 'RESHOOT' 
		  WHEN RTAccepted = 0 AND (RT1rej = 1 or RT2rej =1 or RT3rej =1)
			THEN 'REJ'
		  WHEN RTAccepted = 0 AND RTnumber1 = ''
			THEN ''
			ELSE'NO' 
			END AS [RT RESULT]
	,CASE WHEN NDT.RT IS NULL THEN '' ELSE NDT.RT END AS [RT %]
---------------------------------------------PWHT-------------------------------------------------
	,PWHT1 AS [PWHT]
	,PWHTDate1 AS [PWHT DATE]
	,CASE WHEN PWHTAccepted = 1 THEN 'ACC'
		  WHEN PWHTAccepted = 0 AND PWHT1 <> '' THEN 'REJ'
		  ELSE
		  ''
		  END AS [PWHT RESULT]
	,	
	case when jts.JointType = 'FJ'
			then '0'
		else
				case when iso.NDTCond1 =1
						then 
							 case when jts.htb <> '' and jts.HTBAccepted = 0 --HTB taken and REJ
								then 
									'100'
								else --HTB taken and acc; HTB not taken
									'0'
							 end
					  else -- if iso.NDTcond2 = 0 then normal hta % in ndt matrix
						ndt.PWHT
				end 
		end
	as [PWHT %]
---------------------------------------------HTA-------------------------------------------------
	,HT1 AS [HTa]
	,HTDate1 AS [HTa DATE]
	,CASE WHEN HTAAccepted = 1 THEN 'ACC' 
		  WHEN HTAAccepted = 0 AND HT1 <> '' THEN 'REJ'
		ELSE ''
		END AS [HTa RESULT]
	,
	
	case when jts.JointType = 'FJ'
		then '0'
	else
			case when iso.NDTCond1 =1
			then 
				 case when jts.htb <> '' and jts.HTBAccepted = 0 -- HTB Taken and is REJ
					then 
						'100'
					else	--HTB taken and acc; HTB not taken
						'0'
				 end
			else -- if iso.NDTcond2 = 0 then normal hta % in ndt matrix
				ndt.HTa
			end

	end
	as [HTa %]
---------------------------------------------HTB-------------------------------------------------
	,jts.HTb as [HTb]
	,jts.HTBDate as [HTb DATE]
	,case when jts.HTBAccepted = 1 then 'ACC'
	      when jts.HTBAccepted = 0 and jts.HTb <> '' then 'REJ'
		  else
			''
		  end as [HTb RESULT]
	,
	case when jts.JointType = 'FJ'
		then 
			'0'
		else
			case when iso.NDTCond1 = 1
					then 
						 case when jts.PWHT1 <> '' and jts.PWHTAccepted = 1 --> PWHT taken and ACC
								 then 
									'0'
								else										--> PWHT taken and REJ; PWHT is not taken
									'100'
								end
					else -- NDTCond1 = 0 --> will take normal htb % on ndt matrix
						ndt.HTb
			end 
	end as [HTB %]
					  --when jts.PWHT1 <> '' and jts.PWHTAccepted = 0 --PWHT REJ
						 --then '100'
					  --when jts.PWHT1 = '' and jts.PWHTAccepted = 0 --PWHT not taken
						 --then '100'
					  
---------------------------------------------PT-------------------------------------------------
	,jts.PTnumber as [PT]
	,jts.PTDate as [PT DATE]
	,case when jts.ptnumber <> '' and jts.PT = 1 then 'ACC' 
		  when jts.ptnumber <> '' and jts.pt = 0 then 'REJ'
		  else	
		  ''
		  end AS [PT RESULT]
	, NDT.PT AS [PT %]
---------------------------------------------PMI-------------------------------------------------
	, jts.PMInumber AS [PMI]
	,jts.PMIDate AS [PMI DATE]
	,CASE WHEN JTS.PMI = 1 AND JTS.PMInumber <> '' THEN 'ACC'
			WHEN JTS.PMI = 0 AND JTS.PMInumber <> '' THEN 'REJ'
		  ELSE
		  ''
		  END 
		  AS	
		  [PMI RESULT]
	, NDT.PMI AS [PMI %]
---------------------------------------------FT-------------------------------------------------
	,JTS.ferrit AS [FT]
	,JTS.ferritdate AS [FT DATE]
	,CASE WHEN JTS.FerritAccepted = 1 AND JTS.ferrit <> '' THEN 'ACC'
		  WHEN JTS.FerritAccepted = 0 AND JTS.ferrit <> '' THEN 'REJ'
		  ELSE
		  ''
		  END 
	  AS [FT RESULT]
	,NDT.Ferr AS [FT %]

FROM

		(	SELECT Size.EQSize AS MainDia,i.*
			FROM Isometric i,Size WITH (NOLOCK) 
			WHERE i.LatestRevision LIKE '%Latest%' 
			AND i.Dia=Size.Jointsize 
			AND i.active=1) AS iso

	LEFT JOIN
		(SELECT Size.EqSize AS Dia, j.* 
		FROM Joints j,Size WITH (NOLOCK) 
		WHERE j.JointSize=size.Jointsize) AS jts
		ON iso.[service]=jts.[service] 
		AND iso.unit=jts.unit 
		AND iso.line=jts.line 
		AND iso.train=jts.train 

	LEFT JOIN
		(SELECT * 
		FROM Spool with (NOLOCK) 
		WHERE Active=1) as sp
		ON jts.service=sp.service 
		AND jts.unit=sp.unit 
		AND jts.line=sp.line 
		AND jts.train=sp.train 
		AND jts.spool=sp.spool

	LEFT JOIN
		(
				SELECT UNIT, SERVICE, LINE, TRAIN, JointNumber,
				CASE WHEN ivisual3 <> '' 
							AND ReparationDate2 > ReparationDate 
							AND ReparationDate2 > DateofWeld
						THEN 
							ivisual3
					  WHEN ivisual2 <> '' 
							AND ReparationDate > DateofWeld
						THEN 
							ivisual2
						ELSE
							WeldingReportNumber
				END AS [DWR]
				,
					CASE WHEN ivisual3 <> '' 
							AND ReparationDate2 > ReparationDate 
							AND ReparationDate2 > DateofWeld
						THEN 
							ReparationDate2
					  WHEN ivisual2 <> '' 
							AND ReparationDate > DateofWeld
						THEN 
							ReparationDate
						ELSE
							DateofWeld
				END AS [DATE OF WELD]

			 FROM Joints WITH(NOLOCK)
		) DWR_DATA
		ON
		DWR_DATA.Unit = JTS.Unit
		AND
		DWR_DATA.[Service] = JTS.[Service]
		AND 
		DWR_DATA.Line = JTS.Line
		AND 
		DWR_DATA.Train = JTS.Train
		AND 
		DWR_DATA.JointNumber = jts.JointNumber

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
			JTS.UNIT = RT_DATE.UNIT
			AND JTS.[SERVICE] = RT_DATE.[SERVICE]
			AND JTS.LINE = RT_DATE.LINE
			AND JTS.TRAIN = RT_DATE.TRAIN
			AND JTS.SPOOL = RT_DATE.SPOOL
			AND JTS.JOINTNUMBER = RT_DATE.JointNumber
		LEFT JOIN
		NDT
		ON
		JTS.NDTCategory = NDT.NDTCategory
WHERE
sp.HTP = '00-01-00-P411-101-002'

--select * from HTP