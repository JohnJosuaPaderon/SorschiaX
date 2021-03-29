CREATE OR ALTER PROCEDURE [dbo].[GetUser]
(
    @Id INT,
    @IncludeUserApplications BIT,
    @IncludeUserRoles BIT,
    @IncludeUserPermissions BIT,
    @UserApplication_SkippedCount BIGINT,
    @UserApplication_TakenCount INT,
    @UserApplication_SkippedApplicationIds [dbo].[SmallIntType] READONLY,
    @UserApplication_IncludeApplication BIT,
    @UserRole_SkippedCount BIGINT,
    @UserRole_TakenCount INT,
    @UserRole_SkippedRoleIds [dbo].[IntType] READONLY,
    @UserRole_IncludeRole BIT,
    @UserPermission_SkippedCount BIGINT,
    @UserPermission_TakenCount INT,
    @UserPermission_SkippedPermissionIds [dbo].[IntType] READONLY,
    @UserPermission_IncludePermission BIT
) AS
BEGIN
    DECLARE @Query AS NVARCHAR(MAX);
    DECLARE @UserApplicationQuery AS NVARCHAR(MAX);
    DECLARE @UserRoleQuery AS NVARCHAR(MAX);
    DECLARE @UserPermissionQuery AS NVARCHAR(MAX);
    DECLARE @Selection AS NVARCHAR(MAX);
    DECLARE @UserApplicationSelection AS NVARCHAR(MAX);
    DECLARE @UserRoleSelection AS NVARCHAR(MAX);
    DECLARE @UserPermissionSelection AS NVARCHAR(MAX);

    SET @Selection = '
        SELECT TOP 1
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
    ';
END
GO