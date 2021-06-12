CREATE PROCEDURE [TradeCompany_DataBase].[AddAddress]
	@ClientID int,
	@Address nvarchar(250)
AS
	insert into Addresses (ClientID, Address, isDeleted)
	values(@ClientID, @Address, 0)

	Select SCOPE_IDENTITY()

