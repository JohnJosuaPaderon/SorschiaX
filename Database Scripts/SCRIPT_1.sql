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
-- DROP FOREIGN KEY CONSTRAINTS
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.AccessToken
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.AccessToken', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[AccessToken] DROP CONSTRAINT
        [FK_AccessToken_SessionId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.Application
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Application', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[Application] DROP CONSTRAINT
        [FK_Application_PlatformId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.Module
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Module', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[Module] DROP CONSTRAINT
        [FK_Module_ApplicationId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.Permission
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Permission', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[Permission] DROP CONSTRAINT
        [FK_Permission_GroupId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.PermissionGroup
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.PermissionGroup', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[PermissionGroup] DROP CONSTRAINT
        [FK_PermissionGroup_ParentId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.RefreshToken
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.RefreshToken', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[RefreshToken] DROP CONSTRAINT
        [FK_RefreshToken_AccessTokenId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.Session
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Session', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[Session] DROP CONSTRAINT
        [FK_Session_UserId],
        [FK_Session_ApplicationId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.UserApplication
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserApplication', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[UserApplication] DROP CONSTRAINT
        [FK_UserApplication_UserId],
        [FK_UserApplication_ApplicationId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.UserModule
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserModule', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[UserModule] DROP CONSTRAINT
        [FK_UserModule_UserId],
        [FK_UserModule_ModuleId];
GO

-- -------------------------------------------------------------------------------------
-- DROP FOREIGN KEY CONSTRAINTS: SystemCore.UserPermission
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserPermission', 'U') IS NOT NULL
    ALTER TABLE [SystemCore].[UserPermission] DROP CONSTRAINT
        [FK_UserPermission_UserId],
        [FK_UserPermission_PermissionId];
GO

-- ----------------------------------------------------------------------------------------------------
-- DROP TABLES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- DROP TABLES: dbo.SystemConfiguration
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.SystemConfiguration', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemConfiguration];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.AccessToken
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.AccessToken', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[AccessToken];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.Application
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Application', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Application];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.Module
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Module', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Module];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.Permission
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Permission', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Permission];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.PermissionGroup
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.PermissionGroup', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[PermissionGroup];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.Platform
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Platform', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Platform];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.RefreshToken
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.RefreshToken', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[RefreshToken];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.Session
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.Session', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[Session];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.User
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.User', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[User];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.UserApplication
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserApplication', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserApplication];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.UserPermission
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserPermission', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserPermission];
GO

-- -------------------------------------------------------------------------------------
-- DROP TABLES: SystemCore.UserModule
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('SystemCore.UserModule', 'U') IS NOT NULL
    DROP TABLE [SystemCore].[UserModule];
GO

-- ----------------------------------------------------------------------------------------------------
-- CREATE TABLES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: dbo.SystemConfiguration
-- -------------------------------------------------------------------------------------

CREATE TABLE [dbo].[SystemConfiguration]
(
    [Key] NVARCHAR(250),
    [Value] SQL_VARIANT,
    CONSTRAINT [PK_SystemConfiguration] PRIMARY KEY([Key])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.AccessToken
-- -------------------------------------------------------------------------------------

CREATE TABLE [SystemCore].[AccessToken]
(
    [Id] BIGINT IDENTITY,
    [TokenString] NVARCHAR(500) NOT NULL,
    [Expiration] DATETIME NOT NULL,
    [SessionId] BIGINT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    CONSTRAINT [PK_AccessToken] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.Application
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_Application] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.Module
-- -------------------------------------------------------------------------------------

CREATE TABLE [SystemCore].[Module]
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(250) NOT NULL,
    [OrdinalNumber] INT NOT NULL,
    [RouteUrl] NVARCHAR(250),
    [ApplicationId] INT,
    [IsSystemDefined] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIME,
    [UpdatedById] INT,
    [UpdatedOn] DATETIME,
    [DeletedById] INT,
    [DeletedOn] DATETIME,
    CONSTRAINT [PK_Module] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.Permission
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_Permission] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.PermissionGroup
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_PermissionGroup] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.Platform
-- -------------------------------------------------------------------------------------

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
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.RefreshToken
-- -------------------------------------------------------------------------------------

CREATE TABLE [SystemCore].[RefreshToken]
(
    [Id] BIGINT IDENTITY,
    [TokenString] NVARCHAR(500) NOT NULL,
    [AccessTokenId] BIGINT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.Session
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_Session] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.User
-- -------------------------------------------------------------------------------------

CREATE TABLE [SystemCore].[User]
(  
    [Id] INT IDENTITY,
    [FirstName] NVARCHAR(75) NOT NULL,
    [MiddleName] NVARCHAR(75),
    [LastName] NVARCHAR(75) NOT NULL,
    [NameExtension] NVARCHAR(10),
    [FullName] NVARCHAR(250),
    [Username] NVARCHAR(250) NOT NULL,
    [EmailAddress] NVARCHAR(250) NOT NULL,
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
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.UserApplication
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_UserApplication] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.UserModule
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_UserModule] PRIMARY KEY([Id])
);
GO

-- -------------------------------------------------------------------------------------
-- CREATE TABLES: SystemCore.UserPermission
-- -------------------------------------------------------------------------------------

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
    CONSTRAINT [PK_UserPermission] PRIMARY KEY([Id])
);
GO

-- ----------------------------------------------------------------------------------------------------
-- ADD CONSTRAINTS
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.AccessToken
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[AccessToken] ADD
    CONSTRAINT [FK_AccessToken_SessionId] FOREIGN KEY([SessionId]) REFERENCES [SystemCore].[Session]([Id]),
    CONSTRAINT [DF_AccessToken_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.Application
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[Application] ADD
    CONSTRAINT [FK_Application_PlatformId] FOREIGN KEY([PlatformId]) REFERENCES [SystemCore].[Platform]([Id]),
    CONSTRAINT [DF_Application_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Application_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.Module
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[Module] ADD
    CONSTRAINT [FK_Module_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id]),
    CONSTRAINT [DF_Module_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Module_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.Permission
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[Permission] ADD
    CONSTRAINT [FK_Permission_GroupId] FOREIGN KEY([GroupId]) REFERENCES [SystemCore].[PermissionGroup]([Id]),
    CONSTRAINT [DF_Permission_IsApiPermission] DEFAULT 0 FOR [IsApiPermission],
    CONSTRAINT [DF_Permission_IsDatabasePermission] DEFAULT 0 FOR [IsDatabasePermission],
    CONSTRAINT [DF_Permission_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Permission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.PermissionGroup
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[PermissionGroup] ADD
    CONSTRAINT [FK_PermissionGroup_ParentId] FOREIGN KEY([ParentId]) REFERENCES [SystemCore].[PermissionGroup]([Id]),
    CONSTRAINT [DF_PermissionGroup_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_PermissionGroup_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.Platform
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[Platform] ADD
    CONSTRAINT [DF_Platform_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_Platform_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.RefreshToken
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[RefreshToken] ADD
    CONSTRAINT [FK_RefreshToken_AccessTokenId] FOREIGN KEY([AccessTokenId]) REFERENCES [SystemCore].[AccessToken]([Id]),
    CONSTRAINT [DF_RefreshToken_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.Session
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[Session] ADD
    CONSTRAINT [FK_Session_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_Session_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id]),
    CONSTRAINT [DF_Session_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.User
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[User] ADD
    CONSTRAINT [DF_User_IsActive] DEFAULT 0 FOR [IsActive],
    CONSTRAINT [DF_User_IsPasswordChangeRequired] DEFAULT 1 FOR [IsPasswordChangeRequired],
    CONSTRAINT [DF_User_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_User_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.UserApplication
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[UserApplication] ADD
    CONSTRAINT [FK_UserApplication_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserApplication_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [SystemCore].[Application]([Id]),
    CONSTRAINT [DF_UserApplication_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserApplication_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserApplication_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserApplication_IsDeleted] DEFAULT 0 FOR  [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.UserModule
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[UserModule] ADD
    CONSTRAINT [FK_UserModule_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserModule_ModuleId] FOREIGN KEY([ModuleId]) REFERENCES [SystemCore].[Module]([Id]),
    CONSTRAINT [DF_UserModule_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserModule_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserModule_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserModule_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- -------------------------------------------------------------------------------------
-- ADD CONSTRAINTS: SystemCore.UserPermission
-- -------------------------------------------------------------------------------------

ALTER TABLE [SystemCore].[UserPermission] ADD
    CONSTRAINT [FK_UserPermission_UserId] FOREIGN KEY([UserId]) REFERENCES [SystemCore].[User]([Id]),
    CONSTRAINT [FK_UserPermission_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [SystemCore].[Permission]([Id]),
    CONSTRAINT [DF_UserPermisison_IsApproved] DEFAULT 0 FOR [IsApproved],
    CONSTRAINT [DF_UserPermission_IsExpired] DEFAULT 0 FOR [IsExpired],
    CONSTRAINT [DF_UserPermission_IsSystemDefined] DEFAULT 0 FOR [IsSystemDefined],
    CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

-- ----------------------------------------------------------------------------------------------------
-- INITIAL DATA
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.Platform
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[Platform] ON;
GO

INSERT INTO [SystemCore].[Platform]([Id], [Name], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'Web', 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[Platform] OFF;
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.Application
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[Application] ON;
GO

INSERT INTO [SystemCore].[Application]([Id], [Name], [PlatformId], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'Sorschia Administration', 1, 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[Application] OFF;
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.Module
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[Module] ON;

INSERT INTO [SystemCore].[Module]([Id], [Name], [OrdinalNumber], [RouteUrl], [ApplicationId], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'Platforms', 1, '/platforms', 1, 1, -1, GETDATE()),
    (2, 'Applications', 2, '/applications', 1, 1, -1, GETDATE()),
    (3, 'Modules', 3, '/modules', 1, 1, -1, GETDATE()),
    (4, 'Permission Groups', 4, '/permission-groups', 1, 1, -1, GETDATE()),
    (5, 'Permissions', 5, '/permissions', 1, 1, -1, GETDATE()),
    (6, 'Users', 6, '/users', 1, 1, -1, GETDATE());
GO

SET IDENTITY_INSERT [SystemCore].[Module] OFF;

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

INSERT INTO [SystemCore].[Permission]([Description], [GroupId], [IsApiPermission], [ApiDomain], [ApiController], [ApiAction], [IsDatabasePermission], [DatabaseSchema], [DatabaseProcedure], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    ('Delete Application', 2, 1, 'SystemCore', 'Application', 'Delete', 1, 'SystemCore', 'DeleteApplication', 1, -1, GETDATE()),
    ('Save Application', 2, 1, 'SystemCore', 'Application', 'Save', 1, 'SystemCore', 'SaveApplication', 1, -1, GETDATE()),
    ('Get Application', 2, 1, 'SystemCore', 'Application', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search Application', 2, 1, 'SystemCore', 'Application', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete Module', 3, 1, 'SystemCore', 'Module', 'Delete', 1, 'SystemCore', 'DeleteModule', 1, -1, GETDATE()),
    ('Save Module', 3, 1, 'SystemCore', 'Module', 'Save', 1, 'SystemCore', 'SaveModule', 1, -1, GETDATE()),
    ('Get Module', 3, 1, 'SystemCore', 'Module', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search Module', 3, 1, 'SystemCore', 'Module', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete Permission', 4, 1, 'SystemCore', 'Permission', 'Delete', 1, 'SystemCore', 'DeletePermission', 1, -1, GETDATE()),
    ('Save Permission', 4, 1, 'SystemCore', 'Permission', 'Save', 1, 'SystemCore', 'SavePermission', 1, -1, GETDATE()),
    ('Get Permission', 4, 1, 'SystemCore', 'Permission', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search Permission', 4, 1, 'SystemCore', 'Permission', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Delete', 1, 'SystemCore', 'DeletePermissionGroup', 1, -1, GETDATE()),
    ('Save Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Save', 1, 'SystemCore', 'SavePermissionGroup', 1, -1, GETDATE()),
    ('Get Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search Permission Group', 5, 1, 'SystemCore', 'PermissionGroup', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete Platform', 6, 1, 'SystemCore', 'Platform', 'Delete', 1, 'SystemCore', 'DeletePlatform', 1, -1, GETDATE()),
    ('Save Platform', 6, 1, 'SystemCore', 'Platform', 'Save', 1, 'SystemCore', 'SavePlatform', 1, -1, GETDATE()),
    ('Get Platform', 6, 1, 'SystemCore', 'Platform', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search Platform', 6, 1, 'SystemCore', 'Platform', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Change User Password', 7, 1, 'SystemCore', 'User', 'ChangePassword', 1, 'SystemCore', 'ChangeUserPassword', 1, -1, GETDATE()),
    ('Delete User', 7, 1, 'SystemCore', 'User', 'Delete', 1, 'SystemCore', 'DeleteUser', 1, -1, GETDATE()), 
    ('Save User', 7, 1, 'SystemCore', 'User', 'Save', 1, 'SystemCore', 'SaveUser', 1, -1, GETDATE()),
    ('Get User', 7, 1, 'SystemCore', 'User', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search User', 7, 1, 'SystemCore', 'User', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Delete', 1, 'SystemCore', 'DeleteUserApplication', 1, -1, GETDATE()),
    ('Save User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Save', 1, 'SystemCore', 'SaveUserApplication', 1, -1, GETDATE()),
    ('Get User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search User-Application', 8, 1, 'SystemCore', 'UserApplication', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete User-Module', 9, 1, 'SystemCore', 'UserModule', 'Delete', 1, 'SystemCore', 'DeleteUserModule', 1, -1, GETDATE()),
    ('Save User-Module', 9, 1, 'SystemCore', 'UserModule', 'Save', 1, 'SystemCore', 'SaveUserModule', 1, -1, GETDATE()),
    ('Get User-Module', 9, 1, 'SystemCore', 'UserModule', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search User-Module', 9, 1, 'SystemCore', 'UserModule', 'Search', 0, NULL, NULL, 1, -1, GETDATE()),

    ('Delete User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Delete', 1, 'SystemCore', 'DeleteUserPermission', 1, -1, GETDATE()),
    ('Save User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Save', 1, 'SystemCore', 'SaveUserPermission', 1, -1, GETDATE()),
    ('Get User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Get', 0, NULL, NULL, 1, -1, GETDATE()),
    ('Search User-Permission', 10, 1, 'SystemCore', 'UserPermission', 'Search', 0, NULL, NULL, 1, -1, GETDATE());
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.User
-- -------------------------------------------------------------------------------------

SET IDENTITY_INSERT [SystemCore].[User] ON;
GO

INSERT INTO [SystemCore].[User]([Id], [FirstName], [MiddleName], [LastName], [NameExtension], [FullName], [Username], [EmailAddress], [PasswordHash], [IsActive], [IsPasswordChangeRequired], [IsSystemDefined], [InsertedById], [InsertedOn]) VALUES
    (1, 'N/A', NULL, 'N/A', NULL, 'N/A', 'superuser', 'superuser@fakemail.com', 'b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86', 1, 1, 1, -1, GETDATE());

SET IDENTITY_INSERT [SystemCore].[User] OFF;
GO

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.UserApplication
-- -------------------------------------------------------------------------------------

INSERT INTO [SystemCore].[UserApplication]([UserId], [ApplicationId], [IsApproved], [Expiration], [IsExpired], [IsSystemDefined], [InsertedById], [InsertedOn])
SELECT 1, [Id], 1, NULL, 0, 1, -1, GETDATE()
FROM [SystemCore].[Application];

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.UserModule
-- -------------------------------------------------------------------------------------

INSERT INTO [SystemCore].[UserModule]([UserId], [ModuleId], [IsApproved], [Expiration], [IsExpired], [IsSystemDefined], [InsertedById], [InsertedOn])
SELECT 1, [Id], 1, NULL, 0, 1, -1, GETDATE()
FROM [SystemCore].[Module];

-- -------------------------------------------------------------------------------------
-- INITIAL DATA: SystemCore.UserPermission
-- -------------------------------------------------------------------------------------

INSERT INTO [SystemCore].[UserPermission]([UserId], [PermissionId], [IsApproved], [Expiration], [IsExpired], [IsSystemDefined], [InsertedById], [InsertedOn])
SELECT 1, [Id], 1, NULL, 0, 1, -1, GETDATE()
FROM [SystemCore].[Permission];

-- ----------------------------------------------------------------------------------------------------
-- USER-DEFINED TYPES
-- ----------------------------------------------------------------------------------------------------

-- -------------------------------------------------------------------------------------
-- USER-DEFINED TYPES: dbo.IntValue
-- -------------------------------------------------------------------------------------

IF TYPE_ID('dbo.IntValue') IS NOT NULL
BEGIN
    IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchApplication')
        DROP PROCEDURE [SystemCore].[SearchApplication];

    IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchModule')
        DROP PROCEDURE [SystemCore].[SearchModule];

    IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchPermission')
        DROP PROCEDURE [SystemCore].[SearchPermission];

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
        SET @Result = CONCAT(@Result, @MiddleName);

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
-- FUNCTIONS: dbo.GetSystemConfiguration
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.GetSystemConfiguration') IS NOT NULL
    DROP FUNCTION [dbo].[GetSystemConfiguration];
GO

CREATE FUNCTION [dbo].[GetSystemConfiguration](@Key NVARCHAR(250))
RETURNS SQL_VARIANT AS
BEGIN
    RETURN (
        SELECT [Value]
        FROM [dbo].[SystemConfiguration]
        WHERE [Key] = @Key
    );
END
GO

-- -------------------------------------------------------------------------------------
-- FUNCTIONS: dbo.GetSystemDate
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.GetSystemDate') IS NOT NULL
    DROP FUNCTION [dbo].[GetSystemDate];
GO

CREATE FUNCTION [dbo].[GetSystemDate]() RETURNS DATETIME AS
BEGIN
    RETURN GETDATE();
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
-- FUNCTIONS: dbo.IsNullOrWhitespace
-- -------------------------------------------------------------------------------------

IF OBJECT_ID('dbo.IsNullOrWhitespace') IS NOT NULL
    DROP FUNCTION [dbo].[IsNullOrWhitespace];
GO

CREATE FUNCTION [dbo].[IsNullOrWhitespace](@Value NVARCHAR(MAX))
RETURNS BIT AS
BEGIN
    RETURN CASE WHEN @Value IS NULL OR LEN(@Value) <= 0 THEN 1 ELSE 0 END;
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
            [Permission].[DatabaseSchema] = @DatabaseSchema AND
            [Permission].[DatabaseProcedure] = @DatabaseProcedure AND
            [Permission].[IsDeleted] = 0 AND
            [UserPermission].[IsDeleted] = 0 AND
            [UserPermission].[IsApproved] = 1 AND
            [UserPermission].[IsExpired] = 0 AND
            [User].[IsDeleted] = 0 AND
            [User].[IsActive] = 1 AND
            [Session].[SessionEnd] IS NULL AND
            (
                [UserPermission].[Expiration] IS NULL OR
                [UserPermission].[Expiration] < GETDATE()
            )
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
-- STORED PROCEDURES: dbo.SetSystemConfiguration
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'SetSystemConfiguration')
    DROP PROCEDURE [dbo].[SetSystemConfiguration];
GO

CREATE PROCEDURE [dbo].[SetSystemConfiguration](@Key NVARCHAR(250), @Value SQL_VARIANT) AS
BEGIN
    IF EXISTS(SELECT -1 FROM [dbo].[SystemConfiguration] WHERE [Key] = @Key)
        UPDATE [dbo].[SystemConfiguration] SET [Value] = @Value WHERE [Key] = @Key;
    ELSE
        INSERT INTO [dbo].[SystemConfiguration]([Key], [Value]) VALUES(@Key, @Value);
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: dbo.RemoveSystemConfiguration
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'RemoveSystemConfiguration')
    DROP PROCEDURE [dbo].[RemoveSystemConfiguration];
GO

CREATE PROCEDURE [dbo].[RemoveSystemConfiguration](@Key NVARCHAR(250)) AS
BEGIN
    DELETE FROM [dbo].[SystemConfiguration] WHERE [Key] = @Key;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.ChangeUserPassword
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'ChangeUserPassword')
    DROP PROCEDURE [SystemCore].[ChangeUserPassword];
GO

CREATE PROCEDURE
(
    @Id INT,
    @PasswordHash NVARCHAR(250),
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @User_IsDeleted AS BIT;

    RAISERROR('Change User Password: Not implemented', 18, -1);
    RETURN;
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [DeletedOn] = [dbo].[GetSystemDate]()
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
        [ApplicationId],
        [RouteUrl]
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
-- STORED PROCEDURES: SystemCore.GetSession
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetSession')
    DROP PROCEDURE [SystemCore].[GetSession];
GO

CREATE PROCEDURE [SystemCore].[GetSession](@Id BIGINT) AS
BEGIN
    SELECT
        [Id],
        [MacAddress],
        [IpAddress],
        [OperatingSystem],
        [SessionStart],
        [SessionEnd],
        [UserId],
        [ApplicationId]
    FROM [SystemCore].[Session]
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
        [EmailAddress],
        [IsActive],
        [IsPasswordChangeRequired]
    FROM [SystemCore].[User]
    WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.GetUserByCredentials
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'GetUserByCredentials')
    DROP PROCEDURE [SystemCore].[GetUserByCredentials];
GO

CREATE PROCEDURE [SystemCore].[GetUserByCredentials]
(
    @Username NVARCHAR(250), 
    @EmailAddress NVARCHAR(250),
    @PasswordHash NVARCHAR(250)) AS
BEGIN
    SELECT
        [Id],
        [FirstName],
        [MiddleName],
        [LastName],
        [NameExtension],
        [FullName],
        [Username],
        [EmailAddress],
        [IsActive],
        [IsPasswordChangeRequired]
    FROM [SystemCore].[User]
    WHERE
        (
            [dbo].[Equal]([Username], @Username) = 1 OR
            [dbo].[Equal]([EmailAddress], @Username) = 1
        ) AND
        [dbo].[Equal]([PasswordHash], @PasswordHash) = 1 AND
        [IsDeleted] = 0;
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
-- STORED PROCEDURES: SystemCore.SaveAccessToken
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveAccessToken')
    DROP PROCEDURE [SystemCore].[SaveAccessToken];
GO

CREATE PROCEDURE [SystemCore].[SaveAccessToken]
(
    @Id BIGINT OUT,
    @SessionId BIGINT,
    @TokenString NVARCHAR(500),
    @Expiration DATETIME
) AS
BEGIN
    SET @Id = ISNULL(@Id, 0);
    SET @TokenString = [dbo].[Trim](@TokenString);

    IF [dbo].[IsNullOrWhitespace](@TokenString) = 1
    BEGIN
        RAISERROR('Token string is invalid', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        UPDATE [SystemCore].[AccessToken] SET
            [TokenString] = @TokenString,
            [Expiration] = @Expiration,
            [SessionId] = @SessionId
        WHERE [Id] = @Id;
    END
    ELSE
    BEGIN
        INSERT INTO [SystemCore].[AccessToken]
        (
            [TokenString],
            [Expiration],
            [SessionId]
        )
        VALUES
        (
            @TokenString,
            @Expiration,
            @SessionId
        );

        SET @Id = SCOPE_IDENTITY();
    END
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

    SET @Id = ISNULL(@Id, 0);
    SET @Name = [dbo].[Trim](@Name);

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveApplication') = 0
    BEGIN
        RAISERROR('Denied to save application', 18, -1);
        RETURN;
    END

    IF [dbo].[IsNullOrWhitespace](@Name) = 1
    BEGIN
        RAISERROR('Name is invalid', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @Application_IsSystemDefined = [IsSystemDefined],
            @Application_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Application]
        WHERE [Id] = @Id;

        IF ISNULL(@Application_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('Application does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@Application_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined application', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Application] SET
            [Name] = @Name,
            [PlatformId] = @PlatformId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [dbo].[GetSystemDate]()
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
    @RouteUrl NVARCHAR(250),
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @Module_IsSystemDefined AS BIT;
    DECLARE @Module_IsDeleted AS BIT;

    SET @Id = ISNULL(@Id, 0);
    SET @Name = [dbo].[Trim](@Name);

    IF [dbo].[IsNullOrWhitespace](@Name) = 1
    BEGIN
        RAISERROR('Name is invalid', 18, -1);
        RETURN;
    END

    IF @OrdinalNumber IS NULL
    BEGIN
        RAISERROR('Ordinal number is invalid', 18, -1);
        RETURN;
    END
    
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveModule') = 0
    BEGIN
        RAISERROR('Denied to save module', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @Module_IsSystemDefined = [IsSystemDefined],
            @Module_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Module]
        WHERE [Id] = @Id;

        IF ISNULL(@Module_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('Module does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@Module_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined module', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Module] SET
            [Name] = @Name,
            [OrdinalNumber] = @OrdinalNumber,
            [ApplicationId] = @ApplicationId,
            [RouteUrl] = @RouteUrl,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [RouteUrl],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @Name,
            @OrdinalNumber,
            @ApplicationId,
            @RouteUrl,
            @SessionUserId,
            [dbo].[GetSystemDate]()
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

    SET @Id = ISNULL(@Id, 0);
    SET @Description = [dbo].[Trim](@Description);
    SET @IsApiPermission = ISNULL(@IsApiPermission, 0);
    SET @ApiDomain = [dbo].[Trim](@ApiDomain);
    SET @ApiController = [dbo].[Trim](@ApiController);
    SET @ApiAction = [dbo].[Trim](@ApiAction);
    SET @IsDatabasePermission = ISNULL(@IsDatabasePermission, 0);
    SET @DatabaseSchema = [dbo].[Trim](@DatabaseSchema);
    SET @DatabaseProcedure = [dbo].[Trim](@DatabaseProcedure);

    IF [dbo].[IsNullOrWhitespace](@Description) = 1
    BEGIN
        RAISERROR('Description is invalid', 18, -1);
        RETURN;
    END

    IF @IsApiPermission = 1
    BEGIN
        IF [dbo].[IsNullOrWhitespace](@ApiDomain) = 1
        BEGIN
            RAISERROR('Api domain is invalid', 18, -1);
            RETURN;
        END

        IF [dbo].[IsNullOrWhitespace](@ApiController) = 1
        BEGIN
            RAISERROR('Api controller is invalid', 18, -1);
            ReTURN;
        END

        IF [dbo].[IsNullOrWhitespace](@ApiAction) = 1
        BEGIN
            RAISERROR('Api action is invalid', 18, -1);
            RETURN;
        END
    END

    IF @IsDatabasePermission = 1
    BEGIN
        IF [dbo].[IsNullOrWhitespace](@DatabaseSchema) = 1
        BEGIN
            RAISERROR('Database schema is invalid', 18, -1);
            RETURN;
        END

        IF [dbo].[IsNullOrWhitespace](@DatabaseProcedure) = 1
        BEGIN
            RAISERROR('Database procedure is invalid', 18, -1);
            RETURN;
        END
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePermission') = 0
    BEGIN
        RAISERROR('Denied to save permission', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @Permission_IsSystemDefined = [IsSystemDefined],
            @Permission_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Permission]
        WHERE [Id] = @Id;

        IF ISNULL(@Permission_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('Permission does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@Permission_IsSystemDefined, 0) = 1
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
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [dbo].[GetSystemDate]()
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

    SET @Id = ISNULL(@Id, 0);
    SET @Name = [dbo].[Trim](@Name);

    IF [dbo].[IsNullOrWhitespace](@Name) = 1
    BEGIN
        RAISERROR('Name is invalid', 18, -1);
        RETURN;
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePermissionGroup') = 0
    BEGIN
        RAISERROR('Denied to save permission group', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @PermissionGroup_IsSystemDefined = [IsSystemDefined],
            @PermissionGroup_IsDeleted = [IsDeleted]
        FROM [SystemCore].[PermissionGroup]
        WHERE [Id] = @Id;

        IF ISNULL(@PermissionGroup_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('Permission group does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@PermissionGroup_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined permission group', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[PermissionGroup] SET
            [Name] = @Name,
            [ParentId] = @ParentId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [dbo].[GetSystemDate]()
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

    SET @Id = ISNULL(@Id, 0);
    SET @Name = [dbo].[Trim](@Name);

    IF [dbo].[IsNullOrWhitespace](@Name) = 1
    BEGIN
        RAISERROR('Name is invalid', 18, -1);
        RETURN;
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;
    
    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SavePlatform') = 0
    BEGIN
        RAISERROR('Denied to save platform', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @Platform_IsSystemDefined = [IsSystemDefined],
            @Platform_IsDeleted = [IsDeleted]
        FROM [SystemCore].[Platform]
        WHERE [Id] = @Id;

        IF ISNULL(@Platform_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('Platform does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@Platform_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined platform', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[Platform] SET
            [Name] = @Name,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [dbo].[GetSystemDate]()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveRefreshToken
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveRefreshToken')
    DROP PROCEDURE [SystemCore].[SaveRefreshToken];
GO

CREATE PROCEDURE [SystemCore].[SaveRefreshToken]
(
    @Id BIGINT OUT,
    @TokenString NVARCHAR(500),
    @AccessTokenId BIGINT
) AS
BEGIN
    SET @Id = ISNULL(@Id, 0);
    SET @TokenString = [dbo].[Trim](@TokenString);

    IF [dbo].[IsNullOrWhitespace](@TokenString) = 1
    BEGIN
        RAISERROR('Token string is invalid', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        UPDATE [SystemCore].[RefreshToken] SET
            [TokenString] = @TokenString,
            [AccessTokenId] = @AccessTokenId
        WHERE [Id] = @Id;
    END
    ELSE
    BEGIN
        INSERT INTO [SystemCore].[RefreshToken]
        (
            [TokenString],
            [AccessTokenId]
        )
        VALUES
        (
            @TokenString,
            @AccessTokenId
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
    @EmailAddress NVARCHAR(250),
    @OldPasswordHash NVARCHAR(250),
    @NewPasswordHash NVARCHAR(250),
    @IsActive BIT,
    @IsPasswordChangeRequired BIT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @User_IsSystemDefined AS BIT;
    DECLARE @User_IsDeleted AS BIT;
    DECLARE @FullName NVARCHAR(250);
    DECLARE @IsPermissionGranted AS BIT;
    DECLARE @IsCurrentUser AS BIT; -- SET to 1 if the Session User ID and the User ID are same, 0 otherwise
    
    SET @Id = ISNULL(@Id, 0);
    SET @FirstName = [dbo].[Trim](@FirstName);
    SET @MiddleName = [dbo].[Trim](@MiddleName);
    SET @LastName = [dbo].[Trim](@LastName);
    SET @NameExtension = [dbo].[Trim](@NameExtension);
    SET @Username = [dbo].[Trim](@Username);
    SET @EmailAddress = [dbo].[Trim](@EmailAddress);
    SET @OldPasswordHash = [dbo].[Trim](@OldPasswordHash);
    SET @NewPasswordHash = [dbo].[Trim](@NewPasswordHash);
    SET @IsActive = ISNULL(@IsActive, 0);
    SET @IsPasswordChangeRequired = ISNULL(@IsPasswordChangeRequired, 0);

    IF [dbo].[IsNullOrWhitespace](@FirstName) = 1
    BEGIN
        RAISERROR('First name is invalid', 18, -1);
        RETURN;
    END

    IF [dbo].[IsNullOrWhitespace](@LastName) = 1
    BEGIN
        RAISERROR('Last name is invalid', 18, -1);
        RETURN;
    END

    IF [dbo].[IsNullOrWhitespace](@Username) = 1
    BEGIN
        RAISERROR('Username is invalid', 18, -1);
        RETURN;
    END

    IF [dbo].[IsNullOrWhitespace](@EmailAddress) = 1
    BEGIN
        RAISERROR('Email address is invalid', 18, -1);
        RETURN;
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;
    SET @IsPermissionGranted = [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUser');
    SEt @IsCurrentUser = [dbo].[Equal](@SessionUserId, @Id);

    IF @IsPermissionGranted = 0 AND @IsCurrentUser = 0
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
            CASE WHEN (@Id IS NOT NULL OR @Id <> 0) AND [Id] <> @Id THEN 1 ELSE 0 END = 1
    )
    BEGIN
        RAISERROR('Username already exists', 18, -1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT -1
        FROM [SystemCore].[User]
        WHERE
            [dbo].[Equal]([EmailAddress], @EmailAddress) = 1 AND
            CASE WHEN (@Id IS NOT NULL OR @Id <> 0) AND [Id] <> @Id THEN 1 ELSE 0 END = 1
    )
    BEGIN
        RAISERROR('Email address already in use', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @User_IsSystemDefined = [IsSystemDefined],
            @User_IsDeleted = [IsDeleted]
        FROM [SystemCore].[User]
        WHERE [Id] = @Id;

        IF ISNULL(@User_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('User does not exists', 18, -1);
            RETURN;
        END

        IF @NewPasswordHash IS NOT NULL
        BEGIN
            IF
                @IsCurrentUser = 1 AND
                NOT EXISTS
                (
                    SELECT -1
                    FROM [SystemCore].[User]
                    WHERE [Id] = @Id AND [dbo].[Equal]([PasswordHash], @OldPasswordHash) = 1
                )
            BEGIN
                RAISERROR('Old password is incorrect', 18, -1);
                RETURN;
            END
            ELSE IF
                @IsCurrentUser = 0 AND 
                [SystemCore].[IsPermissionGranted]('SystemCore', 'ChangeUserPassword') = 0
            BEGIN
                RAISERROR('Permission denied to change password', 18, -1);
                RETURN;
            END
        END

        UPDATE [SystemCore].[User] SET
            [FirstName] = @FirstName,
            [MiddleName] = @MiddleName,
            [LastName] = @LastName,
            [NameExtension] = @NameExtension,
            [FullName] = [dbo].[BuildFullName](@FirstName, @MiddleName, @LastName, @NameExtension),
            [Username] = @Username,
            [EmailAddress] = @EmailAddress,
            [PasswordHash] = ISNULL(@NewPasswordHash, [PasswordHash]),
            [IsActive] = @IsActive,
            [IsPasswordChangeRequired] = @IsPasswordChangeRequired,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([FirstName], @FirstName) = 1 OR
                [dbo].[HasChanges]([MiddleName], @MiddleName) = 1 OR
                [dbo].[HasChanges]([LastName], @LastName) = 1 OR
                [dbo].[HasChanges]([NameExtension], @NameExtension) = 1 OR
                [dbo].[HasChanges]([Username], @Username) = 1 OR
                [dbo].[HasChanges]([EmailAddress], @EmailAddress) = 1 OR
                [dbo].[HasChanges]([IsActive], @IsActive) = 1 OR
                [dbo].[HasChanges]([IsPasswordChangeRequired], @IsPasswordChangeRequired) = 1
            );
    END
    ELSE
    BEGIN
        IF [dbo].[IsNullOrWhitespace](@NewPasswordHash) = 1
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
            @NewPasswordHash,
            @IsActive,
            @IsPasswordChangeRequired,
            @SessionUserId,
            [dbo].[GetSystemDate]()
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

    SET @Id = ISNULL(@Id, 0);
    SET @IsApproved = ISNULL(@IsApproved, 0);
    SET @IsExpired = ISNULL(@IsExpired, 0);

    IF @Expiration IS NOT NULL AND @Expiration < [dbo].[GetSystemDate]()
    BEGIN
        RAISERROR('Expiration cannot be in the past', 18, -1);
        RETURN;
    END
    
    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUserApplication') = 0
    BEGIN
        RAISERROR('Denied to save user-application', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @UserApplication_IsSystemDefined = [IsSystemDefined],
            @UserApplication_IsDeleted = [IsDeleted]
        FROM [SystemCore].[UserApplication]
        WHERE [Id] = @Id;

        IF ISNULL(@UserApplication_IsDeleted, 1) = 1
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
            [UpdatedOn] = [dbo].[GetSystemDate]()
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
            [dbo].[GetSystemDate]()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveUserModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveUserModule')
    DROP PROCEDURE [SystemCore].[SaveUserModule];
GO

CREATE PROCEDURE [SystemCore].[SaveUserModule]
(
    @Id BIGINT OUT,
    @IsApproved BIT,
    @Expiration DATETIME,
    @IsExpired BIT,
    @UserId INT,
    @ModuleId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @UserModule_IsSystemDefined AS BIT;
    DECLARE @UserModule_IsDeleted AS BIT;

    SET @Id = ISNULL(@Id, 0);
    SET @IsApproved = ISNULL(@IsApproved, 0);
    SET @IsExpired = ISNULL(@IsExpired, 0);

    IF @Expiration IS NOT NULL AND @Expiration < [dbo].[GetSystemDate]()
    BEGIN
        RAISERROR('Expiration cannot be in the past', 18, -1);
        RETURN;
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUserModule') = 0
    BEGIN
        RAISERROR('Denied to save user-module', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @UserModule_IsSystemDefined = [IsSystemDefined],
            @UserModule_IsDeleted = [IsDeleted]
        FROM [SystemCore].[UserModule]
        WHERE [Id] = @Id;

        IF ISNULL(@UserModule_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('User-module does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@UserModule_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined user-module', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[UserModule] SET
            [IsApproved] = @IsApproved,
            [Expiration] = @Expiration,
            [IsExpired] = @IsExpired,
            [UserId] = @UserId,
            [ModuleId] = @ModuleId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([IsApproved], @IsApproved) = 1 OR
                [dbo].[HasChanges]([Expiration], @Expiration) = 1 OR
                [dbo].[HasChanges]([IsExpired], @IsExpired) = 1 OR
                [dbo].[HasChanges]([UserId], @UserId) = 1 OR
                [dbo].[HasChanges]([ModuleId], @ModuleId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[UserModule]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([IsApproved], @IsApproved) = 1 AND
                [dbo].[Equal]([Expiration], @Expiration) = 1 AND
                [dbo].[Equal]([IsExpired], @IsExpired) = 1 AND
                [dbo].[Equal]([UserId], @UserId) = 1 AND
                [dbo].[Equal]([ModuleId], @ModuleId) = 1
        )
        BEGIN
            RAISERROR('User-module already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[UserModule]
        (
            [IsApproved],
            [Expiration],
            [IsExpired],
            [UserId],
            [ModuleId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @IsApproved,
            @Expiration,
            @IsExpired,
            @UserId,
            @ModuleId,
            @SessionUserId,
            [dbo].[GetSystemDate]()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SaveUserPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SaveUserPermission')
    DROP PROCEDURE [SystemCore].[SaveUserPermission];
GO

CREATE PROCEDURE [SystemCore].[SaveUserPermission]
(
    @Id BIGINT OUT,
    @IsApproved BIT,
    @Expiration DATETIME,
    @IsExpired BIT,
    @UserId INT,
    @PermissionId INT,
    @SessionId BIGINT
) AS
BEGIN
    DECLARE @SessionUserId AS INT;
    DECLARE @UserPermission_IsSystemDefined AS BIT;
    DECLARE @UserPermission_IsDeleted AS BIT;
    
    SET @Id = ISNULL(@Id, 0);
    SET @IsApproved = ISNULL(@IsApproved, 0);
    SET @IsExpired = ISNULL(@IsExpired, 0);

    IF @Expiration IS NOT NULL AND @Expiration < [dbo].[GetSystemDate]()
    BEGIN
        RAISERROR('Expiration cannot be in the past', 18, -1);
        RETURN;
    END

    EXEC [SystemCore].[SetSessionId] @SessionId, @SessionUserId OUT;

    IF [SystemCore].[IsPermissionGranted]('SystemCore', 'SaveUserPermission') = 0
    BEGIN
        RAISERROR('Denied to save user-permission', 18, -1);
        RETURN;
    END

    IF @Id <> 0
    BEGIN
        SELECT
            @UserPermission_IsSystemDefined = [IsSystemDefined],
            @UserPermission_IsDeleted = [IsDeleted]
        FROM [SystemCore].[UserPermission]
        WHERE [Id] = @Id;

        IF ISNULL(@UserPermission_IsDeleted, 1) = 1
        BEGIN
            RAISERROR('User-permission does not exists', 18, -1);
            RETURN;
        END

        IF ISNULL(@UserPermission_IsSystemDefined, 0) = 1
        BEGIN
            RAISERROR('Cannot update system-defined user-permission', 18, -1);
            RETURN;
        END

        UPDATE [SystemCore].[UserPermission] SET
            [IsApproved] = @IsApproved,
            [Expiration] = @Expiration,
            [IsExpired] = @IsExpired,
            [UserId] = @UserId,
            [PermissionId] = @PermissionId,
            [UpdatedById] = @SessionUserId,
            [UpdatedOn] = [dbo].[GetSystemDate]()
        WHERE
            [Id] = @Id AND
            (
                [dbo].[HasChanges]([IsApproved], @IsApproved) = 1 OR
                [dbo].[HasChanges]([Expiration], @Expiration) = 1 OR
                [dbo].[HasChanges]([IsExpired], @IsExpired) = 1 OR
                [dbo].[HasChanges]([UserId], @UserId) = 1 OR
                [dbo].[HasChanges]([PermissionId], @PermissionId) = 1
            );
    END
    ELSE
    BEGIN
        IF EXISTS
        (
            SELECT -1
            FROM [SystemCore].[UserPermission]
            WHERE
                [IsDeleted] = 0 AND
                [dbo].[Equal]([IsApproved], @IsApproved) = 1 AND
                [dbo].[Equal]([Expiration], @Expiration) = 1 AND
                [dbo].[Equal]([IsExpired], @IsExpired) = 1 AND
                [dbo].[Equal]([UserId], @UserId) = 1 AND
                [dbo].[Equal]([PermissionId], @PermissionId) = 1
        )
        BEGIN
            RAISERROR('User-permission already exists', 18, -1);
            RETURN;
        END

        INSERT INTO [SystemCore].[UserPermission]
        (
            [IsApproved],
            [Expiration],
            [IsExpired],
            [UserId],
            [PermissionId],
            [InsertedById],
            [InsertedOn]
        )
        VALUES
        (
            @IsApproved,
            @Expiration,
            @IsExpired,
            @UserId,
            @PermissionId,
            @SessionUserId,
            [dbo].[GetSystemDate]()
        );

        SET @Id = SCOPE_IDENTITY();
    END
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SearchApplication
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchApplication')
    DROP PROCEDURE [SystemCore].[SearchApplication];
GO

CREATE PROCEDURE [SystemCore].[SearchApplication]
(
    @Skip INT,
    @Take INT,
    @FilterText NVARCHAR(250),
    @PlatformIds [dbo].[IntValue] READONLY,
    @SkippedIds [dbo].[IntValue] READONLY,
    @UserIds [dbo].[IntValue] READONLY
) AS
BEGIN
    DECLARE @Query AS NVARCHAR(MAX);
    DECLARE @TotalCountQuery AS NVARCHAR(MAX);
    DECLARE @Parameters AS NVARCHAR(MAX);
    DECLARE @TotalCountParameters AS NVARCHAR(MAX);
    DECLARE @AppendQuery AS NVARCHAR(MAX);
    DECLARE @HasPlatformIds AS BIT;
    DECLARE @HasSkippedIds AS BIT;
    DECLARE @HasUserIds AS BIT;
    DECLARE @SystemDate AS DATETIME = [dbo].[GetSystemDate]();

    SET @Skip = ISNULL(@Skip, 0);
    SET @Take = ISNULL(@Take, 0);
    SET @FilterText = [dbo].[Trim](@FilterText);
    SET @HasPlatformIds = CASE WHEN EXISTS(SELECT -1 FROM @PlatformIds) THEN 1 ELSE 0 END;
    SET @HasSkippedIds = CASE WHEN EXISTS(SELECT -1 FROM @SkippedIds) THEN 1 ELSE 0 END;
    SET @HasUserIds = CASE WHEN EXISTS(SELECT -1 FROM @UserIds) THEN 1 ELSE 0 END;

    SET @Query = '
        SELECT DISTINCT
            [Application].[Id] AS [Id],
            [Application].[Name] AS [Name],
            [Application].[PlatformId] AS [PlatformId]
    ';
    SET @TotalCountQuery = 'SELECT COUNT(DISTINCT [Application].[Id]) AS [TotalCount]';
    SET @TotalCountParameters = '
        @FilterText NVARCHAR(250),
        @PlatformIds [dbo].[IntValue] READONLY,
        @SkippedIds [dbo].[IntValue] READONLY,
        @UserIds [dbo].[IntValue] READONLY,
        @SystemDate DATETIME
    ';
    SET @Parameters = CONCAT(@TotalCountParameters, ', @Skip INT, @Take INT');
    SET @AppendQuery = ' FROM [SystemCore].[Application]';

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' INNER JOIN [SystemCore].[UserApplication] ON [Application].[Id] = [UserApplication].[ApplicationId]');

    SET @AppendQuery = CONCAT(@AppendQuery, ' WHERE [Application].[IsDeleted] = 0');

    IF [dbo].[IsNullOrWhitespace](@FilterText) <> 0
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Application].[Name] LIKE CONCAT(''%'', @FilterText, ''%'')');

    IF @HasPlatformIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Application].[PlatformId] IN (SELECT [Value] FROM @PlatformIds)');

    IF @HasSkippedIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Application].[Id] NOT IN (SELECT [Value] FROM @SkippedIds)');

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND
            [UserApplication].[UserId] IN (SELECT [Value] FROM @UserIds) AND
            [UserApplication].[IsDeleted] = 0 AND
            [UserApplication].[IsApproved] = 1 AND
            [UserApplication].[IsExpired] = 0 AND
            (
                [UserApplication].[Expiration] IS NULL OR
                [UserApplication].[Expiration] > @SystemDate
            )
        ');

    SET @Query = CONCAT(@Query, @AppendQuery, ' ORDER BY [Application].[Name] ASC');
    SET @TotalCountQuery = CONCAT(@TotalCountQuery, @AppendQuery);

    IF @Take > 0
        SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');
    
    EXEC SP_EXECUTESQL @Query, @Parameters,
        @Skip = @Skip,
        @Take = @Take,
        @FilterText = @FilterText,
        @PlatformIds = @PlatformIds,
        @SkippedIds = @SkippedIds,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;

    EXEC SP_EXECUTESQL @TotalCountQuery, @TotalCountParameters,
        @FilterText = @FilterText,
        @PlatformIds = @PlatformIds,
        @SkippedIds = @SkippedIds,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SearchModule
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchModule')
    DROP PROCEDURE [SystemCore].[SearchModule];
GO

CREATE PROCEDURE [SystemCore].[SearchModule]
(
    @Skip INT,
    @Take INT,
    @FilterText NVARCHAR(MAX),
    @ApplicationIds [dbo].[IntValue] READONLY,
    @SkippedIds [dbo].[IntValue] READONLY,
    @UserIds [dbo].[IntValue] READONLY
) AS
BEGIN
    DECLARE @Query AS NVARCHAR(MAX);
    DECLARE @TotalCountQuery AS NVARCHAR(MAX);
    DECLARE @Parameters AS NVARCHAR(MAX);
    DECLARE @TotalCountParameters AS NVARCHAR(MAX);
    DECLARE @AppendQuery AS NVARCHAR(MAX);
    DECLARE @HasApplicationIds AS BIT;
    DECLARE @HasSkippedIds AS BIT;
    DECLARE @HasUserIds AS BIT;
    DECLARE @SystemDate AS DATETIME = [dbo].[GetSystemDate]();

    SET @Skip = ISNULL(@Skip, 0);
    SET @Take = ISNULL(@Take, 0);
    SET @FilterText = [dbo].[Trim](@FilterText);
    SET @HasApplicationIds = CASE WHEN EXISTS(SELECT -1 FROM @ApplicationIds) THEN 1 ELSE 0 END;
    SET @HasSkippedIds = CASE WHEN EXISTS(SELECT -1 FROM @SkippedIds) THEN 1 ELSE 0 END;
    SET @HasUserIds = CASE WHEN EXISTS(SELECT -1 FROM @UserIds) THEN 1 ELSE 0 END;

    SET @Query = '
        SELECT DISTINCT
            [Module].[Id],
            [Module].[Name],
            [Module].[OrdinalNumber],
            [Module].[RouteUrl],
            [Module].[ApplicationId]
    ';
    SET @TotalCountQuery = 'SELECT COUNT(DISTINCT [Module].[Id]) AS [TotalCount]';
    SET @TotalCountParameters = '
        @FilterText NVARCHAR(250),
        @ApplicationIds [dbo].[IntValue] READONLY,
        @SkippedIds [dbo].[IntValue] READONLY,
        @UserIds [dbo].[IntValue] READONLY,
        @SystemDate DATETIME
    ';
    SET @Parameters = CONCAT(@TotalCountParameters, ', @Skip INT, @Take INT');
    SET @AppendQuery = ' FROM [SystemCore].[Module]';

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' INNER JOIN [SystemCore].[UserModule] ON [Module].[Id] = [UserModule].[ModuleId]');

    SET @AppendQuery = CONCAT(@AppendQuery, ' WHERE [Module].[IsDeleted] = 0');

    IF [dbo].[IsNullOrWhitespace](@FilterText) <> 0
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Module].[Name] LIKE CONCAT(''%'', @FilterText, ''%'')');

    IF @HasApplicationIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Module].[ApplicationId] IN (SELECT [Value] FROM @ApplicationIds)');

    IF @HasSkippedIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Module].[Id] NOT IN (SELECT [Value] FROM @SkippedIds)');

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND
            [UserModule].[UserId] IN (SELECT [value] FROM @UserIds) AND
            [UserModule].[IsDeleted] = 0 AND
            [UserModule].[IsApproved] = 1 AND
            [UserModule].[IsExpired] = 0 AND
            (
                [UserModule].[Expiration] IS NULL OR
                [UserModule].[Expiration] > @SystemDate
            )
        ');

    SET @Query = CONCAT(@Query, @AppendQuery, ' ORDER BY [Module].[Name] ASC');
    SET @TotalCountQuery = CONCAT(@TotalCountQuery, @AppendQuery);

    IF @Take > 0
        SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');
    
    EXEC SP_EXECUTESQL @Query, @Parameters,
        @Skip = @Skip,
        @Take = @Take,
        @FilterText = @FilterText,
        @ApplicationIds = @ApplicationIds,
        @SkippedIds = @SkippedIds,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;

    EXEC SP_EXECUTESQL @TotalCountQuery, @TotalCountParameters,
        @FilterText = @FilterText,
        @ApplicationIds = @ApplicationIds,
        @SkippedIds = @SkippedIds,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;
END
GO

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.SearchPermission
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'SearchPermission')
    DROP PROCEDURE [SystemCore].[SearchPermission];
GO

CREATE PROCEDURE [SystemCore].[SearchPermission]
(
    @Skip INT,
    @Take INT,
    @FilterText NVARCHAR(MAX),
    @GroupIds [dbo].[IntValue] READONLY,
    @SkippedIds [dbo].[IntValue] READONLY,
    @IsApiPermission BIT,
    @IsDatabasePermission BIT,
    @UserIds [dbo].[IntValue] READONLY
) AS
BEGIN
    DECLARE @Query AS NVARCHAR(MAX);
    DECLARE @TotalCountQuery AS NVARCHAR(MAX);
    DECLARE @Parameters AS NVARCHAR(MAX);
    DECLARE @TotalCountParameters AS NVARCHAR(MAX);
    DECLARE @AppendQuery AS NVARCHAR(MAX);
    DECLARE @HasGroupIds AS BIT;
    DECLARE @HasSkippedIds AS BIT;
    DECLARE @HasUserIds AS BIT;
    DECLARE @SystemDate AS DATETIME = [dbo].[GetSystemDate]();

    SET @Skip = ISNULL(@Skip, 0);
    SET @Take = ISNULL(@Take, 0);
    SET @FilterText = [dbo].[Trim](@FilterText);
    SET @HasGroupIds = CASE WHEN EXISTS(SELECT -1 FROM @GroupIds) THEN 1 ELSE 0 END;
    SET @HasSkippedIds = CASE WHEN EXISTS(SELECT -1 FROM @SkippedIds) THEN 1 ELSE 0 END;
    SET @HasUserIds = CASE WHEN EXISTS(SELECT -1 FROM @UserIds) THEN 1 ELSE 0 END;

    SET @Query = '
        SELECT DISTINCT
            [Permission].[Id],
            [Permission].[Description],
            [Permission].[IsApiPermission],
            [Permission].[ApiDomain],
            [Permission].[ApiController],
            [Permission].[ApiAction],
            [Permission].[IsDatabasePermission],
            [Permission].[DatabaseSchema],
            [Permission].[DatabaseProcedure],
            [Permission].[GroupId]
    ';
    SET @TotalCountQuery = 'SELECT COUNT(DISTINCT [Permission].[Id]) AS [TotalCount]';
    SET @TotalCountParameters = '
        @FilterText NVARCHAR(MAX),
        @GroupIds [dbo].[IntValue] READONLY,
        @SkippedIds [dbo].[IntValue] READONLY,
        @IsApiPermission BIT,
        @IsDatabasePermission BIT,
        @UserIds [dbo].[IntValue] READONLY,
        @SystemDate DATETIME
    ';
    SET @Parameters = CONCAT(@TotalCountParameters, ', @Skip INT, @Take INT');
    SET @AppendQuery = ' FROM [SystemCore].[Permission]';

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' INNER JOIN [SystemCore].[UserPermission] ON [Permission].[Id] = [UserPermission].[PermissionId]');
    
    SET @AppendQuery = CONCAT(@AppendQuery, ' WHERE [Permission].[IsDeleted] = 0');

    IF [dbo].[IsNullOrWhitespace](@FilterText) <> 0
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Permission].[Description] LIKE CONCAT(''%'', @FilterText, ''%'')');

    IF @HasGroupIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Permission].[GroupId] IN (SELECT [Value] FROM @GroupIds)');

    IF @HasSkippedIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Permission].[Id] NOT IN (SELECT [Value] FROM @SkippedIds)');

    IF @IsApiPermission IS NOT NULL
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Permission].[IsApiPermission] = @IsApiPermission');

    IF @IsDatabasePermission IS NOT NULL
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND [Permission].[IsDatabasePermission] = @IsDatabasePermission');

    IF @HasUserIds = 1
        SET @AppendQuery = CONCAT(@AppendQuery, ' AND
            [UserPermission].[UserId] IN (SELECT [Value] FROM @UserIds) AND
            [UserPermission].[IsDeleted] = 0 AND
            [UserPermission].[IsApproved] = 1 AND
            [UserPermission].[IsExpired] = 0 AND
            (
                [UserPermission].[Expiration] IS NULL OR
                [UserPermission].[Expiration] > @SystemDate
            )
        ');

    SET @Query = CONCAT(@Query, @AppendQuery, ' ORDER BY [Permission].[Description] ASC');
    SET @TotalCountQuery = CONCAT(@TotalCountQuery, @AppendQuery);

    IF @Take > 0
        SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');
    
    EXEC SP_EXECUTESQL @Query, @Parameters,
        @Skip = @Skip,
        @Take = @Take,
        @FilterText = @FilterText,
        @GroupIds = @GroupIds,
        @SkippedIds = @SkippedIds,
        @IsApiPermission = @IsApiPermission,
        @IsDatabasePermission = @IsDatabasePermission,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;

    EXEC SP_EXECUTESQL @TotalCountQuery, @TotalCountParameters,
        @FilterText = @FilterText,
        @GroupIds = @GroupIds,
        @SkippedIds = @SkippedIds,
        @IsApiPermission = @IsApiPermission,
        @IsDatabasePermission = @IsDatabasePermission,
        @UserIds = @UserIds,
        @SystemDate = @SystemDate;
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

-- -------------------------------------------------------------------------------------
-- STORED PROCEDURES: SystemCore.StartSession
-- -------------------------------------------------------------------------------------

IF EXISTS(SELECT -1 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'SystemCore' AND [SPECIFIC_NAME] = 'StartSession')
    DROP PROCEDURE [SystemCore].[StartSession];
GO

CREATE PROCEDURE [SystemCore].[StartSession]
(
    @Id BIGINT OUT,
    @SessionStart DATETIME OUT,
    @UserId INT,
    @ApplicationId INT,
    @MacAddress NVARCHAR(100) = NULL,
    @IpAddress NVARCHAR(100) = NULL,
    @OperatingSystem NVARCHAR(100) = NULL
) AS
BEGIN
    SET @SessionStart = [dbo].[GetSystemDate]();

    INSERT INTO [SystemCore].[Session]
    (
        [MacAddress],
        [IpAddress],
        [OperatingSystem],
        [SessionStart],
        [SessionEnd],
        [UserId],
        [ApplicationId]
    )
    VALUES
    (
        @MacAddress,
        @IpAddress,
        @OperatingSystem,
        @SessionStart,
        NULL,
        @UserId,
        @ApplicationId
    );

    SET @Id = SCOPE_IDENTITY();
END
GO