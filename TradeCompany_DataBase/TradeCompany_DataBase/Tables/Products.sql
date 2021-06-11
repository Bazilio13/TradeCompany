CREATE TABLE [TradeCompany_DataBase].[Products] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (250) NOT NULL,
    [StockAmount]    FLOAT (53)     NOT NULL,
    [MeasureUnit]    INT            NOT NULL,
    [WholesalePrice] FLOAT (53)     NOT NULL,
    [RetailPrice]    FLOAT (53)     NOT NULL,
    [LastSupplyDate] DATETIME       NULL,
    [Description]    NVARCHAR (500) NULL,
    [Comments]       NVARCHAR (500) NULL,
    [IsDeleted]      BIT            NOT NULL,
    CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Products_fk0] FOREIGN KEY ([MeasureUnit]) REFERENCES [TradeCompany_DataBase].[MeasureUnits] ([ID])
);

