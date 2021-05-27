CREATE PROCEDURE [TradeCompany_DataBase].[UpdateOrderListByID]
	@ID int,
	@OrderID int,
	@ProductID int,
	@Amount int,
	@Price float
AS
	update OL
	set
	OrderID= @OrderID,
	ProductID = @ProductID,
	Amount = @Amount,
	Price = @Price
	from OrderLists as OL
	Where OL.ID = @ID
