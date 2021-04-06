CREATE TABLE [Identity].[Permission]
(
    [Id] INT IDENTITY,
    [RoleId] INT,
    [LookupCode] NVARCHAR(20) NOT NULL,
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
    CONSTRAINT [FK_Permission_RoleId] FOREIGN KEY([RoleId]) REFERENCES [Identity].[Role]([Id])
);

ALTER TABLE [Identity].[Permission] ADD CONSTRAINT [DF_Permission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO