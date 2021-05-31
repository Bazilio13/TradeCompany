CREATE PROCEDURE [dbo].[DeleteFeedbackById]
	@ID int
	as
	delete from FeedBacks 
	where FeedBacks.ID = @ID
