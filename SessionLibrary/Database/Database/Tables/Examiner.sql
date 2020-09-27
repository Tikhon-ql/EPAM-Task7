CREATE TABLE [dbo].[Examiner] (
    [Id]        INT           NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [Surname]   NVARCHAR (20) NOT NULL,
    [MidleName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
