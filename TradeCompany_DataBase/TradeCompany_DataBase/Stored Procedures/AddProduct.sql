CREATE PROCEDURE [TradeCompany_DataBase].[AddProduct]
	@Name nvarchar (255),
	@StockAmount float,
	@MeasureUnit int,
	@MinPrice float,
	@MaxPrice float,
	@LastSupplyDate datetime
AS
	insert into Products (Name, StockAmount, MeasureUnit, MinPrice, MaxPrice, LastSupplyDate)
	values (@Name, @StockAmount, @MeasureUnit, @MinPrice, @MaxPrice, @LastSupplyDate)
