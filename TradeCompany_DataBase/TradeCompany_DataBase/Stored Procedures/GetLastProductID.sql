create procedure [TradeCompany_DataBase].[GetLastProductID]
@Output int output
as
set @Output = (SELECT IDENT_CURRENT('TradeCompany_DataBase.Products'))
