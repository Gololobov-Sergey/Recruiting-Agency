USE [master]
GO
/****** Object:  Database [recruiting]    Script Date: 01.08.2017 7:54:23 ******/
CREATE DATABASE [recruiting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'recruiting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\recruiting.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'recruiting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\recruiting_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [recruiting] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [recruiting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [recruiting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [recruiting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [recruiting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [recruiting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [recruiting] SET ARITHABORT OFF 
GO
ALTER DATABASE [recruiting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [recruiting] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [recruiting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [recruiting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [recruiting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [recruiting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [recruiting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [recruiting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [recruiting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [recruiting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [recruiting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [recruiting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [recruiting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [recruiting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [recruiting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [recruiting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [recruiting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [recruiting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [recruiting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [recruiting] SET  MULTI_USER 
GO
ALTER DATABASE [recruiting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [recruiting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [recruiting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [recruiting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [recruiting]
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 01.08.2017 7:54:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Adress] [varchar](100) NOT NULL,
	[Phone] [nchar](9) NOT NULL,
	[Site] [nchar](30) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employers] ON 

INSERT [dbo].[Employers] ([ID], [Name], [Adress], [Phone], [Site], [Description]) VALUES (1, N'ООО "Рассвет"', N'г. Николаев, ул. Садовая, 50', N'503152334', N'www.sunrise.com               ', N'Выращивание сельскохозяйственной продукции')
INSERT [dbo].[Employers] ([ID], [Name], [Adress], [Phone], [Site], [Description]) VALUES (2, N'ФОП Иванов В.А.', N'г. Киев, пр. Победы, 40-А', N'442455878', N'www.ukrbeton.in.ua            ', N'Производство строительных блоков')
INSERT [dbo].[Employers] ([ID], [Name], [Adress], [Phone], [Site], [Description]) VALUES (3, N'АО "Молокозавод"', N'г. Баштанка, ул. Набережная, 34', N'513254785', N'www.bashmol.com.ua            ', N'Производство молочной продукции')
SET IDENTITY_INSERT [dbo].[Employers] OFF
USE [master]
GO
ALTER DATABASE [recruiting] SET  READ_WRITE 
GO
