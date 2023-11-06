using System.Data;
using Dapper;
using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.Exception;
using DotNetTest.Domain.Models;
using DotNetTest.Infrastructure.Finder.Util;

namespace DotNetTest.Infrastructure.Finder.Client;

public class ClientFinder : IClientFinder
{
    private readonly IDbConnection _connection;

    public ClientFinder(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<ClientDto> FindByIdAsync(int clientId)
    {
        var sql = SqlReader.GetQuery("get-client-by-id").Result;
        var dictionary = new Dictionary<string, object>()
        {
            { "@ClientId", clientId }
        };

        var parameters = new DynamicParameters(dictionary);

        var client = await _connection.QueryAsync<ClientDto, ClientTypeDto, ClientDto>(sql, (client, clientType) =>
        {
            client.ClientType = clientType;
            return client;
        }, parameters, splitOn: "Id, Id");

        var clientListDto = client.ToList();
        if (client == null || !clientListDto.Any()) throw new BadRequestException("Product does not exist.");

        var currentClient = clientListDto.FirstOrDefault();

        if (currentClient == null) throw new BadRequestException("Client does not exist.");

        return currentClient;
    }

    public Task<IList<ClientDto>> GetList()
    {
        throw new NotImplementedException();
    }
}