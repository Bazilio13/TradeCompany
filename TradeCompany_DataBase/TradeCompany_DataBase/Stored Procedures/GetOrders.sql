CREATE PROCEDURE [TradeCompany_DataBase].[GetOrders]
AS
	SELECT * from Orders as O
	left join OrderLists as OL 
	on o.ID = OL.OrderID