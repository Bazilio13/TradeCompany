CREATE PROCEDURE [TradeCompany_DataBase].[DeleteAllFeedbacksByClientId]
	@ClientID int
	as
	delete from FeedBacks
	where FeedBacks.ClientID = @ClientID