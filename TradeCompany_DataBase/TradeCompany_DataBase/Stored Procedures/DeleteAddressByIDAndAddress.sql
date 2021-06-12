CREATE PROCEDURE [TradeCompany_DataBase].[DeleteAddressByIDAndAddress]
	@ClientID int,
	@Address nvarchar(250)
AS
	update [Addresses] set isDeleted = 1
	where Addresses.ClientID = @ClientID and Addresses.Address = @Address
