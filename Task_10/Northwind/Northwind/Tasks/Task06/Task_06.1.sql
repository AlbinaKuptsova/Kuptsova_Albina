SELECT YEAR(OrderDate) AS 'Year', COUNT(OrderID) AS 'Total'
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(OrderID) FROM Northwind.Orders