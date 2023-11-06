using DotNetTest.Domain.Models;
using DotNetTest.Domain.SeedWork;

namespace DotNetTest.Domain.AggregatesModel.ProductAggregate;

public interface IProductFinder : IFinder<ProductDto, int>
{
    Task<IList<ProductDto>> GetList();
}