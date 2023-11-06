using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ProductByIdQuery : IRequest<ProductDto>
{
    public int ProductId { get; set; }

    public ProductByIdQuery(int productId)
    {
        ProductId = productId;
    }
}