CREATE PROCEDURE [TradeCompany_DataBase].[DeleteOrderListByID]
	@ID int
AS
	delete OrderLists
	where OrderID = @ID