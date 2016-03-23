CREATE PROCEDURE [Northwind].[SubordinationInfo]
    @EmployeeID int = 2
AS
    WITH DirectReports (ManagerID, EmployeeID, EmplName, Level, Sort)
    AS
    (
	    -- Anchor member definition
        SELECT	e.ReportsTo, 
			    e.EmployeeID, 
			    CAST(CONCAT(e.FirstName, ' ', e.LastName) as nvarchar(100)) as EmplName, 
			    1 AS Level,
			    CAST(CONCAT(e.FirstName, ' ', e.LastName) as nvarchar(254))
        FROM Northwind.Employees AS e    
        WHERE e.EmployeeID = @EmployeeID
        UNION ALL
	
	    -- Recursive member definition
        SELECT	e.ReportsTo,
			    e.EmployeeID, 
			    CAST(REPLICATE ('    ' , d.Level) + CONCAT(e.FirstName, ' ', e.LastName) as nvarchar(100)) as EmplName, 
			    Level + 1,
			    CAST(d.Sort + '\' + CONCAT(e.FirstName, ' ', e.LastName) as nvarchar(254))
        FROM Northwind.Employees AS e
        INNER JOIN DirectReports AS d ON e.ReportsTo = d.EmployeeID
    )
-- Statement that executes the CTE
SELECT ManagerID, EmployeeID, EmplName, Level, Sort
FROM DirectReports dr
order by Sort;