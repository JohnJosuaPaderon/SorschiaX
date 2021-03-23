USE [Sorschia];
GO

CREATE TABLE [dbo].[User]
(
    [Id] INT IDENTITY,
    [FirstName] NVARCHAR(100) NOT NULL,
    [MiddleName] NVARCHAR(100),
    [LastName] NVARCHAR(100) NOT NULL,
    [NameSuffix] NVARCHAR(5),
    [FullName] NVARCHAR(350) NOT NULL,
    [Username] NVARCHAR(300) NOT NULL,
    [SecurePassword] NVARCHAR(300) NOT NULL,
    [EmailAddress] NVARCHAR(300),
    [MobileNumber] NVARCHAR(20),
    [IsActive] BIT NOT NULL,
    [IsPasswordChangeRequired] BIT NOT NULL,
    [IsEmailAddressVerified] BIT NOT NULL,
    [IsMobileNumberVerified] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [UpdatedById] INT,
    [UpdatedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_User] PRIMARY KEY([Id])
);

ALTER TABLE [dbo].[User] ADD
    CONSTRAINT [DF_User_IsActive] DEFAULT 0 FOR [IsActive],
    CONSTRAINT [DF_User_IsPasswordChangeRequired] DEFAULT 0 FOR [IsPasswordChangeRequired],
    CONSTRAINT [DF_User_IsEmailAddressVerified] DEFAULT 0 FOR [IsEmailAddressVerified],
    CONSTRAINT [DF_User_IsMobileNumberVerified] DEFAULT 0 FOR [IsMobileNumberVerified],
    CONSTRAINT [DF_User_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO