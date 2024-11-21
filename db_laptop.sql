USE [master]
GO
/****** Object:  Database [db_laptop]    Script Date: 11/22/2024 12:11:47 AM ******/
CREATE DATABASE [db_laptop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_laptop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_laptop.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_laptop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_laptop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_laptop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_laptop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_laptop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_laptop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_laptop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_laptop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_laptop] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_laptop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_laptop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_laptop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_laptop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_laptop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_laptop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_laptop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_laptop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_laptop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_laptop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_laptop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_laptop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_laptop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_laptop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_laptop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_laptop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_laptop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_laptop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_laptop] SET  MULTI_USER 
GO
ALTER DATABASE [db_laptop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_laptop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_laptop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_laptop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_laptop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_laptop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_laptop] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_laptop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_laptop]
GO
/****** Object:  Table [dbo].[chitiet_donhang]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiet_donhang](
	[madh] [char](10) NOT NULL,
	[masp] [char](10) NOT NULL,
	[soluongmua] [int] NULL,
	[thanhtien] [float] NULL,
 CONSTRAINT [PK_chitiet_donhang] PRIMARY KEY CLUSTERED 
(
	[madh] ASC,
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dangnhap]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dangnhap](
	[tendangnhap] [char](30) NOT NULL,
	[matkhau] [char](50) NULL,
	[nhaplai_mk] [char](50) NULL,
 CONSTRAINT [PK_dangnhap_1] PRIMARY KEY CLUSTERED 
(
	[tendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[don_hang]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[don_hang](
	[madh] [char](10) NOT NULL,
	[manv] [char](10) NULL,
	[makh] [char](10) NULL,
	[ngayban] [datetime] NULL,
 CONSTRAINT [PK_don_hang] PRIMARY KEY CLUSTERED 
(
	[madh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khach_hang]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khach_hang](
	[makh] [char](10) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[sdt_kh] [char](15) NULL,
	[diachi] [nvarchar](100) NULL,
 CONSTRAINT [PK_khach_hang] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhan_vien]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhan_vien](
	[manv] [char](10) NOT NULL,
	[tennv] [nvarchar](50) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[sdt_nv] [nchar](15) NULL,
	[diachi_nv] [nvarchar](50) NULL,
	[ngaysinh_nv] [date] NULL,
	[chucvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_nhan_vien] PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 11/22/2024 12:11:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[masp] [char](10) NOT NULL,
	[tensp] [nvarchar](50) NULL,
	[giabanra] [float] NULL,
	[chitiet] [nvarchar](50) NULL,
	[hinhanh] [nchar](100) NULL,
	[loailaptop] [nvarchar](50) NULL,
	[hangsanxuat] [nvarchar](50) NULL,
	[giamuavao] [float] NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_sanpham] PRIMARY KEY CLUSTERED 
(
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd01      ', N'sp03      ', 3, 1800000)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd02      ', N'sp03      ', 2, 1200000)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd03      ', N'sp03      ', 10, 546430)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd04      ', N'sp03      ', 2, 109286)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd06      ', N'sp0542    ', 1, 5000000)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd07      ', N'sp03      ', 1, 600000)
INSERT [dbo].[chitiet_donhang] ([madh], [masp], [soluongmua], [thanhtien]) VALUES (N'hd08      ', N'sp03      ', 2, 24626)
GO
INSERT [dbo].[dangnhap] ([tendangnhap], [matkhau], [nhaplai_mk]) VALUES (N'a                             ', N'1                                                 ', N'1                                                 ')
INSERT [dbo].[dangnhap] ([tendangnhap], [matkhau], [nhaplai_mk]) VALUES (N'ad                            ', N'1                                                 ', N'1                                                 ')
INSERT [dbo].[dangnhap] ([tendangnhap], [matkhau], [nhaplai_mk]) VALUES (N'admin                         ', N'123                                               ', N'123                                               ')
INSERT [dbo].[dangnhap] ([tendangnhap], [matkhau], [nhaplai_mk]) VALUES (N'pat                           ', N'anh                                               ', N'anh                                               ')
GO
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd01      ', N'nv01      ', N'kh02      ', CAST(N'2024-11-18T11:37:26.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd02      ', N'nv04      ', N'kh03      ', CAST(N'2024-11-21T03:17:12.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd03      ', N'nv01      ', N'kh02      ', CAST(N'2024-11-19T03:48:41.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd04      ', N'nv02      ', N'kh02      ', CAST(N'2024-11-19T03:50:01.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd06      ', N'nv03      ', N'kh03      ', CAST(N'2024-11-19T04:02:33.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd07      ', N'nv04      ', N'kh04      ', CAST(N'2024-11-21T10:38:00.000' AS DateTime))
INSERT [dbo].[don_hang] ([madh], [manv], [makh], [ngayban]) VALUES (N'hd08      ', N'nv03      ', N'kh05      ', CAST(N'2024-11-22T12:04:16.000' AS DateTime))
GO
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh01      ', N'Dương Lan Anh', N'Nữ        ', N'069789         ', N'Hoàng Mai,Hà Nội,Việt Nam')
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh02      ', N'Nguyễn Văn Hoàng', N'Nam       ', N'0689789        ', N'Thanh Trì,Hà Nội')
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh03      ', N'Đỗ Phúc An', N'Nam       ', N'04392853       ', N'thanh hóa,việt nam')
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh04      ', N'Phạm Trang', N'Nữ', N'099999923      ', N'Vịnh Hạ Long,Việt Nam')
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh05      ', N'Phan Nhật Minh', N'Nam       ', N'09285943       ', N'Ninh Bình,Việt Nam')
INSERT [dbo].[khach_hang] ([makh], [tenkh], [gioitinh], [sdt_kh], [diachi]) VALUES (N'kh07      ', N'Đinh Mạnh Ninh', N'Nam', N'043758345      ', N'Hà Nội,Việt Nam')
GO
INSERT [dbo].[nhan_vien] ([manv], [tennv], [gioitinh], [sdt_nv], [diachi_nv], [ngaysinh_nv], [chucvu]) VALUES (N'nv01      ', N'Phan Anh Tuấn', N'Nam', N'078967985      ', N'thanh hóa,việt nam', CAST(N'2004-11-01' AS Date), N'nhân viên')
INSERT [dbo].[nhan_vien] ([manv], [tennv], [gioitinh], [sdt_nv], [diachi_nv], [ngaysinh_nv], [chucvu]) VALUES (N'nv02      ', N'Phạm Minh Quang', N'Nam', N'087967897      ', N'Nam Định,Việt Nam', CAST(N'2007-01-17' AS Date), N'nhân viên')
INSERT [dbo].[nhan_vien] ([manv], [tennv], [gioitinh], [sdt_nv], [diachi_nv], [ngaysinh_nv], [chucvu]) VALUES (N'nv03      ', N'Trần Văn Toàn', N'Nam', N'087967897      ', N'Hà Tĩnh,Việt Nam', CAST(N'2010-01-01' AS Date), N'nhân viên')
INSERT [dbo].[nhan_vien] ([manv], [tennv], [gioitinh], [sdt_nv], [diachi_nv], [ngaysinh_nv], [chucvu]) VALUES (N'nv04      ', N'Mai Thị Mai', N'Nữ', N'0593458        ', N'Quảng Ninh,Việt Nam', CAST(N'2000-01-01' AS Date), N'quản lý')
INSERT [dbo].[nhan_vien] ([manv], [tennv], [gioitinh], [sdt_nv], [diachi_nv], [ngaysinh_nv], [chucvu]) VALUES (N'nv05      ', N'Ngô Minh Quang', N'Nam', N'0345843        ', N'Bắc Ninh,Việt Nam', CAST(N'2009-09-21' AS Date), N'nhân viên')
GO
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp01      ', N'Laptop ASUS Vivobook 14 OLED A1405VA-KM257W', 54325, N'i5-13500H | Intel Iris Xe', N'asus_vivobook_14oled.png                                                                            ', N'Văn phòng', N'HP', 36456, 37)
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp02      ', N'Laptop Lenovo LOQ 15IAX9 83GS001SVN', 52345, N'Core I5-12450HX,RAM:12G,Đồ họa:RTX 2050', N'Screenshot 2024-11-20 015707.png                                                                    ', N'Gaming', N'Lenovo', 43534, 16)
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp03      ', N'Laptop ASUS Zenbook 14 OLED UX3405MA-PP152W', 12313, N'Core Ultra 7,Ram:32G,HĐH:window 11 pro', N'openFileDialog1                                                                                     ', N'Loại mỏng nhẹ', N'Asus', 1000, 12)
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp04      ', N'Laptop HP Pavilion X360 14-EK2017TU 9Z2V5PA', 9999999, N'CORE 5-120U/16GB/512GB PCIE/14.0 FHD/CẢM ỨNG', N'Screenshot 2024-11-21 025148.png                                                                    ', N'Cảm ứng', N'HP', 9445767, 34)
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp05      ', N'Laptop Acer Aspire 7 A715-76G-5806', 55555, N'Core I5-12450H,RAM:16GB DDR4', N'Screenshot 2024-11-20 020808.png                                                                    ', N'Đồ họa-kỹ thuật', N'Acer', 44444, 2)
INSERT [dbo].[sanpham] ([masp], [tensp], [giabanra], [chitiet], [hinhanh], [loailaptop], [hangsanxuat], [giamuavao], [soluong]) VALUES (N'sp0542    ', N'Laptop MSI Modern 14 C13M-607VN', 5000000, N'I7-1355U/16GB/512GB PCIE/14.0 FHD/WIN11/ĐEN', N'Screenshot 2024-11-20 021110.png                                                                    ', N'Sinh viên', N'MSI', 4876878, 6)
GO
ALTER TABLE [dbo].[chitiet_donhang]  WITH CHECK ADD  CONSTRAINT [FK_chitiet_donhang_don_hang] FOREIGN KEY([madh])
REFERENCES [dbo].[don_hang] ([madh])
GO
ALTER TABLE [dbo].[chitiet_donhang] CHECK CONSTRAINT [FK_chitiet_donhang_don_hang]
GO
ALTER TABLE [dbo].[chitiet_donhang]  WITH CHECK ADD  CONSTRAINT [FK_chitiet_donhang_sanpham] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
GO
ALTER TABLE [dbo].[chitiet_donhang] CHECK CONSTRAINT [FK_chitiet_donhang_sanpham]
GO
ALTER TABLE [dbo].[don_hang]  WITH CHECK ADD  CONSTRAINT [FK_don_hang_khach_hang] FOREIGN KEY([makh])
REFERENCES [dbo].[khach_hang] ([makh])
GO
ALTER TABLE [dbo].[don_hang] CHECK CONSTRAINT [FK_don_hang_khach_hang]
GO
ALTER TABLE [dbo].[don_hang]  WITH CHECK ADD  CONSTRAINT [FK_don_hang_nhan_vien] FOREIGN KEY([manv])
REFERENCES [dbo].[nhan_vien] ([manv])
GO
ALTER TABLE [dbo].[don_hang] CHECK CONSTRAINT [FK_don_hang_nhan_vien]
GO
USE [master]
GO
ALTER DATABASE [db_laptop] SET  READ_WRITE 
GO
