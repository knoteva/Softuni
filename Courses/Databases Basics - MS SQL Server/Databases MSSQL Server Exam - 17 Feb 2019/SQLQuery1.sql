------DROP DATABASE School

----CREATE DATABASE School
--------GO

------USE School
--------GO

--CREATE TABLE Students 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(30) NOT NULL,
--	MiddleName NVARCHAR(25),
--	LastName NVARCHAR(30) NOT NULL,
--	Age INT NOT NULL CHECK(Age BETWEEN 5 AND 100),
--	[Address] NVARCHAR(50),
--	Phone CHAR(10)
--)

--CREATE TABLE Subjects 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] NVARCHAR(20) NOT NULL,
--	Lessons INT NOT NULL CHECK(Lessons > 0)
--)

--CREATE TABLE StudentsSubjects 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
--	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
--	Grade DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
--)

--CREATE TABLE Exams 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Date] DATETIME,
--	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
--)


--CREATE TABLE StudentsExams
--(
--	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
--	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
--	Grade DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6),
--	PRIMARY KEY(StudentId, ExamId)
--)

--CREATE TABLE Teachers 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(20) NOT NULL,
--	LastName NVARCHAR(20) NOT NULL,
--	[Address] NVARCHAR(20) NOT NULL,
--	Phone CHAR(10),
--	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
--)

--CREATE TABLE StudentsTeachers
--(
--	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
--	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
--	PRIMARY KEY(StudentId, TeacherId)
--)

--2 Insert
--INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId) VALUES
--    ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146',	6),
--	('Gerrard',	'Lowin', '370 Talisman Plaza', '3324874824', 2),
--	('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154',	5),
--	('Bert', 'Ivie', '2 Gateway Circle', '4409584510',	4)

--INSERT INTO Subjects([Name], Lessons) VALUES
--	('Geometry', 12),
--	('Health', 10),
--	('Drama', 7),
--	('Sports', 9)

--03. Update
--UPDATE StudentsSubjects
--SET Grade = 6.00
--WHERE SubjectId IN (1, 2) AND Grade >=5.50

--SELECT ss.Grade, se.Grade FROM StudentsExams AS se
--JOIN Exams AS e ON se.ExamId = e.Id
--JOIN Subjects AS s ON e.SubjectId = s.Id
--JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId

--04. Delete

--DELETE FROM StudentsTeachers
--WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')


--5. Teen Students

--SELECT FirstName, LastName, Age FROM Students
--WHERE Age >= 12
--ORDER BY FirstName, LastName

--6. Cool Addresses

--SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', ' ') + LastName, [Address]
--FROM Students
--WHERE [Address] LIKE '%road%'
--ORDER by FirstName, LastName, [Address]


--7. 42 Phones
--SELECT FirstName, [Address], Phone
--FROM Students
--WHERE MiddleName IS NOT NUll AND Phone LIKE '42%'
--ORDER by FirstName


--8. Students Teachers
--SELECT FirstName, LastName, COUNT(st.TeacherId) AS TeachersCount
--FROM Students AS s
--JOIN StudentsTeachers AS st ON s.Id = st.StudentId
--GROUP BY  FirstName, LastName


--9. Subjects with Students

--SELECT t.FirstName + ' ' + t.LastName AS FullName, s.[Name] + '-' + CAST(s.Lessons AS varchar) AS Subjects, COUNT(st.StudentId) AS Students
--FROM Teachers AS t
--JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
--JOIN Subjects AS s ON t.SubjectId = s.Id
--GROUP BY  t.FirstName, t.LastName, s.Lessons, s.[Name]
--ORDER by Students DESC, FullName, Subjects DESC


--10. Students to Go

--SELECT s.FirstName + ' ' + s.LastName AS FullName
--FROM Students AS s
--LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
--WHERE se.ExamId is NULL
--ORDER BY FullName

--11. Busiest Teachers

--SELECT TOP (10) t.FirstName, t.LastName, COUNT(st.StudentId) AS Students
--FROM Teachers AS t
--JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
--JOIN Subjects AS s ON t.SubjectId = s.Id
--GROUP BY  t.FirstName, t.LastName, s.Lessons, s.[Name]
--ORDER by Students DESC, t.FirstName


--12. Top Students

--SELECT TOP (10) s.FirstName, s.LastName, convert(numeric(10,2), AVG(se.Grade))
--FROM Students AS s
--JOIN StudentsExams AS se ON s.Id = se.StudentId
--GROUP BY s.FirstName, s.LastName
--ORDER BY AVG(se.Grade) DESC, FirstName, LastName


--13. Second Highest Grade
--SELECT k.FirstName, k.LastName, k.Grade
--  FROM (
--   SELECT s.FirstName, s.LastName, ss.Grade, 
--          ROW_NUMBER() OVER (PARTITION BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) AS RowNumber
--     FROM Students AS s
--	 JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
-- ) AS k
-- WHERE k.RowNumber = 2
-- ORDER BY k.FirstName, k.LastName


-- 14. Not So In The Studying

