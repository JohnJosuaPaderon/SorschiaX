-- USE [master];
-- GO

-- DROP DATABASE [Sorschia];
-- GO

-- CREATE DATABASE [Sorschia];
-- GO

USE [Sorschia];
GO

-- CREATE SCHEMA [SystemCore];
-- GO

-- ----------------------------------------------------------------------------------------------------
-- DROP TABLES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- DROP TABLES: 4TH DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- DROP TABLES: 4TH DEPENDENCY > SystemCore.RefreshToken
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.RefreshToken', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[RefreshToken];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: 3RD DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- DROP TABLES: 3RD DEPENDENCY > SystemCore.AccessToken
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.AccessToken', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[AccessToken];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: 3RD DEPENDENCY > SystemCore.UserModule
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserModule', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserModule];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: 2ND DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- DROP TABLES: 2ND DEPENDENCY > SystemCore.Module
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Module', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Module];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: 2ND DEPENDENCY > SystemCore.Session
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Session', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Session];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: 2ND DEPENDENCY > SystemCore.UserApplication
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserApplication', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserApplication];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: 2ND DEPENDENCY > SystemCore.UserPermission
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserPermission', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserPermission];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: 1ST DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- DROP TABLES: 1ST DEPENDENCY > SystemCore.Application
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Application', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Application];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: 1ST DEPENDENCY > SystemCore.Permission
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Permission', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Permission];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: NO/SELF DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- DROP TABLES: NO/SELF DEPENDENCY > SystemCore.PermissionGroup
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.PermissionGroup', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[PermissionGroup];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: NO/SELF DEPENDENCY > SystemCore.Platform
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Platform', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Platform];
GO

-- ----------------------------------------------------------------------
-- DROP TABLES: NO/SELF DEPENDENCY > SystemCore.User
-- ----------------------------------------------------------------------

IF OBJECT_ID('SystemCore.User', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[User];
GO

-- ----------------------------------------------------------------------------------------------------
-- CREATE TABLES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: NO/SELF DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- CREATE TABLES: NO/SELF DEPENDENCY > SystemCore.PermissionGroup
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[PermissionGroup]
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [ParentId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_PermissionGroup] PRIMARY KEY([Id]),
    CONSTRAINT [FK_PermissionGroup_ParentId] FOREIGN KEY([ParentId]) REFERENCES [SystemCore].[PermissionGroup]([Id])
);

ALTER TABLE [SystemCore].[PermissionGroup] ADD
    CONSTRAINT [DF_PermissionGroup_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_PermissionGroup_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: NO/SELF DEPENDENCY > SystemCore.Platform
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[Platform] 
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Platform] PRIMARY KEY([Id])
);

ALTER TABLE [SystemCore].[Platform] ADD
    CONSTRAINT [DF_Platform_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Platform_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: NO/SELF DEPENDENCY > SystemCore.User
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[User]
(  
    [Id] INT IDENTITY,
    [FirstName] NVARCHAR(75) NOT NULL,
    [MiddleName] NVARCHAR(75),
    [LastName] NVARCHAR(75) NOT NULL,
    [NameExtension] NVARCHAR(10),
    [FullName] NVARCHAR(250),
    [Username] NVARCHAR(250) NOT NULL,
    [PasswordHash] NVARCHAR(250) NOT NULL,
    [IsActive] BIT NOT NULL,
    [IsPasswordChangeRequired] BIT NOT NULL,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_User] PRIMARY KEY([Id])
);

ALTER TABLE [SystemCore].[User] ADD
    CONSTRAINT [DF_User_IsActive] DEFAULT 0 FOR [IsActive],
    CONSTRAINT [DF_User_IsPasswordChangeRequired] DEFAULT 1 FOR [IsPasswordChangeRequired],
    CONSTRAINT [DF_User_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_User_IsDeleted] DEFAULT 0 FOR [IsDeleted]
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: 1ST DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- CREATE TABLES: 1ST DEPENDENCY > SystemCore.Application
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[Application]
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(250) NOT NULL,
    [PlatformId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Application] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Application_PlatformId] FOREIGN KEY([PlatformId]) REFERENCES [SystemCore].[Platform]([Id])
);

ALTER TABLE [SystemCore].[Application] ADD
    CONSTRAINT [DF_Application_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Application_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: 1ST DEPENDENCY > SystemCore.Permission
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[Permission]
(
    [Id] INT IDENTITY,
    [Description] NVARCHAR(250) NOT NULL,
    [IsApiPermission] BIT NOT NULL,
    [ApiDomain] NVARCHAR(250),
    [ApiController] NVARCHAR(250),
    [ApiAction] NVARCHAR(250),
    [IsDatabasePermission] BIT NOT NULL,
    [DatabaseSchema] NVARCHAR(250),
    [DatabaseProcedure] NVARCHAR(250),
    [GroupId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Permission] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Permission_GroupId] FOREIGN KEY([GroupId]) REFERENCES [SystemCore].[PermissionGroup]([Id])
);

ALTER TABLE [SystemCore].[Permission] ADD
    CONSTRAINT [DF_Permission_IsApiPermission] DEFAULT 0 FOR [IsApiPermission],
    CONSTRAINT [DF_Permission_IsDatabasePermission] DEFAULT 0 FOR [IsDatabasePermission],
    CONSTRAINT [DF_Permission_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Permission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: 2ND DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- CREATE TABLES: 2ND DEPENDENCY > SystemCore.Module
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[Module]
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(250) NOT NULL,
    [OrdinalNumber] INT NOT NULL,
    [ApplicationId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Module] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Module_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id])
);

ALTER TABLE [SystemCore].[Module] ADD
    CONSTRAINT [DF_Module_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Module_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: 2ND DEPENDENCY > SystemCore.Session
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[Session]
(
    [Id] BIGINT IDENTITY,
    [MacAddress] NVARCHAR(100),
    [IpAddress] NVARCHAR(100),
    [OperatingSystem] NVARCHAR(100),
    [SessionStart] DATETIME,
    [SessionEnd] DATETIME,
    [UserId] INT,
    [ApplicationId] INT,
    [IsDeleted] BIT NOT NULL,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Session] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Session_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_Session_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id])
);

ALTER TABLE [SystemCore].[Session] ADD
    CONSTRAINT [DF_Session_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: 2ND DEPENDENCY > SystemCore.UserApplication
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[UserApplication]
(
    [Id] BIGINT IDENTITY,
    [IsApproved] BIT NOT NULL,
    [Expiration] DATETIME,
    [IsExpired] BIT NOT NULL,
    [UserId] INT,
    [ApplicationId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_UserApplication] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserApplication_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserApplication_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id])
);

