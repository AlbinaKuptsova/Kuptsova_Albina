SELECT (SELECT Employees.LastName + ' ' + Employees.FirstName
        FROM Northwind.Employees
        WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller'
FROM Northwind.Orders
GROUP BY Orders.EmployeeID
HAVING COUNT(*) > 150;