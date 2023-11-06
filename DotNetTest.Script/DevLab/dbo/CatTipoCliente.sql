create table CatTipoCliente
(
    ID          int         not null
        constraint CatTipoCliente_pk
            primary key,
    TipoCliente varchar(50) not null
)
go

