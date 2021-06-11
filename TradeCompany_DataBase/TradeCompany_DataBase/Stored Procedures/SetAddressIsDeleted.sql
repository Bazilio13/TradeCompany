CREATE PROCEDURE [TradeCompany_DataBase].[SetAddressIsDeleted]
	@ClientID int,
	@Address nvarchar(250),
	@isDeleted bit
AS
	UPDATE TradeCompany_Database.Addresses Set isDeleted = @isDeleted
	output INSERTED.ID 
	where ClientID = @ClientID and Address = @Address