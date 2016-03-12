select case when count(*) > 0 then 'Contains Germany!' else 'Germany not found' end as 'check result'
from
(
SELECT CustomerID, Country
FROM Northwind.Customers
WHERE CAST(Country as nvarchar(1)) BETWEEN 'B' AND 'G'
) as result

where result.Country like '%Germany%'