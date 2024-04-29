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

ALTER PROCEDURE spCompraInsert @compraid int, @tipocompraid int,
							@proveedorid int, @productorid int, 
							@fecha DATE, @fechavencimiento DATE, @cultivo int
AS
	select @compraid = dbo.CalcularPkCompra()
	if @tipocompraid =1
		Begin
			insert into Compra (CompraID, TipoCompraID, ProveedorID, Fecha, FechaVencimiento)
					values		(@compraid, @tipocompraid, @proveedorid, @fecha, @fechavencimiento)
		End
	if @tipocompraid = 2
		Begin
			insert into Compra (CompraID, TipoCompraID, ProductorID, Fecha, CultivoID)
					values		(@compraid, @tipocompraid, @productorid, @fecha, @cultivo)
		End
GO

ALTER PROCEDURE spCompraUpdate @compraid int, @tipocompraid int,
							@proveedorid int, @productorid int, 
							@fecha DATE, @fechavencimiento DATE
AS
	if @tipocompraid =1
		Begin
			Update	Compra
			Set TipoCompraID =@tipocompraid, 
				ProveedorID = @proveedorid, Fecha = @fecha, FechaVencimiento = @fechavencimiento
			WHERE CompraID =@compraid
		End
	if @tipocompraid = 2
		Begin
			Update	Compra
			Set TipoCompraID =@tipocompraid, 
				ProductorID = @productorid, Fecha = @fecha
			where CompraID =@compraid
		End
GO

Alter PROCEDURE spCompraDetalleSelect @compraid int, @tipo int
AS
	
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


ALTER PROCEDURE spCompraDetalleInsert @compraid int, @insumoid int, @cantidad int, @precio float
AS
	BEGIN TRANSACTION
	declare @pk int, @tipo int, @error int

	select @tipo = TipoCompraID from Compra where CompraID = @compraid

	select @pk = max(isnull(CompraDetalleID, 0)) +1 from CompraDetalle

	
	INSERT INTO CompraDetalle values (@pk, @compraid, @insumoid, @cantidad, @precio)
	if @@ERROR <> 0
		set @error = @@ERROR

	exec spActualizarExistencia @tipo, @insumoid, @cantidad, @error output


	if @error =0
		Commit
	Else
		Rollback
GO

ALTER PROCEDURE spCompraDetalleUpdate @compraid int, @insumoid int, @cantidad int, @precio float
AS
	BEGIN TRANSACTION
	declare @cantidadActual int, @cambio int, @tipo int, @error int
	select @cantidadActual = Cantidad from CompraDetalle 
							 where CompraID = @compraid AND InsumoID = @insumoid


	select @tipo = TipoCompraID from Compra where CompraID = @compraid

	set @cambio = @cantidad - @cantidadActual

	UPDATE CompraDetalle
	set  Cantidad = @cantidad, Precio = @precio
	WHERE CompraID = @compraid AND InsumoID = @insumoid

	if @@ERROR <> 0
		set @error = @@ERROR

	EXEC spActualizarExistencia @tipo, @insumoid, @cambio, @error output

	if @error =0
		Commit
	Else
		Rollback
GO

CREATE PROCEDURE spObtenerProductorDeCultivo @cultivoid int
AS
	select p.ProductorID, p.Nombre  from Productor p
	inner join Finca f on p.ProductorID=f.ProductorID
	inner join Lote l on l.FincaID=f.FincaID
	inner join Cultivo c on l.LoteID=c.LoteID  where c.cultivoID=@cultivoid
GO

Alter PROCEDURE spActualizarExistencia @tipo int, @insumoid int, @cantidadinsert int, @err int output
AS
	if @tipo = 1
		BEGIN
			Update Insumo
			set Existencia = (Existencia+ @cantidadinsert)
			WHERE InsumoID = @insumoid
			
			set @err = @@ERROR
		END
	if @tipo = 2
		BEGIN
			Update Insumo
			set Existencia = (Existencia - @cantidadinsert)
			WHERE InsumoID = @insumoid

			SET @err = @@ERROR
		END
GO

Alter table Insumo Add constraint chkExistencia check (Existencia >=0)

create or alter function dbo.TipoCompra() returns @TipoCompra table
	(TipoCompraID int, Nombre varchar(50))
as
	begin
		insert into @TipoCompra values
			(1,'Compra a Proveedores'), --agrocomercializadora compra grandes cantidades a los proveedores
			(2,'Solicitud de insumos a la agrocomercializadora') --los productores solicitan insumos a la agrocomercializadora
		return
	end
go
