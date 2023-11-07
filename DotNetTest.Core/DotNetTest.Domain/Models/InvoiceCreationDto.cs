using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.Models;

public class InvoiceCreationDto : IDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}