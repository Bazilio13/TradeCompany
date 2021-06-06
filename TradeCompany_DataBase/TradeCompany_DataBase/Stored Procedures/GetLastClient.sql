CREATE PROCEDURE [TradeCompany_DataBase].[GetLastClient]
AS
	Select C.ID, C.Name, C.INN, C.E_Mail, C.Phone, C.ContactPerson, C.CorporateBody, c.Type,C.LastOrderDate, C.Comment
	FROM TradeCompany_DataBase.Clients as C
	WHERE id=(SELECT max(id) FROM TradeCompany_DataBase.Clients)