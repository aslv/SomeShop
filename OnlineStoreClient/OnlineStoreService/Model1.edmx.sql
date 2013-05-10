
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2013 20:54:37
-- Generated from EDMX file: D:\ThriftShop\SomeShop\OnlineStoreClient\OnlineStoreService\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_AccountsSet_PaymentDetailsSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountsSet] DROP CONSTRAINT [FK_AccountsSet_PaymentDetailsSet];
GO
IF OBJECT_ID(N'[dbo].[FK_Promos_AccountsSet1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Promos] DROP CONSTRAINT [FK_Promos_AccountsSet1];
GO
IF OBJECT_ID(N'[dbo].[FK_Promos_ProductsSet1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Promos] DROP CONSTRAINT [FK_Promos_ProductsSet1];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchasesSet_AccountsSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchasesSet] DROP CONSTRAINT [FK_PurchasesSet_AccountsSet];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchasesSet_PurchasesSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchasesSet] DROP CONSTRAINT [FK_PurchasesSet_PurchasesSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountsSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentDetailsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentDetailsSet];
GO
IF OBJECT_ID(N'[dbo].[ProductsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductsSet];
GO
IF OBJECT_ID(N'[dbo].[Promos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Promos];
GO
IF OBJECT_ID(N'[dbo].[PurchasesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchasesSet];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountsSet'
CREATE TABLE [dbo].[AccountsSet] (
    [Username] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Type] bit  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] bit  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [FirstNameAcc] nvarchar(max)  NOT NULL,
    [LastNameAcc] nvarchar(max)  NOT NULL,
    [Role] bit  NULL,
    [AccBalance] decimal(19,4)  NULL
);
GO

-- Creating table 'PaymentDetailsSet'
CREATE TABLE [dbo].[PaymentDetailsSet] (
    [Username] nvarchar(50)  NOT NULL,
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

-- Creating table 'ProductsSet'
CREATE TABLE [dbo].[ProductsSet] (
    [ProductID] nvarchar(50)  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Cover] nvarchar(max)  NULL,
    [ReleaseDate] datetime  NULL,
    [Producer] nvarchar(max)  NULL,
    [Score] smallint  NULL,
    [Price] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Promos'
CREATE TABLE [dbo].[Promos] (
    [Username] nvarchar(50)  NOT NULL,
    [ProductID] nvarchar(50)  NOT NULL,
    [Discount] smallint  NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'PurchasesSet'
CREATE TABLE [dbo].[PurchasesSet] (
    [Username] nvarchar(50)  NOT NULL,
    [ProductID] nvarchar(50)  NOT NULL,
    [DateOfPurchase] datetime  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
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

-- Creating primary key on [ProductID] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [PK_ProductsSet]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [Username], [ProductID] in table 'Promos'
ALTER TABLE [dbo].[Promos]
ADD CONSTRAINT [PK_Promos]
    PRIMARY KEY CLUSTERED ([Username], [ProductID] ASC);
GO

-- Creating primary key on [Username], [ProductID] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [PK_PurchasesSet]
    PRIMARY KEY CLUSTERED ([Username], [ProductID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Username] in table 'AccountsSet'
ALTER TABLE [dbo].[AccountsSet]
ADD CONSTRAINT [FK_AccountsSet_PaymentDetailsSet]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[PaymentDetailsSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Username] in table 'Promos'
ALTER TABLE [dbo].[Promos]
ADD CONSTRAINT [FK_Promos_AccountsSet1]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[AccountsSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Username] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [FK_PurchasesSet_AccountsSet]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[AccountsSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'Promos'
ALTER TABLE [dbo].[Promos]
ADD CONSTRAINT [FK_Promos_ProductsSet1]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductsSet]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Promos_ProductsSet1'
CREATE INDEX [IX_FK_Promos_ProductsSet1]
ON [dbo].[Promos]
    ([ProductID]);
GO

-- Creating foreign key on [ProductID] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [FK_PurchasesSet_PurchasesSet]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductsSet]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchasesSet_PurchasesSet'
CREATE INDEX [IX_FK_PurchasesSet_PurchasesSet]
ON [dbo].[PurchasesSet]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------