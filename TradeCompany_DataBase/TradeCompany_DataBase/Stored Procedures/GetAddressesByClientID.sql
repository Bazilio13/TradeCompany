CREATE PROCEDURE [TradeCompany_DataBase].[GetAddressesByClientID]
	@ClientID int
	as
	select ID ,ClientID, Address   from Addresses 
	where Addresses.ClientID = @ClientID --and (isDeleted = 0 or isDeleted = null)