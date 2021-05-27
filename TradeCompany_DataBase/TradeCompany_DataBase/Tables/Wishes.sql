CREATE TABLE [TradeCompany_DataBase].[Wishes] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [ClientsID]  INT NOT NULL,
    [ProductsID] INT NOT NULL,
    CONSTRAINT [PK_Wishes] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Wishes_fk0] FOREIGN KEY ([ClientsID]) REFERENCES [TradeCompany_DataBase].[Clients] ([ID]),
    CONSTRAINT [Wishes_fk1] FOREIGN KEY ([ProductsID]) REFERENCES [TradeCompany_DataBase].[Products] ([ID])
);

