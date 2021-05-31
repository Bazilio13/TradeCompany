CREATE PROCEDURE [TradeCompany_DataBase].[GetProductGroupByID]
	@ProductGroupID int
AS
	select PG.ID, PG.Name, P.ID, P.Name, P.StockAmount, P.MeasureUnit, P.MinPrice, P.MaxPrice, P.LastSupplyDate
	from ProductGroups as PG
	left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on PG.ID = P_PG.ProductGroupID
	left join [TradeCompany_DataBase].[Products] as P on P.ID = P_PG.ProductID
	where PG.ID = @ProductGroupID