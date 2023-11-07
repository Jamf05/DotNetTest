using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ClientByIdQuery : IRequest<ClientDto>
{
    public int ClientId { get; set; }

    public ClientByIdQuery(int clientId)
    {
        ClientId = clientId;
    }
}