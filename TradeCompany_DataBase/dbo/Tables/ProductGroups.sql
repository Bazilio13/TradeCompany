CREATE TABLE [TradeCompany_DataBase].[ProductGroups] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_ProductGroups] PRIMARY KEY CLUSTERED ([ID] ASC)
);

