--ALTER DATABASE [cine] SET COMPATIBILITY_LEVEL = 160
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [cine].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [cine] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [cine] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [cine] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [cine] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [cine] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [cine] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [cine] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [cine] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [cine] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [cine] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [cine] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [cine] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [cine] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [cine] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [cine] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [cine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [cine] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [cine] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [cine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [cine] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [cine] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [cine] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [cine] SET RECOVERY SIMPLE 
--GO
--ALTER DATABASE [cine] SET  MULTI_USER 
--GO
--ALTER DATABASE [cine] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [cine] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [cine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [cine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
--GO
--ALTER DATABASE [cine] SET DELAYED_DURABILITY = DISABLED 
--GO
--ALTER DATABASE [cine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
--GO
--ALTER DATABASE [cine] SET QUERY_STORE = ON
--GO
--ALTER DATABASE [cine] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
--GO
--USE [cine]
--GO
--/****** Object:  Table [dbo].[Funciones]    Script Date: 5/25/2023 6:58:06 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Funciones](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[fecha] [datetime] NULL,
--	[asientos_disponibles] [int] NULL,
--	[costo] [numeric](18, 2) NULL,
--	[id_sala] [int] NULL,
--	[id_pelicula] [int] NULL,
-- CONSTRAINT [PK_Funciones] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Peliculas]    Script Date: 5/25/2023 6:58:06 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Peliculas](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[nombre] [varchar](50) NULL,
--	[descripcion] [varchar](max) NULL,
--	[sinopsis] [varchar](max) NULL,
--	[poster] [varchar](50) NULL,
--	[duracion] [int] NULL,
-- CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Salas]    Script Date: 5/25/2023 6:58:06 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Salas](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[ubicacion] [varchar](50) NULL,
--	[capacidad] [int] NULL,
-- CONSTRAINT [PK_Salas] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/25/2023 6:58:06 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Usuarios](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[dni] [int] NULL,
--	[nombre] [varchar](50) NULL,
--	[apellido] [varchar](50) NULL,
--	[mail] [varchar](50) NULL,
--	[password] [varchar](50) NULL,
--	[fecha_nacimiento] [date] NULL,
--	[credito] [numeric](18, 2) NULL,
--	[es_admin] [bit] NULL,
--	[bloqueado] [bit] NULL,
-- CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[UsuariosFunciones]    Script Date: 5/25/2023 6:58:06 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[UsuariosFunciones](
--	[id_usuario] [int] NULL,
--	[id_funcion] [int] NULL,
--	[cantidad_entradas_compradas] [int] NULL
--) ON [PRIMARY]
--GO
--ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_Pelicula] FOREIGN KEY([id_pelicula])
--REFERENCES [dbo].[Peliculas] ([id])
--GO
--ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_Pelicula]
--GO
--ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_Sala] FOREIGN KEY([id_sala])
--REFERENCES [dbo].[Salas] ([id])
--GO
--ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_Sala]
--GO
--ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Peliculas] FOREIGN KEY([id])
--REFERENCES [dbo].[Peliculas] ([id])
--GO
--ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Peliculas]
--GO
--ALTER TABLE [dbo].[Salas]  WITH CHECK ADD  CONSTRAINT [FK_Salas_Salas] FOREIGN KEY([id])
--REFERENCES [dbo].[Salas] ([id])
--GO
--ALTER TABLE [dbo].[Salas] CHECK CONSTRAINT [FK_Salas_Salas]
--GO
--ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Funciones] FOREIGN KEY([id_funcion])
--REFERENCES [dbo].[Funciones] ([id])
--GO
--ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Funciones]
--GO
--ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Usuarios] FOREIGN KEY([id_usuario])
--REFERENCES [dbo].[Usuarios] ([id])
--GO
--ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Usuarios]
--GO
--USE [master]
--GO
--ALTER DATABASE [cine] SET  READ_WRITE 
--GO
