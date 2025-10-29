USE SchoolManagementDB
GO


-- Create a view for complex queries

CREATE VIEW vw_SumOfCredits
AS
  SELECT 
    Enr.StudentId [Student ID],
    Stu.FirstName + ' ' + Stu.LastName [Student Name],   
    CAST(AVG(Enr.Grade) AS DECIMAL(3, 1)) Score,
    SUM(Cou.CREDITS) [Total Credits]
  FROM Enrollment [Enr]
  INNER JOIN Classes [Cla]
  ON Enr.ClassId = Cla.Id
  INNER JOIN Courses [Cou]
  ON Cla.CourseId = Cou.Id
  INNER JOIN Students [Stu]
  ON Enr.StudentId = Stu.Id
  GROUP BY Enr.StudentId, Stu.FirstName + ' ' + Stu.LastName
GO

-- Calling a view
SELECT * 
FROM vw_SumOfCredits
GO

-- UPDATE a view

-- We use ALTER VIEW for updating a view
ALTER VIEW vw_SumOfCredits
AS
  SELECT 
    Enr.StudentId [Student ID],
    Stu.FirstName + ' ' + Stu.LastName [Student Name],   
    CAST(AVG(Enr.Grade) AS DECIMAL(3, 1)) Score,
    SUM(Cou.CREDITS) [Total Credits]
  FROM Enrollment [Enr]
  INNER JOIN Classes [Cla]
  ON Enr.ClassId = Cla.Id
  INNER JOIN Courses [Cou]
  ON Cla.CourseId = Cou.Id
  INNER JOIN Students [Stu]
  ON Enr.StudentId = Stu.Id
  GROUP BY Enr.StudentId, Stu.FirstName + ' ' + Stu.LastName
  HAVING SUM(Cou.CREDITS) > 10
GO

-- Calling a view
SELECT * 
FROM vw_SumOfCredits
GO


