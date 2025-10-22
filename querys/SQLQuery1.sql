USE [master]
GO
/****** Object:  Database [Growshi]    Script Date: 22/10/2025 11:36:57 ******/
CREATE DATABASE [Growshi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Growshi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Growshi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Growshi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Growshi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Growshi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Growshi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Growshi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Growshi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Growshi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Growshi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Growshi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Growshi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Growshi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Growshi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Growshi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Growshi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Growshi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Growshi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Growshi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Growshi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Growshi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Growshi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Growshi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Growshi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Growshi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Growshi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Growshi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Growshi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Growshi] SET RECOVERY FULL 
GO
ALTER DATABASE [Growshi] SET  MULTI_USER 
GO
ALTER DATABASE [Growshi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Growshi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Growshi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Growshi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Growshi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Growshi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Growshi] SET QUERY_STORE = ON
GO
ALTER DATABASE [Growshi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Growshi]
GO
/****** Object:  Table [dbo].[Backup]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Backup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[NombreArchivo] [varchar](255) NOT NULL,
	[RutaArchivo] [varchar](1000) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Nota] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[BitacoraID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
	[FechaHora] [datetime2](3) NOT NULL,
	[Nivel] [nvarchar](20) NOT NULL,
	[Modulo] [nvarchar](50) NULL,
	[Mensaje] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BitacoraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisoComponente]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoComponente](
	[PermisoID] [nvarchar](100) NOT NULL,
	[NombreDescriptivo] [nvarchar](100) NOT NULL,
	[EsFamilia] [bit] NOT NULL,
	[PadreID] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[TipoUsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoUsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario_Permiso]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario_Permiso](
	[TipoUsuarioID] [int] NOT NULL,
	[PermisoID] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoUsuarioID] ASC,
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] NOT NULL,
	[UsuarioNombre] [varchar](50) NOT NULL,
	[UsuarioContraseña] [varchar](64) NOT NULL,
	[UsuarioClaveRecuperacion] [varchar](50) NOT NULL,
	[UsuarioIntentos] [int] NOT NULL,
 CONSTRAINT [PK_Usuario1] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_TipoUsuario]    Script Date: 22/10/2025 11:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_TipoUsuario](
	[UsuarioID] [int] NOT NULL,
	[TipoUsuarioID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[TipoUsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1, 1, CAST(N'2025-09-16T13:05:18.3430000' AS DateTime2), N'Advertencia', N'Login', N'Intento de inicio de sesión fallido para el usuario.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2, 1, CAST(N'2025-09-16T14:52:56.3130000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (3, 1, CAST(N'2025-09-16T15:03:17.1300000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (4, 1, CAST(N'2025-09-16T17:30:26.7700000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (5, 1, CAST(N'2025-09-16T17:30:30.4800000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (6, 1, CAST(N'2025-09-17T11:23:25.6630000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (7, 1, CAST(N'2025-09-17T11:23:38.2370000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (8, 1, CAST(N'2025-09-17T11:24:19.1470000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (9, 1, CAST(N'2025-09-17T11:25:42.1270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (10, 1, CAST(N'2025-09-17T11:25:48.7800000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (11, 1, CAST(N'2025-09-17T11:26:27.2400000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (12, 1, CAST(N'2025-09-17T11:26:30.9000000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (13, 1, CAST(N'2025-09-17T11:26:51.5770000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (14, 1, CAST(N'2025-09-17T11:26:56.0730000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (15, 1, CAST(N'2025-09-17T13:29:17.4600000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (16, 1, CAST(N'2025-09-17T13:29:28.7400000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (17, 1, CAST(N'2025-09-17T13:31:24.3300000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (18, 1, CAST(N'2025-09-17T13:31:34.4930000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (19, 1, CAST(N'2025-09-17T13:31:48.9270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (20, 1, CAST(N'2025-09-17T13:32:04.3670000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (21, 1, CAST(N'2025-09-17T14:01:43.8070000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (22, 1, CAST(N'2025-09-17T14:02:19.4700000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (23, 1, CAST(N'2025-09-17T14:02:27.6200000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (24, 1, CAST(N'2025-09-17T14:08:40.5670000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (25, 1, CAST(N'2025-09-17T14:08:47.0700000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (26, 1, CAST(N'2025-09-17T14:10:48.9800000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (27, 1, CAST(N'2025-09-17T14:10:53.4670000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (28, 1, CAST(N'2025-09-17T14:14:20.7000000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (29, 1, CAST(N'2025-09-17T14:14:24.2770000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (30, 1, CAST(N'2025-09-17T14:51:33.0300000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (31, 1, CAST(N'2025-09-17T14:51:55.5100000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (32, 1, CAST(N'2025-09-17T14:52:04.2230000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (33, 1, CAST(N'2025-09-17T14:52:18.8000000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (34, 1, CAST(N'2025-09-17T14:52:54.8430000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (35, 1, CAST(N'2025-09-17T14:53:03.2830000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (36, 1, CAST(N'2025-09-17T14:53:20.7830000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (37, 1, CAST(N'2025-09-17T14:53:28.0000000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (38, 1, CAST(N'2025-09-17T14:53:39.2130000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (39, 1, CAST(N'2025-09-17T14:53:49.1600000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (40, 1, CAST(N'2025-09-17T14:54:13.1700000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (41, 1, CAST(N'2025-09-17T14:54:30.1530000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (42, 1, CAST(N'2025-09-17T14:56:11.1330000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (43, 1, CAST(N'2025-09-17T14:56:17.4900000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (44, 1, CAST(N'2025-09-17T15:20:19.8830000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (45, 1, CAST(N'2025-09-17T15:20:46.0400000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (46, 1, CAST(N'2025-09-17T15:20:55.7630000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (47, 1, CAST(N'2025-09-17T15:21:12.1130000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (48, 1, CAST(N'2025-09-17T15:22:02.6030000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (49, 1, CAST(N'2025-09-17T15:22:23.8630000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (50, 1, CAST(N'2025-09-17T16:00:53.5900000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (51, 1, CAST(N'2025-09-17T16:01:08.5300000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (52, 1, CAST(N'2025-09-17T16:03:44.2270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (53, 1, CAST(N'2025-09-17T16:04:03.1100000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (54, 1, CAST(N'2025-09-20T15:05:53.9930000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (55, 1, CAST(N'2025-09-20T15:06:07.1100000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (56, 1, CAST(N'2025-09-20T15:06:18.9400000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (57, 1, CAST(N'2025-09-20T15:07:10.4200000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (58, 1, CAST(N'2025-09-20T15:58:55.1000000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (59, 1, CAST(N'2025-09-20T15:59:15.3230000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (60, 1, CAST(N'2025-09-20T16:00:14.0630000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (61, 1, CAST(N'2025-09-20T16:03:42.2470000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (62, 1, CAST(N'2025-09-20T16:04:58.9330000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (63, 1, CAST(N'2025-09-20T16:05:08.7570000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (64, 1, CAST(N'2025-09-20T16:05:46.0370000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (65, 1, CAST(N'2025-09-20T16:06:03.3030000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (66, 1, CAST(N'2025-09-20T16:07:53.6230000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (67, 1, CAST(N'2025-09-20T16:08:04.4570000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (68, 1, CAST(N'2025-09-20T16:08:20.3070000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (69, 1, CAST(N'2025-09-20T16:12:18.5900000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (70, 1, CAST(N'2025-09-20T16:12:35.2370000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1058, 1, CAST(N'2025-09-22T14:33:05.7430000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1059, 1, CAST(N'2025-09-22T14:44:02.5770000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1060, 1, CAST(N'2025-09-22T15:18:58.0530000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1061, 1, CAST(N'2025-09-23T15:00:09.4130000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1062, 1, CAST(N'2025-09-23T15:00:21.1400000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1063, 1, CAST(N'2025-09-23T16:26:34.7270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1064, 1, CAST(N'2025-09-24T19:10:13.0330000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1065, 1, CAST(N'2025-09-24T19:17:42.5270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1066, 1, CAST(N'2025-09-24T19:17:59.3100000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1067, 1, CAST(N'2025-09-24T19:25:42.3730000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1068, 1, CAST(N'2025-09-24T19:25:58.4730000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1069, 1, CAST(N'2025-09-24T19:27:31.5930000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1070, 1, CAST(N'2025-09-24T19:28:06.2100000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1071, 1, CAST(N'2025-09-24T19:46:37.9600000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1072, 1, CAST(N'2025-09-24T20:20:57.8500000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (1073, 1, CAST(N'2025-09-24T20:40:30.4730000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2072, 1, CAST(N'2025-10-16T15:32:13.8670000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2073, 1, CAST(N'2025-10-16T15:36:25.0200000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2074, 1, CAST(N'2025-10-16T15:36:31.7300000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2075, 1, CAST(N'2025-10-16T15:37:11.8000000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2076, 1, CAST(N'2025-10-16T15:44:35.4830000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2077, 1, CAST(N'2025-10-16T15:46:47.6070000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2078, 1, CAST(N'2025-10-16T15:55:53.5030000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2079, 1, CAST(N'2025-10-21T16:24:14.2230000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2080, 1, CAST(N'2025-10-21T16:24:25.0000000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2081, 1, CAST(N'2025-10-21T16:24:56.3200000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2082, 1, CAST(N'2025-10-21T16:25:02.4930000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2083, 1, CAST(N'2025-10-21T16:25:19.1270000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2084, 1, CAST(N'2025-10-21T16:25:39.4970000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2085, 1, CAST(N'2025-10-21T16:54:00.9500000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2086, 1, CAST(N'2025-10-21T16:54:55.0900000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2087, 1, CAST(N'2025-10-21T16:55:04.1170000' AS DateTime2), N'Info', N'Sesión', N'Cierre de sesión para el usuario ''roger''.')
GO
INSERT [dbo].[Bitacora] ([BitacoraID], [UsuarioID], [FechaHora], [Nivel], [Modulo], [Mensaje]) VALUES (2088, 1, CAST(N'2025-10-21T16:55:47.7030000' AS DateTime2), N'Info', N'Login', N'Inicio de sesión exitoso para el usuario ''roger''.')
GO
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem', N'Acceso al Menú Configuración', 1, N'Permisos_Nivel3')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem_buttonActualizaciones', N'Botón Actualizaciones', 0, N'MenuStrip_configuracionMenuItem')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem_buttonAjusteSistema', N'Botón Ajustes del Sistema', 0, N'MenuStrip_configuracionMenuItem')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem_buttonCopiaSeguridad', N'Botón Copia de Seguridad', 0, N'MenuStrip_configuracionMenuItem')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem_buttonGestionUsuarios', N'Botón Gestión de Usuarios', 0, N'MenuStrip_configuracionMenuItem')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_configuracionMenuItem_buttonRolesPermisos', N'Botón Roles y Permisos', 0, N'MenuStrip_configuracionMenuItem')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_historialMenuItem', N'Acceso al Menú Historial', 1, N'Permisos_Nivel2')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_idiomaMenuItem', N'Acceso al Menú Idioma', 1, N'Permisos_Nivel1')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_inicioMenuItem', N'Acceso al Menú Inicio', 1, N'Permisos_Nivel1')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_miCuentaMenuItem', N'Acceso al Menú Mi Cuenta', 1, N'Permisos_Nivel1')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_misCultivosMenuItem', N'Acceso al Menú Mis Cultivos', 1, N'Permisos_Nivel1')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'MenuStrip_reportesMenuItem', N'Acceso al Menú Reportes', 1, N'Permisos_Nivel2')
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'Permisos_Nivel1', N'Acceso a los permisos esenciales del sistema', 1, NULL)
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'Permisos_Nivel2', N'Acceso a los permisos de nivel medio del sistema', 1, NULL)
GO
INSERT [dbo].[PermisoComponente] ([PermisoID], [NombreDescriptivo], [EsFamilia], [PadreID]) VALUES (N'Permisos_Nivel3', N'Acceso a los permisos de nivel avanzado del sistema', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 
GO
INSERT [dbo].[TipoUsuario] ([TipoUsuarioID], [NombreTipo]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[TipoUsuario] ([TipoUsuarioID], [NombreTipo]) VALUES (3, N'Agricultor')
GO
INSERT [dbo].[TipoUsuario] ([TipoUsuarioID], [NombreTipo]) VALUES (2, N'Técnico')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
GO
INSERT [dbo].[TipoUsuario_Permiso] ([TipoUsuarioID], [PermisoID]) VALUES (1, N'Permisos_Nivel1')
GO
INSERT [dbo].[TipoUsuario_Permiso] ([TipoUsuarioID], [PermisoID]) VALUES (1, N'Permisos_Nivel2')
GO
INSERT [dbo].[TipoUsuario_Permiso] ([TipoUsuarioID], [PermisoID]) VALUES (1, N'Permisos_Nivel3')
GO
INSERT [dbo].[Usuario] ([UsuarioID], [UsuarioNombre], [UsuarioContraseña], [UsuarioClaveRecuperacion], [UsuarioIntentos]) VALUES (1, N'roger', N'4387134784cf3aa4245b7fcf4ac045d0a449524e98ba5dab4955ff4631e89df9', N'roger', 0)
GO
INSERT [dbo].[Usuario] ([UsuarioID], [UsuarioNombre], [UsuarioContraseña], [UsuarioClaveRecuperacion], [UsuarioIntentos]) VALUES (2, N'roro', N'roro', N'roro', 1)
GO
INSERT [dbo].[Usuario_TipoUsuario] ([UsuarioID], [TipoUsuarioID]) VALUES (1, 1)
GO
INSERT [dbo].[Usuario_TipoUsuario] ([UsuarioID], [TipoUsuarioID]) VALUES (2, 2)
GO
INSERT [dbo].[Usuario_TipoUsuario] ([UsuarioID], [TipoUsuarioID]) VALUES (2, 3)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TipoUsua__7586661C26A2857A]    Script Date: 22/10/2025 11:36:58 ******/
ALTER TABLE [dbo].[TipoUsuario] ADD UNIQUE NONCLUSTERED 
(
	[NombreTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bitacora] ADD  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [dbo].[Backup]  WITH CHECK ADD  CONSTRAINT [FK_Backup_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Backup] CHECK CONSTRAINT [FK_Backup_Usuario]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuario]
