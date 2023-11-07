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

INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (0, N'2023-11-06', 1, 2, 0, 0.00, 0.00, 0.00);
INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (1, N'2023-11-06', 1, 1, 0, 0.00, 0.00, 0.00);
INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (2, N'2023-11-06', 2, 1001, 5, 100.00, 15.00, 115.00);
INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (3, N'2023-11-06', 2, 3, 0, 0.00, 0.00, 0.00);
INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (4, N'2023-11-06', 4, 4, 1, 26.50, 5.04, 31.54);
INSERT INTO DevLab.dbo.TbIFacturas (Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFactura, TotalImpuesto, TotalFactura) VALUES (5, N'2023-11-06', 4, 5, 2, 3.08, 0.59, 3.67);
