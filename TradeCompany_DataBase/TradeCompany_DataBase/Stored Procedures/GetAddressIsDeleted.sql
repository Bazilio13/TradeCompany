CREATE PROCEDURE [TradeCompany_DataBase].[GetAddressIsDeleted]
	@ClientID int,
	@Address nvarchar(250)
AS
	Select isDeleted from Addresses 
	where ClientID = @ClientID and Address = @Address
