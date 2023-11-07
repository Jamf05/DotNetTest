using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class ProductListQuery : IRequest<IList<ProductDto>>
{
}