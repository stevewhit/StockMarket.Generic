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
	
-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='ROKU')
-- BEGIN
	-- PRINT 'Inserting "ROKU" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('ROKU', 1, 1)
-- END
-- ELSE
	-- PRINT '"ROKU" already exists in the "Companys" table..'
	
-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='TSLA')
-- BEGIN
	-- PRINT 'Inserting "TSLA" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('TSLA', 1, 1)
-- END
-- ELSE
	-- PRINT '"TSLA" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GPRO')
-- BEGIN
	-- PRINT 'Inserting "GPRO" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('GPRO', 1, 1)
-- END
-- ELSE
	-- PRINT '"GPRO" already exists in the "Companys" table..'


-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GOOG')
-- BEGIN
	-- PRINT 'Inserting "GOOG" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('GOOG', 1, 1)
-- END
-- ELSE
	-- PRINT '"GOOG" already exists in the "Companys" table..'


-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='FB')
-- BEGIN
	-- PRINT 'Inserting "FB" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('FB', 1, 1)
-- END
-- ELSE
	-- PRINT '"FB" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GE')
-- BEGIN
	-- PRINT 'Inserting "GE" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('GE', 1, 1)
-- END
-- ELSE
	-- PRINT '"GE" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='F')
-- BEGIN
	-- PRINT 'Inserting "F" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('F', 1, 1)
-- END
-- ELSE
	-- PRINT '"F" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='HPE')
-- BEGIN
	-- PRINT 'Inserting "HPE" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('HPE', 1, 1)
-- END
-- ELSE
	-- PRINT '"HPE" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='UAA')
-- BEGIN
	-- PRINT 'Inserting "UAA" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('UAA', 1, 1)
-- END
-- ELSE
	-- PRINT '"UAA" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GPS')
-- BEGIN
	-- PRINT 'Inserting "GPS" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('GPS', 1, 1)
-- END
-- ELSE
	-- PRINT '"GPS" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='WU')
-- BEGIN
	-- PRINT 'Inserting "WU" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('WU', 1, 1)
-- END
-- ELSE
	-- PRINT '"WU" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='AAL')
-- BEGIN
	-- PRINT 'Inserting "AAL" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('AAL', 1, 1)
-- END
-- ELSE
	-- PRINT '"AAL" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='BAC')
-- BEGIN
	-- PRINT 'Inserting "BAC" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('BAC', 1, 1)
-- END
-- ELSE
	-- PRINT '"BAC" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='HRB')
-- BEGIN
	-- PRINT 'Inserting "HRB" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('HRB', 1, 1)
-- END
-- ELSE
	-- PRINT '"HRB" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='T')
-- BEGIN
	-- PRINT 'Inserting "T" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('T', 1, 1)
-- END
-- ELSE
	-- PRINT '"T" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='GM')
-- BEGIN
	-- PRINT 'Inserting "GM" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('GM', 1, 1)
-- END
-- ELSE
	-- PRINT '"GM" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='INTC')
-- BEGIN
	-- PRINT 'Inserting "INTC" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('INTC', 1, 1)
-- END
-- ELSE
	-- PRINT '"INTC" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='WFC')
-- BEGIN
	-- PRINT 'Inserting "WFC" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('WFC', 1, 1)
-- END
-- ELSE
	-- PRINT '"WFC" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='MS')
-- BEGIN
	-- PRINT 'Inserting "MS" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('MS', 1, 1)
-- END
-- ELSE
	-- PRINT '"MS" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='KO')
-- BEGIN
	-- PRINT 'Inserting "KO" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('KO', 1, 1)
-- END
-- ELSE
	-- PRINT '"KO" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='JNJ')
-- BEGIN
	-- PRINT 'Inserting "JNJ" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('JNJ', 1, 1)
-- END
-- ELSE
	-- PRINT '"JNJ" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='ORCL')
