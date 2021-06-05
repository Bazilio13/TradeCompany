CREATE PROCEDURE [TradeCompany_DataBase].[DeleteWishListByID]
	@id
AS
	delete [Wishes]
	where Wishes.ClientsID = @ClientID
