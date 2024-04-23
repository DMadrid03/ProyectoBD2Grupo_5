
create or alter procedure spCosechaSelect @CultivoID int = 0, @ProductoID int = 0
as	
	select *into #cosecha from Cosecha where (cultivoid = @CultivoID or @cultivoID = 0) and 
		(ProductoID = @ProductoID or @ProductoID = 0)

	select *into #Cultivo from cultivo where cultivoid in(select cultivoid from #cosecha)
	select *into #Lote from lote where loteid in (select loteid from #Cultivo)
	select *into #Finca from finca where fincaID in (select fincaID from #lote)
	select *into #Productor from Productor where productorID in(select ProductorID from #Finca)
	
	select p.Nombre,F.FincaID CodigoFinca, f.Nombre NombreFinca,L.LoteID,
	from #Productor p
	inner join #Finca F on f.ProductorID = p.ProductorID
	inner join #Lote L on L.FincaID = f.FincaID
	inner join #Cultivo cult on cult.LoteID = l.LoteID
	inner join #cosecha c on c.CultivoID = cult.CultivoID
go
------------------------------------------------------------------------


create or alter procedure spCosechaInsert @CosechaID int,@ProductoID int, @CultivoID int, 
	@UnidadID int, @Cantidad int, @Fecha datetime
as
	select @CosechaID = ISNULL(max(cosechaID),0)+1 from cosecha

	insert into cosecha values (@CosechaID,@ProductoID,@CultivoID,@UnidadID,@Cantidad,@Fecha)
go
------------------------------------------------------------------------

create or alter procedure spCosechaUpdate @CosechaID int,@ProductoID int, @CultivoID int, 
	@UnidadID int, @Cantidad int, @Fecha datetime
as
	update cosecha set ProductoID = @ProductoID, CultivoID = @CultivoID,UnidadID = @UnidadID,
		Cantidad = @Cantidad, Fecha = @Fecha where cosechaID = @CosechaID
go
------------------------------------------------------------------------


create or alter procedure spCosechaDelete @CosechaID int
as
	Delete from cosecha where cosechaID = @cosechaID
go
------------------------------------------------------------------------



