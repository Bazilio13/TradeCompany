CREATE PROCEDURE [TradeCompany_DataBase].[GetProductsByOrderId]

@OrderId int
as
select ol.ProductID, p.[Name], p.MeasureUnit, ol.Amount, ol.Price, pg.[Name] as ProductGroupName
from TradeCompany_DataBase.OrderLists ol
inner join TradeCompany_DataBase.Products p on p.ID = ol.ProductID
inner join TradeCompany_DataBase.Product_ProductGroups ppg on ppg.ProductID = ol.ProductID
inner join TradeCompany_DataBase.ProductGroups pg on pg.ID =ppg.ProductGroupID
where OrderId = @OrderId
