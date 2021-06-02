CREATE PROCEDURE [TradeCompany_DataBase].[UpdateProductByID]
	@ProductID int,
	@Name nvarchar (255),
	@StockAmount float,
	@MeasureUnit int,
	@MinPrice float,
	@MaxPrice float,
	@LastSupplyDate datetime
AS
	update [Products] 
set 
	Name = @Name,
	StockAmount = @StockAmount,
	MeasureUnit = @MeasureUnit,
	MinPrice = @MinPrice,
	MaxPrice = @MaxPrice,
	LastSupplyDate = @LastSupplyDate
where 
	ID = @ProductID
