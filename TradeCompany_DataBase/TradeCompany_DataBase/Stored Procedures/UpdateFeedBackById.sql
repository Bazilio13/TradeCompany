CREATE PROCEDURE [TradeCompany_DataBase].[UpdateFeedBackById]
	@ID int,
	@Datetime datetime,
	@Text nvarchar(1500),
	@ClientID int,
	@OrderID int
as
	update F
	set
	Datetime = @Datetime,
	Text = @Text ,
	ClientID = @ClientID ,
	OrderID  = @OrderID 
	from [TradeCompany_DataBase].[FeedBacks] as F
where F.ID =@ID