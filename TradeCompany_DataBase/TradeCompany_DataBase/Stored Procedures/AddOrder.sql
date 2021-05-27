CREATE PROCEDURE [TradeCompany_DataBase].[AddOrder]
	@ClientsID int,
	@Datetime datetime,
	@AddressID int,
	@Comment nvarchar(500)
AS
	insert into Orders (ClientsID, Datetime,  AddressID, Comment)
	values (@ClientsID, @Datetime,  @AddressID, @Comment)

	Select SCOPE_IDENTITY()