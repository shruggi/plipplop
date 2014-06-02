
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2014 18:33:04
-- Generated from EDMX file: C:\Users\shrug\Documents\Visual Studio 2013\Projects\ConsoleApplication1\ConsoleApplication1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mopidy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TrackSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrackSet];
GO
IF OBJECT_ID(N'[dbo].[PlaylistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaylistSet];
GO
IF OBJECT_ID(N'[dbo].[SupplementalPlaylistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SupplementalPlaylistSet];
GO
IF OBJECT_ID(N'[dbo].[CurrentPlaylistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrentPlaylistSet];
GO
IF OBJECT_ID(N'[dbo].[PlaylistView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaylistView];
GO
IF OBJECT_ID(N'[dbo].[SupplementalPlaylistView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SupplementalPlaylistView];
GO
IF OBJECT_ID(N'[dbo].[QueuelistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QueuelistSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TrackSet'
CREATE TABLE [dbo].[TrackSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [album] nvarchar(max)  NULL,
    [title] nvarchar(max)  NULL,
    [track] nvarchar(max)  NULL,
    [artist] nvarchar(max)  NULL,
    [genre] nvarchar(max)  NULL,
    [filename] nvarchar(max)  NULL,
    [runningtime] int  NULL,
    [date] datetime  NULL,
    [weight] int  NULL
);
GO

-- Creating table 'PlaylistSet'
CREATE TABLE [dbo].[PlaylistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TrackId] int  NOT NULL
);
GO

-- Creating table 'SupplementalPlaylistSet'
CREATE TABLE [dbo].[SupplementalPlaylistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TrackId] int  NOT NULL,
    [Owner] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CurrentPlaylistSet'
CREATE TABLE [dbo].[CurrentPlaylistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [pos] int  NOT NULL,
    [artist] nvarchar(max)  NOT NULL,
    [title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlaylistView'
CREATE TABLE [dbo].[PlaylistView] (
    [Id] int  NOT NULL,
    [artist] nvarchar(max)  NULL,
    [title] nvarchar(max)  NULL
);
GO

-- Creating table 'SupplementalPlaylistView'
CREATE TABLE [dbo].[SupplementalPlaylistView] (
    [Id] int  NOT NULL,
    [artist] nvarchar(max)  NULL,
    [title] nvarchar(max)  NULL,
    [Owner] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'QueuelistSet'
CREATE TABLE [dbo].[QueuelistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TrackId] int  NOT NULL,
    [addtime] datetime  NOT NULL,
    [source] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TrackSet'
ALTER TABLE [dbo].[TrackSet]
ADD CONSTRAINT [PK_TrackSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaylistSet'
ALTER TABLE [dbo].[PlaylistSet]
ADD CONSTRAINT [PK_PlaylistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SupplementalPlaylistSet'
ALTER TABLE [dbo].[SupplementalPlaylistSet]
ADD CONSTRAINT [PK_SupplementalPlaylistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CurrentPlaylistSet'
ALTER TABLE [dbo].[CurrentPlaylistSet]
ADD CONSTRAINT [PK_CurrentPlaylistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaylistView'
ALTER TABLE [dbo].[PlaylistView]
ADD CONSTRAINT [PK_PlaylistView]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SupplementalPlaylistView'
ALTER TABLE [dbo].[SupplementalPlaylistView]
ADD CONSTRAINT [PK_SupplementalPlaylistView]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QueuelistSet'
ALTER TABLE [dbo].[QueuelistSet]
ADD CONSTRAINT [PK_QueuelistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------