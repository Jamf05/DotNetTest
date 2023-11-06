using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductDto>
{
    private readonly IProductFinder _finder;

    public ProductByIdQueryHandler(IProductFinder productFinder)
    {
        _finder = productFinder;
    }

    public async Task<ProductDto> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _finder.FindByIdAsync(request.ProductId);
    }
}