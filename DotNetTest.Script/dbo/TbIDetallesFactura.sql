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
    Notas                  varchar(200)   not null
)
go

