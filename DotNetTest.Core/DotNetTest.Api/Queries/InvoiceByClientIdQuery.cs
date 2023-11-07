using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByClientIdQuery : IRequest<IList<InvoiceDto>>
{
    public int ClientId { get; set; }

    public InvoiceByClientIdQuery(int clientId)
    {
        ClientId = clientId;
    }
}