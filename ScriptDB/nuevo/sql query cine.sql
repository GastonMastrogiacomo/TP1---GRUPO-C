USE [cine]
GO
/****** Object:  Table [dbo].[Funciones]    Script Date: 27/5/2023 5:55:41 p. m. ******/
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
/****** Object:  Table [dbo].[Peliculas]    Script Date: 27/5/2023 5:55:41 p. m. ******/
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
/****** Object:  Table [dbo].[Salas]    Script Date: 27/5/2023 5:55:41 p. m. ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/5/2023 5:55:41 p. m. ******/
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
/****** Object:  Table [dbo].[UsuariosFunciones]    Script Date: 27/5/2023 5:55:41 p. m. ******/
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
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_Pelicula] FOREIGN KEY([id_pelicula])
REFERENCES [dbo].[Peliculas] ([id])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_Pelicula]
GO
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_Sala] FOREIGN KEY([id_sala])
REFERENCES [dbo].[Salas] ([id])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_Sala]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Peliculas] FOREIGN KEY([id])
REFERENCES [dbo].[Peliculas] ([id])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Peliculas]
GO
ALTER TABLE [dbo].[Salas]  WITH CHECK ADD  CONSTRAINT [FK_Salas_Salas] FOREIGN KEY([id])
REFERENCES [dbo].[Salas] ([id])
GO
ALTER TABLE [dbo].[Salas] CHECK CONSTRAINT [FK_Salas_Salas]
GO
ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Funciones] FOREIGN KEY([id_funcion])
REFERENCES [dbo].[Funciones] ([id])
GO
ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Funciones]
GO
ALTER TABLE [dbo].[UsuariosFunciones]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosFunciones_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[UsuariosFunciones] CHECK CONSTRAINT [FK_UsuariosFunciones_Usuarios]
GO
