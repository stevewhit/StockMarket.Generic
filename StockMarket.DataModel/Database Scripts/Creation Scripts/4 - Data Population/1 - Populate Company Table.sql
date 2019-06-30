IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='AAPL')
BEGIN
	PRINT 'Inserting "AAPL" into "Companys" table..'

	INSERT INTO [dbo].[Companys]
			   ([Symbol]
			   ,[RetrieveQuotesFlag]
			   ,[DownloadDetailsFlag])
     	VALUES
              ('AAPL', 1, 1)
END
ELSE
	PRINT '"AAPL" already exists in the "Companys" table..'


IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GPRO')
BEGIN
	PRINT 'Inserting "GPRO" into "Companys" table..'

	INSERT INTO [dbo].[Companys]
			   ([Symbol]
			   ,[RetrieveQuotesFlag]
			   ,[DownloadDetailsFlag])
     	VALUES
              ('GPRO', 1, 1)
END
ELSE
	PRINT '"GPRO" already exists in the "Companys" table..'


IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GOOG')
BEGIN
	PRINT 'Inserting "GOOG" into "Companys" table..'

	INSERT INTO [dbo].[Companys]
			   ([Symbol]
			   ,[RetrieveQuotesFlag]
			   ,[DownloadDetailsFlag])
     	VALUES
              ('GOOG', 1, 1)
END
ELSE
	PRINT '"GOOG" already exists in the "Companys" table..'
