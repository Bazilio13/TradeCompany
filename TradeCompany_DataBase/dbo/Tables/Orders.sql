CREATE TABLE [dbo].[Orders] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [ClientsID] INT            NOT NULL,
    [DateTime]  DATETIME       NOT NULL,
    [AddressID] INT            NOT NULL,
    [Comment]   NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Orders_fk0] FOREIGN KEY ([ClientsID]) REFERENCES [dbo].[Clients] ([ID]),
    CONSTRAINT [Orders_fk1] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([ID])
);

