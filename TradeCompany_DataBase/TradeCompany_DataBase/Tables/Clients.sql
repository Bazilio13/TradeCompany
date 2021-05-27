CREATE TABLE [TradeCompany_DataBase].[Clients] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (255) NOT NULL,
    [INN]           INT            NULL,
    [E_Mail]        NVARCHAR (100) NULL,
    [Phone]         NVARCHAR (50)  NULL,
    [Comment]       NVARCHAR (500) NULL,
    [CorporateBody] BIT            NOT NULL,
    [Type]          BIT            NOT NULL,
    [LastOrderDate] DATETIME       NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ID] ASC)
);

