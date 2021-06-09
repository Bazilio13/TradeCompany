CREATE PROCEDURE [TradeCompany_DataBase].[UpdateSupplyByID]
	@ID int,
	@Datetime datetime,
	@Comment nvarchar(500)
AS
	update S 
	set 
	Datetime = @Datetime,
	Comment = @Comment
	from Supplies as S
	where S.ID = @ID
