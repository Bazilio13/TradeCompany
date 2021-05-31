CREATE PROCEDURE [dbo].[DeleteFeedbackByOrderID]
	@OrderID int
	as
	delete from Feedbacks
	where Feedbacks.OrderID = @OrderID