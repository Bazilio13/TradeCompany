create PROCEDURE [TradeCompany_DataBase].[AddProductToProductGroup]
	@ProductId int,
	@ProductGroupID int
AS
	Insert Product_ProductGroups
	VALUES (@ProductId, @ProductGroupID)
