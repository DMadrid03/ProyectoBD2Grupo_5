use DB20211900096
go
drop procedure spProductoSelect
go
create procedure spProductoSelect @ProductoID int
as
	select *from Producto where ProductoID = @ProductoID or @ProductoID = 0
go

grant execute on spProductoSelect to Public

-----------------------------------------------------------------------------------------------
go
drop procedure spProductoInsert
go
create procedure spProductoInsert @ProductoID int,@Nombre varchar(50),@Existencia int,@UnidadID int
as
	select @ProductoID = ISNULL(max(productoID),0)+1 from Producto

	insert into Producto values (@ProductoID,@Nombre,@Existencia,@UnidadID)
go

grant execute on spProductoInsert to Public

-----------------------------------------------------------------------------------------------
go
drop procedure spProductoUpdate
go
create procedure spProductoUpdate @ProductoID int,@Nombre varchar(50),@Existencia int,@UnidadID int
as
	update Producto set Nombre = @Nombre, Existencia = @Existencia,UnidadID = @UnidadID
		Where ProductoID = @ProductoID
go

grant execute on spProductoUpdate to Public
-----------------------------------------------------------------------------------------------
go
drop procedure spProductoDelete
go
create procedure spProductoDelete @ProductoID int
as
	delete from producto where productoid = @ProductoID
go

grant execute on spProductoDelete to Public
-----------------------------------------------------------------------------------------------
