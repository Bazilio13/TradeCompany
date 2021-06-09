CREATE PROCEDURE [TradeCompany_DataBase].[GetPotentialClientsByProductsIDs]
	@IDs ntext,
	@DateTime DateTime
AS
select C.ID, C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID, P.Name, P.StockAmount, M.Name as MeasureUnitName, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
from [TradeCompany_DataBase].Clients as C
join [TradeCompany_DataBase].Wishes as W on C.ID = W.ClientsID
join [TradeCompany_DataBase].Products as P on P.ID = W.ProductsID
left join [TradeCompany_DataBase].MeasureUnits as M on M.ID = P.MeasureUnit
join [TradeCompany_DataBase].iter_intlist_to_table(@IDs) as i on i.number = P.ID
group by C.ID, C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID, P.Name, P.StockAmount, M.Name, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
union
select C.ID, C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID, P.Name, P.StockAmount, M.Name as MeasureUnitName, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
from [TradeCompany_DataBase].Clients as C
join [TradeCompany_DataBase].Orders as O on O.ClientsID = C.ID
join [TradeCompany_DataBase].OrderLists as OL on O.ID = OL.OrderID
join [TradeCompany_DataBase].Products as P on P.ID = OL.ProductID
left join [TradeCompany_DataBase].MeasureUnits as M on M.ID = P.MeasureUnit
join [TradeCompany_DataBase].iter_intlist_to_table(@IDs) as i on i.number = P.ID
where O.DateTime >= @DateTime
group by C.ID, C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID, P.Name, P.StockAmount, M.Name, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
