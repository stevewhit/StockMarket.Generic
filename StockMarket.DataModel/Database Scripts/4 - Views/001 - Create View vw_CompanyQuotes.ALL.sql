IF EXISTS (SELECT * FROM sys.views WHERE NAME = 'vw_CompanyQuotes')
BEGIN
	PRINT 'The view "vw_CompanyQuotes" already exists.'
	SET NOEXEC ON
END
ELSE
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

SET NOEXEC OFF	