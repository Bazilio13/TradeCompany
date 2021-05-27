CREATE PROCEDURE [TradeCompany_DataBase].[AddClient]
	@Name nvarchar(255),
	@INN int,
	@Email nvarchar(100),
	@Phone nvarchar(50),
	@Comment nvarchar(500),
	@CorporateBody binary,
	@Type binary,
	@LastOrderDate datetime
AS
	insert into Clients (Name, INN, E_Mail, Phone, Type, CorporateBody, LastOrderDate, Comment)
	values(@Name, @INN, @Email, @Phone, @Type, @CorporateBody, @LastOrderDate, @Comment)
