SELECT Employees.LastName, Territories.TerritoryDescription
FROM Northwind.Employees
JOIN Northwind.EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID
JOIN Northwind.Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
    WHERE RegionID IN (
        SELECT RegionID
        FROM Northwind.Region
        WHERE RegionDescription = 'Western'
    )

