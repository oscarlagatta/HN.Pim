CREATE TABLE [dbo].[Account] (
    [AccountId]  INT           IDENTITY (1, 1) NOT NULL,
    [LoginEmail] NVARCHAR (56) NOT NULL,
    [FirstName]  NVARCHAR (50) NULL,
    [LastName]   NVARCHAR (50) NULL,
    [City]       NVARCHAR (50) NULL,
    [State]      NVARCHAR (50) NULL,
    [PostCode]   NVARCHAR (50) NULL,
    [CreditCard] NVARCHAR (50) NULL,
    [ExpDate]    NVARCHAR (50) NULL,
    [Address]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([AccountId] ASC),
    UNIQUE NONCLUSTERED ([LoginEmail] ASC)
);

