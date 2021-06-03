CREATE PROCEDURE [TradeCompany_DataBase].[DeleteProductByID]
	@ProductID int
AS
	delete from [Product_ProductGroups]
	where Product_ProductGroups.ProductID = @ProductID
	delete from [Products] 
	where Products.ID = @ProductID