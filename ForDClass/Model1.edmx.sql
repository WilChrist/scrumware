
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2018 23:35:59
-- Generated from EDMX file: C:\Projets\scrumware\ForDClass\Model1.edmx
-- -------------------------------------------------- 

SET QUOTED_IDENTIFIER OFF;
GO
USE [TEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_joue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_joue];
GO
IF OBJECT_ID(N'[dbo].[FK_cree_Projet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjetUser] DROP CONSTRAINT [FK_cree_Projet];
GO
IF OBJECT_ID(N'[dbo].[FK_cree_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjetUser] DROP CONSTRAINT [FK_cree_User];
GO
IF OBJECT_ID(N'[dbo].[FK_correspond]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Backlogs] DROP CONSTRAINT [FK_correspond];
GO
IF OBJECT_ID(N'[dbo].[FK_comporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStorys] DROP CONSTRAINT [FK_comporte];
GO
IF OBJECT_ID(N'[dbo].[FK_S_execute_en]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sprint] DROP CONSTRAINT [FK_S_execute_en];
GO
IF OBJECT_ID(N'[dbo].[FK_BacklogTache]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Taches] DROP CONSTRAINT [FK_BacklogTache];
GO
IF OBJECT_ID(N'[dbo].[FK_consiste_en]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Taches] DROP CONSTRAINT [FK_consiste_en];
GO
IF OBJECT_ID(N'[dbo].[FK_prend_en_charge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStorys] DROP CONSTRAINT [FK_prend_en_charge];
GO
IF OBJECT_ID(N'[dbo].[FK_ajoute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Taches] DROP CONSTRAINT [FK_ajoute];
GO
IF OBJECT_ID(N'[dbo].[FK_Configure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sprint] DROP CONSTRAINT [FK_Configure];
GO
IF OBJECT_ID(N'[dbo].[FK_Propose]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserStorys] DROP CONSTRAINT [FK_Propose];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBacklog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Backlogs] DROP CONSTRAINT [FK_UserBacklog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Projets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projets];
GO
IF OBJECT_ID(N'[dbo].[Backlogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Backlogs];
GO
IF OBJECT_ID(N'[dbo].[UserStorys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserStorys];
GO
IF OBJECT_ID(N'[dbo].[Sprint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sprint];
GO
IF OBJECT_ID(N'[dbo].[Taches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taches];
GO
IF OBJECT_ID(N'[dbo].[ProjetUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjetUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [SignUpDate] nvarchar(max)  NULL,
    [LastSignIn] datetime  NULL,
    [Description] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
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

-- Creating table 'UserStorys'
CREATE TABLE [dbo].[UserStorys] (
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

-- Creating table 'Sprint'
CREATE TABLE [dbo].[Sprint] (
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

-- Creating table 'ProjetUser'
CREATE TABLE [dbo].[ProjetUser] (
    [Projet_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projets'
ALTER TABLE [dbo].[Projets]
ADD CONSTRAINT [PK_Projets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Backlogs'
ALTER TABLE [dbo].[Backlogs]
ADD CONSTRAINT [PK_Backlogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserStorys'
ALTER TABLE [dbo].[UserStorys]
ADD CONSTRAINT [PK_UserStorys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sprint'
ALTER TABLE [dbo].[Sprint]
ADD CONSTRAINT [PK_Sprint]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [PK_Taches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Projet_Id], [User_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [PK_ProjetUser]
    PRIMARY KEY CLUSTERED ([Projet_Id], [User_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [Projet_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [FK_cree_Projet]
    FOREIGN KEY ([Projet_Id])
    REFERENCES [dbo].[Projets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'ProjetUser'
ALTER TABLE [dbo].[ProjetUser]
ADD CONSTRAINT [FK_cree_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cree_User'
CREATE INDEX [IX_FK_cree_User]
ON [dbo].[ProjetUser]
    ([User_Id]);
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

-- Creating foreign key on [Backlog_Id] in table 'UserStorys'
ALTER TABLE [dbo].[UserStorys]
ADD CONSTRAINT [FK_comporte]
    FOREIGN KEY ([Backlog_Id])
    REFERENCES [dbo].[Backlogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_comporte'
CREATE INDEX [IX_FK_comporte]
ON [dbo].[UserStorys]
    ([Backlog_Id]);
GO

-- Creating foreign key on [Backlog_Id] in table 'Sprint'
ALTER TABLE [dbo].[Sprint]
ADD CONSTRAINT [FK_S_execute_en]
    FOREIGN KEY ([Backlog_Id])
    REFERENCES [dbo].[Backlogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_S_execute_en'
CREATE INDEX [IX_FK_S_execute_en]
ON [dbo].[Sprint]
    ([Backlog_Id]);
GO

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

-- Creating foreign key on [Sprint_Id] in table 'Taches'
ALTER TABLE [dbo].[Taches]
ADD CONSTRAINT [FK_consiste_en]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprint]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_consiste_en'
CREATE INDEX [IX_FK_consiste_en]
ON [dbo].[Taches]
    ([Sprint_Id]);
GO

-- Creating foreign key on [Sprint_Id] in table 'UserStorys'
ALTER TABLE [dbo].[UserStorys]
ADD CONSTRAINT [FK_prend_en_charge]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprint]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_prend_en_charge'
CREATE INDEX [IX_FK_prend_en_charge]
ON [dbo].[UserStorys]
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

-- Creating foreign key on [User_Id] in table 'Sprint'
ALTER TABLE [dbo].[Sprint]
ADD CONSTRAINT [FK_Configure]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Configure'
CREATE INDEX [IX_FK_Configure]
ON [dbo].[Sprint]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserStorys'
ALTER TABLE [dbo].[UserStorys]
ADD CONSTRAINT [FK_Propose]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Propose'
CREATE INDEX [IX_FK_Propose]
ON [dbo].[UserStorys]
    ([User_Id]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------