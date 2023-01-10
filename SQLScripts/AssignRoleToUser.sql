DECLARE @UserName VARCHAR(256) = ''
DECLARE @RoleName VARCHAR(256) = ''

IF EXISTS (SELECT 1 FROM AspNetUsers WHERE UserName = @UserName )
BEGIN
IF EXISTS(SELECT 1 FROM AspNetRoles WHERE Name= @RoleName)
BEGIN
IF NOT EXISTS (SELECT 1 FROM AspNetUserRoles WHERE UserId = (SELECT Id FROM AspNetUsers WHERE UserName = @UserName))
BEGIN
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES ((SELECT Id FROM AspNetUsers WHERE UserName = @UserName)
		,(SELECT Id FROM AspNetRoles WHERE Name= @RoleName) )
END
END
END