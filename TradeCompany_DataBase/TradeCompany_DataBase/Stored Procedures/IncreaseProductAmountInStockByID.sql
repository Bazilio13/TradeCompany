CREATE PROCEDURE [TradeCompany_DataBase].[IncreaseProductAmountInStockByID]
@ProductID int,
@StockAmount float
	
AS
	update TradeCompany_DataBase.[Products] 
set 
	
	StockAmount += @StockAmount
	
where 
	TradeCompany_DataBase.[Products].ID = @ProductID