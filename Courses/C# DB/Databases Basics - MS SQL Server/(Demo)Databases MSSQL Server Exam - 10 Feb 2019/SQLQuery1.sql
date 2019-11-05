--CREATE DATABASE ColonialJourney 
--USE ColonialJourney 
--GO
--1. DDL (30 pts)
--CREATE TABLE Planets 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(30) NOT NULL
--)

--CREATE TABLE Spaceports
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(50) NOT NULL,
--	PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
--)

--CREATE TABLE Spaceships
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(50) NOT NULL,
--	Manufacturer VARCHAR(30) NOT NULL,
--	LightSpeedRate INT DEFAULT (0)

--)

--CREATE TABLE Colonists
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(20) NOT NULL,
--	LastName VARCHAR(20) NOT NULL,
--	Ucn VARCHAR(10) NOT NULL UNIQUE,
--	BirthDate DATE NOT NULL
--)

--CREATE TABLE Journeys
--(
--	Id INT PRIMARY KEY IDENTITY,
--	JourneyStart DATETIME NOT NULL,
--	JourneyEnd DATETIME NOT NULL,
--	Purpose VARCHAR(11) NOT NULL  CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
--	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
--	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
--)

--CREATE TABLE TravelCards
--(
--	Id INT PRIMARY KEY IDENTITY,
--	CardNumber VARCHAR(10) NOT NULL UNIQUE,
--	JobDuringJourney VARCHAR(8) NOT NULL  CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
--	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
--	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
	
--)



--ALTER TABLE Journeys 
--ADD CONSTRAINT 	CH_CheckInCheckOut CHECK (JourneyStart < JourneyEnd)


	--2. Insert
--SELECT * FROM Planets
--	INSERT INTO Planets([Name]) VALUES
--	('Mars'),
--	('Earth'),
--	('Jupiter'),
--	('Saturn')


--INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate) VALUES
--	('Golf',	'VW', 3),
--	('WakaWaka', 'Wakanda', 4),
--	('Falcon9', 'SpaceX', 1),
--	('Bed',	'Vidolov', 6)

	--3.UPDATE
--	SELECT * FROM Spaceships
--UPDATE Spaceships
--SET LightSpeedRate = LightSpeedRate + 1
--WHERE Id BETWEEN 8 AND 12
--4. DELETE

--SELECT  * FROM TravelCards
----ORDER BY JourneyStart



----04. Delete
--DELETE FROM TravelCards
--WHERE JourneyId IN (1,2,3)

--DELETE FROM Journeys
--WHERE Id IN (1,2,3)


--SELECT CardNumber, JobDuringJourney
-- FROM TraVelCards
-- ORDER BY CardNumber

--6.	Select all colonists
--Extract from the database, all colonists. Sort the results by first name, them by last name, and finally by id in ascending order.
--Required Columns
--•	Id
--•	FullName
--•	Ucn

--SELECT Id, FirstName + ' ' + LastName AS FullName, Ucn 
--FROM Colonists
--ORDER BY FirstName, LastName, Id

--7.
--SELECT id, CONVERT (varchar(10), JourneyStart, 103), CONVERT (varchar(10), JourneyEnd, 103)
--FROM Journeys
--WHERE Purpose = 'Military'
--ORDER BY JourneyStart ASC

--8.	Select all pilots
--Extract from the database all colonists, which have a pilot job. Sort the result by id, ascending.
--SELECT c.Id, c.FirstName + ' ' + c.LastName
-- FROM Colonists AS c
--	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
--	WHERE tc.JobDuringJourney = 'Pilot'
--	ORDER BY c.Id

--	9.	Count colonists
--Count all colonists that are on technical journey. 
--Required Columns
--•	Count

--09. Count Colonists 
--SELECT COUNT(c.id) AS Count
--FROM Colonists AS c
--JOIN TravelCards AS tc ON c.id = tc.ColonistId
--JOIN Journeys AS j ON tc.JourneyId = j.id
--WHERE j.Purpose = 'Technical';

