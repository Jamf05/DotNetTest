using System.Data;
using Dapper;
using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Domain.Exception;
using DotNetTest.Domain.Models;
using DotNetTest.Infrastructure.Finder.Util;

namespace DotNetTest.Infrastructure.Finder.Product;

public class ProductFinder : IProductFinder
{
    private readonly IDbConnection _connection;

    public ProductFinder(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<ProductDto> FindByIdAsync(int productId)
    {
        var sql = SqlReader.GetQuery("get-product-by-id").Result;
        var dictionary = new Dictionary<string, object>()
        {
            { "@Id", productId }
        };

        var parameters = new DynamicParameters(dictionary);

        var product = await _connection.QueryAsync<ProductDto>(sql, parameters);

        var productListDto = product.ToList();
        if (product == null || !productListDto.Any()) throw new BadRequestException("Product does not exist.");

        var currentProduct = productListDto.FirstOrDefault();

        if (currentProduct == null) throw new BadRequestException("Product does not exist.");

        return currentProduct;
    }

    public async Task<IList<ProductDto>> GetListAsync()
    {
        var sql = SqlReader.GetQuery("get-product-list").Result;

        var product = await _connection.QueryAsync<ProductDto>(sql);

        var productListDto = product.ToList();

        return productListDto;
    }
}