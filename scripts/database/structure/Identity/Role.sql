CREATE TABLE [Identity].[Role]
(
    [Id] INT IDENTITY,
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
    CONSTRAINT [PK_Role] PRIMARY KEY([Id])
);

ALTER TABLE [Identity].[Role] ADD CONSTRAINT [DF_Role_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO