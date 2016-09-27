EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";

EXEC sp_msforeachtable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0))
							BEGIN
								DELETE FROM ?
							END';

EXEC sp_msforeachtable 'IF OBJECT_ID(''?'') NOT IN (
								ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0),
								ISNULL(OBJECT_ID(''[dbo].[StudentAddresses]''),0),
								ISNULL(OBJECT_ID(''[dbo].[StudentCourses]''),0))
							BEGIN
								DBCC CHECKIDENT (''?'', RESEED, 1)
							END';

EXEC sp_msforeachtable "ALTER TABLE ?  WITH CHECK CHECK CONSTRAINT all";