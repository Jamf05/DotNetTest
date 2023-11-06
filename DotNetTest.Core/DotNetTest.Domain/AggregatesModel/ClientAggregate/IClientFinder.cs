using DotNetTest.Domain.Models;
using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.ClientAggregate;

public interface IClientFinder : IFinder<ClientDto, int>
{
    Task<IList<ClientDto>> GetList();
}