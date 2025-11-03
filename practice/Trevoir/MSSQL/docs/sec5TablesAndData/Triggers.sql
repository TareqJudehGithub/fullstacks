-- Triggers
 -- An piece of code that runs automatically against a table,
 -- whenever an action occurs against the data.
 -- Triggers are good for auditing tables.
 USE SchoolManagementDB
 GO

 CREATE TRIGGER AssignProgramOfStudyId
  ON Students
  AFTER INSERT
 AS
 BEGIN
  DECLARE @programId int  
  DECLARE @id int
  SELECT @programId = ProgramOfStudyId from inserted

  IF @programId IS NULL
  BEGIN
    UPDATE Students 
    SET ProgramOfStudyId = 6
    WHERE Id = @Id
  END 

 END
 GO


 EXEC spins_AddStudents
  @firstName = 'Brat',
  @lastName = 'Sandro',
  @dateOfBirth = '1983-08-24',
  @studentId = 'DB329875', 
  @programId = 9
GO

EXEC sp_SelectStudentById @id