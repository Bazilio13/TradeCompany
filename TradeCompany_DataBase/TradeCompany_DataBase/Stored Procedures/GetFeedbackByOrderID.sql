CREATE PROCEDURE [TradeCompany_DataBase].[GetFeedbackByOrderID]
	@OrderID int
as

	select F.[Datetime], F.[Text], F.ClientID, F.OrderID
	from [TradeCompany_DataBase].[Feedbacks] as F
	where F.OrderID = @OrderID
