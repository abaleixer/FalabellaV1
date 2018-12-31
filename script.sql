USE [master]
GO
/****** Object:  Database [Falabella]    Script Date: 31/12/2018 6:58:09 a. m. ******/
CREATE DATABASE [Falabella]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Falabella', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Falabella.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Falabella_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Falabella_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Falabella] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Falabella].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Falabella] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Falabella] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Falabella] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Falabella] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Falabella] SET ARITHABORT OFF 
GO
ALTER DATABASE [Falabella] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Falabella] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Falabella] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Falabella] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Falabella] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Falabella] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Falabella] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Falabella] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Falabella] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Falabella] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Falabella] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Falabella] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Falabella] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Falabella] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Falabella] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Falabella] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Falabella] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Falabella] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Falabella] SET  MULTI_USER 
GO
ALTER DATABASE [Falabella] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Falabella] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Falabella] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Falabella] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Falabella] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Falabella]
GO
/****** Object:  Table [dbo].[Aseguradoras]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aseguradoras](
	[idAseguradora] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](80) NOT NULL,
	[descripcion] [nvarchar](500) NOT NULL,
	[logo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Aseguradoras] PRIMARY KEY CLUSTERED 
(
	[idAseguradora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idCliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idPersona] [numeric](18, 0) NOT NULL,
	[idPoliza] [numeric](18, 0) NOT NULL,
	[idCobertura] [numeric](18, 0) NOT NULL,
	[valorPrima] [float] NOT NULL,
	[fechaCompra] [datetime] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personas]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[idPersona] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](80) NOT NULL,
	[apellidos] [nvarchar](100) NOT NULL,
	[cumpleanios] [datetime] NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
	[telefono] [nvarchar](50) NULL,
	[celular] [nvarchar](20) NULL,
	[identificacion] [nvarchar](50) NOT NULL,
	[idTipoIdentificacion] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Polizas]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polizas](
	[idPoliza] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idAseguradora] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](500) NOT NULL,
	[cobertura] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Polizas] PRIMARY KEY CLUSTERED 
(
	[idPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PorcentajeCobertura]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PorcentajeCobertura](
	[idCobertura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idPoliza] [numeric](18, 0) NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
	[porcentaje] [float] NOT NULL,
 CONSTRAINT [PK_PorcentajeCobertura] PRIMARY KEY CLUSTERED 
(
	[idCobertura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposIdentificacion]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposIdentificacion](
	[idTipoIdentificacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposIdentificacion] PRIMARY KEY CLUSTERED 
(
	[idTipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](100) NOT NULL,
	[idPersona] [numeric](18, 0) NOT NULL,
	[idRol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Personas]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Polizas] FOREIGN KEY([idPoliza])
REFERENCES [dbo].[Polizas] ([idPoliza])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Polizas]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Personas] FOREIGN KEY([idTipoIdentificacion])
REFERENCES [dbo].[TiposIdentificacion] ([idTipoIdentificacion])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Personas]
GO
ALTER TABLE [dbo].[Polizas]  WITH CHECK ADD  CONSTRAINT [FK_Polizas_Aseguradoras] FOREIGN KEY([idAseguradora])
REFERENCES [dbo].[Aseguradoras] ([idAseguradora])
GO
ALTER TABLE [dbo].[Polizas] CHECK CONSTRAINT [FK_Polizas_Aseguradoras]
GO
ALTER TABLE [dbo].[PorcentajeCobertura]  WITH CHECK ADD  CONSTRAINT [FK_PorcentajeCobertura_Polizas] FOREIGN KEY([idPoliza])
REFERENCES [dbo].[Polizas] ([idPoliza])
GO
ALTER TABLE [dbo].[PorcentajeCobertura] CHECK CONSTRAINT [FK_PorcentajeCobertura_Polizas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[AgregarAseguradora]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Agrega una aseguradora>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarAseguradora]
	(
	   @nombre varchar(80), 
	   @descripcion varchar(500), 
	   @logo varchar(100)
	)
AS
BEGIN
DECLARE @idAseguradora numeric
    INSERT INTO  Aseguradoras 
	             (nombre, 
				  descripcion, 
				  logo) 
		  VALUES (@nombre, 
		          @descripcion, 
				  @logo)   
	
	      SELECT idAseguradora, nombre, descripcion, logo
            FROM Aseguradoras    
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Agrega un cliente>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarCliente] 
	(
	  @idPersona numeric,
	  @idPoliza numeric,
	  @idCobertura numeric,
      @valorPrima float
	)
AS
BEGIN
	INSERT INTO Clientes(idPersona,
	                     idPoliza,
						 idCobertura,
						 valorPrima,
						 fechaCompra) 
	              VALUES (@idPersona,
				          @idPoliza,
						  @idCobertura,
						  @valorPrima,
						  GETDATE())
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarPersona]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Agrega Persona>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarPersona] 
	(
	  @nombre varchar(80),
	  @apellidos varchar(100),
	  @cumpleanios datetime,
      @direccion varchar(150),
      @telefono varchar(50),
      @celular varchar(20),
	  @identificacion varchar(50),
	  @idTipoIdentificacion numeric
	)
AS
BEGIN
DECLARE @idPersona numeric
SET @idPersona  = 0;
	INSERT INTO Personas (nombre,
	                      apellidos,
						  cumpleanios,
						  direccion,
						  telefono,
						  celular,
						  identificacion,
						  idTipoIdentificacion) 
	              VALUES (@nombre,
				          @apellidos,
                          @cumpleanios ,
                          @direccion ,
                          @telefono ,
                          @celular ,
	                      @identificacion ,
	                      @idTipoIdentificacion)
	SET @idPersona = @@IDENTITY
	SELECT @idPersona ;
	RETURN
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarPoliza]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Agrega una poliza>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarPoliza]
	(
	   @nombre varchar(50), 
	   @descripcion varchar(500), 
	   @cobertura varchar(1000),
	   @idAseguradora numeric
	)
AS
BEGIN

    INSERT INTO  Polizas 
	             (idAseguradora,
				  nombre, 
				  descripcion, 
				  cobertura) 
		  VALUES (@idAseguradora,
		          @nombre, 
		          @descripcion, 
				  @cobertura)   
	
	      SELECT idPoliza, idAseguradora, nombre, descripcion, cobertura
            FROM Polizas  
		   WHERE idAseguradora = @idAseguradora  
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarPorcentajeCobertura]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Agrega una cobertura con el porcentaje para el cobro de prima>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarPorcentajeCobertura]
	(
	   @tipo varchar(50), 	  
	   @idPoliza numeric,
	   @porcentaje float
	)
AS
BEGIN

    INSERT INTO  PorcentajeCobertura 
	             (idPoliza,
				  tipo, 
				  porcentaje) 
		  VALUES (@idPoliza,
		          @tipo, 
		          @porcentaje)   
	
	      SELECT idCobertura, idPoliza, tipo, porcentaje
            FROM PorcentajeCobertura  
		   WHERE idPoliza = @idPoliza  
END

GO
/****** Object:  StoredProcedure [dbo].[AutenticarUsuario]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Albarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Autentica al usuario y retorna el rol >
-- =============================================
CREATE PROCEDURE [dbo].[AutenticarUsuario] 
	(
	  @usuario varchar(50),
	  @pass varchar(100)
	)
AS
BEGIN

	    SELECT Usuarios.idUsuario, Usuarios.idRol, Personas.nombre, Personas.apellidos
          FROM Usuarios INNER JOIN
               Personas ON Personas.idPersona = Usuarios.idPersona
         WHERE (Usuarios.usuario = @usuario) AND (Usuarios.pass = @pass)
		
	RETURN 
END

GO
/****** Object:  StoredProcedure [dbo].[DarAseguradoras]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna las aseguradoras existentes>
-- =============================================
CREATE PROCEDURE [dbo].[DarAseguradoras]
	
AS
BEGIN    
	SELECT idAseguradora, nombre, descripcion, logo
      FROM Aseguradoras
END

GO
/****** Object:  StoredProcedure [dbo].[DarClientes]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna la lista de clientes>
-- =============================================
CREATE PROCEDURE [dbo].[DarClientes] 
	
AS
BEGIN
	SELECT Clientes.idCliente, Clientes.idPersona, Personas.identificacion,
	       Personas.nombre, Personas.apellidos, 
		   Personas.telefono, Personas.celular, 
		   Personas.direccion, Personas.cumpleanios, 
		   Clientes.idPoliza, Polizas.nombre AS nombrePoliza, 
           Clientes.idCobertura, PorcentajeCobertura.porcentaje, 
		   PorcentajeCobertura.tipo, Clientes.valorPrima, Clientes.fechaCompra
      FROM Clientes INNER JOIN
           Personas ON Personas.idPersona = Clientes.idPersona INNER JOIN
           PorcentajeCobertura ON PorcentajeCobertura.idCobertura = Clientes.idCobertura INNER JOIN
           Polizas ON Polizas.idPoliza = Clientes.idPoliza

END

GO
/****** Object:  StoredProcedure [dbo].[DarPolizasXidAseguradora]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna las Polizas por aseguradora>
-- =============================================
CREATE PROCEDURE [dbo].[DarPolizasXidAseguradora]
	(
	  @idAseguradora numeric
	)
AS
BEGIN    
	SELECT idPoliza, idAseguradora, nombre, descripcion, cobertura
      FROM Polizas
     WHERE (idAseguradora = @idAseguradora)
END

GO
/****** Object:  StoredProcedure [dbo].[DarPorcentajesPolizasXidPoliza]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna porcentajes prima polizas por id poliza>
-- =============================================
CREATE PROCEDURE [dbo].[DarPorcentajesPolizasXidPoliza]
	(
	  @idpoliza numeric
	)
AS
BEGIN    
	SELECT idCobertura, idPoliza, tipo, porcentaje
      FROM PorcentajeCobertura
     WHERE (idPoliza = @idpoliza)
END

GO
/****** Object:  StoredProcedure [dbo].[DarPorcentajesPolizaXidPorcentaje]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna porcentajes prima polizas por id poliza>
-- =============================================
CREATE PROCEDURE [dbo].[DarPorcentajesPolizaXidPorcentaje]
	(
	  @idCobertura numeric
	)
AS
BEGIN    
	SELECT idCobertura, idPoliza, tipo, porcentaje
      FROM PorcentajeCobertura
     WHERE (idCobertura = @idCobertura)
END

GO
/****** Object:  StoredProcedure [dbo].[DarTiposIdentificacion]    Script Date: 31/12/2018 6:58:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aleixer Alvarado>
-- Create date: <Diciembre 30, 2018>
-- Description:	<Retorna la lista de tipos de identificación>
-- =============================================
CREATE PROCEDURE [dbo].[DarTiposIdentificacion] 
	
AS
BEGIN
	SELECT idTipoIdentificacion, descripcion
      FROM TiposIdentificacion
END

GO
USE [master]
GO
ALTER DATABASE [Falabella] SET  READ_WRITE 
GO
