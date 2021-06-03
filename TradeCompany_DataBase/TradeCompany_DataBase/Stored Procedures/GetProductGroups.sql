CREATE PROCEDURE [TradeCompany_DataBase].[GetProductGroups]
AS
	select PG.ID, PG.Name, P.ID, P.Name, P.StockAmount, P.MeasureUnit, P.WholesalePrice, P.RetailPrice, P.LastSupplyDate, P.Description, P.Comments
	from ProductGroups as PG
	left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on PG.ID = P_PG.ProductGroupID
	left join [TradeCompany_DataBase].[Products] as P on P.ID = P_PG.ProductID
