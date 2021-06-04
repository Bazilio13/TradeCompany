CREATE PROCEDURE [TradeCompany_DataBase].[AddProduct]
	@Name nvarchar (255),
	@StockAmount float,
	@MeasureUnit int,
	@WholesalePrice float,
	@RetailPrice float,
	@LastSupplyDate datetime,
	@Description nvarchar(500),
	@Comments nvarchar(500)
AS
	insert into Products (Name, StockAmount, MeasureUnit, WholesalePrice, RetailPrice, LastSupplyDate, Description, Comments)
	values (@Name, @StockAmount, @MeasureUnit, @WholesalePrice, @RetailPrice, @LastSupplyDate, @Description, @Comments)
