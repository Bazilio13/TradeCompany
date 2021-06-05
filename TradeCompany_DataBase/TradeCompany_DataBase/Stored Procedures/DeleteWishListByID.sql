CREATE PROCEDURE [TradeCompany_DataBase].[DeleteWishListByID]
	@id int
AS
	delete from [Wishes]
	where Wishes.ClientsID = @id
