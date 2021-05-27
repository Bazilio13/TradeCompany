CREATE PROCEDURE [dbo].[GetOrdersByID]
	@ID int
AS
	SELECT * from Orders as O
	join OrderLists as OL 
	on O.ID = OL.OrderID
	Where O.ID = @ID
