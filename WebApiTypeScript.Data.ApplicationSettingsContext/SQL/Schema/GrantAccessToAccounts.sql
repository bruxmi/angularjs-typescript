USE [master];

IF NOT EXISTS (SELECT [name] FROM [master].[sys].[server_principals] WHERE [name] = '__Placeholder_ServiceAccount__')
BEGIN
	CREATE LOGIN [__Placeholder_ServiceAccount__] FROM WINDOWS WITH DEFAULT_DATABASE=[__Placeholder_Database__], DEFAULT_LANGUAGE=[us_english];    
END
ELSE
BEGIN
	ALTER SERVER ROLE sysadmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE setupadmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE serveradmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE securityadmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE processadmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE diskadmin DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE dbcreator DROP MEMBER [__Placeholder_ServiceAccount__];
	ALTER SERVER ROLE bulkadmin DROP MEMBER [__Placeholder_ServiceAccount__];
END


USE [__Placeholder_Database__];

IF USER_ID(N'__Placeholder_ServiceAccount__') IS NOT NULL
BEGIN
	DROP USER [__Placeholder_ServiceAccount__];
END

CREATE USER [__Placeholder_ServiceAccount__] FOR LOGIN [__Placeholder_ServiceAccount__] WITH DEFAULT_SCHEMA=[dbo];
ALTER ROLE [db_datareader] ADD MEMBER [__Placeholder_ServiceAccount__];
ALTER ROLE [db_datawriter] ADD MEMBER [__Placeholder_ServiceAccount__];
ALTER ROLE [db_ddladmin] ADD MEMBER [__Placeholder_ServiceAccount__];