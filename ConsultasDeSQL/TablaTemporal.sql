
--Se crea table temporal para llenarla con los datos de la tabla TPersonaje
declare @TPersonaje table
(id int not null,
name nvarchar(22) not null,
ki nvarchar(15) not null,
maxKi nvarchar(16) not null,
race nvarchar(16) not null,
gender nvarchar(6) not null,
description nvarchar(978) not null,
image nvarchar(87) not null,
affiliation nvarchar(20) not null,
deletedAt nvarchar(30) null,
Ki_Nuevo numeric (38,2)null,
MaxKI_Nuevo numeric (38,2)null

)

--se crea tabla temporal para insertar los datos con en nuevo valor de MaxKi
declare @MaxkiConvertido table
(id int not null,
 numero numeric (38,2)null 

)

--se crea tabla temporal para insertar los datos con en nuevo valor de MaxKi
declare @KiConvertido table
(id int not null,
 numero numeric (38,2)null 

)
-- se insertan los datos de la tabla TPersonaje
insert @TPersonaje
select id,
name,
ki,
maxKi,
race,
gender,
description,
image,
affiliation,
deletedAt,
0,0
from TPersonaje


 

insert @MaxkiConvertido
SELECT 
   id, CAST(REPLACE(maxKi, ' Septillion', '') AS NUMERIC(38,2)) * 1000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Septillion%'

	union all


--	union all

SELECT 
   id, CAST(REPLACE(maxKi, ' septllion', '') AS NUMERIC(38,2)) * 1000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%septl%'


	union all
-- Sextillion
SELECT 
   id, CAST(REPLACE(maxKi, ' Sextillion', '') AS NUMERIC(38, 2)) *1000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Sextillion%'

	union all
-- Quintillion
SELECT 
   id, CAST(REPLACE(maxKi, ' Quintillion', '') AS NUMERIC(38,2))*1000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Quintillion%'

	union all
-- Trillion

SELECT 
   id, CAST(REPLACE(maxKi, ' Trillion', '') AS NUMERIC(38, 2)) *1000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Trillion%'

	union all
-- billion

SELECT 
   id, CAST(REPLACE(maxKi, ' Billion', '') AS NUMERIC(38, 2))*1000000000  AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Billion%'

	union all
--unknown

    SELECT
       id, Numero= CAST(REPLACE(maxKi, 'unknown', '0') AS nvarchar(10)) 
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where maxKi like '%unknown%'
 
 union all
 --Googolplex

 SELECT 
   id, CAST(REPLACE(maxKi, ' Googolplex', '') AS NUMERIC(38,2)) * 1000000000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where maxKi like '%Googolplex%'

 union all
-- los que tienen (punto)
     SELECT
       id, CAST(REPLACE(maxKi, '.', '') AS nvarchar(38 ))  AS Numero
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where maxKi like '%.%'
        and maxki  not like '%Septillion%'
	    and maxki  not like '%septllion%'
		and maxki  not like '%Sextillion%'
		and maxki  not like '%Quintillion%'
		and maxki  not like '%Trillion%'
	    and maxki  not like '%Billion%'

union all
-- los que tienen (coma)
     SELECT
       id, CAST(REPLACE(maxKi, ',', '') AS nvarchar(38 ))  AS Numero
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where maxKi like '%,%'
        and maxki  not like '%Septillion%'
	    and maxki  not like '%septllion%'
		and maxki  not like '%Sextillion%'
		and maxki  not like '%Quintillion%'
		and maxki  not like '%Trillion%'
	    and maxki  not like '%Billion%'



--se actualiza el nuevo valor de Maxki en el campo numérico nuevo
update @TPersonaje 
set MaxKI_Nuevo  = numero
from @MaxkiConvertido r
inner join @TPersonaje as t
on r.id =t.id
  

------- Sacar los valores nuevos de KI
  

insert @KiConvertido
SELECT 
   id, CAST(REPLACE(ki, ' Septillion', '') AS NUMERIC(38,2)) * 1000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Septillion%'

	union all

SELECT 
   id, CAST(REPLACE(ki, ' septllion', '') AS NUMERIC(38,2)) * 1000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%septl%'


	union all
-- Sextillion
SELECT 
   id, CAST(REPLACE(ki, ' Sextillion', '') AS NUMERIC(38, 2)) *1000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Sextillion%'

	union all
-- Quintillion
SELECT 
   id, CAST(REPLACE(ki, ' Quintillion', '') AS NUMERIC(38,2))*1000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Quintillion%'

union all
 
--Quadrillion
SELECT 
   id, CAST(REPLACE(ki, ' Quadrillion', '') AS NUMERIC(38,2))*1000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Quadrillion%'


	union all
-- Trillion

SELECT 
   id, CAST(REPLACE(ki, ' Trillion', '') AS NUMERIC(38, 2)) *1000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Trillion%'

	union all
-- billion

SELECT 
   id, CAST(REPLACE(ki, ' Billion', '') AS NUMERIC(38, 2))*1000000000  AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Billion%'

	union all
--unknown

    SELECT
       id, Numero= CAST(REPLACE(ki, 'unknown', '0') AS nvarchar(10)) 
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where ki like '%unknown%'
 
  union all
 --Googolplex

 SELECT 
   id, CAST(REPLACE(ki, ' Googolplex', '') AS NUMERIC(38,2)) * 1000000000000000000000000000000 AS Numero
FROM 
    [DBZ].[dbo].[TPersonaje]
    where ki like '%Googolplex%'
 
 union all
-- los que tienen (punto)
     SELECT
       id, CAST(REPLACE(ki, '.', '') AS nvarchar(38 ))  AS Numero
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where ki like '%.%'
        and ki  not like '%Septillion%'
	    and ki  not like '%septllion%'
		and ki  not like '%Sextillion%'
		and ki  not like '%Quintillion%'
		and ki  not like '%Quadrillion%'
		and ki  not like '%Trillion%'
	    and ki  not like '%Billion%'

union all
-- los que tienen (coma)
     SELECT
       id, CAST(REPLACE(ki, ',', '') AS nvarchar(38 ))  AS Numero
	 
    FROM 
        [DBZ].[dbo].[TPersonaje]
		 where ki like '%,%'
      and ki  not like '%Septillion%'
	    and ki  not like '%septllion%'
		and ki  not like '%Sextillion%'
		and ki  not like '%Quintillion%'
		and ki  not like '%Quadrillion%'
		and ki  not like '%Trillion%'
	    and ki  not like '%Billion%'


 


--se actualiza el nuevo valor de Ki en el campo numérico nuevo
update @TPersonaje 
set Ki_Nuevo  = numero
from @KiConvertido r
inner join @TPersonaje as t
on r.id =t.id


select * from @TPersonaje