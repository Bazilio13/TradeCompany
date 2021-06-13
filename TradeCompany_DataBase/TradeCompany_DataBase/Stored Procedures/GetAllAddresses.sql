CREATE PROCEDURE [TradeCompany_DataBase].[GetAllAddresses]
AS
	Select A.ClientID, A.Address 
	from [Addresses] as A