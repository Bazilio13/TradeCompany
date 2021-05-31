CREATE PROCEDURE [dbo].[DeleteAllFeedbacksByClientId]
	@ClientID int
	as
	delete from FeedBacks
	where FeedBacks.ClientID = @ClientID