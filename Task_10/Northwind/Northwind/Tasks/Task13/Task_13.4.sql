CREATE PROCEDURE Northwind.IsBoss
@EmplID INT,
@FLAG BIT OUTPUT
AS
BEGIN
SET @FLAG = 
CASE 
WHEN EXISTS(SELECT EmployeeID FROM Northwind.Employees WHERE ReportsTo = @EmplID)
THEN 1
ELSE 0
END --CASE
END
GO
 

DECLARE @ID INT
DECLARE Employee_Cursor CURSOR FOR
SELECT DISTINCT EmployeeID FROM Northwind.Employees ORDER BY EmployeeID


OPEN Employee_Cursor

FETCH NEXT FROM Employee_Cursor 
INTO @ID

WHILE @@FETCH_STATUS = 0
BEGIN
DECLARE @flag BIT

EXEC Northwind.IsBoss @ID, @flag OUTPUT

DECLARE @str VARCHAR(255) = 'EmployeeID: ' + CONVERT(VARCHAR(255), @ID )
		+ ' IsBoss: ' + CONVERT(VARCHAR(255), @flag)

PRINT @str

FETCH NEXT FROM Employee_Cursor 
INTO @ID

END

CLOSE Employee_Cursor