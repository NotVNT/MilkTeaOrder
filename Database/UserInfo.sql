USE [UserInfo]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 12/22/2024 12:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[IdCTHD] [varchar](50) NOT NULL,
	[IdHoaDon] [varchar](50) NULL,
	[IdDrink] [varchar](50) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[IdCTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drink]    Script Date: 12/22/2024 12:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drink](
	[IdDrink] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[price] [money] NULL,
	[idLoai] [varchar](50) NULL,
 CONSTRAINT [PK_Drink] PRIMARY KEY CLUSTERED 
(
	[IdDrink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/22/2024 12:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[idHoaDon] [varchar](50) NOT NULL,
	[NgayinHoaDon] [datetime] NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 12/22/2024 12:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[idLoai] [varchar](50) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[idLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/22/2024 12:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserInfo] ([UserName], [Password], [Email], [Role]) VALUES (N'admin', N'admin123', N'admin123@gmail.com', N'Admin')
INSERT [dbo].[UserInfo] ([UserName], [Password], [Email], [Role]) VALUES (N'leanhthien', N'leanhthien123456', N'leanhthien123@gmail.com', NULL)
INSERT [dbo].[UserInfo] ([UserName], [Password], [Email], [Role]) VALUES (N'not_vnt', N'vinhngoctran', N'vinhngoctran137@gmail.com', N'Người dùng')
INSERT [dbo].[UserInfo] ([UserName], [Password], [Email], [Role]) VALUES (N'not_vnt123', N'vinhdaica113', N'not_vnt123@gmail.com', N'Nhân Viên')
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_Drink] FOREIGN KEY([IdDrink])
REFERENCES [dbo].[Drink] ([IdDrink])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_Drink]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HoaDon] FOREIGN KEY([IdHoaDon])
REFERENCES [dbo].[HoaDon] ([idHoaDon])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_HoaDon]
GO
ALTER TABLE [dbo].[Drink]  WITH CHECK ADD  CONSTRAINT [FK_Drink_Loai] FOREIGN KEY([idLoai])
REFERENCES [dbo].[Loai] ([idLoai])
GO
ALTER TABLE [dbo].[Drink] CHECK CONSTRAINT [FK_Drink_Loai]
GO
