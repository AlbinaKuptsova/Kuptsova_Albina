SELECT OrderID, ShippedDate = 
CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
END
FROM Northwind.Orders
WHERE ShippedDate IS NULL