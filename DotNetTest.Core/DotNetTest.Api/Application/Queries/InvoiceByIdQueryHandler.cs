using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByIdQueryHandler : IRequestHandler<InvoiceByIdQuery, InvoiceDto>
{
    private readonly IInvoiceFinder _finder;

    public InvoiceByIdQueryHandler(IInvoiceFinder productFinder)
    {
        _finder = productFinder;
    }

    public Task<InvoiceDto> Handle(InvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        return _finder.FindByIdAsync(request.InvoiceId);
    }
}