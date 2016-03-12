SELECT Customers.ContactName, COUNT(OrderID) AS 'Count'
FROM Northwind.Customers
LEFT JOIN Northwind.Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY ContactName
ORDER BY 'Count' DESC 
