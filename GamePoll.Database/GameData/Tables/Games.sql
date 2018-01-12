CREATE TABLE [GameData].[Games] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (100) NOT NULL,
    [ImageUrl] NVARCHAR (MAX) NULL, 
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id])
);

