using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByTheLastQueryHandler : IRequestHandler<InvoiceByTheLastQuery, InvoiceDto?>
{
    private readonly IInvoiceFinder _finder;

    public InvoiceByTheLastQueryHandler(IInvoiceFinder productFinder)
    {
        _finder = productFinder;
    }

    public Task<InvoiceDto?> Handle(InvoiceByTheLastQuery request, CancellationToken cancellationToken)
    {
        return _finder.GetTheLastAsync();
    }
}