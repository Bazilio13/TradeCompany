CREATE PROCEDURE [TradeCompany_DataBase].[GetSupplyByID]
	@ID int
AS
	SELECT * from TradeCompany_DataBase.Supplies as S
	left join TradeCompany_DataBase.SupplyLists as SL 
	on S.ID = SL.SupplyID
	Where S.ID = @ID