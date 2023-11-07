using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ClientListQueryHandler : IRequestHandler<ClientListQuery, IList<ClientDto>>
{
    private readonly IClientFinder _finder;

    public ClientListQueryHandler(IClientFinder finder)
    {
        _finder = finder;
    }

    public async Task<IList<ClientDto>> Handle(ClientListQuery request, CancellationToken cancellationToken)
    {
        return await _finder.GetListAsync();
    }
}