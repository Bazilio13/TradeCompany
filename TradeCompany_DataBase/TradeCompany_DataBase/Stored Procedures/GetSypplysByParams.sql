CREATE PROCEDURE [TradeCompany_DataBase].[GetSupplysByParams]
	@MinDateTime DateTime,
	@MaxDateTime DateTime,
	@Product nvarchar(255),
	@ProductGroup nvarchar(255)
AS
	SELECT s.ID, s.DateTime, s.Comment, sl.ID, sl.ProductID, sl.Amount, P.ID, p.Name, p.StockAmount, M.Name as MeasureUnitName, PG.ID, PG.Name
	from TradeCompany_DataBase.Supplies as S
	left join TradeCompany_DataBase.SupplyLists as SL on S.ID = SL.SupplyID
	left join TradeCompany_DataBase.Products as P on SL.ProductID = P.ID
	left join TradeCompany_DataBase.MeasureUnits as M on P.MeasureUnit = M.ID
	left join TradeCompany_DataBase.Product_ProductGroups as PPG on P.ID = PPG.ProductID
	left join TradeCompany_DataBase.ProductGroups as PG on PPG.ProductGroupID = PG.ID
	Where 
	(@MinDateTime IS NULL OR S.DateTime >= @MinDateTime) AND
	(@MaxDateTime IS NULL OR S.DateTime <= @MaxDateTime) AND
	(@Product IS NULL OR P.Name LIKE '%' + @Product + '%') AND
	(@ProductGroup IS NULL OR PG.Name LIKE '%' + @ProductGroup + '%')
	order by S.DateTime desc, S.ID desc