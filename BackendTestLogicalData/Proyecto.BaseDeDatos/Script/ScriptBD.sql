
--- ==================================================
--- Autor: Jirgort McCarty V
--- Fecha: 18/09/2024
--- Descripción: Crea la Base de Datos y los Esquemas
--- de la prueba
--- ==================================================
CREATE DATABASE PruebaLogicalData;
GO

USE PruebaLogicalData;
GO

CREATE SCHEMA Usuarios;
GO

CREATE SCHEMA Articulos;
GO

CREATE SCHEMA Facturas;
GO


--- ==================================================
--- Autor: Jirgort McCArty V
--- Fecha: 18/09/2024
--- Descripción: crea la tabla de usuario del sistema.
--- ==================================================
CREATE TABLE Usuarios.Usuario (
	Id INT IDENTITY(1, 1),
	Nombre NVARCHAR(25) NOT NULL,
	Apellido NVARCHAR(25) NOT NULL,
	Username NVARCHAR(25) NOT NULL,
	Contrasenia VARBINARY(64) NOT NULL,
	CONSTRAINT PkUsuarioId PRIMARY KEY(Id),
	CONSTRAINT UqNombre UNIQUE(Nombre)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los usuarios del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Usuarios',
	@level1type = N'TABLE',
	@level1name = N'Usuario'
;
go
CREATE TABLE Articulos.Articulo (
	Id INT IDENTITY(1, 1),
	Codigo NVARCHAR(25) NOT NULL,
	Nombre NVARCHAR(25) NOT NULL,
	Precio decimal NOT NULL,
	IVA BIT NOT NULL,
	CONSTRAINT PkArticuloId PRIMARY KEY(Id),
	CONSTRAINT UqArticuloCodigo UNIQUE(Codigo)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los articulos del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Articulos',
	@level1type = N'TABLE',
	@level1name = N'Articulo'
;
GO
--- ==================================================
--- Autor: Jirgort McCArty V
--- Fecha: 18/09/2024
--- Descripción: Script encargado de crear la tabla de 
--- ordenes.
--- ==================================================
CREATE TABLE Facturas.Orden (
	Id INT IDENTITY(1, 1),
	UsuarioId INT NOT NULL,
	Fecha date NOT NULL,
	Total decimal NOT NULL,
	CONSTRAINT PkOrdenId PRIMARY KEY(Id),
	CONSTRAINT FkOrdenUsuarioId FOREIGN KEY(UsuarioId) REFERENCES Usuarios.Usuario(Id)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena las ordenes del sistema', 
	@level0type = N'SCHEMA',
	@level0name = N'Facturas',
	@level1type = N'TABLE',
	@level1name = N'Orden'
;
GO

--- ==================================================
--- Autor: Jirgort McCArty V
--- Fecha: 18/09/2024
--- Descripción: Script encargado de crear la tabla de 
--- items de las ordenes.
--- ==================================================
CREATE TABLE Facturas.Item (
	Id INT IDENTITY(1, 1),
	OrdenId INT NOT NULL,
	ArticuloId INT NOT NULL,
	Cantidad int NOT NULL,
	Precio decimal NOT NULL,
	Total decimal NOT NULL,
	CONSTRAINT PkItem PRIMARY KEY(Id),
	CONSTRAINT FkItemOrdenId FOREIGN KEY(OrdenId) REFERENCES Facturas.Orden(Id),
	CONSTRAINT FkItemArticuloId FOREIGN KEY(ArticuloId) REFERENCES Articulos.Articulo(Id)
);

EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los items de las facturas del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Facturas',
	@level1type = N'TABLE',
	@level1name = N'Item'
;
GO