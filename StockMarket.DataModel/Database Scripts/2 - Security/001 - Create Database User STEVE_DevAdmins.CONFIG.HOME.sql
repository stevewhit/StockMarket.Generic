IF NOT EXISTS (SELECT * FROM sys.sysusers WHERE [name] = 'STEVE\DevAdmins')
BEGIN
	PRINT 'Creating "STEVE\DevAdmins" user"..'

	CREATE USER [STEVE\DevAdmins] FOR LOGIN [STEVE\DevAdmins]
	GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE TO [STEVE\DevAdmins]
END
ELSE
	PRINT 'The user "STEVE\DevAdmins" already exists..'
