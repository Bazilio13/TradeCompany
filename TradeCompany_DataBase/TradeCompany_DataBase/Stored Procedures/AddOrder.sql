CREATE PROCEDURE [TradeCompany_DataBase].[AddOrder]
	@ClientsID int,
	@Datetime datetime,
	@AddressID int,
	@Comment nvarchar(500)
AS
	insert into Orders (ClientsID, Datetime,  AddressID, Comment)
	values (@ClientsID, @Datetime,  @AddressID, @Comment)

	Select SCOPE_IDENTITY()

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