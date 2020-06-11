USE [Sorschia_SystemBase];
GO

----------------------------------------
---------- USER-DEFINED TYPES ----------
----------------------------------------
IF TYPE_ID('dbo.IntList') IS NOT NULL
BEGIN
	IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplicationList')
		DROP PROCEDURE [Security].[GetApplicationList];

	IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplicationPlatformList')
		DROP PROCEDURE [Security].[GetApplicationPlatformList];

	IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetModuleList')
		DROP PROCEDURE [Security].[GetModuleList];

	DROP TYPE [dbo].[IntList];
END
GO

CREATE TYPE [dbo].[IntList]
AS TABLE
(
	[Value] INT
);
GO

-------------------------------
---------- FUNCTIONS ----------
-------------------------------
IF OBJECT_ID('dbo.GetSessionVariable') IS NOT NULL
	DROP FUNCTION [dbo].[GetSessionVariable];
GO

CREATE FUNCTION [dbo].[GetSessionVariable](@Key NVARCHAR(64)) RETURNS SQL_VARIANT AS
BEGIN
	RETURN SESSION_CONTEXT(@Key);
END
GO

IF OBJECT_ID('dbo.IsDeleteCascaded') IS NOT NULL
	DROP FUNCTION [dbo].[IsDeleteCascaded];
GO

CREATE FUNCTION [dbo].[IsDeleteCascaded]() RETURNS BIT AS
BEGIN
	RETURN [dbo].[NonNullableBit](CAST([dbo].[GetSessionVariable]('DeleteCascaded') AS BIT));
END
GO

IF OBJECT_ID('dbo.Trim') IS NOT NULL
	DROP FUNCTION [dbo].[Trim];
GO

CREATE FUNCTION [dbo].[Trim](@Value AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX) AS
BEGIN
	IF @Value IS NOT NULL
	BEGIN
		SET @Value = LTRIM(RTRIM(@Value));
	END

	RETURN @Value;
END
GO

IF OBJECT_ID('dbo.NonNullableBit') IS NOT NULL
	DROP FUNCTION [dbo].[NonNullableBit];
GO

CREATE FUNCTION [dbo].[NonNullableBit](@Value AS BIT) RETURNS BIT AS
BEGIN
	RETURN ISNULL(@Value, 0);
END
GO

IF OBJECT_ID('dbo.NonNullableInt') IS NOT NULL
	DROP FUNCTION [dbo].[NonNullableInt];
GO

CREATE FUNCTION [dbo].[NonNullableInt](@Value AS INT) RETURNS INT AS
BEGIN
	RETURN ISNULL(@Value, 0);
END
GO

IF OBJECT_ID('dbo.NonNullableNVarChar') IS NOT NULL
	DROP FUNCTION [dbo].[NonNullableNVarChar];
GO

CREATE FUNCTION [dbo].[NonNullableNVarChar](@Value AS NVARCHAR(MAX)) RETURNS NVARCHAR(MAX) AS
BEGIN
	RETURN ISNULL(@Value, '');
END
GO

IF OBJECT_ID('dbo.ConstructMiddleInitials') IS NOT NULL
	DROP FUNCTION [dbo].[ConstructMiddleInitials];
GO

CREATE FUNCTION [dbo].[ConstructMiddleInitials](@MiddleName NVARCHAR(100)) RETURNS NVARCHAR(10) AS
BEGIN
	DECLARE @Result AS NVARCHAR(MAX);

	SET @MiddleName = [dbo].[Trim](@MiddleName);
	SET @Result = LEFT(@MiddleName, 1);

	WHILE CHARINDEX(' ', @MiddleName, 1) > 0
	BEGIN
		SET @MiddleName = LTRIM(RIGHT(@MiddleName, LEN(@MiddleName) - CHARINDEX(' ', @MiddleName, 1)));
		SET @Result += LEFT(@MiddleName, 1);
	END

	RETURN @Result;
END
GO

IF OBJECT_ID('dbo.ConstructFullName') IS NOT NULL
	DROP FUNCTION [dbo].[ConstructFullName];
GO

CREATE FUNCTION [dbo].[ConstructFullName](
	@FirstName NVARCHAR(100)
	,@MiddleName NVARCHAR(100)
	,@LastName NVARCHAR(100)) RETURNS NVARCHAR(350) AS
