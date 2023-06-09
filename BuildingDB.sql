USE [master]
GO
/****** Object:  Database [BuildingManagement]    Script Date: 5/9/2023 7:45:18 PM ******/
CREATE DATABASE [BuildingManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BuildingManagement', FILENAME = N'D:\SQL2019\MSSQL15.MSSQLSERVER01\MSSQL\DATA\BuildingManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BuildingManagement_log', FILENAME = N'D:\SQL2019\MSSQL15.MSSQLSERVER01\MSSQL\DATA\BuildingManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BuildingManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BuildingManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BuildingManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BuildingManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BuildingManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BuildingManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BuildingManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BuildingManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BuildingManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BuildingManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BuildingManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BuildingManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BuildingManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BuildingManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BuildingManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BuildingManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BuildingManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BuildingManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BuildingManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BuildingManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BuildingManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BuildingManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BuildingManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BuildingManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BuildingManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [BuildingManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BuildingManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BuildingManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BuildingManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BuildingManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BuildingManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BuildingManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BuildingManagement', N'ON'
GO
ALTER DATABASE [BuildingManagement] SET QUERY_STORE = OFF
GO
USE [BuildingManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[Username] [varchar](150) NULL,
	[RoleID] [int] NOT NULL,
	[LastLogin] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK__Account__3214EC27975F230A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[ID] [varchar](255) NOT NULL,
	[BuildingTypeID] [int] NOT NULL,
	[Address] [nvarchar](50) NULL,
	[NumFloors] [int] NULL,
	[YearBuild] [int] NULL,
	[IsOccupied] [bit] NULL,
	[PurchaseDate] [date] NULL,
	[PurchasePrice] [float] NULL,
	[CustomerID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Image] [text] NULL,
	[Bed] [int] NULL,
	[Bath] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[IsResolve] [bit] NULL,
	[Area] [float] NULL,
	[IsPay] [bit] NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingType]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[Avatar] [text] NULL,
	[Address] [nvarchar](255) NULL,
	[CreateDate] [datetime] NULL,
	[Name] [nvarchar](255) NULL,
	[Phone] [varchar](50) NULL,
	[Note] [varchar](50) NULL,
 CONSTRAINT [PK__Customer__3214EC27B2206F8A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[ManagementBuildingID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Address] [nvarchar](250) NULL,
	[Avatar] [text] NULL,
 CONSTRAINT [PK__Employee__3214EC273E0AF4E6] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuildingID] [varchar](255) NOT NULL,
	[CreateDate] [datetime] NULL,
	[URL] [text] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagementBuilding]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagementBuilding](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuildingID] [varchar](255) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[IsSuccess] [bit] NULL,
 CONSTRAINT [PK__Manageme__3214EC27AD446639] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/9/2023 7:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuildingID] [varchar](255) NULL,
	[Time] [datetime] NULL,
	[EmployeeID] [int] NULL,
	[CustomerID] [int] NULL,
	[IsResolve] [bit] NULL,
	[Session] [bit] NULL,
 CONSTRAINT [PK__Appointm__3214EC277939CF7B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (5, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'employee', 3, NULL, NULL, N'chuongd505@gmail.com
')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (9, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'ab', 1, NULL, NULL, N'chuongd505@gmail.com
')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1011, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'toilalaogia', 2, NULL, NULL, N'chuongd505@gmail.com
')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1017, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'ss', 3, NULL, NULL, N'chuongd505@gmail.com
')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1018, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'cho', 2, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1019, N'$2a$10$lk6tVmvPojtUBJ0QTeF.8e6k8BbKdy/ekp9iuFU/pkW0IS1N/B5Xu', N'chux', 3, NULL, NULL, N'chux@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1020, N'$2a$10$hiRux2xt8XsutxSNeBZk9uw4LjZTRjOp/EZj8TOypwhnKbhfFbejW', N'employee1', 2, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1023, N'$2a$10$/r58/UvwTPtXb2ajb8ov4eLQyHbzJxWuP7LOw2lv0mwHApBDnMxhS', N'employee2', 2, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1024, N'$2a$10$Fjt9PgwR/gynFQIiml/Y7OHtSWQNYjgwfc6uo72HAs4p61D0kgIJu', N'user1', 3, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1025, N'$2a$10$X9YPoxXqr2xiHxptLG6gbeZQhQDlVcRv0WjAzfUmWKI8wLx4ZHlgO', N'meo', 2, NULL, NULL, N'chuongdinh2202@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1027, N'$2a$10$tTsSdWyxbOmR2KifVPB7q.7tjL0k9O1MxBI2vtIZHqiyWtJUvOSnS', N'chuongdinh', 3, NULL, NULL, N'chux1@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1028, N'$2a$10$xfMaAOTYsNyS4E21L8M11evf940O4gtaZ9ExyyYf/TmrQYzbi4x7W', N'a1', 3, NULL, NULL, N'chuongdinh2202@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1029, N'$2a$10$mhmklBc3EKDkPLkZK7I3Y.so6BMT6sa39MiWCZc37W92qf2C8Qyp.', N'nhanvien', 2, NULL, NULL, N'chuongdinh2202@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (1030, N'$2a$10$dbMc.Pr7YUmMdHDih7AAKuxJMAFdBjW6dsRNKrPF.PX5I.Uvq3hWq', N'khachhang', 3, NULL, NULL, N'chuongdinh2202@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (2030, N'$2a$10$rN7Dc.zgZ5x9admtncynMeWeJTdTMSC4HFChnmpf1n143lDYkseKC', N'lyly', 3, NULL, NULL, N'chuongdinh2202@gmail.com')
INSERT [dbo].[Account] ([ID], [Password], [Username], [RoleID], [LastLogin], [CreateDate], [Email]) VALUES (2031, N'$2a$10$3SnHtTTVBnDTeKm7ESh/3.Pwc780EkdWU/RjL9Ak49nhgeX2Mx39e', N'test', 3, NULL, NULL, N'chuongdinh2202@gmail.com')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'HT-435d4379-a22e-4b72-ad57-5b611d36fc02', 1, N'Old Trafford Nguyễn kiệm', 3, 2017, 1, NULL, 100000000, NULL, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683573522/building_img/z0x4swrjllqyzfwr3o1i.jpg', 6, 2, N'Nhà 1', 1, NULL, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'HT-95f28399-ac04-4b40-bfdd-1675f4ddb875', 1, N'Old Trafford Nguyễn kiệm', 2, 2017, 0, NULL, 10000000, NULL, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682773562/building_img/tqqngohdza3h0211nvoo.jpg', 2, 2, N'Đình Chương Provip222222', 1, NULL, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'HT-e50dbe24-3250-4db1-8f69-0e2ebc82f450', 4, N'Old Trafford Nguyễn kiệm', 1, 2017, 0, NULL, 10000000, NULL, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683540230/building_img/moxfnxn1zmq7pzpusz69.jpg', 1, 1, N'abcdefgzzz', 1, NULL, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-09607088-eb06-406f-85ab-0473045e0116', 4, N'Old Trafford Nguyễn kiệm', 3, 2017, 0, NULL, 2100000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1680688396/building_img/xz48fb5tsl9klv9xspky.jpg', 3, 5, N'Đình Chương Nè1', 1, NULL, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-16e25769-c7aa-4ea2-a441-efa3fab481b4', 2, N'Nguyễn Kiệm', 3, 1990, NULL, NULL, 10000000, 1045, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1680688396/building_img/xz48fb5tsl9klv9xspky.jpg', 6, 6, N'Nhà test 1', 1, 900, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-17fec864-903f-4259-b0bf-c2ae27e019a7', 1, N'Old Trafford Nguyễn kiệm', 3, 2017, 0, NULL, 10000000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682662802/building_img/ujaeki6efvbpvs69mvzk.jpg', 4, 6, N'cde', 1, 222.33, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-4270eeed-7699-4963-b016-f6e8fa123228', 2, N'Old Trafford Nguyễn kiệm', 3, 2018, 0, NULL, 3000000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682774444/building_img/zwcdfesb11msf3djpy8h.jpg', 5, 4, N'Đình Đình 2', 1, 222.33, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-439599e9-f753-4163-b4e1-b4ec9bee86d0', 1, N'Old Trafford Nguyễn kiệm', 2, 2017, 0, NULL, 10000000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682663466/building_img/u1hs0pude44urbooajch.jpg', 2, 1, N'ADORA', 1, 222.33, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-9682a1e7-ceb1-4f86-93ff-33db16b20ec9', 1, N'Old Trafford Nguyễn kiệm', 1, 2017, 0, NULL, 10000000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682662951/building_img/kb2rqkf1flbsqdkbxapg.jpg', 3, 4, N'abc', 1, 222.33, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-b957f0e6-4697-448d-89d3-8013225d906d', 1, N'Huỳnh tấn phát, Quận 7', 3, 2017, 0, NULL, 100000000, 1045, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683540542/building_img/byslxj5vuoxhz1ydxjx4.jpg', 6, 6, N'Nhà trắng', 1, 900, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-bc057618-a7da-43b2-bf3c-caac99b90835', 1, N'Old Trafford Nguyễn kiệm', 3, 2017, NULL, NULL, 100000000, 1045, NULL, NULL, 6, 6, N'Test final', 0, 222.33, 0)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-be81f2fa-0a18-414a-8ffb-72d8f633a9ee', 1, N'Huỳnh tấn phát', 3, 2017, NULL, NULL, 100000000, 1045, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683592066/building_img/bhirlpwuc6hh4uxvpeqv.jpg', 6, 6, N'LandSup5', 1, 1000, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-d92e8805-6501-4661-b296-a359aa1d4a24', 1, N'Huỳnh tấn phát, Quận 7', 3, 1999, NULL, NULL, 10000000, 1045, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1680688396/building_img/xz48fb5tsl9klv9xspky.jpg', 6, 6, N'Nhà test 2', 1, 1000, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-e13379dc-71c6-4da4-b881-7664cff11e26', 2, N'Old Trafford Nguyễn kiệm', 3, 2017, 0, NULL, 100000000, 1045, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683540542/building_img/byslxj5vuoxhz1ydxjx4.jpg', 6, 6, N'aaaa', 1, 900, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG-f8a00a80-ddba-4752-8e64-26f55553ede0', 2, N'Old Trafford Nguyễn kiệm', 3, 1990, 0, NULL, 4000000, 43, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682774643/building_img/ejyyu4y9xrokhvd3vahv.png', 6, 3, N'Đình Chương Provip222222', 1, NULL, 1)
INSERT [dbo].[Building] ([ID], [BuildingTypeID], [Address], [NumFloors], [YearBuild], [IsOccupied], [PurchaseDate], [PurchasePrice], [CustomerID], [CreateDate], [Image], [Bed], [Bath], [Name], [IsResolve], [Area], [IsPay]) VALUES (N'KG60df341b-45a8-4fb7-bd47-2e96a172ee41', 2, N'Old Trafford Nguyễn kiệm', 5, 2017, 0, NULL, 1230000, NULL, NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683540080/building_img/yk1xakxkxysyhcthbkgt.png', 2, 1, N'Đình Chương Provip', 1, 222.33, 1)
GO
SET IDENTITY_INSERT [dbo].[BuildingType] ON 

INSERT [dbo].[BuildingType] ([ID], [Name]) VALUES (1, N'Apartment')
INSERT [dbo].[BuildingType] ([ID], [Name]) VALUES (2, N'Skyscraper')
INSERT [dbo].[BuildingType] ([ID], [Name]) VALUES (3, N'Office building')
INSERT [dbo].[BuildingType] ([ID], [Name]) VALUES (4, N'Warehouse')
SET IDENTITY_INSERT [dbo].[BuildingType] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [AccountID], [Avatar], [Address], [CreateDate], [Name], [Phone], [Note]) VALUES (43, 1019, NULL, N'Old Trafford Nguyễn kiệm', NULL, N'Đình Chương Provip2222222123213', NULL, N'bbbbbbbbbbbb')
INSERT [dbo].[Customer] ([ID], [AccountID], [Avatar], [Address], [CreateDate], [Name], [Phone], [Note]) VALUES (44, 1028, NULL, N'Old Trafford Nguyễn kiệm', NULL, N'Alo alo ', N'03344362310', NULL)
INSERT [dbo].[Customer] ([ID], [AccountID], [Avatar], [Address], [CreateDate], [Name], [Phone], [Note]) VALUES (45, 1030, NULL, N'Old Trafford Nguyễn kiệm', NULL, N'abcdefg', N'0334436231', NULL)
INSERT [dbo].[Customer] ([ID], [AccountID], [Avatar], [Address], [CreateDate], [Name], [Phone], [Note]) VALUES (1045, 2030, NULL, N'Old Trafford Chiêu', NULL, N'Đình Chương', N'0334436231', N'abcdef')
INSERT [dbo].[Customer] ([ID], [AccountID], [Avatar], [Address], [CreateDate], [Name], [Phone], [Note]) VALUES (1046, 2031, NULL, N'Old Trafford Nguyễn kiệm', NULL, N'LE bang', N'0334436231', N'aaaaaaaaaaaaaaaaaaaa')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [AccountID], [Name], [Phone], [ManagementBuildingID], [CreateDate], [Address], [Avatar]) VALUES (1005, 1011, N'Đình Đình', N'0334436231', NULL, NULL, N'Old Trafford Nguyễn kiệm', N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683572689/building_img/e0hkpmbinhap3biszkmb.jpg')
INSERT [dbo].[Employee] ([ID], [AccountID], [Name], [Phone], [ManagementBuildingID], [CreateDate], [Address], [Avatar]) VALUES (1006, 1020, N'Lê Bằng', N'091234564', NULL, NULL, N'Nguyễn Kiệm', N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1682444255/building_img/e4y7hhy6y1g3omaglltz.png')
INSERT [dbo].[Employee] ([ID], [AccountID], [Name], [Phone], [ManagementBuildingID], [CreateDate], [Address], [Avatar]) VALUES (2007, 1029, N'Alo alo', N'3344362310', NULL, NULL, N'Old Trafford Nguyễn kiệm', NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [BuildingID], [CreateDate], [URL]) VALUES (1012, N'HT-435d4379-a22e-4b72-ad57-5b611d36fc02', NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683573513/building_img/mry8u3tif5bn7rpyvcqo.jpg')
INSERT [dbo].[Image] ([ID], [BuildingID], [CreateDate], [URL]) VALUES (1013, N'HT-435d4379-a22e-4b72-ad57-5b611d36fc02', NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683573515/building_img/v51xeieem2gpyvyf2upb.jpg')
INSERT [dbo].[Image] ([ID], [BuildingID], [CreateDate], [URL]) VALUES (1014, N'HT-435d4379-a22e-4b72-ad57-5b611d36fc02', NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683573518/building_img/ljuuig7szdp6sahxa2hu.jpg')
INSERT [dbo].[Image] ([ID], [BuildingID], [CreateDate], [URL]) VALUES (1015, N'HT-435d4379-a22e-4b72-ad57-5b611d36fc02', NULL, N'https://res.cloudinary.com/dzgugrqxz/image/upload/v1683573520/building_img/ekr70tsylwugwnaplarg.jpg')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[ManagementBuilding] ON 

INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4096, N'HT-e50dbe24-3250-4db1-8f69-0e2ebc82f450', 1005, NULL, 1)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4097, N'KG-17fec864-903f-4259-b0bf-c2ae27e019a7', 1005, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4098, N'KG-be81f2fa-0a18-414a-8ffb-72d8f633a9ee', 1005, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4099, N'KG-d92e8805-6501-4661-b296-a359aa1d4a24', 1005, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4100, N'KG-f8a00a80-ddba-4752-8e64-26f55553ede0', 1005, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4102, N'KG-439599e9-f753-4163-b4e1-b4ec9bee86d0', 1006, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4103, N'KG-9682a1e7-ceb1-4f86-93ff-33db16b20ec9', 1006, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4104, N'KG-be81f2fa-0a18-414a-8ffb-72d8f633a9ee', 1006, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4105, N'KG-f8a00a80-ddba-4752-8e64-26f55553ede0', 1006, NULL, 0)
INSERT [dbo].[ManagementBuilding] ([ID], [BuildingID], [EmployeeID], [CreateDate], [IsSuccess]) VALUES (4106, N'KG60df341b-45a8-4fb7-bd47-2e96a172ee41', 1006, NULL, 0)
SET IDENTITY_INSERT [dbo].[ManagementBuilding] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [Description]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Description]) VALUES (2, N'Employee', NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Description]) VALUES (3, N'User', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (5, N'KG-09607088-eb06-406f-85ab-0473045e0116', CAST(N'2023-06-20T00:00:00.000' AS DateTime), 1005, 43, 1, 1)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (6, N'KG-09607088-eb06-406f-85ab-0473045e0116', CAST(N'2023-04-20T00:00:00.000' AS DateTime), NULL, 43, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (1007, N'KG-09607088-eb06-406f-85ab-0473045e0116', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 1005, 43, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (1009, N'KG-4270eeed-7699-4963-b016-f6e8fa123228', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1005, 43, 1, 1)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (1010, N'KG-439599e9-f753-4163-b4e1-b4ec9bee86d0', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1005, 43, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (1013, N'KG-17fec864-903f-4259-b0bf-c2ae27e019a7', CAST(N'2023-05-03T00:00:00.000' AS DateTime), NULL, 43, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (2015, N'HT-e50dbe24-3250-4db1-8f69-0e2ebc82f450', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 1006, 1045, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (2017, N'KG-16e25769-c7aa-4ea2-a441-efa3fab481b4', CAST(N'2023-06-01T00:00:00.000' AS DateTime), 1005, 1045, 1, 1)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (3017, N'KG-be81f2fa-0a18-414a-8ffb-72d8f633a9ee', CAST(N'2023-06-10T00:00:00.000' AS DateTime), 1005, 43, 1, 0)
INSERT [dbo].[Schedule] ([ID], [BuildingID], [Time], [EmployeeID], [CustomerID], [IsResolve], [Session]) VALUES (3018, N'KG-be81f2fa-0a18-414a-8ffb-72d8f633a9ee', CAST(N'2023-06-10T00:00:00.000' AS DateTime), NULL, 1045, 0, 1)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
ALTER TABLE [dbo].[Building] ADD  CONSTRAINT [DF__Building__IsOccu__286302EC]  DEFAULT ((0)) FOR [IsOccupied]
GO
ALTER TABLE [dbo].[Building] ADD  CONSTRAINT [DF_Building_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ManagementBuilding] ADD  CONSTRAINT [DF_ManagementBuilding_IsSuccess]  DEFAULT ((0)) FOR [IsSuccess]
GO
ALTER TABLE [dbo].[Schedule] ADD  CONSTRAINT [DF_Schedule_IsResolve]  DEFAULT ((0)) FOR [IsResolve]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__Account__RoleID__398D8EEE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account__RoleID__398D8EEE]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK__Building__Buildi__32E0915F] FOREIGN KEY([BuildingTypeID])
REFERENCES [dbo].[BuildingType] ([ID])
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK__Building__Buildi__32E0915F]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK__Building__Custom__33D4B598] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK__Building__Custom__33D4B598]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK__Customer__Accoun__3A81B327] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK__Customer__Accoun__3A81B327]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK__Employee__Accoun__3B75D760] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK__Employee__Accoun__3B75D760]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Images_Buildings] FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Images_Buildings]
GO
ALTER TABLE [dbo].[ManagementBuilding]  WITH CHECK ADD  CONSTRAINT [FK__Managemen__Build__09A971A2] FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementBuilding] CHECK CONSTRAINT [FK__Managemen__Build__09A971A2]
GO
ALTER TABLE [dbo].[ManagementBuilding]  WITH CHECK ADD  CONSTRAINT [FK__Managemen__Emplo__1332DBDC] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementBuilding] CHECK CONSTRAINT [FK__Managemen__Emplo__1332DBDC]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__Buildi__17F790F9] FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__Buildi__17F790F9]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__Custom__19DFD96B] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__Custom__19DFD96B]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__Employ__18EBB532] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__Employ__18EBB532]
GO
USE [master]
GO
ALTER DATABASE [BuildingManagement] SET  READ_WRITE 
GO
