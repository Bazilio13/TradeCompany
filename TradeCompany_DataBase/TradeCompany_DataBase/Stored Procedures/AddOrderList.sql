CREATE PROCEDURE [TradeCompany_DataBase].[AddOrderList]
	@OrderID int,
	@ProductID int,
	@Amount int,
	@Price float
AS
	insert into OrderLists (OrderID, ProductID, Amount, Price)
	values
	(@OrderID, @ProductID, @Amount, @Price)
	Select SCOPE_IDENTITY()