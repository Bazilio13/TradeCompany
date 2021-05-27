CREATE PROCEDURE [TradeCompany_DataBase].[GetClientByID]
	@ClientID int
AS
	SELECT C.ID, C.Name, C.INN, C.E_Mail, C.Phone, C.CorporateBody, C.Type, C.LastOrderDate, C.Comment
	from [Clients] as C
	where C.ID = @ClientID
