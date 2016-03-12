SELECT DISTINCT SUBSTRING(LastName,1,1) AS 'Letter'
FROM Northwind.Employees
ORDER BY 'Letter'