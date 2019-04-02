----DROP DATABASE TripService

----CREATE DATABASE TripService
------GO

----USE TripService
------GO

--CREATE TABLE Cities
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] NVARCHAR(20) NOT NULL,
--	CountryCode CHAR(2) NOT NULL
--)

--CREATE TABLE Hotels
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] NVARCHAR(30) NOT NULL,
--	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
--	EmployeeCount INT NOT NULL,
--	BaseRate DECIMAL(15,2) 
--)

--CREATE TABLE Rooms
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Price DECIMAL(15,2) NOT NULL,
--	[Type] NVARCHAR(20) NOT NULL,
--	Beds INT Not Null,
--	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
--)

--CREATE TABLE Trips
--(
--	Id INT PRIMARY KEY IDENTITY,
--	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
--	BookDate DATETIME NOT NULL,
--	ArrivalDate DATETIME NOT NULL,
--	ReturnDate DATETIME NOT NULL,
--	CancelDate DATETIME,
--	 CONSTRAINT CHK_CheckDate1 CHECK(BookDate < ArrivalDate),
--	 CONSTRAINT CHK_CheckDate3 CHECK(ArrivalDate < ReturnDate)
--)

--CREATE TABLE Accounts
--(
--	Id INT PRIMARY KEY IDENTITY NOT NULL,
--	FirstName NVARCHAR(50) NOT NULL,
--	MiddleName NVARCHAR(20),
--	LastName NVARCHAR(50) NOT NULL,
--	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
--	BirthDate DATE NOT NULL,
--	Email NVARCHAR(100) UNIQUE NOT NULL,
--)

--CREATE TABLE AccountsTrips
--(
--	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
--	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
--	Luggage INT Not Null CHECK(Luggage >= 0)
--	PRIMARY KEY(AccountId, TripId)
--)





----2. Insert 
--INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES

