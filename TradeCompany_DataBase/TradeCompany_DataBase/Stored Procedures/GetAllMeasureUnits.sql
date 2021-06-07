CREATE PROCEDURE [TradeCompany_DataBase].[GetAllMeasureUnits]
AS
	select * from [TradeCompany_DataBase].[MeasureUnits]
	order by Name
