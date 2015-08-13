CREATE TABLE [dbo].[Product] (
    [ProductId]      INT             IDENTITY (1, 1) NOT NULL,
    [Asin]           NVARCHAR (50)   NULL,
    [Name]           NVARCHAR (50)   NULL,
    [Price]          DECIMAL (18, 2) NULL,
    [AccountId]      INT             NULL,
    [Stock]          INT             NULL,
    [OwnerAccountId] INT             NULL
);

