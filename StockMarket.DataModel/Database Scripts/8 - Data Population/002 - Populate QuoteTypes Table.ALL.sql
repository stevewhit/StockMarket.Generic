IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='OneMinute')
BEGIN
	PRINT 'Inserting "OneMinute" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('OneMinute')
END
ELSE
	PRINT '"OneMinute" already exists in the "QuoteTypes" table..'

IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='FiveMinute')
BEGIN
	PRINT 'Inserting "FiveMinute" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('FiveMinute')
END
ELSE
	PRINT '"FiveMinute" already exists in the "QuoteTypes" table..'
	
IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='FifteenMinute')
BEGIN
	PRINT 'Inserting "FifteenMinute" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('FifteenMinute')
END
ELSE
	PRINT '"FifteenMinute" already exists in the "QuoteTypes" table..'
	
IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='ThirtyMinute')
BEGIN
	PRINT 'Inserting "ThirtyMinute" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('ThirtyMinute')
END
ELSE
	PRINT '"ThirtyMinute" already exists in the "QuoteTypes" table..'

IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='OneHour')
BEGIN
	PRINT 'Inserting "OneHour" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('OneHour')
END
ELSE
	PRINT '"OneHour" already exists in the "QuoteTypes" table..'

IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Day')
BEGIN
	PRINT 'Inserting "Day" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Day')
END
ELSE
	PRINT '"Day" already exists in the "QuoteTypes" table..'
	
IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Week')
BEGIN
	PRINT 'Inserting "Week" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Week')
END
ELSE
	PRINT '"Week" already exists in the "QuoteTypes" table..'
	
IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Month')
BEGIN
	PRINT 'Inserting "Month" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Month')
END
ELSE
	PRINT '"Month" already exists in the "QuoteTypes" table..'