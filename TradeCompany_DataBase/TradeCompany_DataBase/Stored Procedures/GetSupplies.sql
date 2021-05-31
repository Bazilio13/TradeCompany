CREATE PROCEDURE [TradeCompany_DataBase].[GetSupplies]
AS
	SELECT * from TradeCompany_DataBase.Supplies as S
	left join TradeCompany_DataBase.SupplyLists as SL 
	on s.ID = SL.SupplyID