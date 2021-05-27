CREATE TABLE [dbo].[Product_ProductGroups] (
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [ProductID]      INT NOT NULL,
    [ProductGroupID] INT NOT NULL,
    CONSTRAINT [PK_Product_ProductGroups] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Product_ProductGroups_fk0] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]),
    CONSTRAINT [Product_ProductGroups_fk1] FOREIGN KEY ([ProductGroupID]) REFERENCES [dbo].[ProductGroups] ([ID])
);

