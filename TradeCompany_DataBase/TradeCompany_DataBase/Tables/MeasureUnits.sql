CREATE TABLE [TradeCompany_DataBase].[MeasureUnits] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_MeasureUnits] PRIMARY KEY CLUSTERED ([ID] ASC)
);

