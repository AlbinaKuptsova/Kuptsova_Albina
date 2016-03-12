SELECT DISTINCT C1.CustomerID, C1.City
    FROM Northwind.Customers C1, Northwind.Customers C2
    WHERE C1.City = C2.City
    AND C1.CustomerID <> C2.CustomerID


	SELECT City, COUNT(*) AS 'Count'
    FROM Northwind.Customers
    GROUP BY City
    HAVING COUNT(*) > 1