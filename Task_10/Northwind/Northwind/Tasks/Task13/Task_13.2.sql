CREATE PROCEDURE Northwind.ShippedOrdersDiff
@Term INT = 35
AS
BEGIN
SELECT OrderID, OrderDate, ShippedDate, (ShippedDate-OrderDate) AS 'ShippedDelay', @Term
FROM Northwind.Orders
WHERE DAY(ShippedDate - OrderDate) > @Term OR ShippedDate IS NULL
END
GO

EXEC Northwind.ShippedOrdersDiff

