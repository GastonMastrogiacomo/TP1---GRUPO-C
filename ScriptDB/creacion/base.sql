USE [master]
GO
/****** Object:  Database [cine]    Script Date: 28/5/2023 1:21:44 p. m. ******/
CREATE DATABASE [cine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cine', FILENAME = N'F:\SQL EXPRESS\MSSQL16.SQLEXPRESS\MSSQL\DATA\cine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cine_log', FILENAME = N'F:\SQL EXPRESS\MSSQL16.SQLEXPRESS\MSSQL\DATA\cine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [cine] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cine] SET ARITHABORT OFF 
GO
ALTER DATABASE [cine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cine] SET  MULTI_USER 
GO
ALTER DATABASE [cine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [cine] SET QUERY_STORE = ON
GO
ALTER DATABASE [cine] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [cine]
GO
/****** Object:  Table [dbo].[Funciones]    Script Date: 28/5/2023 1:21:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[asientos_disponibles] [int] NULL,
	[costo] [float] NULL,
	[id_sala] [int] NULL,
	[id_pelicula] [int] NULL,
 CONSTRAINT [PK_Funciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 28/5/2023 1:21:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
	[sinopsis] [varchar](max) NULL,
	[poster] [varchar](50) NULL,
	[duracion] [int] NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salas]    Script Date: 28/5/2023 1:21:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ubicacion] [varchar](50) NULL,
	[capacidad] [int] NULL,
 CONSTRAINT [PK_Salas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 28/5/2023 1:21:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[fecha_nacimiento] [date] NULL,
	[credito] [float] NULL,
	[es_admin] [bit] NULL,
	[bloqueado] [bit] NULL,
	[Intentos_fallidos] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosFunciones]    Script Date: 28/5/2023 1:21:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosFunciones](
	[id_usuario] [int] NULL,
	[id_funcion] [int] NULL,
	[cantidad_entradas_compradas] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Funciones] ON 

INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (1, CAST(N'2023-06-15T09:00:00.000' AS DateTime), 200, 2000, 1, 1)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (2, CAST(N'2023-06-16T12:00:00.000' AS DateTime), 150, 2500, 1, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (3, CAST(N'2023-06-17T16:30:00.000' AS DateTime), 250, 1500, 2, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (4, CAST(N'2023-06-18T20:30:00.000' AS DateTime), 175, 1000, 2, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (5, CAST(N'2023-06-14T21:00:00.000' AS DateTime), 300, 2200, 2, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (6, CAST(N'2023-05-27T21:00:00.000' AS DateTime), 300, 2200, 2, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (7, CAST(N'2023-06-19T14:00:00.000' AS DateTime), 200, 1800, 3, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (8, CAST(N'2023-06-20T17:30:00.000' AS DateTime), 180, 1500, 3, 4)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (9, CAST(N'2023-06-21T19:45:00.000' AS DateTime), 250, 1200, 4, 4)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (10, CAST(N'2023-06-22T21:15:00.000' AS DateTime), 175, 1000, 4, 4)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (11, CAST(N'2023-06-23T18:30:00.000' AS DateTime), 300, 2000, 1, 1)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (12, CAST(N'2023-06-24T15:45:00.000' AS DateTime), 280, 2200, 1, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (13, CAST(N'2023-06-25T20:00:00.000' AS DateTime), 220, 1900, 2, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (14, CAST(N'2023-06-26T12:30:00.000' AS DateTime), 190, 1700, 2, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (15, CAST(N'2023-06-27T16:15:00.000' AS DateTime), 230, 1400, 3, 1)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (16, CAST(N'2023-06-28T19:30:00.000' AS DateTime), 200, 1200, 3, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (17, CAST(N'2023-06-29T21:45:00.000' AS DateTime), 250, 1000, 4, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (18, CAST(N'2023-06-30T15:00:00.000' AS DateTime), 300, 2200, 4, 2)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (19, CAST(N'2023-07-01T18:15:00.000' AS DateTime), 270, 1900, 1, 3)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (20, CAST(N'2023-07-02T13:30:00.000' AS DateTime), 230, 1700, 1, 4)
INSERT [dbo].[Funciones] ([id], [fecha], [asientos_disponibles], [costo], [id_sala], [id_pelicula]) VALUES (21, CAST(N'2023-07-03T17:45:00.000' AS DateTime), 190, 1400, 2, 1)
SET IDENTITY_INSERT [dbo].[Funciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (1, N'Toy Story', N'Pelicula de juguetes.', N'Juguetes', N' ', 120)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (2, N'Mario Bros', N'Its me Mario!', N'Nintendo', N' ', 100)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (3, N'Mario 2', N'Its me Mario2!', N'Nintendo2', N' ', 110)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (4, N'Rapido y Furioso 10', N'Autitos chocadores', N'Carreras y Acción', N' ', 150)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (5, N'Avengers: Endgame', N'Los héroes luchan contra Thanos', N'Acción y Superhéroes', N' ', 180)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (6, N'La La Land', N'Historia de amor y música', N'Drama y Romance', N' ', 128)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (7, N'Jurassic Park', N'Parque temático de dinosaurios', N'Aventura y Ciencia Ficción', N' ', 127)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (8, N'El Padrino', N'Mafia y crimen organizado', N'Drama y Crimen', N' ', 175)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (9, N'Harry Potter y la piedra filosofal', N'Magia y aventuras', N'Fantasía y Aventura', N' ', 152)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (10, N'Titanic', N'Trágica historia de amor en el Titanic', N'Drama y Romance', N' ', 194)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (11, N'The Dark Knight', N'Batman contra el Joker', N'Acción y Superhéroes', N' ', 152)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (12, N'Forrest Gump', N'Historia de vida y superación', N'Drama y Comedia', N' ', 142)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (13, N'Pulp Fiction', N'Historias entrelazadas de criminales', N'Drama y Crimen', N' ', 154)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (14, N'El Señor de los Anillos: La Comunidad del Anillo', N'Aventuras en la Tierra Media', N'Fantasía y Aventura', N' ', 178)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (15, N'Matrix', N'Realidad virtual y lucha contra las máquinas', N'Ciencia Ficción y Acción', N' ', 136)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (16, N'El Rey León', N'Historia de leones', N'Animación y Aventura', N' ', 88)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (17, N'Interestelar', N'Viajes espaciales y agujeros negros', N'Ciencia Ficción y Aventura', N' ', 169)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (18, N'El Gran Gatsby', N'Ambición y decadencia en los años 20', N'Drama y Romance', N' ', 143)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (19, N'Gladiador', N'Épica historia de un gladiador romano', N'Acción y Drama', N' ', 155)
INSERT [dbo].[Peliculas] ([id], [nombre], [descripcion], [sinopsis], [poster], [duracion]) VALUES (20, N'E.T. el Extraterrestre', N'Amistad entre un niño y un extraterrestre', N'Ciencia Ficción y Aventura', N' ', 115)
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
SET IDENTITY_INSERT [dbo].[Salas] ON 

INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (1, N'Olivos', 100)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (2, N'San Isidro', 200)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (3, N'Caballito', 500)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (4, N'Palermo', 300)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (5, N'Recoleta', 150)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (6, N'Belgrano', 100)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (7, N'La Plata', 200)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (8, N'Mar del Plata', 250)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (9, N'Córdoba', 180)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (10, N'Rosario', 120)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (11, N'Mendoza', 160)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (12, N'Tigre', 80)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (13, N'Quilmes', 110)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (14, N'San Miguel', 140)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (15, N'Lomas de Zamora', 90)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (16, N'Morón', 130)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (17, N'Avellaneda', 100)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (18, N'Banfield', 70)
INSERT [dbo].[Salas] ([id], [ubicacion], [capacidad]) VALUES (19, N'La Matanza', 200)
SET IDENTITY_INSERT [dbo].[Salas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (1, 1111, N'Pepe', N'Perez', N'pepe@mail.com', N'123', CAST(N'1992-11-02' AS Date), 1000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (2, 2222, N'El', N'Admin', N'admin@mail.com', N'123', CAST(N'1990-06-08' AS Date), 0, 1, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (3, 3333, N'Lucas', N'Rodriguez', N'lucas@mail.com', N'123', CAST(N'1995-08-24' AS Date), 3000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (4, 4444, N'Ana', N'González', N'ana@mail.com', N'123', CAST(N'1988-05-15' AS Date), 500, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (5, 5555, N'María', N'López', N'maria@mail.com', N'123', CAST(N'1993-09-30' AS Date), 200, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (6, 6666, N'Luis', N'Fernández', N'luis@mail.com', N'123', CAST(N'1994-12-10' AS Date), 800, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (7, 7777, N'Laura', N'Martínez', N'laura@mail.com', N'123', CAST(N'1991-07-18' AS Date), 1500, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (8, 8888, N'Carlos', N'Gómez', N'carlos@mail.com', N'123', CAST(N'1996-03-25' AS Date), 1200, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (9, 9999, N'Ana', N'Rodríguez', N'ana.rodriguez@mail.com', N'123', CAST(N'1989-09-12' AS Date), 2500, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (10, 1010, N'Marcelo', N'López', N'marcelo@mail.com', N'123', CAST(N'1997-11-28' AS Date), 300, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (11, 1112, N'Julia', N'Torres', N'julia@mail.com', N'123', CAST(N'1993-02-04' AS Date), 1800, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (12, 1213, N'Mariano', N'García', N'mariano@mail.com', N'123', CAST(N'1995-06-22' AS Date), 5000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (13, 1314, N'Gabriela', N'López', N'gabriela@mail.com', N'123', CAST(N'1990-10-08' AS Date), 700, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (14, 1415, N'Federico', N'Pérez', N'federico@mail.com', N'123', CAST(N'1994-04-16' AS Date), 1000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (15, 1516, N'Carolina', N'Fernández', N'carolina@mail.com', N'123', CAST(N'1991-08-14' AS Date), 250, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (16, 1617, N'Luciana', N'González', N'luciana@mail.com', N'123', CAST(N'1988-12-30' AS Date), 3500, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (17, 1718, N'Martín', N'Martínez', N'martin@mail.com', N'123', CAST(N'1997-03-17' AS Date), 900, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (18, 1819, N'Paula', N'Gómez', N'paula@mail.com', N'123', CAST(N'1992-09-24' AS Date), 2000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (19, 1920, N'Diego', N'Rodríguez', N'diego.rodriguez@mail.com', N'123', CAST(N'1996-01-11' AS Date), 3000, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (20, 2021, N'Sofía', N'López', N'sofia@mail.com', N'123', CAST(N'1993-05-28' AS Date), 600, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [dni], [nombre], [apellido], [mail], [password], [fecha_nacimiento], [credito], [es_admin], [bloqueado], [Intentos_fallidos]) VALUES (21, 2122, N'Agustín', N'Torres', N'agustin@mail.com', N'123', CAST(N'1989-11-01' AS Date), 1400, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (1, 1, 1)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (1, 2, 4)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (1, 3, 1)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (3, 4, 3)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (3, 5, 2)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (4, 9, 2)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (4, 10, 4)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (4, 11, 2)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (6, 12, 3)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (6, 13, 1)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (6, 14, 4)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (8, 15, 2)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (8, 16, 3)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (8, 17, 1)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (10, 18, 4)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (10, 19, 2)
INSERT [dbo].[UsuariosFunciones] ([id_usuario], [id_funcion], [cantidad_entradas_compradas]) VALUES (10, 20, 3)
GO
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_Salas] FOREIGN KEY([id_sala])
REFERENCES [dbo].[Salas] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_Salas]
GO
ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Funciones] FOREIGN KEY([id_funcion])
REFERENCES [dbo].[Funciones] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Funciones]
GO
ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [cine] SET  READ_WRITE 
GO
