using DotNetTest.Domain.Models;
using MediatR;

namespace DotNetTest.Api.Queries;

public class InvoiceByTheLastQuery : IRequest<InvoiceDto?>
{
}