CREATE PROCEDURE [TradeCompany_DataBase].[SoftDeleteOrderByID]
	@ID int
AS
	delete [TradeCompany_DataBase].OrderLists
	where OrderLists.OrderID = @ID
	update O 
	set 
	IsDeleted = 1
	from [TradeCompany_DataBase].Orders as O
	where o.ID = @ID