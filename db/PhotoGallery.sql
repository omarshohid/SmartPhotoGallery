USE [master]
GO
/****** Object:  Database [PhotoGallery]    Script Date: 8/18/2019 10:31:23 AM ******/
CREATE DATABASE [PhotoGallery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotoGallery', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PhotoGallery.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PhotoGallery_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PhotoGallery_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PhotoGallery] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotoGallery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotoGallery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotoGallery] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotoGallery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotoGallery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotoGallery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotoGallery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotoGallery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotoGallery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotoGallery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotoGallery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotoGallery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotoGallery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotoGallery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotoGallery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhotoGallery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotoGallery] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PhotoGallery] SET  MULTI_USER 
GO
ALTER DATABASE [PhotoGallery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotoGallery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotoGallery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotoGallery] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PhotoGallery] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PhotoGallery]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NULL,
	[EventDate] [datetime] NULL,
	[EventType] [int] NULL,
	[EventLocation] [nvarchar](max) NULL,
	[UploaderId] [int] NULL,
	[GalleryPath] [nvarchar](350) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ImageTitle] [nvarchar](max) NULL,
	[ImageDetails] [nvarchar](max) NULL,
	[PC] [nvarchar](max) NULL,
	[ImageLike] [int] NULL,
	[ImageTag] [nvarchar](max) NULL,
	[UploadedBy] [int] NULL,
	[UploadDate] [datetime] NULL,
	[IsApproved] [int] NULL,
	[ApprovedBy] [nvarchar](150) NULL,
	[ApproveDate] [datetime] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ffecada-7cda-43f1-9edf-5cb0547eab42', N'admin@gmail.com', 0, N'AGFHk67PwvkjEGGoOTToIyMpqzAaWyi0u+duhcnImkR/feAb5pzFBgQLwKAg7U8b0A==', N'cb39992e-8549-48b2-bad4-d41482ab3bcd', NULL, 0, 0, NULL, 1, 0, N'Admin')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ffecada-7cda-43f1-9edf-5cb0587eab42', N'admin@gmail.com', 0, N'AGFHk67PwvkjEGGoOTToIyMpqzAaWyi0u+duhcnImkR/feAb5pzFBgQLwKAg7U8b0A==', N'cb39992e-8549-48b2-bad4-d41482ab3bcd', NULL, 0, 0, NULL, 1, 0, N'omarshohid')
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (1, 4120, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0081.JPG', N'a', N'a', NULL, NULL, N'a', 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (2, 4120, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0094.JPG', N'a', N'a', NULL, NULL, N'a', 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (3, 4120, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0053.JPG', N'a', N'a', NULL, NULL, N'a', 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (4, 4120, N'http://mediagallery.scibd.info/2017/Child Protection/Event With media gallery/Thumbnail/DSC_3814.JPG', N'a', N'a', NULL, NULL, N'a', 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (5, 4120, N'http://mediagallery.scibd.info/2017/Child Protection/Event With media gallery/Thumbnail/DSC_3812.JPG', NULL, NULL, N'Shohid', 1, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (6, 4120, N'http://mediagallery.scibd.info/2017/Child Protection/Event With media gallery/Thumbnail/DSC_3813.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (7, 4120, N'http://mediagallery.scibd.info/2017/Child Protection/Event With media gallery/Thumbnail/DSC_3814.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (8, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0037.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (9, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0053.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (10, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0081.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (11, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0084.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (12, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0086.JPG', NULL, NULL, N'Shohid', 1, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (13, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0091.JPG', NULL, NULL, N'Shohid', 1, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (14, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0094.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (15, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0104.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (16, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0081.JPG', NULL, NULL, NULL, NULL, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (17, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0128.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (18, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0130.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
INSERT [dbo].[Images] ([ImageId], [EventId], [ImageUrl], [ImageTitle], [ImageDetails], [PC], [ImageLike], [ImageTag], [UploadedBy], [UploadDate], [IsApproved], [ApprovedBy], [ApproveDate]) VALUES (19, 4122, N'http://mediagallery.scibd.info/2017/Celebration/Childrens Day/Thumbnail/_DSC0137.JPG', NULL, NULL, N'Shohid', 0, NULL, 1111, CAST(N'2019-01-31 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2019-01-31 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Images] OFF
/****** Object:  StoredProcedure [dbo].[GetImageListforShow]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Exec GetImageListforShow 2,12,'','',''
-- Exec GetImageListforShow 1,12,'','',''
-- =============================================
CREATE PROCEDURE [dbo].[GetImageListforShow]
	@PageNo int,
	@PageSize int,
	@Category nvarchar(max),
	@FileName nvarchar(max),
	@TagName nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@PageNo = 0)
	BEGIN
		SET @PageNo = 1
	END

	SELECT 
		   [ImageId]
		  ,im.[EventId]
		  ,ISNULL(ev.[EventName],'') as [EventName]
		  ,[ImageUrl]
		  ,ISNULL([ImageTitle],'') as [ImageTitle]
		  ,ISNULL([ImageDetails],'') as [ImageDetails]
		  ,ISNULL([PC],'') as [PC]
		  ,[ImageLike]
		  ,ISNULL([ImageTag],'') as [ImageTag]
		  ,[UploadDate]
		  ,[IsApproved]
		  ,[ApproveDate]
		  --,'' as ous.UploadedBy
		  ,us.[UserName] as [ApprovedBy]
	FROM [dbo].[Images] im
	LEFT JOIN [dbo].[Events] ev on im.EventId = ev.EventId
	LEFT JOIN [dbo].[AspNetUsers] us on im.ApprovedBy = us.Id
	--LEFT JOIN OnDesk.dbo.AspNetUser ous on im.UploadedBy = ous.UserId
	
	WHERE IsApproved = 1
	ORDER BY ApproveDate DESC,ImageId,UploadDate
				   OFFSET @PageSize * (@PageNo - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY;
END

GO
/****** Object:  StoredProcedure [dbo].[GetTotalRecord]    Script Date: 8/18/2019 10:31:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Exec GetTotalRecord '','',''
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalRecord]
	@Category nvarchar(max),
	@FileName nvarchar(max),
	@TagName nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		   COUNT(*) as 'TotalRecord'
	FROM [dbo].[Images] WHERE IsApproved = 1
END

GO
USE [master]
GO
ALTER DATABASE [PhotoGallery] SET  READ_WRITE 
GO
