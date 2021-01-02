USE [FeedbackCollection]
GO
ALTER TABLE [dbo].[PostComment] DROP CONSTRAINT [FK_PostComment_User]
GO
ALTER TABLE [dbo].[PostComment] DROP CONSTRAINT [FK_PostComment_Post]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[CommentsStatus] DROP CONSTRAINT [FK_CommentsStatus_User]
GO
ALTER TABLE [dbo].[CommentsStatus] DROP CONSTRAINT [FK_CommentsStatus_PostComment]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/3/2021 12:19:56 AM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 1/3/2021 12:19:56 AM ******/
DROP TABLE [dbo].[PostComment]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 1/3/2021 12:19:56 AM ******/
DROP TABLE [dbo].[Post]
GO
/****** Object:  Table [dbo].[CommentsStatus]    Script Date: 1/3/2021 12:19:56 AM ******/
DROP TABLE [dbo].[CommentsStatus]
GO
/****** Object:  Table [dbo].[CommentsStatus]    Script Date: 1/3/2021 12:19:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentsStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[CommentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsLike] [bit] NOT NULL,
	[IsDislike] [bit] NOT NULL,
 CONSTRAINT [PK_CommentsStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 1/3/2021 12:19:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[PostDetails] [nvarchar](max) NOT NULL,
	[PostBy] [int] NOT NULL,
	[PostDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 1/3/2021 12:19:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[CommentId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[CommentsBy] [int] NOT NULL,
	[CommentsDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/3/2021 12:19:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Post] ON 
GO
INSERT [dbo].[Post] ([PostId], [PostDetails], [PostBy], [PostDate], [IsActive]) VALUES (1, N'post 1', 1, CAST(N'2021-01-02T23:51:11.773' AS DateTime), 1)
GO
INSERT [dbo].[Post] ([PostId], [PostDetails], [PostBy], [PostDate], [IsActive]) VALUES (2, N'Post 2', 1, CAST(N'2021-01-02T23:53:07.197' AS DateTime), 1)
GO
INSERT [dbo].[Post] ([PostId], [PostDetails], [PostBy], [PostDate], [IsActive]) VALUES (3, N'create post', 1, CAST(N'2021-01-02T23:59:34.277' AS DateTime), 1)
GO
INSERT [dbo].[Post] ([PostId], [PostDetails], [PostBy], [PostDate], [IsActive]) VALUES (4, N'Create post 2', 1, CAST(N'2021-01-03T00:00:16.733' AS DateTime), 1)
GO
INSERT [dbo].[Post] ([PostId], [PostDetails], [PostBy], [PostDate], [IsActive]) VALUES (5, N'Post 3', 1, CAST(N'2021-01-03T00:00:29.953' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (1, N'User1', N'1')
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (2, N'User2', N'2')
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (3, N'User3', N'3')
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (4, N'User4', N'4')
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (5, N'User5', N'5')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CommentsStatus]  WITH CHECK ADD  CONSTRAINT [FK_CommentsStatus_PostComment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[PostComment] ([CommentId])
GO
ALTER TABLE [dbo].[CommentsStatus] CHECK CONSTRAINT [FK_CommentsStatus_PostComment]
GO
ALTER TABLE [dbo].[CommentsStatus]  WITH CHECK ADD  CONSTRAINT [FK_CommentsStatus_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CommentsStatus] CHECK CONSTRAINT [FK_CommentsStatus_User]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([PostBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_User] FOREIGN KEY([CommentsBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_User]
GO
