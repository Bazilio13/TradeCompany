CREATE PROCEDURE [TradeCompany_DataBase].[DeleteSupplyByID]
	@ID int
AS
	Delete SupplyLists
	where SupplyID = @ID
	Delete Supplies
	Where ID = @ID