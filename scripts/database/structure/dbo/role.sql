USE [Sorschia];
GO

CREATE TABLE [dbo].[Role]
(
    [Id] INT IDENTITY,
    [ApplicationId] SMALLINT,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500),
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_Role] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Role_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [dbo].[Application]([Id])
);

ALTER TABLE [dbo].[Role] ADD
    CONSTRAINT [DF_Role_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO