USE [master]
GO
/****** Object:  Database [catalanacontables]    Script Date: 16/6/2020 19:46:11 ******/
CREATE DATABASE [catalanacontables]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'catalanacontables', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\catalanacontables.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'catalanacontables_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\catalanacontables_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [catalanacontables] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [catalanacontables].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [catalanacontables] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [catalanacontables] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [catalanacontables] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [catalanacontables] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [catalanacontables] SET ARITHABORT OFF 
GO
ALTER DATABASE [catalanacontables] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [catalanacontables] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [catalanacontables] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [catalanacontables] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [catalanacontables] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [catalanacontables] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [catalanacontables] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [catalanacontables] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [catalanacontables] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [catalanacontables] SET  DISABLE_BROKER 
GO
ALTER DATABASE [catalanacontables] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [catalanacontables] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [catalanacontables] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [catalanacontables] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [catalanacontables] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [catalanacontables] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [catalanacontables] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [catalanacontables] SET RECOVERY FULL 
GO
ALTER DATABASE [catalanacontables] SET  MULTI_USER 
GO
ALTER DATABASE [catalanacontables] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [catalanacontables] SET DB_CHAINING OFF 
GO
ALTER DATABASE [catalanacontables] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [catalanacontables] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [catalanacontables] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'catalanacontables', N'ON'
GO
ALTER DATABASE [catalanacontables] SET QUERY_STORE = OFF
GO
USE [catalanacontables]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[area] [varchar](200) NULL,
	[empresa_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cargo] [varchar](200) NULL,
	[departamento_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departamento] [varchar](200) NULL,
	[area_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[id] [int] NOT NULL,
	[empresa] [varchar](200) NULL,
	[abreviatura] [varchar](50) NULL,
 CONSTRAINT [PK__Empresas__3213E83F9DC34565] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[permiso] [varchar](200) NOT NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos_Usuarios]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos_Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[permiso_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rol] [varchar](200) NOT NULL,
	[descripcion] [text] NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/6/2020 19:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](250) NOT NULL,
	[apellidos] [varchar](250) NOT NULL,
	[usuario] [varchar](250) NOT NULL,
	[empresa_id] [int] NULL,
	[area_id] [int] NULL,
	[departamento_id] [int] NULL,
	[cargo_id] [int] NULL,
	[dui] [varchar](200) NULL,
	[password] [varchar](300) NOT NULL,
	[idempleado] [int] NULL,
	[rol_id] [int] NULL,
	[createdAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permisos] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [fk_areas] FOREIGN KEY([empresa_id])
REFERENCES [dbo].[Empresas] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [fk_areas]
GO
ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD  CONSTRAINT [fk_cargos] FOREIGN KEY([departamento_id])
REFERENCES [dbo].[Departamentos] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cargos] CHECK CONSTRAINT [fk_cargos]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [fk_depa] FOREIGN KEY([area_id])
REFERENCES [dbo].[Areas] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [fk_depa]
GO
ALTER TABLE [dbo].[Permisos_Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_permisoP] FOREIGN KEY([permiso_id])
REFERENCES [dbo].[Permisos] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Permisos_Usuarios] CHECK CONSTRAINT [fk_permisoP]
GO
ALTER TABLE [dbo].[Permisos_Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_usuarioP] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuarios] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Permisos_Usuarios] CHECK CONSTRAINT [fk_usuarioP]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_areaU] FOREIGN KEY([area_id])
REFERENCES [dbo].[Areas] ([id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_areaU]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_cargoU] FOREIGN KEY([cargo_id])
REFERENCES [dbo].[Cargos] ([id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_cargoU]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_depaU] FOREIGN KEY([departamento_id])
REFERENCES [dbo].[Departamentos] ([id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_depaU]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_empresaU] FOREIGN KEY([empresa_id])
REFERENCES [dbo].[Empresas] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_empresaU]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_rolU] FOREIGN KEY([rol_id])
REFERENCES [dbo].[Roles] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_rolU]
GO
USE [master]
GO
ALTER DATABASE [catalanacontables] SET  READ_WRITE 
GO
