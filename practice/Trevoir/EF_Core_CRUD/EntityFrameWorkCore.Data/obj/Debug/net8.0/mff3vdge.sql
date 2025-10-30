IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Coaches] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Coaches] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Teams] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251021150208_InitialMigrationPracticeDB', N'8.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
    SET IDENTITY_INSERT [Teams] ON;
INSERT INTO [Teams] ([Id], [Country], [CreatedDate], [Name])
VALUES (1, N'Italy', '2025-10-21T00:00:00.0000000+03:00', N'AC Milan'),
(2, N'Italy', '2025-10-21T00:00:00.0000000+03:00', N'Inter Milan'),
(3, N'Italy', '2025-10-21T00:00:00.0000000+03:00', N'Juventus'),
(4, N'England', '2025-10-21T00:00:00.0000000+03:00', N'Manchester United'),
(5, N'England', '2025-10-21T00:00:00.0000000+03:00', N'Manchester City'),
(6, N'England', '2025-10-21T00:00:00.0000000+03:00', N'Chelsea'),
(7, N'England', '2025-10-21T00:00:00.0000000+03:00', N'Liverpool');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Teams]'))
    SET IDENTITY_INSERT [Teams] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251021151450_SeededTeams', N'8.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Teams] ALTER COLUMN [Name] nvarchar(max) NULL;
GO

ALTER TABLE [Teams] ADD [CoachId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Teams] ADD [CreatedBy] nvarchar(max) NULL;
GO

ALTER TABLE [Teams] ADD [LeagueId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Teams] ADD [ModifiedBy] nvarchar(max) NULL;
GO

ALTER TABLE [Teams] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Coaches]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Coaches] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Coaches] ALTER COLUMN [Name] nvarchar(max) NULL;
GO

ALTER TABLE [Coaches] ADD [CreatedBy] nvarchar(max) NULL;
GO

ALTER TABLE [Coaches] ADD [ModifiedBy] nvarchar(max) NULL;
GO

ALTER TABLE [Coaches] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

CREATE TABLE [Leagues] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Country] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Leagues] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Matches] (
    [Id] int NOT NULL IDENTITY,
    [HomeTeamId] int NOT NULL,
    [AwayTeamId] int NOT NULL,
    [TicketPrice] decimal(18,2) NOT NULL,
    [Date] datetime2 NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Matches] PRIMARY KEY ([Id])
);
GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Teams] SET [CoachId] = 0, [CreatedBy] = N'Admin', [CreatedDate] = '2025-10-22T00:00:00.0000000+03:00', [LeagueId] = 0, [ModifiedBy] = NULL, [ModifiedDate] = '0001-01-01T00:00:00.0000000'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251022151314_AddMoreEntities', N'8.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'Country');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Teams] ALTER COLUMN [Country] nvarchar(max) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Matches]') AND [c].[name] = N'Country');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Matches] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Matches] ALTER COLUMN [Country] nvarchar(max) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Leagues]') AND [c].[name] = N'Country');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Leagues] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Leagues] ALTER COLUMN [Country] nvarchar(max) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Coaches]') AND [c].[name] = N'Country');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Coaches] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Coaches] ALTER COLUMN [Country] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251022152305_SeedingTeamsAgain', N'8.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'CreatedBy', N'CreatedDate', N'ModifiedBy', N'ModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] ON;
INSERT INTO [Leagues] ([Id], [Country], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Name])
VALUES (1, N'Italy', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'Serie A'),
(2, N'England', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'EPL'),
(3, N'Spain', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'La Liga'),
(4, N'France', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'Ligue 1'),
(5, N'Netherlands', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'Eredivisie'),
(6, N'Germany', N'Admin', '2025-10-22T00:00:00.0000000+03:00', NULL, '0001-01-01T00:00:00.0000000', N'Bundesliga');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'CreatedBy', N'CreatedDate', N'ModifiedBy', N'ModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251022164514_AddedSeedsTeamsLeagues', N'8.0.21');
GO

COMMIT;
GO

