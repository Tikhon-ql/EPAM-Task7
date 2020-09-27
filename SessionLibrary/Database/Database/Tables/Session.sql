CREATE TABLE [dbo].[Session] (
    [Id]            INT           NOT NULL,
    [SessionTypeId] INT           NOT NULL,
    [AcademicYears] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);