CREATE PROCEDURE [TradeCompany_DataBase].[DeleteFeedbackByOrderID]
	@OrderID int
	as
	delete from Feedbacks
	where Feedbacks.OrderID = @OrderID