SELECT (SELECT Empl.LastName  + ' ' + Empl.FirstName
        FROM Northwind.Employees Empl
        WHERE Empl.EmployeeID = Ord.EmployeeID) AS 'Seller', COUNT(OrderID) AS 'Amount'
FROM Northwind.Orders Ord
GROUP BY EmployeeID
ORDER BY 'Amount' DESC