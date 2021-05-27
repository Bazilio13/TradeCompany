CREATE TABLE [dbo].[FeedBacks] (
    [ID]       INT             IDENTITY (1, 1) NOT NULL,
    [DateTime] DATETIME        NOT NULL,
    [Text]     NVARCHAR (1500) NOT NULL,
    [ClientID] INT             NOT NULL,
    [OrderID]  INT             NOT NULL,
    CONSTRAINT [PK_FeedBacks] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FeedBacks_fk0] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ID]),
    CONSTRAINT [FeedBacks_fk1] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID])
);

