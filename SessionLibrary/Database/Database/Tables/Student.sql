CREATE TABLE [dbo].[Student] (
    [Id]        INT           NOT NULL,
    [Name]      NVARCHAR (30) NOT NULL,
    [Surname]   NVARCHAR (30) NOT NULL,
    [MidleName] NVARCHAR (30) NOT NULL,
    [GenderId]  INT           NOT NULL,
    [GroupId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);