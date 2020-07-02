IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE [name] = 'STEVE\DevAdmins')
BEGIN
	PRINT 'Creating "STEVE\DevAdmins" login..'

	CREATE LOGIN [STEVE\DevAdmins] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
	ALTER SERVER ROLE [sysadmin] ADD MEMBER [STEVE\DevAdmins]
END
ELSE
	PRINT 'The user "STEVE\DevAdmins" login already exists..'
