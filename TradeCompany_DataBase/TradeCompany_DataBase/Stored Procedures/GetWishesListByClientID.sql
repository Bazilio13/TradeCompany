CREATE PROCEDURE [TradeCompany_DataBase].[GetWishesListByClientID]
	@ClientID int
AS
	select P.Name, P.ID
	from TradeCompany_DataBase.Wishes as W
	left join [TradeCompany_DataBase].Products as P on W.ProductsID = P.ID
	where W.ClientsID = @ClientID
