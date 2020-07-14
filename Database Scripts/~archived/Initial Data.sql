USE [Sorschia_SystemBase];
GO

INSERT INTO [Security].[Permission]([Name], [Code]) VALUES
	('Delete Application', 'security.delete-application')
	,('Delete Application Platform', 'security.delete-application-platform')
	,('Delete Module', 'security.delete-module')
	,('Delete Permission', 'security.delete-permission')
	,('Delete User', 'security.delete-user')
	,('Delete User Application', 'security.delete-user-application')
	,('Delete User Module', 'security.delete-user-module')
	,('Delete User Permission', 'security.delete-user-permission');
GO

INSERT INTO [Security].[ApplicationPlatform]([Name]) VALUES
	('Windows PC')
	,('Web');
GO

INSERT INTO [Security].[Application]([Name], [PlatformId]) VALUES
	('Sorschia Security Management for Windows', 1)
	,('Sorschia Security Management for Web', 2);
GO