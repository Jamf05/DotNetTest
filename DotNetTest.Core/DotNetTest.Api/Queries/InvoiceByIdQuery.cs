using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByIdQuery : IRequest<InvoiceDto>
{
    public int InvoiceId { get; set; }

    public InvoiceByIdQuery(int invoiceId)
    {
        InvoiceId = invoiceId;
    }
}