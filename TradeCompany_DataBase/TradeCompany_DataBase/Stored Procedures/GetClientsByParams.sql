CREATE PROCEDURE [TradeCompany_DataBase].[GetClientsByParams]
	@Person binary,
	@Sale binary,
	@MinData DateTime,
	@MaxData DateTime
AS
	Select C.ID, C.Name, C.INN, C.E_Mail, C.Phone, C.ContactPerson, C.CorporateBody, c.Type,C.LastOrderDate, C.Comment
	from [Clients] as C
	Where 
	(@Person IS NULL OR C.Type = @Person ) AND
	(@Sale IS NULL OR C.CorporateBody = @Sale ) AND
	(@MinData IS NULL OR C.LastOrderDate >= @MinData) AND
	(@MaxData IS NULL OR C.LastOrderDate <= @MaxData) 
