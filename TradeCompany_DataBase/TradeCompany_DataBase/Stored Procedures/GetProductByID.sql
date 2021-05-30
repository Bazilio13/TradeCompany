CREATE PROCEDURE [TradeCompany_DataBase].[GetProductByID]
	@ProductId int
AS
	select P.ID, P.Name, P.StockAmount, P.MeasureUnit, P.MinPrice, P.MaxPrice, P.LastSupplyDate, PG.ID, PG.Name as [Product group]
	from Products as P
	left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on P.ID = P_PG.ProductID
	left join [TradeCompany_DataBase].[ProductGroups] as PG on PG.ID = P_PG.ProductGroupID
	where P.ID = @ProductId