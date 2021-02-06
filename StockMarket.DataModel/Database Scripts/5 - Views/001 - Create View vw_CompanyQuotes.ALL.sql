IF EXISTS (SELECT * FROM sys.views WHERE NAME = 'vw_CompanyQuotes')
BEGIN
	PRINT 'Dropping view "vw_CompanyQuotes"..'
	DROP VIEW [dbo].[vw_CompanyQuotes]
	IF EXISTS (SELECT * FROM sys.views WHERE NAME = 'vw_CompanyQuotes')
		PRINT 'ERROR: Dropping view "vw_CompanyQuotes"..'
	ELSE
		PRINT 'SUCCESS: Dropping view "vw_CompanyQuotes"..'
END
GO

PRINT 'Creating view "vw_CompanyQuotes"..'
GO

CREATE VIEW [dbo].[vw_CompanyQuotes]
AS
SELECT        [dbo].[Quotes].[CompanyId], [dbo].[Companys].[Symbol], [dbo].[Companys].[CompanyName], [dbo].[Quotes].[TypeId], [dbo].QuoteTypes.[Type], [dbo].[Quotes].[Date], [dbo].[Quotes].[Open], [dbo].[Quotes].[High], [dbo].[Quotes].[Low], [dbo].[Quotes].[Close], 
                         [dbo].[Quotes].[Volume], [dbo].[Quotes].[IsValid]
FROM            [dbo].[Companys] INNER JOIN
                         [dbo].[Quotes] ON [dbo].[Companys].[Id] = [dbo].[Quotes].[CompanyId] INNER JOIN
                         [dbo].[QuoteTypes] ON [dbo].[Quotes].[TypeId] = [dbo].[QuoteTypes].[Id]
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE NAME = 'vw_CompanyQuotes')
	PRINT 'ERROR: Creating view "vw_CompanyQuotes"..'
ELSE
	PRINT 'SUCCESS: Created view "vw_CompanyQuotes"..' 