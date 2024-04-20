use DB20211900096

--agregar funciones para listas cerradas
--tipoRiego, TipoSuelo,TipoInsumo,Unidad(cosecha),TipoCompra,
go
create or alter function dbo.TipoRiego() returns @TipoRiego table
	(TipoRiegoID int, Nombre varchar(50))
as
	begin
		insert into @TipoRiego values(1,'Goteo'),(2,'Aspersión'),(3,'Exudación'),(4,'Gravedad'),(5,'Común')
		return
	end
go

create or alter function dbo.TipoSuelo() returns @TipoSuelo table
	(TipoSueloID int, Nombre varchar(50))
as
	begin
		insert into @TipoSuelo values 
			(1, 'Suelos arenosos'),
			(2, 'Suelos limosos'),
			(3, 'Suelos arcillosos'),
			(4, 'Suelos francos'),
			(5, 'Suelos calcáreos'),
			(6, 'Suelos orgánicos inundados'),
			(7, 'Suelos urbanos'),
			(8, 'Suelos congelados'),
			(9, 'Suelos volcánicos'),
			(10, 'Suelos pedregosos')
		return
	end
go

create or alter function dbo.TipoInsumo() returns @TipoInsumo table
	(TipoInsumoID int, Nombre varchar(50))
as
	begin
		insert into  @TipoInsumo values
			(1, 'Fertilizantes'),
			(2, 'Pesticidas'),
			(3, 'Herbicidas'),
			(4, 'Abonos orgánicos'),		
			(6, 'Herramientas')
		return
	end
go

create or alter function dbo.Unidad() returns @Unidad table
	(UnidadID int, Nombre varchar(50))
as
	begin
		insert into @Unidad values
			(1,'Unidad'),
			(2,'Quintal'),
			(3,'Kilogramo'),
			(4,'Hectárea'),
			(5,'Fangea'),
			(6,'Acre')
		return
	end
go

create or alter function dbo.TipoCompra() returns @TipoCompra table
	(TipoCompraID int, Nombre varchar(20))
as
	begin
		insert into @TipoCompra values
			(1,'Compra a Proveedores'), --agrocomercializadora compra grandes cantidades a los proveedores
			(2,'Solicitud de insumos a la agrocomercializadora') --los productores solicitan insumos a la agrocomercializadora
		return
	end
go