BEGIN
	DECLARE @Result AS NVARCHAR(350);
	DECLARE @HasFirstName AS BIT;
	DECLARE @HasMiddleName AS BIT;
	DECLARE @HasLastName AS BIT;

	SET @FirstName = [dbo].[Trim](@FirstName);
	SET @MiddleName = [dbo].[Trim](@MiddleName);
	SET @LastName = [dbo].[Trim](@LastName);

	SET @HasFirstName = CASE WHEN LEN(@FirstName) > 0 THEN 1 ELSE 0 END;
	SET @HasMiddleName = CASE WHEN LEN(@MiddleName) > 0 THEN 1 ELSE 0 END;
	SET @HasLastName = CASE WHEN LEN(@LastName) > 0 THEN 1 ELSE 0 END;

	SET @Result = '';

	IF @HasLastName = 1
	BEGIN
		SET @Result = @LastName;

		IF @HasFirstName = 1 OR @HasMiddleName = 1
		BEGIN
			SET @Result = CONCAT(@Result, ', ');
		END
	END

	IF @HasFirstName = 1
	BEGIN
		SET @Result = CONCAT(@Result, @FirstName);

		IF @HasMiddleName = 1
		BEGIN
			SET @Result = CONCAT(@Result, ' ');
		END
	END

	IF @HasMiddleName = 1
	BEGIN
		SET @Result = CONCAT(@Result, @MiddleName);
	END	

	RETURN @Result;
END
GO

IF OBJECT_ID('dbo.ConstructInformalFullName') IS NOT NULL
	DROP FUNCTION [dbo].[ConstructInformalFullName];
GO

CREATE FUNCTION [dbo].[ConstructInformalFullName](
	@FirstName NVARCHAR(100)
	,@MiddleInitials NVARCHAR(10)
	,@LastName NVARCHAR(100)) RETURNS NVARCHAR(350) AS
BEGIN
	DECLARE @Result AS NVARCHAR(350);
	DECLARE @HasFirstName AS BIT;
	DECLARE @HasMiddleInitials AS BIT;
	DECLARE @HasLastName AS BIT;
	DECLARE @HasNameExtension AS BIT;

	SET @FirstName = [dbo].[Trim](@FirstName);
	SET @MiddleInitials = [dbo].[Trim](@MiddleInitials);
	SET @LastName = [dbo].[Trim](@LastName);

	SET @HasFirstName = CASE WHEN LEN(@FirstName) > 0 THEN 1 ELSE 0 END;
	SET @HasMiddleInitials = CASE WHEN LEN(@MiddleInitials) > 0 THEN 1 ELSE 0 END;
	SET @HasLastName = CASE WHEN LEN(@LastName) > 0 THEN 1 ELSE 0 END;

	SET @Result = '';

	IF @HasFirstName = 1
	BEGIN
		SET @Result = @FirstName;

		IF @HasMiddleInitials = 1 OR @HasLastName = 1 OR @HasNameExtension = 1
		BEGIN
			SET @Result = CONCAT(@Result, ' ');
		END
	END

	IF @HasMiddleInitials = 1
	BEGIN
		SET @Result = CONCAT(@Result, @MiddleInitials);

		IF @HasLastName = 1 OR @HasNameExtension = 1
		BEGIN
			SET @Result = CONCAT(@Result, ' ');
		END
	END

	IF @HasLastName = 1
	BEGIN
		SET @Result = CONCAT(@Result, @LastName);
	END

	RETURN @Result;
END
GO

IF OBJECT_ID('Security.GetSessionId') IS NOT NULL
	DROP FUNCTION [Security].[GetSessionId];
GO

CREATE FUNCTION [Security].[GetSessionId]() RETURNS UNIQUEIDENTIFIER AS
BEGIN
	RETURN CAST([dbo].[GetSessionVariable]('Security:SessionId') AS UNIQUEIDENTIFIER);
END
GO

IF OBJECT_ID('Security.ConstructSessionPermissionGrantedKey') IS NOT NULL
	DROP FUNCTION [Security].[ConstructSessionPermissionGrantedKey];
GO

CREATE FUNCTION [Security].[ConstructSessionPermissionGrantedKey](@PermissionCode NVARCHAR(100)) RETURNS NVARCHAR(150) AS
BEGIN
	RETURN CONCAT('Security:PermissionGranted:', @PermissionCode);
END
GO

IF OBJECT_ID('Security.IsPermissionGranted') IS NOT NULL
	DROP FUNCTION [Security].[IsPermissionGranted];
GO

