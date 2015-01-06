
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/06/2015 17:11:10
-- Generated from EDMX file: P:\GitHub\CardFileBooks\CardFileBooks\Core.DB\CardFileBooks_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CardFileBooksDatabase];
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

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [GenreId] int IDENTITY(1,1) NOT NULL,
    [GenreName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [AuthorId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [PlaceOfBirth] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [FinalReleaseDate] datetime  NOT NULL,
    [Publisher] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [NumberOfPages] int  NOT NULL,
    [ISBN] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GenreBook'
CREATE TABLE [dbo].[GenreBook] (
    [Genre_GenreId] int  NOT NULL,
    [Book_BookId] int  NOT NULL
);
GO

-- Creating table 'AuthorBook'
CREATE TABLE [dbo].[AuthorBook] (
    [Author_AuthorId] int  NOT NULL,
    [Book_BookId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GenreId] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([GenreId] ASC);
GO

-- Creating primary key on [AuthorId] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([AuthorId] ASC);
GO

-- Creating primary key on [BookId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- Creating primary key on [Genre_GenreId], [Book_BookId] in table 'GenreBook'
ALTER TABLE [dbo].[GenreBook]
ADD CONSTRAINT [PK_GenreBook]
    PRIMARY KEY CLUSTERED ([Genre_GenreId], [Book_BookId] ASC);
GO

-- Creating primary key on [Author_AuthorId], [Book_BookId] in table 'AuthorBook'
ALTER TABLE [dbo].[AuthorBook]
ADD CONSTRAINT [PK_AuthorBook]
    PRIMARY KEY CLUSTERED ([Author_AuthorId], [Book_BookId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Genre_GenreId] in table 'GenreBook'
ALTER TABLE [dbo].[GenreBook]
ADD CONSTRAINT [FK_GenreBook_Genre]
    FOREIGN KEY ([Genre_GenreId])
    REFERENCES [dbo].[Genres]
        ([GenreId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Book_BookId] in table 'GenreBook'
ALTER TABLE [dbo].[GenreBook]
ADD CONSTRAINT [FK_GenreBook_Book]
    FOREIGN KEY ([Book_BookId])
    REFERENCES [dbo].[Books]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenreBook_Book'
CREATE INDEX [IX_FK_GenreBook_Book]
ON [dbo].[GenreBook]
    ([Book_BookId]);
GO

-- Creating foreign key on [Author_AuthorId] in table 'AuthorBook'
ALTER TABLE [dbo].[AuthorBook]
ADD CONSTRAINT [FK_AuthorBook_Author]
    FOREIGN KEY ([Author_AuthorId])
    REFERENCES [dbo].[Authors]
        ([AuthorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Book_BookId] in table 'AuthorBook'
ALTER TABLE [dbo].[AuthorBook]
ADD CONSTRAINT [FK_AuthorBook_Book]
    FOREIGN KEY ([Book_BookId])
    REFERENCES [dbo].[Books]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorBook_Book'
CREATE INDEX [IX_FK_AuthorBook_Book]
ON [dbo].[AuthorBook]
    ([Book_BookId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------