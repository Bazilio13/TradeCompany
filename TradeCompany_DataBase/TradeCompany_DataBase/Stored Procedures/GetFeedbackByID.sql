CREATE PROCEDURE [TradeCompany_DataBase].[GetFeedbackByID]
	@FeedbackId int
	as
	select F.[Datetime], F.[Text], F.ClientID, F.OrderID
	from [Feedbacks] as F
	where F.ID = @FeedbackId