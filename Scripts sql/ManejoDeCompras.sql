USE DB20211900096
GO

/*Procedimientos para manejar Tabla Proveedor*/

CREATE PROCEDURE spProveedorSelect @proveedorid INT
AS
	SELECT * FROM Proveedor
	WHERE ProveedorID = @proveedorid OR @proveedorid = 0
GO

CREATE PROCEDURE spProveedorInsert @proveedorid INT OUTPUT, @nombre VARCHAR(50), @direccion VARCHAR(50)
AS
	SELECT @proveedorid = ISNULL(MAX(ProveedorID),0) + 1 FROM Proveedor

	INSERT INTO Proveedor VALUES (@proveedorid, @nombre, @direccion)
GO

CREATE PROCEDURE spProveedorUpdate @proveedorid INT, @nombre VARCHAR(50), @direccion VARCHAR(50)
AS
	UPDATE Proveedor
	SET Nombre = @nombre, Direccion=@direccion
	WHERE ProveedorID = @proveedorid
GO

CREATE PROCEDURE spProveedorDelete @proveedorid INT
AS
	DELETE FROM Proveedor WHERE ProveedorID = @proveedorid
GO

CREATE PROCEDURE spBusquedaProveedor @texto VARCHAR(50)
AS
	SELECT * FROM Proveedor WHERE Nombre LIKE ('%'+ @texto + '%')
GO


/** Procedimientos para manejar Tabla Insumo **/
CREATE FUNCTION dbo.CalcularPkInsumo() returns int
AS
	BEGIN
		DECLARE @pk INT

		SELECT @pk = ISNULL(MAX(InsumoID),0) + 1 FROM Insumo

		return @pk
	END



CREATE PROCEDURE spInsumoSelect @insumoid int
AS
	SELECT * FROM Insumo
	WHERE InsumoID = @insumoid OR @insumoid = 0
GO

CREATE PROCEDURE spInsumoInsert @insumoid INT OUTPUT, @nombre VARCHAR(100), @tipo INT, @observacion VARCHAR(200)
AS
	SELECT @insumoid = dbo.CalcularPkInsumo()

	INSERT INTO Insumo (InsumoID, Nombre, Existencia, TipoInsumoID, Observacion)
	VALUES (@insumoid, @nombre, 0, @tipo, @observacion)
GO

CREATE PROCEDURE spInsumoUpdate @insumoid INT, @nombre VARCHAR(100), @tipo INT, @observacion VARCHAR(200)
AS
	UPDATE Insumo
	SET Nombre = @nombre, TipoInsumoID = @tipo, Observacion = @observacion
	WHERE InsumoID = @insumoid
GO

CREATE PROCEDURE spInsumoDelete @insumoid INT
AS
	DELETE FROM Insumo WHERE InsumoID = @insumoid
GO

CREATE PROCEDURE spBusquedaInsumo @texto VARCHAR(50)
AS
	SELECT * FROM Insumo WHERE Nombre LIKE ('%'+ @texto + '%')
GO