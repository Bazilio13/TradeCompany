CREATE PROCEDURE [TradeCompany_DataBase].[AddWishByID]
	@id int,
	@IDProduct int
AS
	insert into Wishes(ClientsID, ProductsID)
	values(@id, @IDProduct)