create procedure [TradeCompany_DataBase].[GetProducts] --вместе с группами
as
select P.ID, P.Name, P.StockAmount, MU.Name as [MeasureUnitName], P.WholesalePrice, P.RetailPrice, P.LastSupplyDate, P.Description, P.Comments,PG.ID, PG.Name
from [TradeCompany_DataBase].Products as P
left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on P.ID = P_PG.ProductID
left join [TradeCompany_DataBase].[ProductGroups] as PG on PG.ID = P_PG.ProductGroupID
left join [TradeCompany_DataBase].MeasureUnits as MU on MU.ID = P.MeasureUnit
where P.IsDeleted = 0