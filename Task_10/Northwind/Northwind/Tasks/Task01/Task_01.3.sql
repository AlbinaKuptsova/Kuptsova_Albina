SELECT OrderId AS 'Order Number' , 'Shipped Date' =  
CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' ELSE CAST(ShippedDate AS nvarchar(20))
END
FROM Northwind.Orders
WHERE (ShippedDate IS NULL) OR (ShippedDate > '1998-05-06') 