CREATE FUNCTION [Security].[IsPermissionGranted](@PermissionCode NVARCHAR(100)) RETURNS BIT AS
BEGIN
	SET @PermissionCode = [dbo].[Trim](@PermissionCode);

	IF @PermissionCode IS NOT NULL AND LEN(@PermissionCode) > 0
	BEGIN
		RETURN [dbo].[NonNullableBit](CAST([dbo].[GetSessionVariable]([Security].[ConstructSessionPermissionGrantedKey](@PermissionCode)) AS BIT));
	END
		
	RETURN 0;
END
GO

---------------------------------------
---------- STORED PROCEDURES ----------
---------------------------------------
IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'SetSessionVariable')
	DROP PROCEDURE [dbo].[SetSessionVariable];
GO

CREATE PROCEDURE [dbo].[SetSessionVariable](@Key NVARCHAR(64), @Value SQL_VARIANT, @IsReadOnly BIT = 0) AS
BEGIN
	EXEC SYS.SP_SET_SESSION_CONTEXT @Key, @Value, @IsReadonly;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'dbo' AND [SPECIFIC_NAME] = 'EnableDeleteCascade')
	DROP PROCEDURE [dbo].[EnableDeleteCascade];
GO

CREATE PROCEDURE [dbo].[EnableDeleteCascade](@IsCascaded BIT) AS
BEGIN
	SET @IsCascaded = [dbo].[NonNullableBit](@IsCascaded);

	EXEC [dbo].[SetSessionVariable] 'DeleteCascaded', @IsCascaded; 
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'SetSessionId')
	DROP PROCEDURE [Security].[SetSessionId];
GO

CREATE PROCEDURE [Security].[SetSessionId](@SessionId UNIQUEIDENTIFIER) AS
BEGIN
	EXEC [dbo].[SetSessionVariable] 'Security:SessionId', @SessionId, 1;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GrantPermission')
	DROP PROCEDURE [Security].[GrantPermission];
GO

CREATE PROCEDURE [Security].[GrantPermission](
	@PermissionCode NVARCHAR(100)
	,@SessionId UNIQUEIDENTIFIER = NULL
	,@Granted BIT = NULL) AS
