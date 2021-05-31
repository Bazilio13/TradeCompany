create procedure [TradeCompany_DataBase].[GetProductByLetter]
@InputString nvarchar (50)
as
select P.ID, P.Name, P.StockAmount, P.MeasureUnit, P.MinPrice, P.MaxPrice, P.LastSupplyDate, PG.ID, PG.Name as [Group]
from Products as P
left join [TradeCompany_DataBase].[Product_ProductGroups] as P_PG on P.ID = P_PG.ProductID
left join [TradeCompany_DataBase].[ProductGroups] as PG on PG.ID = P_PG.ProductGroupID
where P.Name like '%' + @InputString + '%'