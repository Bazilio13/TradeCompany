CREATE PROCEDURE [TradeCompany_DataBase].[GetAddressesByClientID]
	@ClientID int
	as
	select Address from Addresses
	where Addresses.ClientID = @ClientID