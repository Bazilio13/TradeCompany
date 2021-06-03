CREATE PROCEDURE [TradeCompany_DataBase].[DeleteProductGroupByID]
	@ProductGroupID int
AS
	delete from [Product_ProductGroups]
	where Product_ProductGroups.ProductGroupID = @ProductGroupID
	delete from [ProductGroups] 
	where ProductGroups.ID = @ProductGroupID

