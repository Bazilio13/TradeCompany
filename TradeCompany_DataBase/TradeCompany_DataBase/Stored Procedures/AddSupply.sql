CREATE PROCEDURE [TradeCompany_DataBase].[AddSupply]
	@Datetime datetime
AS
	insert into Supplies (Datetime)
	values(@Datetime)