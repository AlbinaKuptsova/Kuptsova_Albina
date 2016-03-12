SELECT LastName AS 'User Name',
    (SELECT LastName FROM Northwind.Employees E2 WHERE E2.EmployeeID = E1.ReportsTo) AS 'Boss'
FROM Northwind.Employees E1