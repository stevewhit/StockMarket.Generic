IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Quotes')
BEGIN
	PRINT 'Creating table "Quotes"..'

	CREATE TABLE [dbo].[Quotes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CompanyId] [int] NOT NULL,
		[TypeId] [int] NOT NULL,
		[Date] [datetime] NOT NULL,
		[Open] [decimal](10, 2) NOT NULL,
		[High] [decimal](10, 2) NOT NULL,
		[Low] [decimal](10, 2) NOT NULL,
		[Close] [decimal](10, 2) NOT NULL,
		[Volume] [bigint] NOT NULL,
		[IsValid] [bit] NOT NULL,
		[LastModifiedDate] [datetime] NULL,
	 CONSTRAINT [PK_Quotes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	 CONSTRAINT [U_Quotes_CompanyId_Date] UNIQUE NONCLUSTERED 
	(
		[CompanyId] ASC,
		[Date] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Quotes] ADD  DEFAULT ((1)) FOR [IsValid]

	ALTER TABLE [dbo].[Quotes]  WITH CHECK ADD  CONSTRAINT [FK_Quotes_Companys] FOREIGN KEY([CompanyId])
	REFERENCES [dbo].[Companys] ([Id])

	ALTER TABLE [dbo].[Quotes] CHECK CONSTRAINT [FK_Quotes_Companys]

	ALTER TABLE [dbo].[Quotes]  WITH CHECK ADD  CONSTRAINT [FK_Quotes_QuoteTypes] FOREIGN KEY([TypeId])
	REFERENCES [dbo].[QuoteTypes] ([Id])

	ALTER TABLE [dbo].[Quotes] CHECK CONSTRAINT [FK_Quotes_QuoteTypes]

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Quotes')	
		PRINT 'ERROR: Creating table "Quotes"..'
	ELSE
		PRINT 'SUCCESS: Created table "Quotes"..'
END
ELSE
	PRINT 'SKIP: The table "Quotes" already exists.'