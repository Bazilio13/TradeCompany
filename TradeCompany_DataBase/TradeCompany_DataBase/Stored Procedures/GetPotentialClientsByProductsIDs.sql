CREATE PROCEDURE [TradeCompany_DataBase].[GetPotentialClientsByProductsIDs]
	@IDs ntext,
	@DateTime DateTime,
	@GroupMatchNumber int,
	@ClientSearch nvarchar(255)
AS
select t1.ID, t1.ClientName, t1.ContactPerson, t1.Phone, t1.E_Mail, t1.Type, t1.LastOrderDate,
t1.ProductID, t1.Name, t1.StockAmount, t1.MeasureUnitName as MeasureUnitName, t1.LastSupplyDate, t1.RetailPrice, t1.WholesalePrice
from
(select C.ID, C.Name as ClientName, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID as ProductID, P.Name, P.StockAmount, M.Name as MeasureUnitName, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
from [TradeCompany_DataBase].Clients as C
join [TradeCompany_DataBase].Wishes as W on C.ID = W.ClientsID
join [TradeCompany_DataBase].Products as P on P.ID = W.ProductsID
left join [TradeCompany_DataBase].MeasureUnits as M on M.ID = P.MeasureUnit
where
c.IsDeleted = 0 and
(@ClientSearch is null or C.Name like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.ContactPerson like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.E_Mail like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.Phone like '%' + @ClientSearch + '%')
group by C.ID, C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate,
P.ID, P.Name, P.StockAmount, M.Name, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
union
select Gr.ID, Gr.ClientName, Gr.ContactPerson, Gr.Phone, Gr.E_Mail, Gr.Type, Gr.LastOrderDate, 
Pr.ID as ProductID, Pr.Name, Pr.StockAmount, Pr.MeasureUnitName, Pr.LastSupplyDate, Pr.RetailPrice, Pr.WholesalePrice
from
(select C.ID,C.Name as ClientName, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate, PPG.ProductGroupID, COUNT (*) as GC
from [TradeCompany_DataBase].Clients as C
join [TradeCompany_DataBase].Orders as O on O.ClientsID = C.ID
join [TradeCompany_DataBase].OrderLists as OL on O.ID = OL.OrderID
join [TradeCompany_DataBase].Products as P on P.ID = OL.ProductID
left join [TradeCompany_DataBase].Product_ProductGroups as PPG on PPG.ProductID = P.ID
where O.DateTime > @DateTime and
O.IsDeleted = 0 and
P.IsDeleted = 0 and
C.IsDeleted = 0 and
(@ClientSearch is null or C.Name like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.ContactPerson like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.E_Mail like '%' + @ClientSearch + '%') or
(@ClientSearch is null or C.Phone like '%' + @ClientSearch + '%')
group by C.ID,C.Name, C.ContactPerson, C.Phone, C.E_Mail, C.Type, C.LastOrderDate, PPG.ProductGroupID
having COUNT (*) > @GroupMatchNumber) Gr
left join 
( select PPG.ProductGroupID, P.ID, P.Name, P.StockAmount, M.Name as MeasureUnitName, P.LastSupplyDate, P.RetailPrice, P.WholesalePrice
from [TradeCompany_DataBase].Product_ProductGroups as PPG 
join [TradeCompany_DataBase].Products as P on P.ID = PPG.ProductID
left join [TradeCompany_DataBase].MeasureUnits as M on M.ID = P.MeasureUnit
where P.IsDeleted = 0) Pr on Pr.ProductGroupID = Gr.ProductGroupID) t1
join [TradeCompany_DataBase].iter_intlist_to_table(@IDs) as i on i.number = t1.ProductID