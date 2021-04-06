CREATE TABLE [Identity].[UserPermission]
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
    CONSTRAINT [FK_UserPermission_UserId] FOREIGN KEY([UserId]) REFERENCES [Identity].[User]([Id]),
    CONSTRAINT [FK_UserPermission_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [Identity].[Permission]([Id])
);

ALTER TABLE [Identity].[UserPermission] ADD CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO