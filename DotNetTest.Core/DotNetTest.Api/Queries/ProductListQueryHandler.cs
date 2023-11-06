using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IList<ProductDto>>
{
    private readonly IProductFinder _finder;

    public ProductListQueryHandler(IProductFinder finder)
    {
        _finder = finder;
    }

    public async Task<IList<ProductDto>> Handle(ProductListQuery request, CancellationToken cancellationToken)
    {
        return await _finder.GetList();
    }
}