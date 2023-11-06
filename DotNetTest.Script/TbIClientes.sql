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

INSERT INTO DevLab.dbo.TbIClientes (id, RazonSocial, IdTipoCliente, FechaCreacion, RFC) VALUES (1, N'Helen S. Arnold', 1, N'2023-01-15', N'ABCD123456EFG');
INSERT INTO DevLab.dbo.TbIClientes (id, RazonSocial, IdTipoCliente, FechaCreacion, RFC) VALUES (2, N'Woolf Brothers', 2, N'2023-03-20', N'HIJK789012LMN');
INSERT INTO DevLab.dbo.TbIClientes (id, RazonSocial, IdTipoCliente, FechaCreacion, RFC) VALUES (3, N'Catherine H. Glover', 1, N'2022-12-05', N'OPQR345678STU');
INSERT INTO DevLab.dbo.TbIClientes (id, RazonSocial, IdTipoCliente, FechaCreacion, RFC) VALUES (4, N'Bennett Brothers', 2, N'2023-06-18', N'VWXY901234ZAB');
