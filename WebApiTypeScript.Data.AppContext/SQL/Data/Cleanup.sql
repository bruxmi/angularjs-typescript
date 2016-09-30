EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";

EXEC sp_msforeachtable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0))
							BEGIN
								DELETE FROM ?
								DBCC CHECKIDENT (''?'', RESEED, 0)
							END';

EXEC sp_msforeachtable "ALTER TABLE ?  WITH CHECK CHECK CONSTRAINT all";