CREATE PROCEDURE [TradeCompany_DataBase].[GetOrdersByParams]
	@ClientsID int,
	@MinDateTime DateTime,
	@MaxDateTime DateTime,
	@AddressID int,
	@ProductID int
AS
	SELECT * from Orders as O
	left join OrderLists as OL 
	on O.ID = OL.OrderID
	Where 
	(@ClientsID IS NULL OR O.ClientsID = @ClientsID) AND
	(@AddressID IS NULL OR O.AddressID = @AddressID) AND
	(@ProductID IS NULL OR OL.ProductID = @ProductID) AND
	(@MinDateTime IS NULL OR O.DateTime >= @MinDateTime) AND
	(@MaxDateTime IS NULL OR O.DateTime <= @MaxDateTime) 