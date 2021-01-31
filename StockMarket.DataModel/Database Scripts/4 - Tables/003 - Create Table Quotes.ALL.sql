IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Quotes')
BEGIN
	PRINT 'Creating table "Quotes"..'

	CREATE TABLE [dbo].[Quotes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CompanyId] [int] NOT NULL,
		[UTCEpochMs] [bigint] NOT NULL,
		[UTCDateTime] [datetime] NULL,
		[LocalDateTime] [datetime] NULL,
		[Price] [decimal](10, 2) NOT NULL,
		[LastModifiedDate] [datetime] NULL,
	 CONSTRAINT [PK_Quotes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	 CONSTRAINT [U_Quotes_CompanyId_UTCEpochMs] UNIQUE NONCLUSTERED 
	(
		[CompanyId] ASC,
		[UTCEpochMs] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Quotes]  WITH CHECK ADD  CONSTRAINT [FK_Quotes_Companys] FOREIGN KEY([CompanyId])
	REFERENCES [dbo].[Companys] ([Id])

	ALTER TABLE [dbo].[Quotes] CHECK CONSTRAINT [FK_Quotes_Companys]
	
	IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Quotes')	
		PRINT 'ERROR: Creating table "Quotes"..'
	ELSE
		PRINT 'SUCCESS: Created table "Quotes"..'
END
ELSE
	PRINT 'SKIP: The table "Quotes" already exists.'