using DotNetTest.Api.Constants;
using DotNetTest.Api.Queries;
using DotNetTest.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Api.Controllers.V1;

[ApiController]
[Route(ApiConstants.ContextPathV1 + "[Controller]")]
public class ClientController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("get-by-id")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductById(int clientId)
    {
        try
        {
            var product = new ClientByIdQuery(clientId);
            var result = await _mediator.Send(product);
            return await SuccessRequest(result);
        }
        catch (EntityNotFoundException e)
        {
            return await UnSuccessRequestNotFound(e.Message);
        }
        catch (ExceptionBase e)
        {
            return await UnSuccessRequest(e.Message);
        }

        catch (BadRequestException e)
        {
            return await UnSuccessRequest(e.Message);
        }

        catch (Exception e)
        {
            return await UnSuccessRequest(e.Message);
        }
    }
}