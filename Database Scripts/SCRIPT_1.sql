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
    (2, 'Get Application', 2, 1, 'SystemCore', 'Application', 'Get', 1, 'SystemCore', 'GetApplication', 1, -1, GETDATE()),
    (3, 'Save Application', 2, 1, 'SystemCore', 'Application', 'Save', 1, 'SystemCore', 'SaveApplication', 1, -1, GETDATE()),
    (4, 'Search Application', 2, 1, 'SystemCore', 'Application', 'Search', 1, 'SystemCore', 'SearchApplication', 1, -1, GETDATE()),
    (5, 'Delete Module', 3, 1, 'SystemCore', 'Module', 'Delete', 1, 'SystemCore', 'DeleteModule', 1, -1, GETDATE()),
    (6, 'Get Module', 3, 1, 'SystemCore', 'Module', 'Get', 1, 'SystemCore', 'GetModule', 1, -1, GETDATE()),
    (7, 'Save Module', 3, 1, 'SystemCore', 'Module', 'Save', 1, 'SystemCore', 'SaveModule', 1, -1, GETDATE()),
    (8, 'Search Module', 3, 1, 'SystemCore', 'Module', 'Search', 1, 'SystemCore', 'SearchModule', 1, -1, GETDATE()),
    (9, 'Delete Permission', 4, 1, 'SystemCore', 'Permission', 'Delete', 1, 'SystemCore', 'DeletePermission', 1, -1, GETDATE()),
    (10, 'Get Permission', 4, 1, 'SystemCore', 'Permission', 'Get', 1, 'SystemCore', 'GetPermission', 1, -1, GETDATE()),
    (11, 'Save Permission', 4, 1, 'SystemCore', 'Permission', 'Save', 1, 'SystemCore', 'SavePermission', 1, -1, GETDATE()),
    (12, 'Search Permission', 4, 1, 'SystemCore', 'Permission', 'Search', 1, 'SystemCore', 'SearchPermission', 1, -1, GETDATE()),
    (13, 'Delete Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Delete', 1, 'SystemCore', 'DeletePermissionGroup', 1, -1, GETDATE()),
    (14, 'Get Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Get', 1, 'SystemCore', 'GetPermissionGroup', 1, -1, GETDATE()),
    (15, 'Save Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Save', 1, 'SystemCore', 'SavePermissionGroup', 1, -1, GETDATE()),
    (16, 'Search Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Search', 1, 'SystemCore', 'SearchPermissionGroup', 1, -1, GETDATE()),
    (17, 'Delete Platform', 6, 1, 'SystemCore', 'Platform', 'Delete', 1, 'SystemCore', 'DeletePlatform', 1, -1, GETDATE()),
    (18, 'Get Platform', 6, 1, 'SystemCore', 'Platform', 'Get', 1, 'SystemCore', 'GetPlatform', 1, -1, GETDATE()),
    (19, 'Save Platform', 6, 1, 'SystemCore', 'Platform', 'Save', 1, 'SystemCore', 'SavePlatform', 1, -1, GETDATE()),
    (20, 'Search Platform', 6, 1, 'SystemCore', 'Platform', 'Search', 1, 'SystemCore', 'SearchPlatform', 1, -1, GETDATE()),
    (21, 'Delete User', 7, 1, 'SystemCore', 'User', 'Delete', 1, 'SystemCore', 'DeleteUser', 1, -1, GETDATE()),
    (22, 'Get User', 7, 1, 'SystemCore', 'User', 'Get', 1, 'SystemCore', 'GetUser', 1, -1, GETDATE()),
    (23, 'Save User', 7, 1, 'SystemCore', 'User', 'Save', 1, 'SystemCore', 'SaveUser', 1, -1, GETDATE()),
    (24, 'Search User', 7, 1, 'SystemCore', 'User', 'Search', 1, 'SystemCore', 'SearchUser', 1, -1, GETDATE()),
    (25, 'Delete User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Delete', 1, 'SystemCore', 'DeleteUserApplication', 1, -1, GETDATE()),
    (26, 'Get User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Get', 1, 'SystemCore', 'GetUserApplication', 1, -1, GETDATE()),
    (27, 'Save User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Save', 1, 'SystemCore', 'SaveUserApplication', 1, -1, GETDATE()),
    (28, 'Search User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Search', 1, 'SystemCore', 'SearchUserApplication', 1, -1, GETDATE()),
    (29, 'Delete User-Module', 9, 1, 'SystemCore', 'UserModule', 'Delete', 1, 'SystemCore', 'DeleteUserModule', 1, -1, GETDATE()),
    (30, 'Get User-Module', 9, 1, 'SystemCore', 'UserModule', 'Get', 1, 'SystemCore', 'GetUserModule', 1, -1, GETDATE()),
    (31, 'Save User-Module', 9, 1, 'SystemCore', 'UserModule', 'Save', 1, 'SystemCore', 'SaveUserModule', 1, -1, GETDATE()),
    (32, 'Search User-Module', 9, 1, 'SystemCore', 'UserModule', 'Search', 1, 'SystemCore', 'SearchUserModule', 1, -1, GETDATE()),
    (33, 'Delete User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Delete', 1, 'SystemCore', 'DeleteUserPermission', 1, -1, GETDATE()),
    (34, 'Get User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Get', 1, 'SystemCore', 'GetUserPermission', 1, -1, GETDATE()),
    (35, 'Save User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Save', 1, 'SystemCore', 'SaveUserPermission', 1, -1, GETDATE()),
    (36, 'Search User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Search', 1, 'SystemCore', 'SearchUserPermission', 1, -1, GETDATE());
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
    (2, 'Mac', 1, -1, GETDATE()),
    (3, 'Linux', 1, -1, GETDATE()),
    (4, 'Android', 1, -1, GETDATE()),
    (5, 'iOS', 1, -1, GETDATE()),
    (6, 'Web', 1, -1, GETDATE());
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

    SELECT @Result = [Permission].[Id]
    FROM [SystemCore].[Permission]
    WHERE
        [Permission].[IsDeleted] = 0 AND
        [Permission].[DatabaseSchema] = @DatabaseSchema AND
        [Permission].[DatabaseProcedure] = @DatabaseProcedure;

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

