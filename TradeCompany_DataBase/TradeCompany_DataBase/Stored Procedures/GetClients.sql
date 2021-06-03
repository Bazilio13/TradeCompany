CREATE PROCEDURE [TradeCompany_DataBase].[GetClients]
AS
	Select C.ID, C.Name, C.INN, C.E_Mail, C.Phone, C.ContactPerson, C.CorporateBody, c.Type,C.LastOrderDate, C.Comment
	from [Clients] as C