BEGIN
	DECLARE @SessionVariableKey AS NVARCHAR(150);

	SET @PermissionCode = [dbo].[Trim](@PermissionCode);

	IF @PermissionCode IS NULL OR LEN(@PermissionCode) <= 0
	BEGIN
		RAISERROR('Invalid permission code', 18, -1);
		RETURN;
	END

	IF @SessionId IS NULL
	BEGIN
		SET @SessionId = [Security].[GetSessionId]();
	END

	IF @Granted IS NULL
	BEGIN
		SET @Granted = CASE WHEN EXISTS (
			SELECT 0
			FROM [Security].[Permission]
			INNER JOIN [Security].[UserPermission] ON [Permission].[Id] = [UserPermission].[PermissionId]
			INNER JOIN [Security].[User] ON [UserPermission].[UserId] = [User].[Id]
			INNER JOIN [Security].[Session] ON [User].[Id] = [Session].[UserId]
			WHERE
				[Permission].[IsDeleted] = 0
				AND [Permission].[Code] = @PermissionCode
				AND [UserPermission].[IsDeleted] = 0
				AND [UserPermission].[IsApproved] = 1
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

	SET @SessionVariableKey = [Security].[ConstructSessionPermissionGrantedKey](@PermissionCode);

	EXEC [dbo].[SetSessionVariable] @SessionVariableKey, @Granted;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteApplication')
	DROP PROCEDURE [Security].[DeleteApplication];
GO

CREATE PROCEDURE [Security].[DeleteApplication] (
	@Id INT
	,@IsCascaded BIT
	,@SessionId UNIQUEIDENTIFIER) AS
BEGIN
	DECLARE @DELETE_APPLICATION AS NVARCHAR(100) = 'security.delete-application';
	
	SET NOCOUNT ON;
	EXEC [dbo].[EnableDeleteCascade] @IsCascaded;
	EXEC [Security].[SetSessionId] @SessionId;
	EXEC [Security].[GrantPermission] @DELETE_APPLICATION;

	IF [Security].IsPermissionGranted(@DELETE_APPLICATION) = 0
	BEGIN
		RAISERROR('Permission denied: Delete Application', 18, -1);
		RETURN;
	END
	SET NOCOUNT OFF;

	UPDATE [Security].[Application] SET
		[IsDeleted] = 1
		,[DeleteSessionId] = @SessionId
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteApplicationPlatform')
	DROP PROCEDURE [Security].[DeleteApplicationPlatform];
GO

CREATE PROCEDURE [Security].[DeleteApplicationPlatform] (
	@Id INT
	,@IsCascaded BIT
	,@SessionId UNIQUEIDENTIFIER) AS
BEGIN
	DECLARE @DELETE_APPLICATION_PLATFORM AS NVARCHAR(100) = 'security.delete-application-platform';
	
	SET NOCOUNT ON;
	EXEC [dbo].[EnableDeleteCascade] @Iscascaded;
	EXEC [Security].[SetSessionId] @SessionId;
	EXEC [Security].[GrantPermission] @DELETE_APPLICATION_PLATFORM;

	IF [Security].[IsPermissionGranted](@DELETE_APPLICATION_PLATFORM) = 0
	BEGIN
		RAISERROR('Permission denied: Delete Application Platform', 18, -1);
		RETURN;
	END
	SET NOCOUNT OFF;

	UPDATE [Security].[ApplicationPlatform] SET
		[IsDeleted] = 1
		,[DeleteSessionId] = @SessionId
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteModule')
	DROP PROCEDURE [Security].[DeleteModule];
GO

CREATE PROCEDURE [Security].[DeleteModule]
(
	@Id INT
	,@SessionId UNIQUEIDENTIFIER
) AS
BEGIN
	DECLARE @DELETE_MODULE AS NVARCHAR(100) = 'security.delete-module';

	SET NOCOUNT ON;
	EXEC [Security].[SetSessionId] @SessionId;
	EXEC [Security].[GrantPermission] @DELETE_MODULE;

	IF [Security].[IsPermissionGranted](@DELETE_MODULE) = 0
	BEGIN
		RAISERROR('Permission denied: Delete Module', 18, -1);
		RETURN;
	END
	SET NOCOUNT OFF;

	UPDATE [Security].[Module] SET
		[IsDeleted] = 1
		,[DeleteSessionId] = @SessionId
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeletePermission')
	DROP PROCEDURE [Security].[DeletePermission];
GO

CREATE PROCEDURE [Security].[DeletePermission] (
	@Id INT
	,@SessionId UNIQUEIDENTIFIER) AS
BEGIN
	DECLARE @DELETE_PERMISSION AS NVARCHAR(100) = 'security.delete-permission';

	SET NOCOUNT ON;
	EXEC [Security].[SetSessionId] @SessionId;
	EXEC [Security].[GrantPermission] @DELETE_PERMISSION;

	IF [Security].[IsPermissionGranted](@DELETE_PERMISSION) = 0
	BEGIN
		RAISERROR('Permission denied: Delete Permission', 18, -1);
		RETURN;
	END
	SET NOCOUNT OFF;

	UPDATE [Security].[Permission] SET
		[IsDeleted] = 1
		,[DeleteSessionId] = @SessionId
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteUser')
	DROP PROCEDURE [Security].[DeleteUser];
GO

CREATE PROCEDURE [Security].[DeleteUser] (
	@Id INT
	,@SessionId UNIQUEIDENTIFIER) AS
BEGIN
	DECLARE @DELETE_USER AS NVARCHAR(100) = 'security.delete-user';

	SET NOCOUNT ON;
	EXEC [Security].[SetSessionId] @SessionId;
	EXEC [Security].[GrantPermission] @DELETE_USER;

	IF [Security].[IsPermissionGranted](@DELETE_USER) = 0
	BEGIN
		RAISERROR('Permission denied: Delete User', 18, -1);
		RETURN;
	END
	SET NOCOUNT OFF;

	UPDATE [Security].[User] SET
		[IsDeleted] = 1
		,[DeleteSessionId] = @SessionId
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplication')
	DROP PROCEDURE [Security].[GetApplication];
GO

CREATE PROCEDURE [Security].[GetApplication](@Id INT) AS
BEGIN
	SELECT
		[Id]
		,[Name]
		,[PlatformId]
	FROM [Security].[Application]
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplicationList')
	DROP PROCEDURE [Security].[GetApplicationList];
GO

CREATE PROCEDURE [Security].[GetApplicationList] (
	@Skip INT
	,@Take INT
	,@FilterText NVARCHAR(100)
	,@FilterByPlatform BIT
	,@PlatformIdList [dbo].[IntList] READONLY
	,@SkippedIdList [dbo].[IntList] READONLY) AS
BEGIN
	DECLARE @Query AS NVARCHAR(MAX);
	DECLARE @CountQuery AS NVARCHAR(MAX);
	DECLARE @AppendQuery AS NVARCHAR(MAX);

	SET @Skip = [dbo].[NonNullableInt](@Skip);
	SET @Take = [dbo].[NonNullableInt](@Take);
	SET @FilterText = [dbo].[NonNullableNVarChar]([dbo].[Trim](@FilterText));
	SET @FilterByPlatform = [dbo].[NonNullableBit](@FilterByPlatform);

	SET @Query = 'SELECT DISTINCT [Id], [Name], [PlatformId]'
	SET @CountQuery = 'SELECT COUNT(DISTINCT [Id]) AS [TotalCount]';

	SET @AppendQuery = ' FROM [Security].[Application] WHERE [IsDeleted] = 0';
	SET @Query = CONCAT(@Query, @AppendQuery);
	SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);

	IF LEN(@FilterText) > 0
	BEGIN
		SET @AppendQuery = ' AND [Name] LIKE CONCAT(''%'', @FilterText, ''%'')';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	IF @FilterByPlatform = 1 AND EXISTS(SELECT 0 FROM @PlatformIdList)
	BEGIN
		SET @AppendQuery = ' AND [PlatformId] IN (SELECT [Value] IN @PlatformIdList)';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	IF EXISTS(SELECT 0 FROM @SkippedIdList)
	BEGIN
		SET @AppendQuery = ' AND [Id] NOT IN (SELECT [Value] IN @SkippedIdList)';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	SET @Query = CONCAT(@Query, ' ORDER BY [Name] ASC');

	IF @Take > 0
		SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');

	EXEC SP_EXECUTESQL @Query
		,N'@Skip INT
			,@Take INT
			,@FilterText NVARCHAR(100)
			,@PlatformIdList [dbo].[IntList] READONLY
			,@SkippedIdLIst [dbo].[IntList] READONLY'
		,@Skip = @Skip
		,@Take = @Take
		,@FilterText = @FilterText
		,@PlatformIdList = @PlatformIdList
		,@SkippedIdList = @SkippedIdList;

	EXEC SP_EXECUTESQL @CountQuery
		,N'@FilterText NVARCHAR(100)
			,@PlatformIdList [dbo].[IntList] READONLY
			,@SkippedIdList [dbo].[IntList] READONLY'
		,@FilterText = @FilterText
		,@PlatformIdList = @PlatformIdList
		,@SkippedIdList = @SkippedIdList;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplicationPlatform')
	DROP PROCEDURE [Security].[GetApplicationPlatform];
