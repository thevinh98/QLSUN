USE [QLSUN]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[IdChucVu] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenChucVu] [nvarchar](50) NOT NULL,
	[LuongThang] [decimal](8, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdLichGiangDay] [uniqueidentifier] NOT NULL,
	[IdNhapHoc] [uniqueidentifier] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DotKiemTra]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DotKiemTra](
	[IdDotKiemTra] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Ten] [nvarchar](50) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDotKiemTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DotTuyenSinh]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DotTuyenSinh](
	[IdDotTuyenSinh] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenDotTuyenSinh] [nvarchar](50) NULL,
	[ThoiGian] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[NoiDung] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDotTuyenSinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[IdGiaoVien] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[HoTen] [nvarchar](50) NULL,
	[NamSinh] [datetime] NOT NULL,
	[TrinhDo] [nvarchar](50) NULL,
	[SDT] [varchar](15) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [varchar](50) NULL,
	[NgayVaoLam] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GioiTinh] [nvarchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGiaoVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HocPhi]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhi](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdNhapHoc] [uniqueidentifier] NOT NULL,
	[TienThanhToan] [decimal](8, 0) NULL,
	[GiamTru] [decimal](8, 0) NULL,
	[ThoiGianDong] [datetime] NOT NULL,
	[HanDong] [datetime] NOT NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HocVien](
	[IdHocVien] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[HoTen] [nvarchar](50) NULL,
	[NamSinh] [datetime] NOT NULL,
	[SDT] [varchar](15) NULL,
	[FaceBook] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[GhiChu] [ntext] NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GioiTinh] [nvarchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KetQuaHocTap]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaHocTap](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdDotKiemTra] [uniqueidentifier] NOT NULL,
	[IdNhapHoc] [uniqueidentifier] NOT NULL,
	[Diem] [nvarchar](5) NULL,
	[GhiChu] [ntext] NULL,
	[ThoiGian] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KetQuaTuyenSinh]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaTuyenSinh](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdDotTuyenSinh] [uniqueidentifier] NOT NULL,
	[IdHocVien] [uniqueidentifier] NOT NULL,
	[DiemNghe] [nvarchar](5) NULL,
	[DiemNoi] [nvarchar](5) NULL,
	[DiemDoc] [nvarchar](5) NULL,
	[DiemViet] [nvarchar](5) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[IdKhoaHoc] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenKhoaHoc] [nvarchar](50) NULL,
	[GhiChu] [ntext] NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichGiangDay]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichGiangDay](
	[IdLichGiangDay] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdLop] [uniqueidentifier] NOT NULL,
	[IdPhongHoc] [uniqueidentifier] NOT NULL,
	[IdGiaoVien] [uniqueidentifier] NOT NULL,
	[BuoiHoc] [nvarchar](20) NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[SoGio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLichGiangDay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[IdLop] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdKhoaHoc] [uniqueidentifier] NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[SoBuoiHoc] [int] NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[HocVienToiDa] [int] NULL,
	[GhiChu] [ntext] NULL,
	[HocPhiLop] [decimal](8, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDungADM]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDungADM](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](30) NULL,
	[TrangThai] [bit] NULL,
	[IdNhanVien] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDungGiaoVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDungGiaoVien](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](30) NULL,
	[TrangThai] [bit] NULL,
	[IdGiaoVien] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDungHocVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDungHocVien](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](30) NULL,
	[TrangThai] [bit] NULL,
	[IdHocVien] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdChucVu] [uniqueidentifier] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NamSinh] [datetime] NOT NULL,
	[SDT] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[NgayVaoLam] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GioiTinh] [nvarchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhapHoc]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapHoc](
	[IdNhapHoc] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdHocVien] [uniqueidentifier] NOT NULL,
	[IdLop] [uniqueidentifier] NOT NULL,
	[GhiChu] [ntext] NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNhapHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[IdPhongHoc] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[SoPhong] [varchar](10) NULL,
	[GhiChu] [ntext] NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPhongHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongBaoGiaoVien]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBaoGiaoVien](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdGiaoVien] [uniqueidentifier] NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
	[ThoiGian] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBaoLop]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBaoLop](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[IdLop] [uniqueidentifier] NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
	[ThoiGian] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuChi]    Script Date: 2020-07-06 3:12:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuChi](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[TenKhoanChi] [nvarchar](50) NULL,
	[SoTien] [decimal](8, 0) NULL,
	[NoiDung] [ntext] NULL,
	[ThoiGian] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ChucVu] ([IdChucVu], [TenChucVu], [LuongThang]) VALUES (N'5f95925a-f9d3-4951-8f26-1ea0bbe80fe0', N'Kế Toán', CAST(6600000 AS Decimal(8, 0)))
