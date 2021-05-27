CREATE PROCEDURE [dbo].[DeleteOrderListByID]
	@ID int
AS
	delete OrderLists
	where OrderID = @ID
