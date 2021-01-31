IF NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE [name] = 'StockMarketData')
BEGIN
	PRINT 'Creating "StockMarketData" database..'

	CREATE DATABASE [StockMarketData]	

	IF EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE [name] = 'StockMarketData')
	BEGIN
		PRINT 'Successfully created "StockMarketData" database..'
	END
	ELSE
		PRINT 'ERROR creating "StockMarketData" database..'
END
ELSE	
	PRINT 'Successfully found the StockMarketData database..'