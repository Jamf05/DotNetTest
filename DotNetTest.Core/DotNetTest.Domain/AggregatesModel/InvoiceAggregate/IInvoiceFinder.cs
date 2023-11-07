using DotNetTest.Domain.Models;
using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.InvoiceAggregate;

public interface IInvoiceFinder : IFinder<InvoiceDto, int>
{
    Task<InvoiceDto?> GetTheLastAsync();
    Task<IList<InvoiceDto>> GetListAsync();
    Task<IList<InvoiceDto>> GetByClientIdAsync(int clientId);
}