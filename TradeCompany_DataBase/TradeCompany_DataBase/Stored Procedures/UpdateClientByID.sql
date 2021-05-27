CREATE PROCEDURE [TradeCompany_DataBase].[UpdateClientByID]
	@ClientID int,
	@Name nvarchar(255),
	@INN int,
	@Email nvarchar(100),
	@Phone nvarchar(50),
	@Comment nvarchar(500),
	@CorporateBody binary,
	@Type binary,
	@LastOrderDate datetime
AS
	update [Clients]
	set 
	[Name] = @Name,
	[INN] = @INN,
	[E_Mail] = @Email,
	[Phone] = @Phone,
	[Comment] = @Comment,
	[CorporateBody] = @CorporateBody,
	[Type] = @Type,
	[LastOrderDate] = @LastOrderDate
	where Clients.ID = @ClientID
