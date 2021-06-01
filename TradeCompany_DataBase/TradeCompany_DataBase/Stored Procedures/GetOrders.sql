CREATE PROCEDURE [TradeCompany_DataBase].[GetOrders]
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
	order by o.DateTime, o.ID