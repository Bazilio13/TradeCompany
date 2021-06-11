CREATE PROCEDURE [TradeCompany_DataBase].[GetAddresses]
AS
	Select A.ClientID, A.Address 
	from [Addresses] as A
	where isDeleted = 0 or isDeleted = null