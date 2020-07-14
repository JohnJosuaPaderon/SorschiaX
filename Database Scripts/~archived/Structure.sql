---------- DATABASE ----------

--USE [master];
--GO

--CREATE DATABASE [Sorschia_SystemBase];
--GO

USE [Sorschia_SystemBase];
GO

-----------------------------
---------- SCHEMAS ----------
-----------------------------

--CREATE SCHEMA [Security];
--GO

---------------------------------
---------- DROP TABLES ----------
---------------------------------

IF OBJECT_ID('Security.UserApplication', 'U') IS NOT NULL
	DROP TABLE [Security].[UserApplication];
GO

IF OBJECT_ID('Security.UserModule', 'U') IS NOT NULL
	DROP TABLE [Security].[UserModule];
GO

IF OBJECT_ID('Security.UserPermission', 'U') IS NOT NULL
	DROP TABLE [Security].[UserPermission];
GO

IF OBJECT_ID('Security.Module', 'U') IS NOT NULL
	DROP TABLE [Security].[Module];
GO

IF OBJECT_ID('Security.Session', 'U') IS NOT NULL
	DROP TABLE [Security].[Session];
GO

IF OBJECT_ID('Security.Application', 'U') IS NOT NULL
	DROP TABLE [Security].[Application];
GO

IF OBJECT_ID('Security.ApplicationPlatform', 'U') IS NOT NULL
	DROP TABLE [Security].[ApplicationPlatform];
GO

IF OBJECT_ID('Security.Permission', 'U') IS NOT NULL
	DROP TABLE [Security].[Permission];
GO

IF OBJECT_ID('Security.User') IS NOT NULL
	DROP TABLE [Security].[User];
GO

-----------------------------------
---------- CREATE TABLES ----------
-----------------------------------

CREATE TABLE [Security].[ApplicationPlatform]
(
	[Id] INT IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_ApplicationPlatform] PRIMARY KEY([Id])
);

ALTER TABLE [Security].[ApplicationPlatform] ADD
	CONSTRAINT [DF_ApplicationPlatform_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[Application]
(
	[Id] INT IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,[PlatformId] INT
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_Application] PRIMARY KEY([Id])
	,CONSTRAINT [FK_Application_PlatformId] FOREIGN KEY([PlatformId]) REFERENCES [Security].[ApplicationPlatform]([Id])
);

ALTER TABLE [Security].[Application] ADD
	CONSTRAINT [DF_Application_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[Module]
(
	[Id] INT IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,[OrdinalNumber] INT NOT NULL
	,[ApplicationId] INT
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_Module] PRIMARY KEY([Id])
	,CONSTRAINT [FK_ModuleId] FOREIGN KEY([ApplicationId]) REFERENCES [Security].[Application]([Id])
);

ALTER TABLE [Security].[Module] ADD
	CONSTRAINT [DF_Module_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[Permission]
(
	[Id] INT IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,[Code] NVARCHAR(100) NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_Permission] PRIMARY KEY([Id])
);

ALTER TABLE [Security].[Permission] ADD
	CONSTRAINT [DF_Permission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[User]
(
	[Id] INT IDENTITY
	,[FirstName] NVARCHAR(100) NOT NULL
	,[MiddleName] NVARCHAR(100)
	,[LastName] NVARCHAR(100) NOT NULL
	,[MiddleInitials] NVARCHAR(5)
	,[FullName] NVARCHAR(350) NOT NULL
	,[InformalFullName] NVARCHAR(350) NOT NULL
	,[Username] NVARCHAR(250) NOT NULL
	,[HashedPassword] NVARCHAR(250) NOT NULL
	,[IsActive] BIT NOT NULL
	,[IsPasswordChangeRequired] BIT NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_User] PRIMARY KEY([Id])
);

ALTER TABLE [Security].[User] ADD
	CONSTRAINT [DF_User_IsActive] DEFAULT 0 FOR [IsActive]
	,CONSTRAINT [DF_User_IsPasswordChangeRequired] DEFAULT 1 FOR [IsPasswordChangeRequired]
	,CONSTRAINT [DF_User_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[Session]
(
	[Id] UNIQUEIDENTIFIER
	,[UserId] INT
	,[ApplicationId] INT
	,[MacAddress] NVARCHAR(50)
	,[IpAddress] NVARCHAR(50)
	,[OperatingSystem] NVARCHAR(50)
	,[SessionStart] DATETIME NOT NULL
	,[SessionEnd] DATETIME
	,CONSTRAINT [PK_Session] PRIMARY KEY([Id])
	,CONSTRAINT [FK_Session_UserId] FOREIGN KEY([UserId]) REFERENCES [Security].[User]([Id])
	,CONSTRAINT [FK_Session_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [Security].[Application]([Id])
);
GO

CREATE TABLE [Security].[UserApplication]
(
	[Id] BIGINT IDENTITY
	,[UserId] INT NOT NULL
	,[ApplicationId] INT NOT NULL
	,[IsApproved] BIT NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_UserApplication] PRIMARY KEY([Id])
	,CONSTRAINT [FK_UserApplication_UserId] FOREIGN KEY([UserId]) REFERENCES [Security].[User]([Id])
	,CONSTRAINT [FK_UserApplication_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [Security].[Application]([Id])
);

ALTER TABLE [Security].[UserApplication] ADD
	CONSTRAINT [DF_UserApplication_IsApproved] DEFAULT 0 FOR [IsApproved]
	,CONSTRAINT [DF_UserApplication_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[UserModule]
(
	[Id] BIGINT IDENTITY
	,[UserId] INT NOT NULL
	,[ModuleId] INT NOT NULL
	,[IsApproved] BIT NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_UserModule] PRIMARY KEY([Id])
	,CONSTRAINT [FK_UserModule_userId] FOREIGN KEY([UserId]) REFERENCES [Security].[User]([Id])
	,CONSTRAINT [FK_UserModule_ModuleId] FOREIGN KEY([ModuleId]) REFERENCES [Security].[Module]([Id])
);

ALTER TABLE [Security].[UserModule] ADD
	CONSTRAINT [DF_UserModule_IsApproved] DEFAULT 0 FOR [IsApproved]
	,CONSTRAINT [DF_UserModule_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO

CREATE TABLE [Security].[UserPermission]
(
	[Id] BIGINT IDENTITY
	,[UserId] INT NOT NULL
	,[PermissionId] INT NOT NULL
	,[IsApproved] BIT NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[InsertSessionId] UNIQUEIDENTIFIER
	,[InsertedOn] DATETIME
	,[UpdateSessionId] UNIQUEIDENTIFIER
	,[UpdatedOn] DATETIME
	,[DeleteSessionId] UNIQUEIDENTIFIER
	,[DeletedOn] DATETIME
	,CONSTRAINT [PK_UserPermission] PRIMARY KEY([Id])
	,CONSTRAINT [FK_UserPermission_UserId] FOREIGN KEY([UserId]) REFERENCES [Security].[User]([Id])
	,CONSTRAINT [FK_UserPermission_PermissionId] FOREIGN KEY([PermissionId]) REFERENCES [Security].[Permission]([Id])
);

ALTER TABLE [Security].[UserPermission] ADD
	CONSTRAINT [DF_UserPermission_IsApproved] DEFAULT 0 FOR [IsApproved]
	,CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO