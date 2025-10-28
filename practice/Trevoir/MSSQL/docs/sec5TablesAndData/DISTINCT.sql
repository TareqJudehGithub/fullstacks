USE SchoolManagementDB
GO


INSERT INTO Enrollment
VALUES 
(NULL, 13, 21),
(NULL, 13, 17),
(NULL, 17, 15),
(NULL, 15, 21),
(NULL, 16, 15),
(NULL, 14, 17)
GO

-- Distinct Eliminates data redundancy
SELECT DISTINCT StudentId
FROM Enrollment
GO

SELECT *
FROM Enrollment
GO

