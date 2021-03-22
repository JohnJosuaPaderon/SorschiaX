USE [Sorschia];
GO

CREATE TABLE [dbo].[UserPermission]
(
    [Id] BIGINT IDENTITY,
    [UserId] INT NOT NULL,
    [PermissionId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_UserPermission] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserPermission_UserId] FOREIGN KEY([UserId]) REFERENCES [dbo].[User]([Id]),
    CONSTRAINT [FK_UserPermission_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [dbo].[Permission]([Id])
);

ALTER TABLE [dbo].[UserPermission] ADD
    CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO