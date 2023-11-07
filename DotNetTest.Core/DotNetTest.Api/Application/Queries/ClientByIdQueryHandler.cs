using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ClientByIdQueryHandler : IRequestHandler<ClientByIdQuery, ClientDto>
{
    private readonly IClientFinder _finder;

    public ClientByIdQueryHandler(IClientFinder finder)
    {
        _finder = finder;
    }

    public async Task<ClientDto> Handle(ClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _finder.FindByIdAsync(request.ClientId);
    }
}