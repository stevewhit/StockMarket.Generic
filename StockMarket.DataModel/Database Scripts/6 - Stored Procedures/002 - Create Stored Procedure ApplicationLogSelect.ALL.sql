IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogSelect')
BEGIN
	PRINT 'Dropping stored procedure "ApplicationLogSelect"..'
	DROP PROCEDURE [dbo].[ApplicationLogSelect]
	IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogSelect')
		PRINT 'ERROR: Dropping stored procedure "ApplicationLogSelect"..'
	ELSE
		PRINT 'SUCCESS: Dropping stored procedure "ApplicationLogSelect"..'
END
GO

PRINT 'Creating stored procedure "ApplicationLogSelect"..'
GO

CREATE PROC [dbo].[ApplicationLogSelect]
AS

SELECT [Id]
	,[Date]
	,[Thread]
	,[Level]
	,[Logger]
	,[Message]
	,[Exception]
	,[Location]
	,[UserId]
FROM [dbo].[ApplicationLogs] logEntry
ORDER BY logEntry.Date DESC
GO

IF NOT EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogSelect')
	PRINT 'ERROR: Creating stored procedure "ApplicationLogSelect"..'
ELSE
	PRINT 'SUCCESS: Created stored procedure "ApplicationLogSelect"..' 