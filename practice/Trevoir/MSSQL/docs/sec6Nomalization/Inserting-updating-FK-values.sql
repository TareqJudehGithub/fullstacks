USE SchoolManagementDB
GO

SELECT *
FROM Enrollment
GO


SELECT *
FROM Students
GO
-- 5-8, 9, 10

SELECT *
FROM Classes
GO
-- 1, 2, 3, 4, 5


SELECT *
FROM ProgramOfStudy
GO
-- 1 DB, 2 PL, 3 DN, 6 FE, 8IT

BEGIN TRANSACTION
  INSERT INTO Students
  VALUES
  ('Huda', 'Bassem','2001-07-19', 'FE974628', 6)
  GO
COMMIT

BEGIN TRANSACTION
  UPDATE Students
  SET ProgramOfStudyId = 6
  WHERE Id IN (16, 17)
  GO
COMMIT

ROLLBACK


SELECT *
FROM ProgramOfStudy
GO

BEGIN TRANSACTION
  INSERT INTO ProgramOfStudy
  VALUES
  ('Bsc. in Information Technology', 4)
  GO
COMMIT

BEGIN TRANSACTION
  UPDATE ProgramOfStudy
  SET Name = 'Programming Language'
  WHERE Id IN (2, 4)
COMMIT

DELETE
FROM ProgramOfStudy
WHERE Id IN (4, 5, 7)
GO