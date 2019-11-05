--15. Top Order per Employee

--SELECT k.[Full Name], DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, k.TotalPrice
--FROM (
--SELECT o.Id AS OrderID, e.Id AS EmploeeyId, o.[DateTime], e.FirstName + ' ' + e.LastName AS [Full Name], SUM(oi.Quantity * i.Price) AS TotalPrice,
--ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price) DESC) AS RowNumber
--FROM Employees AS e
--JOIN Orders AS o ON e.Id = o.EmployeeId
--JOIN OrderItems AS oi ON o.Id = oi.OrderId
--JOIN Items AS i ON oi.ItemId = i.Id
--GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.[DateTime]
--) AS k
--JOIN Shifts AS s ON k.EmploeeyId = s.EmployeeId
--WHERE RowNumber = 1 AND k.[DateTime] BETWEEN s.CheckIn AND s.CheckOut
--ORDER BY k.[Full Name], DATEDIFF(HOUR, s.CheckIn, s.CheckOut) DESC,k.TotalPrice DESC


--16. Average Profit per Day

--SELECT DATEPART(DAY, o.[DateTime]) AS [Day], FORMAT(AVG(oi.Quantity * i.Price), 'N2') AS AveragePrice
--FROM Orders AS o
--JOIN OrderItems AS oi ON o.Id = oi.OrderId
--JOIN Items AS i ON oi.ItemId = i.Id
--GROUP BY DATEPART(DAY, o.[DateTime])
--ORDER BY [Day]


--17. Top Products

--SELECT i.[Name] AS Item, c.[Name] AS Category, SUM(oi.Quantity) AS [Count], SUM(i.Price * oi.Quantity) AS TotalPrice
--FROM Items AS i
--	JOIN Categories AS c ON i.CategoryId = c.Id
--	LEFT JOIN OrderItems AS oi ON i.Id = oi.ItemId
--GROUP BY i.[Name], c.[Name]
--ORDER BY TotalPrice DESC, [Count] DESC


----18 Promotion day
--CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
--RETURNS VARCHAR(80)
--AS
--BEGIN
--	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
--	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
--	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

--	IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
--	BEGIN
--	 RETURN 'One of the items does not exists!'
--	END

--	IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
--	BEGIN
--	 RETURN 'The current date is not within the promotion dates!'
--	END

--	DECLARE @NewFirstItemPrice DECIMAL(15,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
--	DECLARE @NewSecondItemPrice DECIMAL(15,2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
--	DECLARE @NewThirdItemPrice DECIMAL(15,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100)

--	DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
--	DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
--	DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

--	RETURN @FirstItemName + ' price: ' + CAST(ROUND(@NewFirstItemPrice,2) as varchar) + ' <-> ' +
--		   @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondItemPrice,2) as varchar)+ ' <-> ' +
--		   @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
--END

--19

--CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATE)
--AS
--BEGIN
--	DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
--	DECLARE  @IssueDate DATE = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

--	IF (@order IS NULL)
--	BEGIN
--		;THROW 51000, 'The order does not exist!', 1
--	END

--	IF (DATEDIFF(DAY, @IssueDate,  @CancelDate) > 3)
	
--	BEGIN
--		;THROW 51000, 'You cannot cancel the order!', 2
--	END

--	DELETE FROM OrderItems
--	WHERE OrderId = @OrderId

--	DELETE FROM Orders
--	WHERE Id = @OrderId
--END

--EXEC usp_CancelOrder 1, '2018-06-02'
--SELECT COUNT(*) FROM Orders
--SELECT COUNT(*) FROM OrderItems


--20

CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)


CREATE TRIGGER t_DeletedOrders
    ON OrderItems AFTER DELETE
    AS
    BEGIN
	  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	  SELECT d.OrderId, d.ItemId, d.Quantity
	    FROM deleted AS d
    END


	DELETE FROM OrderItems
WHERE OrderId = 5

DELETE FROM Orders
WHERE Id = 5 
