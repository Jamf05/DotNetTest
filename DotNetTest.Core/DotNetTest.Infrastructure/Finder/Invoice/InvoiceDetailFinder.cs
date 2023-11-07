using System.Data;
using Dapper;
using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.Models;
using DotNetTest.Infrastructure.Finder.Util;

namespace DotNetTest.Infrastructure.Finder.Invoice;

public class InvoiceDetailFinder : IInvoiceDetailFinder
{
    private readonly IDbConnection _connection;

    public InvoiceDetailFinder(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<InvoiceDetailDto> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<InvoiceDetailDto>> GetListAsync()
    {
        var sql = SqlReader.GetQuery("get-invoice-detail-list").Result;

        var invoiceDetail = await _connection.QueryAsync<InvoiceDetailDto>(sql);

        var invoiceDetailListDto = invoiceDetail.ToList();

        return invoiceDetailListDto;
    }
}