USE [NC_DB]
GO
/****** Object:  Table [dbo].[Criminal]    Script Date: 02-12-2015 14:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Criminal](
	[Id] [bigint] NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[LName] [varchar](50) NULL,
	[Age] [int] NULL,
	[Sex] [varchar](10) NULL,
	[Height] [varchar](10) NULL,
	[Weight] [float] NULL,
	[Nationality] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 02-12-2015 14:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[LName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [FName], [LName], [Email], [Password]) VALUES (1, N'Aslam', N'Shaikh', N'shmoaslam@gmail.com', N'123456789')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
