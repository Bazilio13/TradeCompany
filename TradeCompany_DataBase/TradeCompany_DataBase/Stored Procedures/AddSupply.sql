CREATE PROCEDURE [TradeCompany_DataBase].[AddSupply]
	@Datetime DateTime,
	@Comment nvarchar(500)

AS
	insert into Supplies (DateTime, Comment)
	values(@Datetime, @Comment)

	Select SCOPE_IDENTITY()