IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetDateTimeFromEpochMs]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
BEGIN
	PRINT 'Dropping existing function: [dbo].[fn_GetDateTimeFromEpochMs]'
    DROP FUNCTION [dbo].[fn_GetDateTimeFromEpochMs]
	IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetDateTimeFromEpochMs]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
		PRINT 'ERROR: Dropping function "[dbo].[fn_GetDateTimeFromEpochMs]"..'
	ELSE
		PRINT 'SUCCESS: Dropping function "[dbo].[fn_GetDateTimeFromEpochMs]"..' 
END
GO 

PRINT 'Creating function: [dbo].[fn_GetDateTimeFromEpochMs]'
GO

-- ======================================================================================================
-- Author:		Steve Whitmire Jr.
-- Create date: January 31, 2021
-- Description:	Converts the supplied @UTCEpochMs into the UTC Datetime equivalent and returns the value. 
-- ======================================================================================================
CREATE FUNCTION [dbo].[fn_GetDateTimeFromEpochMs]
(
    @UTCEpochMs BIGINT
)
RETURNS DATETIME
AS
BEGIN
	RETURN DATEADD(MILLISECOND, @UTCEpochMs % 1000, DATEADD(SECOND, @UTCEpochMs / 1000, '19700101'))
END
GO

IF NOT EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GetDateTimeFromEpochMs]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
	PRINT 'ERROR: Creating function "[dbo].[fn_GetDateTimeFromEpochMs]"..'
ELSE
	PRINT 'SUCCESS: Created function "[dbo].[fn_GetDateTimeFromEpochMs]"..' 