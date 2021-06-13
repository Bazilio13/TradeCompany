CREATE TABLE [TradeCompany_DataBase].[Addresses] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [ClientID] INT            NOT NULL,
    [Address]  NVARCHAR (255) NOT NULL,
    [IsDeleted] BIT NOT NULL CONSTRAINT DF_Addresses_IsDeleted DEFAULT 0 , 
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Addresses_fk0] FOREIGN KEY ([ClientID]) REFERENCES [TradeCompany_DataBase].[Clients] ([ID])
);

