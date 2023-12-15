
USE [master]
GO

/****** Object:  Database [pleberr]    Script Date: 23.10.2017 16:19:01 ******/
CREATE DATABASE [pleberr]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Database', FILENAME = N'C:\inetpub\wwwroot\portfolio\pleberr\App_Data\Database.mdf' , SIZE = 3200KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Database_log', FILENAME = N'C:\inetpub\wwwroot\portfolio\pleberr\App_Data\Database_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [pleberr] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pleberr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [pleberr] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [pleberr] SET ANSI_NULLS OFF
GO

ALTER DATABASE [pleberr] SET ANSI_PADDING OFF
GO

ALTER DATABASE [pleberr] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [pleberr] SET ARITHABORT OFF
GO

ALTER DATABASE [pleberr] SET AUTO_CLOSE ON
GO

ALTER DATABASE [pleberr] SET AUTO_SHRINK ON
GO

ALTER DATABASE [pleberr] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [pleberr] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [pleberr] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [pleberr] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [pleberr] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [pleberr] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [pleberr] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [pleberr] SET  DISABLE_BROKER
GO

ALTER DATABASE [pleberr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [pleberr] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [pleberr] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [pleberr] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [pleberr] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [pleberr] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [pleberr] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [pleberr] SET RECOVERY SIMPLE
GO

ALTER DATABASE [pleberr] SET  MULTI_USER
GO

ALTER DATABASE [pleberr] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [pleberr] SET DB_CHAINING OFF
GO

ALTER DATABASE [pleberr] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [pleberr] SET TARGET_RECOVERY_TIME = 0 SECONDS
GO

ALTER DATABASE [pleberr] SET DELAYED_DURABILITY = DISABLED
GO

ALTER DATABASE [pleberr] SET QUERY_STORE = OFF
GO

USE [pleberr]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

USE [pleberr]
GO

/****** Object:  Table [dbo].[Comment]    Script Date: 23.10.2017 16:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Message]    Script Date: 23.10.2017 16:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Post]    Script Date: 23.10.2017 16:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Request]    Script Date: 23.10.2017 16:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Setting]    Script Date: 23.10.2017 16:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[User]    Script Date: 23.10.2017 16:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[Comment] ON
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2076, 1106, 1000001052, N'comment one', 1000001061, N'Joe Mustermann', CAST(N'2016-11-07T20:03:52.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2077, 1106, 1000001052, N'comment 2', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:04:17.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2078, 1106, 1000001052, N'comment three', 1000001061, N'Joe Mustermann', CAST(N'2016-11-07T20:04:30.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2079, 1115, 0, N'this is a comment', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:05:16.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2080, 1103, 0, N'test comment', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:05:27.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2081, 1103, 0, N'test', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:06:18.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2082, 1103, 1000001052, N'test', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:15:47.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2083, 1103, 1000001052, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:16:36.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2084, 1103, 1000001052, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:16:49.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2085, 1103, 1000001052, N'test', 1000001061, N'Joe Mustermann', CAST(N'2016-11-07T20:17:02.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2086, 1116, 1000001061, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:18:21.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2087, 1117, 1000001052, N'nice job posting your experiences', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:23:49.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2088, 1115, 1000001061, N'a very nice car in this picture', 1000001052, N'Loukas Anastasiou', CAST(N'2016-11-07T20:38:03.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2089, 1116, 1000001061, N'test 2', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:39:42.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2090, 1115, 1000001061, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:48:13.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2091, 1115, 1000001061, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:54:07.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2092, 1115, 1000001061, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:54:43.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2093, 1118, 1000001052, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:54:53.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2094, 1116, 1000001061, N'test', 1000001052, N'Joe Mustermann', CAST(N'2016-11-07T20:55:05.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2095, 1119, 1000001061, N'this is a test comment to test the site&rsquo;s backend.', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:56:42.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2096, 1100, 1000001052, N'very beautiful picture', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-07T20:57:26.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2097, 1121, 1000001061, N'nice image', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T07:58:48.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2098, 1123, 1000001062, N'nice post dude!!!', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T08:45:24.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2099, 1145, 1000001052, N'thi is a comment', 1000001052, N'Joe Mustermann', CAST(N'2016-11-08T10:53:13.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2100, 1147, 1000001061, N'this is my comment for this post, thank you for reading', 1000001052, N'Joe Mustermann', CAST(N'2016-11-08T10:53:53.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2101, 1154, 1000001052, N'this is a video from a company in Germany.', 1000001052, N'Joe Mustermann', CAST(N'2016-11-08T11:03:45.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2102, 1156, 1000001061, N'nice image', 1000001052, N'Joe Mustermann', CAST(N'2016-11-08T11:13:11.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2103, 1162, 1000001052, N'very good choice for a share...', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T11:15:43.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2104, 1165, 1000001061, N'nice post', 1000001052, N'Joe Mustermann', CAST(N'2016-11-08T15:30:25.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2105, 1165, 1000001061, N'hello', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T18:41:27.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2106, 1155, 1000001052, N'hello', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T19:00:26.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2107, 1167, 1000001052, N'comment', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T19:02:37.000' AS DateTime))
GO

INSERT [dbo].[Comment] ([Id], [Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES (2108, 1166, 1000001061, N'very nice image', 1000001061, N'Loukas Anastasiou', CAST(N'2016-11-08T19:42:05.000' AS DateTime))
GO

SET IDENTITY_INSERT [dbo].[Comment] OFF
GO

SET IDENTITY_INSERT [dbo].[Message] ON
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (56, 1000001061, 1000001052, CAST(N'2016-11-08T14:24:26.000' AS DateTime), N'test', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (57, 1000001061, 1000001052, CAST(N'2016-11-08T14:42:38.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (58, 1000001052, 1000001061, CAST(N'2016-11-08T14:42:52.000' AS DateTime), N'hello there', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (59, 1000001061, 1000001062, CAST(N'2016-11-08T14:45:25.000' AS DateTime), N'hello', 0)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (60, 1000001061, 1000001052, CAST(N'2016-11-08T14:49:54.000' AS DateTime), N'this is a test message for Joe...', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (61, 1000001052, 1000001062, CAST(N'2016-11-08T15:04:40.000' AS DateTime), N'hello there', 0)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (62, 1000001052, 1000001061, CAST(N'2016-11-08T15:05:32.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (63, 1000001052, 1000001061, CAST(N'2016-11-08T15:20:45.000' AS DateTime), N'helo', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (64, 1000001061, 1000001052, CAST(N'2016-11-08T15:23:10.000' AS DateTime), N'hello there', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (65, 1000001061, 1000001052, CAST(N'2016-11-08T15:23:30.000' AS DateTime), N'test', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (66, 1000001061, 1000001052, CAST(N'2016-11-08T15:23:41.000' AS DateTime), N'test2', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (67, 1000001052, 1000001062, CAST(N'2016-11-08T15:24:54.000' AS DateTime), N'hi', 0)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (68, 1000001061, 1000001062, CAST(N'2016-11-08T15:29:00.000' AS DateTime), N'hello there', 0)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (69, 1000001061, 1000001052, CAST(N'2016-11-08T15:34:09.000' AS DateTime), N'hello again', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (70, 1000001052, 1000001061, CAST(N'2016-11-08T15:34:15.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (71, 1000001061, 1000001052, CAST(N'2016-11-08T15:40:47.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (72, 1000001052, 1000001061, CAST(N'2016-11-08T15:40:56.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (73, 1000001052, 1000001061, CAST(N'2016-11-08T15:41:11.000' AS DateTime), N'test message', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (74, 1000001061, 1000001052, CAST(N'2016-11-08T18:57:50.000' AS DateTime), N'hello', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (75, 1000001061, 1000001052, CAST(N'2016-11-08T18:58:01.000' AS DateTime), N'hello vasiliki', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (76, 1000001052, 1000001061, CAST(N'2016-11-08T18:58:13.000' AS DateTime), N'hallo Loukas', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (77, 1000001052, 1000001061, CAST(N'2016-11-08T18:59:22.000' AS DateTime), N'Hello Loukas Anastasiou', 1)
GO

INSERT [dbo].[Message] ([Id], [From], [To], [DateCreated], [Content], [Read]) VALUES (78, 1000001052, 1000001061, CAST(N'2016-11-08T19:07:32.000' AS DateTime), N'hello', 1)
GO

SET IDENTITY_INSERT [dbo].[Message] OFF
GO

SET IDENTITY_INSERT [dbo].[Post] ON
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1145, 1000001052, 1000001052, CAST(N'2016-11-08T10:47:58.000' AS DateTime), N'this is a test', 0, N'text', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1147, 1000001061, 1000001052, CAST(N'2016-11-08T10:47:58.000' AS DateTime), N'this is a test', 1, N'text', N'1000001052 1000001061', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1148, 1000001052, 1000001052, CAST(N'2016-11-08T10:56:48.000' AS DateTime), N'<img class="img-post" src="../../1000001052/p2.jpg" alt="" style="width:100%;cursor:pointer;" />', 0, N'image', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1150, 1000001061, 1000001061, CAST(N'2016-11-08T11:00:01.000' AS DateTime), N'<iframe style="height:278px;width:100%;max-width:100%;border:0;" frameborder="0" src="https://www.youtube.com/embed/03Jy2eek0_4?hl=en&amp;autoplay=0&amp;cc_load_policy=0&amp;loop=0&amp;iv_load_policy=0&amp;fs=1&amp;showinfo=0"></iframe>', 0, N'video', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1151, 1000001061, 1000001061, CAST(N'2016-11-08T11:01:16.000' AS DateTime), N'This is my new post to test the websites fron end. Thank you for reading my posts every day, my name is Loukas and I am a 34 year old developer from München Germany.', 0, N'text', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1152, 1000001052, 1000001052, CAST(N'2016-11-08T11:02:06.000' AS DateTime), N'<img class="img-post" src="../../1000001052/p8.jpg" alt="" style="width:100%;cursor:pointer;" />', 0, N'image', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1153, 1000001052, 1000001052, CAST(N'2016-11-08T11:03:23.000' AS DateTime), N'This is my first test post...', 0, N'text', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1154, 1000001052, 1000001052, CAST(N'2016-11-08T11:03:28.000' AS DateTime), N'<iframe style="height:278px;width:100%;max-width:100%;border:0;" frameborder="0" src="https://www.youtube.com/embed/XUmIrG62za8?hl=en&amp;autoplay=0&amp;cc_load_policy=0&amp;loop=0&amp;iv_load_policy=0&amp;fs=1&amp;showinfo=0"></iframe>', 0, N'video', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1155, 1000001052, 1000001052, CAST(N'2016-11-08T11:05:28.000' AS DateTime), N'This is my first test post... thank you for reading', 0, N'text', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1162, 1000001052, 1000001061, CAST(N'2016-11-08T11:08:52.000' AS DateTime), N'<img class="img-post" src="../../1000001061/31.-LOVE.jpg" alt="" style="width:100%;cursor:pointer;" />', 0, N'image', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1163, 1000001061, 1000001061, CAST(N'2016-11-08T15:26:49.000' AS DateTime), N'<img class="img-post" src="../../1000001061/0ec7ad33875372.56d84f815729f.jpg" alt="" style="width:100%;cursor:pointer;" />', 0, N'image', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1164, 1000001061, 1000001061, CAST(N'2016-11-08T15:27:36.000' AS DateTime), N'This is the final message during the production period... Thank you very much', 0, N'text', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1165, 1000001061, 1000001061, CAST(N'2016-11-08T15:28:43.000' AS DateTime), N'stest
awrwrw', 0, N'text', N'1000001061', N'public', N'Loukas Anastasiou')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1166, 1000001061, 1000001052, CAST(N'2016-11-08T11:02:06.000' AS DateTime), N'<img class="img-post" src="../../1000001052/p8.jpg" alt="" style="width:100%;cursor:pointer;" />', 0, N'image', N'1000001052', N'public', N'Joe Mustermann')
GO

INSERT [dbo].[Post] ([Id], [Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES (1167, 1000001052, 1000001052, CAST(N'2016-11-08T19:02:12.000' AS DateTime), N'ich bin caffee trinken', 1, N'text', N'1000001052 1000001061', N'public', N'Joe Mustermann')
GO

SET IDENTITY_INSERT [dbo].[Post] OFF
GO

SET IDENTITY_INSERT [dbo].[Request] ON
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (2, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (3, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (4, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (5, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (6, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (7, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (8, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (9, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (10, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (11, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (12, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (13, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (14, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (15, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (16, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (17, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (18, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (19, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (20, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (21, 1000001052, 1000001061, 1, 1, 0, N'Loukas Anastasiou', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (22, 1000001061, 1000001052, 1, 1, 0, N'Loukas Anastasiou', N'Joe Mustermann')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (23, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (24, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (25, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (26, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (27, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (28, 1000001062, 1000001052, 1, 1, 0, N'Loukas Mustermann', N'Joe Mustermann')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (29, 1000001062, 1000001061, 1, 1, 0, N'Loukas Mustermann', N'Loukas Anastasiou')
GO

INSERT [dbo].[Request] ([Id], [From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) VALUES (30, 1000001052, 1000001061, 1, 1, 0, N'Joe Mustermann', N'Loukas Anastasiou')
GO

SET IDENTITY_INSERT [dbo].[Request] OFF
GO

SET IDENTITY_INSERT [dbo].[Setting] ON
GO

INSERT [dbo].[Setting] ([Id], [User], [PostsPrivacy], [InfoPrivacy], [FriendsPrivacy], [PicturesPrivacy]) VALUES (2, 1000001061, 0, 0, 0, 0)
GO

INSERT [dbo].[Setting] ([Id], [User], [PostsPrivacy], [InfoPrivacy], [FriendsPrivacy], [PicturesPrivacy]) VALUES (3, 1000001052, 0, 0, 0, 0)
GO

SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

SET IDENTITY_INSERT [dbo].[User] ON
GO

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [School], [Work], [Location], [Relationship], [Birthdate], [Weight], [Height], [Friends], [Password], [Online], [Gender], [Email2], [Telephone]) VALUES (1000001052, N'Joe', N'Mustermann', N'loukas@anastasiou.email', N'Your school', N'Your work', N'Your current location', N'Your relationship status', CAST(N'2017-01-01T00:00:00.000' AS DateTime), 90, 0, N' 1000001062 1000001061', N'3f0892993bdb93f81b767e7c58fcdb0d60d4907d3addee3c09d00041b586c1445e49f9c2b6468a90ce83e4bc1aed5571', 1, NULL, NULL, NULL)
GO

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [School], [Work], [Location], [Relationship], [Birthdate], [Weight], [Height], [Friends], [Password], [Online], [Gender], [Email2], [Telephone]) VALUES (1000001061, N'Loukas', N'Anastasiou', N'hallo@loukasanast.de', N'Brunel University', N'IBM London', N'Munich, Germany', N'Single', CAST(N'1982-08-23T00:00:00.000' AS DateTime), 100, 1.76, N' 1000001062 1000001052', N'3f0892993bdb93f81b767e7c58fcdb0d60d4907d3addee3c09d00041b586c1445e49f9c2b6468a90ce83e4bc1aed5571', 1, N'Male', N'test@test.de', N'000 555')
GO

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [School], [Work], [Location], [Relationship], [Birthdate], [Weight], [Height], [Friends], [Password], [Online], [Gender], [Email2], [Telephone]) VALUES (1000001062, N'Loukas', N'Mustermann', N'test@test.de', N'Your school', N'Your work', N'Your current location', N'Your relationship status', CAST(N'3016-08-11T08:17:17.000' AS DateTime), 0, 0, N' 1000001052 1000001061', N'3f0892993bdb93f81b767e7c58fcdb0d60d4907d3addee3c09d00041b586c1445e49f9c2b6468a90ce83e4bc1aed5571', 0, NULL, NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[User] OFF
GO

USE [master]
GO

ALTER DATABASE [pleberr] SET  READ_WRITE
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;

GO

--Syntaxfehler: Incorrect syntax near IDENTITY_CACHE.
--ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;



GO
