USE [Sorschia];
GO

CREATE TABLE [dbo].[Application]
(
    [Id] SMALLINT IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500),
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_Application] PRIMARY KEY([Id])
);

ALTER TABLE [dbo].[Application] ADD
    CONSTRAINT [DF_Application_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO