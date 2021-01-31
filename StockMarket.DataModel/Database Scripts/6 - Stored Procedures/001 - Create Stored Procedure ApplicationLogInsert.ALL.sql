IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogInsert')
BEGIN
	PRINT 'Dropping stored procedure "ApplicationLogInsert"..'
	DROP PROCEDURE [dbo].[ApplicationLogInsert]
	IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogInsert')
		PRINT 'ERROR: Dropping stored procedure "ApplicationLogInsert"..'
	ELSE
		PRINT 'SUCCESS: Dropping stored procedure "ApplicationLogInsert"..'
END
GO

PRINT 'Creating stored procedure "ApplicationLogInsert"..'
GO

CREATE proc [dbo].[ApplicationLogInsert]
	@logDate DateTime
	,@thread nvarchar(255)
	,@logLevel nvarchar(50)
	,@logger nvarchar(255)
	,@message nvarchar(max)
	,@exception nvarchar(max)
	,@location nvarchar(255)
	,@userId nvarchar(255)
AS
  
INSERT INTO [dbo].[ApplicationLogs] ([Date],[Thread],[Level],[Logger],[Message],[Exception], [Location], [UserId] ) 
VALUES (@logDate, @thread, @logLevel, @logger, @message, @exception, @location, @userId)
GO

IF NOT EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'ApplicationLogInsert')
	PRINT 'ERROR: Creating stored procedure "ApplicationLogInsert"..'
ELSE
	PRINT 'SUCCESS: Created stored procedure "ApplicationLogInsert"..' 


