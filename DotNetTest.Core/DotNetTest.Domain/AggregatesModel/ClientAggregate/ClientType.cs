using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.ClientAggregate;

public class ClientType : IEntity
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}