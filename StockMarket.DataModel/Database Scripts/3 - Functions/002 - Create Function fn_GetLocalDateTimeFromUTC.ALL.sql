IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetLocalDateTimeFromUTC]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
BEGIN
	PRINT 'Dropping existing function: [dbo].[fn_GetLocalDateTimeFromUTC]'
    DROP FUNCTION [dbo].[fn_GetLocalDateTimeFromUTC]
	IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetLocalDateTimeFromUTC]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
		PRINT 'ERROR: Dropping function "[dbo].[fn_GetLocalDateTimeFromUTC]"..'
	ELSE
		PRINT 'SUCCESS: Dropping function "[dbo].[fn_GetLocalDateTimeFromUTC]"..' 
END
GO 

PRINT 'Creating function: [dbo].[fn_GetLocalDateTimeFromUTC]'
GO

-- ==============================================================================================
-- Author:		Steve Whitmire Jr.
-- Create date: January 31, 2021
-- Description:	Converts the supplied @UTCDateTime into the local timezone and returns the value.
-- 				Daylight savings time is accounted for.
-- ==============================================================================================
CREATE FUNCTION [dbo].[fn_GetLocalDateTimeFromUTC]
(
    @UTCDateTime datetime
)
RETURNS datetime
AS
BEGIN

DECLARE 
	-- Second Sunday in March
    @SSM datetime = DATEADD(dd,7 + (6-(DATEDIFF(dd,0,DATEADD(mm,(YEAR(GETDATE())-1900) * 12 + 2,0))%7)),DATEADD(mm,(YEAR(GETDATE())-1900) * 12 + 2,0))+'02:00:00',

	-- First Sunday in November
    @FSN datetime = DATEADD(dd, (6-(DATEDIFF(dd,0,DATEADD(mm,(YEAR(GETDATE())-1900) * 12 + 10,0))%7)),DATEADD(mm,(YEAR(GETDATE())-1900) * 12 + 10,0)) +'02:00:00',

	-- Standard hour(s) offset between UTC and Local timezone.
	@standardOffset int = datediff (hh, GETUTCDATE(), GETDATE())

-- Add an hour to @StandardOffset if @UTC is in DST range
if @UTCDateTime between @SSM and @FSN
    SET @standardOffset = @standardOffset + 1

-- Convert to DST
DECLARE @DST datetime = dateadd(hour,@StandardOffset,@UTCDateTime)
return @DST

END
GO

IF NOT EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetLocalDateTimeFromUTC]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
	PRINT 'ERROR: Creating function "[dbo].[fn_GetLocalDateTimeFromUTC]"..'
ELSE
	PRINT 'SUCCESS: Created function "[dbo].[fn_GetLocalDateTimeFromUTC]"..' 