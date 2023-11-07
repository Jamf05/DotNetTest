create table CatProductos
(
    Id             int identity
        constraint CatProductos_pk
            primary key,
    NombreProducto varchar(50)    not null,
    ImagenProducto image,
    PrecioUnitario decimal(18, 2) not null,
    ext            varchar(5)
)
go

