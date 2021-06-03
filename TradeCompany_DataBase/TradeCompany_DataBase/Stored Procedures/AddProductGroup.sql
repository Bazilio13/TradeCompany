CREATE PROCEDURE [TradeCompany_DataBase].[AddProductGroup]
	@Name nvarchar(255)
AS
	insert into ProductGroups (Name)
	values (@Name)