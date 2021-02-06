IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'QuoteTypes')
BEGIN
	PRINT 'Creating table "QuoteTypes"..'

	CREATE TABLE [dbo].[QuoteTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](25) NOT NULL,
	 CONSTRAINT [PK_QuoteTypes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'QuoteTypes')	
		PRINT 'ERROR: Creating table "QuoteTypes"..'
	ELSE
		PRINT 'SUCCESS: Created table "QuoteTypes"..'
END
ELSE
	PRINT 'SKIP: The table "QuoteTypes" already exists.'