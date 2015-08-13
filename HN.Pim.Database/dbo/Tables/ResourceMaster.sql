CREATE TABLE [dbo].[ResourceMaster] (
    [ResourceId] INT             IDENTITY (1, 1) NOT NULL,
    [Culture]    VARCHAR (10)    NOT NULL,
    [Name]       VARCHAR (100)   NOT NULL,
    [Value]      NVARCHAR (4000) NOT NULL,
    CONSTRAINT [pk_culture_name] PRIMARY KEY CLUSTERED ([ResourceId] ASC, [Culture] ASC, [Name] ASC)
);