--SELECT  FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName  AS FullName
--FROM Students AS s
--LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
----JOIN Subjects AS sj ON ss.SubjectId = sj.Id
--WHERE ss.SubjectId IS NULL
--ORDER BY FullName



--15. Top Student per Teacher
SELECT j.[Teacher Full Name], j.SubjectName ,j.[Student Full Name], FORMAT(j.TopGrade, 'N2') AS Grade
  FROM (
SELECT k.[Teacher Full Name],k.SubjectName, k.[Student Full Name], k.AverageGrade  AS TopGrade,
	   ROW_NUMBER() OVER (PARTITION BY k.[Teacher Full Name] ORDER BY k.AverageGrade DESC) AS RowNumber
  FROM (
  SELECT t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
  	   s.FirstName + ' ' + s.LastName AS [Student Full Name],
  	   AVG(ss.Grade) AS AverageGrade,
  	   su.[Name] AS SubjectName
    FROM Teachers AS t 
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
    JOIN Students AS s ON s.Id = st.StudentId
    JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
    JOIN Subjects AS su ON su.Id = ss.SubjectId AND su.Id = t.SubjectId
GROUP BY t.FirstName, t.LastName, s.FirstName, s.LastName, su.[Name]
) AS k
) AS j
   WHERE j.RowNumber = 1 
ORDER BY j.SubjectName,j.[Teacher Full Name], TopGrade DESC



--16. Average Grade per Subject

--SELECT s.[Name], AVG(ss.Grade)
--FROM Subjects AS s
--JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
--GROUP BY s.[Name], s.Id
--ORDER BY s.Id


--17. Exams Information

--17. Exams Information 
--SELECT  k.Quarter, k.SubjectName, COUNT(k.StudentId) AS StudentsCount
--  FROM (
--  SELECT s.[Name] AS SubjectName, se.StudentId,
--		 CASE
--		 WHEN DATEPART(MONTH, Date) BETWEEN 1 AND 3 THEN 'Q1'
--		 WHEN DATEPART(MONTH, Date) BETWEEN 4 AND 6 THEN 'Q2'
--		 WHEN DATEPART(MONTH, Date) BETWEEN 7 AND 9 THEN 'Q3'
--		 WHEN DATEPART(MONTH, Date) BETWEEN 10 AND 12 THEN 'Q4'
--		 WHEN Date IS NULL THEN 'TBA'
--		 END AS [Quarter]
--    FROM Exams AS e
--	JOIN Subjects AS s ON s.Id = e.SubjectId 
--	JOIN StudentsExams AS se ON se.ExamId = e.Id
--	WHERE se.Grade >= 4
--) AS k
--GROUP BY k.Quarter, k.SubjectName
--ORDER BY k.Quarter


--18
--
--CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
--CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
--RETURNS VARCHAR(80)
--AS
--BEGIN
--	DECLARE @studentExist INT = (SELECT TOP(1) StudentId FROM StudentsExams WHERE StudentId = @studentId);
--	IF @studentExist IS NULL
--		BEGIN
--			RETURN ('The student with provided id does not exist in the school!')
--		END
--	IF @grade > 6.00
--		BEGIN
--			RETURN ('Grade cannot be above 6.00!')
--		END

--	DECLARE @studentFirstName NVARCHAR(20) = (SELECT TOP(1) FirstName FROM Students WHERE Id = @studentId);
--	DECLARE @biggestGrade DECIMAL(15,2) = @grade + 0.50;
--	DECLARE @count INT = (SELECT Count(Grade) FROM StudentsExams
--	WHERE StudentId = @studentId AND Grade >= @grade AND Grade <= @biggestGrade)
--	RETURN ('You have to update ' + CAST(@count AS nvarchar(10)) + ' grades for the student ' + @studentFirstName)
--END
	

--SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)


--19
--CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)

--CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
--AS
--BEGIN
--	--DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
--	DECLARE @Student INT = (SELECT Id FROM Students WHERE Id = @StudentId)

--	IF (@Student IS NULL)
--	BEGIN
--		;THROW 51000, 'This school has no student with the provided id!', 1
--	END

--	DELETE FROM StudentsSubjects
--	WHERE StudentId = @Student

--	DELETE FROM StudentsExams
--	WHERE StudentId = @Student

--	DELETE FROM StudentsTeachers
--	WHERE StudentId = @Student

--	DELETE FROM Students
--	WHERE Id = @StudentId

--END

--EXEC usp_ExcludeFromSchool 1
--SELECT COUNT(*) FROM Students

--20 
CREATE TABLE ExcludedStudents
(
	--OrderId INT,
	--ItemId INT,
	--ItemQuantity INT
	StudentId INT, 
	StudentName VARCHAR(110)

)


CREATE TRIGGER t_ExcludedStudents
    ON Students AFTER DELETE
    AS
    BEGIN
	  INSERT INTO ExcludedStudents (StudentId, StudentName)
	  SELECT d.Id, d.FirstName + ' ' + d.LastName
	    FROM deleted AS d
    END



