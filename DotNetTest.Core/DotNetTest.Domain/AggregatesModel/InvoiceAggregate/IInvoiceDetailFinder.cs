using DotNetTest.Domain.Models;
using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.InvoiceAggregate;

public interface IInvoiceDetailFinder : IFinder<InvoiceDetailDto, int>
{
    public Task<IList<InvoiceDetailDto>> GetListAsync();
}