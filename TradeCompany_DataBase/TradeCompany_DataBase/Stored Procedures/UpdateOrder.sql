CREATE PROCEDURE [TradeCompany_DataBase].[UpdateOrder]
	@ID int,
	@ClientsID int,
	@Datetime datetime,
	@AddressID int,
	@Comment nvarchar(500)
AS
	update O 
	set 
	ClientsID = @ClientsID, 
	DateTime = @Datetime,
	AddressID = @AddressID,
	Comment = @Comment
	from [TradeCompany_DataBase].Orders as O

where o.ID = @ID

UPDATE  B
SET
     B.LastOrderDate = D.LastOrder
FROM
(select C.ID, C.LastOrderDate from
		[TradeCompany_DataBase].Clients AS C
		where C.ID = @ClientsID ) B
		left join
	(select C.ID,  max(O.DateTime) as LastOrder from
		[TradeCompany_DataBase].Clients AS C
	join [TradeCompany_DataBase].Orders as O ON O.ClientsID = C.ID
	where C.ID = @ClientsID 
	group by C.ID, C.LastOrderDate) D on B.ID = D.ID