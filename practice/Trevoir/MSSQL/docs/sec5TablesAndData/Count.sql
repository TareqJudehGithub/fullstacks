USE SchoolManagementDB
GO

SELECT *
FROM Students
GO

SELECT ProgramOfStudyId, COUNT(StudentId) [Total Students]
FROM Students
GROUP BY ProgramOfStudyId
GO


SELECT ProgramOfStudyId, Pro.Name [Study], COUNT(StudentId) [Total Students]
FROM Students [Stu]
INNER JOIN ProgramOfStudy [Pro]
ON Stu.ProgramOfStudyId = Pro.Id
GROUP BY ProgramOfStudyId, Pro.Name
GO



INSERT INTO Students
VALUES
('Gorgio', 'Mirabelli', '2002-09-16', 'DN785456', 11),
('Murad', 'Tamer', '1997-01-12', 'PE7369742', 10),
('Sam', 'Tailor', '1991-07-29', 'IT85269', 13),
('Mohammad', 'Baker', '1988-05-24', 'FE197325', 12)
GO

SELECT *
FROM ProgramOfStudy
GO

UPDATE Students
SET ProgramOfStudyId = 13
WHERE Id = 15
GO