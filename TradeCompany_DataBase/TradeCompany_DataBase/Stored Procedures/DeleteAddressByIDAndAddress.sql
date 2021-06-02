CREATE PROCEDURE [TradeCompany_DataBase].[DeleteAddressByIDAndAddress]
	@ClientID int,
	@Address nvarchar(250)
AS
	delete [Addresses]
	where Addresses.ClientID = @ClientID and Addresses.Address = @Address
