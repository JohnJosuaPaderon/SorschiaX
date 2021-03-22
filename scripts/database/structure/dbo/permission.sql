USE [Sorschia];
GO

CREATE TABLE [dbo].[Permission]
(
    [Id] INT IDENTITY,
    [ApplicationId] SMALLINT,
    [RoleId] INT,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500),
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_Permission] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Permission_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [dbo].[Application]([Id]),
    CONSTRAINT [FK_Permission_RoleId] FOREIGN KEY([RoleId]) REFERENCES [dbo].[Role]([Id])
);

ALTER TABLE [dbo].[Permission] ADD
    CONSTRAINT [DF_Permission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO