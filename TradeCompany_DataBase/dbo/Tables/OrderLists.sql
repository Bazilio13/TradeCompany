CREATE TABLE [dbo].[OrderLists] (
    [ID]        INT        IDENTITY (1, 1) NOT NULL,
    [OrderID]   INT        NOT NULL,
    [ProductID] INT        NOT NULL,
    [Amount]    FLOAT (53) NOT NULL,
    [Price]     FLOAT (53) NOT NULL,
    CONSTRAINT [PK_OrderLists] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [OrderLists_fk0] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID]),
    CONSTRAINT [OrderLists_fk1] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
);

