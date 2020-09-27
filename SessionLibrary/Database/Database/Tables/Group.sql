CREATE TABLE [dbo].[Group] (
    [Id]              INT           NOT NULL,
    [GroupName]       NVARCHAR (20) NOT NULL,
    [SpecificationId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

