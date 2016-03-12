SELECT OrderId, ShippedDate, ShipVia 
FROM Northwind.Orders
WHERE (ShippedDate >= '1998-05-06') and (ShipVia >=2)
