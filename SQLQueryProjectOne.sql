USE [master]
GO
/****** Object:  Database [ProjectDBexa]    Script Date: 2022-01-26 09:26:28 ******/
CREATE DATABASE [ProjectDBexa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectDBexa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDBexa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectDBexa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDBexa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectDBexa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectDBexa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectDBexa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectDBexa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectDBexa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectDBexa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectDBexa] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectDBexa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectDBexa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectDBexa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectDBexa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectDBexa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectDBexa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectDBexa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectDBexa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectDBexa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectDBexa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectDBexa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectDBexa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectDBexa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectDBexa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectDBexa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectDBexa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectDBexa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectDBexa] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectDBexa] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectDBexa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectDBexa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectDBexa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectDBexa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectDBexa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectDBexa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectDBexa', N'ON'
GO
ALTER DATABASE [ProjectDBexa] SET QUERY_STORE = OFF
GO
USE [ProjectDBexa]
GO
/****** Object:  Table [dbo].[Project_tasks]    Script Date: 2022-01-26 09:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_tasks](
	[resourceid] [bigint] NULL,
	[projectid] [bigint] NULL,
	[description] [text] NULL,
	[status] [varchar](50) NULL,
	[id] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Project_tasks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2022-01-26 09:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[customer] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[active] [char](3) NULL,
	[due_date] [date] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 2022-01-26 09:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[id] [bigint] IDENTITY(1000,1) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[skill] [varchar](100) NULL,
	[admin_rights] [char](1) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Project_tasks] ON 
GO
INSERT [dbo].[Project_tasks] ([resourceid], [projectid], [description], [status], [id]) VALUES (1000, 1, N'Project 1 .NET', N'Ongoing, login and test data needed', 1)
GO
INSERT [dbo].[Project_tasks] ([resourceid], [projectid], [description], [status], [id]) VALUES (1000, 2, N'Finish watching Udemy intro SQL', N'Done', 2)
GO
INSERT [dbo].[Project_tasks] ([resourceid], [projectid], [description], [status], [id]) VALUES (1001, 3, N'Stå och glo', N'Ska påbörja gloandet', 3)
GO
INSERT [dbo].[Project_tasks] ([resourceid], [projectid], [description], [status], [id]) VALUES (1000, 3, N'Hjälper till att glo', N'Strax klar', 4)
GO
INSERT [dbo].[Project_tasks] ([resourceid], [projectid], [description], [status], [id]) VALUES (1002, 4, N'koka potatis', N'klart', 5)
GO
SET IDENTITY_INSERT [dbo].[Project_tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 
GO
INSERT [dbo].[Projects] ([id], [description], [customer], [status], [active], [due_date]) VALUES (1, N'Project 1', N'KYH', N'Ongoing, login and test data needed', N'Y  ', CAST(N'2022-01-13' AS Date))
GO
INSERT [dbo].[Projects] ([id], [description], [customer], [status], [active], [due_date]) VALUES (2, N'Databasteknik', N'Udemy', N'Finished', N'N  ', CAST(N'2022-01-17' AS Date))
GO
INSERT [dbo].[Projects] ([id], [description], [customer], [status], [active], [due_date]) VALUES (3, N'Stå och glo', N'Hela världen', N'Står, ska börja glo', N'Yes', CAST(N'2021-12-29' AS Date))
GO
INSERT [dbo].[Projects] ([id], [description], [customer], [status], [active], [due_date]) VALUES (4, N'laga mat', N'ingen', N'ongoing', N'Y  ', CAST(N'2022-01-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Resources] ON 
GO
INSERT [dbo].[Resources] ([id], [firstname], [lastname], [email], [skill], [admin_rights]) VALUES (1000, N'Daniel', N'Larsson', N'dlarsson@dl.com', N'Hello World console apps', N'Y')
GO
INSERT [dbo].[Resources] ([id], [firstname], [lastname], [email], [skill], [admin_rights]) VALUES (1001, N'Hank', N'The Tank', N'blomkruka@flowers.com', N'Stå och glo', N'N')
GO
INSERT [dbo].[Resources] ([id], [firstname], [lastname], [email], [skill], [admin_rights]) VALUES (1002, N'kurt', N'vonnegut', N'a@a.com', N'inget', N'N')
GO
SET IDENTITY_INSERT [dbo].[Resources] OFF
GO
ALTER TABLE [dbo].[Project_tasks]  WITH CHECK ADD  CONSTRAINT [FK_Project_tasks_Projects] FOREIGN KEY([projectid])
REFERENCES [dbo].[Projects] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project_tasks] CHECK CONSTRAINT [FK_Project_tasks_Projects]
GO
ALTER TABLE [dbo].[Project_tasks]  WITH CHECK ADD  CONSTRAINT [FK_Project_tasks_Resources] FOREIGN KEY([resourceid])
REFERENCES [dbo].[Resources] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project_tasks] CHECK CONSTRAINT [FK_Project_tasks_Resources]
GO
USE [master]
GO
ALTER DATABASE [ProjectDBexa] SET  READ_WRITE 
GO
