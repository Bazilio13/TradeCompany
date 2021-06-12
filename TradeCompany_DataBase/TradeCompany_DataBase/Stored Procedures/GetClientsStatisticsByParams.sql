CREATE PROCEDURE [TradeCompany_DataBase].[GetClientsStatisticsByParams]
@FromOrdersСount int,
@ToOrdersСount int,
@Type binary,
@FromLastOrderDate datetime,
@UntilLastOrderDate datetime,
@MinDate datetime,
@MaxDate datetime,
@FromAmount float,
@ToAmount float

AS
select FirstSet.ID, FirstSet.RegistrationDate, FirstSet.Name, FirstSet.OrdersСount, SecondSet.TotalAmount, FirstSet.LastOrderDate
from
	(select Clients.ID, Clients.RegistrationDate, Clients.Name, count(o.ID) as OrdersСount, MAX(O.DateTime) as LastOrderDate, Clients.Type
	from [TradeCompany_DataBase].Clients as Clients
	left join TradeCompany_DataBase.Orders as O on O.ClientsID = Clients.ID
	where (@MinDate is null OR O.DateTime >= @MinDate) AND
	(@MaxDate is null or O.DateTime <= @MaxDate)
	group by Clients.Name, Clients.ID, Clients.Type, Clients.RegistrationDate) as FirstSet
inner join
	(select c.ID, c.Name, sum(ol.Price * ol.Amount) as TotalAmount
	from [TradeCompany_DataBase].[Orders] as O
	left join [TradeCompany_DataBase].OrderLists as OL on o.ID = OL.OrderID
	full join [TradeCompany_DataBase].Clients as C on o.ClientsID = C.ID
	where (@MinDate is null OR O.DateTime >= @MinDate) AND
	(@MaxDate is null or O.DateTime <= @MaxDate)
	group by C.Name, C.ID) as SecondSet
	on FirstSet.ID = SecondSet.ID
	where
	(@FromOrdersСount IS NULL OR FirstSet.OrdersСount >= @FromOrdersСount) AND
	(@ToOrdersСount IS NULL OR FirstSet.OrdersСount <= @ToOrdersСount) AND
	(@FromAmount is null or SecondSet.TotalAmount >= @FromAmount) AND
	(@ToAmount is null or SecondSet.TotalAmount <= @ToAmount) AND
	(@Type IS NULL OR FirstSet.Type = @Type ) AND
	(@FromLastOrderDate IS NULL OR FirstSet.LastOrderDate >= @FromLastOrderDate) AND
	(@UntilLastOrderDate IS NULL OR FirstSet.LastOrderDate <= @UntilLastOrderDate)
	order by SecondSet.TotalAmount desc
