using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ClientListQuery : IRequest<IList<ClientDto>>
{
}