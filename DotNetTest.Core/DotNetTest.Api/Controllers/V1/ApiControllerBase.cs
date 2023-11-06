using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetTest.Api.Constants;
using DotNetTest.Api.SeedWork;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Api.Controllers.V1;

[ApiController]
[Route(ApiConstants.ContextPathV1 + "[Controller]")]
public class ApiControllerBase : ControllerBase
{
    private const int OkCode = 200;
    private const int BadRequestCode = 400;
    private const int UnauthorizedCode = 401;
    private const int PaymentRequiredCode = 402;
    private const int ForbiddenCode = 403;
    private const int NotFoundCode = 404;

    protected Task<IActionResult> SuccessRequest(object data)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        var response = new ResponseData()
        {
            Code = OkCode,
            Status = true,
            Message = "Successful response",
            Data = JsonSerializer.SerializeToNode(data, options)
        };
        return Task.FromResult<IActionResult>(Ok(response));
    }

    protected Task<IActionResult> UnSuccessRequest(object message)
    {
        var response = new ResponseData()
        {
            Code = BadRequestCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(BadRequest(response));
    }

    protected Task<IActionResult> UnSuccessRequestNotFound(object message)
    {
        var response = new ResponseData()
        {
            Code = NotFoundCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(NotFound(response));
    }

    protected Task<IActionResult> UnexpectedErrorRequest(object message)
    {
        var response = new ResponseData()
        {
            Code = BadRequestCode,
            Status = true,
            Message = message,
            Data = ""
        };
        return Task.FromResult<IActionResult>(BadRequest(response));
    }
}