INSERT [dbo].[ChucVu] ([IdChucVu], [TenChucVu], [LuongThang]) VALUES (N'a988baa2-a29a-4db5-a03a-3c3655b2e42a', N'ADMIN', CAST(8000000 AS Decimal(8, 0)))
INSERT [dbo].[ChucVu] ([IdChucVu], [TenChucVu], [LuongThang]) VALUES (N'69121893-3afc-4f92-85f3-40bb5e7c7e29', N'Quản Lý Nhân Sự', CAST(8000000 AS Decimal(8, 0)))
INSERT [dbo].[ChucVu] ([IdChucVu], [TenChucVu], [LuongThang]) VALUES (N'7ee4e41c-abb8-433f-a7d7-f76c92a1124f', N'Nhân Viên Vệ Sinh', CAST(8000000 AS Decimal(8, 0)))
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'd0a01e54-aa89-4ece-b4f7-05b98fb8c297', N'7cb18b55-44fd-49e0-82b3-2cbd3049f78c', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'd00c72b1-cd16-4375-b0f9-089bf27ae9af', N'5d6e8d08-374f-4d26-9b7e-e05e202317d7', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Có', NULL)
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'37d12530-282a-4a9b-a411-13abeb0144ac', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'08d388ce-8914-4d5e-af4b-a0062e76cf64', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'd07e82ad-7442-4181-997c-1f2b17bd1339', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'908d01ce-8419-4cb7-a741-970b0f9762e6', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'244f0d7b-0ac1-4813-a196-2ee7353b38cb', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'1daac8e2-71dc-4eb8-ad8d-b58e55c575d2', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'ccd2a484-f4be-4792-bcf0-30b7a8f3f9da', N'e0a06e14-c5c0-4145-9c80-d6e18b07893c', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Không', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'6b045c85-4822-4772-a7f8-30d306f60a5f', N'f6405536-af2c-4c0c-a346-998e30d608db', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'2811a187-5ba6-415e-b919-3c11c4057acb', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'9897fa1c-972e-486d-bef9-c35d2deff44c', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'1a46c823-07f7-476b-bf1a-6fc78692c205', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'699fd5b8-c8cd-40d8-bd57-007a6632b967', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'ed46e716-3453-4ab5-930d-77a085c86ebf', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'bf229953-57e5-415f-a7f1-a6d0cc28b588', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'53f5fe7f-7d5a-4a70-92a5-8ea8428f569f', N'e92720ef-8556-4174-aba1-a93d3387cb33', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'd7377b6d-58ab-41f9-b359-a1c036c184eb', N'5d6e8d08-374f-4d26-9b7e-e05e202317d7', N'9897fa1c-972e-486d-bef9-c35d2deff44c', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'781036e2-7742-43b9-992b-aa322b953768', N'5d6e8d08-374f-4d26-9b7e-e05e202317d7', N'9897fa1c-972e-486d-bef9-c35d2deff44c', N'Có', N'')
INSERT [dbo].[DiemDanh] ([Id], [IdLichGiangDay], [IdNhapHoc], [TrangThai], [GhiChu]) VALUES (N'b3870764-4a51-4adf-a837-ccb43d832536', N'59e6375d-5341-4bdb-adee-6d3624dce186', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'Có', N'')
INSERT [dbo].[DotKiemTra] ([IdDotKiemTra], [Ten], [GhiChu]) VALUES (N'a99a279e-86c1-4804-ba78-70c2d9dd72cb', N'Kiểm Tra Lần 1', N'Kiểm tra Nghe')
INSERT [dbo].[DotKiemTra] ([IdDotKiemTra], [Ten], [GhiChu]) VALUES (N'b7b34bc1-48c0-469c-8a7e-bb928a469060', N'Kiểm Tra Lần 2', N'Kiểm tra Nói 1')
INSERT [dbo].[DotTuyenSinh] ([IdDotTuyenSinh], [TenDotTuyenSinh], [ThoiGian], [TrangThai], [NoiDung]) VALUES (N'5bddc2c3-5b1a-4f06-a5b4-022985d1b323', N'Tuyển Sinh Lần 2', CAST(N'2019-04-01 08:00:00.000' AS DateTime), N'Đã Xong', N'test nghe')
INSERT [dbo].[DotTuyenSinh] ([IdDotTuyenSinh], [TenDotTuyenSinh], [ThoiGian], [TrangThai], [NoiDung]) VALUES (N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'Tuyển Sinh Lần 4', CAST(N'2020-04-01 08:00:00.000' AS DateTime), N'Sắp Tuyển Sinh', N'đợt tuyển sinh này gồm các phần nghe và nói')
INSERT [dbo].[DotTuyenSinh] ([IdDotTuyenSinh], [TenDotTuyenSinh], [ThoiGian], [TrangThai], [NoiDung]) VALUES (N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'Tuyển Sinh Lần 1', CAST(N'2019-01-01 08:00:00.000' AS DateTime), N'Đã Xong', N'đợt tuyển sinh này gồm các phần nghe và nói')
INSERT [dbo].[DotTuyenSinh] ([IdDotTuyenSinh], [TenDotTuyenSinh], [ThoiGian], [TrangThai], [NoiDung]) VALUES (N'41d77576-0f55-4e64-83c5-bf691e837023', N'Tuyển Sinh Lần 3', CAST(N'2020-01-01 08:00:00.000' AS DateTime), N'Đã Xong', N'đợt tuyển sinh này gồm các phần nghe và nói')
INSERT [dbo].[GiaoVien] ([IdGiaoVien], [HoTen], [NamSinh], [TrinhDo], [SDT], [DiaChi], [Email], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'41b17291-2760-4612-ab77-19137a7976bf', N'Lê Thị Nhung', CAST(N'1990-02-02 00:00:00.000' AS DateTime), N'Thạc Sỹ', N'0347830088', N'24 nguyễn khuyến-vĩnh hải-nha trang-khánh hòa', N'lethinhung@gmail.com', CAST(N'2016-03-04 00:00:00.000' AS DateTime), N'Đang Làm', N'Nữ')
INSERT [dbo].[GiaoVien] ([IdGiaoVien], [HoTen], [NamSinh], [TrinhDo], [SDT], [DiaChi], [Email], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'd36f22b4-3c7e-44a4-b389-45c9b6be0902', N'Lê Thị Hiền', CAST(N'1989-02-01 00:00:00.000' AS DateTime), N'Giáo Sư', N'0987654363', N'phường vĩnh hải - Nha Trang', N'letthihien@gmail.com', CAST(N'2016-02-02 00:00:00.000' AS DateTime), N'Đang Làm', N'Nữ')
INSERT [dbo].[GiaoVien] ([IdGiaoVien], [HoTen], [NamSinh], [TrinhDo], [SDT], [DiaChi], [Email], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Trịnh Văn Bình', CAST(N'1989-05-03 00:00:00.000' AS DateTime), N'Giáo Sư', N'0987654353', N'vĩnh hải - Nha Trang', N'trinhvanbinh@gmail.com', CAST(N'2018-05-05 00:00:00.000' AS DateTime), N'Đang Làm', N'Nam')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'3642af11-1f9f-49a5-be2d-0a964fc55ccd', N'7aa6d0ce-1a92-4ab9-9219-a7ae4869ca95', CAST(54545 AS Decimal(8, 0)), CAST(500000 AS Decimal(8, 0)), CAST(N'2020-05-29 00:00:00.000' AS DateTime), CAST(N'2020-05-30 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'07f5e223-7c06-4ce2-b870-3f390cc3dcec', N'6f55145c-2f30-4af5-b76d-5b7337be1346', CAST(100000 AS Decimal(8, 0)), CAST(500000 AS Decimal(8, 0)), CAST(N'2020-05-06 00:00:00.000' AS DateTime), CAST(N'2020-05-05 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'3b70a5f6-4d87-4fb8-b027-4678172ae6e6', N'6f55145c-2f30-4af5-b76d-5b7337be1346', CAST(1000000 AS Decimal(8, 0)), CAST(500000 AS Decimal(8, 0)), CAST(N'2020-03-03 00:00:00.000' AS DateTime), CAST(N'2020-05-05 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'9f82f8a0-716b-412a-bbe2-48e6b79e70ce', N'08d388ce-8914-4d5e-af4b-a0062e76cf64', CAST(5500000 AS Decimal(8, 0)), CAST(0 AS Decimal(8, 0)), CAST(N'2020-06-18 00:00:00.000' AS DateTime), CAST(N'2020-06-17 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'e3a20b96-7ab0-4f60-8611-aad28dcc92bf', N'7aa6d0ce-1a92-4ab9-9219-a7ae4869ca95', CAST(445455 AS Decimal(8, 0)), CAST(500000 AS Decimal(8, 0)), CAST(N'2020-05-12 00:00:00.000' AS DateTime), CAST(N'2020-05-30 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocPhi] ([Id], [IdNhapHoc], [TienThanhToan], [GiamTru], [ThoiGianDong], [HanDong], [GhiChu]) VALUES (N'0505d8b1-1527-40f4-aa15-bf53d189a403', N'7aa6d0ce-1a92-4ab9-9219-a7ae4869ca95', CAST(1000000 AS Decimal(8, 0)), CAST(500000 AS Decimal(8, 0)), CAST(N'2020-05-05 00:00:00.000' AS DateTime), CAST(N'2020-05-30 00:00:00.000' AS DateTime), N'')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'b2afa4f5-d75c-48c8-a76c-00feab44acda', N'Phùng Thanh Phương', CAST(N'2000-01-12 00:00:00.000' AS DateTime), N'0984654353', N'Thanh Phương', N'phungthanhphuong@gmail.com', N'Hà nội', N'', N'Tuyển Sinh', N'Nam')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'b3ad0a7e-3317-406a-85cc-0d6d68c10e7a', N'Trần Nam', CAST(N'2020-05-12 00:00:00.000' AS DateTime), N'0987654354', N'Trần Nam', N'trannam@gmail.com', N'Nha Trang', N'', N'Tuyển Sinh', N'Nam')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'56a3819f-ad28-4956-a97f-1b829cd80be0', N'Trần Thị Huyền', CAST(N'2000-01-23 00:00:00.000' AS DateTime), N'0347865599', N'Huyền', N'trangthihuyen@gmail.com', N'Huế', N'', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'ec21a30d-f5d7-413a-8ee9-26ae3ae0ded8', N'Tuyết minh', CAST(N'2020-05-05 00:00:00.000' AS DateTime), N'0987654353', N'Thu Hành', N'Nguyenthibay@gmail.com', N'Nha Trang', N'ded', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'3d31ce97-4497-4f1b-978a-59c276bb41ad', N'Nguyễn Thị Bảy', CAST(N'2020-05-13 00:00:00.000' AS DateTime), N'0987654354', N'Bảy Lúa', N'Nguyenthibay@gmail.com', N'Nha Trang', N'ui', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'81371f6d-9383-49f8-98b7-63e57a79e78b', N'Phùng Thị Lý', CAST(N'2001-04-03 00:00:00.000' AS DateTime), N'0356754764', N'Phùng Lý', N'phungthily@gmail.com', N'Hải Phòng', N'', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'6a0a8924-fc89-455a-b2ba-7f885be93c06', N'Phan Quang Nam', CAST(N'1998-06-05 00:00:00.000' AS DateTime), N'097654337', N'Nam', N'phanquangnam@gmail.com', N'Bình Định', N'', N'Tuyển Sinh', N'Nam')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'1c6afbc4-9ae2-4c7e-8823-94f61a2f1378', N'Lê Thị Thu Hà', CAST(N'2002-01-01 00:00:00.000' AS DateTime), N'0347939988', N'Thu Hà', N'lethithuha@gmail.com', N'vĩnh hải - Nha Trang', N'', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'95d6db69-ba36-4142-8f38-95801a82c9d7', N'Nguyễn Thị Thu Ngân', CAST(N'1996-09-07 00:00:00.000' AS DateTime), N'0987054353', N'Thu Ngân', N'nguyenthithungan96@gmail.com', N'34-Trần Hưng Đạo-NhaTrang', N'', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'e325b5e7-d134-48f8-b07d-bb3b4a567b1c', N'Lê Thị Quỳnh Anh', CAST(N'2003-06-12 00:00:00.000' AS DateTime), N'012345679', N'Quỳnh Anh', N'quynhanh@gmail.com', N'Cam Ranh- Khánh Hòa', N'Học viên tuyển sinh', N'Tuyển Sinh', N'Nữ')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'2b80b7cc-a64f-43be-bb33-c3c1357a8a69', N'Lê Nam', CAST(N'2020-05-07 00:00:00.000' AS DateTime), N'0987654353', N'Lê Nam', N'LeNam@gmail.com', N'Nha Trang', N'', N'Tuyển Sinh', N'Nam')
INSERT [dbo].[HocVien] ([IdHocVien], [HoTen], [NamSinh], [SDT], [FaceBook], [Email], [DiaChi], [GhiChu], [TrangThai], [GioiTinh]) VALUES (N'ca7a7827-e9e3-4e98-80ab-de5154960d39', N'Hoàng Sơn', CAST(N'2000-06-16 00:00:00.000' AS DateTime), N'0987684354', N'Hoàng Sơn', N'hoanson@gmail.com', N'vĩnh hải - Nha Trang', N'đang tuyển sinh', N'Tuyển Sinh', N'Nam')
INSERT [dbo].[KetQuaHocTap] ([Id], [IdDotKiemTra], [IdNhapHoc], [Diem], [GhiChu], [ThoiGian]) VALUES (N'88cf30dd-c539-4489-9a33-2a790cefee36', N'b7b34bc1-48c0-469c-8a7e-bb928a469060', N'7aa6d0ce-1a92-4ab9-9219-a7ae4869ca95', N'9', N'', CAST(N'2020-05-13 00:00:00.000' AS DateTime))
INSERT [dbo].[KetQuaHocTap] ([Id], [IdDotKiemTra], [IdNhapHoc], [Diem], [GhiChu], [ThoiGian]) VALUES (N'92ffeb29-3eac-401d-be4e-92e84f4b3755', N'a99a279e-86c1-4804-ba78-70c2d9dd72cb', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'10', N's', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[KetQuaHocTap] ([Id], [IdDotKiemTra], [IdNhapHoc], [Diem], [GhiChu], [ThoiGian]) VALUES (N'cc1ee137-7099-4a98-b580-b03cc077dea6', N'b7b34bc1-48c0-469c-8a7e-bb928a469060', N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'8', N'', CAST(N'2020-05-05 00:00:00.000' AS DateTime))
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'348f70cf-2a1f-4121-96c1-0079b542d75f', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'ec21a30d-f5d7-413a-8ee9-26ae3ae0ded8', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'4b10de31-9c76-48fb-aa63-02a82386d62d', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'2b80b7cc-a64f-43be-bb33-c3c1357a8a69', N'8', N'8', N'8', N'8', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'e6aa3c69-6996-4bbb-b881-20aca9724cd2', N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'95d6db69-ba36-4142-8f38-95801a82c9d7', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'2e5bce2d-de4f-498b-a116-2148925882ff', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'ca7a7827-e9e3-4e98-80ab-de5154960d39', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'5efad37d-d203-4b58-9a66-269edbeecc1f', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'b3ad0a7e-3317-406a-85cc-0d6d68c10e7a', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'7f6c5e97-2b9f-4f67-af2d-45d420919e85', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'3d31ce97-4497-4f1b-978a-59c276bb41ad', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'eca61d26-37c8-42e8-bcd6-462fe4f829d4', N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'b2afa4f5-d75c-48c8-a76c-00feab44acda', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'1e0396cd-1844-4154-a4e2-5fc81fc8298d', N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'6a0a8924-fc89-455a-b2ba-7f885be93c06', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'c6201654-886c-4e22-929e-dfc229c410c6', N'4a2470b3-2ee9-406e-9c5e-b0b1910426cc', N'e325b5e7-d134-48f8-b07d-bb3b4a567b1c', N'0.00', N'0.00', N'0.00', N'0.00', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'1ee9baf3-c507-41fd-8bab-f1e1f2d9e5fd', N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'81371f6d-9383-49f8-98b7-63e57a79e78b', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'943ca925-6cca-4ca3-ab83-fc613c0596b7', N'5692b20c-f583-42ce-8e99-2d71fd4ac239', N'56a3819f-ad28-4956-a97f-1b829cd80be0', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KetQuaTuyenSinh] ([Id], [IdDotTuyenSinh], [IdHocVien], [DiemNghe], [DiemNoi], [DiemDoc], [DiemViet], [GhiChu]) VALUES (N'0d0781bf-adcb-4b97-8e2c-feae214d71fa', N'5bddc2c3-5b1a-4f06-a5b4-022985d1b323', N'1c6afbc4-9ae2-4c7e-8823-94f61a2f1378', N'9', N'9', N'9', N'9', N'')
INSERT [dbo].[KhoaHoc] ([IdKhoaHoc], [TenKhoaHoc], [GhiChu], [TrangThai]) VALUES (N'63fc6b86-2e1b-4ae0-a5e8-37e2cc9c214d', N'IELTS', N'Dạy toic', N'Đang Mở')
INSERT [dbo].[KhoaHoc] ([IdKhoaHoc], [TenKhoaHoc], [GhiChu], [TrangThai]) VALUES (N'7cfdf5fb-eef0-47b3-8036-b60ad99909c5', N'TOEIC', N'Sắp mở', N'Đang Mở')
INSERT [dbo].[KhoaHoc] ([IdKhoaHoc], [TenKhoaHoc], [GhiChu], [TrangThai]) VALUES (N'1a2066d1-80ae-41ad-99e7-da764337659d', N'Tiếng Anh Trung Học Cơ Sơ', N'', N'Đang Mở')
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'784fcfd4-f992-45ab-bfd6-00689b13777f', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 26', CAST(N'2020-03-02 08:00:00.000' AS DateTime), CAST(N'2020-03-02 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'ccca825e-daf7-4362-ad74-01efe4f2181a', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 20', CAST(N'2020-02-17 08:00:00.000' AS DateTime), CAST(N'2020-02-17 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'0d85f3c3-884c-44ff-ad24-077df0875a5f', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Buổi 5', CAST(N'2020-04-10 07:30:00.000' AS DateTime), CAST(N'2020-04-10 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'2eb30f10-575f-4ede-9f46-0e87fb7da57c', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 24', CAST(N'2020-02-26 08:00:00.000' AS DateTime), CAST(N'2020-02-26 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'42f38623-0dab-4df3-9e3c-18a8d10cb9e7', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 27', CAST(N'2020-03-04 08:00:00.000' AS DateTime), CAST(N'2020-03-04 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'f1976b60-3f3a-4fe4-a6fd-19a6ead5a734', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 7', CAST(N'2020-01-15 08:00:00.000' AS DateTime), CAST(N'2020-01-15 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'82fe4a8e-e4c8-48d8-bf07-1cd51f0a475e', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 29', CAST(N'2020-03-09 08:00:00.000' AS DateTime), CAST(N'2020-03-09 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'7cb18b55-44fd-49e0-82b3-2cbd3049f78c', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 4', CAST(N'2020-01-08 07:00:00.000' AS DateTime), CAST(N'2020-01-08 09:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'5230b3dc-e145-4f8d-8b24-2d11a4af1821', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 9', CAST(N'2020-01-20 08:59:00.000' AS DateTime), CAST(N'2020-01-20 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'8dc4cb01-f719-4e64-b9dd-372488438ade', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 30', CAST(N'2020-03-11 08:00:00.000' AS DateTime), CAST(N'2020-03-11 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'24c3ee62-80cf-4ad4-8519-3db553c84d04', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi  8', CAST(N'2020-01-17 08:00:00.000' AS DateTime), CAST(N'2020-01-17 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'2105d1c3-57b1-44b5-901e-4311c88d903f', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 25', CAST(N'2020-02-28 08:00:00.000' AS DateTime), CAST(N'2020-02-28 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'4d680b04-48ba-48a5-9fd5-4a1e27af1e4e', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Buổi 3', CAST(N'2020-04-06 07:30:00.000' AS DateTime), CAST(N'2020-04-06 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'aaefc1d5-91be-42be-8bc8-4f0938f76e07', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 22', CAST(N'2020-02-21 08:00:00.000' AS DateTime), CAST(N'2020-02-21 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'77d8a299-17cd-462a-a503-5260610558e5', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 17', CAST(N'2020-02-10 08:00:00.000' AS DateTime), CAST(N'2020-02-10 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'c12b0a39-06b9-4a22-b6f0-535f59fe07bb', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Buổi 1', CAST(N'2020-04-01 07:30:00.000' AS DateTime), CAST(N'2020-05-04 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'5161f642-a82c-4165-b566-5c9c65af3994', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 12', CAST(N'2020-01-29 08:00:00.000' AS DateTime), CAST(N'2020-01-29 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'11a337dc-9f3f-4e4c-9c4b-68a20d934ba4', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 21', CAST(N'2020-02-19 08:00:00.000' AS DateTime), CAST(N'2020-02-19 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'59e6375d-5341-4bdb-adee-6d3624dce186', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 1', CAST(N'2020-01-01 07:30:00.000' AS DateTime), CAST(N'2020-01-01 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'8984744a-acce-4257-928a-73e126ee494a', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 15', CAST(N'2020-02-05 08:00:00.000' AS DateTime), CAST(N'2020-02-05 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'60838db7-17d5-4c97-8c41-773b9537aef8', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 23', CAST(N'2020-02-24 08:00:00.000' AS DateTime), CAST(N'2020-02-24 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'd8bead54-8f33-4822-a175-970c057c5522', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 13', CAST(N'2020-01-31 08:00:00.000' AS DateTime), CAST(N'2020-01-31 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'f6405536-af2c-4c0c-a346-998e30d608db', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 3', CAST(N'2020-01-06 07:30:00.000' AS DateTime), CAST(N'2020-01-06 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'a0a2babf-a658-48b0-b50c-a1b10685f7fe', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 10 ', CAST(N'2020-01-22 08:00:00.000' AS DateTime), CAST(N'2020-01-22 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'1ae2f30f-8048-4dff-ae5c-a66b10fa0e06', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Buổi 4', CAST(N'2020-04-08 07:30:00.000' AS DateTime), CAST(N'2020-04-08 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'e92720ef-8556-4174-aba1-a93d3387cb33', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 6', CAST(N'2020-01-13 08:00:00.000' AS DateTime), CAST(N'2020-01-13 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'ef73d664-caee-4854-a708-b0510e8a9537', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 14', CAST(N'2020-02-03 08:00:00.000' AS DateTime), CAST(N'2020-02-03 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'b1eb38eb-b5d8-44fe-9b00-b68bd4304500', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 11', CAST(N'2020-01-24 08:00:00.000' AS DateTime), CAST(N'2020-01-24 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'45ab4b0a-6d9c-4de2-87f5-bc48d476eb6b', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 28', CAST(N'2020-03-06 08:00:00.000' AS DateTime), CAST(N'2020-03-06 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'a1ebf30a-2b9c-4b5e-a7ea-d2e096197d0a', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Buổi 2', CAST(N'2020-04-03 07:30:00.000' AS DateTime), CAST(N'2020-04-03 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'd8b5909a-ff52-45af-962c-d50e6ffdb2a7', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 18', CAST(N'2020-02-12 08:00:00.000' AS DateTime), CAST(N'2020-02-12 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'e0a06e14-c5c0-4145-9c80-d6e18b07893c', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 5', CAST(N'2020-01-10 08:00:00.000' AS DateTime), CAST(N'2020-01-10 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'de7bd392-7847-47ee-b728-d9173e32db5d', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 19', CAST(N'2020-02-14 08:00:00.000' AS DateTime), CAST(N'2020-02-14 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'5d6e8d08-374f-4d26-9b7e-e05e202317d7', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 2', CAST(N'2020-01-03 07:30:00.000' AS DateTime), CAST(N'2020-01-03 09:30:00.000' AS DateTime), 2)
INSERT [dbo].[LichGiangDay] ([IdLichGiangDay], [IdLop], [IdPhongHoc], [IdGiaoVien], [BuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [SoGio]) VALUES (N'1ead2ca4-280b-426d-b4ed-fed4bf536427', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'41b17291-2760-4612-ab77-19137a7976bf', N'Buổi 16', CAST(N'2020-02-07 08:00:00.000' AS DateTime), CAST(N'2020-02-07 10:00:00.000' AS DateTime), 2)
INSERT [dbo].[Lop] ([IdLop], [IdKhoaHoc], [TenLop], [SoBuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [TrangThai], [HocVienToiDa], [GhiChu], [HocPhiLop]) VALUES (N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'7cfdf5fb-eef0-47b3-8036-b60ad99909c5', N'Class Toeic 1', 30, CAST(N'2020-01-01 00:00:00.000' AS DateTime), CAST(N'2020-03-11 00:00:00.000' AS DateTime), N'Đang mở', 34, N'', CAST(5500000 AS Decimal(8, 0)))
INSERT [dbo].[Lop] ([IdLop], [IdKhoaHoc], [TenLop], [SoBuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [TrangThai], [HocVienToiDa], [GhiChu], [HocPhiLop]) VALUES (N'1bcec44b-5377-40eb-bb9b-28938a5a3d0e', N'63fc6b86-2e1b-4ae0-a5e8-37e2cc9c214d', N'Lớp học 4', 14, CAST(N'2020-05-14 00:00:00.000' AS DateTime), CAST(N'2020-05-21 00:00:00.000' AS DateTime), N'Đã Kết Thúc', 35, N'', CAST(5000000 AS Decimal(8, 0)))
INSERT [dbo].[Lop] ([IdLop], [IdKhoaHoc], [TenLop], [SoBuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [TrangThai], [HocVienToiDa], [GhiChu], [HocPhiLop]) VALUES (N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'7cfdf5fb-eef0-47b3-8036-b60ad99909c5', N'Class Toeic 2 ', 15, CAST(N'2020-04-01 00:00:00.000' AS DateTime), CAST(N'2020-05-04 00:00:00.000' AS DateTime), N'Đang mở', 34, N'Lớp học dành cho học viên mới , học về tocic', CAST(5000000 AS Decimal(8, 0)))
INSERT [dbo].[Lop] ([IdLop], [IdKhoaHoc], [TenLop], [SoBuoiHoc], [ThoiGianBatDau], [ThoiGianKetThuc], [TrangThai], [HocVienToiDa], [GhiChu], [HocPhiLop]) VALUES (N'ee048f2d-ac34-417d-845b-9a9a511dc6fc', N'7cfdf5fb-eef0-47b3-8036-b60ad99909c5', N'Class Toeic 3', 3, CAST(N'2020-05-06 00:00:00.000' AS DateTime), CAST(N'2020-05-06 00:00:00.000' AS DateTime), N'Sắp Mở', 3, N'', CAST(5000000 AS Decimal(8, 0)))
INSERT [dbo].[NguoiDungADM] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdNhanVien]) VALUES (N'15cf770d-a29a-4397-80f5-d9c155874de9', N'LeHa', N'1234567', 1, N'1fab84b7-2be0-46b2-91c4-efcf83dcd8e5')
INSERT [dbo].[NguoiDungADM] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdNhanVien]) VALUES (N'72cd3a9e-c2e6-46cb-86b0-f16df1b3b42f', N'nguyenthibay', N'123456', 1, N'38830eb7-010b-4c67-997a-d032623795e0')
INSERT [dbo].[NguoiDungGiaoVien] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdGiaoVien]) VALUES (N'298f124d-d951-42a0-b486-34e8c8cfaccc', N'lethinhung', N'1234567', 1, N'41b17291-2760-4612-ab77-19137a7976bf')
INSERT [dbo].[NguoiDungGiaoVien] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdGiaoVien]) VALUES (N'4312aed8-f69f-4d78-9634-c563174e04e7', N'trinhvanbinh', N'123456', 1, N'541203e1-75b2-410b-88f7-57bb6874bdb4')
INSERT [dbo].[NguoiDungHocVien] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdHocVien]) VALUES (N'c3e95f7a-8259-407a-ba8b-593da1e880ae', N'lenam', N'123456', 1, N'2b80b7cc-a64f-43be-bb33-c3c1357a8a69')
INSERT [dbo].[NguoiDungHocVien] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdHocVien]) VALUES (N'8cb1a287-020a-4ec0-a1d9-8444d2556ab4', N'hoangson', N'1234567', 1, N'ca7a7827-e9e3-4e98-80ab-de5154960d39')
INSERT [dbo].[NguoiDungHocVien] ([Id], [TenTaiKhoan], [MatKhau], [TrangThai], [IdHocVien]) VALUES (N'd4105c15-5a42-4e13-b309-fd58d3be9b70', N'trannam', N'123456', 1, N'b3ad0a7e-3317-406a-85cc-0d6d68c10e7a')
INSERT [dbo].[NhanVien] ([Id], [IdChucVu], [HoTen], [NamSinh], [SDT], [Email], [DiaChi], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'216b3c6e-d58a-446f-8b6c-8978a2507468', N'7ee4e41c-abb8-433f-a7d7-f76c92a1124f', N'Nguyễn Văn Anh', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'0923453421', N'NguyenVanAnh@gmail.com', N'06-Nguyễn khuyến-Nha Trang -Khánh Hòa', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N' Thử Việc', N'Nam')
INSERT [dbo].[NhanVien] ([Id], [IdChucVu], [HoTen], [NamSinh], [SDT], [Email], [DiaChi], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'53b2d083-0d64-4bb0-858a-bb0c6800bc3d', N'69121893-3afc-4f92-85f3-40bb5e7c7e29', N'Trần Văn Hà', CAST(N'1988-02-03 00:00:00.000' AS DateTime), N'0987654553', N'tranvanha@gmail.com', N'vĩnh hải - Nha Trang', CAST(N'2016-03-04 00:00:00.000' AS DateTime), N' Thử Việc', N'Nam')
INSERT [dbo].[NhanVien] ([Id], [IdChucVu], [HoTen], [NamSinh], [SDT], [Email], [DiaChi], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'38830eb7-010b-4c67-997a-d032623795e0', N'69121893-3afc-4f92-85f3-40bb5e7c7e29', N'Nguyễn Thị Bảy', CAST(N'1991-03-23 00:00:00.000' AS DateTime), N'0987654354', N'Nguyenthibay@gmail.com', N'Nha Trang', CAST(N'2019-02-05 00:00:00.000' AS DateTime), N' Thử Việc', N'Nữ')
INSERT [dbo].[NhanVien] ([Id], [IdChucVu], [HoTen], [NamSinh], [SDT], [Email], [DiaChi], [NgayVaoLam], [TrangThai], [GioiTinh]) VALUES (N'1fab84b7-2be0-46b2-91c4-efcf83dcd8e5', N'a988baa2-a29a-4db5-a03a-3c3655b2e42a', N'Lê Hà', CAST(N'2020-05-15 00:00:00.000' AS DateTime), N'0987654354', N'Leha@gmail.com', N'vĩnh hải - Nha Trang', CAST(N'2020-05-12 00:00:00.000' AS DateTime), N' Đang Làm', N'Nữ')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'699fd5b8-c8cd-40d8-bd57-007a6632b967', N'1c6afbc4-9ae2-4c7e-8823-94f61a2f1378', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'b7b7f5e4-33cf-476c-a13e-1e8f47d74ca7', N'2b80b7cc-a64f-43be-bb33-c3c1357a8a69', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'97cdfd8d-8b06-41f8-99ac-310db5ea73ac', N'2b80b7cc-a64f-43be-bb33-c3c1357a8a69', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'e883e557-0413-4319-bec6-58cbfb6c57d8', N'e325b5e7-d134-48f8-b07d-bb3b4a567b1c', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'6f55145c-2f30-4af5-b76d-5b7337be1346', N'ca7a7827-e9e3-4e98-80ab-de5154960d39', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Bảo Lưu')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'dd6e8cbd-312b-48e5-a985-6cb2f2b08b1c', N'ec21a30d-f5d7-413a-8ee9-26ae3ae0ded8', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'908d01ce-8419-4cb7-a741-970b0f9762e6', N'81371f6d-9383-49f8-98b7-63e57a79e78b', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'08d388ce-8914-4d5e-af4b-a0062e76cf64', N'3d31ce97-4497-4f1b-978a-59c276bb41ad', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'bf229953-57e5-415f-a7f1-a6d0cc28b588', N'95d6db69-ba36-4142-8f38-95801a82c9d7', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'7aa6d0ce-1a92-4ab9-9219-a7ae4869ca95', N'3d31ce97-4497-4f1b-978a-59c276bb41ad', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'1daac8e2-71dc-4eb8-ad8d-b58e55c575d2', N'b2afa4f5-d75c-48c8-a76c-00feab44acda', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'9897fa1c-972e-486d-bef9-c35d2deff44c', N'ec21a30d-f5d7-413a-8ee9-26ae3ae0ded8', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'c4539458-4d0a-41da-933a-d02316823183', N'e325b5e7-d134-48f8-b07d-bb3b4a567b1c', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[NhapHoc] ([IdNhapHoc], [IdHocVien], [IdLop], [GhiChu], [TrangThai]) VALUES (N'14970e56-0b6d-42b1-b725-eeb4303bf928', N'6a0a8924-fc89-455a-b2ba-7f885be93c06', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'', N'Đang Học')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'b32fe9a8-7696-4deb-9bff-11d505bf163b', N'T1_01', N'Tầng 1 phòng số 1', N'Hoạt Động')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'00234c26-8d75-4585-846f-500feda86aba', N'T1_02', N'Tầng 1 phòng số 2', N'Không Hoạt Động')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'7f2abd00-24ad-4d6a-ad42-871170641b65', N'T1_03', N'Tầng 1 phòng số 3', N'Hoạt Động')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'29a3fc17-5de9-47c1-bdeb-9b5547079f65', N'T2_01', N'Tầng 2 phòng số 1', N'Hoạt Động')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'7d25cb37-fa88-4362-9e4f-a2de42d06873', N'T2_02', N'Tầng 2 phòng số 2', N'Hoạt Động')
INSERT [dbo].[PhongHoc] ([IdPhongHoc], [SoPhong], [GhiChu], [TrangThai]) VALUES (N'4394452a-7457-4f1c-933c-d10f3b31c89f', N'T2_03', N'Tầng 2 phòng số 3', N'Hoạt Động')
INSERT [dbo].[ThongBaoGiaoVien] ([Id], [IdGiaoVien], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'f9a684ad-0e9f-440c-84bd-1a02fbd8f8fc', N'41b17291-2760-4612-ab77-19137a7976bf', N'Thông Báo Nghỉ dạy', N'ngày 31- 03 - 2020 nghỉ dạy', CAST(N'2020-03-31 00:00:00.000' AS DateTime), N'Hiện')
INSERT [dbo].[ThongBaoGiaoVien] ([Id], [IdGiaoVien], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'f9cfcbc7-7c60-41b3-ba9f-6319786c587f', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Thông Báo Lịch Dạy', N'Lịch Giảng Dạy', CAST(N'2020-06-17 00:00:00.000' AS DateTime), N'Hiện')
INSERT [dbo].[ThongBaoGiaoVien] ([Id], [IdGiaoVien], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'22bbfcb1-fa2a-4de2-a728-75cebb9528f1', N'541203e1-75b2-410b-88f7-57bb6874bdb4', N'Nhận lương', N'Ngày 05- 05 -2020 nhận lương', CAST(N'2020-05-05 00:00:00.000' AS DateTime), N'Hiện')
INSERT [dbo].[ThongBaoLop] ([Id], [IdLop], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'38d87b2b-d13d-4f93-9150-85911ec502c9', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'Thông báo Học', N'lớp học bắt đầu', CAST(N'2020-11-11 00:00:00.000' AS DateTime), N'Hiện')
INSERT [dbo].[ThongBaoLop] ([Id], [IdLop], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'a47feb5d-bdc6-4f74-a308-cb0a48ed74ee', N'2e3bb1e8-97ee-4dbe-8ce6-3e2c01ec7d9a', N'Thông Báo Nghỉ Học 1', N'nghỉ học', CAST(N'2020-05-19 00:00:00.000' AS DateTime), N'Hiện')
INSERT [dbo].[ThongBaoLop] ([Id], [IdLop], [TieuDe], [NoiDung], [ThoiGian], [TrangThai]) VALUES (N'c9e938bb-bda6-4a96-9dfe-e8950ec4db9b', N'e4ff3e3a-137c-4fda-b615-2213d8766145', N'Thông báo nghỉ', N'nghỉ học', CAST(N'2020-06-17 00:00:00.000' AS DateTime), N'Ẩn')
INSERT [dbo].[ThuChi] ([Id], [TenKhoanChi], [SoTien], [NoiDung], [ThoiGian]) VALUES (N'e6fbe25a-6a3c-496b-8954-1eb47640792e', N'Lê Hà', CAST(8000000 AS Decimal(8, 0)), N'Trả lương', CAST(N'2020-05-31 00:00:00.000' AS DateTime))
INSERT [dbo].[ThuChi] ([Id], [TenKhoanChi], [SoTien], [NoiDung], [ThoiGian]) VALUES (N'2f0f9b53-9326-4c14-b36e-57f95403e5ec', N'Trần Nam', CAST(5500000 AS Decimal(8, 0)), N'Trả lương cho nhân viên', CAST(N'2019-11-11 00:00:00.000' AS DateTime))
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [fk_dd_lgd] FOREIGN KEY([IdLichGiangDay])
REFERENCES [dbo].[LichGiangDay] ([IdLichGiangDay])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [fk_dd_lgd]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [fk_dd_nh] FOREIGN KEY([IdNhapHoc])
REFERENCES [dbo].[NhapHoc] ([IdNhapHoc])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [fk_dd_nh]
GO
ALTER TABLE [dbo].[HocPhi]  WITH CHECK ADD  CONSTRAINT [fk_hp_nh] FOREIGN KEY([IdNhapHoc])
REFERENCES [dbo].[NhapHoc] ([IdNhapHoc])
GO
ALTER TABLE [dbo].[HocPhi] CHECK CONSTRAINT [fk_hp_nh]
GO
ALTER TABLE [dbo].[KetQuaHocTap]  WITH CHECK ADD  CONSTRAINT [fk_kqht_dkt] FOREIGN KEY([IdDotKiemTra])
REFERENCES [dbo].[DotKiemTra] ([IdDotKiemTra])
GO
ALTER TABLE [dbo].[KetQuaHocTap] CHECK CONSTRAINT [fk_kqht_dkt]
GO
ALTER TABLE [dbo].[KetQuaHocTap]  WITH CHECK ADD  CONSTRAINT [fk_kqht_nh] FOREIGN KEY([IdNhapHoc])
REFERENCES [dbo].[NhapHoc] ([IdNhapHoc])
GO
ALTER TABLE [dbo].[KetQuaHocTap] CHECK CONSTRAINT [fk_kqht_nh]
GO
ALTER TABLE [dbo].[KetQuaTuyenSinh]  WITH CHECK ADD  CONSTRAINT [fk_kqts_dts] FOREIGN KEY([IdDotTuyenSinh])
REFERENCES [dbo].[DotTuyenSinh] ([IdDotTuyenSinh])
GO
ALTER TABLE [dbo].[KetQuaTuyenSinh] CHECK CONSTRAINT [fk_kqts_dts]
GO
ALTER TABLE [dbo].[KetQuaTuyenSinh]  WITH CHECK ADD  CONSTRAINT [fk_kqts_hv] FOREIGN KEY([IdHocVien])
REFERENCES [dbo].[HocVien] ([IdHocVien])
GO
ALTER TABLE [dbo].[KetQuaTuyenSinh] CHECK CONSTRAINT [fk_kqts_hv]
GO
ALTER TABLE [dbo].[LichGiangDay]  WITH CHECK ADD  CONSTRAINT [fk_lgd_gv] FOREIGN KEY([IdGiaoVien])
REFERENCES [dbo].[GiaoVien] ([IdGiaoVien])
GO
ALTER TABLE [dbo].[LichGiangDay] CHECK CONSTRAINT [fk_lgd_gv]
GO
ALTER TABLE [dbo].[LichGiangDay]  WITH CHECK ADD  CONSTRAINT [fk_lgd_l] FOREIGN KEY([IdLop])
REFERENCES [dbo].[Lop] ([IdLop])
GO
ALTER TABLE [dbo].[LichGiangDay] CHECK CONSTRAINT [fk_lgd_l]
GO
ALTER TABLE [dbo].[LichGiangDay]  WITH CHECK ADD  CONSTRAINT [fk_lgd_ph] FOREIGN KEY([IdPhongHoc])
REFERENCES [dbo].[PhongHoc] ([IdPhongHoc])
GO
ALTER TABLE [dbo].[LichGiangDay] CHECK CONSTRAINT [fk_lgd_ph]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [fk_Lop_kh] FOREIGN KEY([IdKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([IdKhoaHoc])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [fk_Lop_kh]
GO
ALTER TABLE [dbo].[NguoiDungADM]  WITH CHECK ADD  CONSTRAINT [FK_ngnv] FOREIGN KEY([IdNhanVien])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[NguoiDungADM] CHECK CONSTRAINT [FK_ngnv]
GO
ALTER TABLE [dbo].[NguoiDungGiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_nggv] FOREIGN KEY([IdGiaoVien])
REFERENCES [dbo].[GiaoVien] ([IdGiaoVien])
GO
ALTER TABLE [dbo].[NguoiDungGiaoVien] CHECK CONSTRAINT [FK_nggv]
GO
ALTER TABLE [dbo].[NguoiDungHocVien]  WITH CHECK ADD  CONSTRAINT [FK_nghv] FOREIGN KEY([IdHocVien])
REFERENCES [dbo].[HocVien] ([IdHocVien])
GO
ALTER TABLE [dbo].[NguoiDungHocVien] CHECK CONSTRAINT [FK_nghv]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [fk_nv_cv] FOREIGN KEY([IdChucVu])
REFERENCES [dbo].[ChucVu] ([IdChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [fk_nv_cv]
GO
ALTER TABLE [dbo].[NhapHoc]  WITH CHECK ADD  CONSTRAINT [fk_nh_hv] FOREIGN KEY([IdHocVien])
REFERENCES [dbo].[HocVien] ([IdHocVien])
GO
ALTER TABLE [dbo].[NhapHoc] CHECK CONSTRAINT [fk_nh_hv]
GO
ALTER TABLE [dbo].[NhapHoc]  WITH CHECK ADD  CONSTRAINT [fk_nh_l] FOREIGN KEY([IdLop])
REFERENCES [dbo].[Lop] ([IdLop])
GO
ALTER TABLE [dbo].[NhapHoc] CHECK CONSTRAINT [fk_nh_l]
GO
ALTER TABLE [dbo].[ThongBaoGiaoVien]  WITH CHECK ADD  CONSTRAINT [fk_tbgv_gv] FOREIGN KEY([IdGiaoVien])
REFERENCES [dbo].[GiaoVien] ([IdGiaoVien])
GO
ALTER TABLE [dbo].[ThongBaoGiaoVien] CHECK CONSTRAINT [fk_tbgv_gv]
GO
ALTER TABLE [dbo].[ThongBaoLop]  WITH CHECK ADD  CONSTRAINT [fk_tb_l] FOREIGN KEY([IdLop])
REFERENCES [dbo].[Lop] ([IdLop])
GO
ALTER TABLE [dbo].[ThongBaoLop] CHECK CONSTRAINT [fk_tb_l]
GO
