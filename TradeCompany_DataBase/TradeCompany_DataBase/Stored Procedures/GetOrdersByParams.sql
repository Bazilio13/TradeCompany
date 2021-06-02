CREATE PROCEDURE [TradeCompany_DataBase].[GetOrdersByParams]
	@ClientsID int,
	@MinDateTime DateTime,
	@MaxDateTime DateTime,
	@AddressID int,
	@ProductID int
AS
	SELECT o.ID, o.ClientsID, o.DateTime, o.AddressID, o.Comment, A.Address as Address,
	ol.ID, ol.OrderID, ol.ProductID, ol.Amount, ol.Price,
	c.ID, c.Name, c.Type, c.Phone,
	p.id, p.Name, m.Name as MeasureUnitName from [TradeCompany_DataBase].[Orders] as O
	left join [TradeCompany_DataBase].OrderLists as OL on o.ID = OL.OrderID
	left join [TradeCompany_DataBase].Clients as C on o.ClientsID = C.ID
	left join [TradeCompany_DataBase].Products as P on ol.ProductID = P.ID
	left join [TradeCompany_DataBase].MeasureUnits as M on m.ID = P.MeasureUnit
	left join [TradeCompany_DataBase].Addresses as A on o.AddressID = A.ID
	Where 
	(@ClientsID IS NULL OR O.ClientsID = @ClientsID) AND
	(@AddressID IS NULL OR O.AddressID = @AddressID) AND
	(@ProductID IS NULL OR OL.ProductID = @ProductID) AND
	(@MinDateTime IS NULL OR O.DateTime >= @MinDateTime) AND
	(@MaxDateTime IS NULL OR O.DateTime <= @MaxDateTime) 
	order by o.DateTime desc, o.ID desc
	