
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2013 10:37:36
-- Generated from EDMX file: C:\Users\Lari\Documents\GitHub\SomeShop\OnlineStoreClient\OnlineStoreService\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PCStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountsSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentDetailsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentDetailsSet];
GO
IF OBJECT_ID(N'[dbo].[PurchasesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchasesSet];
GO
IF OBJECT_ID(N'[dbo].[ProductsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountsSet'
CREATE TABLE [dbo].[AccountsSet] (
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Type] bit  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] bit  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [FirstNameAcc] nvarchar(max)  NOT NULL,
    [LastNameAcc] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaymentDetailsSet'
CREATE TABLE [dbo].[PaymentDetailsSet] (
    [Username] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [District] nvarchar(max)  NOT NULL,
    [Town] nvarchar(max)  NOT NULL,
    [PostalCode] smallint  NOT NULL,
    [PayingAddress] nvarchar(max)  NOT NULL,
    [CardNumber] nvarchar(max)  NOT NULL,
    [DateOfExpire] datetime  NOT NULL,
    [SecurityCode] smallint  NOT NULL
);
GO

-- Creating table 'PurchasesSet'
CREATE TABLE [dbo].[PurchasesSet] (
    [Username] nvarchar(max)  NOT NULL,
    [ProductID] int  NOT NULL,
    [DateOfPurchase] datetime  NOT NULL,
    [PaymentStatement] nvarchar(max)  NOT NULL,
    [PurchaseCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductsSet'
CREATE TABLE [dbo].[ProductsSet] (
    [ProductID] int  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Cover] nvarchar(max)  NOT NULL,
    [ReleaseDate] datetime  NOT NULL,
    [Producer] nvarchar(max)  NOT NULL,
    [Score] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Username] in table 'AccountsSet'
ALTER TABLE [dbo].[AccountsSet]
ADD CONSTRAINT [PK_AccountsSet]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Username] in table 'PaymentDetailsSet'
ALTER TABLE [dbo].[PaymentDetailsSet]
ADD CONSTRAINT [PK_PaymentDetailsSet]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Username], [ProductID] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [PK_PurchasesSet]
    PRIMARY KEY CLUSTERED ([Username], [ProductID] ASC);
GO

-- Creating primary key on [ProductID] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [PK_ProductsSet]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------