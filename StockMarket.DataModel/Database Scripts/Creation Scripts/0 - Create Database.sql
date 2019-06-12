-- Skip the database creation if we're not on the correct machine.
IF (@@SERVERNAME <> 'DEV-SQL\ITSSQL')
BEGIN
	IF NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE [name] = 'StockMarketData')
	BEGIN
		PRINT 'Creating "StockMarketData" database"..'

		CREATE DATABASE [StockMarketData]
		 CONTAINMENT = NONE
		 ON  PRIMARY 
		( NAME = N'StockMarketData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DEVSQL\MSSQL\DATA\StockMarketData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
		 LOG ON 
		( NAME = N'StockMarketData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DEVSQL\MSSQL\DATA\StockMarketData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
		ALTER DATABASE [StockMarketData] SET COMPATIBILITY_LEVEL = 140
		
		IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
		begin
			EXEC [StockMarketData].[dbo].[sp_fulltext_database] @action = 'enable'
		end
		
		ALTER DATABASE [StockMarketData] SET ANSI_NULL_DEFAULT OFF 
		ALTER DATABASE [StockMarketData] SET ANSI_NULLS OFF 
		ALTER DATABASE [StockMarketData] SET ANSI_PADDING OFF 
		ALTER DATABASE [StockMarketData] SET ANSI_WARNINGS OFF 
		ALTER DATABASE [StockMarketData] SET ARITHABORT OFF 
		ALTER DATABASE [StockMarketData] SET AUTO_CLOSE OFF 
		ALTER DATABASE [StockMarketData] SET AUTO_SHRINK OFF 
		ALTER DATABASE [StockMarketData] SET AUTO_UPDATE_STATISTICS ON 
		ALTER DATABASE [StockMarketData] SET CURSOR_CLOSE_ON_COMMIT OFF 
		ALTER DATABASE [StockMarketData] SET CURSOR_DEFAULT  GLOBAL 
		ALTER DATABASE [StockMarketData] SET CONCAT_NULL_YIELDS_NULL OFF 
		ALTER DATABASE [StockMarketData] SET NUMERIC_ROUNDABORT OFF 
		ALTER DATABASE [StockMarketData] SET QUOTED_IDENTIFIER OFF 
		ALTER DATABASE [StockMarketData] SET RECURSIVE_TRIGGERS OFF 
		ALTER DATABASE [StockMarketData] SET  DISABLE_BROKER 
		ALTER DATABASE [StockMarketData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
		ALTER DATABASE [StockMarketData] SET DATE_CORRELATION_OPTIMIZATION OFF 
		ALTER DATABASE [StockMarketData] SET TRUSTWORTHY OFF 
		ALTER DATABASE [StockMarketData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
		ALTER DATABASE [StockMarketData] SET PARAMETERIZATION SIMPLE 
		ALTER DATABASE [StockMarketData] SET READ_COMMITTED_SNAPSHOT OFF 
		ALTER DATABASE [StockMarketData] SET HONOR_BROKER_PRIORITY OFF 
		ALTER DATABASE [StockMarketData] SET RECOVERY FULL 
		ALTER DATABASE [StockMarketData] SET  MULTI_USER 
		ALTER DATABASE [StockMarketData] SET PAGE_VERIFY CHECKSUM  
		ALTER DATABASE [StockMarketData] SET DB_CHAINING OFF 
		ALTER DATABASE [StockMarketData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
		ALTER DATABASE [StockMarketData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
		ALTER DATABASE [StockMarketData] SET DELAYED_DURABILITY = DISABLED 
		ALTER DATABASE [StockMarketData] SET QUERY_STORE = OFF
		ALTER DATABASE [StockMarketData] SET  READ_WRITE 
	END
	ELSE
		PRINT 'The database "StockMarketData" already exists..'
END
ELSE
	PRINT 'Wrong machine, skipping "StockMarketData" database creation..'