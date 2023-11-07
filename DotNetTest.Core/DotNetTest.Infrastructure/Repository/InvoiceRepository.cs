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

    public async Task<bool> Create(Invoice invoice, IList<InvoiceDetail> details)
    {
        _connection.Open();
        var transaction = _connection.BeginTransaction();
        try
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

            await _connection.ExecuteAsync(sql, parameters, transaction);

            foreach (var detail in details)
            {
                var sqlDetail = SqlReader.GetCommand("create-invoice-detail").Result;
                var dictionaryDetail = new Dictionary<string, object>()
                {
                    { "@Id", detail.Id },
                    { "@InvoiceId", detail.InvoiceId },
                    { "@ProductId", detail.ProductId },
                    { "@Quantity", detail.Quantity },
                    { "@UnitPrice", detail.UnitPrice },
                    { "@Subtotal", detail.Subtotal },
                    { "@Notes", detail.Notes },
                };

                var parametersDetail = new DynamicParameters(dictionaryDetail);

                await _connection.ExecuteAsync(sqlDetail, parametersDetail, transaction);
            }

            transaction.Commit();
            _connection.Close();
            return true;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            _connection.Close();
            throw;
        }
    }
}