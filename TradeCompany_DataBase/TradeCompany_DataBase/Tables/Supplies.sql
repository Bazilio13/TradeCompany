CREATE TABLE [TradeCompany_DataBase].[Supplies] (
    [ID]       INT      IDENTITY (1, 1) NOT NULL,
    [DateTime] DATETIME NOT NULL,
    [Comment]   NVARCHAR (500) NULL
    CONSTRAINT [PK_Supplies] PRIMARY KEY CLUSTERED ([ID] ASC)
);

