CREATE PROCEDURE [TradeCompany_DataBase].[UpdateProductGroupByID]
	@ProductGroupID int,
	@Name nvarchar (255)
AS
	update [ProductGroups]
set 
	Name = @Name
where 
	ID = @ProductGroupID