GO

CREATE PROCEDURE [Security].[GetApplicationPlatform](@Id INT) AS
BEGIN
	SELECT
		[Id]
		,[Name]
	FROM [Security].[ApplicationPlatform]
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetApplicationPlatformList')
	DROP PROCEDURE [Security].[GetApplicationPlatformList];
GO

CREATE PROCEDURE [Security].[GetApplicationPlatformList] (
	@Skip INT
	,@Take INT
	,@FilterText NVARCHAR(100)
	,@SkippedIdList [dbo].[IntList] READONLY) AS
BEGIN
	DECLARE @Query AS NVARCHAR(MAX);
	DECLARE @CountQuery AS NVARCHAR(MAX);
	DECLARE @AppendQuery AS NVARCHAR(MAX);

	SET @Skip = [dbo].[NonNullableInt](@Skip);
	SET @Take = [dbo].[NonNullableInt](@Take);
	SET @FilterText = [dbo].[NonNullableNVarChar]([dbo].[Trim](@FilterText));

	SET @Query = 'SELECT DISTINCT [Id], [Name]'
	SET @CountQuery = 'SELECT COUNT(DISTINCT [Id]) AS [TotalCount]';

	SET @AppendQuery = ' FROM [Security].[ApplicationPlatform] WHERE [IsDeleted] = 0';
	SET @Query = CONCAT(@Query, @AppendQuery);
	SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);

	IF LEN(@FilterText) > 0
	BEGIN
		SET @AppendQuery = ' AND [Name] LIKE CONCAT(''%'', @FilterText, ''%'')';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	IF EXISTS(SELECT 0 FROM @SkippedIdList)
	BEGIN
		SET @AppendQuery = ' AND [Id] NOT IN (SELECT [Value] IN @SkippedIdList)';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	SET @Query = CONCAT(@Query, ' ORDER BY [Name] ASC');

	IF @Take > 0
		SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');

	EXEC SP_EXECUTESQL @Query
		,N'@Skip INT
			,@Take INT
			,@FilterText NVARCHAR(100)
			,@SkippedIdLIst [dbo].[IntList] READONLY'
		,@Skip = @Skip
		,@Take = @Take
		,@FilterText = @FilterText
		,@SkippedIdList = @SkippedIdList;

	EXEC SP_EXECUTESQL @CountQuery
		,N'@FilterText NVARCHAR(100)
			,@SkippedIdList [dbo].[IntList] READONLY'
		,@FilterText = @FilterText
		,@SkippedIdList = @SkippedIdList;
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'GetModule')
	DROP PROCEDURE [Security].[GetModule];
