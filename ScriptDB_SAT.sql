USE [master]
GO
/****** Object:  Database [SAT]    Script Date: 19/07/2019 16:57:27 ******/
CREATE DATABASE [SAT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SAT', FILENAME = N'D:\RDSDBDATA\DATA\SAT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'SAT_log', FILENAME = N'D:\RDSDBDATA\DATA\SAT_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SAT] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SAT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SAT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SAT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SAT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SAT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SAT] SET ARITHABORT OFF 
GO
ALTER DATABASE [SAT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SAT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SAT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SAT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SAT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SAT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SAT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SAT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SAT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SAT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SAT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SAT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SAT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SAT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SAT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SAT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SAT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SAT] SET RECOVERY FULL 
GO
ALTER DATABASE [SAT] SET  MULTI_USER 
GO
ALTER DATABASE [SAT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SAT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SAT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SAT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SAT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SAT] SET QUERY_STORE = OFF
GO
USE [SAT]
GO
/****** Object:  User [bidss]    Script Date: 19/07/2019 16:57:35 ******/
CREATE USER [bidss] FOR LOGIN [bidss] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [bidss]
GO
/****** Object:  Schema [Acce]    Script Date: 19/07/2019 16:57:36 ******/
CREATE SCHEMA [Acce]
GO
/****** Object:  Schema [Cont]    Script Date: 19/07/2019 16:57:37 ******/
CREATE SCHEMA [Cont]
GO
/****** Object:  Schema [Esc]    Script Date: 19/07/2019 16:57:37 ******/
CREATE SCHEMA [Esc]
GO
/****** Object:  Schema [Gral]    Script Date: 19/07/2019 16:57:37 ******/
CREATE SCHEMA [Gral]
GO
/****** Object:  Table [Acce].[tbUsuarios]    Script Date: 19/07/2019 16:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acce].[tbUsuarios](
	[usu_Id] [int] IDENTITY(1,1) NOT NULL,
	[usu_NombreUsuario] [nvarchar](100) NOT NULL,
	[usu_Password] [varbinary](64) NOT NULL,
	[usu_EsActivo] [bit] NOT NULL,
	[usu_RazonInactivo] [nvarchar](150) NULL,
	[usu_EsAdministrador] [bit] NOT NULL,
 CONSTRAINT [PK_Acce_tbUsuario_usu_Id] PRIMARY KEY CLUSTERED 
(
	[usu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Acce_tbUsuario_usu_NombreUsuario] UNIQUE NONCLUSTERED 
(
	[usu_NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Esc].[tbAlumnos]    Script Date: 19/07/2019 16:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Esc].[tbAlumnos](
	[alu_Id] [int] IDENTITY(1,1) NOT NULL,
	[alu_Identidad] [varchar](25) NOT NULL,
	[alu_Nombres] [varchar](50) NOT NULL,
	[alu_Apellidos] [varchar](50) NOT NULL,
	[alu_Sexo] [char](1) NOT NULL,
	[alu_FechaNacimiento] [date] NOT NULL,
	[alu_NombresEncargado] [varchar](50) NOT NULL,
	[alu_ApellidosEncargado] [varchar](50) NOT NULL,
	[alu_TelefonoEncargado] [varchar](25) NULL,
	[alu_UsuarioCrea] [int] NOT NULL,
	[alu_FechaCrea] [datetime] NOT NULL,
	[alu_UsuarioModifica] [int] NULL,
	[alu_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Esc_tbAlumnos_alm_Id] PRIMARY KEY CLUSTERED 
(
	[alu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Esc].[tbMatriculas]    Script Date: 19/07/2019 16:57:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Esc].[tbMatriculas](
	[mat_Id] [int] IDENTITY(1,1) NOT NULL,
	[alu_Id] [int] NOT NULL,
	[sec_Id] [int] NOT NULL,
	[car_Id] [int] NOT NULL,
	[mat_Anio] [int] NOT NULL,
	[mat_UsuarioCrea] [int] NOT NULL,
	[mat_FechaCrea] [datetime] NOT NULL,
	[mat_UsuarioModifica] [int] NULL,
	[mat_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Esc_tbMatricula_mat_Id] PRIMARY KEY CLUSTERED 
(
	[mat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Esc].[tbNotaDetalles]    Script Date: 19/07/2019 16:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Esc].[tbNotaDetalles](
	[notd_Id] [int] IDENTITY(1,1) NOT NULL,
	[not_Id] [int] NOT NULL,
	[notd_Acumulado1] [decimal](18, 2) NULL,
	[notd_Examen1] [decimal](18, 2) NULL,
	[notd_Acumulado2] [decimal](18, 2) NULL,
	[notd_Examen2] [decimal](18, 2) NULL,
	[notd_Acumulado3] [decimal](18, 2) NULL,
	[notd_Examen3] [decimal](18, 2) NULL,
	[notd_Acumulado4] [decimal](18, 2) NULL,
	[notd_Examen4] [decimal](18, 2) NULL,
	[notd_UsuarioCrea] [int] NOT NULL,
	[notd_FechaCrea] [datetime] NOT NULL,
	[notd_UsuarioModifica] [int] NULL,
	[notd_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Esc_tbNotas_notd_Id] PRIMARY KEY CLUSTERED 
(
	[notd_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Esc].[tbNotas]    Script Date: 19/07/2019 16:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Esc].[tbNotas](
	[not_Id] [int] IDENTITY(1,1) NOT NULL,
	[asig_Id] [int] NOT NULL,
	[mat_Id] [int] NOT NULL,
	[not_UsuarioCrea] [int] NOT NULL,
	[not_FechaCrea] [datetime] NOT NULL,
	[not_UsuarioModifica] [int] NULL,
	[not_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Esc_tbNotas_not_Id] PRIMARY KEY CLUSTERED 
(
	[not_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbAsignaturas]    Script Date: 19/07/2019 16:57:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbAsignaturas](
	[asig_Id] [int] IDENTITY(1,1) NOT NULL,
	[asig_Descripcion] [nvarchar](100) NOT NULL,
	[asig_Semestral] [bit] NOT NULL,
	[asig_UsuarioCrea] [int] NOT NULL,
	[asig_FechaCrea] [datetime] NOT NULL,
	[asig_UsuarioModifica] [int] NULL,
	[asig_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbAsignatura_Asig_Id] PRIMARY KEY CLUSTERED 
(
	[asig_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbCargos]    Script Date: 19/07/2019 16:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbCargos](
	[carg_Id] [int] IDENTITY(1,1) NOT NULL,
	[carg_Descripcion] [varchar](50) NOT NULL,
	[carg_UsuarioCrea] [int] NOT NULL,
	[carg_FechaCrea] [datetime] NOT NULL,
	[carg_UsuarioModifica] [int] NULL,
	[carg_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbCargos_carg_Id] PRIMARY KEY CLUSTERED 
(
	[carg_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbCarreraAsignaturas]    Script Date: 19/07/2019 16:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbCarreraAsignaturas](
	[carasi_Id] [int] NOT NULL,
	[car_Id] [int] NULL,
	[asig_Id] [int] NULL,
	[carasi_UsuarioCrea] [int] NOT NULL,
	[carasi_FechaCrea] [datetime] NOT NULL,
	[carasi_UsuarioModifica] [int] NULL,
	[carasi_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbCarreraAsignatura_carasi_Id] PRIMARY KEY CLUSTERED 
(
	[carasi_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbCarreras]    Script Date: 19/07/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbCarreras](
	[car_Id] [int] IDENTITY(1,1) NOT NULL,
	[car_Descripcion] [nvarchar](100) NOT NULL,
	[car_Encargado] [int] NOT NULL,
	[car_UsuarioCrea] [int] NOT NULL,
	[car_FechaCrea] [datetime] NOT NULL,
	[car_UsuarioModifica] [int] NULL,
	[car_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbCarrera_car_Id] PRIMARY KEY CLUSTERED 
(
	[car_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbDepartamentos]    Script Date: 19/07/2019 16:57:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbDepartamentos](
	[dep_Id] [char](2) NOT NULL,
	[dep_Descripcion] [varchar](50) NOT NULL,
	[dep_UsuarioCrea] [int] NOT NULL,
	[dep_FechaCrea] [datetime] NOT NULL,
	[dep_UsuarioModifica] [int] NULL,
	[dep_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Esc_tbDepartamentos_dep_Id] PRIMARY KEY CLUSTERED 
(
	[dep_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbEmpleadoAsignaturas]    Script Date: 19/07/2019 16:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbEmpleadoAsignaturas](
	[empa_Id] [int] IDENTITY(1,1) NOT NULL,
	[emp_Id] [int] NOT NULL,
	[asig_Id] [int] NOT NULL,
	[empa_UsuarioCrea] [int] NOT NULL,
	[empa_FechaCrea] [datetime] NOT NULL,
	[empa_UsuarioModifica] [int] NULL,
	[empa_FechaModifica] [int] NULL,
 CONSTRAINT [PK_Gral_tbEmpleadoAsignaturas_empa_Id] PRIMARY KEY CLUSTERED 
(
	[empa_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbEmpleados]    Script Date: 19/07/2019 16:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbEmpleados](
	[emp_Id] [int] IDENTITY(1,1) NOT NULL,
	[emp_Identidad] [varchar](20) NOT NULL,
	[emp_Nombres] [nvarchar](100) NOT NULL,
	[emp_Apellidos] [nvarchar](100) NOT NULL,
	[emp_FechaNacimiento] [date] NOT NULL,
	[emp_Sexo] [char](1) NOT NULL,
	[emp_Direccion] [nvarchar](100) NOT NULL,
	[mun_Id] [char](4) NOT NULL,
	[emp_CorreoElectronico] [nvarchar](100) NOT NULL,
	[emp_Telefono] [nvarchar](20) NOT NULL,
	[carg_Id] [int] NOT NULL,
	[emp_FechaIngreso] [date] NOT NULL,
	[emp_FechadeSalida] [date] NULL,
	[emp_RazonSalida] [nvarchar](250) NULL,
	[emp_UsuarioCrea] [int] NOT NULL,
	[emp_FechaCrea] [datetime] NOT NULL,
	[emp_UsuarioModifica] [int] NULL,
	[emp_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbEmpleados_emp_Id] PRIMARY KEY CLUSTERED 
(
	[emp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbEscuelas]    Script Date: 19/07/2019 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbEscuelas](
	[esc_Id] [int] IDENTITY(1,1) NOT NULL,
	[esc_Codigo] [varchar](20) NOT NULL,
	[esc_NombreEscuela] [nvarchar](100) NOT NULL,
	[esc_Director] [int] NOT NULL,
	[esc_Contacto] [int] NOT NULL,
	[esc_Telefono] [varchar](20) NOT NULL,
	[esc_Correo] [nvarchar](100) NOT NULL,
	[mun_Id] [char](4) NOT NULL,
	[esc_UsuarioCrea] [int] NOT NULL,
	[esc_FechaCrea] [datetime] NOT NULL,
	[esc_UsuarioModifica] [int] NULL,
	[esc_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbEscuelas_esc_Id] PRIMARY KEY CLUSTERED 
(
	[esc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbGrados]    Script Date: 19/07/2019 16:57:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbGrados](
	[grad_Id] [int] IDENTITY(1,1) NOT NULL,
	[grad_Descripcion] [varchar](10) NOT NULL,
	[grad_UsuarioCrea] [int] NOT NULL,
	[grad_FechaCrea] [datetime] NOT NULL,
	[grad_UsuarioModifica] [int] NULL,
	[grad_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbGrados_grad_Id] PRIMARY KEY CLUSTERED 
(
	[grad_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbJornadaGrados]    Script Date: 19/07/2019 16:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbJornadaGrados](
	[jgra_Id] [int] IDENTITY(1,1) NOT NULL,
	[grad_Id] [int] NOT NULL,
	[jor_Id] [int] NOT NULL,
	[jgra_UsuarioCrea] [int] NOT NULL,
	[jgra_FechaCrea] [datetime] NOT NULL,
	[jgra_UsuarioModifica] [int] NULL,
	[jgra_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_tbJornadaGrados_jg_Id] PRIMARY KEY CLUSTERED 
(
	[jgra_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbJornadas]    Script Date: 19/07/2019 16:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbJornadas](
	[jor_Id] [int] IDENTITY(1,1) NOT NULL,
	[jor_Descripcion] [varchar](15) NOT NULL,
	[jor_UsuarioCrea] [int] NOT NULL,
	[jor_FechaCrea] [datetime] NOT NULL,
	[jor_UsuarioModifica] [int] NULL,
	[jor_FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Gral_Jornada_jor_Id] PRIMARY KEY CLUSTERED 
(
	[jor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Gral_Jornada_Jor_Descripcion] UNIQUE NONCLUSTERED 
(
	[jor_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbMunicipios]    Script Date: 19/07/2019 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbMunicipios](
	[mun_Id] [char](4) NOT NULL,
	[mun_Descripcion] [varchar](50) NOT NULL,
	[mun_UsuarioCrea] [int] NOT NULL,
	[mun_FechaCrea] [datetime] NOT NULL,
	[mun_UsuarioModifica] [int] NULL,
	[mun_FechaModifica] [datetime] NULL,
	[dep_Id] [char](2) NULL,
 CONSTRAINT [PK_Esc_tbMunicipios_mun_Id] PRIMARY KEY CLUSTERED 
(
	[mun_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gral].[tbSecciones]    Script Date: 19/07/2019 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gral].[tbSecciones](
	[sec_Id] [int] IDENTITY(1,1) NOT NULL,
	[sec_Descripcion] [char](1) NOT NULL,
	[sec_UsuarioCrea] [int] NOT NULL,
	[sec_FechaCrea] [datetime] NOT NULL,
	[sec_UsuarioModifica] [int] NULL,
	[sec_FechaModifica] [datetime] NULL,
	[jgra_Id] [int] NOT NULL,
 CONSTRAINT [PK_Gral_tbSecciones_Sec_ID] PRIMARY KEY CLUSTERED 
(
	[sec_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Acce].[tbUsuarios] ADD  CONSTRAINT [DF_Acce_tbUsuario_usu_EsACTIVO]  DEFAULT ((1)) FOR [usu_EsActivo]
GO
ALTER TABLE [Acce].[tbUsuarios] ADD  CONSTRAINT [DF_Acce_tbUsuario_usu_EsAdministrador]  DEFAULT ((0)) FOR [usu_EsAdministrador]
GO
ALTER TABLE [Esc].[tbAlumnos]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbAlumnos_alu_UsuarioCrea] FOREIGN KEY([alu_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbAlumnos] CHECK CONSTRAINT [FK_Esc_tbAlumnos_alu_UsuarioCrea]
GO
ALTER TABLE [Esc].[tbAlumnos]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbAlumnos_alu_UsuarioModifica] FOREIGN KEY([alu_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbAlumnos] CHECK CONSTRAINT [FK_Esc_tbAlumnos_alu_UsuarioModifica]
GO
ALTER TABLE [Esc].[tbMatriculas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbMatriculas_alu_Id] FOREIGN KEY([alu_Id])
REFERENCES [Esc].[tbAlumnos] ([alu_Id])
GO
ALTER TABLE [Esc].[tbMatriculas] CHECK CONSTRAINT [FK_Esc_tbMatriculas_alu_Id]
GO
ALTER TABLE [Esc].[tbMatriculas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbMatriculas_car_Id] FOREIGN KEY([car_Id])
REFERENCES [Gral].[tbCarreras] ([car_Id])
GO
ALTER TABLE [Esc].[tbMatriculas] CHECK CONSTRAINT [FK_Esc_tbMatriculas_car_Id]
GO
ALTER TABLE [Esc].[tbMatriculas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbMatriculas_mat_UsuarioCrea] FOREIGN KEY([mat_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbMatriculas] CHECK CONSTRAINT [FK_Esc_tbMatriculas_mat_UsuarioCrea]
GO
ALTER TABLE [Esc].[tbMatriculas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbMatriculas_mat_UsuarioModifica] FOREIGN KEY([mat_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbMatriculas] CHECK CONSTRAINT [FK_Esc_tbMatriculas_mat_UsuarioModifica]
GO
ALTER TABLE [Esc].[tbMatriculas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbMatriculas_sec_Id] FOREIGN KEY([sec_Id])
REFERENCES [Gral].[tbSecciones] ([sec_Id])
GO
ALTER TABLE [Esc].[tbMatriculas] CHECK CONSTRAINT [FK_Esc_tbMatriculas_sec_Id]
GO
ALTER TABLE [Esc].[tbNotaDetalles]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotaDetalles_notd_UsuarioCrea] FOREIGN KEY([notd_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbNotaDetalles] CHECK CONSTRAINT [FK_Esc_tbNotaDetalles_notd_UsuarioCrea]
GO
ALTER TABLE [Esc].[tbNotaDetalles]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotaDetalles_notd_UsuarioModifica] FOREIGN KEY([notd_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbNotaDetalles] CHECK CONSTRAINT [FK_Esc_tbNotaDetalles_notd_UsuarioModifica]
GO
ALTER TABLE [Esc].[tbNotaDetalles]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotas_not_Id] FOREIGN KEY([not_Id])
REFERENCES [Esc].[tbNotas] ([not_Id])
GO
ALTER TABLE [Esc].[tbNotaDetalles] CHECK CONSTRAINT [FK_Esc_tbNotas_not_Id]
GO
ALTER TABLE [Esc].[tbNotas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotas_asig_Id] FOREIGN KEY([asig_Id])
REFERENCES [Gral].[tbAsignaturas] ([asig_Id])
GO
ALTER TABLE [Esc].[tbNotas] CHECK CONSTRAINT [FK_Esc_tbNotas_asig_Id]
GO
ALTER TABLE [Esc].[tbNotas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotas_mat_Id] FOREIGN KEY([mat_Id])
REFERENCES [Esc].[tbMatriculas] ([mat_Id])
GO
ALTER TABLE [Esc].[tbNotas] CHECK CONSTRAINT [FK_Esc_tbNotas_mat_Id]
GO
ALTER TABLE [Esc].[tbNotas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotas_not_UsuarioCrea] FOREIGN KEY([not_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbNotas] CHECK CONSTRAINT [FK_Esc_tbNotas_not_UsuarioCrea]
GO
ALTER TABLE [Esc].[tbNotas]  WITH CHECK ADD  CONSTRAINT [FK_Esc_tbNotas_not_UsuarioModifica] FOREIGN KEY([not_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Esc].[tbNotas] CHECK CONSTRAINT [FK_Esc_tbNotas_not_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbAsignaturas_asig_UsuarioCrea] FOREIGN KEY([asig_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbAsignaturas] CHECK CONSTRAINT [FK_Gral_tbAsignaturas_asig_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbAsignaturas_asig_UsuarioModifica] FOREIGN KEY([asig_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbAsignaturas] CHECK CONSTRAINT [FK_Gral_tbAsignaturas_asig_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbCargos]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCargos_carg_UsuarioCrea] FOREIGN KEY([carg_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCargos] CHECK CONSTRAINT [FK_Gral_tbCargos_carg_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbCargos]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCargos_carg_UsuarioModifica] FOREIGN KEY([carg_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCargos] CHECK CONSTRAINT [FK_Gral_tbCargos_carg_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreraAsignatura_asig_Id] FOREIGN KEY([asig_Id])
REFERENCES [Gral].[tbAsignaturas] ([asig_Id])
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas] CHECK CONSTRAINT [FK_Gral_tbCarreraAsignatura_asig_Id]
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreraAsignatura_car_Id] FOREIGN KEY([car_Id])
REFERENCES [Gral].[tbCarreras] ([car_Id])
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas] CHECK CONSTRAINT [FK_Gral_tbCarreraAsignatura_car_Id]
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreraAsignaturas_carasi_UsuarioCrea] FOREIGN KEY([carasi_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas] CHECK CONSTRAINT [FK_Gral_tbCarreraAsignaturas_carasi_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreraAsignaturas_carasi_UsuarioModifica] FOREIGN KEY([carasi_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCarreraAsignaturas] CHECK CONSTRAINT [FK_Gral_tbCarreraAsignaturas_carasi_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbCarreras]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarrera_car_Encargado] FOREIGN KEY([car_Encargado])
REFERENCES [Gral].[tbEmpleados] ([emp_Id])
GO
ALTER TABLE [Gral].[tbCarreras] CHECK CONSTRAINT [FK_Gral_tbCarrera_car_Encargado]
GO
ALTER TABLE [Gral].[tbCarreras]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreras_car_UsuarioCrea] FOREIGN KEY([car_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCarreras] CHECK CONSTRAINT [FK_Gral_tbCarreras_car_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbCarreras]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbCarreras_car_UsuarioModifica] FOREIGN KEY([car_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbCarreras] CHECK CONSTRAINT [FK_Gral_tbCarreras_car_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbDepartamentos]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbDepartamentos_dep_UsuarioCrea] FOREIGN KEY([dep_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbDepartamentos] CHECK CONSTRAINT [FK_Gral_tbDepartamentos_dep_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbDepartamentos]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbDepartamentos_dep_UsuarioModifica] FOREIGN KEY([dep_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbDepartamentos] CHECK CONSTRAINT [FK_Gral_tbDepartamentos_dep_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_asig_Id] FOREIGN KEY([asig_Id])
REFERENCES [Gral].[tbAsignaturas] ([asig_Id])
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas] CHECK CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_asig_Id]
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_emp_Id] FOREIGN KEY([emp_Id])
REFERENCES [Gral].[tbEmpleados] ([emp_Id])
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas] CHECK CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_emp_Id]
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_empa_UsuarioCrea] FOREIGN KEY([empa_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas] CHECK CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_empa_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_empa_UsuarioModifica] FOREIGN KEY([empa_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEmpleadoAsignaturas] CHECK CONSTRAINT [FK_Gral_tbEmpleadoAsignaturas_empa_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleados_carg_Id] FOREIGN KEY([carg_Id])
REFERENCES [Gral].[tbCargos] ([carg_Id])
GO
ALTER TABLE [Gral].[tbEmpleados] CHECK CONSTRAINT [FK_Gral_tbEmpleados_carg_Id]
GO
ALTER TABLE [Gral].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleados_emp_UsuarioCrea] FOREIGN KEY([emp_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEmpleados] CHECK CONSTRAINT [FK_Gral_tbEmpleados_emp_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleados_emp_UsuarioModifica] FOREIGN KEY([emp_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEmpleados] CHECK CONSTRAINT [FK_Gral_tbEmpleados_emp_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEmpleados_mun_Id] FOREIGN KEY([mun_Id])
REFERENCES [Gral].[tbMunicipios] ([mun_Id])
GO
ALTER TABLE [Gral].[tbEmpleados] CHECK CONSTRAINT [FK_Gral_tbEmpleados_mun_Id]
GO
ALTER TABLE [Gral].[tbEscuelas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEscuelas_esc_Contacto] FOREIGN KEY([esc_Contacto])
REFERENCES [Gral].[tbEmpleados] ([emp_Id])
GO
ALTER TABLE [Gral].[tbEscuelas] CHECK CONSTRAINT [FK_Gral_tbEscuelas_esc_Contacto]
GO
ALTER TABLE [Gral].[tbEscuelas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEscuelas_esc_Director] FOREIGN KEY([esc_Director])
REFERENCES [Gral].[tbEmpleados] ([emp_Id])
GO
ALTER TABLE [Gral].[tbEscuelas] CHECK CONSTRAINT [FK_Gral_tbEscuelas_esc_Director]
GO
ALTER TABLE [Gral].[tbEscuelas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEscuelas_esc_UsuarioCrea] FOREIGN KEY([esc_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEscuelas] CHECK CONSTRAINT [FK_Gral_tbEscuelas_esc_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbEscuelas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEscuelas_esc_UsuarioModifica] FOREIGN KEY([esc_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbEscuelas] CHECK CONSTRAINT [FK_Gral_tbEscuelas_esc_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbEscuelas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbEscuelas_mun_Id] FOREIGN KEY([mun_Id])
REFERENCES [Gral].[tbMunicipios] ([mun_Id])
GO
ALTER TABLE [Gral].[tbEscuelas] CHECK CONSTRAINT [FK_Gral_tbEscuelas_mun_Id]
GO
ALTER TABLE [Gral].[tbGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbGrados_grad_UsuarioCrea] FOREIGN KEY([grad_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbGrados] CHECK CONSTRAINT [FK_Gral_tbGrados_grad_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbGrados_grad_UsuarioModifica] FOREIGN KEY([grad_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbGrados] CHECK CONSTRAINT [FK_Gral_tbGrados_grad_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbJornadaGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadaGrados_grad_Id] FOREIGN KEY([grad_Id])
REFERENCES [Gral].[tbGrados] ([grad_Id])
GO
ALTER TABLE [Gral].[tbJornadaGrados] CHECK CONSTRAINT [FK_Gral_tbJornadaGrados_grad_Id]
GO
ALTER TABLE [Gral].[tbJornadaGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadaGrados_jgra_UsuarioCrea] FOREIGN KEY([jgra_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbJornadaGrados] CHECK CONSTRAINT [FK_Gral_tbJornadaGrados_jgra_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbJornadaGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadaGrados_jgra_UsuarioModifica] FOREIGN KEY([jgra_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbJornadaGrados] CHECK CONSTRAINT [FK_Gral_tbJornadaGrados_jgra_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbJornadaGrados]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadaGrados_jor_Id] FOREIGN KEY([jor_Id])
REFERENCES [Gral].[tbJornadas] ([jor_Id])
GO
ALTER TABLE [Gral].[tbJornadaGrados] CHECK CONSTRAINT [FK_Gral_tbJornadaGrados_jor_Id]
GO
ALTER TABLE [Gral].[tbJornadas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadas_jor_UsuarioCrea] FOREIGN KEY([jor_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbJornadas] CHECK CONSTRAINT [FK_Gral_tbJornadas_jor_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbJornadas]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbJornadas_jor_UsuarioModifica] FOREIGN KEY([jor_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbJornadas] CHECK CONSTRAINT [FK_Gral_tbJornadas_jor_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [Fk_Esc_tbMunicipios_constraint] FOREIGN KEY([dep_Id])
REFERENCES [Gral].[tbDepartamentos] ([dep_Id])
GO
ALTER TABLE [Gral].[tbMunicipios] CHECK CONSTRAINT [Fk_Esc_tbMunicipios_constraint]
GO
ALTER TABLE [Gral].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbMunicipios_mun_UsuarioCrea] FOREIGN KEY([mun_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbMunicipios] CHECK CONSTRAINT [FK_Gral_tbMunicipios_mun_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbMunicipios_mun_UsuarioModifica] FOREIGN KEY([mun_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbMunicipios] CHECK CONSTRAINT [FK_Gral_tbMunicipios_mun_UsuarioModifica]
GO
ALTER TABLE [Gral].[tbSecciones]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbSecciones_Sec_ID] FOREIGN KEY([jgra_Id])
REFERENCES [Gral].[tbJornadaGrados] ([jgra_Id])
GO
ALTER TABLE [Gral].[tbSecciones] CHECK CONSTRAINT [FK_Gral_tbSecciones_Sec_ID]
GO
ALTER TABLE [Gral].[tbSecciones]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbSecciones_sec_UsuarioCrea] FOREIGN KEY([sec_UsuarioCrea])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbSecciones] CHECK CONSTRAINT [FK_Gral_tbSecciones_sec_UsuarioCrea]
GO
ALTER TABLE [Gral].[tbSecciones]  WITH CHECK ADD  CONSTRAINT [FK_Gral_tbSecciones_sec_UsuarioModifica] FOREIGN KEY([sec_UsuarioModifica])
REFERENCES [Acce].[tbUsuarios] ([usu_Id])
GO
ALTER TABLE [Gral].[tbSecciones] CHECK CONSTRAINT [FK_Gral_tbSecciones_sec_UsuarioModifica]
GO
/****** Object:  StoredProcedure [Acce].[UDP_Acce_tbUsuario_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acce].[UDP_Acce_tbUsuario_Insert]
	(
		@usu_NombreUsuario [varchar](100),
		@usu_Password [varchar](64),
		@usu_EsAdministrador [bit]
	)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Acce].[tbUsuarios]
			(
				[usu_NombreUsuario], [usu_Password],[usu_EsAdministrador]
			)
			VALUES
			(
				@usu_NombreUsuario,
				HASHBYTES('SHA2_512', @usu_Password),
				@usu_EsAdministrador
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) 
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Esc].[UDP_Esc_tbNotaDetalles_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Esc].[UDP_Esc_tbNotaDetalles_Insert]
(
	@not_Id int,
	@notd_Acumulado1 decimal(8,2),
	@notd_Examen1 decimal(8,2),
	@notd_Acumulado2 decimal(8,2),
	@notd_Examen2 decimal(8,2),
	@notd_Acumulado3 decimal(8,2),
	@notd_Examen3 decimal(8,2),
	@notd_Acumulado4 decimal(8,2),
	@notd_Examen4 decimal(8,2),
	@notd_UsuarioCrea int,
	@notd_FechaCrea datetime
)
as
Begin
	begin try
		begin tran
			INSERT INTO [Esc].[tbNotaDetalles]
			(
				not_Id, notd_Acumulado1, notd_Examen1, notd_Acumulado2, notd_Examen2, notd_Acumulado3, notd_Examen3, notd_Acumulado4, notd_Examen4, notd_UsuarioCrea, notd_FechaCrea
			)
			values
			(
				@not_Id, @notd_Acumulado1, @notd_Examen1, @notd_Acumulado2, @notd_Examen2, @notd_Acumulado3, @notd_Examen3, @notd_Acumulado4, @notd_Examen4, @notd_UsuarioCrea, @notd_FechaCrea
			)
			select cast(scope_identity() as varchar) as MensajeError
		commit tran
	end try
	begin catch
		rollback tran
		select '-1' + ERROR_MESSAGE() AS MensajeError
	end catch
end	
GO
/****** Object:  StoredProcedure [Esc].[UDP_Esc_tbNotaDetalles_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [Esc].[UDP_Esc_tbNotaDetalles_Update]
(	@notd_Id int,
	@not_Id int,
	@notd_Examen1 decimal(8,2),
	@notd_Examen2 decimal(8,2),
	@notd_Examen3 decimal(8,2),
	@notd_Examen4 decimal(8,2),
	@notd_Acumulado1 decimal(8,2),
	@notd_Acumulado2 decimal(8,2),
	@notd_Acumulado3 decimal(8,2),
	@notd_Acumulado4 decimal(8,2),
	@notd_UsuarioCrea int, 
	@notd_FechaCrea datetime,
	@notd_UsuarioModifica int,
	@notd_FechaModifica datetime
)
as
Begin
	begin try
		begin tran

			update [Esc].[tbNotaDetalles] set
			notd_Acumulado1 = @notd_Acumulado1,
			notd_Examen1 = @notd_Examen1,
			notd_Acumulado2 = @notd_Acumulado2,
			notd_Examen2 = @notd_Examen2,
			notd_Acumulado3 = @notd_Acumulado3,
			notd_Examen3 = @notd_Examen3,
			notd_Acumulado4 = @notd_Acumulado4,
			notd_Examen4 = @notd_Examen4,
			notd_UsuarioModifica = @notd_UsuarioModifica,
			notd_FechaModifica = @notd_FechaModifica
			where
			notd_Id = @notd_Id
			
			select cast(scope_identity() as varchar) as MensajeError
		commit tran
	end try
	begin catch
		rollback tran
		select '-1' + ERROR_MESSAGE() AS MensajeError
	end catch
end	
GO
/****** Object:  StoredProcedure [Esc].[UDP_Esc_tbNotas_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Esc].[UDP_Esc_tbNotas_Insert]
	(
		@asig_Id int,
		@mat_Id int,
		@not_UsuarioCrea int,
		@not_FechaCrea datetime
	)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Esc].[tbNotas]
			(
				[asig_Id],
				[mat_Id],
				[not_UsuarioCrea],
				[not_FechaCrea] 
			)
			VALUES
			(
				@asig_Id ,
				@mat_Id ,
				@not_UsuarioCrea,
				@not_FechaCrea
			)
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Esc].[UDP_Esc_tbNotas_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Esc].[UDP_Esc_tbNotas_Update]
	(
        @not_Id int,
		@asig_Id int,
		@mat_Id int,
		@not_UsuarioCrea int,
		@not_FechaCrea datetime,
		@not_UsuarioModifica int,
        @not_FechaModifica datetime
	)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update  [Esc].[tbNotas]
			set 
				@asig_Id = [asig_Id],
				@not_UsuarioCrea = [not_UsuarioCrea],
				@not_FechaCrea = [not_FechaCrea],
				@not_UsuarioModifica = [not_UsuarioModifica],
				@not_FechaModifica = [not_FechaModifica]
				where @not_Id = [not_Id]
			SELECT CAST(@not_Id AS varchar) AS MensajeError
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Esc].[UDP_Gral_tbMatriculas_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Esc].[UDP_Gral_tbMatriculas_Insert]
(
    @alu_Id int,
	@sec_Id int,
	@car_Id int,
	@mat_Anio int,
	@mat_UsuarioCrea int,
	@mat_FechaCrea datetime
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Esc].[tbMatriculas]
			(
				[alu_Id],[sec_Id],[car_Id],[mat_Anio],[mat_UsuarioCrea],[mat_FechaCrea]
			)
			VALUES
			(
				@alu_Id,
				@sec_Id,
				@car_Id,
				@mat_Anio,
				@mat_UsuarioCrea,
				@mat_FechaCrea
			)
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Esc].[UDP_Gral_tbMatriculas_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Esc].[UDP_Gral_tbMatriculas_Update]
	(
		@mat_Id int,
		@alu_Id int,
		@sec_Id int,
		@car_Id int,
		@mat_Anio int,
		@mat_UsuarioCrea int,
		@mat_FechaCrea datetime,
		@mat_UsuarioModifica int,
		@mat_FechaModifica datetime
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE [Esc].[tbMatriculas]
			SET
				
					alu_Id = @mat_Id,
					sec_Id = @sec_Id,
					car_Id = @car_Id,
					mat_Anio = @mat_Anio,
					mat_UsuarioCrea = @mat_UsuarioCrea,
					mat_FechaCrea = @mat_FechaCrea,
					mat_UsuarioModifica = @mat_UsuarioModifica,
					mat_FechaModifica = @mat_FechaModifica
			WHERE mat_Id = @mat_Id
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbAsignaturas_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbAsignaturas_Insert]
	(
		@asig_Descripcion [nvarchar](100),
		@asig_Semestral [bit],
		@asig_UsuarioCrea  int,
		@asig_FechaCrea datetime
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbAsignaturas]
			(
				[asig_Descripcion], [asig_Semestral],[asig_UsuarioCrea],[asig_FechaCrea]
			)
			VALUES
			(
				@asig_Descripcion,
				@asig_Semestral,
				@asig_UsuarioCrea,
				@asig_FechaCrea 
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbAsignaturas_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Gral].[UDP_Gral_tbAsignaturas_Update]
	(
		@asig_Id int,
		@asig_Descripcion [nvarchar](100),
		@asig_Semestral [bit],
		@asig_UsuarioCrea  int,
		@asig_FechaCrea datetime,
		@asig_UsuarioModifica  int,
		@asig_FechaModifica datetime
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE [Gral].[tbAsignaturas]
			
				SET [asig_Descripcion] = @asig_Descripcion,
					[asig_Semestral] = @asig_Semestral,
					[asig_UsuarioCrea] = @asig_UsuarioCrea ,
					[asig_FechaCrea] = @asig_FechaCrea ,
					[asig_UsuarioModifica] = @asig_UsuarioModifica,
					[asig_FechaModifica] = @asig_FechaModifica
				where [asig_Id] = @asig_Id		
			
	
			SELECT CAST(@asig_Id AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbCargos_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbCargos_Insert]
	(
		@carg_Descripcion VARCHAR(50), 
		@carg_UsuarioCrea INT, 
		@carg_FechaCrea DATETIME 
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbCargos]
			(
				carg_Descripcion, 
				carg_UsuarioCrea, 
				carg_FechaCrea
			)
			VALUES
			(
				@carg_Descripcion, 
				@carg_UsuarioCrea, 
				@carg_FechaCrea 
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbCargos_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbCargos_Update]
	(
		@carg_Id int, 
		@carg_Descripcion VARCHAR(50), 
		@carg_UsuarioCrea INT, 
		@carg_FechaCrea DATETIME, 
		@carg_UsuarioModifica INT, 
		@carg_FechaModifica DATETIME
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE [Gral].[tbCargos]
			SET
				carg_Descripcion=@carg_Descripcion, 
				carg_UsuarioCrea=@carg_UsuarioCrea, 
				carg_FechaCrea=@carg_FechaCrea, 
				carg_UsuarioModifica=@carg_UsuarioModifica, 
				carg_FechaModifica=@carg_FechaModifica
			WHERE [carg_Id]=@carg_Id
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbCarreras_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbCarreras_Insert]
	(
		@Descripcion NVARCHAR(100), 
		@Encargado INT, 
		@car_UsuarioCrea INT,
		@car_FechaCrea DATETIME
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbCarreras]
			(
				car_Descripcion, 
				car_Encargado, 
				car_UsuarioCrea, 
				car_FechaCrea
			)
			VALUES
			(
				@Descripcion,
				@Encargado,
				@car_UsuarioCrea,
				@car_FechaCrea
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbCarreras_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbCarreras_Update]
	(
		@car_Id INT,
		@Descripcion NVARCHAR(100), 
		@Encargado INT,
		@car_UsuarioCrea INT,
		@car_FechaCrea DATETIME, 
		@car_UsuarioModifica INT,
		@car_FechaModifica DATETIME
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE[Gral].[tbCarreras]
			SET
				car_Descripcion=@Descripcion, 
				car_Encargado=@Encargado,
				car_UsuarioCrea=@car_UsuarioCrea, 
				car_FechaCrea=@car_FechaCrea, 
				car_UsuarioModifica=@car_UsuarioCrea,
				car_FechaModifica=@car_FechaModifica
			WHERE [car_Id]=@car_Id
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbDepartamentos_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbDepartamentos_Insert](
    @dep_Id varchar(2),
    @dep_Descripcion nvarchar(50),
    @usu_Id int,
    @usu_Fechacrea DateTime
)
AS
BEGIN
    BEGIN TRY
            BEGIN TRAN
            INSERT INTO [Gral].[tbDepartamentos]    (
            [dep_Id],
            [dep_Descripcion],
            [dep_UsuarioCrea],
            [dep_FechaCrea]    )
            VALUES(
            @dep_Id,
            @dep_Descripcion,
            @usu_Id,
            @usu_FechaCrea
            )
            select cast(@dep_Id AS VARCHAR) AS MensajeError
            COMMIT TRAN
    END TRY
        BEGIN CATCH
            ROLLBACK TRAN
            SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError
        END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbDepartamentos_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbDepartamentos_Update]
(
    @dep_Id char(2),
    @dep_Descripcion nvarchar(50),
    @dep_UsuarioCrea int,
    @dep_FechaCrea DateTime,
    @dep_UsuarioModifica int,
    @dep_FechaModifica DateTime
)
AS
BEGIN
    BEGIN TRY
            BEGIN TRAN
                UPDATE [Gral].[tbDepartamentos]
                SET @dep_Descripcion = dep_Descripcion, 
					@dep_UsuarioCrea = dep_UsuarioCrea, 
					@dep_FechaCrea = dep_FechaCrea,
					@dep_UsuarioModifica = dep_UsuarioModifica,
					@dep_FechaModifica = dep_FechaModifica
                WHERE @dep_Id = dep_Id

                select cast(@dep_Id AS VARCHAR) AS MensajeError
            COMMIT TRAN
    END TRY
        BEGIN CATCH
            ROLLBACK TRAN
            SELECT '-1' + ERROR_MESSAGE() AS MensajeError
        END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbEmpleados_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbEmpleados_Insert]
(
	@emp_Identidad varchar (20),
	@emp_Nombres nvarchar(100),
	@emp_Apellidos nvarchar(100),
	@emp_FechaNacimiento date,
	@emp_Sexo char(1),
	@emp_Direccion nvarchar(100),
	@mun_Id char(4),
	@emp_CorreoElectronico nvarchar(100),
	@emp_Telefono nvarchar(20),
	@carg_Id int,
	@emp_FechaIngreso date,
	@emp_FechadeSalida date,
	@emp_RazonSalida nvarchar(250),
	@emp_UsuarioCrea int,
	@emp_FechaCrea datetime	
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbEmpleados]
			(
				emp_Identidad,
				emp_Nombres,
				emp_Apellidos,
				emp_FechaNacimiento,
				emp_Sexo,
				emp_Direccion,
				mun_Id,
				emp_CorreoElectronico,
				emp_Telefono,
				carg_Id,
				emp_FechaIngreso,
				emp_FechadeSalida,
				emp_RazonSalida,
				emp_UsuarioCrea,
				emp_FechaCrea
			)
			VALUES
			(
				@emp_Identidad,
				@emp_Nombres,
				@emp_Apellidos,
				@emp_FechaNacimiento,
				@emp_Sexo,
				@emp_Direccion,
				@mun_Id,
				@emp_CorreoElectronico,
				@emp_Telefono,
				@carg_Id,
				@emp_FechaIngreso,
				@emp_FechadeSalida,
				@emp_RazonSalida,
				@emp_UsuarioCrea,
				@emp_FechaCrea			
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbEmpleados_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbEmpleados_Update]
(
	@emp_Id int,
	@emp_Identidad varchar (20) ,
	@emp_Nombres nvarchar(100),
	@emp_Apellidos nvarchar(100),
	@emp_FechaNacimiento date,
	@emp_Sexo char(1),
	@emp_Direccion nvarchar(100),
	@mun_Id char(4),
	@emp_CorreoElectronico nvarchar(100),
	@emp_Telefono nvarchar(20),
	@carg_Id int,
	@emp_FechaIngreso date,
	@emp_FechadeSalida date,
	@emp_RazonSalida nvarchar(250),
	@emp_UsuarioCrea int,
	@emp_FechaCrea datetime,
	@emp_UsuarioModifica int,
	@emp_FechaModifica datetime	
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE [Gral].[tbEmpleados]
			SET	
				emp_Identidad			=	@emp_Identidad,
				emp_Nombres				=	@emp_Nombres,
				emp_Apellidos			=	@emp_Apellidos,
				emp_FechaNacimiento		=	@emp_FechaNacimiento,
				emp_Sexo				=	@emp_Sexo,
				emp_Direccion			=	@emp_Direccion,
				mun_Id					=	@mun_Id,
				emp_CorreoElectronico	=	@emp_CorreoElectronico,
				emp_Telefono			=	@emp_Telefono,
				carg_Id					=	@carg_Id,
				emp_FechaIngreso		=	@emp_FechaIngreso,
				emp_FechadeSalida		=	@emp_FechadeSalida,
				emp_RazonSalida			=	@emp_RazonSalida,
				emp_UsuarioCrea			=	@emp_UsuarioCrea,
				emp_FechaCrea			=	@emp_FechaCrea,
				emp_UsuarioModifica		=	@emp_UsuarioModifica,
				emp_FechaModifica		=	@emp_FechaModifica
				WHERE emp_Id			=	@emp_Id	
				
			SELECT CAST(@emp_Id AS varchar) AS MensajeError	
					           
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbEscuelas_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbEscuelas_Insert]
	(
	@esc_Codigo [varchar](20) ,
	@esc_NombreEscuela [nvarchar](100) ,
	@esc_Director [int] ,
	@esc_Contacto [int] ,
	@esc_Telefono [varchar](20) ,
	@esc_Correo [nvarchar](100) ,
	@mun_Id [char](4) ,
	@esc_UsuarioCrea [int] ,
	@esc_FechaCrea [datetime]
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbEscuelas]
			(
				esc_Codigo,
				esc_NombreEscuela, 
				esc_Director, 
				esc_Contacto, 
				esc_Telefono, 
				esc_Correo, 
				mun_Id, 
				esc_UsuarioCrea, 
				esc_FechaCrea
			)
			VALUES
			(
				@esc_Codigo  ,
				@esc_NombreEscuela ,
				@esc_Director  ,
				@esc_Contacto ,
				@esc_Telefono  ,
				@esc_Correo ,
				@mun_Id  ,
				@esc_UsuarioCrea ,
				@esc_FechaCrea 
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbEscuelas_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [Gral].[UDP_Gral_tbEscuelas_Update]
(	@esc_Id INT,
	@esc_Codigo varchar(20),
	@esc_NombreEscuela nvarchar(100),
	@esc_Director int,
	@esc_Contacto int,
	@esc_Telefono varchar(20),
	@esc_Correo nvarchar(100),
	@mun_Id char(4),
	@esc_UsuarioCrea int, 
	@esc_FechaCrea DateTime,
	@esc_UsuarioModifica int, 
	@esc_FechaModifica DateTime 
)
AS	
BEGIN
	BEGIN TRY
		BEGIN TRAN
			Update gral.tbEscuelas set 			
				esc_Codigo = @esc_Codigo, 
				esc_NombreEscuela = @esc_NombreEscuela, 
				esc_Director = @esc_Director, 
				esc_Contacto = @esc_Contacto, 
				esc_Telefono = @esc_Telefono, 
				esc_Correo = @esc_Correo, 
				mun_Id = @mun_Id,
				esc_UsuarioCrea = @esc_UsuarioCrea, 
				esc_FechaCrea = @esc_UsuarioModifica, 
				esc_UsuarioModifica = @esc_UsuarioModifica, 
				esc_FechaModifica = @esc_FechaModifica	
				Where esc_Id = @esc_Id			
			
	
			SELECT CAST(@esc_Id AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END

GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbGrados_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 Create Procedure [Gral].[UDP_Gral_tbGrados_Insert]
(
	@grad_Descripcion varchar(10),
	@grad_UsuarioCrea int, 
	@grad_FechaCrea DATETIME 
)
AS	
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO gral.tbgrados
			(
				grad_Descripcion, grad_UsuarioCrea,grad_FechaCrea
			)
			VALUES
			(
				@grad_Descripcion,
				@grad_UsuarioCrea,
				@grad_FechaCrea
			)
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbGrados_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [Gral].[UDP_Gral_tbGrados_Update]
(
	@grad_Id int,
	@grad_Descripcion varchar(10),
	@grad_UsuarioCrea int, 
	@grad_FechaCrea DATETIME,
	@grad_UsuarioMofifica int, 
	@grad_FechaModifica DateTime 
)
AS	
BEGIN
	BEGIN TRY
		BEGIN TRAN
			Update gral.tbgrados set 
			grad_Descripcion = @grad_Descripcion,
			grad_UsuarioCrea = @grad_UsuarioCrea,
			grad_FechaCrea = @grad_FechaCrea,
			grad_UsuarioModifica = @grad_UsuarioMofifica,
			grad_FechaModifica = @grad_FechaModifica
			Where grad_Id = @grad_Id;
	
			SELECT CAST(@grad_Id AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbJornadas_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbJornadas_Insert]
	(
		@jor_Descripcion varchar(15),
		@jor_UsuarioCrea int,
	    @jor_FechaCrea datetime
	)
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Gral].[tbJornadas]
			(
				jor_Descripcion, jor_UsuarioCrea, jor_FechaCrea
			)
			VALUES
			(
				@jor_Descripcion,
				@jor_UsuarioCrea,
				@jor_FechaCrea
			 )
	
			SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
            
          COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbJornadas_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbJornadas_Update]
	(
		@jor_Id int,
		@jor_Descripcion varchar(15),
		@jor_UsuarioCrea int,
	    @jor_FechaCrea datetime,
		@jor_UsuarioModifica int,
		@jor_FechaModifica datetime
	)
AS
BEGIN
	
   BEGIN TRY
		BEGIN TRAN
		   UPDATE  [Gral].[tbJornadas] SET 
					jor_Descripcion=@jor_Descripcion, 
					jor_UsuarioCrea=@jor_UsuarioCrea , 
					jor_FechaCrea = @jor_FechaCrea,
					jor_UsuarioModifica = @jor_UsuarioModifica,
					jor_FechaModifica = @jor_FechaModifica

		    WHERE   jor_Id= @jor_Id
			SELECT  CAST(@jor_Id AS varchar) AS MensajeError   
        COMMIT TRAN
   END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbMunicipios_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Gral].[UDP_Gral_tbMunicipios_Insert]
(
@mun_Id char(4) ,
@mun_Descripcion varchar(50) ,
@mun_UsuarioCrea int ,
@mun_FechaCrea DATETIME ,
@dep_Id char(2)
)
as
begin
BEGIN TRY
		BEGIN TRAN
		INSERT INTO [Gral].[tbMunicipios]
			(
				mun_Id, mun_Descripcion, mun_UsuarioCrea, mun_FechaCrea,dep_Id
			)
			VALUES
			(
				@mun_Id,
				@mun_Descripcion,
				@mun_UsuarioCrea,
				@mun_FechaCrea,
				@dep_Id
			)
			SELECT CAST(@mun_Id AS varchar) AS MensajeError
			     COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbMunicipios_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Gral].[UDP_Gral_tbMunicipios_Update]
(
@mun_Id char(4) ,
@mun_Descripcion varchar(50) ,
@mun_UsuarioCrea int ,
@mun_FechaCrea DATETIME ,
@mun_UsuarioModifica int ,
@mun_FechaModifica datetime ,
@dep_Id char(2) 
)
as
begin
BEGIN TRY
update [Gral].[tbMunicipios]		
			set						
				mun_Descripcion=@mun_Descripcion,
				mun_UsuarioCrea=@mun_UsuarioCrea,
				mun_FechaCrea=@mun_FechaCrea,
                mun_UsuarioModifica = @mun_UsuarioModifica,
			    mun_FechaModifica=@mun_FechaModifica 
				where dep_Id=@dep_Id

			SELECT CAST(@mun_Id AS varchar) AS MensajeError
			     COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError  
	END CATCH
END	
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbSecciones_Insert]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbSecciones_Insert]
(
	@sec_Descripcion CHAR(1), 
	@sec_UsuarioCrea INT, 
	@sec_FechaCrea DATETIME, 
	@jgra_Id INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		INSERT INTO [SAT].[Gral].[tbSecciones]
		(
			[sec_Descripcion], [sec_UsuarioCrea], [sec_FechaCrea], [jgra_Id]
		)
		VALUES 
		(
				@sec_Descripcion, 
				@sec_UsuarioCrea, 
				@sec_FechaCrea, 
				@jgra_Id
		)

		SELECT CAST(SCOPE_IDENTITY() AS varchar) AS MensajeError
		COMMIT TRAN 
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT '-1 ' + ERROR_MESSAGE() AS MensajeError
	END CATCH
END
GO
/****** Object:  StoredProcedure [Gral].[UDP_Gral_tbSecciones_Update]    Script Date: 19/07/2019 16:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Gral].[UDP_Gral_tbSecciones_Update]
(
	@sec_Id INT,
	@sec_Descripcion CHAR(1),
	@sec_UsuarioCrea INT, 
	@sec_FechaCrea DATETIME, 
	@sec_UsuarioModifica INT, 
	@sec_FechaModifica DATETIME, 
	@jgra_Id INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN

		UPDATE [SAT].[Gral].[tbSecciones]
		   SET @sec_Descripcion = sec_Descripcion, 
			   @sec_UsuarioCrea = sec_UsuarioCrea,
			   @sec_FechaCrea = sec_FechaCrea,
			   @sec_UsuarioModifica = sec_UsuarioModifica,
			   @sec_FechaModifica = sec_FechaModifica,
			   @jgra_Id = jgra_Id
		
		WHERE @sec_Id = sec_Id

		SELECT CAST(@sec_Id AS varchar) AS MensajeError
		COMMIT TRAN 
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT '-1' + ERROR_MESSAGE() AS MensajeError
	END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [SAT] SET  READ_WRITE 
GO
