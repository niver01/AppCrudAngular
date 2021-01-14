CREATE DATABASE [DB_CRUD]
USE [DB_CRUD]

--------------------------------------------------------------------------
---  TABLA USUARIOS  
--------------------------------------------------------------------------
CREATE TABLE [tb_usuario](
	[id_usuario] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[email] [varchar](60) NULL,
	[password] [varchar](128) NULL
)

--------------------------------------------------------------------------
---  TABLA CONTRUBUYENTES  
--------------------------------------------------------------------------
CREATE TABLE [tb_tipo_contribuyente](
	[id_tipo_contribuyente] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[estato] [bit] NULL DEFAULT ((1))
)

--------------------------------------------------------------------------
---  TABLA DOCUMENTOS  
--------------------------------------------------------------------------
CREATE TABLE [tb_tipo_documento](
	[id_tipo_documento] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[estato] [bit] NULL DEFAULT ((1))
)

--------------------------------------------------------------------------
---  TABLA ENTIDADES  
--------------------------------------------------------------------------
CREATE TABLE [dbo].[tb_entidad](
	[id_entidad] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[id_tipo_documento] [int] REFERENCES [tb_tipo_documento]([id_tipo_documento]) NOT NULL,
	[nro_documento] [varchar](30) NOT NULL,
	[razon_social] [varchar](200) NOT NULL,
	[nombre_comercial] [varchar](200) NOT NULL,
	[id_tipo_contribuyente] [int] REFERENCES [tb_tipo_contribuyente]([id_tipo_contribuyente]) NOT NULL,
	[direccion] [varchar](200) NULL,
	[telefono] [varchar](50) NULL,
	[estato] [bit] NULL DEFAULT ((1))
)

INSERT [tb_usuario] ([email], [password]) VALUES ('prueba@gmail.com', N'655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b'); -- contraseña (prueba)