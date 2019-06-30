IF NOT EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Companys')
BEGIN
	PRINT 'Creating table "Companys"..'

	CREATE TABLE [dbo].[Companys](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Symbol] [nvarchar](20) NOT NULL,
		[CompanyName] [nvarchar](100) NULL,
		[Exchange] [nvarchar](50) NULL,
		[Industry] [nvarchar](100) NULL,
		[Website] [nvarchar](100) NULL,
		[Description] [nvarchar](2500) NULL,
		[CEO] [nvarchar](100) NULL,
		[SecurityName] [nvarchar](100) NULL,
		[IssueType] [nvarchar](50) NULL,
		[Sector] [nvarchar](50) NULL,
		[NumEmployees] int NULL,
		[Tags] [nvarchar](2000) NULL,
		[RetrieveQuotesFlag] [bit] NOT NULL DEFAULT(1),
		[DownloadDetailsFlag] [bit] NOT NULL DEFAULT(1),
	 CONSTRAINT [PK_Companys] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
ELSE
	PRINT 'The table "Companys" already exists.'


