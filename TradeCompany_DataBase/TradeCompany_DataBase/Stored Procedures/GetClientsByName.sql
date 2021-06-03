CREATE PROCEDURE [TradeCompany_DataBase].[GetClientsByName]
	@PartOfTheName nvarchar(50)
AS
	select * from TradeCompany_DataBase.Clients
	where Name LIKE '%'+@PartOfTheName+'%'

