USE [Sorschia_SystemBase];
GO

---------- USER-DEFINED TYPES ----------

IF TYPE_ID('dbo.IntList') IS NOT NULL
BEGIN
	DROP TYPE [dbo].[IntList];
END
GO

CREATE TYPE [dbo].[IntList]
AS TABLE
(
	[Value] INT
);
GO

---------- FUNCTIONS ----------

IF OBJECT_ID('dbo.Trim') IS NOT NULL
BEGIN
	DROP FUNCTION [dbo].[Trim];
END
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

IF OBJECT_ID('dbo.ConstructMiddleInitials') IS NOT NULL
BEGIN
	DROP FUNCTION [dbo].[ConstructMiddleInitials];
END
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
BEGIN
	DROP FUNCTION [dbo].[ConstructFullName];
END
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
BEGIN
	DROP FUNCTION [dbo].[ConstructInformalFullName];
END
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

---------- STORED PROCEDURES ----------
IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteApplication')
	DROP PROCEDURE [Security].[DeleteApplication];
GO

CREATE PROCEDURE [Security].[DeleteApplication]
(
	@Id INT
	,@IsCascaded BIT
	,@DeletedBy NVARCHAR(250)
) AS
BEGIN
	UPDATE [Security].[Application] SET
		[IsDeleted] = 1
		,[DeletedBy] = @DeletedBy
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;

	IF @IsCascaded = 1
	BEGIN
		SET NOCOUNT ON;
		UPDATE [Security].[Module] SET
			[IsDeleted] = 1
			,[DeletedBy] = @DeletedBy
			,[DeletedOn] = GETDATE()
		WHERE [ApplicationId] = @Id AND [IsDeleted] = 0;
		SET NOCOUNT OFF;
	END
END
GO

IF EXISTS(SELECT 0 FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [SPECIFIC_SCHEMA] = 'Security' AND [SPECIFIC_NAME] = 'DeleteApplicationPlatform')
	DROP PROCEDURE [Security].[DeleteApplicationPlatform];
GO

CREATE PROCEDURE [Security].[DeleteApplicationPlatform]
(
	@Id INT
	,@IsCascaded BIT
	,@DeletedBy NVARCHAR(250)
) AS
BEGIN
	UPDATE [Security].[ApplicationPlatform] SET
		[IsDeleted] = 1
		,[DeletedBy] = @DeletedBy
		,[DeletedOn] = GETDATE()
	WHERE [Id] = @Id AND [IsDeleted] = 0;

	IF @IsCascaded = 1
	BEGIN
		SET NOCOUNT ON;
		UPDATE [Security].[Application] SET
			[IsDeleted] = 1
			,[DeletedBy] = @DeletedBy
			,[DeletedOn] = GETDATE()
		WHERE [PlatformId] = @Id AND [IsDeleted] = 0;
		SET NOCOUNT OFF;
	END
END
GO