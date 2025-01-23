using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JEX.Assessment.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleError()
    {
        // Retrieve the exception details from the HttpContext
        var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();

        if (exceptionDetails != null)
        {
            var exception = exceptionDetails.Error;

            return Problem(
                detail: exception.Message, // Use exception details in the response
                statusCode: StatusCodes.Status500InternalServerError,
                title: "An unexpected error occurred."
            );
        }

        return Problem(
            detail: "An unexpected error occurred, but no exception details are available.",
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}