--10.	Select the fastest spaceship
--Extract from the database the fastest spaceship and its destination spaceport name. In other words, the ship with the highest light speed rate.
--Required Columns
--•	SpaceshipName
--•	SpaceportName

--SELECT * FROM Journeys
--SELECT * FROM Spaceports

--SELECT TOP(1) ss.[Name], sp.Name
--FROM Spaceships AS ss
--JOIN Journeys AS j ON ss.Id = j.SpaceshipId
--JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
--ORDER BY LightSpeedRate DESC

--11.	Select spaceships with pilots younger than 30 years
--Extract from the database those spaceships, which have pilots, younger than 30 years old. In other words, 30 years from 01/01/2019. Sort the results alphabetically by spaceship name.
--Required Columns
--•	Name
--•	Manufacturer

--SELECT * FROM TravelCards
--SELECT * FROM Spaceports

--SELECT s.Name, s.Manufacturer
--FROM Colonists c
--JOIN TravelCards tc ON tc.ColonistId = c.id
--JOIN Journeys j on tc.JourneyId = j.id
--JOIN Spaceships s on j.SpaceshipId = s.id
--WHERE DATEDIFF(YEAR, c.Birthdate, '01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
--ORDER BY s.Name

--12.	Select all educational mission planets and spaceports
--Extract from the database names of all planets and their spaceports, which have educational missions. Sort the results by spaceport name in descending order.
--Required Columns
--•	PlanetName
--•	SpaceportName

--SELECT * FROM Journeys
--SELECT * FROM Spaceports
--SELECT p.[Name], sp.Name
--FROM Planets AS p
--JOIN Spaceports sp ON p.Id = sp.PlanetId
--JOIN Journeys j on j.DestinationSpaceportId = sp.Id
--WHERE j.Purpose = 'Educational'
--ORDER BY sp.[Name] DESC

--13.
--SELECT p.[Name], COUNT(j.JourneyStart) AS JourneysCount
--FROM Planets AS p
--JOIN Spaceports sp ON p.Id = sp.PlanetId
--JOIN Journeys j on j.DestinationSpaceportId = sp.Id
--GROUP BY p.[Name]
--ORDER By JourneysCount DESC, p.[Name]


--14.

--SELECT TOP (1) j.Id, p.[Name], sp.[Name], j.Purpose
--FROM Journeys AS j
--JOIN Spaceports sp ON j.DestinationSpaceportId = sp.Id
--JOIN Planets AS p ON sp.PlanetId = p.Id
--ORDER BY j.JourneyEnd - j.JourneyStart DESC

--15

--14.

--SELECT TOP (1) j.Id, tc.JobDuringJourney
--FROM Journeys AS j
--JOIN TravelCards tc ON j.Id = tc.JourneyId
--ORDER BY j.JourneyEnd - j.JourneyStart DESC
--select * from 
--(
--16. Select Special Colonists
--SELECT k.JobDuringJourney, c.FirstName + ' ' + c.LastName AS FullName, k.JobRank
--  FROM (
--  SELECT tc.JobDuringJourney AS JobDuringJourney, tc.ColonistId,
--DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY co.Birthdate ASC) AS JobRank
--  FROM TravelCards AS tc
--  JOIN Colonists AS co ON co.Id = tc.ColonistId
--  GROUP BY tc.JobDuringJourney, co.Birthdate, tc.ColonistId
--  ) AS k
--  JOIN Colonists AS c ON c.Id = k.ColonistId
--  WHERE k.JobRank = 2
--  ORDER BY k.JobDuringJourney


--17

--SELECT p.[Name], Count(sp.Name) AS CountPlanets
--FROM Planets AS p
--LEFT JOIN Spaceports sp ON p.Id = sp.PlanetId
--GROUP BY p.[Name]
--ORDER BY Count(sp.Name) DESC, p.[Name]


--18


  CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Journeys AS j
	JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
	JOIN Planets AS p ON p.Id = s.PlanetId
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
	WHERE p.Name = @PlanetName)
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')