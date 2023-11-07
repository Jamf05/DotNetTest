using DotNetTest.Api.Application.Commands;
using DotNetTest.Api.Constants;
using DotNetTest.Api.Queries;
using DotNetTest.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Api.Controllers.V1;

[ApiController]
[Route(ApiConstants.ContextPathV1 + "[Controller]")]
public class InvoiceController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("get-by-id")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInvoiceById(int invoiceId)
    {
        try
        {
            var query = new InvoiceByIdQuery(invoiceId);
            var result = await _mediator.Send(query);
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

    [Route("get-by-client-id")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInvoiceByClientId(int clientId)
    {
        try
        {
            var query = new InvoiceByClientIdQuery(clientId);
            var result = await _mediator.Send(query);
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

    [Route("get-by-the-last")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInvoiceByTheLast()
    {
        try
        {
            var query = new InvoiceByTheLastQuery();
            var result = await _mediator.Send(query);
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDetail(CreateInvoiceCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
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