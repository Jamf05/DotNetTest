using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.Models;

public class ProductDto : IDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public byte[]?  ImageProduct { get; set; }
    public decimal UnitPrice { get; set; }
    public string Ext { get; set; } = string.Empty;
}