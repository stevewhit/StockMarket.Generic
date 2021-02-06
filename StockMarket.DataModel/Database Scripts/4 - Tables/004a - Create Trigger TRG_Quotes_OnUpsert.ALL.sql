IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_Quotes_OnUpsert]'))
BEGIN
	PRINT 'Dropping trigger "TRG_Quotes_OnUpsert"..'
	DROP TRIGGER [dbo].[TRG_Quotes_OnUpsert]
	IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_Quotes_OnUpsert]'))
		PRINT 'ERROR: Dropping trigger "[dbo].[TRG_Quotes_OnUpsert]"..'
	ELSE
		PRINT 'SUCCESS: Dropping trigger "[dbo].[TRG_Quotes_OnUpsert]"..'
END
GO

PRINT 'Creating trigger "TRG_Quotes_OnUpsert"..'
GO

CREATE TRIGGER [dbo].[TRG_Quotes_OnUpsert] ON [dbo].[Quotes] AFTER INSERT, UPDATE
AS
BEGIN
	-- Add LastModifiedDate
	SET NOCOUNT ON;
	UPDATE [dbo].[Quotes] SET LastModifiedDate=SYSDATETIME()
	FROM dbo.Quotes INNER JOIN inserted
	 ON dbo.Quotes.Id = inserted.Id;
END
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TRG_Quotes_OnUpsert]'))
	PRINT 'ERROR: Creating trigger "[dbo].[TRG_Quotes_OnUpsert]"..'
ELSE
	PRINT 'SUCCESS: Created trigger "[dbo].[TRG_Quotes_OnUpsert]"..' 