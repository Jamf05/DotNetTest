using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByClientIdQueryHandler : IRequestHandler<InvoiceByClientIdQuery, IList<InvoiceDto>>
{
    private readonly IInvoiceFinder _finder;

    public InvoiceByClientIdQueryHandler(IInvoiceFinder productFinder)
    {
        _finder = productFinder;
    }

    public Task<IList<InvoiceDto>> Handle(InvoiceByClientIdQuery request, CancellationToken cancellationToken)
    {
        return _finder.GetByClientIdAsync(request.ClientId);
    }
}