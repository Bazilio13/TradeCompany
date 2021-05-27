CREATE TABLE [TradeCompany_DataBase].[SupplyLists] (
    [ID]        INT        IDENTITY (1, 1) NOT NULL,
    [SupplyID] INT        NOT NULL,
    [ProductID] INT        NOT NULL,
    [Amount]    FLOAT (53) NOT NULL,
    CONSTRAINT [PK_SupplyLists] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [SupplyLists_fk0] FOREIGN KEY ([SupplyID]) REFERENCES [TradeCompany_DataBase].[Supplies] ([ID]),
    CONSTRAINT [SupplyLists_fk1] FOREIGN KEY ([ProductID]) REFERENCES [TradeCompany_DataBase].[Products] ([ID])
);

