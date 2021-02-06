IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'IntradayQuotes')
BEGIN
	PRINT 'Creating table "IntradayQuotes"..'

	CREATE TABLE [dbo].[IntradayQuotes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CompanyId] [int] NOT NULL,
		[UTCEpochMs] [bigint] NOT NULL,
		[UTCDateTime] [datetime] NULL,
		[LocalDateTime] [datetime] NULL,
		[Price] [decimal](10, 2) NOT NULL,
		[LastModifiedDate] [datetime] NULL,
	 CONSTRAINT [PK_IntradayQuotes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	 CONSTRAINT [U_IntradayQuotes_CompanyId_UTCEpochMs] UNIQUE NONCLUSTERED 
	(
		[CompanyId] ASC,
		[UTCEpochMs] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[IntradayQuotes]  WITH CHECK ADD  CONSTRAINT [FK_IntradayQuotes_Companys] FOREIGN KEY([CompanyId])
	REFERENCES [dbo].[Companys] ([Id])

	ALTER TABLE [dbo].[IntradayQuotes] CHECK CONSTRAINT [FK_IntradayQuotes_Companys]
	
	IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'IntradayQuotes')	
		PRINT 'ERROR: Creating table "IntradayQuotes"..'
	ELSE
		PRINT 'SUCCESS: Created table "IntradayQuotes"..'
END
ELSE
	PRINT 'SKIP: The table "IntradayQuotes" already exists.'