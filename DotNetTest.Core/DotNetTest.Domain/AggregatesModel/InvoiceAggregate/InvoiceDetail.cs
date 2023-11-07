using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.InvoiceAggregate;

public class InvoiceDetail : IEntity
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public string Notes { get; set; } = String.Empty;
}