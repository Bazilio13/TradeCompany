CREATE PROCEDURE [TradeCompany_DataBase].[GetOrdersByParams]
	@ClientsID int,
	@MinDateTime DateTime,
	@MaxDateTime DateTime,
	@AddressID int
AS
	SELECT * from Orders as O
	join OrderLists as OL 
	on O.ID = OL.OrderID
	Where 
	(@ClientsID IS NULL OR O.ClientsID = @ClientsID) AND
	(@AddressID IS NULL OR O.AddressID = @AddressID) AND
	(@MinDateTime IS NULL OR O.DateTime >= @MinDateTime) AND
	(@MinDateTime IS NULL OR O.DateTime <= @MinDateTime)
