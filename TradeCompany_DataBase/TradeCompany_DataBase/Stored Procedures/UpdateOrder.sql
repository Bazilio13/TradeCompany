CREATE PROCEDURE [TradeCompany_DataBase].[UpdateOrder]
	@ID int,
	@ClientsID int,
	@Datetime datetime,
	@AddressID int,
	@Comment nvarchar(500)
AS
	update O 
	set 
	ClientsID = @ClientsID, 
	DateTime = @Datetime,
	AddressID = @AddressID,
	Comment = @Comment
	from [TradeCompany_DataBase].Orders as O

where o.ID = @ID