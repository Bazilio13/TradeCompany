create procedure [TradeCompany_DataBase].[SoftDeleteProductByID]
@ProductID int
as
	update [Products]
set
	IsDeleted = 'TRUE'
where 
	ID = @ProductID
