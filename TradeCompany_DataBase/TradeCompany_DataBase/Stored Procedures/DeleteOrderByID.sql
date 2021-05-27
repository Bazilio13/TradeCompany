CREATE PROCEDURE [TradeCompany_DataBase].[DeleteOrderByID]
	@ID int
AS
	Delete Orders
	Where ID = @ID
	delete OrderLists
	where OrderID = @ID