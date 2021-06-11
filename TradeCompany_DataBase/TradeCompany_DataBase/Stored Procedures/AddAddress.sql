CREATE PROCEDURE [TradeCompany_DataBase].[AddAddress]
	@ClientID int,
	@Address nvarchar(250)
AS
	insert into Addresses (ClientID, Address)
	values(@ClientID, @Address)
	DECLARE @lastID int
	SELECT @lastID = max(ID) from Addresses
	RETURN @lastID;