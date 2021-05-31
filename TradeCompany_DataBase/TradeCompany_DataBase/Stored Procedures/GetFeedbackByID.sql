CREATE PROCEDURE [dbo].[GetFeedbackByID]
	@FeedbackId int
	as
	select [Datetime].F, [Text].F, ClientID.F, OrderID.F
	from [Feedbacks] as F
	where F.ID = @FeedbackId