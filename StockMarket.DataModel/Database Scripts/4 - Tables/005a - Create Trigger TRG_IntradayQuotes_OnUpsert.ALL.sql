IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_IntradayQuotes_OnUpsert]'))
BEGIN
	PRINT 'Dropping trigger "TRG_IntradayQuotes_OnUpsert"..'
	DROP TRIGGER [dbo].[TRG_IntradayQuotes_OnUpsert]
	IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_IntradayQuotes_OnUpsert]'))
		PRINT 'ERROR: Dropping trigger "[dbo].[TRG_IntradayQuotes_OnUpsert]"..'
	ELSE
		PRINT 'SUCCESS: Dropping trigger "[dbo].[TRG_IntradayQuotes_OnUpsert]"..'
END
GO

PRINT 'Creating trigger "TRG_IntradayQuotes_OnUpsert"..'
GO

CREATE TRIGGER [dbo].[TRG_IntradayQuotes_OnUpsert] ON [dbo].[IntradayQuotes] AFTER INSERT, UPDATE
AS
BEGIN
	-- Add LastModifiedDate
	SET NOCOUNT ON;
	UPDATE [dbo].[IntradayQuotes] SET LastModifiedDate=SYSDATETIME()
	FROM dbo.IntradayQuotes INNER JOIN inserted
		ON dbo.IntradayQuotes.Id = inserted.Id;

	DECLARE @utcEpochMs BIGINT;
	SELECT @utcEpochMs = inserted.UTCEpochMs FROM inserted

	-- Calculate UTCDateTime field
	DECLARE @utc_dt DATETIME;
	EXEC @utc_dt = dbo.fn_GetDateTimeFromEpochMs @utcEpochMs

	UPDATE [dbo].[IntradayQuotes] SET UTCDateTime=@utc_dt
	FROM dbo.IntradayQuotes INNER JOIN inserted
		ON dbo.IntradayQuotes.Id = inserted.Id;
				
	-- Calculate LocalDateTime field
	DECLARE @local_dt DATETIME;
	EXEC @local_dt = dbo.fn_GetLocalDateTimeFromUTC @utc_dt

	UPDATE [dbo].[IntradayQuotes] SET LocalDateTime=@local_dt
	FROM dbo.IntradayQuotes INNER JOIN inserted
		ON dbo.IntradayQuotes.Id = inserted.Id;
END
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_IntradayQuotes_OnUpsert]'))
	PRINT 'ERROR: Creating trigger "[dbo].[TRG_IntradayQuotes_OnUpsert]"..'
ELSE
	PRINT 'SUCCESS: Created trigger "[dbo].[TRG_IntradayQuotes_OnUpsert]"..' 