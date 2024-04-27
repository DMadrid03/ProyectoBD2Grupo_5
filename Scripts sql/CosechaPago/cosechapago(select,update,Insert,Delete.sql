use db20211900096
go
create or alter procedure spCosechaPagoSelect @cosechaID int
as
	create table #cosecha
	(nomProd varchar(50),codigoFinca int, NombreFinca varchar(100),Lote varchar(20),FechaSiembra datetime,PrecioCultivo float,
	CosechaID int,CantidadCosechada int,Unidad varchar(30),FechaCosecha datetime,Producto varchar(100))

	insert into #cosecha
		exec spCosechaSelect 0,0,@cosechaID
	select *into #Cosechapago from cosechaPago where cosechapagoID in(select cosechapagoid from #cosecha)
	
	select c.nomProd,codigoFinca,NombreFinca,Lote,FechaSiembra,PrecioCultivo,CantidadCosechada,Unidad,
	FechaCosecha,Producto,cp.CosechaID,cp.Valor ValorPago,cp.Fecha FechaPago from #Cosecha c
	inner join #cosechaPago cp on cp.CosechaID = c.CosechaID
go

execute spCosechapagoSElect 0