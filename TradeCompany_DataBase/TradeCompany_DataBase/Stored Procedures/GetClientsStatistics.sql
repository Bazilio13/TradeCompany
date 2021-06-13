create PROCEDURE [TradeCompany_DataBase].[GetClientsStatistics]
AS
select FirstSet.ID, FirstSet.RegistrationDate, FirstSet.Name, FirstSet.CountOrder, SecondSet.TotalAmount, FirstSet.LastOrderDate
from
(select Clients.ID, Clients.RegistrationDate, Clients.Name, count(o.ID) as CountOrder, MAX(O.DateTime) as LastOrderDate
from [TradeCompany_DataBase].Clients as Clients
	left join TradeCompany_DataBase.Orders as O on O.ClientsID = Clients.ID
	group by Clients.Name, Clients.ID, Clients.RegistrationDate) as FirstSet
inner join
	(select c.ID, c.Name, sum(ol.Price * ol.Amount) as TotalAmount
	from [TradeCompany_DataBase].[Orders] as O
	join [TradeCompany_DataBase].OrderLists as OL on o.ID = OL.OrderID
	full join [TradeCompany_DataBase].Clients as C on o.ClientsID = C.ID
	group by C.Name, C.ID) as SecondSet
	on FirstSet.ID = SecondSet.ID
	order by SecondSet.TotalAmount desc