-- BEGIN
	-- PRINT 'Inserting "ORCL" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('ORCL', 1, 1)
-- END
-- ELSE
	-- PRINT '"ORCL" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='V')
-- BEGIN
	-- PRINT 'Inserting "V" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('V', 1, 1)
-- END
-- ELSE
	-- PRINT '"V" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='SBUX')
-- BEGIN
	-- PRINT 'Inserting "SBUX" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('SBUX', 1, 1)
-- END
-- ELSE
	-- PRINT '"SBUX" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='KR')
-- BEGIN
	-- PRINT 'Inserting "KR" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('KR', 1, 1)
-- END
-- ELSE
	-- PRINT '"KR" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='CVS')
-- BEGIN
	-- PRINT 'Inserting "CVS" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('CVS', 1, 1)
-- END
-- ELSE
	-- PRINT '"CVS" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='LOW')
-- BEGIN
	-- PRINT 'Inserting "LOW" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('LOW', 1, 1)
-- END
-- ELSE
	-- PRINT '"LOW" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='NKE')
-- BEGIN
	-- PRINT 'Inserting "NKE" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('NKE', 1, 1)
-- END
-- ELSE
	-- PRINT '"NKE" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='CTL')
-- BEGIN
	-- PRINT 'Inserting "CTL" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('CTL', 1, 1)
-- END
-- ELSE
	-- PRINT '"CTL" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='ADBE')
-- BEGIN
	-- PRINT 'Inserting "ADBE" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('ADBE', 1, 1)
-- END
-- ELSE
	-- PRINT '"ADBE" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='DIS')
-- BEGIN
	-- PRINT 'Inserting "DIS" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('DIS', 1, 1)
-- END
-- ELSE
	-- PRINT '"DIS" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='TIF')
-- BEGIN
	-- PRINT 'Inserting "TIF" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('TIF', 1, 1)
-- END
-- ELSE
	-- PRINT '"TIF" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='EBAY')
-- BEGIN
	-- PRINT 'Inserting "EBAY" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('EBAY', 1, 1)
-- END
-- ELSE
	-- PRINT '"EBAY" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='TSN')
-- BEGIN
	-- PRINT 'Inserting "TSN" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('TSN', 1, 1)
-- END
-- ELSE
	-- PRINT '"TSN" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='PEGI')
-- BEGIN
	-- PRINT 'Inserting "PEGI" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('PEGI', 1, 1)
-- END
-- ELSE
	-- PRINT '"PEGI" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='SHAK')
-- BEGIN
	-- PRINT 'Inserting "SHAK" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('SHAK', 1, 1)
-- END
-- ELSE
	-- PRINT '"SHAK" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='NVDA')
-- BEGIN
	-- PRINT 'Inserting "NVDA" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('NVDA', 1, 1)
-- END
-- ELSE
	-- PRINT '"NVDA" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='WMT')
-- BEGIN
	-- PRINT 'Inserting "NVDA" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('WMT', 1, 1)
-- END
-- ELSE
	-- PRINT '"WMT" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='MSFT')
-- BEGIN
	-- PRINT 'Inserting "MSFT" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('MSFT', 1, 1)
-- END
-- ELSE
	-- PRINT '"MSFT" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='D')
-- BEGIN
	-- PRINT 'Inserting "D" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('D', 1, 1)
-- END
-- ELSE
	-- PRINT '"D" already exists in the "Companys" table..'

-- IF NOT EXISTS (SELECT * FROM Companys WHERE Symbol='NFLX')
-- BEGIN
	-- PRINT 'Inserting "NFLX" into "Companys" table..'

	-- INSERT INTO [dbo].[Companys]
			   -- ([Symbol]
			   -- ,[RetrieveQuotesFlag]
			   -- ,[DownloadDetailsFlag])
     	-- VALUES
              -- ('NFLX', 1, 1)
-- END
-- ELSE
	-- PRINT '"NFLX" already exists in the "Companys" table..'