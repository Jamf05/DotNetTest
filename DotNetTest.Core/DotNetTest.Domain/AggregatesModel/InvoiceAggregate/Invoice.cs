using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.InvoiceAggregate;

public class Invoice : IEntity
{
    public int Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public int ClientId { get; set; }
    public int InvoiceNumber { get; set; }
    public int TotalItems { get; set; }
    public decimal Subtotal { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal Total { get; set; }
}