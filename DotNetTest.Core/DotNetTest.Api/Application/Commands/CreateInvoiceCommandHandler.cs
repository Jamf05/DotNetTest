using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Domain.Exception;
using MediatR;

namespace DotNetTest.Api.Application.Commands;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, bool>
{
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceFinder _invoiceFinder;
    private readonly IInvoiceDetailFinder _invoiceDetailFinder;
    private readonly IProductFinder _productFinder;

    public CreateInvoiceCommandHandler(IInvoiceRepository repository, IInvoiceFinder invoiceFinder,
        IProductFinder productFinder, IInvoiceDetailFinder invoiceDetailFinder)
    {
        _repository = repository;
        _invoiceFinder = invoiceFinder;
        _productFinder = productFinder;
        _invoiceDetailFinder = invoiceDetailFinder;
    }

    public async Task<bool> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var totalItems = 0;
        var subtotal = 0.00m;
        var taxTotal = 0.00m;
        var total = 0.00m;

        var details = new List<InvoiceDetail>();

        var invoiceId = 0;
        var listInvoiceDto = await _invoiceFinder.GetListAsync();
        listInvoiceDto = listInvoiceDto.OrderBy(x => x.Id).ToList();

        if (listInvoiceDto.Any(e => e.InvoiceNumber == request.InvoiceNumber))
            throw new BadRequestException("Invoice Number must be unique");

        var lastInvoiceDto = listInvoiceDto.LastOrDefault();

        if (lastInvoiceDto != null)
        {
            invoiceId = lastInvoiceDto.Id + 1;
        }

        var invoiceDetailId = 0;
        var listInvoiceDetailDto = await _invoiceDetailFinder.GetListAsync();
        listInvoiceDetailDto = listInvoiceDetailDto.OrderBy(x => x.Id).ToList();
        var lastInvoiceDetailDto = listInvoiceDetailDto.LastOrDefault();

        if (lastInvoiceDetailDto != null)
        {
            invoiceDetailId = lastInvoiceDetailDto.Id + 1;
        }

        foreach (var item in request.DetailsList)
        {
            var product = await _productFinder.FindByIdAsync(item.ProductId);
            if (product == null) throw new BadRequestException("");
            details.Add(new InvoiceDetail()
            {
                Id = invoiceDetailId,
                InvoiceId = invoiceId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.UnitPrice,
                Subtotal = product.UnitPrice * item.Quantity
            });
            invoiceDetailId += 1;
        }

        totalItems = details.Count;
        subtotal = details.Sum(x => x.Subtotal);
        taxTotal = subtotal * 0.19m;
        total = subtotal + taxTotal;

        var invoice = new Invoice()
        {
            Id = invoiceId,
            InvoiceDate = request.InvoiceDate,
            ClientId = request.ClientId,
            InvoiceNumber = request.InvoiceNumber,
            TotalItems = totalItems,
            Subtotal = subtotal,
            TaxTotal = taxTotal,
            Total = total,
        };
        return await _repository.Create(invoice, details);
    }
}