GO

CREATE PROCEDURE [Security].[GetModule](@Id INT) AS
BEGIN
	SELECT
		[Id]
		,[Name]
		,[OrdinalNumber]
		,[ApplicationId]
	FROM [Security].[Module]
	WHERE [Id] = @Id AND [IsDeleted] = 0;
END
GO

CREATE PROCEDURE [Security].[GetModuleList] (
	@Skip INT
	,@Take INT
	,@FilterText NVARCHAR(100)
	,@FilterByApplication BIT
	,@ApplicationIdList [dbo].[IntList] READONLY
	,@SkippedIdList [dbo].[IntList] READONLY) AS
BEGIN
	DECLARE @Query AS NVARCHAR(MAX);
	DECLARE @CountQuery AS NVARCHAR(MAX);
	DECLARE @AppendQuery AS NVARCHAR(MAX);

	SET @Skip = [dbo].[NonNullableInt](@Skip);
	SET @Take = [dbo].[NonNullableInt](@Take);
	SET @FilterText = [dbo].[NonNullableNVarChar]([dbo].[Trim](@FilterText));
	SET @FilterByApplication = [dbo].[NonNullableBit](@FilterByApplication);

	SET @Query = 'SELECT DISTINCT [Id], [Name], [OrdinalNumber], [ApplicationId]'
	SET @CountQuery = 'SELECT COUNT(DISTINCT [Id]) AS [TotalCount]';

	SET @AppendQuery = ' FROM [Security].[Module] WHERE [IsDeleted] = 0';
	SET @Query = CONCAT(@Query, @AppendQuery);
	SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);

	IF LEN(@FilterText) > 0
	BEGIN
		SET @AppendQuery = ' AND [Name] LIKE CONCAT(''%'', @FilterText, ''%'')';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	IF @FilterByApplication = 1 AND EXISTS(SELECT 0 FROM @ApplicationIdList)
	BEGIN
		SET @AppendQuery = ' AND [ApplicationId] IN (SELECT [Value] IN @ApplicationIdList)';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	IF EXISTS(SELECT 0 FROM @SkippedIdList)
	BEGIN
		SET @AppendQuery = ' AND [Id] NOT IN (SELECT [Value] IN @SkippedIdList)';
		SET @Query = CONCAT(@Query, @AppendQuery);
		SET @CountQuery = CONCAT(@CountQuery, @AppendQuery);
	END

	SET @Query = CONCAT(@Query, ' ORDER BY [OrdinalNumbeer] ASC, [Name] ASC');

	IF @Take > 0
		SET @Query = CONCAT(@Query, ' OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY');

	EXEC SP_EXECUTESQL @Query
		,N'@Skip INT
			,@Take INT
			,@FilterText NVARCHAR(100)
			,@ApplicationIdList [dbo].[IntList] READONLY
			,@SkippedIdLIst [dbo].[IntList] READONLY'
		,@Skip = @Skip
		,@Take = @Take
		,@FilterText = @FilterText
		,@ApplicationIdList = @ApplicationidList
		,@SkippedIdList = @SkippedIdList;

	EXEC SP_EXECUTESQL @CountQuery
		,N'@FilterText NVARCHAR(100)
			,@ApplicationIdList [dbo].[IntList] READONLY
			,@SkippedIdList [dbo].[IntList] READONLY'
		,@FilterText = @FilterText
		,@ApplicationIdList = @ApplicationidList
		,@SkippedIdList = @SkippedIdList;
END
GO

