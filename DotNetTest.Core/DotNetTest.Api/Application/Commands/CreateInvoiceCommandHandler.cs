using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using MediatR;

namespace DotNetTest.Api.Application.Commands;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, bool>
{
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceFinder _finder;

    public CreateInvoiceCommandHandler(IInvoiceRepository repository, IInvoiceFinder finder)
    {
        _repository = repository;
        _finder = finder;
    }

    public async Task<bool> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoiceId = 0;
        var listInvoiceDto = await _finder.GetListAsync();
        listInvoiceDto = listInvoiceDto.OrderBy(x => x.Id).ToList();
        var lastInvoiceDto = listInvoiceDto.LastOrDefault();

        if (lastInvoiceDto != null)
        {
            invoiceId = lastInvoiceDto.Id + 1;
        }

        var invoice = new Invoice()
        {
            Id = invoiceId,
            InvoiceDate = request.InvoiceDate,
            ClientId = request.ClientId,
            InvoiceNumber = request.InvoiceNumber,
            TotalItems = request.TotalItems,
            Subtotal = request.Subtotal,
            TaxTotal = request.TaxTotal,
            Total = request.Total,
        };
        return await _repository.Create(invoice);
    }
}