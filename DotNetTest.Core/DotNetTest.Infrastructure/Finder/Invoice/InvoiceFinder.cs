using System.Data;
using Dapper;
using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.Exception;
using DotNetTest.Domain.Models;
using DotNetTest.Infrastructure.Finder.Util;

namespace DotNetTest.Infrastructure.Finder.Invoice;

public class InvoiceFinder : IInvoiceFinder
{
    private readonly IDbConnection _connection;

    public InvoiceFinder(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<InvoiceDto> FindByIdAsync(int invoiceId)
    {
        var sql = SqlReader.GetQuery("get-invoice-by-id").Result;
        var dictionary = new Dictionary<string, object>()
        {
            { "@InvoiceId", invoiceId }
        };

        var parameters = new DynamicParameters(dictionary);

        var invoice = await _connection.QueryAsync<InvoiceDto, ClientDto, InvoiceDto>(sql, (invoice, client) =>
        {
            invoice.Client = client;
            return invoice;
        }, parameters, splitOn: "Id, Id");

        var invoiceListDto = invoice.ToList();
        if (invoice == null || !invoiceListDto.Any()) throw new BadRequestException("Invoice does not exist.");

        var currentInvoice = invoiceListDto.FirstOrDefault();

        if (currentInvoice == null) throw new BadRequestException("Invoice does not exist.");

        return currentInvoice;
    }

    public async Task<InvoiceDto?> GetTheLastAsync()
    {
        var sql = SqlReader.GetQuery("get-the-last-invoice").Result;
        var dictionary = new Dictionary<string, object>();

        var parameters = new DynamicParameters(dictionary);

        var invoice = await _connection.QueryAsync<InvoiceDto, ClientDto, InvoiceDto>(sql, (invoice, client) =>
        {
            invoice.Client = client;
            return invoice;
        }, parameters, splitOn: "Id, Id");

        var invoiceListDto = invoice.ToList();
        var theLastInvoiceDto = invoiceListDto.FirstOrDefault();

        if (theLastInvoiceDto != null)
        {
            return theLastInvoiceDto;
        }

        var invoiceAllListDto = await GetListAsync();

        var invoiceDto = invoiceAllListDto.LastOrDefault();

        return invoiceDto;
    }

    public async Task<IList<InvoiceDto>> GetListAsync()
    {
        var sql = SqlReader.GetQuery("get-invoice-list").Result;

        var invoice = await _connection.QueryAsync<InvoiceDto, ClientDto, InvoiceDto>(sql, (invoice, client) =>
        {
            invoice.Client = client;
            return invoice;
        }, splitOn: "Id, Id");

        var invoiceListDto = invoice.ToList();

        return invoiceListDto;
    }

    public async Task<IList<InvoiceDto>> GetByClientIdAsync(int clientId)
    {
        var sql = SqlReader.GetQuery("get-invoice-by-client-id").Result;
        var dictionary = new Dictionary<string, object>()
        {
            { "@ClientId", clientId }
        };

        var parameters = new DynamicParameters(dictionary);

        var invoice = await _connection.QueryAsync<InvoiceDto, ClientDto, InvoiceDto>(sql, (invoice, client) =>
        {
            invoice.Client = client;
            return invoice;
        }, parameters, splitOn: "Id, Id");

        var invoiceListDto = invoice.ToList();
        if (invoice == null || !invoiceListDto.Any()) throw new BadRequestException("Invoice does not exist.");

        return invoiceListDto;
    }
}