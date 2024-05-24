select 
race,
ISNULL(Male, 0) as Male,
ISNULL(Female, 0) as Female
FROM (
SELECT 
race,
gender,
count(gender) as suma
  FROM [DBZ].[dbo].[TPersonaje]
  group by race, gender
  ) as p
PIVOT
(SUM(suma) for gender in (Male, Female)) as tablaP