using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.Models;

public class ClientDto : IDto
{
    public int Id { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public int ClientTypeId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Rfc { get; set; } = string.Empty;
    public ClientTypeDto ClientType { get; set; } = null!;
}