CREATE PROCEDURE [TradeCompany_DataBase].[DeleteAllAddressesByID]
	@ClientID int
AS
	delete [Addresses]
	where Addresses.ClientID = @ClientID 