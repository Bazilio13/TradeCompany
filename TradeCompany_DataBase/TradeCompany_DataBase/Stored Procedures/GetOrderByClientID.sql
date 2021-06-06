CREATE PROCEDURE [TradeCompany_DataBase].[GetOrderByClientID]
	@ID int
AS
	SELECT O.ID, O.ClientsID, A.Address, O.DateTime, O.Comment
	from TradeCompany_DataBase.Orders as O
	Left join TradeCompany_DataBase.Addresses as A on A.ID = o.AddressID
	where ClientsID = @ID
	order by o.DateTime desc