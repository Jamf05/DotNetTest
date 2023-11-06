create table TbIClientes
(
    id            int          not null
        constraint TbIClientes_pk
            primary key,
    RazonSocial   varchar(200) not null,
    IdTipoCliente int          not null
        constraint TbIClientes_CatTipoCliente_ID_fk
            references CatTipoCliente,
    FechaCreacion date         not null,
    RFC           varchar(50)  not null
)
go