------------------------------
---------- TRIGGERS ----------
------------------------------
IF OBJECT_ID('Security.TR_Application_AfterUpdate', 'TR') IS NOT NULL
	DROP TRIGGER [Security].[TR_Application_AfterUpdate];
GO

CREATE TRIGGER [Security].[TR_Application_AfterUpdate] ON [Security].[Application] AFTER UPDATE AS
BEGIN
	DECLARE @DELETE_MODULE AS NVARCHAR(100) = 'security.delete-module';
	DECLARE @DELETE_USER_APPLICATION AS NVARCHAR(100) = 'security.delete-user-application';

	SET NOCOUNT ON;
	IF EXISTS(SELECT 0 FROM INSERTED INNER JOIN DELETED ON INSERTED.[Id] = DELETED.[Id] WHERE INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0)
	BEGIN
		IF [Security].[IsPermissionGranted](@DELETE_USER_APPLICATION) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Application', 18, -1);
			RETURN;
		END

		UPDATE [UserApplication] SET
			[UserApplication].[IsDeleted] = 1
			,[UserApplication].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserApplication].[DeletedOn] = GETDATE()
		FROM [Security].[UserApplication]
		INNER JOIN INSERTED ON [UserApplication].[ApplicationId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserApplication].[ApplicationId] = DELETED.[Id]
		WHERE [UserApplication].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;

		IF [dbo].[IsDeleteCascaded]() = 1
		BEGIN
			IF [Security].[IsPermissionGranted](@DELETE_MODULE) = 0
			BEGIN
				RAISERROR('Permission denied: Delete Module', 18, -1);
				RETURN;
			END

			UPDATE [Module] SET
				[Module].[IsDeleted] = 1
				,[Module].[DeleteSessionId] = [Security].[GetSessionId]()
				,[Module].[DeletedOn] = GETDATE()
			FROM [Security].[Module]
			INNER JOIN INSERTED ON [Module].[ApplicationId] = INSERTED.[Id]
			INNER JOIN DELETED ON [Module].[ApplicationId] = DELETED.[Id]
			WHERE [Module].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;
		END
	END
	SET NOCOUNT OFF;
END
GO

IF OBJECT_ID('Security.TR_ApplicationPlatform_AfterUpdate', 'TR') IS NOT NULL
	DROP TRIGGER [Security].[TR_ApplicationPlatform_AfterUpdate];
GO

CREATE TRIGGER [Security].[TR_ApplicationPlatform_AfterUpdate] ON [Security].[ApplicationPlatform] AFTER UPDATE AS
BEGIN
	DECLARE @DELETE_APPLICATION AS NVARCHAR(100) = 'security.delete-application';

	SET NOCOUNT ON;
	IF EXISTS(SELECT 0 FROM INSERTED INNER JOIN DELETED ON INSERTED.[Id] = DELETED.[Id] WHERE INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0)
	BEGIN
		IF [dbo].[IsDeleteCascaded]() = 1
		BEGIN
			IF [Security].[IsPermissionGranted](@DELETE_APPLICATION) = 0
			BEGIN
				RAISERROR('Permission denied: Delete Application', 18, -1);
				RETURN;
			END

			UPDATE [Application] SET
				[Application].[IsDeleted] = 1
				,[Application].[DeleteSessionId] = [Security].[GetSessionId]()
				,[Application].[DeletedOn] = GETDATE()
			FROM [Security].[Application]
			INNER JOIN INSERTED ON [Application].[PlatformId] = INSERTED.[Id]
			INNER JOIN DELETED ON [Application].[PlatformId] = DELETED.[Id]
			WHERE [Application].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;
		END
	END
	SET NOCOUNT OFF;
END
GO

IF OBJECT_ID('Security.TR_Module_AfterUpdate', 'TR') IS NOT NULL
	DROP TRIGGER [Security].[TR_Module_AfterUpdate];
GO

CREATE TRIGGER [Security].[TR_Module_AfterUpdate] ON [Security].[Module] AFTER UPDATE AS
BEGIN
	DECLARE @DELETE_USER_MODULE AS NVARCHAR(100) = 'security.delete-user-module';

	SET NOCOUNT ON;
	IF EXISTS(SELECT 0 FROM INSERTED INNER JOIN DELETED ON INSERTED.[Id] = DELETED.[Id] WHERE INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0)
	BEGIN
		IF [Security].IsPermissionGranted(@DELETE_USER_MODULE) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Module', 18, -1);
			RETURN;
		END
	
		UPDATE [UserModule] SET
			[UserModule].[IsDeleted] = 1
			,[UserModule].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserModule].[DeletedOn] = GETDATE()
		FROM [Security].[UserModule]
		INNER JOIN INSERTED ON [UserModule].[ModuleId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserModule].[ModuleId] = DELETED.[Id]
		WHERE [UserModule].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;
	END
	SET NOCOUNT OFF;
