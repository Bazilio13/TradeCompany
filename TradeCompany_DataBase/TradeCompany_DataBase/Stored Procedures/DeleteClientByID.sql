CREATE PROCEDURE [TradeCompany_DataBase].[DeleteClientByID]
	@ClientID int
AS
	delete [Clients]
	where Clients.ID = @ClientID
