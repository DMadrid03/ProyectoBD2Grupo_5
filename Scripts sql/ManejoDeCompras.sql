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



CREATE PROCEDURE spListaInsumosSelect @busqueda varchar(20)
AS
	SELECT * INTO #insumo FROM Insumo
	WHERE Nombre LIKE '%'+@busqueda+'%' OR @busqueda = ''

	SELECT * INTO #tipo FROM dbo.TipoInsumo()
	WHERE TipoInsumoID IN (Select TipoInsumoID From #insumo)

	SELECT i.InsumoID, i.Nombre, i.Existencia, t.Nombre AS 'Tipo de Insumo', i.Observacion
	FROM #insumo as i
	INNER JOIN #tipo as t ON i.TipoInsumoID = t.TipoInsumoID
GO

CREATE PROCEDURE spInsumoSelect @insumoid int
AS
	SELECT * FROM Insumo
	WHERE InsumoID = @insumoid
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

/** Procedimientos para manejar las compras y los detalles**/
CREATE FUNCTION dbo.CalcularPkCompra() returns int
AS
	BEGIN
		DECLARE @pk INT

		SELECT @pk = ISNULL(MAX(CompraID),0) + 1 FROM Compra

		return @pk
	END

ALTER PROCEDURE spListaCompraSelect @tipo int
AS
	if @tipo =1
		BEGIN
			Select c.CompraID, c.TipoCompraID, p.ProveedorID, p.Nombre, c.Fecha, c.FechaVencimiento
			from Compra c
			Inner join Proveedor p ON c.ProveedorID = p.ProveedorID
			Where TipoCompraID=1
		END
	IF @tipo = 2
		Begin
			select c.CompraID, c.TipoCompraID, prod.ProductorID, prod.Nombre, c.Fecha, c.CultivoID
			from Compra c
			INNER JOIN Productor prod on prod.ProductorID = c.ProductorID
			where TipoCompraID = 2
		End
go

CREATE PROCEDURE spCompraSelect @compraid int
AS
	SELECT * FROM Compra where CompraID = @compraid
GO

CREATE PROCEDURE spCompraInsert @compraid int, @tipocompraid int,
							@proveedorid int, @productorid int, 
							@fecha DATE, @fechavencimiento DATE
AS
	select @compraid = dbo.CalcularPkCompra()
	if @tipocompraid =1
		Begin
			insert into Compra (CompraID, TipoCompraID, ProveedorID, Fecha, FechaVencimiento)
					values		(@compraid, @tipocompraid, @proveedorid, @fecha, @fechavencimiento)
		End
	if @tipocompraid = 2
		Begin
			insert into Compra (CompraID, TipoCompraID, ProductorID, Fecha)
					values		(@compraid, @tipocompraid, @productorid, @fecha)
		End
GO

CREATE PROCEDURE spCompraUpdate @compraid int, @tipocompraid int,
							@proveedorid int, @productorid int, 
							@fecha DATE, @fechavencimiento DATE
AS
	if @tipocompraid =1
		Begin
			Update	Compra
			Set CompraID =@compraid, TipoCompraID =@tipocompraid, 
				ProveedorID = @proveedorid, Fecha = @fecha, FechaVencimiento = @fechavencimiento
		End
	if @tipocompraid = 2
		Begin
			Update	Compra
			Set CompraID =@compraid, TipoCompraID =@tipocompraid, 
				ProductorID = @productorid, Fecha = @fecha
		End
GO

Alter PROCEDURE spCompraDetalleSelect @compraid int
AS
	declare @tipo int
	select @tipo = TipoCompraID from Compra where CompraID = @compraid
	
	if @tipo = 1
		Begin
			Select cd.CompraDetalleID, cd.CompraID, i.InsumoID, i.Nombre,
					cd.Cantidad, cd.Precio
			from CompraDetalle as cd
			INNER JOIN Insumo as i ON i.InsumoID = cd.InsumoID
			where CompraID = @compraid
		End

	if @tipo = 2
		Begin
			select cd.CompraDetalleID, cd.CompraID, i.InsumoID, i.Nombre, 
					cd.Cantidad, cd.Precio,
					Precio*(1+0.05) AS 'Cobro Productor'
			from CompraDetalle as cd
			INNER JOIN Insumo as i On i.InsumoID = cd.InsumoID
			where CompraID = @compraid
		END
			
GO


CREATE PROCEDURE spCompraDetalleInsert @compraid int, @insumoid int, @cantidad int, @precio float
AS
	declare @pk int
	select @pk = max(isnull(CompraDetalleID, 0)) +1 from CompraDetalle
	INSERT INTO CompraDetalle values (@pk, @compraid, @insumoid, @cantidad, @precio)
GO

CREATE PROCEDURE spCompraDetalleUpdate @compraid int, @insumoid int, @cantidad int, @precio float
AS
	UPDATE CompraDetalle
	set InsumoID = @insumoid, Cantidad = @cantidad, Precio = @precio
	WHERE CompraID = @compraid
GO

exec spCompraSelect 1
exec spCompraSelect 2