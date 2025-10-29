USE SchoolManagementDB
GO

-- Create a new new Store Procedure (sp)
CREATE PROCEDURE sp_SelectAllStudents
AS 
BEGIN
  SELECT *
  FROM Students
END

-- Execute a SP
EXEC sp_SelectAllStudents
GO

CREATE PROCEDURE sp_SelectStudentById
  -- Params
  @Id INT = 0
AS
BEGIN
  SELECT *
  FROM Students
  WHERE Id = @Id
END
GO

EXEC sp_SelectStudentById @Id = 22
GO

-- sp for Inserting data into tables
CREATE PROCEDURE spins_AddStudents
  @studentId NVARCHAR(10),
  @firstName NVARCHAR(10),
  @lastName NVARCHAR(10),
  @dateOfBirth NVARCHAR(10),
  @programId INT = NULL
AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO Students
  VALUES
  (@studentId, @firstName, @lastName, @dateOfBirth, @programId)
END
GO

-- Update SP
Alter PROCEDURE spins_AddStudents
  @firstName NVARCHAR(10),
  @lastName NVARCHAR(10),
 @dateOfBirth DATE = NULL,
  @studentId NVARCHAR(10),
  @programId INT = NULL
AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO Students
  VALUES
  (@firstName, @lastName, @dateOfBirth, @studentId, @programId)
END
GO


EXEC spins_AddStudents
  @firstName = 'Sarah',
  @lastName = 'Adams',
  @dateOfBirth = '1977-12-19',
  @studentId = 'PE456654', 
  @programId = 10
GO

INSERT INTO Students
VALUES 
('John','Thompson', '1988-11-05', 'IT967458', 13)
GO

SELECT *
FROM Students
GO

