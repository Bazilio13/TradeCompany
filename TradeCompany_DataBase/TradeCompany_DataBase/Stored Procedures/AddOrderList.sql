CREATE PROCEDURE [TradeCompany_DataBase].[AddOrderList]
	@OrderID int,
	@ProductID int,
	@Amount int,
	@Price float
AS
	insert into OrderLists values
	(@OrderID, @ProductID, @Amount, @Price)
	Select SCOPE_IDENTITY()