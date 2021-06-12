CREATE PROCEDURE [TradeCompany_DataBase].[GetAllAddressesByClientID]
	@ClientID int
	as
	select Address from Addresses
	where Addresses.ClientID = @ClientID
