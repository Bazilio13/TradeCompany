﻿CREATE PROCEDURE [TradeCompany_DataBase].[GetProductGroups]
AS
	select PG.ID, PG.Name as [Product group], P.ID, P.Name, P.StockAmount, P.MeasureUnit, P.MinPrice, P.MaxPrice, P.LastSupplyDate
	from ProductGroups as PG
	left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on PG.ID = P_PG.ProductGroupID
	left join [TradeCompany_DataBase].[Products] as P on P.ID = P_PG.ProductID