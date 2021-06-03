create procedure [TradeCompany_DataBase].DeleteGroupFromProduct
@ProductID int, 
@ProductGroupId int
as
delete from [Product_ProductGroups]
where Product_ProductGroups.ProductGroupID = @ProductGroupID 
AND Product_ProductGroups.ProductID = @ProductID 
