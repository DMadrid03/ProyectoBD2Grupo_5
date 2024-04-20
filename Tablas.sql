-- Creando la base de datos
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ProyectoBDII')
BEGIN
    CREATE DATABASE ProyectoBDII;
END
GO


USE ProyectoBDII;

-- Productor
CREATE TABLE Productor (
  ProductorID INT NOT NULL,
  Nombre VARCHAR(100) NOT NULL,
  CONSTRAINT pkProductor PRIMARY KEY (ProductorID)
);

-- Proveedor
CREATE TABLE Proveedor (
  ProveedorID INT NOT NULL,
  Nombre VARCHAR(100) NOT NULL,
  Direccion VARCHAR(150),
  CONSTRAINT pkProveedor PRIMARY KEY (ProveedorID)
);

-- Insumo
CREATE TABLE Insumo (
  InsumoID INT NOT NULL,
  Nombre VARCHAR(100) NOT NULL,
  Existencia INT NOT NULL,
  TipoInsumoID INT NOT NULL,
  Observacion VARCHAR(200) NULL,
  CONSTRAINT pkInsumo PRIMARY KEY (InsumoID)
);

-- Producto
CREATE TABLE Producto (
  ProductoID INT NOT NULL,
  Nombre VARCHAR(100) NOT NULL,
  Existencia INT NOT NULL,
  UnidadID INT NOT NULL,
  CONSTRAINT pkProducto PRIMARY KEY (ProductoID)
);

-- Finca
CREATE TABLE Finca (
  FincaID INT NOT NULL,
  Nombre VARCHAR(100) NOT NULL,
  ProductorID INT NOT NULL,
  CONSTRAINT pkFinca PRIMARY KEY (FincaID),
  CONSTRAINT fkFincaProductor FOREIGN KEY (ProductorID) REFERENCES Productor(ProductorID)
);

-- Lote
CREATE TABLE Lote (
  LoteID INT NOT NULL,
  FincaID INT NOT NULL,
  Extension FLOAT NOT NULL,
  TipoSueloID INT NOT NULL,
  TipoRiegoID INT NOT NULL,
  CantidadCosechas INT NOT NULL,
  CONSTRAINT pkLote PRIMARY KEY (LoteID),
  CONSTRAINT fkLoteFinca FOREIGN KEY (FincaID) REFERENCES Finca(FincaID)
);

-- Cultivo
CREATE TABLE Cultivo (
  CultivoID INT NOT NULL,
  LoteID INT NOT NULL,
  FechaSiembra DATETIME NOT NULL,
  FechaCosecha DATETIME,
  Precio FLOAT NOT NULL,
  CONSTRAINT pkCultivo PRIMARY KEY (CultivoID),
  CONSTRAINT fkCultivoLote FOREIGN KEY (LoteID) REFERENCES Lote(LoteID)
);

-- Cosecha
CREATE TABLE Cosecha (
  CosechaID INT NOT NULL,
  ProductoID INT NOT NULL,
  CultivoID INT NOT NULL,
  UnidadID INT NOT NULL,
  Cantidad INT NOT NULL,
  CONSTRAINT pkCosecha PRIMARY KEY (CosechaID),
  CONSTRAINT fkCosechaProducto FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID),
  CONSTRAINT fkCosechaCultivo FOREIGN KEY (CultivoID) REFERENCES Cultivo(CultivoID)
);

-- CultivoInsumo
CREATE TABLE CultivoInsumo (
  CultivoInsumoID INT NOT NULL,
  CultivoID INT NOT NULL,
  InsumoID INT NOT NULL,
  CONSTRAINT pkCultivoInsumo PRIMARY KEY (CultivoInsumoID),
  CONSTRAINT fkCultivoInsumoCultivo FOREIGN KEY (CultivoID) REFERENCES Cultivo(CultivoID),
  CONSTRAINT fkCultivoInsumoInsumo FOREIGN KEY (InsumoID) REFERENCES Insumo(InsumoID)
);

-- Compra
CREATE TABLE Compra (
  CompraID INT NOT NULL,
  TipoCompraID INT NOT NULL,
  ProveedorID INT NOT NULL,
  ProductorID INT NOT NULL,
  Fecha DATE NOT NULL,
  FechaVencimiento DATE NULL,
  CONSTRAINT pkCompra PRIMARY KEY (CompraID),
  CONSTRAINT fkCompraProveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor(ProveedorID),
  CONSTRAINT fkCompraProductor FOREIGN KEY (ProductorID) REFERENCES Productor(ProductorID)
);

-- CompraDetalle
CREATE TABLE CompraDetalle (
  CompraDetalleID INT NOT NULL,
  CompraID INT NOT NULL,
  InsumoID INT NOT NULL,
  Cantidad INT NOT NULL,
  Precio FLOAT NOT NULL,
  CONSTRAINT pkCompraDetalle PRIMARY KEY (CompraDetalleID),
  CONSTRAINT fkCompraDetalleCompra FOREIGN KEY (CompraID) REFERENCES Compra(CompraID),
  CONSTRAINT fkCompraDetalleInsumo FOREIGN KEY (InsumoID) REFERENCES Insumo(InsumoID)
);

-- CosechaPago
CREATE TABLE CosechaPago (
  CosechaPagoID INT NOT NULL,
  CosechaID INT NOT NULL,
  Valor FLOAT NOT NULL,
  Fecha DATETIME NOT NULL,
  CONSTRAINT pkCosechaPago PRIMARY KEY (CosechaPagoID),
  CONSTRAINT fkCosechaPagoCosecha FOREIGN KEY (CosechaID) REFERENCES Cosecha(CosechaID)
);

-- Cobro
CREATE TABLE Cobro (
  CobroID INT NOT NULL,
  CompraID INT NOT NULL,
  CosechaPagoID INT NOT NULL,
  Valor FLOAT NOT NULL,
  Fecha DATE NOT NULL,
  CONSTRAINT pkCobro PRIMARY KEY (CobroID),
  CONSTRAINT fkCobroCompra FOREIGN KEY (CompraID) REFERENCES Compra(CompraID),
  CONSTRAINT fkCobroCosechaPago FOREIGN KEY (CosechaPagoID) REFERENCES CosechaPago(CosechaPagoID)
);

