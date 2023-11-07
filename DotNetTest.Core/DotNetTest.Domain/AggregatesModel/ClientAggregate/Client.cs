using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.ClientAggregate;

public class Client : IEntity
{
    public int Id { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public int ClientTypeId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Rfc { get; set; } = string.Empty;
    public ClientType ClientType { get; set; } = null!;
}