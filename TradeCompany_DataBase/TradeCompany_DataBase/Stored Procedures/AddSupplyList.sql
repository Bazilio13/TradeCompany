CREATE PROCEDURE [TradeCompany_DataBase].[AddSupplyList]
	@SupplyID int,
	@ProductID int,
	@Amount int
AS
	insert into SupplyLists values
	(@SupplyID, @ProductID, @Amount)
