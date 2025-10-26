USE SchoolManagementDB
GO


INSERT INTO Lecturers
VALUES 
('Delete', 'Me', '1900-01-01', 1009)
GO

-- DELETE rows in a table
DELETE 
FROM Lecturers
WHERE FirstName = 'Delete' AND LastName = 'Me'
GO


SELECT *
FROM Lecturers
GO