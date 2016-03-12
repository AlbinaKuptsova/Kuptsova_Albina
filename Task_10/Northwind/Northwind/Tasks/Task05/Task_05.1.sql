SELECT CAST(SUM((UnitPrice-Discount)*Quantity) AS money) AS 'Totals'
FROM Northwind.[Order Details]
