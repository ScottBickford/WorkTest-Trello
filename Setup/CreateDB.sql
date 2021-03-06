USE [master]
GO
/****** Object:  Database [WorkTestTrello]    Script Date: 2017/01/25 4:48:17 PM ******/
CREATE DATABASE [WorkTestTrello] ON  PRIMARY 
( NAME = N'WorkTestTrello', FILENAME = N'D:\SQL Server\Data\WorkTestTrello.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WorkTestTrello_log', FILENAME = N'D:\SQL Server\Data\WorkTestTrello_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WorkTestTrello] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkTestTrello].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkTestTrello] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkTestTrello] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkTestTrello] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkTestTrello] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkTestTrello] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkTestTrello] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkTestTrello] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkTestTrello] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkTestTrello] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkTestTrello] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkTestTrello] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkTestTrello] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkTestTrello] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkTestTrello] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkTestTrello] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkTestTrello] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkTestTrello] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkTestTrello] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkTestTrello] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkTestTrello] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkTestTrello] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkTestTrello] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkTestTrello] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkTestTrello] SET  MULTI_USER 
GO
ALTER DATABASE [WorkTestTrello] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkTestTrello] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkTestTrello', N'ON'
GO
USE [WorkTestTrello]
GO
/****** Object:  User [XICRM_Reports]    Script Date: 2017/01/25 4:48:17 PM ******/
CREATE USER [XICRM_Reports] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 2017/01/25 4:48:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[AppCode] [varchar](20) NOT NULL,
	[AppVersion] [varchar](20) NOT NULL,
	[ErrorDescription] [varchar](max) NOT NULL,
	[StackTrace] [varchar](max) NOT NULL,
	[SourceName] [varchar](max) NOT NULL,
	[ExceptionType] [varchar](100) NOT NULL,
	[IPAddress] [varchar](20) NOT NULL,
	[ControllerName] [varchar](100) NULL,
	[ActionName] [varchar](100) NULL,
	[UserAgent] [varchar](max) NULL,
	[UserHostAddress] [varchar](100) NULL,
	[UserHostName] [varchar](100) NULL,
	[CreatedByUser] [nvarchar](50) NOT NULL,
	[CreatedOnDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_ErrorLog]    Script Date: 2017/01/25 4:48:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_ErrorLog] ON [dbo].[ErrorLog]
(
	[CreatedOnDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WorkTestTrello] SET  READ_WRITE 
GO
