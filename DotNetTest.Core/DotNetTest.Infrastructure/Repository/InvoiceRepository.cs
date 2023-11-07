using System.Data;
using Dapper;
using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Infrastructure.Finder.Util;

namespace DotNetTest.Infrastructure.Repository;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IDbConnection _connection;

    public InvoiceRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> Create(Invoice invoice)
    {
        
        
        var sql = SqlReader.GetCommand("create-invoice").Result;
        var dictionary = new Dictionary<string, object>()
        {
            { "@Id", invoice.Id },
            { "@InvoiceDate", invoice.InvoiceDate },
            { "@ClientId", invoice.ClientId },
            { "@InvoiceNumber", invoice.InvoiceNumber },
            { "@TotalItems", invoice.TotalItems },
            { "@Subtotal", invoice.Subtotal },
            { "@TaxTotal", invoice.TaxTotal },
            { "@Total", invoice.Total }
        };

        var parameters = new DynamicParameters(dictionary);
        
       

        await _connection.ExecuteAsync(sql, parameters);

        return true;
    }
}