CREATE FUNCTION [SystemCore].[IsPermissionGranted](@PermissionId INT)
RETURNS BIT AS
BEGIN
    IF @PermissionId IS NOT NULL AND @PermissionId > 0
        RETURN [dbo].[NonNullableBit](CAST([dbo].[GetSessionVariable]([SystemCore].[BuildSessionPermissionKey](@PermissionId)) AS BIT));
    RETURN 0;
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
    DECLARE @PERMISSIONID_DeleteApplication AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteApplication');
    
    DECLARE @Application_IsSystemDefined AS BIT;
    DECLARE @Application_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteApplication;

    SELECT
        @Application_IsSystemDefined = [Application].[IsSystemDefined],
        @Application_IsDeleted = [Application].[IsDeleted]
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

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteApplication) = 0
    BEGIN
        RAISERROR('Denied to delete application', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeleteModule AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteModule');

    DECLARE @Module_IsSystemDefined AS BIT;
    DECLARE @Module_IsDeleted AS BIT;

    SET NOCOUNT ON;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteModule;

    SELECT
        @Module_IsSystemDefined = [Module].[IsSystemDefined],
        @Module_IsDeleted = [Module].[IsDeleted]
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

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteModule) = 0
    BEGIN
        RAISERROR('Denied to delete module', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeletePermission AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeletePermission');

    DECLARE @Permission_IsSystemDefined AS BIT;
    DECLARE @Permission_IsDeleted AS BIT;

    SET NOCOUNT ON;

    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionUserId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeletePermission;

    SELECT
        @Permission_IsSystemDefined = [Permission].[IsSystemDefined],
        @Permission_IsDeleted = [Permission].[IsDeleted]
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

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeletePermission) = 0
    BEGIN
        RAISERROR('Denied to delete permission', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeletePermissionGroup AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeletePermissionGroup');
    
    DECLARE @PermissionGroup_IsSystemDefined AS BIT;
    DECLARE @PermissionGroup_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeletePermissionGroup;

    SELECT
        @PermissionGroup_IsSystemDefined = [PermissionGroup].[IsSystemDefined],
        @PermissionGroup_IsDeleted = [PermissionGroup].[IsDeleted]
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

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeletePermissionGroup) = 0
    BEGIN
        RAISERROR('Denied to delete permission group', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeletePlatform AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeletePlatform');
    
    DECLARE @Platform_IsSystemDefined AS BIT;
    DECLARE @Platform_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeletePlatform;

    SELECT
        @Platform_IsSystemDefined = [Platform].[IsSystemDefined],
        @Platform_IsDeleted = [Platform].[IsDeleted]
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

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeletePlatform) = 0
    BEGIN
        RAISERROR('Denied to delete platform', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeleteUser AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteUser');
    
    DECLARE @User_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteUser;

    SELECT @User_IsDeleted = [User].[IsDeleted]
    FROM [SystemCore].[User]
    WHERE [Id] = @Id;

    IF @User_IsDeleted IS NULL OR @User_IsDeleted = 1
    BEGIN
        RAISERROR('User does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteUser) = 0
    BEGIN
        RAISERROR('Denied to delete user', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeleteUserApplication AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteUserApplication');
    
    DECLARE @UserApplication_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteUserApplication;

    SELECT @UserApplication_IsDeleted = [UserApplication].[IsDeleted]
    FROM [SystemCore].[UserApplication]
    WHERE [Id] = @Id;

    IF @UserApplication_IsDeleted IS NULL OR @UserApplication_IsDeleted = 1
    BEGIN
        RAISERROR('User-application does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteUserApplication) = 0
    BEGIN
        RAISERROR('Denied to delete user-application', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeleteUserModule AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteUserModule');
    
    DECLARE @UserModule_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteUserModule;

    SELECT @UserModule_IsDeleted = [UserModule].[IsDeleted]
    FROM [SystemCore].[UserModule]
    WHERE [Id] = @Id;

    IF @UserModule_IsDeleted IS NULL OR @UserModule_IsDeleted = 1
    BEGIN
        RAISERROR('User-module does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteUserModule) = 0
    BEGIN
        RAISERROR('Denied to delete user-module', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

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
    DECLARE @PERMISSIONID_DeleteUserPermission AS INT = [SystemCore].[GetPermissionId]('SystemCore', 'DeleteUserPermission');
    
    DECLARE @UserPermission_IsDeleted AS BIT;

    SET NOCOUNT ON;
    
    EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
    EXEC [SystemCore].[SetSessionId] @SessionId;
    EXEC [SystemCore].[TryGrantPermission] @PERMISSIONID_DeleteUserPermission;

    SELECT @UserPermission_IsDeleted = [UserPermission].[IsDeleted]
    FROM [SystemCore].[UserPermission]
    WHERE [Id] = @Id;

    IF @UserPermission_IsDeleted IS NULL OR @UserPermission_IsDeleted = 1
    BEGIN
        RAISERROR('User-permission does not exists', 18, -1);
        RETURN;
    END

    IF [SystemCore].[IsPermissionGranted](@PERMISSIONID_DeleteUserPermission) = 0
    BEGIN
        RAISERROR('Denied to delete user-permission', 18, -1);
        RETURN;
    END

    SET @SessionUserId = [SystemCore].[GetSessionUserId]();

    SET NOCOUNT OFF;

    UPDATE [SystemCore].[UserPermission] SET
        [IsDeleted] = 1,
        [DeletedById] = @SessionUserId,
        [DeletedOn] = GETDATE()
    WHERE [Id] = @Id;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SetSessionId
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SetSessionId')
    DROP PROCEDURE [SystemCore].[SetSessionId];
GO

CREATE PROCEDURE [SystemCore].[SetSessionId](@SessionId BIGINT) AS
BEGIN
    DECLARE @UserId AS INT;
    DECLARE @ApplicationId AS INT;

    SELECT
        @UserId = [Session].[UserId],
        @ApplicationId = [Session].[ApplicationId]
    FROM [SystemCore].[Session]
    WHERE [Session].[Id] = @SessionId;
    
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.Id', @SessionId, 1;
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.UserId', @UserId, 1;
    EXEC [dbo].[SetSessionVariable] 'SystemCore.Session.ApplicationId', @ApplicationId, 1;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.TryGrantPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'TryGrantPermission')
    DROP PROCEDURE [SystemCore].[TryGrantPermission];
GO

CREATE PROCEDURE [SystemCore].[TryGrantPermission]
(
    @PermissionId INT,
    @SessionId BIGINT = NULL,
    @Granted BIT = NULL
) AS
BEGIN
    DECLARE @SessionVariableKey AS NVARCHAR(64) = [SystemCore].[BuildSessionPermissionKey](@PermissionId);

    IF @PermissionId IS NULL OR @PermissionId <= 0 OR NOT EXISTS(SELECT -1 FROM [SystemCore].[Permission] WHERE [IsDeleted] = 0 AND [Id] = @PermissionId)
    BEGIN
        RAISERROR('Invalid permission', 18, -1);
        RETURN;
    END

    IF @SessionId IS NULL OR @SessionId <= 0
        SET @SessionId = [SystemCore].[GetSessionId]();

    IF @Granted IS NULL
    BEGIN
        SET @Granted = CASE WHEN EXISTS
        (
            SELECT -1
            FROM [SystemCore].[Permission]
            INNER JOIN [SystemCore].[UserPermission] ON [Permission].[Id] = [UserPermission].[PermissionId]
            INNER JOIN [SystemCore].[User] ON [UserPermission].[UserId] = [User].[Id]
            INNER JOIN [SystemCore].[Session] ON [User].[Id] = [Session].[UserId]
            WHERE
                [Permission].[IsDeleted] = 0
                AND [UserPermission].[IsDeleted] = 0
                AND [UserPermission].[IsApproved] = 1
                AND [UserPermission].[IsExpired] = 0
                AND [User].[IsDeleted] = 0
                AND [User].[IsActive] = 1
                AND [Session].[SessionEnd] IS NULL
        ) THEN 1 ELSE 0 END;
    END

    IF @SessionId IS NULL
    BEGIN
        RAISERROR('Invalid session', 18, -1);
        RETURN;
    END

    IF @Granted IS NULL
    BEGIN
        RAISERROR('Failed to grant permission', 18, -1);
        RETURN;
    END

    EXEC [dbo].[SetSessionVariable] @SessionVariableKey, @Granted;
END
GO