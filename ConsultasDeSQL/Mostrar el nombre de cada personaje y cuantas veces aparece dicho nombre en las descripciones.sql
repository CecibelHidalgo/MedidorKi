--•	Escribe una consulta que muestre el nombre de cada personaje y cuantas veces aparece dicho nombre en las descripciones de todos los personajes.

 
 SELECT 
    PER.name,
       SUM((LEN(PER2.description) - LEN(REPLACE(PER2.description, PER.name, ''))) / LEN(PER.name))
     AS apariciones
FROM 
    DBZ.dbo.TPersonaje PER
JOIN 
    DBZ.dbo.TPersonaje PER2 ON PER2.description LIKE '%' + PER.name + '%'
GROUP BY 
  PER.name