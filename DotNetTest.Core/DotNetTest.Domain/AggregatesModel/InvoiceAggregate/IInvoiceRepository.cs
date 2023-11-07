using DotNetTest.Domain.Models;
using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.InvoiceAggregate;

public interface IInvoiceRepository : IRepository
{
    Task<bool> Create(Invoice invoice);
}