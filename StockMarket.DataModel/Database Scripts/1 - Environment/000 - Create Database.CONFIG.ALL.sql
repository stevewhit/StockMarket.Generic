IF NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE [name] = 'StockMarketData')
BEGIN
	PRINT 'Creating "StockMarketData" database..'

	CREATE DATABASE [StockMarketData]	

	IF EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE [name] = 'StockMarketData')
	BEGIN
		PRINT 'SUCCESS: Created "StockMarketData" database..'
	END
	ELSE
		PRINT 'ERROR: Creating "StockMarketData" database..'
END
ELSE	
	PRINT 'SKIP: "StockMarketData" database already exists..'