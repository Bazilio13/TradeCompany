CREATE PROCEDURE [TradeCompany_DataBase].[SearchSupplys]
@str nvarchar(255)
AS
	SELECT s.ID, s.DateTime, s.Comment, sl.ID, sl.ProductID, sl.Amount, P.ID, p.Name, p.StockAmount, M.Name as MeasureUnitName, PG.ID, PG.Name
	from TradeCompany_DataBase.Supplies as S
	left join TradeCompany_DataBase.SupplyLists as SL on S.ID = SL.SupplyID
	left join TradeCompany_DataBase.Products as P on SL.ProductID = P.ID
	left join TradeCompany_DataBase.MeasureUnits as M on P.MeasureUnit = M.ID
	left join TradeCompany_DataBase.Product_ProductGroups as PPG on P.ID = PPG.ProductID
	left join TradeCompany_DataBase.ProductGroups as PG on PPG.ProductGroupID = PG.ID
	Where 
	s.ID like '%' + @str + '%' OR
	s.Comment like '%' + @str + '%' OR
	p.Name like '%' + @str + '%' OR
	PG.Name like '%' + @str + '%'
	order by S.DateTime desc, S.ID desc
