create table TbIFacturas
(
    Id                   int            not null
        constraint TbIFacturas_pk
            primary key,
    FechaEmisionFactura  date           not null,
    IdCliente            int            not null
        constraint TbIFacturas_TbIClientes_id_fk
            references TbIClientes,
    NumeroFactura        int            not null,
    NumeroTotalArticulos int            not null,
    SubTotalFactura      decimal(18, 2) not null,
    TotalImpuesto        decimal(18, 2),
    TotalFactura         decimal(18, 2) not null
)
go

