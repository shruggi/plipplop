
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2014 23:34:21
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------