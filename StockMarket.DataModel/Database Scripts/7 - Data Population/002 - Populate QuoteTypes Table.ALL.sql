IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Second')
BEGIN
	PRINT 'Inserting "Second" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Second')
END
ELSE
	PRINT '"Second" already exists in the "QuoteTypes" table..'


IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Minute')
BEGIN
	PRINT 'Inserting "Minute" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Minute')
END
ELSE
	PRINT '"Minute" already exists in the "QuoteTypes" table..'


IF NOT EXISTS (SELECT * FROM QuoteTypes WHERE Type='Hour')
BEGIN
	PRINT 'Inserting "Hour" into "QuoteTypes" table..'

	INSERT INTO [dbo].[QuoteTypes]
			   ([Type])
     	VALUES
              ('Hour')
END
ELSE
	PRINT '"Hour" already exists in the "QuoteTypes" table..'

	
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