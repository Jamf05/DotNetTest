create table TbIDetallesFactura
(
    Id                     int            not null
        constraint TbIDetallesFactura_pk
            primary key,
    IdFactura              int            not null
        constraint TbIDetallesFactura_TbIFacturas_Id_fk
            references TbIFacturas,
    IdProducto             int            not null
        constraint TbIDetallesFactura_CatProductos_Id_fk
            references CatProductos,
    CantidadDeProducto     int            not null,
    PrecioUnitarioProducto decimal(18, 2) not null,
    SubtotalProducto       decimal(18, 2) not null,
    Notas                  varchar(200)
)
go

INSERT INTO DevLab.dbo.TbIDetallesFactura (Id, IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas) VALUES (0, 4, 10, 5, 5.30, 26.50, N'');
INSERT INTO DevLab.dbo.TbIDetallesFactura (Id, IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas) VALUES (1, 5, 1, 3, 0.42, 1.26, N'');
INSERT INTO DevLab.dbo.TbIDetallesFactura (Id, IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas) VALUES (2, 5, 4, 2, 0.91, 1.82, N'');
