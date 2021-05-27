CREATE TABLE [dbo].[MeasureUnits] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_MeasureUnits] PRIMARY KEY CLUSTERED ([ID] ASC)
);

