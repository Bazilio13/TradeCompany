CREATE PROCEDURE [TradeCompany_DataBase].[GetFeedbackByClientID]
	@id int
as
	select F.OrderID,  F.Text, F.DateTime
	from TradeCompany_DataBase.FeedBacks as F
	where ClientID = @id