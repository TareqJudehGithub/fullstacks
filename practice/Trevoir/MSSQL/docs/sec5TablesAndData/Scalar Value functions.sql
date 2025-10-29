-- Scalar Value functions
 -- Returns one value  (like  SUM() and AVG())

USE SchoolManagementDB
GO

 SELECT GETDATE()
 GO

 SELECT MONTH(GETDATE())
 GO

 SELECT YEAR(GETDATE())
 GO

 CREATE FUNCTION Fnc_GetHighestGrade 
 (
   -- Params
 )
 -- Return type
 RETURNS DECIMAL(3,2)
 AS
 BEGIN
  DECLARE
 END