END
GO

IF OBJECT_ID('Security.TR_Permission_AfterUpdate', 'TR') IS NOT NULL
	DROP TRIGGER [Security].[TR_Permission_AfterUpdate];
GO

CREATE TRIGGER [Security].[TR_Permission_AfterUpdate] ON [Security].[Permission] AFTER UPDATE AS
BEGIN
	DECLARE @DELETE_USER_PERMISSION AS NVARCHAR(100) = 'security.delete-user-permission';

	SET NOCOUNT ON;
	IF EXISTS(SELECT 0 FROM INSERTED INNER JOIN DELETED ON INSERTED.[Id] = DELETED.[Id] WHERE INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0)
	BEGIN
		IF [Security].[IsPermissionGranted](@DELETE_USER_PERMISSION) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Permission', 18, -1);
			RETURN;
		END

		UPDATE [UserPermission] SET
			[UserPermission].[IsDeleted] = 1
			,[UserPermission].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserPermission].[DeletedOn] = GETDATE()
		FROM [Security].[UserPermission]
		INNER JOIN INSERTED ON [UserPermission].[PermissionId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserPermission].[PermissionId] = DELETED.[Id]
		WHERE [UserPermission].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;
	END
	SET NOCOUNT OFF;
END
GO

IF OBJECT_ID('Security.TR_User_AfterUpdate', 'TR') IS NOT NULL
	DROP TRIGGER [Security].[TR_User_AfterUpdate];
GO

CREATE TRIGGER [Security].[TR_User_AfterUpdate] ON [Security].[User] AFTER UPDATE AS
BEGIN
	DECLARE @DELETE_USER_APPLICATION AS NVARCHAR(100) = 'security.delete-user-application';
	DECLARE @DELETE_USER_MODULE AS NVARCHAR(100) = 'security.delete-user-module';
	DECLARE @DELETE_USER_PERMISSION AS NVARCHAR(100) = 'security.delete-user-permission';

	SET NOCOUNT ON;
	IF EXISTS(SELECT 0 FROM INSERTED INNER JOIN DELETED ON INSERTED.[Id] = DELETED.[Id] WHERE INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0)
	BEGIN
		IF [Security].[IsPermissionGranted](@DELETE_USER_APPLICATION) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Application', 18, -1);
			RETURN;
		END

		IF [Security].[IsPermissionGranted](@DELETE_USER_MODULE) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Module', 18, -1);
			RETURN;
		END

		IF [Security].[IsPermissionGranted](@DELETE_USER_PERMISSION) = 0
		BEGIN
			RAISERROR('Permission denied: Delete User Permission', 18, -1);
			RETURN;
		END
		
		UPDATE [UserApplication] SET
			[UserApplication].[IsDeleted] = 1
			,[UserApplication].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserApplication].[DeletedOn] = GETDATE()
		FROM [Security].[UserApplication]
		INNER JOIN INSERTED ON [UserApplication].[ApplicationId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserApplication].[ApplicationId] = DELETED.[Id]
		WHERE [UserApplication].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;

		UPDATE [UserModule] SET
			[UserModule].[IsDeleted] = 1
			,[UserModule].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserModule].[DeletedOn] = GETDATE()
		FROM [Security].[UserModule]
		INNER JOIN INSERTED ON [UserModule].[ModuleId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserModule].[ModuleId] = DELETED.[Id]
		WHERE [UserModule].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;

		UPDATE [UserPermission] SET
			[UserPermission].[IsDeleted] = 1
			,[UserPermission].[DeleteSessionId] = [Security].[GetSessionId]()
			,[UserPermission].[DeletedOn] = GETDATE()
		FROM [Security].[UserPermission]
		INNER JOIN INSERTED ON [UserPermission].[PermissionId] = INSERTED.[Id]
		INNER JOIN DELETED ON [UserPermission].[PermissionId] = DELETED.[Id]
		WHERE [UserPermission].[IsDeleted] = 0 AND INSERTED.[IsDeleted] = 1 AND DELETED.[IsDeleted] = 0;

	END
	SET NOCOUNT OFF;
END
GO