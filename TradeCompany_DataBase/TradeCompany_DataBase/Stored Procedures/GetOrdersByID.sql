CREATE PROCEDURE [TradeCompany_DataBase].[GetOrdersByID]
	@ID int
AS
	SELECT * from Orders as O
	left join OrderLists as OL 
	on O.ID = OL.OrderID
	Where O.ID = @ID