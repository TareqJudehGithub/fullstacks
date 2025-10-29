USE SchoolManagementDB
GO

-- AVG()



ALTER TABLE Enrollment
ALTER COLUMN Grade DECIMAL(3,1) NULL
GO

UPDATE Enrollment
SET ClassId = 18
WHERE Id =30
GO

SELECT *
FROM Enrollment
GO

INSERT INTO Enrollment
VALUES
(61, 15, 18),
(58.5, 12, 6),
(72.7, 12, 21),
(66, 13, 22),
(71, 14, 15),
(79, 16, 21),
(68.5, 17, 6),
(57.5, 18, 6),
(87.5, 18, 15),
(92.5, 15, 21),
(89.5, 12, 15),
(95, 13, 18),
(87.5, 14, 21),
(55.5, 16, 17),
(78.5, 17, 16),
(79.7, 18, 17)
GO



SELECT 
  Stu.StudentId, 
  Stu.FirstName + ' ' + Stu.LastName [Student],
  CAST(AVG(Enr.Grade) AS DECIMAL(10, 2)) [Grade],
  MIN(Enr.Grade) [Lowest],
  MAX(Enr.Grade) [Highest]
FROM Enrollment [Enr]
INNER JOIN Students [Stu]
ON Enr.StudentId = Stu.Id
GROUP BY  Stu.StudentId, Stu.FirstName + ' ' + Stu.LastName
ORDER BY [Grade] DESC
GO
