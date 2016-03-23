CREATE PROCEDURE [Northwind].[GreatestOrders]
    @year int,
    @rowCount int
AS
BEGIN
	SET NOCOUNT ON;

    select top(@rowCount) e.EmployeeID, e.FirstName, e.LastName, o.OrderID, z.MaxTotal from 
	(
		-- запрос возвращает ID сотрудника и стоимость самого крупного заказа
		select r.EmployeeID, MAX (r.Subtotal) as MaxTotal from
		(
			-- запрос возвращает заказы сотрудников за указанный год и общую стоимость заказа (Subtotal)
			select o.OrderID, o.EmployeeID, o.OrderDate, os.Subtotal
				from Northwind.Orders o inner join Northwind.[Order Subtotals] os on o.OrderID = os.OrderID			
				where YEAR(o.OrderDate) = @year
		) as r
		group by r.EmployeeID
	) as z inner join Northwind.Employees as e on z.EmployeeID = e.EmployeeID
	inner join Northwind.[Order Subtotals] as os on os.Subtotal = z.MaxTotal
	inner join Northwind.Orders as o on o.OrderID = os.OrderID
	order by z.MaxTotal desc

END
RETURN 0


DECLARE	@reportYear int
DECLARE	@checkEmplID int
set @reportYear = 1996
set @checkEmplID = 5 -- ИД сотрудника для проверки

EXEC	[Northwind].[GreatestOrders]
		@year = @reportYear,
		@rowCount = 100

-- проверочный запрос
-- запрос возвращает заказы сотрудников за указанный год и общую стоимость заказа (Subtotal)
select o.OrderID, o.EmployeeID, o.OrderDate, os.Subtotal
	from Northwind.Orders o inner join Northwind.[Order Subtotals] os on o.OrderID = os.OrderID			
	where YEAR(o.OrderDate) = @reportYear and o.EmployeeID = @checkEmplID
	order by os.Subtotal desc

GO
