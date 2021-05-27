CREATE TABLE [dbo].[SupplyLists] (
    [ID]        INT        IDENTITY (1, 1) NOT NULL,
    [SupplytID] INT        NOT NULL,
    [ProductID] INT        NOT NULL,
    [Amount]    FLOAT (53) NOT NULL,
    CONSTRAINT [PK_SupplyLists] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [SupplyLists_fk0] FOREIGN KEY ([SupplytID]) REFERENCES [dbo].[Supplies] ([ID]),
    CONSTRAINT [SupplyLists_fk1] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
);

