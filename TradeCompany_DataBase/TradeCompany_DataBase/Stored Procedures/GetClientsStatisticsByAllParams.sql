	Create procedure [TradeCompany_DataBase].[GetClientsStatisticsByAllParams]
	@ID int,
	@FromDate datetime,
	@UntilDate datetime,
	@FromLastOrder datetime,
	@UntilLastOrder datetime,
	@Type binary,
	@FromAmount float,
	@ToAmount float,
	@FromOrdersCount int,
	@ToOrdersCount int
	AS
	select t1.Name, t1.RegistrationDate, t1.Counts as CountOrder, t1.TotalAmount, t1.LastOrderDate, t1.ID from 
	(select O.ClientsID as ID, C.RegistrationDate, C.Name, count(OL.OrderID) as Counts, sum(OL.Price * OL.Amount) as TotalAmount, MAX(O.DateTime) as LastOrderDate --C.LastOrderDate
from TradeCompany_DataBase.ProductGroups as PG 
left join TradeCompany_DataBase.Product_ProductGroups as PPG on PPG.ProductGroupID = PG.ID
left join TradeCompany_DataBase.Products as P on PPG.ProductID = p.ID
join TradeCompany_DataBase.OrderLists as OL on OL.ProductID = P.ID
left join TradeCompany_DataBase.Orders as O on OL.OrderID=O.ID
left join TradeCompany_DataBase.Clients as C on O.ClientsID = C.ID
where (PG.ID = @ID)
AND (@FromDate is null or O.DateTime >= @FromDate)
AND (@UntilDate is null or O.DateTime <= @UntilDate)
AND (@FromLastOrder is null or C.LastOrderDate >= @FromLastOrder)
AND (@UntilLastOrder is null or C.LastOrderDate <= @UntilLastOrder)
AND (@Type is null or C.Type = @Type)
group by O.ClientsID, C.RegistrationDate, C.Name--C.LastOrderDate
having
(@FromOrdersCount is null or count(OL.OrderID) >= @FromOrdersCount)
AND (@ToOrdersCount is null or count(OL.OrderID) <= @ToOrdersCount)
AND (@FromAmount is null or sum(OL.Price * OL.Amount) >= @FromAmount)
AND (@ToAmount is null or sum(OL.Price * OL.Amount) <= @ToAmount)) t1
order by TotalAmount desc