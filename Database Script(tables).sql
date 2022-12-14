USE [master]
GO
/****** Object:  Database [tritonexpress]    Script Date: 2022/07/31 15:50:08 ******/
CREATE DATABASE [tritonexpress]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tritonexpress', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tritonexpress.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tritonexpress_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tritonexpress_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tritonexpress] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tritonexpress].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tritonexpress] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tritonexpress] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tritonexpress] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tritonexpress] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tritonexpress] SET ARITHABORT OFF 
GO
ALTER DATABASE [tritonexpress] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tritonexpress] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tritonexpress] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tritonexpress] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tritonexpress] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tritonexpress] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tritonexpress] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tritonexpress] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tritonexpress] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tritonexpress] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tritonexpress] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tritonexpress] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tritonexpress] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tritonexpress] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tritonexpress] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tritonexpress] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tritonexpress] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tritonexpress] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tritonexpress] SET  MULTI_USER 
GO
ALTER DATABASE [tritonexpress] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tritonexpress] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tritonexpress] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tritonexpress] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tritonexpress] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tritonexpress] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [tritonexpress] SET QUERY_STORE = OFF
GO
USE [tritonexpress]
GO
/****** Object:  User [triton_user]    Script Date: 2022/07/31 15:50:08 ******/
CREATE USER [triton_user] FOR LOGIN [triton_user] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [triton]    Script Date: 2022/07/31 15:50:08 ******/
CREATE USER [triton] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[guest]
GO
/****** Object:  Table [dbo].[Parcel]    Script Date: 2022/07/31 15:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNumber] [nchar](20) NOT NULL,
	[Dimensions] [nchar](10) NOT NULL,
	[Mass] [nchar](10) NOT NULL,
	[Service] [nchar](50) NULL,
 CONSTRAINT [PK_Parcels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 2022/07/31 15:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Make] [varchar](250) NULL,
	[Model] [varchar](250) NULL,
	[Color] [varchar](250) NULL,
	[Type] [varchar](250) NULL,
	[Transmission] [varchar](250) NULL,
	[RegistrationNumber] [varchar](50) NULL,
	[Capacity] [decimal](18, 0) NULL,
	[Branch] [varchar](250) NULL,
	[FuelType] [nchar](50) NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WayBillForm]    Script Date: 2022/07/31 15:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WayBillForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNumber] [nchar](20) NOT NULL,
	[ShipDate] [datetime] NULL,
	[ShipmentDate] [datetime] NULL,
	[Vehicle] [int] NULL,
	[Company] [nchar](150) NULL,
	[FromContactName] [nchar](50) NULL,
	[FromPhoneNumber] [nchar](50) NULL,
	[ToFirstName] [nchar](50) NULL,
	[ToLastName] [nchar](50) NULL,
	[Address1] [nchar](150) NULL,
	[Address2] [nchar](150) NULL,
	[PostalCode] [nchar](10) NULL,
	[Country] [nchar](150) NULL,
 CONSTRAINT [PK_WayBillForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [tritonexpress] SET  READ_WRITE 
GO
