CREATE OR ALTER PROCEDURE [dbo].[GetUser]
(
    @Id INT,
    @IncludeUserApplications BIT,
    @UserApplication_SkippedCount BIGINT,
    @UserApplication_TakenCount INT,
    @UserApplication_SkippedApplicationIds [dbo].[SmallIntType] READONLY,
    @UserApplication_IncludeApplication BIT,
    @IncludeUserPermissions BIT,
    @UserRole_SkippedCount BIGINT,
    @UserRole_TakenCount INT,
    @UserRole_SkippedRoleIds [dbo].[IntType] READONLY,
    @UserRole_IncludeRole BIT,
    @IncludeUserRoles BIT,
    @UserPermission_SkippedCount BIGINT,
    @UserPermission_TakenCount INT,
    @UserPermission_SkippedPermissionIds [dbo].[IntType] READONLY,
    @UserPermission_IncludePermission BIT
) AS
BEGIN
    IF ISNULL(@Id, 0) = 0
    BEGIN
        RAISERROR('Id is invalid', 18, -1);
        RETURN;
    END

    SET @IncludeUserApplications = ISNULL(@IncludeUserApplications, 0);
    SET @IncludeUserRoles = ISNULL(@IncludeUserRoles, 0);
    SET @IncludeUserPermissions = ISNULL(@IncludeUserPermissions, 0);

    -- Get User
    SELECT
        [User].[Id] AS [Id],
        [User].[FirstName] AS [FirstName],
        [User].[MiddleName] AS [MiddleName],
        [User].[LastName] AS [LastName],
        [User].[NameSuffix] AS [NameSuffix],
        [User].[FullName] AS [FullName],
        [User].[Username] AS [Username],
        [User].[EmailAddress] AS [EmailAddress],
        [User].[MobileNumber] AS [MobileNumber],
        [User].[IsActive] AS [IsActive],
        [User].[IsPasswordChangeRequired] AS [IsPasswordChangeRequired],
        [User].[IsEmailAddressVerified] AS [IsEmailAddressVerified],
        [User].[IsMobileNumberVerified] AS [IsMobileNumberVerified]
    FROM [dbo].[User]
    WHERE [Id] = @Id AND [IsDeleted] = 0;

    -- User-Application
    IF @IncludeUserApplications = 1
    BEGIN
        DECLARE @UserApplication_Query AS NVARCHAR(MAX);
        DECLARE @UserApplication_TotalCountQuery AS NVARCHAR(MAX);
        DECLARE @UserApplication_Selection AS NVARCHAR(MAX);
        DECLARE @UserApplication_TotalCountSelection AS NVARCHAR(MAX);
        DECLARE @UserApplication_Origin AS NVARCHAR(MAX);
        DECLARE @UserApplication_Condition AS NVARCHAR(MAX);
        DECLARE @UserApplication_Parameters AS NVARCHAR(MAX);
        DECLARE @UserApplication_TotalCountParameters AS NVARCHAR(MAX);
        DECLARE @UserApplication_HasSkippedApplicationIds AS BIT;
        
        SET @UserApplication_IncludeApplication = ISNULL(@UserApplication_IncludeApplication, 0);
        SET @UserApplication_SkippedCount = ISNULL(@UserApplication_SkippedCount, 0);
        SET @UserApplication_TakenCount = ISNULL(@UserApplication_TakenCount, 0);
        SET @UserApplication_HasSkippedApplicationIds = CASE WHEN EXISTS(SELECT -1 FROM @UserApplication_SkippedApplicationIds) THEN 1 ELSE 0 END;

        SET @UserApplication_Selection = CONCAT('SELECT',
            CASE WHEN @UserApplication_SkippedCount = 0 AND @UserApplication_TakenCount > 0 THEN ' TOP (@TakenCount)' END,
            '
                [UserApplication].[Id] AS [Id],
                [UserApplication].[ApplicationId] AS [ApplicationId]
            ');
        SET @UserApplication_TotalCountSelection = 'SELECT COUNT_BIG([UserApplication].[Id]) AS [TotalCount]';
        SET @UserApplication_Origin = ' FROM [dbo].[UserApplication]';
        SET @UserApplication_Condition = ' WHERE [UserApplication].[IsDeleted] = 0 AND [UserApplication].[UserId] = @UserId';
        SET @UserApplication_Parameters = '
            @UserId INT,
            @SkippedCount BIGINT,
            @TakenCount BIGINT,
            @SkippedApplicationIds [dbo].[SmallIntType] READONLY
        ';
        SET @UserApplication_TotalCountParameters = '
            @UserId INT,
            @SkippedApplicationIds [dbo].[SmallIntType] READONLY
        ';

        IF @UserApplication_IncludeApplication = 1
        BEGIN
            SET @UserApplication_Selection = CONCAT(@UserApplication_Selection, ',
                [Application].[Id] AS [Id],
                [Application].[Name] AS [ ame],
                [Application].[Description] AS [Description]
            ');
            SET @UserApplication_Origin = CONCAT(@UserApplication_Origin, ' LEFT JOIN [dbo].[Application] ON [UserApplication].[ApplicationId] = [Application].[Id]');
            SET @UserApplication_Condition = CONCAT(@UserApplication_Condition, ' AND [Application].[IsDeleted] = 0');
        END
        ELSE
        BEGIN
            SET @UserApplication_Selection = CONCAT(@UserApplication_Selection, ',
                NULL AS [Id],
                NULL AS [Name],
                NULL AS [Description]
            ');
        END

        IF @UserApplication_HasSkippedApplicationIds = 1
        BEGIN
            SET @UserApplication_Condition = CONCAT(@UserApplication_Condition, ' AND [UserApplication].[ApplicationId] NOT IN (SELECT [Value] FROM @SkippedApplicationIds)');
        END

        SET @UserApplication_Query = CONCAT(
            @UserApplication_Selection,
            @UserApplication_Origin,
            @UserApplication_Condition,
            ' ORDER BY',
            CASE WHEN @UserApplication_IncludeApplication = 1 THEN ' [Application].[Name] ASC' ELSE ' [UserApplication].[ApplicationId] ASC' END,
            CASE WHEN @UserApplication_SkippedCount > 0 THEN ' OFFSET @SkippedCount ROWS' END,
            CASE WHEN @UserApplication_SkippedCount > 0 AND @UserApplication_TakenCount > 0 THEN ' FETCH NEXT @TakenCount ROWS ONLY' END
        );
        SET @UserApplication_TotalCountQuery = CONCAT(
            @UserApplication_TotalCountSelection,
            @UserApplication_Origin,
            @UserApplication_Condition
        );

        EXEC SP_EXECUTESQL @UserApplication_Query, @UserApplication_Parameters,
            @UserId = @Id,
            @SkippedCount = @UserApplication_SkippedCount,
            @TakenCount = @UserApplication_TakenCount,
            @SkippedApplicationIds = @UserApplication_SkippedApplicationIds;

        EXEC SP_EXECUTESQL @UserApplication_TotalCountQuery, @UserApplication_TotalCountParameters,
            @UserId = @Id,
            @SkippedApplicationIds = @UserApplication_SkippedApplicationIds;
    END -- END: User-Application
    
    -- User-Role
    IF @IncludeUserRoles = 1
    BEGIN
        DECLARE @UserRole_Query AS NVARCHAR(MAX);
        DECLARE @UserRole_TotalCountQuery AS NVARCHAR(MAX);
        DECLARE @UserRole_Selection AS NVARCHAR(MAX);
        DECLARE @UserRole_TotalCountSelection AS NVARCHAR(MAX);
        DECLARE @UserRole_Origin AS NVARCHAR(MAX);
        DECLARE @UserRole_Condition AS NVARCHAR(MAX);
        DECLARE @UserRole_Parameters AS NVARCHAR(MAX);
        DECLARE @UserRole_TotalCountParameters AS NVARCHAR(MAX);
        DECLARE @UserRole_HasSkippedRoleIds AS BIT;

        SET @UserRole_IncludeRole = ISNULL(@UserRole_IncludeRole, 0);
        SET @UserRole_SkippedCount = ISNULL(@UserRole_SkippedCount, 0);
        SET @UserRole_TakenCount = ISNULL(@UserRole_TakenCount, 0);
        SET @UserRole_HasSkippedRoleIds = CASE WHEN EXISTS(SELECT -1 FROM @UserRole_SkippedRoleIds) THEN 1 ELSE 0 END;

        SET @UserRole_Selection = CONCAT('SELECT', 
            CASE WHEN @UserRole_SkippedCount = 0 AND @UserRole_TakenCount > 0 THEN ' TOP (@TakenCount)' END,
            '
                [UserRole].[Id] AS [Id],
                [UserRole].[RoleId] AS [RoleId]
            ');
        SET @UserRole_TotalCountSelection = 'SELECT COUNT_BIG([UserRole].[Id]) AS [TotalCount]';
        SET @UserRole_Origin = ' FROM [dbo].[UserRole]';
        SET @UserRole_Condition = ' WHERE [UserRole].[IsDeleted] = 0 AND [UserRole].[UserId] = @UserId';
        SET @UserRole_Parameters = '
            @UserId INT,
            @SkippedCount BIGINT,
            @TakenCount BIGINT,
            @SkippedRoleIds [dbo].[IntType] READONLY
        ';
        SET @UserRole_TotalCountParameters = '
            @UserId INT,
            @SkippedRoleIds [dbo].[IntType] READONLY
        ';

        IF @UserRole_IncludeRole = 1
        BEGIN
            SET @UserRole_Selection = CONCAT(@UserRole_Selection, ',
                [Role].[Id] AS [Id],
                [Role].[ApplicationId] AS [ApplicationId],
                [Role].[Name] AS [Name],
                [Role].[Description]
            ');
            SET @UserRole_Origin = CONCAT(@UserRole_Origin, ' LEFT JOIN [dbo].[Role] ON [UserRole].[RoleId] = [Role].[Id]');
            SET @UserRole_Condition = CONCAT(@UserRole_Condition, ' AND [Role].[IsDeleted] = 0');
        END
        ELSE
        BEGIN
            SET @UserRole_Selection = CONCAT(@UserRole_Selection, ',
                NULL AS [Id],
                NULL AS [ApplicationId],
                NULL AS [Name],
                NULL AS [Description]
            ');
        END

        IF @UserRole_HasSkippedRoleIds = 1
        BEGIN
            SET @UserRole_Condition = CONCAT(@UserRole_Condition, ' AND [UserRole].[RoleId] NOT IN (SELECT [Value] FROM @SkippedRoleIds)');
        END

        SET @UserRole_Query = CONCAT(
            @UserRole_Selection,
            @UserRole_Origin,
            @UserRole_Condition,
            ' ORDER BY',
            CASE WHEN @UserRole_IncludeRole = 1 THEN ' [Role].[Name] ASC' ELSE ' [UserRole].[RoleId] ASC' END,
            CASE WHEN @UserRole_SkippedCount > 0 THEN ' OFFSET @SkippedCount ROWS' END,
            CASE WHEN @UserRole_SkippedCount > 0 AND @UserRole_TakenCount > 0 THEN ' FETCH NEXT @TakenCount ROWS ONLY' END
        );
        SET @UserRole_TotalCountQuery = CONCAT(
            @UserRole_TotalCountSelection,
            @UserRole_Origin,
            @UserRole_Condition
        );

        EXEC SP_EXECUTESQL @UserRole_Query, @UserRole_Parameters,
            @UserId = @Id,
            @SkippedCount = @UserRole_SkippedCount,
            @TakenCount = @UserRole_TakenCount,
            @SkippedRoleIds = @UserRole_SkippedRoleIds;
        
        EXEC SP_EXECUTESQL @UserRole_TotalCountQuery, @UserRole_TotalCountParameters,
            @UserId = @Id,
            @SkippedRoleIds = @UserRole_SkippedRoleIds;
    END -- END: User-Role

    -- User-Permission
    IF @IncludeUserPermissions = 1
    BEGIN
        DECLARE @UserPermission_Query AS NVARCHAR(MAX);
        DECLARE @UserPermission_TotalCountQuery AS NVARCHAR(MAX);
        DECLARE @UserPermission_Selection AS NVARCHAR(MAX);
        DECLARE @UserPermission_TotalCountSelection AS NVARCHAR(MAX);
        DECLARE @UserPermission_Origin AS NVARCHAR(MAX);
        DECLARE @UserPermission_Condition AS NVARCHAR(MAX);
        DECLARE @UserPermission_Parameters AS NVARCHAR(MAX);
        DECLARE @UserPermission_TotalCountParameters AS NVARCHAR(MAX);
        DECLARE @UserPermission_HasSkippedPermissionIds AS BIT;

        SET @UserPermission_IncludePermission = ISNULL(@UserPermission_IncludePermission, 0);
        SET @UserPermission_SkippedCount =  ISNULL(@UserPermission_SkippedCount, 0);
        SET @UserPermission_TakenCount = ISNULL(@UserPermission_TakenCount, 0);
        SET @UserPermission_HasSkippedPermissionIds = CASE WHEN EXISTS(SELECT -1 FROM @UserPermission_SkippedPermissionIds) THEN 1 ELSE 0 END;

        SET @UserPermission_Selection = CONCAT('SELECT', 
            CASE WHEN @UserPermission_SkippedCount = 0 AND @UserPermission_TakenCount > 0 THEN ' TOP (@TakenCount)' END,
            '
                [UserPermission].[Id] AS [Id],
                [UserPermission].[PermissionId] AS [PermissionId]
            ');
        SET @UserPermission_TotalCountSelection = 'SELECT COUNT_BIG([Id]) AS [TotalCount]';
        SET @UserPermission_Origin = ' FROM [dbo].[UserPermission]';
        SET @UserPermission_Condition = ' WHERE [UserPermission].[IsDeleted] = 0 AND [UserPermission].[UserId] = @UserId';
        SET @UserPermission_Parameters = '
            @UserId INT,
            @SkippedCount BIGINT,
            @TakenCount BIGINT,
            @SkippedPermissionIds [dbo].[IntType] READONLY
        ';
        SET @UserPermission_TotalCountParameters = '
            @UserId INT,
            @SkippedPermissionIds [dbo].[IntType] READONLY
        ';

        IF @UserPermission_IncludePermission = 1
        BEGIN
            SET @UserPermission_Selection = CONCAT(@UserPermission_Selection, ',
                [Permission].[Id] AS [Id],
                [Permission].[ApplicationId] AS [ApplicationId],
                [Permission].[RoleId] AS [RoleId],
                [Permission].[Name] AS [Name],
                [Permission].[Description] AS [Description]
            ');
            SET @UserPermission_Origin = CONCAT(@UserPermission_Origin, ' LEFT JOIN [dbo].[Permission] ON [UserPermission].[PermissionId] = [Permission].[Id]');
            SET @UserPermission_Condition = CONCAT(@UserPermission_Condition, ' AND [Permission].[IsDeleted] = 0');
        END
        ELSE
        BEGIN
            SET @UserPermission_Selection = CONCAT(@UserPermission_Selection, ',
                NULL AS [Id],
                NULL AS [ApplicationId],
                NULL AS [RoleId],
                NULL AS [Name],
                NULL AS [Description]
            ');
        END

        IF @UserPermission_HasSkippedPermissionIds = 1
        BEGIN
            SET @UserPermission_Condition = CONCAT(@UserPermission_Condition, ' AND [UserPermission].[PermissionId] NOT IN (SELECT [Value] FROM @SkippedPermissionIds)');
        END

        SET @UserPermission_Query = CONCAT(
            @UserPermission_Selection,
            @UserPermission_Origin,
            @UserPermission_Condition,
            ' ORDER BY',
            CASE WHEN @UserPermission_IncludePermission = 1 THEN ' [Permission].[Name] ASC' ELSE ' [UserPermission].[PermissionId] ASC' END,
            CASE WHEN @UserPermission_SkippedCount > 0 THEN ' OFFSET @SkippedCount ROWS' END,
            CASE WHEN @UserPermission_SkippedCount > 0 AND @UserPermission_TakenCount > 0 THEN ' FETCH NEXT @TakenCount ROWS ONLY' END
        );
        SET @UserPermission_TotalCountQuery = CONCAT(
            @UserPermission_TotalCountSelection,
            @UserPermission_Origin,
            @UserPermission_Condition
        );

        EXEC SP_EXECUTESQL @UserPermission_Query, @UserPermission_Parameters,
            @UserId = @Id,
            @SkippedCount = @UserPermission_SkippedCount,
            @TakenCount = @UserPermission_TakenCount,
            @SkippedPermissionIds = @UserPermission_SkippedPermissionIds;

        EXEC SP_EXECUTESQL @UserPermission_TotalCountQuery, @UserPermission_TotalCountParameters,
            @UserId = @Id,
            @SkippedPermissionIds = @UserPermission_SkippedPermissionIds;
    END -- END: User-Permission
END
GO