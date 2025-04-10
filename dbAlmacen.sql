USE [master]
GO
/****** Object:  Database [dbAlmacen]    Script Date: 9/04/2025 12:23:35 a. m. ******/
CREATE DATABASE [dbAlmacen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbAlmacen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbAlmacen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbAlmacen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbAlmacen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbAlmacen] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbAlmacen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbAlmacen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbAlmacen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbAlmacen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbAlmacen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbAlmacen] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbAlmacen] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbAlmacen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbAlmacen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbAlmacen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbAlmacen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbAlmacen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbAlmacen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbAlmacen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbAlmacen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbAlmacen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbAlmacen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbAlmacen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbAlmacen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbAlmacen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbAlmacen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbAlmacen] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [dbAlmacen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbAlmacen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbAlmacen] SET  MULTI_USER 
GO
ALTER DATABASE [dbAlmacen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbAlmacen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbAlmacen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbAlmacen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbAlmacen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbAlmacen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbAlmacen] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbAlmacen] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbAlmacen]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/04/2025 12:23:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignacionCliente]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionCliente](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[Visitado] [bit] NOT NULL,
	[FechaVisita] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoUsuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoUsuario](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[tipoUsuario] [nvarchar](max) NULL,
 CONSTRAINT [PK_tipoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [nvarchar](max) NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[TelefonoFijo] [nvarchar](max) NULL,
	[Celular] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Foto] [nvarchar](max) NULL,
	[Ubicacion] [nvarchar](max) NULL,
	[Estado] [nvarchar](max) NULL,
	[clave] [nvarchar](max) NULL,
	[IdTipo] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250408015503_MigraMike1', N'9.0.3')
GO
SET IDENTITY_INSERT [dbo].[AsignacionCliente] ON 

INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (13, 2, 4, CAST(N'2025-04-07T23:55:43.443' AS DateTime), 1, CAST(N'2025-04-09T00:04:09.420' AS DateTime))
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (14, 2, 5, CAST(N'2025-04-07T23:55:47.717' AS DateTime), 1, CAST(N'2025-04-07T23:55:53.153' AS DateTime))
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (15, 1, 2, CAST(N'2025-04-09T01:16:57.877' AS DateTime), 1, CAST(N'2025-04-09T01:16:57.877' AS DateTime))
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (16, 2, 7, CAST(N'2025-04-08T23:30:32.370' AS DateTime), 1, CAST(N'2025-04-09T00:21:21.617' AS DateTime))
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (17, 2, 8, CAST(N'2025-04-08T23:30:32.370' AS DateTime), 0, NULL)
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (18, 2, 8, CAST(N'2025-04-03T23:30:32.370' AS DateTime), 1, CAST(N'2025-04-05T23:30:32.370' AS DateTime))
INSERT [dbo].[AsignacionCliente] ([IdAsignacion], [IdVendedor], [IdCliente], [FechaAsignacion], [Visitado], [FechaVisita]) VALUES (19, 12, 10, CAST(N'2025-04-08T23:30:32.373' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[AsignacionCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoUsuario] ON 

INSERT [dbo].[tipoUsuario] ([IdTipo], [tipoUsuario]) VALUES (1, N'administrador')
INSERT [dbo].[tipoUsuario] ([IdTipo], [tipoUsuario]) VALUES (2, N'vendedor')
INSERT [dbo].[tipoUsuario] ([IdTipo], [tipoUsuario]) VALUES (3, N'cliente')
INSERT [dbo].[tipoUsuario] ([IdTipo], [tipoUsuario]) VALUES (4, N'almacenista')
INSERT [dbo].[tipoUsuario] ([IdTipo], [tipoUsuario]) VALUES (5, N'CEO')
SET IDENTITY_INSERT [dbo].[tipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (1, N'1052383163', N'Michael Alexander', N'Daza Vargas', N'Carrera 34 N°16 - 39', N'7606350', N'3123389141', N'michaeldaz23@gmail.com', N'mm', N'Duitama', N'1', N'1234', 1)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (2, N'1145325502', N'Maria Camila', N'Daza Vargas', N'Carrera 34 # 16-39', N'7606350', N'3224077963', N'camiladaza304@gmail.com', N'jajaja', N'Duitama', N'1', N'1234', 2)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (4, N'12345678', N'Dairo Gustavo ', N'Cardenas Walteros', N'Diagonar 17', N'2222', N'3148596371', N'dairo@gmail.com', N'', N'Tasco', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (5, N'222222', N'Maria Limbania', N'Vargas Acero', N'Carrera 34 # 16-39', N'7606350', N'3222687923', N'mariVargas@gmail.com', N'', N'Duitama', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (6, N'1052838205', N'Juan Sebastian', N'Silva Piñeros', N'Santa Rosa', N'1234565', N'3011708855', N'silvasebastian2703@gmail.com', N'f1.png', N'sogamoso', N'pendiente', N'1052838205', 4)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (7, N'98765432', N'Carlos Alberto', N'Rodriguez Perez', N'Calle 15 # 45-23', N'7452136', N'3156789012', N'carlosrp@gmail.com', N'', N'Sogamoso', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (8, N'87654321', N'Ana Maria', N'Sanchez Lopez', N'Avenida 23 # 56-12', N'7136542', N'3187654321', N'anamariasl@gmail.com', N'', N'Paipa', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (9, N'76543210', N'Jorge Luis', N'Martinez Gomez', N'Diagonal 34 # 12-45', N'7892345', N'3201234567', N'jorgeluis@gmail.com', N'', N'Duitama', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (10, N'65432109', N'Laura Sofia', N'Torres Ramirez', N'Carrera 12 # 34-56', N'7654321', N'3112345678', N'laurasofia@gmail.com', N'', N'Nobsa', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (11, N'54321098', N'Pedro Antonio', N'Jimenez Diaz', N'Calle 67 # 23-45', N'7908765', N'3134567890', N'pedroantonio@gmail.com', N'', N'Tibasosa', N'1', N'1234', 3)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (12, N'43210987', N'Juan Carlos', N'Mendez Castro', N'Carrera 56 # 78-90', N'7123456', N'3145678901', N'juancarlos@gmail.com', N'', N'Duitama', N'1', N'1234', 2)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (13, N'32109876', N'Sandra Patricia', N'Castillo Rojas', N'Avenida 45 # 67-89', N'7234567', N'3156789012', N'sandrapatricia@gmail.com', N'', N'Sogamoso', N'1', N'1234', 2)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (14, N'21098765', N'Roberto Jose', N'Duarte Ortiz', N'Calle 89 # 12-34', N'7345678', N'3167890123', N'robertojose@gmail.com', N'', N'Duitama', N'1', N'1234', 4)
INSERT [dbo].[usuario] ([IdUsuario], [Documento], [Nombres], [Apellidos], [Direccion], [TelefonoFijo], [Celular], [Email], [Foto], [Ubicacion], [Estado], [clave], [IdTipo]) VALUES (15, N'10987654', N'Monica Alejandra', N'Cardenas Suarez', N'Diagonal 67 # 89-12', N'7456789', N'3178901234', N'monicaalejandra@gmail.com', N'', N'Duitama', N'1', N'1234', 4)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
/****** Object:  Index [IX_usuario_IdTipo]    Script Date: 9/04/2025 12:23:36 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_usuario_IdTipo] ON [dbo].[usuario]
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AsignacionCliente] ADD  DEFAULT ((0)) FOR [Visitado]
GO
ALTER TABLE [dbo].[AsignacionCliente]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[AsignacionCliente]  WITH CHECK ADD FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_tipoUsuario_IdTipo] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[tipoUsuario] ([IdTipo])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_tipoUsuario_IdTipo]
GO
/****** Object:  StoredProcedure [dbo].[spActualizarUsuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spActualizarUsuario]
    @IdUsuario int,
    @Documento varchar(20),
    @Nombres varchar(50),
    @Apellidos varchar(50),
    @Direccion varchar(100),
    @TelefonoFijo varchar(20),
    @Celular varchar(20),
    @Email varchar(50),
    @Foto varchar(200),
    @Ubicacion varchar(100),
    @Estado bit,
    @Clave varchar(50),
    @IdTipo int
AS
BEGIN
    UPDATE usuario
    SET Documento = @Documento,
        Nombres = @Nombres,
        Apellidos = @Apellidos,
        Direccion = @Direccion,
        TelefonoFijo = @TelefonoFijo,
        Celular = @Celular,
        Email = @Email,
        Foto = @Foto,
        Ubicacion = @Ubicacion,
        Estado = @Estado,
        Clave = @Clave,
        IdTipo = @IdTipo
    WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[spAsignarClienteVendedor]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAsignarClienteVendedor]
    @IdVendedor int,
    @IdCliente int,
    @Resultado int OUTPUT -- Parámetro de salida
AS
BEGIN
    IF EXISTS (SELECT 1 FROM AsignacionCliente WHERE IdCliente = @IdCliente)
    BEGIN
        SET @Resultado = -1 -- Asignar el valor al parámetro de salida
        RETURN
    END
    
    IF NOT EXISTS (SELECT 1 FROM usuario WHERE IdUsuario = @IdVendedor AND IdTipo = 2)
    BEGIN
        SET @Resultado = -2
        RETURN
    END
    
    IF NOT EXISTS (SELECT 1 FROM usuario WHERE IdUsuario = @IdCliente AND IdTipo = 3)
    BEGIN
        SET @Resultado = -3
        RETURN
    END
    
    -- Insertar la asignación
    INSERT INTO AsignacionCliente (IdVendedor, IdCliente, FechaAsignacion, Visitado)
    VALUES (@IdVendedor, @IdCliente, GETDATE(), 0)
    
    -- Asignar el ID de la nueva asignación al parámetro de salida
    SET @Resultado = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarAsignacionCliente]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEliminarAsignacionCliente]
    @IdAsignacion int
AS
BEGIN
    DELETE FROM AsignacionCliente WHERE IdAsignacion = @IdAsignacion
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarUsuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEliminarUsuario]
    @IdUsuario int
AS
BEGIN
    DELETE FROM usuario WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarUsuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarUsuario]
    @Documento varchar(20),
    @Nombres varchar(50),
    @Apellidos varchar(50),
    @Direccion varchar(100),
    @TelefonoFijo varchar(20),
    @Celular varchar(20),
    @Email varchar(50),
    @Foto varchar(200),
    @Ubicacion varchar(100),
    @Estado bit,
    @Clave varchar(50),
    @IdTipo int
AS
BEGIN
    INSERT INTO usuario (Documento, Nombres, Apellidos, Direccion, TelefonoFijo, 
                         Celular, Email, Foto, Ubicacion, Estado, Clave, IdTipo)
    VALUES (@Documento, @Nombres, @Apellidos, @Direccion, @TelefonoFijo, 
            @Celular, @Email, @Foto, @Ubicacion, @Estado, @Clave, @IdTipo)
    
    SELECT SCOPE_IDENTITY() AS IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[spListarClientesAsignados]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarClientesAsignados]
    @IdVendedor int = NULL
AS
BEGIN
    SELECT a.IdAsignacion, a.IdVendedor, v.Nombres + ' ' + v.Apellidos AS NombreVendedor,
           a.IdCliente, c.Nombres + ' ' + c.Apellidos AS NombreCliente,
           a.FechaAsignacion, a.Visitado, a.FechaVisita
    FROM AsignacionCliente a
    INNER JOIN usuario v ON a.IdVendedor = v.IdUsuario
    INNER JOIN usuario c ON a.IdCliente = c.IdUsuario
    WHERE (@IdVendedor IS NULL OR a.IdVendedor = @IdVendedor)
END
GO
/****** Object:  StoredProcedure [dbo].[spListarClientesDisponibles]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarClientesDisponibles]
AS
BEGIN
    SELECT u.IdUsuario, u.Documento, u.Nombres, u.Apellidos
    FROM usuario u
    WHERE u.IdTipo = 3 
    AND u.IdUsuario NOT IN (SELECT IdCliente FROM AsignacionCliente)
END
GO
/****** Object:  StoredProcedure [dbo].[spListarClientesVisitados]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarClientesVisitados]
AS
BEGIN
    SELECT a.IdAsignacion, a.IdVendedor, v.Nombres + ' ' + v.Apellidos AS NombreVendedor,
           a.IdCliente, c.Nombres + ' ' + c.Apellidos AS NombreCliente,
           a.FechaAsignacion, a.Visitado, a.FechaVisita
    FROM AsignacionCliente a
    INNER JOIN usuario v ON a.IdVendedor = v.IdUsuario
    INNER JOIN usuario c ON a.IdCliente = c.IdUsuario
    WHERE a.Visitado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spListarTiposUsuario]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarTiposUsuario]
AS
BEGIN
    SELECT IdTipo, tipoUsuario FROM tipoUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[spListarUsuarios]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarUsuarios]
AS
BEGIN
    SELECT u.IdUsuario, u.Documento, u.Nombres, u.Apellidos, u.Direccion, 
           u.TelefonoFijo, u.Celular, u.Email, u.Foto, u.Ubicacion, u.Estado, 
           u.Clave, u.IdTipo, t.tipoUsuario
    FROM usuario u
    INNER JOIN tipoUsuario t ON u.IdTipo = t.IdTipo
END
GO
/****** Object:  StoredProcedure [dbo].[spListarVendedores]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarVendedores]
AS
BEGIN
    SELECT u.IdUsuario, u.Documento, u.Nombres, u.Apellidos
    FROM usuario u
    WHERE u.IdTipo = 2 
END
GO
/****** Object:  StoredProcedure [dbo].[spMarcarClienteVisitado]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spMarcarClienteVisitado]
    @IdAsignacion int
AS
BEGIN
    UPDATE AsignacionCliente
    SET Visitado = 1,
        FechaVisita = GETDATE()
    WHERE IdAsignacion = @IdAsignacion
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerUsuarioPorId]    Script Date: 9/04/2025 12:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerUsuarioPorId]
    @IdUsuario int
AS
BEGIN
    SELECT u.IdUsuario, u.Documento, u.Nombres, u.Apellidos, u.Direccion, 
           u.TelefonoFijo, u.Celular, u.Email, u.Foto, u.Ubicacion, u.Estado, 
           u.Clave, u.IdTipo, t.tipoUsuario
    FROM usuario u
    INNER JOIN tipoUsuario t ON u.IdTipo = t.IdTipo
    WHERE IdUsuario = @IdUsuario
END
GO
USE [master]
GO
ALTER DATABASE [dbAlmacen] SET  READ_WRITE 
GO
