CREATE TABLE [Identity].[User]
(
    [Id] INT IDENTITY,
    [FirstName] NVARCHAR(100) NOT NULL,
    [MiddleName] NVARCHAR(100),
    [LastName] NVARCHAR(100) NOT NULL,
    [NameSuffix] NVARCHAR(5),
    [FullName] NVARCHAR(400) NOT NULL,
    [Username] NVARCHAR(50) NOT NULL,
    [SecurePassword] NVARCHAR(500) NOT NULL,
    [Status] TINYINT NOT NULL,
    [IsPasswordChangeRequired] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_User] PRIMARY KEY([Id])
);

ALTER TABLE [Identity].[User] ADD CONSTRAINT [DF_User_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO