using Api.Middleware;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Common;

public class BaseController : ControllerBase
{
    protected IActionResult Success(object o) => Ok(o);
    
    protected IActionResult Success() => Ok();

    protected IActionResult Failure(object o)
    {
        return BadRequest(new ErrorDetails()
        {
            Title = "Bad Request",
            Message = o.ToString(),
            StatusCode = 400,
            Errors = new Dictionary<string, string[]>()
        });
    }
}