CREATE PROCEDURE [TradeCompany_DataBase].[UpdateProductByID]
	@ProductID int,
	@Name nvarchar (255),
	@StockAmount float,
	@MeasureUnit int,
	@WholesalePrice float,
	@RetailPrice float,
	@LastSupplyDate datetime,
	@Description nvarchar (500),
	@Comments nvarchar (500)
AS
	update [Products] 
set 
	Name = @Name,
	StockAmount = @StockAmount,
	MeasureUnit = @MeasureUnit,
	WholesalePrice = @WholesalePrice,
	RetailPrice = @RetailPrice,
	LastSupplyDate = @LastSupplyDate,
	Description = @Description,
	Comments = @Comments
where 
	ID = @ProductID