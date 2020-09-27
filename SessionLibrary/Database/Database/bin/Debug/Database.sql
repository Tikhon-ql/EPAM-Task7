/*
Скрипт развертывания для SessionLibrary_7

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SessionLibrary_7"
:setvar DefaultFilePrefix "SessionLibrary_7"
:setvar DefaultDataPath "D:\Тихон\MySQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Тихон\MySQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Выполняется создание $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Выполняется создание [dbo].[Examiner]...';


GO
CREATE TABLE [dbo].[Examiner] (
    [Id]        INT           NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [Surname]   NVARCHAR (20) NOT NULL,
    [MidleName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Gender]...';


GO
CREATE TABLE [dbo].[Gender] (
    [Id]         INT           NOT NULL,
    [GenderName] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Group]...';


GO
CREATE TABLE [dbo].[Group] (
    [Id]              INT           NOT NULL,
    [GroupName]       NVARCHAR (20) NOT NULL,
    [SpecificationId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Session]...';


GO
CREATE TABLE [dbo].[Session] (
    [Id]            INT           NOT NULL,
    [SessionTypeId] INT           NOT NULL,
    [AcademicYears] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[SessionShedule]...';


GO
CREATE TABLE [dbo].[SessionShedule] (
    [Id]         INT      NOT NULL,
    [GroupId]    INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [SessionId]  INT      NOT NULL,
    [ExaminerId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[SessionType]...';


GO
CREATE TABLE [dbo].[SessionType] (
    [Id]              INT           NOT NULL,
    [SessionTypeName] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Specification]...';


GO
CREATE TABLE [dbo].[Specification] (
    [Id]                INT           NOT NULL,
    [SpecificationName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Student]...';


GO
CREATE TABLE [dbo].[Student] (
    [Id]        INT           NOT NULL,
    [Name]      NVARCHAR (30) NOT NULL,
    [Surname]   NVARCHAR (30) NOT NULL,
    [MidleName] NVARCHAR (30) NOT NULL,
    [GenderId]  INT           NOT NULL,
    [GroupId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Subject]...';


GO
CREATE TABLE [dbo].[Subject] (
    [Id]          INT           NOT NULL,
    [SubjectName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[WorkResult]...';


GO
CREATE TABLE [dbo].[WorkResult] (
    [Id]               INT           NOT NULL,
    [Result]           NVARCHAR (10) NOT NULL,
    [StudentId]        INT           NOT NULL,
    [SubjectId]        INT           NOT NULL,
    [WorkTypeId]       INT           NOT NULL,
    [SessionSheduleId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[WorkType]...';


GO
CREATE TABLE [dbo].[WorkType] (
    [Id]           INT           NOT NULL,
    [WorkTypeName] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.Session_dbo.SessionType_SessionTypeId]...';


GO
ALTER TABLE [dbo].[Session]
    ADD CONSTRAINT [FK_dbo.Session_dbo.SessionType_SessionTypeId] FOREIGN KEY ([SessionTypeId]) REFERENCES [dbo].[SessionType] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.SessionShedule_dbo.Session_SessionId]...';


GO
ALTER TABLE [dbo].[SessionShedule]
    ADD CONSTRAINT [FK_dbo.SessionShedule_dbo.Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.SessionShedule_dbo.Examiner_ExaminerId]...';


GO
ALTER TABLE [dbo].[SessionShedule]
    ADD CONSTRAINT [FK_dbo.SessionShedule_dbo.Examiner_ExaminerId] FOREIGN KEY ([ExaminerId]) REFERENCES [dbo].[Examiner] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.Student_dbo.Group_GroupId]...';


GO
ALTER TABLE [dbo].[Student]
    ADD CONSTRAINT [FK_dbo.Student_dbo.Group_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.Student_dbo.Gender_GenderId]...';


GO
ALTER TABLE [dbo].[Student]
    ADD CONSTRAINT [FK_dbo.Student_dbo.Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Gender] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.WorkResult_dbo.Student_StudentId]...';


GO
ALTER TABLE [dbo].[WorkResult]
    ADD CONSTRAINT [FK_dbo.WorkResult_dbo.Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.WorkResult_dbo.Subject_SubjectId]...';


GO
ALTER TABLE [dbo].[WorkResult]
    ADD CONSTRAINT [FK_dbo.WorkResult_dbo.Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.WorkResult_dbo.WorkType_WorkTypeId]...';


GO
ALTER TABLE [dbo].[WorkResult]
    ADD CONSTRAINT [FK_dbo.WorkResult_dbo.WorkType_WorkTypeId] FOREIGN KEY ([WorkTypeId]) REFERENCES [dbo].[WorkType] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_dbo.WorkResult_dbo.SessionShedule_SessionSheduleId]...';


GO
ALTER TABLE [dbo].[WorkResult]
    ADD CONSTRAINT [FK_dbo.WorkResult_dbo.SessionShedule_SessionSheduleId] FOREIGN KEY ([SessionSheduleId]) REFERENCES [dbo].[SessionShedule] ([Id]) ON DELETE CASCADE;


GO
insert into [Subject](Id,SubjectName) values (1,'Math')
GO
insert into [Subject](Id,SubjectName) values (2,'Physics')
GO
insert into [Subject](Id,SubjectName) values (3,'Philosophy')
GO
insert into [Subject](Id,SubjectName) values (4,'Psychology')
GO

insert into Examiner(Id,[Name],[Surname],MidleName) values (1,'Elena','Ivanova','Ivanovna')
GO
insert into Examiner(Id,[Name],[Surname],MidleName) values (2,'Petr','Sinichcin','Sergeevich')
GO
insert into Examiner(Id,[Name],[Surname],MidleName) values (3,'Oleg','Vetrov','Constantinovich')
GO
insert into Examiner(Id,[Name],[Surname],MidleName) values (4,'Anna','Petrova','Petrovna')
GO

insert into Specification(Id,SpecificationName) values (1,'First')
GO
insert into Specification(Id,SpecificationName) values (2,'Second')
GO
insert into Specification(Id,SpecificationName) values (3,'Third')
GO
insert into Specification(Id,SpecificationName) values (4,'Fourth')
GO

INSERT INTO WorkType (Id,WorkTypeName) VALUES (1,'Examen')
GO
insert into WorkType(Id,WorkTypeName) values (2,'Credit')
GO
insert into [Group](Id,GroupName,SpecificationId) values (1,'Group-1',1)
GO
insert into [Group](Id,GroupName,SpecificationId) values (2,'Group-2',2)
GO
insert into [Group](Id,GroupName,SpecificationId) values (3,'Group-3',3)
GO
insert into [Group](Id,GroupName,SpecificationId) values (4,'Group-4',4)
GO

insert into Gender(Id,GenderName) values (1,'Male')
GO
insert into Gender(Id,GenderName) values (2,'Female')
GO

insert into SessionType(Id,SessionTypeName) values (1,'Winter')
GO
insert into SessionType(Id,SessionTypeName) values (2,'Летняя')
GO




insert into [Session](Id,SessionTypeId,AcademicYears) values (1,1,'2019')
GO
insert into [Session](Id,SessionTypeId,AcademicYears) values (2,2,'2020')
GO

insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (1,1,'2019-10-11',1,1)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (2,2,'2019-15-11',1,2)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (3,3,'2020-10-07',1,3)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (4,4,'2020-14-07',1,4)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (5,1,'2019-13-11',1,1)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (6,2,'2019-14-11',1,2)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (7,3,'2020-15-07',1,3)
GO
insert into SessionShedule(Id,GroupId,[Date],SessionId,ExaminerId) values (8,4,'2020-16-07',2,4)
GO


insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (1,'Ivan','Ivanov','Ivanovich',1,1)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (2,'Andrey','Andreev','Andreevich',1,1)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (3,'Sergey','Sergeev','Sergeevich',1,1)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (4,'Anna','Ivanova','Ivanovna',2,1)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (5,'Alexandra','Krasnova','Sergeevna',2,2)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (6,'Petr','Petrov','Petrovich',1,2)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (7,'Evgeniy','Kirpitch','Victorivich',1,2)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (8,'Stepan','Stepanov','Stepanovich',1,3)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (9,'Maxim','Maximov','Maximovich',1,3)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (10,'Oleg','Ryba','Olegovich',1,3)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (11,'Ecaterina','Pervaya','Alecseevna',2,4)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (12,'Ilya','Ilyn','Ivanovich',1,4)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (13,'Denis','Denisov','Denisovich',1,4)
GO
insert into Student(Id,[Name],Surname,MidleName,GenderId,GroupId) values (14,'Sonya','Sonnaya','Genadyena',2,4)
GO



insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (1,'8',1,1,1,1)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values  (2,'9',2,2,1,2) 
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values  (3,'Credit',3,3,2,3)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values  (4,'Credit',4,4,2,4)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values  (5,'Uncredit',5,4,2,5)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (6,'Credit',6,3,2,6)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (7,'Credit',7,4,2,7)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (8,'Uncredit',8,3,2,8)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (9,'Credit',9,4,2,1)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (10,'Credit',10,3,2,2)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (11,'2',11,1,1,3)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (12,'3',12,2,1,4)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (13,'4',13,2,1,5)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (14,'6',14,1,1,6)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (15,'7',5,2,1,7)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (16,'8',2,1,1,8)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (17,'8',4,1,1,1)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (18,'9',1,2,1,2)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (19,'Credit',1,3,2,3)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (20,'6',2,1,1,4)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (21,'Uncredit',3,4,2,5)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (22,'2',4,1,1,6)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (23,'3',3,1,1,7)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (24,'8',9,1,1,8)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (25,'4',8,2,1,1)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (26,'7',10,1,1,2)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (27,'8',8,1,1,3)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (28,'6',9,2,1,4)
GO
insert into WorkResult(Id,Result,StudentId,SubjectId,WorkTypeId,SessionSheduleId) values (29,'8',10,2,1,5)

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Обновление завершено.';


GO
