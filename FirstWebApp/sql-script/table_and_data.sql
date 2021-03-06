USE [EF_CRUD]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2014/12/24 上午 10:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [nvarchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 2014/12/24 上午 10:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustId] [int] NOT NULL,
	[IsExpress] [bit] NOT NULL CONSTRAINT [DF_Order_IsExpress]  DEFAULT ((0)),
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2014/12/24 上午 10:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[Count] [smallint] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [CustName], [Created], [Modified]) VALUES (2, N'JimLin', CAST(N'2014-12-18 11:50:21.727' AS DateTime), CAST(N'2014-12-18 11:50:21.727' AS DateTime))
INSERT [dbo].[Customer] ([Id], [CustName], [Created], [Modified]) VALUES (6, N'LarrySu', CAST(N'2014-12-18 17:55:11.980' AS DateTime), CAST(N'2014-12-18 17:55:11.980' AS DateTime))
INSERT [dbo].[Customer] ([Id], [CustName], [Created], [Modified]) VALUES (10, N'Wei', CAST(N'2014-12-19 15:54:12.743' AS DateTime), CAST(N'2014-12-19 15:54:12.743' AS DateTime))
INSERT [dbo].[Customer] ([Id], [CustName], [Created], [Modified]) VALUES (14, N'AAB', CAST(N'2014-12-23 10:05:22.183' AS DateTime), CAST(N'2014-12-24 10:01:03.183' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustId], [IsExpress], [Created], [Modified]) VALUES (2, 2, 0, CAST(N'2014-12-18 17:14:41.263' AS DateTime), CAST(N'2014-12-18 17:14:41.263' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustId], [IsExpress], [Created], [Modified]) VALUES (4, 6, 1, CAST(N'2014-12-18 17:55:12.100' AS DateTime), CAST(N'2014-12-18 17:55:12.100' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustId], [IsExpress], [Created], [Modified]) VALUES (5, 2, 1, CAST(N'2014-12-19 10:25:12.117' AS DateTime), CAST(N'2014-12-19 10:25:12.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ItemName], [Count], [Created], [Modified]) VALUES (5, 2, N'連勝動', 50, CAST(N'2014-12-18 17:14:41.437' AS DateTime), CAST(N'2014-12-18 17:14:41.437' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ItemName], [Count], [Created], [Modified]) VALUES (6, 5, N'排骨飯', 1, CAST(N'2014-12-18 17:14:41.437' AS DateTime), CAST(N'2014-12-18 17:14:41.437' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ItemName], [Count], [Created], [Modified]) VALUES (7, 4, N'蒜頭', 2, CAST(N'2014-12-18 17:55:12.117' AS DateTime), CAST(N'2014-12-18 17:55:12.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
