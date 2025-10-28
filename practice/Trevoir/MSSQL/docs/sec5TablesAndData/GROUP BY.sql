USE SchoolManagementDB
GO

-- Classes and Courses





SELECT *
FROM ProgramOfStudy
GO
-- 9 DB, 10 PL, 11 DN, 12 FE, 13 IT

UPDATE Courses
SET ProgramOfStudyId = 12
WHERE Id = 17
GO

UPDATE Courses
SET CourseName = 'TypeScript Full Guide'
WHERE Id = 14
GO

SELECT * 
FROM Students
GO

SELECT * 
FROM Courses
GO

SELECT *
FROM Classes
GO

SELECT DISTINCT StudentId
FROM Enrollment
GO


SELECT *
FROM Lecturers
GO

INSERT INTO Classes
VALUES 
('11:00', 5, 1)
GO



SELECT 
  cou.Id, cou.CODE, cou.CourseName 
FROM Classes AS cla
 INNER JOIN Courses AS cou
ON cla.CourseId = cou.Id
WHERE cla.LecturerId = 5
GROUP BY  cou.Id, cou.CODE, cou.CourseName
GO

-- DISTINCT eliminates returning same student more than once.
SELECT DISTINCT enr.StudentId [Student Id], stu.FirstName + ' ' + stu.LastName [Student Name]
FROM Enrollment AS enr
INNER JOIN Students AS stu
ON Enr.StudentId = stu.Id
GO