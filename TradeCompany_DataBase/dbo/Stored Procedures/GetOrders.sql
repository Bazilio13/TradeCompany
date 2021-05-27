CREATE PROCEDURE dbo.GetOrders
AS
	SELECT * from Orders as O
	join OrderLists as OL 
	on o.ID = OL.OrderID
