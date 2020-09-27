CREATE TABLE [dbo].[SessionShedule] (
    [Id]         INT      NOT NULL,
    [GroupId]    INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [SessionId]  INT      NOT NULL,
    [ExaminerId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

