USE [Sorschia];
GO

CREATE TABLE [dbo].[PermissionAspNetRoute]
(
    [Id] BIGINT IDENTITY,
    [PermissionId] INT NOT NULL,
    [AspNetArea] NVARCHAR(100),
    [AspNetController] NVARCHAR(100) NOT NULL,
    [AspNetAction] NVARCHAR(100) NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_PermissionAspNetRoute] PRIMARY KEY([Id]),
    CONSTRAINT [FK_PermissionAspNetRoute_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [dbo].[Permission]([Id])
);

ALTER TABLE [dbo].[PermissionAspNetRoute] ADD
    CONSTRAINT [DF_PermissionAspNetRoute_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO