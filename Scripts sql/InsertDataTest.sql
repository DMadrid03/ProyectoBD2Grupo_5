USE DB20211900096
-- Productor
INSERT INTO Productor (ProductorID, Nombre) VALUES
(1, 'Juan Perez'),
(2, 'Maria Rodriguez'),
(3, 'Pedro Gomez');

-- Proveedor
INSERT INTO Proveedor (ProveedorID, Nombre, Direccion) VALUES
(1, 'Proveedor A', 'Calle 123, Ciudad X'),
(2, 'Proveedor B', 'Avenida 456, Ciudad Y'),
(3, 'Proveedor C', 'Carrera 789, Ciudad Z');

-- Insumo
INSERT INTO Insumo (InsumoID, Nombre, Existencia, TipoInsumoID, Observacion) VALUES
(1, 'Semilla de maíz', 500, 1, NULL),
(2, 'Fertilizante NPK', 200, 2, NULL),
(3, 'Insecticida', 100, 3, NULL);

-- Producto
INSERT INTO Producto (ProductoID, Nombre, Existencia, UnidadID) VALUES
(1, 'Maíz', 100, 1),
(2, 'Frijol', 50, 1),
(3, 'Café', 80, 1);

-- Finca
INSERT INTO Finca (FincaID, Nombre, ProductorID) VALUES
(1, 'Finca A', 1),
(2, 'Finca B', 2),
(3, 'Finca C', 3);

-- Lote
INSERT INTO Lote (LoteID, FincaID, Extension, TipoSueloID, TipoRiegoID, CantidadCosechas) VALUES
(1, 1, 10.5, 1, 1, 2),
(2, 2, 15.3, 2, 2, 3),
(3, 3, 20.0, 3, 3, 1);

INSERT INTO Lote (LoteID, FincaID, Extension, TipoSueloID, TipoRiegoID, CantidadCosechas) VALUES
(5, 1, 10.25, 3, 1, 2),
(6, 2, 55.3, 2, 2, 6),
(7, 3, 25.0, 1, 3, 1);
-- Cultivo
INSERT INTO Cultivo (CultivoID, LoteID, FechaSiembra, Precio) VALUES
(1, 1, '2024-04-01', 500),
(2, 2, '2024-03-15', 700),
(3, 3, '2024-04-10', 600);

-- Cosecha
INSERT INTO Cosecha (CosechaID, ProductoID, CultivoID, UnidadID, Cantidad, Fecha) VALUES
(1, 1, 1, 1, 50, '2024-06-01'),
(2, 2, 2, 1, 30, '2024-07-15'),
(3, 3, 3, 1, 40, '2024-06-20');

-- CultivoInsumo
INSERT INTO CultivoInsumo (CultivoInsumoID, CultivoID, InsumoID) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3);

-- Compra
INSERT INTO Compra (CompraID, TipoCompraID, ProveedorID, ProductorID, Fecha, FechaVencimiento) VALUES
(1, 1, 1, 1, '2024-05-01', '2024-06-01'),
(2, 2, 2, 2, '2024-04-20', '2024-05-20'),
(3, 1, 3, 3, '2024-05-10', '2024-06-10');

-- CompraDetalle
INSERT INTO CompraDetalle (CompraDetalleID, CompraID, InsumoID, Cantidad, Precio) VALUES
(1, 1, 1, 100, 200),
(2, 2, 2, 50, 300),
(3, 3, 3, 30, 150);

-- CosechaPago
INSERT INTO CosechaPago (CosechaPagoID, CosechaID, Valor, Fecha) VALUES
(1, 1, 250, '2024-07-01'),
(2, 2, 210, '2024-08-15'),
(3, 3, 240, '2024-07-20');

-- Cobro
INSERT INTO Cobro (CobroID, CompraID, CosechaPagoID, Valor, Fecha) VALUES
(1, 1, 1, 200, '2024-06-01'),
(2, 2, 2, 150, '2024-07-15'),
(3, 3, 3, 180, '2024-06-20');


SELECT  P.ProductorID, p.Nombre, f.Nombre, LoteID AS Lote, lt.Extension, lt.TipoSueloID, lt.TipoRiegoID, lt.CantidadCosechas from Productor p inner join finca f on p.ProductorID=f.ProductorID inner join Lote lt on lt.FincaID=f.FincaID

