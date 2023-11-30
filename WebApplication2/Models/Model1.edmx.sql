
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2023 21:58:55
-- Generated from EDMX file: C:\Users\LabInfo\source\repos\WebApplication2\WebApplication2\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [empregado];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dependente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dependente];
GO
IF OBJECT_ID(N'[dbo].[Empregado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empregado];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dependente'
CREATE TABLE [dbo].[Dependente] (
    [id_dependente] int  NOT NULL,
    [nome] varchar(50)  NULL,
    [cpf] int  NULL,
    [endereço] varchar(50)  NULL,
    [data_nasc] datetime  NULL
);
GO

-- Creating table 'Empregado'
CREATE TABLE [dbo].[Empregado] (
    [id_empregado] int  NOT NULL,
    [nome] varchar(50)  NULL,
    [matrícula] int  NULL,
    [cpf] int  NULL,
    [endereço] varchar(50)  NULL,
    [id_dependente] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_dependente] in table 'Dependente'
ALTER TABLE [dbo].[Dependente]
ADD CONSTRAINT [PK_Dependente]
    PRIMARY KEY CLUSTERED ([id_dependente] ASC);
GO

-- Creating primary key on [id_empregado] in table 'Empregado'
ALTER TABLE [dbo].[Empregado]
ADD CONSTRAINT [PK_Empregado]
    PRIMARY KEY CLUSTERED ([id_empregado] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_dependente] in table 'Empregado'
ALTER TABLE [dbo].[Empregado]
ADD CONSTRAINT [FK_DependenteEmpregado]
    FOREIGN KEY ([id_dependente])
    REFERENCES [dbo].[Dependente]
        ([id_dependente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DependenteEmpregado'
CREATE INDEX [IX_FK_DependenteEmpregado]
ON [dbo].[Empregado]
    ([id_dependente]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------