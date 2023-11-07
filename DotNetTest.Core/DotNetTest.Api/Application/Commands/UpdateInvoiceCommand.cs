using MediatR;

namespace DotNetTest.Api.Application.Commands;

public class UpdateInvoiceCommand : IRequest<bool>
{
    public int InvoiceNumber { get; set; }
}