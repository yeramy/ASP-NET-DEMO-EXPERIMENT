CREATE TABLE [dbo].[Vocabs] (
    [Id]         INT IDENTITY(1, 1) NOT NULL,
    [Word]       NVARCHAR (50) NULL,
    [Definition] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

