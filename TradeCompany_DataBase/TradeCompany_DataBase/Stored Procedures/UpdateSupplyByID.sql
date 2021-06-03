CREATE PROCEDURE [TradeCompany_DataBase].[UpdateSupplyByID]
	@ID int,
	@Datetime datetime
AS
	update S 
	set 
	Datetime = @Datetime
	from Supplies as S
	where S.ID = @ID
