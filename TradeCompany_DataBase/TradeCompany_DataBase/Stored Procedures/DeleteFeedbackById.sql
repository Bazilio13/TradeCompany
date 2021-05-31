CREATE PROCEDURE [TradeCompany_DataBase].[DeleteFeedbackById]
	@ID int
	as
	delete from FeedBacks 
	where FeedBacks.ID = @ID
