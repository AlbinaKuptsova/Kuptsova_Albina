(SELECT CompanyName AS 'Person', 'Customer' AS 'Type', City AS 'City'
            FROM Northwind.Customers
            WHERE EXISTS (SELECT * FROM Northwind.Employees WHERE Employees.City = Customers.City)
        UNION
        SELECT LastName + ' ' + FirstName AS 'Person', 'Seller' AS 'Type', City AS 'City'
            FROM Northwind.Employees
            WHERE EXISTS (SELECT * FROM Northwind.Customers WHERE Customers.City = Employees.City))
ORDER BY 'City', 'Person'