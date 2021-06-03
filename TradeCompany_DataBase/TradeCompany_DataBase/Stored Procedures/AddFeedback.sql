CREATE PROCEDURE [TradeCompany_DataBase].[AddFeedback]
@Datetime datetime,
@Text nvarchar(1500),
@ClientID int,
@OrderID int
As 
insert into FeedBacks(Datetime,Text,ClientID,OrderID)
values (@Datetime,@Text,@ClientID,@OrderID)