GO
ALTER TABLE [dbo].[PermisoComponente]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_Padre] FOREIGN KEY([PadreID])
REFERENCES [dbo].[PermisoComponente] ([PermisoID])
GO
ALTER TABLE [dbo].[PermisoComponente] CHECK CONSTRAINT [FK_Permiso_Padre]
GO
ALTER TABLE [dbo].[TipoUsuario_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_TUP_Permiso] FOREIGN KEY([PermisoID])
REFERENCES [dbo].[PermisoComponente] ([PermisoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoUsuario_Permiso] CHECK CONSTRAINT [FK_TUP_Permiso]
GO
ALTER TABLE [dbo].[TipoUsuario_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_TUP_TipoUsuario] FOREIGN KEY([TipoUsuarioID])
REFERENCES [dbo].[TipoUsuario] ([TipoUsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoUsuario_Permiso] CHECK CONSTRAINT [FK_TUP_TipoUsuario]
GO
ALTER TABLE [dbo].[Usuario_TipoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_UTU_TipoUsuario] FOREIGN KEY([TipoUsuarioID])
REFERENCES [dbo].[TipoUsuario] ([TipoUsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_TipoUsuario] CHECK CONSTRAINT [FK_UTU_TipoUsuario]
GO
ALTER TABLE [dbo].[Usuario_TipoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_UTU_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_TipoUsuario] CHECK CONSTRAINT [FK_UTU_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Growshi] SET  READ_WRITE 
GO
