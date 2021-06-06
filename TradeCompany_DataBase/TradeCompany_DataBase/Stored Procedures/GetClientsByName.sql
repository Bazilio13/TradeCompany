CREATE PROCEDURE [TradeCompany_DataBase].[GetClientsByName]
	@PartOfTheName nvarchar(50)
AS
	select * from TradeCompany_DataBase.Clients
	where Name LIKE '%'+@PartOfTheName+'%' or INN LIKE @PartOfTheName+'%' or Phone LIKE @PartOfTheName+'%' or  E_Mail LIKE @PartOfTheName+'%'

