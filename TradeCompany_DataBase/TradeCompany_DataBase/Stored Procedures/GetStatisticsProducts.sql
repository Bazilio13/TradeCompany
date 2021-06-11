CREATE PROCEDURE [TradeCompany_DataBase].[GetStatisticsProducts]

AS
	select  PG.ID, PG.Name as CategoryName, sum(OL.Amount*OL.Price) as Summ, 
	MAX(P.LastSupplyDate) as LastSupplyDate, MAX(O.DateTime) as LastOrderDate
	from TradeCompany_DataBase.ProductGroups as PG 
	left join TradeCompany_DataBase.Product_ProductGroups as PPG on PPG.ProductGroupID = PG.ID
	left join TradeCompany_DataBase.Products as P on PPG.ProductID = p.ID
	left join TradeCompany_DataBase.OrderLists as OL on OL.ProductID = P.ID
	left join TradeCompany_DataBase.Orders as O on OL.OrderID=O.ID
	group by PPG.ProductGroupID, PG.Name,  PG.ID
	order by summ desc