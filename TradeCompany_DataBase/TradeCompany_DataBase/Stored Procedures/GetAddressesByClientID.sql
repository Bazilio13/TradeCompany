CREATE PROCEDURE [TradeCompany_DataBase].[GetAddressesByClientID]
  @ClientID int
  as
  select A.Address, A.ID , A.ClientID
  from Addresses as A
  where A.ClientID = @ClientID