ALTER TABLE [SystemCore].[UserApplication] ADD
    CONSTRAINT [DF_UserApplication_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserApplication_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserApplication_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserApplication_ISDeleted] DEFAULT 0 FOR  [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: 2ND DEPENDENCY > SystemCore.UserPermission
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[UserPermission]
(
    [Id] BIGINT IDENTITY,
    [IsApproved] BIT NOT NULL,
    [Expiration] DATETIME,
    [IsExpired] BIT NOT NULL,
    [UserId] INT,
    [PermissionId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_UserPermission] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserPermission_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserPermission_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [SystemCore].[Permission]([Id])
);

ALTER TABLE [SystemCore].[UserPermission] ADD
    CONSTRAINT [DF_UserPermisison_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserPermission_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserPermission_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: 3RD DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- CREATE TABLES: 3RD DEPENDENCY > SystemCore.AccessToken
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[AccessToken]
(
    [Id] BIGINT IDENTITY,
    [TokenString] NVARCHAR(500) NOT NULL,
    [Expiration] DATETIME NOT NULL,
    [SessionId] BIGINT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    CONSTRAINT [PK_AccessToken] PRIMARY KEY([Id]),
    CONSTRAINT [FK_AccessToken_SessionId] FOREIGN KEY([SessionId]) REFERENCES [SystemCore].[Session]([Id])
);

ALTER TABLE [SystemCore].[AccessToken] ADD
    CONSTRAINT [DF_AccessToken_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------
-- CREATE TABLES: 3RD DEPENDENCY > SystemCore.UserModule
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[UserModule]
(
    [Id] BIGINT IDENTITY,
    [IsApproved] BIT NOT NULL,
    [Expiration] DATETIME,
    [IsExpired] BIT NOT NULL,
    [UserId] INT,
    [ModuleId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_UserModule] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserModule_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserModule_ModuleId] FOREIGN KEY([ModuleId]) REFERENCES [SystemCore].[Module]([Id])
);

ALTER TABLE [SystemCore].[UserModule] ADD
    CONSTRAINT [DF_UserModule_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserModule_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserModule_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserModule_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: 4TH DEPENDENCY
-- -------------------------------------------------------------------------------------

-- ----------------------------------------------------------------------
-- CREATE TABLES: 4TH DEPENDENCY > SystemCore.RefreshToken
-- ----------------------------------------------------------------------

CREATE TABLE [SystemCore].[RefreshToken]
(
    [Id] BIGINT IDENTITY,
    [TokenString] NVARCHAR(500) NOT NULL,
    [AccessTokenId] BIGINT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY([Id]),
    CONSTRAINT [FK_RefreshToken_AccessTokenId] FOREIGN KEY([AccessTokenId]) REFERENCES [SystemCore].[AccessToken]([Id])
);

ALTER TABLE [SystemCore].[RefreshToken] ADD
    CONSTRAINT [DF_RefreshToken_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------------------------------------
-- INITIAL DATA
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.PermissionGroup
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[PermissionGroup] ON;
GO

INSERT INTO [SystemCore].[PermissionGroup]([Id], [Name], [IsSystemDefined], [InsertedById], [Insertedon])
VALUES(1, '* System', 1, -1, GETDATE());
GO

INSERT INTO [SystemCore].[PermissionGroup]([Id], [Name], [ParentId] , [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (2, 'Application', 1, 1, -1, GETDATE()),
    (3, 'Module', 1, 1, -1, GETDATE()),
    (4, 'Permission', 1, 1, -1, GETDATE()),
    (5, 'Permission Group', 1, 1, -1, GETDATE()),
    (6, 'Platform', 1, 1, -1, GETDATE()),
    (7, 'User', 1, 1, -1, GETDATE()),
    (8, 'User-Application', 1, 1, -1, GETDATE()),
    (9, 'User-Module', 1, 1, -1, GETDATE()),
    (10, 'User-Permission', 1, 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[PermissionGroup] OFF;
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.Permission
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[Permission] ON;
GO

INSERT INTO [SystemCore].[Permission]([Id], [Description], [GroupId], [IsApiPermission], [ApiDomain], [ApiController], [ApiAction], [IsDatabasePermission], [DatabaseSchema], [DatabaseProcedure], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'Delete Application', 2, 1, 'SystemCore', 'Application', 'Delete', 1, 'SystemCore', 'DeleteApplication', 1, -1, GETDATE()),
    (2, 'Save Application', 2, 1, 'SystemCore', 'Application', 'Save', 1, 'SystemCore', 'SaveApplication', 1, -1, GETDATE()),
    (3, 'Delete Module', 3, 1, 'SystemCore', 'Module', 'Delete', 1, 'SystemCore', 'DeleteModule', 1, -1, GETDATE()),
    (4, 'Save Module', 3, 1, 'SystemCore', 'Module', 'Save', 1, 'SystemCore', 'SaveModule', 1, -1, GETDATE()),
    (5, 'Delete Permission', 4, 1, 'SystemCore', 'Permission', 'Delete', 1, 'SystemCore', 'DeletePermission', 1, -1, GETDATE()),
    (6, 'Save Permission', 4, 1, 'SystemCore', 'Permission', 'Save', 1, 'SystemCore', 'SavePermission', 1, -1, GETDATE()),
    (7, 'Delete Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Delete', 1, 'SystemCore', 'DeletePermissionGroup', 1, -1, GETDATE()),
    (8, 'Save Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Save', 1, 'SystemCore', 'SavePermissionGroup', 1, -1, GETDATE()),
    (9, 'Delete Platform', 6, 1, 'SystemCore', 'Platform', 'Delete', 1, 'SystemCore', 'DeletePlatform', 1, -1, GETDATE()),
    (10, 'Save Platform', 6, 1, 'SystemCore', 'Platform', 'Save', 1, 'SystemCore', 'SavePlatform', 1, -1, GETDATE()),
    (11, 'Delete User', 7, 1, 'SystemCore', 'User', 'Delete', 1, 'SystemCore', 'DeleteUser', 1, -1, GETDATE()),
    (12, 'Save User', 7, 1, 'SystemCore', 'User', 'Save', 1, 'SystemCore', 'SaveUser', 1, -1, GETDATE()),
    (13, 'Delete User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Delete', 1, 'SystemCore', 'DeleteUserApplication', 1, -1, GETDATE()),
    (14, 'Save User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Save', 1, 'SystemCore', 'SaveUserApplication', 1, -1, GETDATE()),
    (15, 'Delete User-Module', 9, 1, 'SystemCore', 'UserModule', 'Delete', 1, 'SystemCore', 'DeleteUserModule', 1, -1, GETDATE()),
    (16, 'Save User-Module', 9, 1, 'SystemCore', 'UserModule', 'Save', 1, 'SystemCore', 'SaveUserModule', 1, -1, GETDATE()),
    (17, 'Delete User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Delete', 1, 'SystemCore', 'DeleteUserPermission', 1, -1, GETDATE()),
    (18, 'Save User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Save', 1, 'SystemCore', 'SaveUserPermission', 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[Permission] OFF;
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.Platform
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[Platform] ON;
GO

INSERT INTO [SystemCore].[Platform]([Id], [Name], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'Windows', 1, -1, GETDATE()),
    (2, 'Web', 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[Platform] OFF;
GO

-- ----------------------------------------------------------------------------------------------------
-- USER-DEFINED TYPES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- USER-DEFINED TYPES: dbo.IntValue
-- -------------------------------------------------------------------------------------

IF TYPE_ID('dbo.IntValue') IS NOT NULL
BEGIN
    DROP TYPE [dbo].[IntValue];
END
GO

CREATE TYPE [dbo].[IntValue] AS TABLE
(
    [Value] INT
);
GO

-- ----------------------------------------------------------------------------------------------------
-- FUNCTIONS
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.BuildFullName
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.BuildFullName') IS NOT NULL
    DROP FUNCTION [dbo].[BuildFullName];
GO

CREATE FUNCTION [dbo].[BuildFullName](@FirstName NVARCHAR(100), @MiddleName NVARCHAR(100), @LastName NVARCHAR(100), @NameExtension NVARCHAR(10))
RETURNS NVARCHAR(320) AS
BEGIN
    DECLARE @Result AS NVARCHAR(320) = '';
    DECLARE @HasFirstName AS BIT;
    DECLARE @HasMiddleName AS BIT;
    DECLARE @HasLastName AS BIT;
    DECLARE @HasNameExtension AS BIT;

    SET @FirstName = [dbo].[Trim](@FirstName);
    SET @MiddleName = [dbo].[Trim](@MiddleName);
    SET @LastName = [dbo].[Trim](@LastName);
    SET @NameExtension = [dbo].[Trim](@NameExtension);

    SET @HasFirstName = CASE WHEN @FirstName IS NOT NULL AND LEN(@FirstName) > 0 THEN 1 ELSE 0 END;
    SET @HasMiddleName = CASE WHEN @MiddleName IS NOT NULL AND LEN(@MiddleName) > 0 THEN 1 ELSE 0 END;
    SET @HasLastName = CASE WHEN @LastName IS NOT NULL AND LEN(@LastName) > 0 THEN 1 ELSE 0 END;
    SET @HasNameExtension = CASE WHEN @NameExtension IS NOT NULL AND LEN(@NameExtension) > 0 THEN 1 ELSE 0 END;

    IF @HasLastName = 1
    BEGIN
        SET @Result = @LastName;

        IF @HasFirstName = 1 OR @HasNameExtension = 1 OR @HasMiddleName = 1
            SET @Result = CONCAT(@Result, ', ');
    END

    IF @HasFirstName = 1
    BEGIN
        SET @Result = CONCAT(@Result, @FirstName);

        IF @HasNameExtension = 1 OR @HasMiddleName = 1
            SET @Result = CONCAT(@Result, ' ');
    END

    IF @HasNameExtension = 1
    BEGIN
        SET @Result = CONCAT(@Result, @NameExtension);

        IF @HasMiddleName = 1
            SET @Result = CONCAT(@Result, ' ');
    END

    IF @HasMiddleName = 1
    BEGIN
        SET @Result = CONCAT(@Result, @MiddleName);
    END

    RETURN @Result;
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.Equal
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.Equal') IS NOT NULL
    DROP FUNCTION [dbo].[Equal];
GO

CREATE FUNCTION [dbo].[Equal](@Old SQL_VARIANT, @New SQL_VARIANT)
RETURNS BIT AS
BEGIN
    IF @Old IS NULL AND @New IS NULL
        RETURN 1;

    IF (@Old IS NULL AND @New IS NOT NULL) OR (@Old IS NOT NULL AND @New IS NULL)
        RETURN 0;

    RETURN CASE WHEN @Old = @New THEN 1 ELSE 0 END;
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.GetSessionVariable
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.GetSessionVariable') IS NOT NULL
    DROP FUNCTION [dbo].[GetSessionVariable];
GO

CREATE FUNCTION [dbo].[GetSessionVariable](@Key NVARCHAR(64))
RETURNS SQL_VARIANT AS
BEGIN
    RETURN SESSION_CONTEXT(@Key);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.HasChanges
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.HasChanges') IS NOT NULL
    DROP FUNCTION [dbo].[HasChanges];
GO

CREATE FUNCTION [dbo].[HasChanges](@Old SQL_VARIANT, @New SQL_VARIANT)
RETURNS BIT AS
BEGIN
    IF @Old IS NULL AND @New IS NULL
        RETURN 0;

    IF (@Old IS NULL AND @New IS NOT NULL) OR (@Old IS NOT NULL AND @New IS NULL)
        RETURN 1;

    RETURN CASE WHEN @Old <> @New THEN 1 ELSE 0 END;
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.IsDeleteCascaded
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.IsDeleteCascaded') IS NOT NULL
    DROP FUNCTION [dbo].[IsDeleteCascaded];
GO

CREATE FUNCTION [dbo].[IsDeleteCascaded]()
RETURNS BIT AS
BEGIN
    RETURN [dbo].[NonNullableBit](CAST([dbo].[GetSessionVariable]('IsDeleteCascaded') AS BIT));
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.NonNullableBit
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.NonNullableBit') IS NOT NULL
    DROP FUNCTION [dbo].[NonNullableBit];
GO

CREATE FUNCTION [dbo].[NonNullableBit](@Value AS BIT)
RETURNS BIT AS
BEGIN
    RETURN ISNULL(@Value, 0);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.Trim
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.Trim') IS NOT NULL
    DROP FUNCTION [dbo].[Trim];
GO

CREATE FUNCTION [dbo].[Trim](@Value AS NVARCHAR(MAX)) 
RETURNS NVARCHAR(MAX) AS 
BEGIN
    IF @Value IS NOT NULL
        SET @Value = LTRIM(RTRIM(@Value));

    RETURN @Value;
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.BuildSessionPermissionKey
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.BuildSessionPermissionKey') IS NOT NULL
    DROP FUNCTION [SystemCore].[BuildSessionPermissionKey];
GO

CREATE FUNCTION [SystemCore].[BuildSessionPermissionKey](@PermissionId INT)
RETURNS NVARCHAR(64) AS
BEGIN
    IF @PermissionId IS NULL OR @PermissionId <= 0
        RETURN NULL;

    RETURN CONCAT('SystemCore.SessionPermission:', @PermissionId);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.GetPermissionId
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.GetPermissionId') IS NOT NULL
    DROP FUNCTION [SystemCore].[GetPermissionId];
GO

CREATE FUNCTION [SystemCore].[GetPermissionId](@DatabaseSchema NVARCHAR(250), @DatabaseProcedure NVARCHAR(250))
RETURNS INT AS
BEGIN
    DECLARE @Result AS INT;

    SELECT @Result = [Id]
    FROM [SystemCore].[Permission]
    WHERE
        [IsDeleted] = 0 AND
        [DatabaseSchema] = @DatabaseSchema AND
        [DatabaseProcedure] = @DatabaseProcedure;

    RETURN @Result;
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.GetSessionApplicationId
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.GetSessionApplicationId') IS NOT NULL
    DROP FUNCTION [SystemCore].[GetSessionApplicationId];
GO

CREATE FUNCTION [SystemCore].[GetSessionApplicationId]()
RETURNS INT AS
BEGIN
    RETURN CAST([dbo].[GetSessionVariable]('SystemCore.Session.ApplicationId') AS INT);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.GetSessionId
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.GetSessionId') IS NOT NULL
    DROP FUNCTION [SystemCore].[GetSessionId];
GO

CREATE FUNCTION [SystemCore].[GetSessionId]()
RETURNS BIGINT AS
BEGIN
    RETURN CAST([dbo].[GetSessionVariable]('SystemCore.Session.Id') AS BIGINT);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.GetSessionUserId
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.GetSessionUserId') IS NOT NULL
    DROP FUNCTION [SystemCore].[GetSessionUserId];
GO

CREATE FUNCTION [SystemCore].[GetSessionUserId]()
RETURNS INT AS
BEGIN
    RETURN CAST([dbo].[GetSessionVariable]('SystemCore.Session.UserId') AS INT);
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: SystemCore.IsPermissionGranted
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.IsPermissionGranted') IS NOT NULL
    DROP FUNCTION [SystemCore].[IsPermissionGranted];
GO

CREATE FUNCTION [SystemCore].[IsPermissionGranted](@DatabaseSchema NVARCHAR(250), @DatabaseProcedure NVARCHAR(250))
RETURNS BIT AS
BEGIN
    RETURN CASE WHEN EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Permission]
            INNER JOIN [SystemCore].[UserPermission] ON [Permission].[Id] = [UserPermission].[PermissionId]
            INNER JOIN [SystemCore].[User] ON [UserPermission].[UserId] = [User].[Id]
            INNER JOIN [SystemCore].[Session] ON [User].[Id] = [Session].[UserId]
            WHERE
                [Permission].[DatabaseSchema] = @DatabaseSchema
                AND [Permission].[DatabaseProcedure] = @DatabaseProcedure
                AND [Permission].[IsDeleted] = 0
                AND [UserPermission].[IsDeleted] = 0
                AND [UserPermission].[IsApproved] = 1
                AND [UserPermission].[IsExpired] = 0
                AND [User].[IsDeleted] = 0
                AND [User].[IsActive] = 1
                AND [Session].[SessionEnd] IS NULL
        ) THEN 1 ELSE 0 END;
END
GO

-- ----------------------------------------------------------------------------------------------------
-- STORED PROCEDURES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: dbo.EnableDeleteCascade
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'EnableDeleteCascade')
    DROP PROCEDURE [dbo].[EnableDeleteCascade];
GO

CREATE PROCEDURE [dbo].[EnableDeleteCascade](@IsEnabled BIT) AS
BEGIN
    SET @IsEnabled = [dbo].[NonNullableBit](@IsEnabled);
    EXEC [dbo].[SetSessionVariable] 'IsDeleteCascaded', @IsEnabled;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: dbo.SetSessionVariable
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'SetSessionVariable')
    DROP PROCEDURE [dbo].[SetSessionVariable];
GO

CREATE PROCEDURE [dbo].[SetSessionVariable](@Key NVARCHAR(64), @Value SQL_VARIANT, @IsReadOnly BIT = 0) AS
BEGIN
    EXEC SYS.SP_SET_SESSION_CONTEXT @Key, @Value, @IsReadOnly;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteApplication')
    DROP PROCEDURE [SystemCore].[DeleteApplication];
GO

CREATE PROCEDURE [SystemCore].[DeleteApplication]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Application_IsSystemDefined AS BIT;
    DECLARE @Application_IsDeleted AS BIT;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @Application_IsSystemDefined = [IsSystemDefined],
        @Application_IsDeleted = [IsDeleted]
    FROM [SystemCore].[Application]
    WHERE [Id] = @Id;

    IF @Application_IsSystemDefined IS NULL OR @Application_IsDeleted IS NULL OR @Application_IsDeleted = 1
    BEGIN
        RAISERROR('Application does not exists', 18, -1);
        RETURN;
    END

    IF @Application_IsSystemDefined = 1
    BEGIN
        RAISERROR('Cannot delete system-defined application', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteApplication') = 0
    BEGIN
        RAISERROR('Denied to delete application', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[Application] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteModule')
    DROP PROCEDURE [SystemCore].[DeleteModule];
GO

CREATE PROCEDURE [SystemCore].[DeleteModule]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Module_IsSystemDefined AS BIT;
    DECLARE @Module_IsDeleted AS BIT;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @Module_IsSystemDefined = [IsSystemDefined],
        @Module_IsDeleted = [IsDeleted]
    FROM [SystemCore].[Module]
    WHERE [Id] = @Id;

    IF @Module_IsSystemDefined IS NULL OR @Module_IsDeleted IS NULL OR @Module_IsDeleted = 1
    BEGIN
        RAISERROR('Module does not exists', 18, -1);
        RETURN;
    END

    IF @Module_IsSystemDefined = 1
    BEGIN
        RAISERROR('Cannot delete system-defined module', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteModule') = 0
    BEGIN
        RAISERROR('Denied to delete module', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[Module] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeletePermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeletePermission')
    DROP PROCEDURE [SystemCore].[DeletePermission];
GO

CREATE PROCEDURE [SystemCore].[DeletePermission]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Permission_IsSystemDefined AS BIT;
    DECLARE @Permission_IsDeleted AS BIT;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @Permission_IsSystemDefined = [IsSystemDefined],
        @Permission_IsDeleted = [IsDeleted]
    FROM [SystemCore].[Permission]
    WHERE [Id] = @Id;

    IF @Permission_IsSystemDefined IS NULL OR @Permission_IsDeleted IS NULL OR @Permission_IsDeleted = 1
    BEGIN
        RAISERROR('Permission does not exists', 18, -1);
        RETURN;
    END

    IF @Permission_IsSystemDefined = 1
    BEGIN
        RAISERROR('Cannot delete system-defined permission', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeletePermission') = 0
    BEGIN
        RAISERROR('Denied to delete permission', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[Permission] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeletePermissionGroup
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeletePermissionGroup')
    DROP PROCEDURE [SystemCore].[DeletePermissionGroup];
GO

CREATE PROCEDURE [SystemCore].[DeletePermissionGroup]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @PermissionGroup_IsSystemDefined AS BIT;
    DECLARE @PermissionGroup_IsDeleted AS BIT;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @PermissionGroup_IsSystemDefined = [IsSystemDefined],
        @PermissionGroup_IsDeleted = [IsDeleted]
    FROM [SystemCore].[PermissionGroup]
    WHERE [Id] = @Id;

    IF @PermissionGroup_IsSystemDefined IS NULL OR @PermissionGroup_IsDeleted IS NULL OR @PermissionGroup_IsDeleted = 1
    BEGIN
        RAISERROR('Permission group does not exists', 18, -1);
        RETURN;
    END

    IF @PermissionGroup_IsSystemDefined = 1
    BEGIN
        RAISERROR('Cannot delete system-defined permission group', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeletePermissionGroup') = 0
    BEGIN
        RAISERROR('Denied to delete permission group', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[PermissionGroup] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeletePlatform
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeletePlatform')
    DROP PROCEDURE [SystemCore].[DeletePlatform];
GO

CREATE PROCEDURE [SystemCore].[DeletePlatform]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Platform_IsSystemDefined AS BIT;
    DECLARE @Platform_IsDeleted AS BIT;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @Platform_IsSystemDefined = [IsSystemDefined],
        @Platform_IsDeleted = [IsDeleted]
    FROM [SystemCore].[Platform]
    WHERE [Id] = @Id;

    IF @Platform_IsSystemDefined IS NULL OR @Platform_IsDeleted IS NULL OR @Platform_IsDeleted = 1
    BEGIN
        RAISERROR('Platform does not exists', 18, -1);
        RETURN;
    END

    IF @Platform_IsSystemDefined = 1
    BEGIN
        RAISERROR('Cannot delete system-defined platform', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeletePlatform') = 0
    BEGIN
        RAISERROR('Denied to delete platform', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[Platform] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteUser
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteUser')
    DROP PROCEDURE [SystemCore].[DeleteUser];
GO

CREATE PROCEDURE [SystemCore].[DeleteUser]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @User_IsSystemDefined AS BIT;
    DECLARE @User_IsDeleted AS BIT;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @User_IsSystemDefined = [IsSystemDefined],
        @User_IsDeleted = [IsDeleted]
    FROM [SystemCore].[User]
    WHERE [Id] = @Id;

    IF @User_IsSystemDefined IS NULL OR @User_IsDeleted IS NULL OR @User_IsDeleted = 1
    BEGIN
        RAISERROR('User does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteUser') = 0
    BEGIN
        RAISERROR('Denied to delete user', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[User] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteUserApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteUserApplication')
    DROP PROCEDURE [SystemCore].[DeleteUserApplication];
GO

CREATE PROCEDURE [SystemCore].[DeleteUserApplication]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @UserApplication_IsSystemDefined AS BIT;
    DECLARE @UserApplication_IsDeleted AS BIT;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @UserApplication_IsSystemDefined = [IsSystemDefined],
        @UserApplication_IsDeleted = [IsDeleted]
    FROM [SystemCore].[UserApplication]
    WHERE [Id] = @Id;

    IF @UserApplication_IsSystemDefined IS NULL OR @UserApplication_IsDeleted IS NULL OR @UserApplication_IsDeleted = 1
    BEGIN
        RAISERROR('User-application does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteUserApplication') = 0
    BEGIN
        RAISERROR('Denied to delete user-application', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[UserApplication] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteUserModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteUserModule')
    DROP PROCEDURE [SystemCore].[DeleteUserModule];
GO

CREATE PROCEDURE [SystemCore].[DeleteUserModule]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @UserModule_IsSystemDefined AS BIT;
    DECLARE @UserModule_IsDeleted AS BIT;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @UserModule_IsSystemDefined = [IsSystemDefined],
        @UserModule_IsDeleted = [IsDeleted]
    FROM [SystemCore].[UserModule]
    WHERE [Id] = @Id;

    IF @UserModule_IsSystemDefined IS NULL OR @UserModule_IsDeleted IS NULL OR @UserModule_IsDeleted = 1
    BEGIN
        RAISERROR('User-module does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteUserModule') = 0
    BEGIN
        RAISERROR('Denied to delete user-module', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[UserModule] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.DeleteUserPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'DeleteUserPermission')
    DROP PROCEDURE [SystemCore].[DeleteUserPermission];
GO

CREATE PROCEDURE [SystemCore].[DeleteUserPermission]
(
    @Id INT,
    @IsCascaded BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @UserPermission_IsSystemDefined AS BIT;
    DECLARE @UserPermission_IsDeleted AS BIT;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    SELECT
        @UserPermission_IsSystemDefined = [IsSystemDefined],
        @UserPermission_IsDeleted = [IsDeleted]
    FROM [SystemCore].[UserPermission]
    WHERE [Id] = @Id;

    IF @UserPermission_IsSystemDefined IS NULL OR @UserPermission_IsDeleted IS NULL OR @UserPermission_IsDeleted = 1
    BEGIN
        RAISERROR('User-permission does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'DeleteUserPermission') = 0
    BEGIN
        RAISERROR('Denied to delete user-permission', 18, -1);
        RETURN;
    END

    UPDATE [SystemCore].[UserPermission] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetApplication')
    DROP PROCEDURE [SystemCore].[GetApplication];
GO

CREATE PROCEDURE [SystemCore].[GetApplication](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [Name],
        [PlatformId]
    FROM [SystemCore].[Application]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetModule')
    DROP PROCEDURE [SystemCore].[GetModule];
GO

CREATE PROCEDURE [SystemCore].[GetModule](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [Name],
        [OrdinalNumber],
        [ApplicationId]
    FROM [SystemCore].[Module]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetPermission')
    DROP PROCEDURE [SystemCore].[GetPermission];
GO

CREATE PROCEDURE [SystemCore].[GetPermission](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [Description],
        [IsApiPermission],
        [ApiDomain],
        [ApiController],
        [ApiAction],
        [IsDatabasePermission],
        [DatabaseSchema],
        [DatabaseProcedure],
        [GroupId]
    FROM [SystemCore].[Permission]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetPermissionGroup
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetPermissionGroup')
    DROP PROCEDURE [SystemCore].[GetPermissionGroup];
GO

CREATE PROCEDURE [SystemCore].[GetPermissionGroup](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [Name],
        [ParentId]
    FROM [SystemCore].[PermissionGroup]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetPlatform
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetPlatform')
    DROP PROCEDURE [SystemCore].[GetPlatform];
GO

CREATE PROCEDURE [SystemCore].[GetPlatform](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [Name]
    FROM [SystemCore].[Platform]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetUser
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetUser')
    DROP PROCEDURE [SystemCore].[GetUser];
GO

CREATE PROCEDURE [SystemCore].[GetUser](@Id INT) AS
BEGIN
    SELECT
        [Id],
        [FirstName],
        [MiddleName],
        [LastName],
        [NameExtension],
        [FullName],
        [Username],
        [IsActive],
        [IsPasswordChangeRequired]
    FROM [SystemCore].[User]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetUserApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetUserApplication')
    DROP PROCEDURE [SystemCore].[GetUserApplication];
GO

CREATE PROCEDURE [SystemCore].[GetUserApplication](@Id BIGINT) AS
BEGIN
    SELECT
        [Id],
        [IsApproved],
        [Expiration],
        [IsExpired],
        [UserId],
        [ApplicationId]
    FROM [SystemCore].[UserApplication]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetUserModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetUserModule')
    DROP PROCEDURE [SystemCore].[GetUserModule];
GO

CREATE PROCEDURE [SystemCore].[GetUserModule](@Id BIGINT) AS
BEGIN
    SELECT
        [Id],
        [IsApproved],
        [Expiration],
        [IsExpired],
        [UserId],
        [ModuleId]
    FROM [SystemCore].[UserModule]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetUserPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetUserPermission')
    DROP PROCEDURE [SystemCore].[GetUserPermission];
GO

CREATE PROCEDURE [SystemCore].[GetUserPermission](@Id BIGINT) AS
BEGIN
    SELECT
        [Id],
        [IsApproved],
        [Expiration],
        [IsExpired],
        [UserId],
        [PermissionId]
    FROM [SystemCore].[UserPermission]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveApplication')
    DROP PROCEDURE [SystemCore].[SaveApplication];
GO

CREATE PROCEDURE [SystemCore].[SaveApplication]
(
    @Id INT OUT,
    @Name NVARCHAR(250),
    @PlatformId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Application_IsSystemDefined AS BIT;
    DECLARE @Application_IsDeleted AS BIT;

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveApplication') = 0
    BEGIN
        RAISERROR('Denied to save application', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @Application_IsSystemDefined = [IsSystemDefined],
            @Application_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Application]
        WHERE [Id] = @Id;

        IF @Application_IsSystemDefined IS NULL OR @Application_IsDeleted IS NULL OR @Application_IsDeleted = 1
        BEGIN
            RAISERROR('Application does not exists', 18, -1);
            RETURN;
        END

        IF @Application_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined application', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Application] SET
            [Name] = @Name,
            [PlatformId] = @PlatformId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([Name], @Name) = 1 OR
                [dbo].[HasChanges]([PlatformId], @PlatformId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Application]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([Name], @Name) = 1 AND
                [dbo].[Equal]([PlatformId], @PlatformId) = 1
        )
        BEGIN
            RAISERROR('Application already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[Application]
        (
            [Name],
            [PlatformId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @Name,
            @PlatformId,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveModule')
    DROP PROCEDURE [SystemCore].[SaveModule];
GO

CREATE PROCEDURE [SystemCore].[SaveModule]
(
    @Id INT OUT,
    @Name NVARCHAR(250),
    @OrdinalNumber INT,
    @ApplicationId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Module_IsSystemDefined AS BIT;
    DECLARE @Module_IsDeleted AS BIT;

    SET NOCOUNT ON
    
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveModule') = 0
    BEGIN
        RAISERROR('Denied to save module', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @Module_IsSystemDefined = [IsSystemDefined],
            @Module_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Module]
        WHERE [Id] = @Id;

        IF @Module_IsSystemDefined IS NULL OR @Module_IsDeleted IS NULL OR @Module_IsDeleted = 1
        BEGIN
            RAISERROR('Module does not exists', 18, -1);
            RETURN;
        END

        IF @Module_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined module', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Module] SET
            [Name] = @Name,
            [OrdinalNumber] = @OrdinalNumber,
            [ApplicationId] = @ApplicationId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([Name], @Name) = 1 OR
                [dbo].[HasChanges]([OrdinalNumber], @OrdinalNumber) = 1 OR
                [dbo].[HasChanges]([ApplicationId], @ApplicationId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Module]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([Name], @Name) = 1 AND
                [dbo].[Equal]([OrdinalNumber], @OrdinalNumber) = 1 AND
                [dbo].[Equal]([ApplicationId], @ApplicationId) = 1
        )
        BEGIN
            RAISERROR('Module already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[Module]
        (
            [Name],
            [OrdinalNumber],
            [ApplicationId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @Name,
            @OrdinalNumber,
            @ApplicationId,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SavePermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SavePermission')
    DROP PROCEDURE [SystemCore].[SavePermission];
GO

CREATE PROCEDURE [SystemCore].[SavePermission]
(
    @Id INT OUT,
    @Description NVARCHAR(250),
    @IsApiPermission BIT,
    @ApiDomain NVARCHAR(250),
    @ApiController NVARCHAR(250),
    @ApiAction NVARCHAR(250),
    @IsDatabasePermission BIT,
    @DatabaseSchema NVARCHAR(250),
    @DatabaseProcedure NVARCHAR(250),
    @GroupId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Permission_IsSystemDefined AS BIT;
    DECLARE @Permission_IsDeleted AS BIT;

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePermission') = 0
    BEGIN
        RAISERROR('Denied to save permission', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @Permission_IsSystemDefined = [IsSystemDefined],
            @Permission_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Permission]
        WHERE [Id] = @Id;

        IF @Permission_IsSystemDefined IS NULL OR @Permission_IsDeleted IS NULL OR @Permission_IsDeleted = 1
        BEGIN
            RAISERROR('Permission does not exists', 18, -1);
            RETURN;
        END

        IF @Permission_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined permission', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Permission] SET
            [Description] = @Description,
            [IsApiPermission] = @IsApiPermission,
            [ApiDomain] = @ApiDomain,
            [ApiController] = @ApiController,
            [ApiAction] = @ApiAction,
            [IsDatabasePermission] = @IsDatabasePermission,
            [DatabaseSchema] = @DatabaseSchema,
            [DatabaseProcedure] = @DatabaseProcedure,
            [GroupId] = @GroupId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([Description], @Description) = 1 OR
                [dbo].[HasChanges]([IsApiPermission], @IsApiPermission) = 1 OR
                [dbo].[HasChanges]([ApiDomain], @ApiDomain) = 1 OR
                [dbo].[HasChanges]([ApiController], @ApiController) = 1 OR
                [dbo].[HasChanges]([ApiAction], @ApiAction) = 1 OR
                [dbo].[HasChanges]([IsDatabasePermission], @IsDatabasePermission) = 1 OR
                [dbo].[HasChanges]([DatabaseSchema], @DatabaseSchema) = 1 OR
                [dbo].[HasChanges]([DatabaseProcedure], @DatabaseProcedure) = 1 OR
                [dbo].[HasChanges]([GroupId], @GroupId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Permission]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([Description], @Description) = 1 AND
                [dbo].[Equal]([IsApiPermission], @IsApiPermission) = 1 AND
                [dbo].[Equal]([ApiDomain], @ApiDomain) = 1 AND
                [dbo].[Equal]([ApiController], @ApiController) = 1 AND
                [dbo].[Equal]([ApiAction], @ApiAction) = 1 AND
                [dbo].[Equal]([IsDatabasePermission], @IsDatabasePermission) = 1 AND
                [dbo].[Equal]([DatabaseSchema], @DatabaseSchema) = 1 AND
                [dbo].[Equal]([DatabaseProcedure], @DatabaseProcedure) = 1 AND
                [dbo].[Equal]([GroupId], @GroupId) = 1
        )
        BEGIN
            RAISERROR('Permission already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[Permission]
        (
            [Description],
            [IsApiPermission],
            [ApiDomain],
            [ApiController],
            [ApiAction],
            [IsDatabasePermission],
            [DatabaseSchema],
            [DatabaseProcedure],
            [GroupId],
            [InsertedById],
            [InsertedOn] 
        )
        VALUES
        (
            @Description,
            @IsApiPermission,
            @ApiDomain,
            @ApiController,
            @ApiAction,
            @IsDatabasePermission,
            @DatabaseSchema,
            @DatabaseProcedure,
            @GroupId,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SavePermissionGroup
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SavePermissionGroup')
    DROP PROCEDURE [SystemCore].[SavePermissionGroup];
GO

CREATE PROCEDURE [SystemCore].[SavePermissionGroup]
(
    @Id INT OUT,
    @Name NVARCHAR(100),
    @ParentId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @PermissionGroup_IsSystemDefined AS BIT;
    DECLARE @PermissionGroup_IsDeleted AS BIT;

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePermissionGroup') = 0
    BEGIN
        RAISERROR('Denied to save permission group', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @PermissionGroup_IsSystemDefined = [IsSystemDefined],
            @PermissionGroup_IsDeleted = [IsDeleted]
        FROM [SystemCore].[PermissionGroup]
        WHERE [Id] = @Id;

        IF @PermissionGroup_IsSystemDefined IS NULL OR @PermissionGroup_IsDeleted IS NULL OR @PermissionGroup_IsDeleted = 1
        BEGIN
            RAISERROR('Permission group does not exists', 18, -1);
            RETURN;
        END

        IF @PermissionGroup_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined permission group', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[PermissionGroup] SET
            [Name] = @Name,
            [ParentId] = @ParentId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([Name], @Name) = 1 OR
                [dbo].[HasChanges]([ParentId], @ParentId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[PermissionGroup]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([Name], @Name) = 1 AND
                [dbo].[Equal]([ParentId], @ParentId) = 1
        )
        BEGIN
            RAISERROR('Permission group already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[PermissionGroup]
        (
            [Name],
            [ParentId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @Name,
            @ParentId,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SavePlatform
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SavePlatform')
    DROP PROCEDURE [SystemCore].[SavePlatform];
GO

CREATE PROCEDURE [SystemCore].[SavePlatform]
(
    @Id INT OUT,
    @Name NVARCHAR(100),
    @SessionId BIGINT
) As
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Platform_IsSystemDefined AS BIT;
    DECLARE @Platform_IsDeleted AS BIT;

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;
    
    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePlatform') = 0
    BEGIN
        RAISERROR('Denied to save platform', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @Platform_IsSystemDefined = [IsSystemDefined],
            @Platform_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Platform]
        WHERE [Id] = @Id;

        IF @Platform_IsSystemDefined IS NULL OR @Platform_IsDeleted IS NULL OR @Platform_IsDeleted = 1
        BEGIN
            RAISERROR('Platform does not exists', 18, -1);
            RETURN;
        END

        IF @Platform_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined platform', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Platform] SET
            [Name] = @Name,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            [dbo].[HasChanges]([Name], @Name) = 1;
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Platform]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([Name], @Name) = 1
        )
        BEGIN
            RAISERROR('Platform already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[Platform]
        (
            [Name],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @Name,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveUser
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveUser')
    DROP PROCEDURE [SystemCore].[SaveUser];
GO

CREATE PROCEDURE [SystemCore].[SaveUser]
(
    @Id INT OUT,
    @FirstName NVARCHAR(75),
    @MiddleName NVARCHAR(75),
    @LastName NVARCHAR(75),
    @NameExtension NVARCHAR(10),
    @Username NVARCHAR(250),
    @PasswordHash NVARCHAR(250),
    @IsActive BIT,
    @IsPasswordChangeRequired BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @User_IsSystemDefined AS BIT;
    DECLARE @User_IsDeleted AS BIT;
    
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUser') = 0 AND [dbo].[Equal](@SessionUserId, @Id) = 0
    BEGIN
        RAISERROR('Denied to save user', 18, -1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT -1
        FROM [SystemCore].[User]
        WHERE
            [dbo].[Equal]([Username], @Username) = 1 AND
            [IsDeleted] = 0 AND
            CASE WHEN (@Id IS NOT NULL OR @Id > 0) AND [Id] <> @Id THEN 1 ELSE 0 END = 1
    )
    BEGIN
        RAISERROR('Username already exists', 18, -1);
        RETURN;
    END

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @User_IsSystemDefined = [IsSystemDefined],
            @User_IsDeleted = [IsDeleted]
        FROM [SystemCore].[User]
        WHERE [Id] = @Id;

        IF @User_IsSystemDefined IS NULL OR @User_IsDeleted IS NULL OR @User_IsDeleted = 1
        BEGIN
            RAISERROR('User does not exists', 18, -1);
            RETURN;
        END

        IF @User_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined user', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[User] SET
            [FirstName] = @FirstName,
            [MiddleName] = @MiddleName,
            [LastName] = @LastName,
            [NameExtension] = @NameExtension,
            [FullName] = [dbo].[BuildFullName](@FirstName, @MiddleName, @LastName, @NameExtension),
            [Username] = @Username,
            [IsActive] = @IsActive,
            [IsPasswordChangeRequired] = @IsPasswordChangeRequired,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([FirstName], @FirstName) = 1 OR
                [dbo].[HasChanges]([MiddleName], @MiddleName) = 1 OR
                [dbo].[HasChanges]([LastName], @LastName) = 1 OR
                [dbo].[HasChanges]([NameExtension], @NameExtension) = 1 OR
                [dbo].[HasChanges]([Username], @Username) = 1 OR
                [dbo].[HasChanges]([IsActive], @IsActive) = 1 OR
                [dbo].[HasChanges]([IsPasswordChangeRequired], @IsPasswordChangeRequired) = 1
            );
    END
    ELSE
    BEGIN
        IF LEN([dbo].[Trim](@PasswordHash)) <= 0
        BEGIN
            RAISERROR('Password is required', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[User]
        (
            [FirstName],
            [MiddleName],
            [LastName],
            [NameExtension],
            [FullName],
            [Username],
            [PasswordHash],
            [IsActive],
            [IsPasswordChangeRequired],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @FirstName,
            @MiddleName,
            @LastName,
            @NameExtension,
            [dbo].[BuildFullName](@FirstName, @MiddleName, @LastName, @NameExtension),
            @Username,
            @PasswordHash,
            @IsActive,
            @IsPasswordChangeRequired,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveUserApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveUserApplication')
    DROP PROCEDURE [SystemCore].[SaveUserApplication];
GO

CREATE PROCEDURE [SystemCore].[SaveUserApplication]
(
    @Id BIGINT OUT,
    @IsApproved BIT,
    @Expiration DATETIME,
    @IsExpired BIT,
    @UserId INT,
    @ApplicationId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;

    DECLARE @UserApplication_IsSystemDefined AS BIT;
    DECLARE @UserApplication_IsDeleted AS BIT;
    
    SET NOCOUNT ON;
    
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUserApplication') = 0
    BEGIN
        RAISERROR('Denied to save user-application', 18, -1);
        RETURN;
    END

    SET NOCOUNT OFF;

    IF @Id IS NULL OR @Id <= 0
    BEGIN
        SELECT
            @UserApplication_IsSystemDefined = [IsSystemDefined],
            @UserApplication_IsDeleted = [IsDeleted]
        FROM [SystemCore].[UserApplication]
        WHERE [Id] = @Id;

        IF @UserApplication_IsSystemDefined IS NULL OR @UserApplication_IsDeleted IS NULL OR @UserApplication_IsDeleted = 1
        BEGIN
            RAISERROR('User-application does not exists', 18, -1);
            RETURN;
        END

        IF @UserApplication_IsSystemDefined = 1
        BEGIN
            RAISERROR('Cannot update system-defined user-application', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[UserApplication] SET
            [IsApproved] = @IsApproved,
            [Expiration] = @Expiration,
            [IsExpired] = @IsExpired,
            [UserId] = @UserId,
            [ApplicationId] = @ApplicationId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = GETDATE()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([IsApproved], @IsApproved) = 1 OR
                [dbo].[HasChanges]([Expiration], @Expiration) = 1 OR
                [dbo].[HasChanges]([IsExpired], @IsExpired) = 1 OR
                [dbo].[HasChanges]([UserId], @UserId) = 1 OR
                [dbo].[HasChanges]([ApplicationId], @ApplicationId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[UserApplication]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([IsApproved], @IsApproved) = 1 AND
                [dbo].[Equal]([Expiration], @Expiration) = 1 AND
                [dbo].[Equal]([IsExpired], @IsExpired) = 1 AND
                [dbo].[Equal]([UserId], @UserId) = 1 AND
                [dbo].[Equal]([ApplicationId], @ApplicationId) = 1
        )
        BEGIN
            RAISERROR('User-application already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[UserApplication]
        (
            [IsApproved],
            [Expiration],
            [IsExpired],
            [UserId],
            [ApplicationId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @IsApproved,
            @Expiration,
            @IsExpired,
            @UserId,
            @ApplicationId,
            @SessionUserId,
            GETDATE()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SetSessionId
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SetSessionId')
    DROP PROCEDURE [SystemCore].[SetSessionId];
GO

CREATE PROCEDURE [SystemCore].[SetSessionId](@SessionId BIGINT, @UserId INT = NULL OUT, @ApplicationId INT = NULL OUT) AS
BEGIN
    SELECT
        @UserId = [UserId],
        @ApplicationId = [ApplicationId]
    FROM [SystemCore].[Session]
    WHERE [Id] = @SessionId;
    
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.Id', @SessionId, 1;
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.UserId', @UserId, 1;
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.ApplicationId', @ApplicationId, 1;
END
GO