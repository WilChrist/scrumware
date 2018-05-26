
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2018 20:09:23
-- Generated from EDMX file: C:\Projets\scrumware\ScrumWare\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjetScrum];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ajoute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tache] DROP CONSTRAINT [FK_ajoute];
GO
IF OBJECT_ID(N'[dbo].[FK_BacklogTache]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tache] DROP CONSTRAINT [FK_BacklogTache];
GO
IF OBJECT_ID(N'[dbo].[FK_comporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStory] DROP CONSTRAINT [FK_comporte];
GO
IF OBJECT_ID(N'[dbo].[FK_Configure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sprint] DROP CONSTRAINT [FK_Configure];
GO
IF OBJECT_ID(N'[dbo].[FK_consiste_en]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tache] DROP CONSTRAINT [FK_consiste_en];
GO
IF OBJECT_ID(N'[dbo].[FK_correspond]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Backlog] DROP CONSTRAINT [FK_correspond];
GO
IF OBJECT_ID(N'[dbo].[FK_cree_Projet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjetUser] DROP CONSTRAINT [FK_cree_Projet];
GO
IF OBJECT_ID(N'[dbo].[FK_cree_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjetUser] DROP CONSTRAINT [FK_cree_User];
GO
IF OBJECT_ID(N'[dbo].[FK_joue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_joue];
GO
IF OBJECT_ID(N'[dbo].[FK_prend_en_charge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStory] DROP CONSTRAINT [FK_prend_en_charge];
GO
IF OBJECT_ID(N'[dbo].[FK_Propose]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStory] DROP CONSTRAINT [FK_Propose];
GO
IF OBJECT_ID(N'[dbo].[FK_S_execute_en]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sprint] DROP CONSTRAINT [FK_S_execute_en];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBacklog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Backlog] DROP CONSTRAINT [FK_UserBacklog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Backlog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Backlog];
GO
IF OBJECT_ID(N'[dbo].[Projet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projet];
GO
IF OBJECT_ID(N'[dbo].[ProjetUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjetUser];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Sprint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sprint];
GO
IF OBJECT_ID(N'[dbo].[Tache]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tache];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserStory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserStory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Backlogs'
CREATE TABLE [dbo].[Backlogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NULL,
    [State] nvarchar(max)  NOT NULL,
    [TotalEstimation] int  NULL,
    [Projet_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Projets'
CREATE TABLE [dbo].[Projets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Sprints'
CREATE TABLE [dbo].[Sprints] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NULL,
    [State] nvarchar(max)  NOT NULL,
    [Decision] nvarchar(max)  NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Cout] int  NULL,
    [Backlog_Id] int  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Taches'
CREATE TABLE [dbo].[Taches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NULL,
    [State] nvarchar(max)  NOT NULL,
    [Cout] int  NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Cout_Mon] int  NULL,
    [Cout_Tue] int  NULL,
    [Cout_Wen] int  NULL,
    [Cout_Thu] int  NULL,
    [Cout_Fri] int  NULL,
    [Backlog_Id] int  NULL,
    [Sprint_Id] int  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [MotPasse] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [SignUpDate] nvarchar(max)  NULL,
    [LastSignIn] datetime  NULL,
    [Description] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'UserStories'
CREATE TABLE [dbo].[UserStories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NULL,
    [State] nvarchar(max)  NOT NULL,
    [Priorite] int  NULL,
    [Estimation] int  NOT NULL,
    [Backlog_Id] int  NULL,
    [Sprint_Id] int  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ProjetUser'
CREATE TABLE [dbo].[ProjetUser] (
    [Projets_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Backlogs'
ALTER TABLE [dbo].[Backlogs]
ADD CONSTRAINT [PK_Backlogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projets'
ALTER TABLE [dbo].[Projets]
ADD CONSTRAINT [PK_Projets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sprints'
ALTER TABLE [dbo].[Sprints]
ADD CONSTRAINT [PK_Sprints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [PK_Taches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserStories'
ALTER TABLE [dbo].[UserStories]
ADD CONSTRAINT [PK_UserStories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Projets_Id], [Users_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [PK_ProjetUser]
    PRIMARY KEY CLUSTERED ([Projets_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Backlog_Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [FK_BacklogTache]
    FOREIGN KEY ([Backlog_Id])
    REFERENCES [dbo].[Backlogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BacklogTache'
CREATE INDEX [IX_FK_BacklogTache]
ON [dbo].[Taches]
    ([Backlog_Id]);
GO

-- Creating foreign key on [Backlog_Id] in table 'UserStories'
ALTER TABLE [dbo].[UserStories]
ADD CONSTRAINT [FK_comporte]
    FOREIGN KEY ([Backlog_Id])
    REFERENCES [dbo].[Backlogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_comporte'
CREATE INDEX [IX_FK_comporte]
ON [dbo].[UserStories]
    ([Backlog_Id]);
GO

-- Creating foreign key on [Projet_Id] in table 'Backlogs'
ALTER TABLE [dbo].[Backlogs]
ADD CONSTRAINT [FK_correspond]
    FOREIGN KEY ([Projet_Id])
    REFERENCES [dbo].[Projets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_correspond'
CREATE INDEX [IX_FK_correspond]
ON [dbo].[Backlogs]
    ([Projet_Id]);
GO

-- Creating foreign key on [Backlog_Id] in table 'Sprints'
ALTER TABLE [dbo].[Sprints]
ADD CONSTRAINT [FK_S_execute_en]
    FOREIGN KEY ([Backlog_Id])
    REFERENCES [dbo].[Backlogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_S_execute_en'
CREATE INDEX [IX_FK_S_execute_en]
ON [dbo].[Sprints]
    ([Backlog_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Backlogs'
ALTER TABLE [dbo].[Backlogs]
ADD CONSTRAINT [FK_UserBacklog]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBacklog'
CREATE INDEX [IX_FK_UserBacklog]
ON [dbo].[Backlogs]
    ([User_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_joue]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_joue'
CREATE INDEX [IX_FK_joue]
ON [dbo].[Users]
    ([Role_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Sprints'
ALTER TABLE [dbo].[Sprints]
ADD CONSTRAINT [FK_Configure]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Configure'
CREATE INDEX [IX_FK_Configure]
ON [dbo].[Sprints]
    ([User_Id]);
GO

-- Creating foreign key on [Sprint_Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [FK_consiste_en]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprints]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_consiste_en'
CREATE INDEX [IX_FK_consiste_en]
ON [dbo].[Taches]
    ([Sprint_Id]);
GO

-- Creating foreign key on [Sprint_Id] in table 'UserStories'
ALTER TABLE [dbo].[UserStories]
ADD CONSTRAINT [FK_prend_en_charge]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprints]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_prend_en_charge'
CREATE INDEX [IX_FK_prend_en_charge]
ON [dbo].[UserStories]
    ([Sprint_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [FK_ajoute]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ajoute'
CREATE INDEX [IX_FK_ajoute]
ON [dbo].[Taches]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserStories'
ALTER TABLE [dbo].[UserStories]
ADD CONSTRAINT [FK_Propose]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Propose'
CREATE INDEX [IX_FK_Propose]
ON [dbo].[UserStories]
    ([User_Id]);
GO

-- Creating foreign key on [Projets_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [FK_ProjetUser_Projet]
    FOREIGN KEY ([Projets_Id])
    REFERENCES [dbo].[Projets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [FK_ProjetUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjetUser_User'
CREATE INDEX [IX_FK_ProjetUser_User]
ON [dbo].[ProjetUser]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------