CREATE TABLE [TradeCompany_DataBase].[Addresses] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [ClientID] INT            NOT NULL,
    [Address]  NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Addresses_fk0] FOREIGN KEY ([ClientID]) REFERENCES [TradeCompany_DataBase].[Clients] ([ID])
);

