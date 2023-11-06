using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Api.Controllers;

[ApiController]
[Route("health/")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetHealth()
    {
        return Task.FromResult<IActionResult>(Ok("OK"));
    }
}