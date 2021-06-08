CREATE PROCEDURE [TradeCompany_DataBase].[DeleteSupplyListsBySupplyID]
	@SupplyID int
AS
	Delete SupplyLists
	where SupplyID = @SupplyID