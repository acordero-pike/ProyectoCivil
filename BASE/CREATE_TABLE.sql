USE [master]
GO
/****** Object:  Database [Bombero]    Script Date: 5/10/2022 07:16:29 ******/
CREATE DATABASE [Bombero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bombero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Bombero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bombero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Bombero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Bombero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bombero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bombero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bombero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bombero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bombero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bombero] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bombero] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Bombero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bombero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bombero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bombero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bombero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bombero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bombero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bombero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bombero] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Bombero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bombero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bombero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bombero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bombero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bombero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bombero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bombero] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bombero] SET  MULTI_USER 
GO
ALTER DATABASE [Bombero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bombero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bombero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bombero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bombero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bombero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Bombero] SET QUERY_STORE = OFF
GO
USE [Bombero]
GO
/****** Object:  Table [dbo].[ClaseFuego]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaseFuego](
	[id_cf] [varchar](36) NOT NULL,
	[cf_Clasefuego] [varchar](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compañia]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compañia](
	[ID_Compañia] [varchar](36) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Compañia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estacion]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estacion](
	[ID_Estacion] [varchar](36) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[ID_Firma] [varchar](36) NOT NULL,
	[Tipo] [varchar](20) NULL,
	[Nombre] [varchar](25) NULL,
	[Firma] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Firma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InEstructural]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InEstructural](
	[id_ie] [varchar](36) NOT NULL,
	[ie_Estacion] [varchar](36) NULL,
	[ie_Turno] [varchar](36) NULL,
	[ie_UbiSiniestro] [varchar](50) NULL,
	[ie_Inmueble] [varchar](50) NULL,
	[ie_Valor] [float] NULL,
	[ie_Perdida] [float] NULL,
	[id_prop] [varchar](36) NULL,
	[ie_id_cf] [varchar](36) NULL,
	[ie_HoraSalida] [time](7) NULL,
	[ie_HoraServicio] [time](7) NULL,
	[ie_HoraEntrada] [time](7) NULL,
	[ie_JefeServicio] [varchar](46) NULL,
	[ie_TelefonistaTurno] [varchar](46) NULL,
	[ie_BomberoReporta] [varchar](46) NULL,
	[ie_Piloto] [varchar](46) NULL,
	[ie_Unidad] [varchar](50) NULL,
	[ie_UniAsisEstacion] [varchar](100) NULL,
	[ie_UniAsisOtraEstacion] [varchar](100) NULL,
	[ie_UniPoliciacas] [varchar](100) NULL,
	[ie_UniOtrasInstiBomberiles] [varchar](100) NULL,
	[ie_PersonalAsisEstacion] [varchar](200) NULL,
	[ie_PersonalAsisOtraEstacion] [varchar](200) NULL,
	[ie_Observacion] [varchar](500) NULL,
	[ie_Fecha] [date] NULL,
	[ie_KmEntrada] [float] NULL,
	[ie_KmSalida] [float] NULL,
	[ie_KmRecorrido] [float] NULL,
	[ie_FirmaBombero] [varchar](36) NULL,
	[ie_NoBombero] [bigint] NULL,
	[ie_VoBoJefeServicio] [varchar](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InForestal]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InForestal](
	[id_if] [varchar](36) NOT NULL,
	[if_Estacion] [varchar](36) NULL,
	[if_Turno] [varchar](36) NULL,
	[if_UbiSiniestro] [varchar](100) NULL,
	[if_AreaAfectada] [varchar](100) NULL,
	[if_TipoTerreno] [varchar](100) NULL,
	[id_prop] [varchar](36) NULL,
	[id_cf] [varchar](36) NULL,
	[if_HoraSalida] [time](7) NULL,
	[if_HoraServicio] [time](7) NULL,
	[if_HoraEntrada] [time](7) NULL,
	[if_JefeServicio] [varchar](46) NULL,
	[if_TelefonistaTurno] [varchar](46) NULL,
	[if_BomberoReporta] [varchar](46) NULL,
	[if_Piloto] [varchar](46) NULL,
	[if_Unidad] [varchar](50) NULL,
	[if_UniAsisEstacion] [varchar](100) NULL,
	[if_UniAsisOtraEstacion] [varchar](100) NULL,
	[if_UniPoliciacas] [varchar](100) NULL,
	[if_UniOtrasInstiBomberiles] [varchar](100) NULL,
	[if_PersonalAsisEstacion] [varchar](100) NULL,
	[if_PersonalAsisOtraEstacion] [varchar](100) NULL,
	[if_Observacion] [varchar](500) NULL,
	[if_Fecha] [date] NULL,
	[if_KmEntrada] [float] NULL,
	[if_KmSalida] [float] NULL,
	[if_KmRecorrido] [float] NULL,
	[if_FirmaBombero] [varchar](36) NULL,
	[if_NoBombero] [bigint] NULL,
	[if_VoBoJefeServicio] [varchar](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_if] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InVehiculo]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InVehiculo](
	[id_iv] [varchar](36) NOT NULL,
	[iv_Estacion] [varchar](36) NULL,
	[iv_Turno] [varchar](36) NULL,
	[iv_UbiSiniestro] [varchar](100) NULL,
	[iv_TipoVehiculo] [varchar](100) NULL,
	[iv_Placa] [varchar](100) NULL,
	[iv_Color] [varchar](100) NULL,
	[iv_Marca] [varchar](100) NULL,
	[iv_Valor] [float] NULL,
	[iv_Perdida] [float] NULL,
	[id_prop] [varchar](36) NULL,
	[id_cf] [varchar](36) NULL,
	[iv_HoraSalida] [time](7) NULL,
	[iv_HoraServicio] [time](7) NULL,
	[iv_HoraEntrada] [time](7) NULL,
	[iv_JefeServicio] [varchar](46) NULL,
	[iv_TelefonistaTurno] [varchar](46) NULL,
	[iv_BomberoReporta] [varchar](46) NULL,
	[iv_Piloto] [varchar](46) NULL,
	[iv_Unidad] [varchar](50) NULL,
	[iv_UniAsisEstacion] [varchar](100) NULL,
	[iv_UniAsisOtraEstacion] [varchar](100) NULL,
	[iv_UniPoliciacas] [varchar](100) NULL,
	[iv_UniOtrasInstiBomberiles] [varchar](100) NULL,
	[iv_PersonalAsisEstacion] [varchar](100) NULL,
	[iv_PersonalAsisOtraEstacion] [varchar](100) NULL,
	[iv_Observacion] [varchar](500) NULL,
	[iv_Fecha] [date] NULL,
	[iv_KmEntrada] [float] NULL,
	[iv_KmSalida] [float] NULL,
	[iv_KmRecorrido] [float] NULL,
	[iv_FirmaBombero] [varchar](36) NULL,
	[iv_NoBombero] [bigint] NULL,
	[iv_VoBoJefeServicio] [varchar](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_iv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[ID_Personal] [varchar](46) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Direccion] [varchar](15) NULL,
	[Puesto] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proporcion]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proporcion](
	[id_prop] [varchar](36) NOT NULL,
	[p_TipoProp] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioPrevencion]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicioPrevencion](
	[id_sp] [varchar](36) NOT NULL,
	[sp_Direccion] [varchar](100) NULL,
	[sp_NombreRazonsocial] [varchar](50) NULL,
	[sp_GeneralesServPrestado] [varchar](150) NULL,
	[sp_Establecimiento] [varchar](50) NULL,
	[sp_HoraSalida] [time](7) NULL,
	[sp_HoraEntrada] [time](7) NULL,
	[sp_Unidad] [varchar](50) NULL,
	[sp_Piloto] [varchar](46) NULL,
	[sp_FormaAviso] [varchar](50) NULL,
	[sp_Telefonista] [varchar](46) NULL,
	[sp_OficialServicio] [varchar](46) NULL,
	[sp_Estacion] [varchar](36) NULL,
	[sp_Compañia] [varchar](36) NULL,
	[sp_Turno] [varchar](36) NULL,
	[sp_Observacion] [varchar](500) NULL,
	[sp_KmSalida] [float] NULL,
	[sp_KmEntrada] [float] NULL,
	[sp_KmTotal] [float] NULL,
	[sp_BomberoReporta] [varchar](46) NULL,
	[sp_Fecha] [date] NULL,
	[sp_VoBoJefeServicio] [varchar](36) NULL,
 CONSTRAINT [PK_ServicioPrevencion] PRIMARY KEY CLUSTERED 
(
	[id_sp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioRescate]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicioRescate](
	[id_sr] [varchar](36) NOT NULL,
	[sr_Estacion] [varchar](36) NULL,
	[sr_DireccionRescate] [varchar](100) NULL,
	[sr_LugarLocalizacion] [varchar](100) NULL,
	[sr_Estado] [varchar](100) NULL,
	[sr_NombresPaciente] [varchar](100) NULL,
	[sr_ApellidosPaciente] [varchar](100) NULL,
	[sr_Causa] [varchar](100) NULL,
	[sr_DireccionPaciente] [varchar](100) NULL,
	[sr_Edad] [int] NULL,
	[sr_Sexo] [varchar](1) NULL,
	[sr_RopaColor] [varchar](100) NULL,
	[sr_ColorZapatos] [varchar](100) NULL,
	[sr_ObjetosPortaba] [varchar](100) NULL,
	[sr_ColorPelo] [varchar](100) NULL,
	[sr_AproxEstatura] [varchar](100) NULL,
	[sr_PosicionEncontro] [varchar](100) NULL,
	[sr_Traslado] [varchar](100) NULL,
	[sr_Unidad] [varchar](100) NULL,
	[sr_OtrasUniAsis] [varchar](100) NULL,
	[sr_NombreJuez] [varchar](100) NULL,
	[sr_SeñalesPartRescatado] [varchar](100) NULL,
	[sr_FormaAviso] [varchar](100) NULL,
	[sr_NoTelLlamaron] [int] NULL,
	[sr_SiglasRadioLlamaron] [varchar](100) NULL,
	[sr_RadioOpTurnoCentral] [varchar](100) NULL,
	[sr_TelefonistaTurnoEstacion] [varchar](46) NULL,
	[sr_OficialMando] [varchar](46) NULL,
	[sr_HoraSalida] [time](7) NULL,
	[sr_HoraEntrada] [time](7) NULL,
	[sr_Patrullas_CarSeg] [varchar](100) NULL,
	[sr_PersonalAsistente] [varchar](100) NULL,
	[sr_Observacion] [varchar](500) NULL,
	[sr_KmSalida] [float] NULL,
	[sr_KmEntrada] [float] NULL,
	[sr_KmTotal] [float] NULL,
	[sr_BomberoReporta] [varchar](46) NULL,
	[sr_Fecha] [date] NULL,
	[sr_VoBoJefeServicio] [varchar](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioVario]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicioVario](
	[id_sv] [varchar](36) NOT NULL,
	[sv_Estacion] [varchar](20) NULL,
	[sv_Turno] [varchar](20) NULL,
	[sv_Fecha] [date] NULL,
	[sv_Direccion] [varchar](100) NULL,
	[sv_Servicio] [varchar](100) NULL,
	[sv_HoraSalida] [time](7) NULL,
	[sv_horaEntrada] [time](7) NULL,
	[sv_JefeServicio] [varchar](46) NULL,
	[sv_TelefonistaTurno] [varchar](46) NULL,
	[sv_BomberoReporta] [varchar](46) NULL,
	[sv_Unidad] [varchar](50) NULL,
	[sv_Piloto] [varchar](46) NULL,
	[sv_ServicioAutPor] [varchar](46) NULL,
	[sv_PersonalAsistente] [varchar](46) NULL,
	[sv_Observacion] [varchar](500) NULL,
	[sv_KmEntrada] [float] NULL,
	[sv_KmSalida] [float] NULL,
	[sv_KmRecorrido] [float] NULL,
	[sv_FirmaBombero] [varchar](36) NULL,
	[sv_NoBombero] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[ID_Turno] [varchar](36) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Horario] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 5/10/2022 07:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [varchar](46) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Activo] [bit] NULL,
	[us_Usuario] [varchar](20) NULL,
	[us_Contraseña] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClaseFuego] ADD  DEFAULT (newid()) FOR [id_cf]
GO
ALTER TABLE [dbo].[Compañia] ADD  DEFAULT (newid()) FOR [ID_Compañia]
GO
ALTER TABLE [dbo].[estacion] ADD  DEFAULT (newid()) FOR [ID_Estacion]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (newid()) FOR [ID_Firma]
GO
ALTER TABLE [dbo].[InEstructural] ADD  DEFAULT (newid()) FOR [id_ie]
GO
ALTER TABLE [dbo].[InForestal] ADD  DEFAULT (newid()) FOR [id_if]
GO
ALTER TABLE [dbo].[InVehiculo] ADD  DEFAULT (newid()) FOR [id_iv]
GO
ALTER TABLE [dbo].[Personal] ADD  DEFAULT (newid()) FOR [ID_Personal]
GO
ALTER TABLE [dbo].[Proporcion] ADD  DEFAULT (newid()) FOR [id_prop]
GO
ALTER TABLE [dbo].[ServicioPrevencion] ADD  DEFAULT (newid()) FOR [id_sp]
GO
ALTER TABLE [dbo].[ServicioRescate] ADD  DEFAULT (newid()) FOR [id_sr]
GO
ALTER TABLE [dbo].[ServicioVario] ADD  DEFAULT (newid()) FOR [id_sv]
GO
ALTER TABLE [dbo].[Turno] ADD  DEFAULT (newid()) FOR [ID_Turno]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.id_cf] FOREIGN KEY([ie_id_cf])
REFERENCES [dbo].[ClaseFuego] ([id_cf])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.id_cf]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.id_prop] FOREIGN KEY([id_prop])
REFERENCES [dbo].[Proporcion] ([id_prop])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.id_prop]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_BomberoReporta] FOREIGN KEY([ie_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_BomberoReporta]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_Estacion] FOREIGN KEY([ie_Estacion])
REFERENCES [dbo].[estacion] ([ID_Estacion])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_Estacion]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_FirmaBombero] FOREIGN KEY([ie_FirmaBombero])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_FirmaBombero]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_JefeServicio] FOREIGN KEY([ie_JefeServicio])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_JefeServicio]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_Piloto] FOREIGN KEY([ie_Piloto])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_Piloto]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_TelefonistaTurno] FOREIGN KEY([ie_TelefonistaTurno])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_TelefonistaTurno]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_Turno] FOREIGN KEY([ie_Turno])
REFERENCES [dbo].[Turno] ([ID_Turno])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_Turno]
GO
ALTER TABLE [dbo].[InEstructural]  WITH CHECK ADD  CONSTRAINT [FK_InEstructural.ie_VoBoJefeServicio] FOREIGN KEY([ie_VoBoJefeServicio])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InEstructural] CHECK CONSTRAINT [FK_InEstructural.ie_VoBoJefeServicio]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.id_cf] FOREIGN KEY([id_cf])
REFERENCES [dbo].[ClaseFuego] ([id_cf])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.id_cf]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.id_prop] FOREIGN KEY([id_prop])
REFERENCES [dbo].[Proporcion] ([id_prop])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.id_prop]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_BomberoReporta] FOREIGN KEY([if_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_BomberoReporta]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_Estacion] FOREIGN KEY([if_Estacion])
REFERENCES [dbo].[estacion] ([ID_Estacion])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_Estacion]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_FirmaBombero] FOREIGN KEY([if_FirmaBombero])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_FirmaBombero]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_JefeServicio] FOREIGN KEY([if_JefeServicio])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_JefeServicio]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_Piloto] FOREIGN KEY([if_Piloto])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_Piloto]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_TelefonistaTurno] FOREIGN KEY([if_TelefonistaTurno])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_TelefonistaTurno]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_Turno] FOREIGN KEY([if_Turno])
REFERENCES [dbo].[Turno] ([ID_Turno])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_Turno]
GO
ALTER TABLE [dbo].[InForestal]  WITH CHECK ADD  CONSTRAINT [FK_InForestal.if_VoBoJefeServicio] FOREIGN KEY([if_VoBoJefeServicio])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InForestal] CHECK CONSTRAINT [FK_InForestal.if_VoBoJefeServicio]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.id_cf] FOREIGN KEY([id_cf])
REFERENCES [dbo].[ClaseFuego] ([id_cf])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.id_cf]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.id_prop] FOREIGN KEY([id_prop])
REFERENCES [dbo].[Proporcion] ([id_prop])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.id_prop]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_BomberoReporta] FOREIGN KEY([iv_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_BomberoReporta]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_Estacion] FOREIGN KEY([iv_Estacion])
REFERENCES [dbo].[estacion] ([ID_Estacion])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_Estacion]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_FirmaBombero] FOREIGN KEY([iv_FirmaBombero])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_FirmaBombero]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_JefeServicio] FOREIGN KEY([iv_JefeServicio])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_JefeServicio]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_Piloto] FOREIGN KEY([iv_Piloto])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_Piloto]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_TelefonistaTurno] FOREIGN KEY([iv_TelefonistaTurno])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_TelefonistaTurno]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_Turno] FOREIGN KEY([iv_Turno])
REFERENCES [dbo].[Turno] ([ID_Turno])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_Turno]
GO
ALTER TABLE [dbo].[InVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_InVehiculo.iv_VoBoJefeServicio] FOREIGN KEY([iv_VoBoJefeServicio])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[InVehiculo] CHECK CONSTRAINT [FK_InVehiculo.iv_VoBoJefeServicio]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_BomberoReporta] FOREIGN KEY([sp_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_BomberoReporta]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_Compañia] FOREIGN KEY([sp_Compañia])
REFERENCES [dbo].[Compañia] ([ID_Compañia])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_Compañia]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_Estacion] FOREIGN KEY([sp_Estacion])
REFERENCES [dbo].[estacion] ([ID_Estacion])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_Estacion]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_OficialServicio] FOREIGN KEY([sp_OficialServicio])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_OficialServicio]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_Piloto] FOREIGN KEY([sp_Piloto])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_Piloto]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_Telefonista] FOREIGN KEY([sp_Telefonista])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_Telefonista]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_Turno] FOREIGN KEY([sp_Turno])
REFERENCES [dbo].[Turno] ([ID_Turno])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_Turno]
GO
ALTER TABLE [dbo].[ServicioPrevencion]  WITH CHECK ADD  CONSTRAINT [FK_ServicioPrevencion.sp_VoBoJefeServicio] FOREIGN KEY([sp_VoBoJefeServicio])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[ServicioPrevencion] CHECK CONSTRAINT [FK_ServicioPrevencion.sp_VoBoJefeServicio]
GO
ALTER TABLE [dbo].[ServicioRescate]  WITH CHECK ADD  CONSTRAINT [FK_ServicioRescate.sr_BomberoReporta] FOREIGN KEY([sr_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[ServicioRescate] CHECK CONSTRAINT [FK_ServicioRescate.sr_BomberoReporta]
GO
ALTER TABLE [dbo].[ServicioRescate]  WITH CHECK ADD  CONSTRAINT [FK_ServicioRescate.sr_Estacion] FOREIGN KEY([sr_Estacion])
REFERENCES [dbo].[estacion] ([ID_Estacion])
GO
ALTER TABLE [dbo].[ServicioRescate] CHECK CONSTRAINT [FK_ServicioRescate.sr_Estacion]
GO
ALTER TABLE [dbo].[ServicioRescate]  WITH CHECK ADD  CONSTRAINT [FK_ServicioRescate.sr_OficialMando] FOREIGN KEY([sr_OficialMando])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioRescate] CHECK CONSTRAINT [FK_ServicioRescate.sr_OficialMando]
GO
ALTER TABLE [dbo].[ServicioRescate]  WITH CHECK ADD  CONSTRAINT [FK_ServicioRescate.sr_TelefonistaTurnoEstacion] FOREIGN KEY([sr_TelefonistaTurnoEstacion])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioRescate] CHECK CONSTRAINT [FK_ServicioRescate.sr_TelefonistaTurnoEstacion]
GO
ALTER TABLE [dbo].[ServicioRescate]  WITH CHECK ADD  CONSTRAINT [FK_ServicioRescate.sr_VoBoJefeServicio] FOREIGN KEY([sr_VoBoJefeServicio])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[ServicioRescate] CHECK CONSTRAINT [FK_ServicioRescate.sr_VoBoJefeServicio]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_BomberoReporta] FOREIGN KEY([sv_BomberoReporta])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_BomberoReporta]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_FirmaBombero] FOREIGN KEY([sv_FirmaBombero])
REFERENCES [dbo].[Firma] ([ID_Firma])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_FirmaBombero]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_JefeServicio] FOREIGN KEY([sv_JefeServicio])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_JefeServicio]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_PersonalAsistente] FOREIGN KEY([sv_PersonalAsistente])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_PersonalAsistente]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_Piloto] FOREIGN KEY([sv_Piloto])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_Piloto]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_ServicioAutPor] FOREIGN KEY([sv_ServicioAutPor])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_ServicioAutPor]
GO
ALTER TABLE [dbo].[ServicioVario]  WITH CHECK ADD  CONSTRAINT [FK_ServicioVario.sv_TelefonistaTurno] FOREIGN KEY([sv_TelefonistaTurno])
REFERENCES [dbo].[Personal] ([ID_Personal])
GO
ALTER TABLE [dbo].[ServicioVario] CHECK CONSTRAINT [FK_ServicioVario.sv_TelefonistaTurno]
GO
USE [master]
GO
ALTER DATABASE [Bombero] SET  READ_WRITE 
GO
create table Codigo(
UUID VARCHAR(36) PRIMARY KEY DEFAULT NEWID(),
CODIGO VARCHAR(6),
DESCRIPCION VARCHAR(130)
);
GO

ALTER TABLE [dbo].[InEstructural] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[InEstructural] ADD   CONSTRAINT [FK_InEstructural] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)
	GO
	ALTER TABLE [dbo].[InForestal] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[InForestal] ADD   CONSTRAINT [FK_InForestal] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)
GO
		ALTER TABLE [dbo].[InVehiculo] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[InVehiculo] ADD   CONSTRAINT [FK_InVehiculo] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)
GO
		ALTER TABLE [dbo].[ServicioVario] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[ServicioVario] ADD   CONSTRAINT [FK_ServicioVario] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)
	GO
		ALTER TABLE [dbo].[ServicioPrevencion] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[ServicioPrevencion] ADD   CONSTRAINT [FK_ServicioPrevencion] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)
	GO
		ALTER TABLE [dbo].[ServicioRescate] ADD  CODIGO VARCHAR(36) 
ALTER TABLE [dbo].[ServicioRescate] ADD   CONSTRAINT [FK_ServicioRescate] FOREIGN KEY (CODIGO)
    REFERENCES Codigo(UUID)