--('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
--('Gosho', NULL,	'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
--('Ivan','Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
--('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

--INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES

--(101, '2015-04-12',	'2015-04-14', '2015-04-20',	'2015-02-02'),
--(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
--(103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
--(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10'),
--(109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)

--SELECT *
--FROM Accounts

--3. Update

--UPDATE Rooms
--		SET Price = Price * 1.14
--		WHERE HotelId IN (5, 7, 9)

--4. Delete

--DELETE FROM AccountsTrips 
--		WHERE AccountId = 47

--5. Bulgarian Cities

--SELECT id, [Name] 
--FROM Cities
--WHERE CountryCode = 'BG'
--ORDER BY [Name]


--6. People Born After 1991

--SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName, DATEPART(YEAR, BirthDate) AS  BirthYear
--FROM Accounts
--WHERE DATEPART(YEAR, BirthDate)> 1991
--ORDER by BirthYear DESC, FirstName

--7. EEE-Mails

--SELECT a.FirstName, a.LastName, CONVERT(VARCHAR(10),  a.BirthDate, 110), c.[Name], a.Email
--FROM Accounts AS a
--JOIN Cities AS c ON a.CityId = c.Id
--WHERE (a.Email LIKE 'e%')
--ORDER BY c.[Name] DESC

--8
--SELECT c.[Name], COUNT(h.Id) 
--FROM Cities AS c
--LEFT JOIN Hotels AS h ON c.Id = h.CityId
--GROUP BY c.[Name]
--ORDER BY COUNT(h.Id)  DESC, c.[Name]
	
--9

--SELECT r.Id, r.Price, h.[Name], c.[Name] FROM Rooms AS r
-- JOIN Hotels AS h ON r.HotelId = h.Id
--RIGHT JOIN Cities AS c ON h.CityId = c.Id
--WHERE r.Type = 'First Class'
--ORDER BY r.Price DESC, r.Id

--10

--SELECT a.Id, a.FirstName + ' ' + a.LastName,
--MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongStay,
--MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate))
--FROM Accounts AS a
--JOIN AccountsTrips AS atr ON a.Id = atr.AccountId
--JOIN Trips AS t ON atr.TripId = t.Id
--WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
--GROUP BY a.Id, a.FirstName, a.LastName
--ORDER BY LongStay DESC, a.Id


--11. Metropolis

--SELECT TOP (5) c.Id, c.[Name], c.CountryCode, COUNT(a.FirstName)
--FROM Cities AS c
--JOIN Accounts AS a ON c.Id = a.CityId
--GROUP BY c.Id, c.[Name], c.CountryCode
--ORDER BY COUNT(a.FirstName) DESC


--12. Romantic Getaways

--SELECT a.Id, a.Email, c.[Name], COUNT(t.Id)
--FROM Accounts AS a
--JOIN AccountsTrips AS ac ON a.Id = ac.AccountId
--JOIN Trips AS t ON ac.TripId = t.Id
--JOIN Rooms AS r ON t.RoomId = r.Id
--JOIn Hotels AS h On r.HotelId = h.Id
--JOIN Cities AS c ON a.CityId = c.Id
--WHERE a.CityId = h.CityId
--GROUP BY a.Id, a.Email, c.[Name]
--ORDER BY COUNT(t.Id) DESC, a.Id

--13

--SELECT TOP (10) c.Id, c.[Name], SUM(h.BaseRate + r.Price) AS Revenue, COUNT(t.Id) AS TCount
--FROM Cities AS c
--JOIN Hotels AS h ON c.Id = h.CityId
--JOIN Rooms AS r ON h.Id = r.HotelId
--JOIN Trips AS t ON r.Id = t.RoomId
----JOIN AccountsTrips AS actr ON t.Id = actr.TripId
--WHERE DATEPART(YEAR, t.BookDate) = 2016
--GROUP BY c.Id, c.[Name]
--ORDER BY Revenue DESC, TCount DESC

--14. Trip Revenues
--Find all trips’ revenue (hotel base rate + room price). If a trip is canceled, its revenue is always 0. Extract the trip’s ID, the hotel’s name, the room type and the revenue.
--Order the results by Room type, then by the Trip ID.

--SELECT t.Id, h.[Name], r.[Type],
--CASE 
--WHEN t.CancelDate IS NULL THEN SUM(h.BaseRate + r.Price)
--ELSE 0.00
--END AS Revenue
--FROM Trips AS t
--JOIN AccountsTrips AS actr ON t.Id = actr.TripId
--JOIN Rooms AS r ON t.RoomId = r.Id
--JOIN Hotels AS h ON r.HotelId = h.Id
--GROUP BY t.Id, h.[Name], r.[Type], t.CancelDate
--ORDER BY r.[Type], t.Id

--15

--16. Luggage Fees

--SELECT t.Id, SUM(ac.Luggage) AS Luggages, '$' + CONVERT(VARCHAR(10), SUM(Luggage) *
--  CASE WHEN SUM(Luggage) > 5
--  THEN 5
--  ELSE 0 END) AS Fee
--FROM Trips AS t
--JOIN AccountsTrips AS ac ON t.Id = ac.TripId 
--GROUP BY t.Id
--HAVING SUM(ac.Luggage) > 0
--ORDER BY SUM(ac.Luggage) DESC


--17. GDPR Violation

--SELECT t.Id, a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS FullName, ca.[Name] AS [From], c.[Name] AS [To],
--CASE WHEN t.CancelDate IS NOT NULL
--    THEN 'Canceled'
--  ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
--  END   

--FROM Trips AS t
--JOIN AccountsTrips AS act ON t.Id = act.TripId
--JOIN Accounts AS a On act.AccountId = a.Id
--JOIN Cities AS ca on a.CityId = ca.Id
--JOIN Rooms AS r ON t.RoomId = r.Id
--JOIN Hotels AS h ON r.HotelId = h.Id
--JOIN Cities c on h.CityId = c.Id
--ORDER BY FullName, t.id

--18. Available Room