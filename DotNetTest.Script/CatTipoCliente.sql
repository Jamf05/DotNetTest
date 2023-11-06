create table CatTipoCliente
(
    ID          int         not null
        constraint CatTipoCliente_pk
            primary key,
    TipoCliente varchar(50) not null
)
go

INSERT INTO DevLab.dbo.CatTipoCliente (ID, TipoCliente) VALUES (1, N'CONSUMER');
INSERT INTO DevLab.dbo.CatTipoCliente (ID, TipoCliente) VALUES (2, N'COMPANY');
